
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
            this.DelButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.apartamentMenu = new System.Windows.Forms.MenuStrip();
            this.dataTpFilling = new System.Windows.Forms.DateTimePicker();
            this.labData = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Number
            // 
            this.Number.Location = new System.Drawing.Point(151, 17);
            this.Number.Name = "Number";
            this.Number.Size = new System.Drawing.Size(121, 20);
            this.Number.TabIndex = 2;
            // 
            // SquareMeters
            // 
            this.SquareMeters.Location = new System.Drawing.Point(151, 101);
            this.SquareMeters.Name = "SquareMeters";
            this.SquareMeters.Size = new System.Drawing.Size(121, 20);
            this.SquareMeters.TabIndex = 3;
            // 
            // Name
            // 
            this.Name.Location = new System.Drawing.Point(151, 55);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(121, 20);
            this.Name.TabIndex = 4;
            // 
            // HouseId
            // 
            this.HouseId.FormattingEnabled = true;
            this.HouseId.Location = new System.Drawing.Point(151, 141);
            this.HouseId.Name = "HouseId";
            this.HouseId.Size = new System.Drawing.Size(121, 21);
            this.HouseId.TabIndex = 5;
            // 
            // ImportantUserId
            // 
            this.ImportantUserId.FormattingEnabled = true;
            this.ImportantUserId.Location = new System.Drawing.Point(151, 184);
            this.ImportantUserId.Name = "ImportantUserId";
            this.ImportantUserId.Size = new System.Drawing.Size(121, 21);
            this.ImportantUserId.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(27, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 35);
            this.label1.TabIndex = 7;
            this.label1.Text = "Номер квартиры";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(27, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 30);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ответственный за квартиру";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Дом";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Площадь";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(27, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 31);
            this.label6.TabIndex = 12;
            this.label6.Text = "Название квартиры";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 49);
            this.button1.TabIndex = 13;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labData);
            this.panel1.Controls.Add(this.dataTpFilling);
            this.panel1.Controls.Add(this.DelButton);
            this.panel1.Controls.Add(this.EditButton);
            this.panel1.Controls.Add(this.AddButton);
            this.panel1.Controls.Add(this.dataGrid);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 303);
            this.panel1.TabIndex = 14;
            // 
            // DelButton
            // 
            this.DelButton.Location = new System.Drawing.Point(207, 15);
            this.DelButton.Name = "DelButton";
            this.DelButton.Size = new System.Drawing.Size(75, 23);
            this.DelButton.TabIndex = 18;
            this.DelButton.Text = "Удалить";
            this.DelButton.UseVisualStyleBackColor = true;
            this.DelButton.Click += new System.EventHandler(this.DelButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(105, 15);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(96, 23);
            this.EditButton.TabIndex = 17;
            this.EditButton.Text = "Редактировать";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(24, 15);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 16;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(0, 55);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(603, 248);
            this.dataGrid.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.Number);
            this.panel2.Controls.Add(this.SquareMeters);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.Name);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.HouseId);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.ImportantUserId);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(645, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(283, 303);
            this.panel2.TabIndex = 19;
            // 
            // apartamentMenu
            // 
            this.apartamentMenu.Location = new System.Drawing.Point(0, 0);
            this.apartamentMenu.Name = "apartamentMenu";
            this.apartamentMenu.Size = new System.Drawing.Size(936, 24);
            this.apartamentMenu.TabIndex = 20;
            this.apartamentMenu.Text = "menuStrip1";
            this.apartamentMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // dataTpFilling
            // 
            this.dataTpFilling.Location = new System.Drawing.Point(304, 29);
            this.dataTpFilling.Name = "dataTpFilling";
            this.dataTpFilling.Size = new System.Drawing.Size(200, 20);
            this.dataTpFilling.TabIndex = 19;
            // 
            // labData
            // 
            this.labData.AutoSize = true;
            this.labData.Location = new System.Drawing.Point(304, 8);
            this.labData.Name = "labData";
            this.labData.Size = new System.Drawing.Size(92, 13);
            this.labData.TabIndex = 21;
            this.labData.Text = "Выбирете месяц";
            // 
            // Apartaments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 353);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.apartamentMenu);
            this.MainMenuStrip = this.apartamentMenu;
            this.Text = "Квартира";
            this.Load += new System.EventHandler(this.Apartaments_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button DelButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip apartamentMenu;
        private System.Windows.Forms.Label labData;
        private System.Windows.Forms.DateTimePicker dataTpFilling;
    }
}