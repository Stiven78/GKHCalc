using GKHCalc.Models.Attributies;
using GKHCalc.Models.Enums;
using System.Collections.Generic;
using GKHCalc.Models;

namespace GKHCalc.Service.Extensions
{
    public static class EnumExtensions
    {
        public static string Localize(this System.Enum enumValue)
        {
            return AttributeHelper.GetAttributeValueField<Localize, string>(enumValue);
        }

        public static List<EnumList> LocalizeListTypeUser() 
        {
            List<EnumList> EnumList = new List<EnumList>();

            foreach (ETypeUsers item in System.Enum.GetValues(typeof(ETypeUsers)))
            {
                EnumList.Add(new EnumList() { Localize = item.Localize(), Name= item.ToString() });
            }
            return EnumList;
        }

        public static List<EnumList> LocalizeListEMenuItem()
        {
            List<EnumList> EnumList = new List<EnumList>();

            foreach (EMenuItem item in System.Enum.GetValues(typeof(EMenuItem)))
            {
                EnumList.Add(new EnumList() { Localize = item.Localize(), Name = item.ToString() });
            }
            return EnumList;
        }

        public static List<EnumList> LocalizeListEMenuHouseItem()
        {
            List<EnumList> EnumList = new List<EnumList>();

            foreach (EMenuHouseItem item in System.Enum.GetValues(typeof(EMenuHouseItem)))
            {
                EnumList.Add(new EnumList() { Localize = item.Localize(), Name = item.ToString() });
            }
            return EnumList;
        }

        public static List<EnumList> LocalizeListEMenuApartamentItem()
        {
            List<EnumList> EnumList = new List<EnumList>();

            foreach (EMenuApartamentItem item in System.Enum.GetValues(typeof(EMenuApartamentItem)))
            {
                EnumList.Add(new EnumList() { Localize = item.Localize(), Name = item.ToString() });
            }
            return EnumList;
        }

        public static List<EnumList> LocalizeListETypeRate()
        {
            List<EnumList> EnumList = new List<EnumList>();

            foreach (ETypeRate item in System.Enum.GetValues(typeof(ETypeRate)))
            {
                EnumList.Add(new EnumList() { Localize = item.Localize(), Name = item.ToString() });
            }
            return EnumList;
        }
    }
}
