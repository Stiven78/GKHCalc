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
    public partial class House : Form
    {
        private int Id = -1;
        private Models.Objects.House HouseCurent = new Models.Objects.House();
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
            HouseCurent.PostCode =int.Parse(PostCode.Text);
            ObjectService.InsertOrUpdate(HouseCurent);
            this.Close();
        }
    }
}
