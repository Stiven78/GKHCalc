using GKHCalc.Service;
using GKHCalc.Service.Extensions;
using GKHCalc.Service.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ObjModel = GKHCalc.Models.Objects;

namespace GKHCalc.Forms.Objects
{
    public partial class Indicators : Form
    {
        private int _objId = 0, _apartamentId = 0;
        private ObjModel.Indicators _indicators = new ObjModel.Indicators();
        private List<ObjModel.Rates> _rates = new List<ObjModel.Rates>();

        public Indicators(int objectId, int apartamentId)
        {
            _objId = objectId;
            _apartamentId = apartamentId;
            InitializeComponent();
        }

        private void Indicators_Load(object sender, EventArgs e)
        {
            _rates = ObjectService.GetsByWhere(new ObjModel.Rates(), $@" HouseId in (select HouseId from dbo.Apartments a where a.Id={_apartamentId}) and TypeRate = 3");
            if (_rates.Count == 0)
            {
                MessageBox.Show("Не добавлены тарифы для дома");
                this.Close();
                return;
            }

            cBTypeRate.Items.AddRange(_rates.Select(x=>x.Name).ToArray());
            if (_objId > 0)
            {
                _indicators = ObjectService.GetById(_indicators, _objId);
                if (_indicators != null &&
                    _indicators.Id > 0)
                {
                    dTDate.Value = _indicators.Date;
                    tBIndicator.Text = _indicators.Indication.ToString();
                    cBTypeRate.SelectedIndex = _rates.FindIndex(x=>x.Id == _indicators.RateId);
                }
            }
            else
            {
                cBTypeRate.SelectedIndex = 0;
                _indicators.ApartamentId = _apartamentId;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (
                tBIndicator.Text.ToString().ValidString("Введите значение показаний", func: StringExtensions.IsValidNumber)
                )
                return;
            ObjModel.Rates RateCurrent = _rates[cBTypeRate.SelectedIndex];

            var indicatorCurrent = ObjectService.GetsByWhere(_indicators, $@" month(Date)={dTDate.Value.Month}  and YEAR(Date)={dTDate.Value.Year} and RateId={RateCurrent.Id}");
            if (indicatorCurrent.Count > 0 && !indicatorCurrent.Any(iC => iC.Id == _objId))
            {
                FormHelper.ViewMessageError("Данные уже введены за этот месяц", "Ошибка");
                return;
            }

            _indicators.Date = dTDate.Value;
            _indicators.Indication = int.Parse(tBIndicator.Text);
            _indicators.RateId = RateCurrent.Id;
            ObjectService.InsertOrUpdate(_indicators);
            FormHelper.ViewMessageGood(_objId != 0 ? "Показания обновлены" : "Показания сохранены", "Показания");
            this.Close();
        }
    }
}
