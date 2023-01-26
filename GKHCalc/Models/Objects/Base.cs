using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKHCalc.Models.Objects
{
    public abstract class Base
    {
        public virtual string Table() => string.Empty;
    }
}
