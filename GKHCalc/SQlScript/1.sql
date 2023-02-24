
select* from(
select a.Id
, iif(r.TypeRate = 1, a.SquareMeters* r.Rate,0) as perSqueareMeter
, iif(r.TypeRate = 2, 1 * r.Rate, 0) as forAnApartment
, iif(r.TypeRate = 3, PresonTable.Indication * r.Rate, 0) as byIndications
, iif(r.TypeRate = 0, iif(UserCount.CountUser = 0, 1, UserCount.CountUser) * r.Rate, 0) as perPerson
from dbo.House h
inner
join dbo.Apartments a on h.Id = a.HouseId
inner
join dbo.Rates r on r.HouseId = h.Id
left
join (
			select a.Id as ApartamentId, i.RateId as RateId, SUM(i.Indication) as Indication from dbo.Apartments a
			inner
																							 join dbo.Indicators i on i.ApartamentId = a.Id
			group by a.Id, i.RateId) PresonTable on PresonTable.ApartamentId=a.Id and PresonTable.RateId=r.Id
left join ( 
			select a.Id as ApartamentId, Count(ru.UserId) as CountUser from dbo.Apartments a
			left join dbo.RegisteredUser ru on ru.ApartamentId = a.Id
			group by a.Id ) UserCount on UserCount.ApartamentId=a.Id
group by a.Id, r.Rate, r.TypeRate) SumApartament


  --select a.Id as ApartamentId, i.RateId as RateId, SUM(i.Indication) as Indication
  --from dbo.Apartments a
--inner join dbo.Indicators i on i.ApartamentId = a.Id
  --group by a.Id, i.RateId
  

--left join (
  --			select a.Id, Sum(p.Sum) as SumPayment from dbo.Payments p
--			inner join dbo.Apartments a on p.ApartamentId = a.Id
  --          group by a.Id ) PaymentApartment on PaymentApartment.Id=a.Id

