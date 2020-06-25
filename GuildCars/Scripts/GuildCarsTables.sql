Use Master 
GO
DROP DATABASE IF EXISTS
 GuildCars;
 GO
 CREATE DATABASE GuildCars;
 GO
 USE GuildCars
 GO

 IF EXISTS(SELECT * FROM sys.tables WHERE name ='Orders')
	DROP TABLE Orders
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name ='Vehicles')
	DROP TABLE Vehicles
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name ='Model')
	DROP TABLE Model
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name ='Make')
	DROP TABLE Make
GO

 IF EXISTS(SELECT * FROM sys.tables WHERE name ='ContactUs')
	DROP TABLE ContactUs
GO

CREATE TABLE [ContactUs]
(
 [ContactUsId] int NOT NULL IDENTITY(1, 1),
 [Name]        text NOT NULL ,
 [Email]       text NOT NULL ,
 [Phone]       text NOT NULL ,
 [Message]     text NOT NULL ,


 CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED ([ContactUsId])
);
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name ='Specials')
	DROP TABLE Specials
GO

CREATE TABLE [Specials]
(
    [SpecialId]   int NOT NULL IDENTITY(1, 1),
    [SpecialName] text NOT NULL,
	[SpecialDescription] text NOT NULL,
	[SpecialImageFileName]   varchar(50) NOT NULL,
);
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name ='BodyStyle')
	DROP TABLE BodyStyle
GO

CREATE TABLE [BodyStyle]
(
 [BodyStyleId] int NOT NULL IDENTITY(1, 1),
 [BodyStyleName]   text NOT NULL ,


 CONSTRAINT [PK_BodyStyle] PRIMARY KEY CLUSTERED ([BodyStyleId])
);
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name ='ExteriorColor')
	DROP TABLE ExteriorColor
GO

CREATE TABLE [ExteriorColor]
(
    [ExteriorColorId] int NOT NULL IDENTITY(1, 1),
    [ExteriorColorName] text NOT NULL,

    CONSTRAINT [PK_ExteriorColor] PRIMARY KEY CLUSTERED ([ExteriorColorId])
    );
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name ='InteriorColor')
	DROP TABLE InteriorColor
GO

CREATE TABLE [InteriorColor]
(
    [InteriorColorId] int NOT NULL IDENTITY(1, 1),
    [InteriorColorName] text NOT NULL,

    CONSTRAINT [PK_InteriorColor] PRIMARY KEY CLUSTERED ([InteriorColorId])
    );
GO



CREATE TABLE [Make]
(
    [MakeId] int NOT NULL IDENTITY(1, 1),
    [MakeName]   varchar(50) NOT NULL,
	[UserId]     nvarchar(128) NOT NULL,
	[AddedDate]  datetime NOT NULL
    

    CONSTRAINT [PK_Make] PRIMARY KEY CLUSTERED ([MakeId]),
    
);
GO

CREATE TABLE [Model]
(
    [ModelId] int NOT NULL IDENTITY(1, 1),
    [ModelName]   varchar(50) NOT NULL,
	[MakeId]  int NOT NULL,
	[UserId]     nvarchar(128) NOT NULL,
	[AddedDate]  datetime NOT NULL

    CONSTRAINT [PK_Model] PRIMARY KEY CLUSTERED ([ModelId]),
	CONSTRAINT [FK_ModelMake] FOREIGN KEY ([MakeId]) REFERENCES [Make]([MakeId])
);
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name ='PurchaseType')
	DROP TABLE PurchaseType
GO

CREATE TABLE [PurchaseType]
(
    [PurchaseTypeId] int NOT NULL IDENTITY(1, 1),
    [PurchaseTypeName]           text NOT NULL,

    CONSTRAINT [PK_PurchaseType] PRIMARY KEY CLUSTERED ([PurchaseTypeId])
);
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name ='Transmission')
	DROP TABLE Transmission
GO

CREATE TABLE [Transmission]
(
    [TransmissionId] int NOT NULL IDENTITY(1, 1),
    [TransmissionName]   text NOT NULL,

    CONSTRAINT [PK_Transmision] PRIMARY KEY CLUSTERED ([TransmissionId])
);
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name ='NewUsed')
	DROP TABLE NewUsed
GO

CREATE TABLE [NewUsed]
(
    [NewUsedId] int NOT NULL IDENTITY(1, 1),
    [NewUsedName] varchar(20) NOT NULL,

    CONSTRAINT [PK_NewUsed] PRIMARY KEY CLUSTERED ([NewUsedId])
);
GO


CREATE TABLE [Vehicles]
(
 [VehicleId]       int NOT NULL IDENTITY(1, 1),
 [Year]            int NOT NULL ,
 [Description]     varchar(150) NOT NULL ,
 [ImageFileName]   varchar(50) NOT NULL,
 [MSRP]            int NOT NULL ,
 [Mileage]         int NOT NULL ,
 [VIN]             text NOT NULL ,
 [SalePrice]       int NULL ,
 [MakeId]          int NOT NULL ,
 [ModelId]         int NOT NULL ,
 [NewUsedId]       int NOT NULL ,
 [BodyStyleId]     int NOT NULL ,
 [InteriorColorId] int NOT NULL ,
 [ExteriorColorId] int NOT NULL ,
 [TransmissionId]  int NOT NULL ,
 [DateAdded]       datetime NOT NULL,
 [HasBeenSold]     bit NOT NULL,
 [IsFeatured]      bit NOT NULL,


 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED ([VehicleId]),
 CONSTRAINT [FK_VehiclesMake] FOREIGN KEY ([MakeId])  REFERENCES [Make]([MakeId]),
 CONSTRAINT [FK_VehiclesNewUsed] FOREIGN KEY ([NewUsedId])  REFERENCES [NewUsed]([NewUsedId]),
 CONSTRAINT [FK_VehiclesBodyStyle] FOREIGN KEY ([BodyStyleId])  REFERENCES [BodyStyle]([BodyStyleId]),
 CONSTRAINT [FK_VehiclesInteriorColor] FOREIGN KEY ([InteriorColorId])  REFERENCES [InteriorColor]([InteriorColorId]),
 CONSTRAINT [FK_VehiclesExteriorColor] FOREIGN KEY ([ExteriorColorID])  REFERENCES [ExteriorColor]([ExteriorColorID]),
 CONSTRAINT [FK_VehiclesTransmission] FOREIGN KEY ([TransmissionId])  REFERENCES [Transmission]([TransmissionId])
);
GO



CREATE TABLE [Orders]
(
 [OrderId]         int NOT NULL IDENTITY(1, 1),
 [UserId]          nvarchar(128) NOT NULL,
 [OrderDate]       datetime NOT NULL ,
 [OrderTotal]      int NOT NULL ,
 [VehicleId]       int NOT NULL ,
 [CustomerName]    text NOT NULL ,
 [CustomerPhone]   text NOT NULL ,
 [CustomerEmail]   text NOT NULL ,
 [CustomerStreet1] text NOT NULL ,
 [CustomerStreet2] text NULL ,
 [CustomerCity]    text NOT NULL ,
 [CustomerState]   text NOT NULL ,
 [CustomerZipcode] int NOT NULL ,
 [PurchaseTypeId]  int NOT NULL ,


 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([OrderId]),
 CONSTRAINT [OrdersVehicles] FOREIGN KEY ([VehicleId])  REFERENCES [Vehicles]([VehicleId]),
 CONSTRAINT [OrdersPurchaseType] FOREIGN KEY ([PurchaseTypeId])  REFERENCES [PurchaseType]([PurchaseTypeId])
);

GO





