using GKHCalc.Models;
using GKHCalc.Service;
using GKHCalc.Service.Extensions;
using GKHCalc.Service.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ModelObject = GKHCalc.Models.Objects;

namespace GKHCalc.Forms
{
    public partial class Menu : Form
    {
        public string MenuItem = "House";
        private List<EnumList> enumListsMenu = EnumExtensions.LocalizeListEMenuItem();
        public ModelObject.User user = new ModelObject.User();

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            user = ObjectService.GetById(user, Auth.UserId);
            if (user != null && user.Id > 0)
            {
                label1.Text = $@"{FormHelper.GetGreetingByTime()} , {user.FirtsName} {user.LastName}";
            }
            enumListsMenu.ForEach((x) =>
            {
                menuMain.Items.Add(x.Localize);
            });
            GetData(null,null);
        }

        private void menuMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var CurentItem = enumListsMenu.Where(x => x.Localize == e.ClickedItem.Text).ToList();
            if (CurentItem.Count > 0 &&
                MenuItem != CurentItem[0].Name)
            {                
                MenuItem = CurentItem[0].Name;
                GetData(null, null);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            FormHelper.OpenModal(MenuItem, -1, GetData);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            FormHelper.DeleteItem(dataGrid,MenuItem);
            FormHelper.ViewMessageGood("Успешно удалено","Удаление");
            GetData(null, null);

        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (!FormHelper.GetIdGridTable(dataGrid, out int objId) && objId == 0)
                return;
            FormHelper.OpenModal(MenuItem, objId, GetData);
        }

        private void GetData(object sender, FormClosedEventArgs e)
        {
            var CurentItem = enumListsMenu.Where(x => x.Name == MenuItem).ToList();
            string whereSql = string.Empty;
            if (CurentItem != null && CurentItem.Count > 0)
            {
                foreach (ToolStripItem item in menuMain.Items)
                {
                    item.BackColor = item.Text == CurentItem[0].Localize ? Color.White : Color.WhiteSmoke;
                }
            }

            if (MenuItem == "Exit") {
                DialogResult result =  MessageBox.Show("Вы уверены что хотите выйти из системы", "Выход", MessageBoxButtons.YesNo);
                if (result.ToString() == "Yes")
                {
                    Auth auth = new Auth();
                    auth.Show();
                    this.Close();
                }
                else
                {
                    MenuItem = "Apartments";
                    GetData(null, null);
                }
                return;
            }

                if (user != null 
                && user.Id > 0 
                && user.TypeUser == 0)
            {
                switch (MenuItem) 
                {
                    case "Apartments":
                        whereSql = $@" ImportantUserId={user.Id}
                                        or exists(select * from dbo.RegisteredUser ru where ApartamentId=Apartments.Id and ru.UserId={user.Id})";
                        Add.Enabled = false;
                        Delete.Enabled = false;
                        Edit.Enabled = true;
                        break;
                    case "House":
                        whereSql = $@" Id in (select HouseId from dbo.Apartments where ImportantUserId = {user.Id})";
                        Add.Enabled = false;
                        Delete.Enabled = false;
                        Edit.Enabled = true;
                        break;
                    case "User":
                        whereSql = $@" Id = {user.Id}";
                        Add.Enabled = true;
                        Delete.Enabled = false;
                        Edit.Enabled = true;
                        break;
                }
            }

            dataGrid.DataSource = FormHelper.GetData(MenuItem, FieldForWhere: whereSql);
            switch (MenuItem)
            {
                case "Apartments":
                    dataGrid.Columns[0].Visible = false;
                    dataGrid.Columns[1].HeaderText = "Номер дома";
                    dataGrid.Columns[2].HeaderText = "Номер квартиры";
                    dataGrid.Columns[3].HeaderText = "Площадь";
                    dataGrid.Columns[4].HeaderText = "Ответственный пользователь";
                    dataGrid.Columns[5].HeaderText = "Название";
                    break;
                case "User":
                    dataGrid.Columns[0].Visible = false;
                    dataGrid.Columns[1].HeaderText = "Имя";
                    dataGrid.Columns[2].HeaderText = "Фамилия";
                    dataGrid.Columns[3].HeaderText = "Отчество";
                    dataGrid.Columns[4].HeaderText = "Телефон";
                    dataGrid.Columns[5].HeaderText = "Почта";
                    dataGrid.Columns[6].HeaderText = "Пароль";
                    dataGrid.Columns[7].HeaderText = "Активность";
                    dataGrid.Columns[8].HeaderText = "Тип пользователя";
                    break;
                case "House":
                    dataGrid.Columns[0].Visible = false;
                    dataGrid.Columns[1].HeaderText = "Адрес";
                    dataGrid.Columns[2].HeaderText = "Индекс";
                    break;


            }
        }
    }
}
