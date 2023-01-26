using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GKHCalc.Service.Helper
{
    public class SqlHelperService
    {
        public static string GetPartRequestSQL(Type myType, int TypeStr = 1, List<string> NotUseProperty = null)
        {
            string result = string.Empty;
            foreach (MemberInfo member in myType.GetMembers())
            {
                if (member.MemberType != MemberTypes.Property)
                    continue;

                if (NotUseProperty != null && NotUseProperty.Any(str => str == member.Name))
                    continue;

                switch (TypeStr)
                {
                    case 1:
                        result += (result != string.Empty ? "," : "") + $@"{member.Name}";
                        break;
                    case 2:
                        result += (result != string.Empty ? "," : "") + $@"@{member.Name}";
                        break;
                    case 3:
                        result += (result != string.Empty ? "," : "") + $@"{member.Name}=@{member.Name}";
                        break;
                }
            }
            return result;
        }

        public static SqlParameter[] GetParamsForRequest(Type myType, string strObject, List<string> NotUseProperty = null)
        {
            List<SqlParameter> result = new List<SqlParameter>();
            var ObjectDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(strObject);
            foreach (MemberInfo member in myType.GetMembers())
            {
                if (member.MemberType != MemberTypes.Property)
                    continue;

                if (NotUseProperty != null && NotUseProperty.Any(str => str == member.Name))
                    continue;

                result.Add(new SqlParameter($@"@{member.Name}", $@"{ObjectDictionary[member.Name]}"));
            }
            return result.ToArray();
        }

        public static T ParseItemSql<T>(Type myType, SqlDataReader reader)
        {
            Dictionary<string, object> dictionaryList = new Dictionary<string, object>();
            List<SqlParameter> result = new List<SqlParameter>();

            var list = myType.GetMembers();

            foreach (MemberInfo member in myType.GetMembers())
            {
                if (member.MemberType != MemberTypes.Property)
                    continue;

                string str = ((PropertyInfo)member).PropertyType.Name;

                dictionaryList.Add(member.Name, GetVal(((PropertyInfo)member).PropertyType.Name, reader, member.Name));
            }

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(dictionaryList));
        }

        private static object GetVal(string TypeProp, SqlDataReader reader, string nameField)
        {
            try
            {
                switch (TypeProp)
                {
                    case "Int32":
                        return SQLDataHelperFields.GetInt(reader, nameField);
                    case "String":
                        return SQLDataHelperFields.GetString(reader, nameField);
                    case "Boolean":
                        return SQLDataHelperFields.GetBool(reader, nameField);
                    case "Single":
                        return SQLDataHelperFields.GetFloat(reader, nameField);
                }
            }
            catch (Exception ex)
            {
                int i = 123;
            }
            return null;
        }
    }
}
