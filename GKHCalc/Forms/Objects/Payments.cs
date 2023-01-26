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
using OModel = GKHCalc.Models.Objects;

namespace GKHCalc.Forms.Objects
{
    public partial class Payments : Form
    {
        private int _Id, _ApartamentId;
        private OModel.Payments payment = new OModel.Payments();

        public Payments(int Id, int ApartamentId)
        {
            InitializeComponent();
            _Id = Id;
            _ApartamentId = ApartamentId;
        }

        private void Payments_Load(object sender, EventArgs e)
        {
            if (_Id > 0)
            {
                payment = ObjectService.GetById(payment, _Id);
                if (payment != null &&
                    payment.Id > 0)
                {
                    dateTime.Value = payment.Date;
                    tBSum.Text = payment.Sum.ToString();
                    cBoxValidation.Checked = payment.Validation;
                }
            }
            else
            {
                payment.ApartamentId = _ApartamentId;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (
                tBSum.Text.ValidString("Нужно заполнить адрес", func: StringExtensions.IsValidFloat) ||
                dateTime.Value.ToString().ValidString("Некорректная дата",func: StringExtensions.IsValidDateTime)
                )
            {
                return;
            }
            payment.Sum = float.Parse(tBSum.Text);
            payment.Date = dateTime.Value;
            payment.Validation = cBoxValidation.Checked;
            ObjectService.InsertOrUpdate(payment);
        }
    }
}
