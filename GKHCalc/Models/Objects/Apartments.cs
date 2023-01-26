using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKHCalc.Models.Objects
{
    public class Apartments:Base
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public int Number { get; set; }
        public float SquareMeters { get; set; }
        public int ImportantUserId { get; set; }
        public string Name { get; set; }

        public override string Table() => "[dbo].[Apartments]";
    }
}
