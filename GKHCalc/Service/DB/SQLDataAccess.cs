using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKHCalc.Service
{
    public class SQLDataAccess : IDisposable
    {
        public SqlCommand cmd;
        public SqlConnection cn;

        /// <summary>
        /// Define the internalSQLConnection with default connectionString
        /// </summary>
        /// <remarks></remarks>
        public SQLDataAccess()
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Учеба(Улгту)\ПИ\v2\GKHCalc\GKHCalc\DB\DB.mdf;Integrated Security=True");
            cmd = new SqlCommand { Connection = cn };
        }

        /// <summary>
        /// Define the internalSQLConnection with custom connectionString
        /// </summary>
        /// <param name="strConnectionString"></param>
        /// <remarks></remarks>
        public SQLDataAccess(string strConnectionString, int commandTimeout = 60)
        {
            cn = new SqlConnection(strConnectionString);
            cmd = new SqlCommand { Connection = cn, CommandTimeout = commandTimeout };
        }

        private void Inititialize(string commandText, CommandType commandType, SqlParameter[] parameters)
        {
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            cmd.Parameters.Clear();

            if (parameters != null && parameters.Any(param => param != null && param.Value == null))
                throw new NoNullAllowedException("param name: " + parameters.Where(p => p != null && p.Value == null).Select(p => p.ParameterName).AggregateString(","));

            if (parameters != null)
                cmd.Parameters.AddRange(parameters.Where(param => param != null).ToArray());

           // DataModificationFlag.SetLastModifiedSql(commandText, commandType);
        }


        public static void ExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            using (var db = new SQLDataAccess())
            {
                db.Inititialize(commandText, commandType, parameters);

                db.cnOpen();
                db.cmd.ExecuteNonQuery();
                db.cnClose();
            }
        }

        public static List<TResult> ExecuteReadList<TResult>(string commandText, CommandType commandType, Func<SqlDataReader, TResult> function, params SqlParameter[] parameters)
        {
            var res = new List<TResult>();
            using (var db = new SQLDataAccess())
            {
                db.Inititialize(commandText, commandType, parameters);

                db.cnOpen();
                using (var reader = db.cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res.Add(function(reader));
                    }
                }
                db.cnClose();
            }
            return res;
        }

        public static TResult ExecuteReadOne<TResult>(string commandText, CommandType commandType, Func<SqlDataReader, TResult> function, params SqlParameter[] parameters)
        {
            using (var db = new SQLDataAccess())
            {
                db.Inititialize(commandText, commandType, parameters);

                db.cnOpen();
                using (var reader = db.cmd.ExecuteReader())
                {
                    return reader.Read() ? function(reader) : default(TResult);
                }
            }
        }

        #region Connection functions

        /// <summary>
        /// Open connection to SQL DB
        /// </summary>
        /// <remarks></remarks>
        public void cnOpen()
        {
            cn.Open();
        }

        /// <summary>
        /// Close connection to DB
        /// </summary>
        /// <remarks></remarks>
        public void cnClose()
        {
            if ((cn != null) && (cn.State != ConnectionState.Closed))
            {
                cn.Close();
            }
        }

        /// <summary>
        /// Get status of current connection
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public ConnectionState cnStatus()
        {
            return cn.State;
        }

        #endregion

        #region  IDisposable Support

        private bool _disposedValue; // To detect redundant calls

        // IDisposable

        ~SQLDataAccess()// the finalizer
        {
            Dispose(false);
        }

        // This code added by Visual Basic to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue && disposing)
            {
                if (cn.State != ConnectionState.Closed)
                    cn.Close();

                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
                if (cn != null)
                {
                    cn.Dispose();
                    cn = null;
                }
            }
            _disposedValue = true;
        }

        #endregion

    }
}
