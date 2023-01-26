using GKHCalc.Models;
using GKHCalc.Service;
using GKHCalc.Service.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                }
            }
            listBox.Items.AddRange(new List<string>() { "Показатели", "Платежи", "Прописаные пользователи" }.ToArray());
            listBox.SelectedIndex = 0;

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

        private void button2_Click(object sender, EventArgs e)
        {
            OpenModal(-1);

        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var CurentItem = enumListsMenu.Where(x => x.Localize == listBox.SelectedItem.ToString()).ToList();
            if (CurentItem.Count > 0 &&
                MenuItem != CurentItem[0].Name)
            {
                MenuItem = CurentItem[0].Name;
                GetData(null, null);
            }
        }

        private void GetData(object sender, FormClosedEventArgs e)
        {
            switch (MenuItem)
            {
                case "Indicators":
                    dataGrid.DataSource = ObjectService.GetsByFieldId(new ObjectModel.Indicators(), FieldForWhere, Id);
                    break;
                case "Payments":
                    dataGrid.DataSource = ObjectService.GetsByFieldId(new ObjectModel.Payments(), FieldForWhere, Id);
                    break;
                case "RegisteredUser":
                    dataGrid.DataSource = ObjectService.GetsByFieldId(new ObjectModel.RegisteredUser(), FieldForWhere, Id);
                    break;
            }
        }

        private void OpenModal(int ObjectId)
        {
            Form form = new Form();
            switch (MenuItem)
            {
                case "Indicators":
                    form = new User(ObjectId);
                    break;
                case "Payments":
                    form = new Apartaments(ObjectId);
                    break;
                case "RegisteredUser":
                    form = new House(ObjectId);
                    break;
            }
            form.Show();
            form.FormClosed += GetData;
        }
    }
}
