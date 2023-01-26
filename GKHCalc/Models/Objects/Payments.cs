using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKHCalc.Models.Objects
{
    public class Payments : Base
    {
        public int Id { get; set; }
        public int ApartamentId { get; set; }
        public bool Validation { get; set; }
        public float Sum { get; set; }
        public DateTime Date { get; set; }
        public override string Table() => "[dbo].[Payments]";
    }
}
