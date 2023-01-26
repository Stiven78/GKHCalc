
namespace GKHCalc.Forms
{
    partial class User
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.Password = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.Patranumic = new System.Windows.Forms.TextBox();
            this.LastName = new System.Windows.Forms.TextBox();
            this.Phone = new System.Windows.Forms.MaskedTextBox();
            this.Enabled = new System.Windows.Forms.CheckBox();
            this.TypeUsers = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FirstName
            // 
            this.FirstName.Location = new System.Drawing.Point(173, 23);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(104, 20);
            this.FirstName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Фамилия";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(111, 242);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(98, 42);
            this.Save.TabIndex = 2;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(174, 153);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(104, 20);
            this.Password.TabIndex = 5;
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(174, 127);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(104, 20);
            this.Email.TabIndex = 6;
            // 
            // Patranumic
            // 
            this.Patranumic.Location = new System.Drawing.Point(174, 75);
            this.Patranumic.Name = "Patranumic";
            this.Patranumic.Size = new System.Drawing.Size(104, 20);
            this.Patranumic.TabIndex = 7;
            // 
            // LastName
            // 
            this.LastName.Location = new System.Drawing.Point(174, 49);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(104, 20);
            this.LastName.TabIndex = 8;
            // 
            // Phone
            // 
            this.Phone.Location = new System.Drawing.Point(174, 101);
            this.Phone.Mask = "+7(000)000-00-00";
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(104, 20);
            this.Phone.TabIndex = 9;
            // 
            // Enabled
            // 
            this.Enabled.AutoSize = true;
            this.Enabled.Location = new System.Drawing.Point(207, 179);
            this.Enabled.Name = "Enabled";
            this.Enabled.Size = new System.Drawing.Size(29, 17);
            this.Enabled.TabIndex = 10;
            this.Enabled.Text = " ";
            this.Enabled.UseVisualStyleBackColor = true;
            // 
            // TypeUsers
            // 
            this.TypeUsers.FormattingEnabled = true;
            this.TypeUsers.Location = new System.Drawing.Point(173, 202);
            this.TypeUsers.Name = "TypeUsers";
            this.TypeUsers.Size = new System.Drawing.Size(103, 21);
            this.TypeUsers.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Имя";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Отчество";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Номер телефона";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Email";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Пароль";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Активность";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Роль пользователя";
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 297);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TypeUsers);
            this.Controls.Add(this.Enabled);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.Patranumic);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FirstName);
            this.Name = "User";
            this.Text = "Пользователь";
            this.Load += new System.EventHandler(this.User_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.TextBox Patranumic;
        private System.Windows.Forms.TextBox LastName;
        private System.Windows.Forms.MaskedTextBox Phone;
        private System.Windows.Forms.CheckBox Enabled;
        private System.Windows.Forms.ComboBox TypeUsers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}