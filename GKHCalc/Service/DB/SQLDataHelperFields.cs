using System;
using System.Data;

namespace GKHCalc.Service
{
    public static class SQLDataHelperFields
    {
        #region fields parse

        /// <summary>
        /// Gets a string of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>A string value</returns>
        public static string GetString(IDataReader rdr, string columnName)
        {
            return GetString(rdr, columnName, string.Empty);
        }

        /// <summary>
        /// Gets a string of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <param name="defaultValue"></param>
        /// <returns>A string value</returns>
        public static string GetString(IDataReader rdr, string columnName, string defaultValue)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return defaultValue;
            }
            return Convert.ToString(rdr.GetValue(index));
        }

        /// <summary>
        /// Gets an integer value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>An integer value</returns>
        public static int GetInt(IDataReader rdr, string columnName)
        {
            return GetInt(rdr, columnName, 0);
        }

        /// <summary>
        /// Gets an integer value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <param name="defaultValue"></param>
        /// <returns>An integer value</returns>
        public static int GetInt(IDataReader rdr, string columnName, int defaultValue)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return defaultValue;
            }
            return Convert.ToInt32(rdr.GetValue(index));
        }

        /// <summary>
        /// Gets an integer value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>An integer value</returns>
        public static bool GetBool(IDataReader rdr, string columnName)
        {
            return GetBool(rdr, columnName, false);
        }

        /// <summary>
        /// Gets an integer value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <param name="defaultValue"></param>
        /// <returns>An integer value</returns>
        public static bool GetBool(IDataReader rdr, string columnName, bool defaultValue)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return defaultValue;
            }
            return Convert.ToBoolean(rdr.GetValue(index));
        }

        /// <summary>
        /// Gets an integer value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>An integer value</returns>
        public static DateTime GetDateTime(IDataReader rdr, string columnName)
        {
            return GetDateTime(rdr, columnName, 0);
        }

        /// <summary>
        /// Gets an integer value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <param name="defaultValue"></param>
        /// <returns>An integer value</returns>
        public static DateTime GetDateTime(IDataReader rdr, string columnName, int defaultValue)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return DateTime.Now;
            }
            return Convert.ToDateTime(rdr.GetValue(index));
        }

        #endregion

        /// <summary>
        /// Gets an integer value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <returns>An integer value</returns>
        public static float GetFloat(IDataReader rdr, string columnName)
        {
            return GetInt(rdr, columnName, 0);
        }

        /// <summary>
        /// Gets an integer value of a data reader by a column name
        /// </summary>
        /// <param name="rdr">Data reader</param>
        /// <param name="columnName">Column name</param>
        /// <param name="defaultValue"></param>
        /// <returns>An integer value</returns>
        public static float GetFloat(IDataReader rdr, string columnName, float defaultValue)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return defaultValue;
            }
            return float.Parse(rdr.GetValue(index).ToString());
        }        
    }
}
