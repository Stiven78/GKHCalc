using GKHCalc.Enum;
using System;

namespace GKHCalc.Models.Attributies
{
    public class Localize : Attribute, IAttribute<string>
    {
        private string _key;

        public Localize(string key)
        {
            _key = key;
        }

        public string Value
        {
            get { return _key; }
        }
    }
}