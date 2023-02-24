namespace GKHCalc.Models.Objects
{
    public class BalanceHouse : Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float sumCredit { get; set; }
        public float PaymentSum { get; set; }
    }
}
