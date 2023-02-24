using GKHCalc.Models.Objects;
using GKHCalc.Service;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GKHCalc
{
    public partial class Auth : Form
    {
        public static int UserId = 0;
        public static User User = null;

        public Auth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Customers = ObjectService.GetsByWhere(new User(), $@" Email = '{ txtBEmail.Text }' and Password = '{ txtBPassword.Text }' and Enabled = 1");
            if (Customers.Count > 0)
            {
                UserId = Customers.First().Id;
                User = Customers.First();
                MessageBox.Show("Авторизация выполнена");
                var Form = new Forms.Menu();
                Form.Show();
                this.Hide();
                return;
            }

            MessageBox.Show("Некорректные введенные данные");

        }
        private void Registration_Click(object sender, EventArgs e)
        {
            this.Hide();
            Forms.User user = new Forms.User(-1);
            user.FormClosed += (object send, FormClosedEventArgs ec) =>
            {
                this.Show();
            };
            user.Show();
        }
    }
}
