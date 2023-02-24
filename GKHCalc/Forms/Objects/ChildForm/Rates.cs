using GKHCalc.Service;
using GKHCalc.Service.Extensions;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GKHCalc.Forms.Objects
{
    public partial class Rates : Form
    {
        private int _objId = 0, _houseId = 0;
        private Models.Objects.Rates _rateCurrent = new Models.Objects.Rates();
        public Rates(int Id,int HouseId = 0)
        {
            _objId = Id;
            _houseId = HouseId;
            InitializeComponent();
        }

        private void Rates_Load(object sender, EventArgs e)
        {
            cbRates.Items.AddRange(EnumExtensions
                        .LocalizeListETypeRate()
                        .Select(en => en.Localize)
                        .ToArray());

            if (_objId > 0)
            {
                _rateCurrent = ObjectService.GetById(_rateCurrent, _objId);
                if (_rateCurrent != null &&
                    _rateCurrent.Id > 0)
                {
                    tbName.Text = _rateCurrent.Name;
                    tbRate.Text = _rateCurrent.Rate.ToString();
                    cbRates.SelectedIndex = _rateCurrent.TypeRate;
                }
                else
                {
                    _rateCurrent.HouseId = _houseId;
                }
            }
            else
            {
                _rateCurrent.HouseId = _houseId;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (
                    tbName.Text.ValidString("Некорректное название тарифа") ||
                    tbRate.Text.ValidString("Некорректное значение тарифа", func: StringExtensions.IsValidNumber) ||
                    cbRates.SelectedIndex.ToString().ValidString("Некорректный тип тарифа", 1)
                )
            {
                return;
            }

            _rateCurrent.Name = tbName.Text;
            _rateCurrent.Rate = int.Parse(tbRate.Text);
            _rateCurrent.TypeRate = cbRates.SelectedIndex;
            ObjectService.InsertOrUpdate(_rateCurrent);
            this.Close();
        }
    }
}
