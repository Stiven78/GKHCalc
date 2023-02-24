select * from dbo.Apartments a 
where a.ImportantUserId=60
or exists(select * from dbo.RegisteredUser ru where ApartamentId=a.Id and ru.UserId=5)

