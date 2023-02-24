
namespace GKHCalc.Forms.Objects
{
    partial class RegisteredUser
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
            this.cBUsers = new System.Windows.Forms.ComboBox();
            this.cBApartaments = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateRegistration = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // cBUsers
            // 
            this.cBUsers.FormattingEnabled = true;
            this.cBUsers.Location = new System.Drawing.Point(129, 6);
            this.cBUsers.Name = "cBUsers";
            this.cBUsers.Size = new System.Drawing.Size(130, 21);
            this.cBUsers.TabIndex = 0;
            // 
            // cBApartaments
            // 
            this.cBApartaments.FormattingEnabled = true;
            this.cBApartaments.Location = new System.Drawing.Point(129, 64);
            this.cBApartaments.Name = "cBApartaments";
            this.cBApartaments.Size = new System.Drawing.Size(130, 21);
            this.cBApartaments.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Житель";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Квартира";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(57, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 51);
            this.button2.TabIndex = 4;
            this.button2.Text = "Сохранить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Дата прописки";
            // 
            // dateRegistration
            // 
            this.dateRegistration.Location = new System.Drawing.Point(129, 38);
            this.dateRegistration.Name = "dateRegistration";
            this.dateRegistration.Size = new System.Drawing.Size(130, 20);
            this.dateRegistration.TabIndex = 6;
            // 
            // RegisteredUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 177);
            this.Controls.Add(this.dateRegistration);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cBApartaments);
            this.Controls.Add(this.cBUsers);
            this.Name = "RegisteredUser";
            this.Text = "RegisteredUser";
            this.Load += new System.EventHandler(this.RegisteredUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBUsers;
        private System.Windows.Forms.ComboBox cBApartaments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateRegistration;
    }
}