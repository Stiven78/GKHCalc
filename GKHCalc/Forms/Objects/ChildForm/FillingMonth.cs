using GKHCalc.Service;
using GKHCalc.Service.Helper;
using System;
using System.Linq;
using System.Windows.Forms;
using ObjModel = GKHCalc.Models.Objects;

namespace GKHCalc.Forms.Objects.ChildForm
{
    public partial class FillingMonth : Form
    {
        private int _apartamentId = 0, _Id = 0;
        private DateTime _dateTime;
        private ObjModel.FillingMonth _fillingMonth = new ObjModel.FillingMonth();
        public FillingMonth(int Id, int ApartamentId, DateTime? dateTime = null)
        {
            _Id = Id;
            _apartamentId = ApartamentId;
            _dateTime = dateTime.HasValue?dateTime.Value:DateTime.Now;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var monthFillings = ObjectService.GetsByWhere(_fillingMonth, $@" ApartamentId = {_apartamentId} 
                                                                            and ((MONTH(DateFilling) = {_dateTime.Month})
                                                                            and Year(DateFilling) = {_dateTime.Year} ) ");
            if (monthFillings.Count > 0 &&
                !monthFillings.Any(x=> x.Id == _fillingMonth.Id)) 
            {
                FormHelper.ViewMessageError("Запись на эту дату добавлена, отредактируйте запись", "Ошибка");
                return;
            }
            ObjectService.InsertOrUpdate(_fillingMonth);
            FormHelper.ViewMessageGood("Запись за месяц сохранена", "Запись за месяц");
            this.Close();
        }

        private void FillingMonth_Load(object sender, EventArgs e)
        {
            if (_Id > 0)
            {
                _fillingMonth = ObjectService.GetById(_fillingMonth, _Id);
                if (_fillingMonth.Id > 0)
                {
                    _dateTime = _fillingMonth.DateFilling;
                }
                var fillingMonth = ObjectService.GetFillingMonth(_fillingMonth, _dateTime, _apartamentId);
                _fillingMonth.PerPerson = fillingMonth.PerPerson;
                _fillingMonth.PerSquareMeter = fillingMonth.PerSquareMeter;
                _fillingMonth.ForAnApartment = fillingMonth.ForAnApartment;
                _fillingMonth.ByIndications = fillingMonth.ByIndications;

            }
            else
            {
                _fillingMonth = ObjectService.GetFillingMonth(_fillingMonth, _dateTime, _apartamentId);
                _fillingMonth.DateFilling = _dateTime;
                _fillingMonth.ApartamentId = _apartamentId;
            }
            txtBPerPerson.Text = _fillingMonth.PerPerson.ToString();
            txtBPerSquareMeter.Text = _fillingMonth.PerSquareMeter.ToString();
            txtBForAnApartment.Text = _fillingMonth.ForAnApartment.ToString();
            txtBByIndications.Text = _fillingMonth.ByIndications.ToString();
            txtBSum.Text = (_fillingMonth.ByIndications + _fillingMonth.ForAnApartment + _fillingMonth.PerSquareMeter + _fillingMonth.PerPerson).ToString();

            if (Auth.User != null &&
                Auth.User.Id > 0 &&
                Auth.User.TypeUser == 0)
            {
                txtBPerSquareMeter.Enabled = txtBForAnApartment.Enabled = txtBByIndications.Enabled = txtBSum.Enabled = txtBPerPerson.Enabled = false;
            }
        }
    }
}
