
namespace GKHCalc.Forms.Objects.ChildForm
{
    partial class FillingMonth
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBPerPerson = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBByIndications = new System.Windows.Forms.TextBox();
            this.txtBForAnApartment = new System.Windows.Forms.TextBox();
            this.txtBPerSquareMeter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBSum = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "За человека";
            // 
            // txtBPerPerson
            // 
            this.txtBPerPerson.Location = new System.Drawing.Point(130, 6);
            this.txtBPerPerson.Name = "txtBPerPerson";
            this.txtBPerPerson.Size = new System.Drawing.Size(100, 20);
            this.txtBPerPerson.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "По показаниям";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "За квартиру";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "За кв. метр";
            // 
            // txtBByIndications
            // 
            this.txtBByIndications.Location = new System.Drawing.Point(130, 85);
            this.txtBByIndications.Name = "txtBByIndications";
            this.txtBByIndications.Size = new System.Drawing.Size(100, 20);
            this.txtBByIndications.TabIndex = 9;
            // 
            // txtBForAnApartment
            // 
            this.txtBForAnApartment.Location = new System.Drawing.Point(130, 59);
            this.txtBForAnApartment.Name = "txtBForAnApartment";
            this.txtBForAnApartment.Size = new System.Drawing.Size(100, 20);
            this.txtBForAnApartment.TabIndex = 10;
            // 
            // txtBPerSquareMeter
            // 
            this.txtBPerSquareMeter.Location = new System.Drawing.Point(130, 33);
            this.txtBPerSquareMeter.Name = "txtBPerSquareMeter";
            this.txtBPerSquareMeter.Size = new System.Drawing.Size(100, 20);
            this.txtBPerSquareMeter.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Итог";
            // 
            // txtBSum
            // 
            this.txtBSum.Location = new System.Drawing.Point(130, 110);
            this.txtBSum.Name = "txtBSum";
            this.txtBSum.Size = new System.Drawing.Size(100, 20);
            this.txtBSum.TabIndex = 13;
            // 
            // FillingMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 199);
            this.Controls.Add(this.txtBSum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBPerSquareMeter);
            this.Controls.Add(this.txtBForAnApartment);
            this.Controls.Add(this.txtBByIndications);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBPerPerson);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "FillingMonth";
            this.Text = "FillingMonth";
            this.Load += new System.EventHandler(this.FillingMonth_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBPerPerson;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBByIndications;
        private System.Windows.Forms.TextBox txtBForAnApartment;
        private System.Windows.Forms.TextBox txtBPerSquareMeter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBSum;
    }
}