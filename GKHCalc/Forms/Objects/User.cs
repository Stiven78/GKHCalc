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
    public partial class User : Form
    {
        private int Id = -1;
        private Models.Objects.User UserCurent = new Models.Objects.User();
        public User(int UserId)
        {
            Id = UserId;
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (
                FirstName.Text.ValidString("Некорректная фамилия",3) ||
                LastName.Text.ValidString("Некорректная имя",3) ||
                Patranumic.Text.ValidString("Некорректная отчество",3) ||
                Email.Text.ValidString("Некорректный Email",func:StringExtensions.IsValidEmail) ||
                Password.Text.ValidString("Некорректный пароль",3) ||
                Phone.Text.ValidString("Некорректный номер телефона",11)
                ) 
            {
                return;
            }
            UserCurent.FirtsName = FirstName.Text;
            UserCurent.LastName = LastName.Text;
            UserCurent.Patranumic = Patranumic.Text;
            UserCurent.Email = Email.Text;
            UserCurent.Password = Password.Text;
            UserCurent.Phone = Phone.Text;
            UserCurent.Enabled = Enabled.Checked;
            UserCurent.TypeUser = TypeUsers.SelectedIndex;
            ObjectService.InsertOrUpdate(UserCurent);
            this.Close();
        }

        private void User_Load(object sender, EventArgs e)
        {
           TypeUsers.Items.AddRange(EnumExtensions
                                   .LocalizeListTypeUser()
                                   .Select(en => en.Name)
                                   .ToArray());

            if (Id > 0)
            {
                UserCurent = ObjectService.GetById(UserCurent,Id);
                if (UserCurent != null &&
                    UserCurent.Id > 0)
                {
                    FirstName.Text = UserCurent.FirtsName;
                    LastName.Text = UserCurent.LastName;
                    Patranumic.Text = UserCurent.Patranumic;
                    Phone.Text = UserCurent.Phone.ToString();
                    Email.Text = UserCurent.Email;
                    Password.Text = UserCurent.Password;
                    Enabled.Checked = UserCurent.Enabled;
                    TypeUsers.SelectedIndex = UserCurent.TypeUser;
                }
            }
        }
    }
}
