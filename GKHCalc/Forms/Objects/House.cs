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

namespace GKHCalc.Forms
{
    public partial class House : Form
    {
        private int Id = -1;
        private Models.Objects.House HouseCurent = new Models.Objects.House();
        private string MenuItem = "Rates";
        private List<EnumList> enumListsMenuHouse = EnumExtensions.LocalizeListEMenuHouseItem();


        public House(int HouseId)
        {
            this.Id = HouseId;
            InitializeComponent();
        }

        private void House_Load(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                HouseCurent = ObjectService.GetById(HouseCurent, Id);
                if (HouseCurent != null &&
                    HouseCurent.Id > 0)
                {
                    Addres.Text = HouseCurent.Addres;
                    PostCode.Text = HouseCurent.PostCode.ToString();
                }
                enumListsMenuHouse.ForEach(x =>
                {
                    menuMain.Items.Add(x.Localize);
                });
                GetData(null, null);
            }
            else
            {
                panel1.Visible = false;
                this.Width = 300;
                panel2.Location = new Point(10,40);
            }




       
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (
                Addres.Text.ValidString("Нужно заполнить адрес") ||
                PostCode.Text.ValidString("Незаполнен или не корректный индекс дома", 6)
            )
            {
                return;
            }
            HouseCurent.Addres = Addres.Text;
            HouseCurent.PostCode = int.Parse(PostCode.Text);
            ObjectService.InsertOrUpdate(HouseCurent);
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormHelper.OpenModal(MenuItem, -1, GetData,parentId: Id);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!FormHelper.GetIdGridTable(dataGrid, out int objId) && objId == 0)
                return;
            FormHelper.OpenModal(MenuItem, objId, GetData);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            FormHelper.DeleteItem(dataGrid, MenuItem);
            GetData(null, null);
        }

        private void GetData(object sender, FormClosedEventArgs e)
        {
            var CurentItem = enumListsMenuHouse.Where(x => x.Name == MenuItem).ToList();
            if (CurentItem != null && CurentItem.Count > 0)
            {
                foreach (ToolStripItem item in menuMain.Items)
                {
                    item.BackColor = item.Text == CurentItem[0].Localize ? Color.White : Color.WhiteSmoke;
                }
            }
            dataGrid.DataSource = FormHelper.GetData(MenuItem, Id);
            switch (MenuItem)
            {
                case "IndebtednessApartment":
                    dataGrid.Columns[0].Visible = false;
                    dataGrid.Columns[1].HeaderText = "Название квартиры";
                    dataGrid.Columns[2].HeaderText = "Сумма долга, \nЕсли отрицательное значение то переплата";
                    dataGrid.Columns[2].Width = 150;
                    dataGrid.Columns[3].HeaderText = "Не подтвержденный платеж";
                    break;
                case "Rates":
                    dataGrid.Columns[0].Visible = false;
                    dataGrid.Columns[1].HeaderText = "Название тарифа";
                    dataGrid.Columns[2].HeaderText = "Тип тарифа";
                    dataGrid.Columns[3].HeaderText = "Стоимость тарифа";
                    dataGrid.Columns[4].Visible = false;
                    break;
            }
        }

        private void menuMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var CurentItem = enumListsMenuHouse.Where(x => x.Localize == e.ClickedItem.Text).ToList();
            if (CurentItem.Count > 0 &&
                MenuItem != CurentItem[0].Name)
            {                
                MenuItem = CurentItem[0].Name;
                btnAdd.Visible = MenuItem != "IndebtednessApartment";
                btnEdit.Visible = MenuItem != "IndebtednessApartment";
                btnDel.Visible = MenuItem != "IndebtednessApartment";
                GetData(null, null);
            }
        }
    }
}
