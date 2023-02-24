



select a.Id,a.Name,(fmAll.allSum - paymentValid.PaymentSum) as sumCredit,paymentNotValid.PaymentSum from dbo.Apartments a 
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
