using GKHCalc.Service;
using GKHCalc.Service.Extensions;
using GKHCalc.Service.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ObjectModel = GKHCalc.Models.Objects;

namespace GKHCalc.Forms.Objects
{
    public partial class RegisteredUser : Form
    {
        public List<ObjectModel.Apartments> Apartaments = ObjectService.GetAll(new ObjectModel.Apartments());
        public List<ObjectModel.User> Users = ObjectService.GetAll(new ObjectModel.User());
        int ApartamentId = -1;
        public RegisteredUser(int ApartamentId)
        {
            this.ApartamentId = ApartamentId;
            InitializeComponent();
        }

        private void RegisteredUser_Load(object sender, EventArgs e)
        {
            if (Users.Count == 0) {
                MessageBox.Show("Нужно внести пользователей в систему");
                this.Close();
            }
            cBUsers.Items.AddRange(Users.Select(x=>$@"{x.FirtsName} {x.LastName} {x.Patranumic}").ToArray());
            cBApartaments.Visible = label4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (
                    cBUsers.SelectedIndex.ToString().ValidString("Нужно выбрать пользователя", func: StringExtensions.IsValidNumber)
                )
            {
                return;
            }
            ObjectModel.RegisteredUser registeredUser = new ObjectModel.RegisteredUser()
            {
                ApartamentId = this.ApartamentId,
                UserId = Users[cBUsers.SelectedIndex].Id,
                DateRegistration = dateRegistration.Value
            };
            ObjectService.InsertOrUpdate(registeredUser);
            FormHelper.ViewMessageGood("Пользователь прописан", "Прописка");
            Close();
        }
    }
}
