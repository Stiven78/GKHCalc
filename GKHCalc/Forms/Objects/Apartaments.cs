using GKHCalc.Models;
using GKHCalc.Service;
using GKHCalc.Service.Extensions;
using GKHCalc.Service.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ObjectModel = GKHCalc.Models.Objects;

namespace GKHCalc.Forms
{
    public partial class Apartaments : Form
    {
        private int Id = -1;
        private ObjectModel.Apartments ApartmentCurent = new ObjectModel.Apartments();
        private List<ObjectModel.House> HouseList = new List<ObjectModel.House>();
        private List<ObjectModel.User> UserList = new List<ObjectModel.User>();
        private List<EnumList> enumListsMenu = EnumExtensions.LocalizeListEMenuApartamentItem();
        private string MenuItem = "Indicators";
        private string FieldForWhere = "ApartamentId";

        public Apartaments(int ApartamentId)
        {
            Id = ApartamentId;
            InitializeComponent();
            HouseList = ObjectService.GetAll(new ObjectModel.House());
            UserList = ObjectService.GetAll(new ObjectModel.User());
        }

        private void Apartaments_Load(object sender, EventArgs e)
        {
            if (HouseList.Count == 0 || UserList.Count == 0)
            {
                MessageBox.Show("Необходимо добавить записи о домах или пользователях в систему");
                this.Close();
            }

            ObjectModel.User user = new ObjectModel.User();

            if (Auth.UserId > 0)
            {
                user = ObjectService.GetById(user, Auth.UserId);
            }

            HouseId.Items.AddRange(HouseList.Select(x => x.Addres).ToArray());
            ImportantUserId.Items.AddRange(UserList.Select(x => $@"{x.FirtsName} {x.LastName} {x.Patranumic}").ToArray());
            if (Id > 0)
            {
                ApartmentCurent = ObjectService.GetById(ApartmentCurent, Id);
                if (ApartmentCurent != null &&
                    ApartmentCurent.Id > 0)
                {
                    int HouseIdItem = HouseList.FindIndex(x=>x.Id == ApartmentCurent.HouseId);
                    int UserId = UserList.FindIndex(x=>x.Id == ApartmentCurent.ImportantUserId);
                    Number.Text = ApartmentCurent.Number.ToString();
                    Name.Text = ApartmentCurent.Name;
                    SquareMeters.Text = ApartmentCurent.SquareMeters.ToString();
                    HouseId.SelectedIndex = HouseIdItem;//ApartmentCurent.HouseId;
                    ImportantUserId.SelectedIndex = UserId;//ApartmentCurent.ImportantUserId;
                    ImportantUserId.Enabled = HouseId.Enabled = user != null && user.TypeUser == 1;
                }
            }

            enumListsMenu.ForEach((eMenu)=> {
                apartamentMenu.Items.Add(eMenu.Localize);
            });
            GetData(null, null);
            labData.Visible = false;
            dataTpFilling.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (
                Number.Text.ValidString("Нужно заполнить номер дома", func: StringExtensions.IsValidNumber) ||
                Name.Text.ValidString("Незаполнен или не корректно название") ||
                SquareMeters.Text.ValidString("Незаполнен или не корректно значение площади", func: StringExtensions.IsValidFloat) ||
                ImportantUserId.SelectedIndex.ToString().ValidString("Незаполнен или не корректный ответственный пользователь", func: StringExtensions.IsValidNumber) ||
                HouseId.SelectedIndex.ToString().ValidString("Незаполнен или не корректный выбранный дом", func: StringExtensions.IsValidNumber)
                ) 
            {
                return;
            }
            ApartmentCurent.Number = int.Parse(Number.Text);
            ApartmentCurent.Name = Name.Text;
            ApartmentCurent.SquareMeters = float.Parse(SquareMeters.Text);
            ApartmentCurent.ImportantUserId = UserList[ImportantUserId.SelectedIndex].Id;
            ApartmentCurent.HouseId = HouseList[HouseId.SelectedIndex].Id;
            ObjectService.InsertOrUpdate(ApartmentCurent);
            this.Close();
        }

        private void GetData(object sender, FormClosedEventArgs e)
        {
            dataGrid.DataSource = FormHelper.GetData(MenuItem, Id, FieldForWhere);
            switch (MenuItem)
            {
                case "Indicators":
                    dataGrid.Columns[0].Visible = false;
                    dataGrid.Columns[3].Visible = false;
                    dataGrid.Columns[1].HeaderText = "Показания";
                    dataGrid.Columns[2].HeaderText = "Дата";
                    dataGrid.Columns[4].HeaderText = "Тариф";
                    break;
                case "Payments":
                    dataGrid.Columns[0].Visible = false;
                    dataGrid.Columns[2].HeaderText = "Подтверждение";
                    dataGrid.Columns[4].HeaderText = "Дата";
                    dataGrid.Columns[3].HeaderText = "Сумма";
                    break;
                case "RegisteredUser":
                    dataGrid.Columns[0].Visible = false;
                    dataGrid.Columns[2].HeaderText = "Пользователь";
                    dataGrid.Columns[3].HeaderText = "Дата прописки";
                    break;
                case "FillingMonth":
                    dataGrid.Columns[0].Visible = false;
                    dataGrid.Columns[1].Visible = false;
                    dataGrid.Columns[2].HeaderText = "За человека";
                    dataGrid.Columns[3].HeaderText = "По площади";
                    dataGrid.Columns[4].HeaderText = "За квартиру";
                    dataGrid.Columns[5].HeaderText = "По показаниям";
                    dataGrid.Columns[5].Width = 110;
                    dataGrid.Columns[6].HeaderText = "Дата";
                    break;

            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var CurentItem = enumListsMenu.Where(x => x.Localize == e.ClickedItem.Text).ToList();
            if (CurentItem.Count > 0 &&
                MenuItem != CurentItem[0].Name)
            {
                MenuItem = CurentItem[0].Name;                
                GetData(null, null);

                labData.Visible = MenuItem == "FillingMonth";
                dataTpFilling.Visible = MenuItem == "FillingMonth";

                if (Auth.User != null &&
                    Auth.User.Id > 0 &&
                    Auth.User.TypeUser == 0)
                {
                    EditButton.Enabled = !(MenuItem == "RegisteredUser");
                    DelButton.Enabled = false;
                    AddButton.Enabled = !(MenuItem == "RegisteredUser");
                }
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            FormHelper.OpenModal(MenuItem, -1, GetData, parentId: Id, dateTime: dataTpFilling.Value);
        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            FormHelper.DeleteItem(dataGrid, MenuItem);
            GetData(null, null);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (!FormHelper.GetIdGridTable(dataGrid, out int objId) && objId == 0)
                return;
            FormHelper.OpenModal(MenuItem, objId, GetData, parentId: Id);
        }
    }
}

