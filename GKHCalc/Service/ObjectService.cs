using GKHCalc.Models.Objects;
using GKHCalc.Service.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
        public static List<T> GetsByFieldId<T>(T obj, string Field, int Id) where T : Base
        {
            return SQLDataAccess.ExecuteReadList(
                $@"SELECT * FROM {obj.Table()} where { Field }=" + Id,
                CommandType.Text,
                (reader) => {
                    return GetReader<T>(obj.GetType(), reader);
                });
        }
        public static List<T> GetsByWhere<T>(T obj, string where) where T : Base
        {
            return SQLDataAccess.ExecuteReadList(
                $@"SELECT * FROM {obj.Table()} where { where }",
                CommandType.Text,
                (reader) => {
                    return GetReader<T>(obj.GetType(), reader);
                });
        }
        public static T GetFillingMonth<T>(T obj, DateTime dateTime, int ApartamentId) where T : FillingMonth
        {
            return SQLDataAccess.ExecuteReadOne(
                $@" declare @dateCurent  datetime2 = '{dateTime.ToString("yyyy-MM-dd")}'
                    declare @FillingMonth table (
	                    ApartamentId int,
	                    Name nvarchar(max),
	                    PerPerson float,
	                    PerSquareMeter float,
	                    ForAnApartment float,
	                    ByIndications float
                    );

                    insert into @FillingMonth 
                    select a.Id, a.Name, 
                    iif(r.TypeRate = 0, r.Rate * (iif(registUser.Counts > 0, registUser.Counts, 1)), 0) as PerPerson,
                    iif(r.TypeRate = 1, a.SquareMeters * r.Rate, 0) as PerSquareMeter,
                    iif(r.TypeRate = 2, r.Rate * 1, 0) as ForAnApartment,
                    iif(r.TypeRate = 3, r.Rate * (iif(indicApartament.Indication > 0, indicApartament.Indication, 0)), 0) as ByIndications
                    from dbo.Apartments a
                    inner join dbo.Rates r on r.HouseId = a.HouseId
                    left join (
                    select i.ApartamentId, i.RateId as RateId, i.Indication as Indication from dbo.Indicators i
                    where MONTH(i.Date) = MONTH(@dateCurent)
                    and Year(i.Date) = Year(@dateCurent)
                    and i.ApartamentId = {ApartamentId} ) indicApartament on indicApartament.ApartamentId = a.Id and indicApartament.RateId = r.Id

                    left join ( select ru.ApartamentId as ApartamentId , Count(*) as Counts from dbo.RegisteredUser ru 
                    where ru.ApartamentId = {ApartamentId}
                    and ((MONTH(ru.DateRegistration) = MONTH(@dateCurent)
                    and Year(ru.DateRegistration) = Year(@dateCurent))
                    or (ru.DateRegistration < @dateCurent))
                    group by ru.ApartamentId) registUser on registUser.ApartamentId = a.Id
                    where a.Id = {ApartamentId}

                    select 0 as Id, fm.ApartamentId,fm.Name, @dateCurent as DateFilling, 
                    sum(fm.PerPerson) as PerPerson, 
                    sum(fm.PerSquareMeter) as PerSquareMeter, 
                    sum(fm.ForAnApartment) as ForAnApartment, 
                    sum(fm.ByIndications) as ByIndications 
                    from @FillingMonth fm
                    group by fm.ApartamentId, fm.Name",
                CommandType.Text,
                (reader) => {
                    return GetReader<T>(obj.GetType(), reader);
                });
        }
        public static List<T> GetsBalanceHouse<T>(T obj, int HouseId) where T : BalanceHouse
        {
            return SQLDataAccess.ExecuteReadList(
                $@"--Номер квартиры/Название квартиры/Сумма долга/не подтвержденная сумма оплаты
                    select a.Id, a.Name, (fmAll.allSum - paymentValid.PaymentSum) as sumCredit, paymentNotValid.PaymentSum from dbo.Apartments a 
                    inner join (
	                    select fm.ApartamentId,sum(fm.ByIndications + fm.ForAnApartment + fm.PerPerson + fm.PerSquareMeter) as allSum from dbo.FillingMonth fm
	                    group by fm.ApartamentId
                    ) fmAll on fmAll.ApartamentId=a.Id
                    inner join (
	                    select p.ApartamentId,Sum(p.Sum) as PaymentSum from dbo.Payments p
	                    where p.Validation = 1
	                    group by p.ApartamentId
                    ) paymentValid on paymentValid.ApartamentId=a.Id
                    inner join (
	                    select p.ApartamentId,Sum(p.Sum) as PaymentSum from dbo.Payments p
	                    where p.Validation = 0
	                    group by p.ApartamentId
                    ) paymentNotValid on paymentNotValid.ApartamentId=a.Id
                    where a.HouseId={HouseId}",
                CommandType.Text,
                (reader) => {
                    return GetReader<T>(obj.GetType(), reader);
                });
        }
    }
}
