using GKHCalc.Service.Helper;
using System;
using System.Text.RegularExpressions;

namespace GKHCalc.Service.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidEmail(this string strEmail)
        {

            if (string.IsNullOrEmpty(strEmail))
                return false;

            var r = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                              RegexOptions.IgnoreCase | RegexOptions.Singleline);

            return r.IsMatch(strEmail);
        }
        public static bool IsValidNumber(this string str)
        {
            if (int.TryParse(str, out int Val) && Val > -1)
                return true;
            return false;
        }
        public static bool IsValidFloat(this string str)
        {
            if (float.TryParse(str, out float Val) && Val > 0)
                return true;
            return false;
        }
        public static bool IsValidDateTime(this string str)
        {
            if (DateTime.TryParse(str, out DateTime date) && date.Year > 2010)
                return true;
            return false;
        }

        public static bool IsNotWhitespace(this string str) 
        {
            return str.IndexOf(" ") == -1;
        }

        public static bool ValidString(this string val, string Message, int CountSimbols = 0, Func<string, bool> func = null)
        {
            bool isValid = string.IsNullOrEmpty(val);
            isValid = isValid || !((CountSimbols != 0 && CountSimbols <= val.Length) || (CountSimbols == 0));
            isValid = isValid || (func != null && !func(val));
            if (isValid)
            {
                FormHelper.ViewMessageError(Message,"Ошибка");
                return true;
            }
            return false;
        }
    }
}
