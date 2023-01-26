using GKHCalc.Models;
using GKHCalc.Models.Enums;
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

namespace GKHCalc.Forms
{
    public partial class Menu : Form
    {
        public string MenuItem = "House";
        private List<EnumList> enumListsMenu = EnumExtensions.LocalizeListEMenuItem();

        public Menu()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {        
            var CurentItem = enumListsMenu.Where(x => x.Localize == listBox1.SelectedItem.ToString()).ToList();
            if (CurentItem.Count > 0 &&
                MenuItem != CurentItem[0].Name)
            {
                MenuItem = CurentItem[0].Name;
                GetData(null, null);
            }           
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            foreach (var item in enumListsMenu) 
            {
                listBox1.Items.Add(item.Localize);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            OpenModal(-1);
        }

        private void GetData(object sender, FormClosedEventArgs e)
        {
            switch (MenuItem) 
            {              
                case "User":
                    dataGrid.DataSource = ObjectService.GetAll(new Models.Objects.User());
                    break;
                case "Apartments":
                    dataGrid.DataSource = ObjectService.GetAll(new Models.Objects.Apartments());
                    break;
                case "House":
                    dataGrid.DataSource = ObjectService.GetAll(new Models.Objects.House());
                    break;                    
            }
        }

        private void OpenModal(int ObjectId)
        {
            Form form = new Form();
            switch (MenuItem)
            {
                case "User":
                    form = new User(ObjectId);
                    break;
                case "Apartments":
                    form = new Apartaments(ObjectId);
                    break;
                case "House":
                    form = new House(ObjectId);
                    break;
            }
            form.Show();
            form.FormClosed += GetData;
        }

        private void Edit_Click(object sender, EventArgs e)
        {

        }
    }
}
