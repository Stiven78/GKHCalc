using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKHCalc.Models.Objects
{
    public class Indicators : Base
    {
        public int Id { get; set; }
        public int Indication { get; set; }
        public DateTime Date { get; set; }
        public int ApartamentId { get; set; }
        public int RateId { get; set; }
        public override string Table() => "[dbo].[Indicators]";
    }
}
