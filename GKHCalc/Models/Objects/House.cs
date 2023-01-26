using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKHCalc.Models.Objects
{
    public class House : Base
    {
        public int Id { get; set; }
        public string Addres { get; set; }
        public int PostCode { get; set; }
        public override string Table() => "[dbo].[House]";
    }
}
