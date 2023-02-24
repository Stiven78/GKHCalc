using System;

namespace GKHCalc.Models.Objects
{
    public class RegisteredUser : Base
    {
        public int Id { get; set; }
        public int ApartamentId { get; set; }
        public int UserId { get; set; }
        public DateTime DateRegistration { get; set; }
        public override string Table() => "[dbo].[RegisteredUser]";
    }
}
