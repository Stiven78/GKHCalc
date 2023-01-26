
namespace GKHCalc.Forms
{
    partial class Apartaments
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
            this.Number = new System.Windows.Forms.TextBox();
            this.SquareMeters = new System.Windows.Forms.TextBox();
            this.Name = new System.Windows.Forms.TextBox();
            this.HouseId = new System.Windows.Forms.ComboBox();
            this.ImportantUserId = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.listBox = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // Number
            // 
            this.Number.Location = new System.Drawing.Point(136, 20);
            this.Number.Name = "Number";
            this.Number.Size = new System.Drawing.Size(121, 20);
            this.Number.TabIndex = 2;
            // 
            // SquareMeters
            // 
            this.SquareMeters.Location = new System.Drawing.Point(136, 104);
            this.SquareMeters.Name = "SquareMeters";
            this.SquareMeters.Size = new System.Drawing.Size(121, 20);
            this.SquareMeters.TabIndex = 3;
            // 
            // Name
            // 
            this.Name.Location = new System.Drawing.Point(136, 58);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(121, 20);
            this.Name.TabIndex = 4;
            // 
            // HouseId
            // 
            this.HouseId.FormattingEnabled = true;
            this.HouseId.Location = new System.Drawing.Point(136, 144);
            this.HouseId.Name = "HouseId";
            this.HouseId.Size = new System.Drawing.Size(121, 21);
            this.HouseId.TabIndex = 5;
            // 
            // ImportantUserId
            // 
            this.ImportantUserId.FormattingEnabled = true;
            this.ImportantUserId.Location = new System.Drawing.Point(136, 187);
            this.ImportantUserId.Name = "ImportantUserId";
            this.ImportantUserId.Size = new System.Drawing.Size(121, 21);
            this.ImportantUserId.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 35);
            this.label1.TabIndex = 7;
            this.label1.Text = "Номер квартиры";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 30);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ответственный за квартиру";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Дом";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Площадь";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 31);
            this.label6.TabIndex = 12;
            this.label6.Text = "Название квартиры";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 49);
            this.button1.TabIndex = 13;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.Add);
            this.panel1.Controls.Add(this.dataGrid);
            this.panel1.Controls.Add(this.listBox);
            this.panel1.Location = new System.Drawing.Point(272, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 289);
            this.panel1.TabIndex = 14;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(16, 226);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 18;
            this.button4.Text = "Удалить";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(10, 161);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Редактировать";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(16, 105);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 16;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(118, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(485, 286);
            this.dataGrid.TabIndex = 15;
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(0, 0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(112, 95);
            this.listBox.TabIndex = 0;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // Apartaments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 431);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ImportantUserId);
            this.Controls.Add(this.HouseId);
            this.Controls.Add(this.Name);
            this.Controls.Add(this.SquareMeters);
            this.Controls.Add(this.Number);
            this.Text = "Квартира";
            this.Load += new System.EventHandler(this.Apartaments_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Number;
        private System.Windows.Forms.TextBox SquareMeters;
        private System.Windows.Forms.TextBox Name;
        private System.Windows.Forms.ComboBox HouseId;
        private System.Windows.Forms.ComboBox ImportantUserId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
    }
}