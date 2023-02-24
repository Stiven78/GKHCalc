
declare @dateCurent  datetime2 = '2023-01-01'
declare @FillingMonth table (
	HouseId int,
	Name nvarchar(max),
	PerPerson float,
	PerSquareMeter float,
	ForAnApartment float,
	ByIndications float
);

insert into @FillingMonth 
select 
a.HouseId ,
a.Name , 
iif(r.TypeRate = 0, r.Rate * (iif(registUser.Counts > 0, 1, registUser.Counts)), 0) as PerPerson,
iif(r.TypeRate = 1, a.SquareMeters * r.Rate, 0) as PerSquareMeter,
iif(r.TypeRate = 2, r.Rate * 1, 0) as ForAnApartment,
iif(r.TypeRate = 3, r.Rate * (iif(indicApartament.Indication > 0, indicApartament.Indication, 0)), 0) as ByIndications
from dbo.Apartments a
inner join dbo.Rates r on r.HouseId = a.HouseId
left join (
select i.ApartamentId, i.RateId as RateId, i.Indication as Indication from dbo.Indicators i
where MONTH(i.Date) = MONTH(@dateCurent)
and Year(i.Date) = Year(@dateCurent)
and i.ApartamentId = 1
		) indicApartament on indicApartament.ApartamentId = a.Id and indicApartament.RateId = r.Id
left join (
select ru.ApartamentId as ApartamentId , Count(*) as Counts from dbo.RegisteredUser ru 
where ru.ApartamentId=1
and ((MONTH(ru.DateRegistration) = MONTH(@dateCurent)
and Year(ru.DateRegistration) = Year(@dateCurent))
or (ru.DateRegistration < @dateCurent))
group by ru.ApartamentId) registUser on registUser.ApartamentId= a.Id
where a.Id=1


select fm.HouseId,fm.Name, 
sum(fm.PerPerson) as PerPerson, 
sum(fm.PerSquareMeter) as PerSquareMeter, 
sum(fm.ForAnApartment) as ForAnApartment, 
sum(fm.ByIndications) as ByIndications 
from @FillingMonth fm
group by fm.HouseId,fm.Name