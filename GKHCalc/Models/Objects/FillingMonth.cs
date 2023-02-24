using System;

namespace GKHCalc.Models.Objects
{
    public class FillingMonth : Base
    {
        public int Id { get; set; }
        public int ApartamentId { get; set; }
        public float PerPerson { get; set; }
        public float PerSquareMeter { get; set; }
        public float ForAnApartment { get; set; }
        public float ByIndications { get; set; }
        public DateTime DateFilling { get; set; }
        public override string Table() => "[dbo].[FillingMonth]";
    }
}
