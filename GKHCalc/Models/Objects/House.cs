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
