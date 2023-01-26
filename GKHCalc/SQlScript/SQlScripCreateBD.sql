GO
CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [FirtsName] NVARCHAR(MAX) NOT NULL, 
    [LastName] NVARCHAR(MAX) NOT NULL, 
    [Patranumic] NVARCHAR(MAX) NOT NULL, 
    [Phone] NVARCHAR(MAX) NOT NULL, 
    [Email] NVARCHAR(MAX) NOT NULL, 
    [Password] NVARCHAR(MAX) NOT NULL,
    [Enabled] bit NOT NULL,
    [TypeUser] int NOT NULL,
)
GO
CREATE TABLE [dbo].[House]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [PostCode] INT NOT NULL, 
    [Addres] NVARCHAR(MAX) NOT NULL,
)
GO
CREATE TABLE [dbo].[Apartments]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [SquareMeters] float NOT NULL, 
    [Number] INT NOT NULL, 
    [ImportantUserId] INT NOT NULL, 
    [HouseId] INT NOT NULL, 
    CONSTRAINT [FK_Apartments_User_ImportantUserId] FOREIGN KEY([ImportantUserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_Apartments_House_HouseId] FOREIGN KEY([HouseId]) REFERENCES [dbo].[House] ([Id])
)


GO
CREATE TABLE [dbo].[RegisteredUser]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [ApartamentId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_RegisteredUser_Apartments_ApartamentId] FOREIGN KEY([ApartamentId]) REFERENCES [dbo].[Apartments] ([Id]),
    CONSTRAINT [FK_RegisteredUser_User_UserId] FOREIGN KEY([UserId]) REFERENCES [dbo].[User] ([Id])
)
GO
CREATE TABLE [dbo].[Payments]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [ApartamentId] INT NOT NULL, 
    [Validation] bit NOT NULL, 
    [Date] datetime NOT NULL, 
    CONSTRAINT [FK_Payments_Apartments_ApartamentId] FOREIGN KEY([ApartamentId]) REFERENCES [dbo].[Apartments] ([Id])
)
GO
CREATE TABLE [dbo].[Rates]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [TypeRate] INT NOT NULL, 
    [Rate] INT NOT NULL, 
    [HouseId] INT NOT NULL, 
    CONSTRAINT [FK_Rates_House_HouseId] FOREIGN KEY([HouseId]) REFERENCES [dbo].[House] ([Id])
)
GO
CREATE TABLE [dbo].[Indicators]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Indication] INT NOT NULL, 
    [Date] datetime NOT NULL, 
    [ApartamentId] INT NOT NULL, 
    [RateId] INT NOT NULL, 
    CONSTRAINT [FK_Indicators_Rates_RateId] FOREIGN KEY([RateId]) REFERENCES [dbo].[Rates] ([Id]),
    CONSTRAINT [FK_Indicators_Apartments_ApartamentId] FOREIGN KEY([ApartamentId]) REFERENCES [dbo].[Apartments] ([Id])
)
GO
