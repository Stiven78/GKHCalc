using GKHCalc.Models.Objects;
using GKHCalc.Service.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKHCalc.Service
{
    public class ObjectService
    {
        private static List<string> NotUsedProperty = new List<string>() { "Id" };
        private static T GetReader<T>(Type type,SqlDataReader reader)
        {
            return SqlHelperService.ParseItemSql<T>(type, reader);
        }
        public static void InsertOrUpdate<T>(T obj) where T : Base
        {
            var query = $@"IF NOT EXISTS(SELECT * FROM {obj.Table()} WHERE Id=@Id)
            INSERT INTO {obj.Table()} ({SqlHelperService.GetPartRequestSQL(typeof(T), 1, NotUsedProperty)}) 
            VALUES ({SqlHelperService.GetPartRequestSQL(typeof(T), 2, NotUsedProperty)})
            ELSE
            UPDATE {obj.Table()} SET {SqlHelperService.GetPartRequestSQL(typeof(T), 3, NotUsedProperty)}
            WHERE Id=@Id";

            var pars = SqlHelperService.GetParamsForRequest(typeof(T), JsonConvert.SerializeObject(obj), null);

            SQLDataAccess.ExecuteNonQuery(query, CommandType.Text, pars);
        }
        public static void Delete<T>(T obj, int Id) where T : Base
        {
            var query = $@"DELETE FROM {obj.Table()} WHERE Id=@Id";
            SQLDataAccess.ExecuteNonQuery(query, CommandType.Text, new SqlParameter("@Id", Id));
        }
        public static List<T> GetAll<T>(T obj) where T : Base
        {
            return SQLDataAccess.ExecuteReadList(
                $@"SELECT * FROM {obj.Table()}",
                CommandType.Text,
                (reader)=> {
                    return GetReader<T>(obj.GetType(), reader);
                });
        }
        public static T GetById<T>(T obj, int Id) where T : Base
        {
            return SQLDataAccess.ExecuteReadOne(
                $@"SELECT * FROM {obj.Table()} where Id=" + Id,
                CommandType.Text,
                (reader) => {
                    return GetReader<T>(obj.GetType(), reader);
                });
        }

        public static T GetsByFieldId<T>(T obj, string Field, int Id) where T : Base
        {
            return SQLDataAccess.ExecuteReadOne(
                $@"SELECT * FROM {obj.Table()} where { Field }=" + Id,
                CommandType.Text,
                (reader) => {
                    return GetReader<T>(obj.GetType(), reader);
                });
        }
    }
}
