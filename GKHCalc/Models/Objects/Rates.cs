using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKHCalc.Models.Objects
{
    public class Rates : Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeRate { get; set; }
        public int Rate { get; set; }
        public int HouseId { get; set; }
        public override string Table() => "[dbo].[Rates]";
    }
}
