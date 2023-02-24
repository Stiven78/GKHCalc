
declare @dateCurent  datetime2 = '2022-12-01'

select a.Id as ApartamentId, i.RateId as RateId, i.Indication as Indication from dbo.Apartments a
inner join dbo.Indicators i on i.ApartamentId=a.Id
where 
MONTH(i.Date) = MONTH(@dateCurent)
and Year(i.Date) = Year(@dateCurent)
and a.Id=1

select a.*,
r.*,
iif(r.TypeRate = 0,r.Rate * (iif(registUser.Counts = null,1,registUser.Counts)),0) as PerPerson,
iif(r.TypeRate = 1,a.SquareMeters * r.Rate,0) as PerSquareMeter,
iif(r.TypeRate = 2, r.Rate *1, 0) as ForAnApartment,
iif(r.TypeRate = 3, r.Rate * (iif(indicApartament.Indication = null,0,indicApartament.Indication)) ,0) as ByIndications
from dbo.Apartments a
inner join dbo.Rates r on r.HouseId = a.HouseId

left join (
			select i.ApartamentId, i.RateId as RateId, i.Indication as Indication from dbo.Indicators i
			where 
			MONTH(i.Date) = MONTH(@dateCurent)
			and Year(i.Date) = Year(@dateCurent)
			and i.ApartamentId=1
			) indicApartament on indicApartament.ApartamentId=a.Id and indicApartament.RateId=r.Id
left join (
			select ru.ApartamentId as ApartamentId , Count(*) as Counts from dbo.RegisteredUser ru 
			where ru.ApartamentId=1
			and ((MONTH(ru.DateRegistration) = MONTH(@dateCurent)
			and Year(ru.DateRegistration) = Year(@dateCurent))
			or (ru.DateRegistration < @dateCurent))
			group by ru.ApartamentId
		) registUser on registUser.ApartamentId= a.Id
where a.Id=1