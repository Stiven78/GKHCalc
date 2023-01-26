﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKHCalc.Models.Objects
{
    public class RegisteredUser : Base
    {
        public int Id { get; set; }
        public int ApartamentId { get; set; }
        public int UserId { get; set; }
        public override string Table() => "[dbo].[RegisteredUser]";
    }
}