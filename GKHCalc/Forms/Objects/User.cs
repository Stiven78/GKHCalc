using GKHCalc.Service;
using GKHCalc.Service.Extensions;
using GKHCalc.Service.Helper;
using System;
using System.Data;
using System.Linq;
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
                Phone.Text.ValidString("Некорректный номер телефона",11,func:StringExtensions.IsNotWhitespace)
                ) 
            {
                return;
            }

            var User = ObjectService.GetsByWhere(UserCurent,$@" Email='{Email.Text}'").FirstOrDefault();
            if (User != null && User.Id != UserCurent.Id)
            {
                FormHelper.ViewMessageError("Пользователь с такой почтой уже есть в системе", "Пользователь");
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
            FormHelper.ViewMessageGood(Id == -1 ? "Пользователь сохранен" : "Пользователь обновлен", "Пользователь");
            this.Close();
        }

        private void User_Load(object sender, EventArgs e)
        {
            label8.Visible = label9.Visible = TypeUsers.Visible = Enabled.Visible = (Auth.UserId > 0 && Auth.User.Id > 0 && Auth.User.TypeUser == 1) 
                                                                                    || Auth.UserId == 0;
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
