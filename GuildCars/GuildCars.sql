Use Master 
GO
DROP DATABASE IF EXISTS
 GuildCars;
 GO
 CREATE DATABASE GuildCars;
 GO
 USE GuildCars
 GO

CREATE TABLE [ContactUs]
(
 [ContactUsId] int NOT NULL ,
 [Name]        text NOT NULL ,
 [Email]       text NOT NULL ,
 [Phone]       text NOT NULL ,
 [Message]     text NOT NULL ,


 CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED ([ContactUsId])
);
GO

CREATE TABLE [Specials]
(
    [SpecialId]   int NOT NULL,
    [SpecialName] text NOT NULL,
);
GO

CREATE TABLE [BodyStyle]
(
 [BodyStyleId] int NOT NULL ,
 [BodyStyle]   text NOT NULL ,


 CONSTRAINT [PK_BodyStyle] PRIMARY KEY CLUSTERED ([BodyStyleId])
);
GO

CREATE TABLE [ExteriorColor]
(
    [ExteriorColorId] int NOT NULL,
    [ExteriorColor] text NOT NULL,

    CONSTRAINT [PK_ExteriorColor] PRIMARY KEY CLUSTERED ([ExteriorColorId])
    );
GO

CREATE TABLE [InteriorColor]
(
    [InteriorColorId] int NOT NULL,
    [InteriorColor] text NOT NULL,

    CONSTRAINT [PK_InteriorColor] PRIMARY KEY CLUSTERED ([InteriorColorId])
    );
GO
CREATE TABLE [Model]
(
    [ModelId] int NOT NULL,
    [Model]   text NOT NULL,

    CONSTRAINT [PK_Model] PRIMARY KEY CLUSTERED ([ModelId])
);
GO

CREATE TABLE [Make]
(
    [MakeId] int NOT NULL,
    [Make]   text NOT NULL,
    [ModelId] int NOT NULL,

    CONSTRAINT [PK_Make] PRIMARY KEY CLUSTERED ([MakeId]),
    CONSTRAINT [FK_MakeModel] FOREIGN KEY ([ModelId]) REFERENCES [Model]([ModelId])
);
GO

CREATE TABLE [PurchaseType]
(
    [PurchaseTypeId] int NOT NULL,
    [Type]           text NOT NULL,

    CONSTRAINT [PK_PurchaseType] PRIMARY KEY CLUSTERED ([PurchaseTypeId])
);
GO

CREATE TABLE [Transmission]
(
    [TransmissionId] int NOT NULL,
    [Transmission]   text NOT NULL,

    CONSTRAINT [PK_Transmision] PRIMARY KEY CLUSTERED ([TransmissionId])
);
GO

CREATE TABLE [Type]
(
    [TypeId] int NOT NULL,
    [Type]   text NOT NULL,

    CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED ([TypeId])
);
GO

CREATE TABLE [Vehicles]
(
 [VehicleId]       int NOT NULL ,
 [Year]            int NOT NULL ,
 [Description]     text NOT NULL ,
 [Picture]         image NOT NULL ,
 [MSRP]            int NOT NULL ,
 [Mileage]         int NOT NULL ,
 [VIN]             text NOT NULL ,
 [SalePrice]       int NULL ,
 [MakeId]          int NOT NULL ,
 [TypeId]          int NOT NULL ,
 [BodyStyleId]     int NOT NULL ,
 [InteriorColorId] int NOT NULL ,
 [ExteriorColorID] int NOT NULL ,
 [TransmissionId]  int NOT NULL ,


 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED ([VehicleId]),
 CONSTRAINT [FK_VehiclesMake] FOREIGN KEY ([MakeId])  REFERENCES [Make]([MakeId]),
 CONSTRAINT [FK_VehiclesType] FOREIGN KEY ([TypeId])  REFERENCES [Type]([TypeId]),
 CONSTRAINT [FK_VehiclesBodyStyle] FOREIGN KEY ([BodyStyleId])  REFERENCES [BodyStyle]([BodyStyleId]),
 CONSTRAINT [FK_VehiclesInteriorColor] FOREIGN KEY ([InteriorColorId])  REFERENCES [InteriorColor]([InteriorColorId]),
 CONSTRAINT [FK_VehiclesExteriorColor] FOREIGN KEY ([ExteriorColorID])  REFERENCES [ExteriorColor]([ExteriorColorID]),
 CONSTRAINT [FK_VehiclesTransmission] FOREIGN KEY ([TransmissionId])  REFERENCES [Transmission]([TransmissionId])
);
GO


CREATE TABLE [Orders]
(
 [OrderId]         int NOT NULL ,
 [Date]            datetime NOT NULL ,
 [orderTotal]      int NOT NULL ,
 [VehicleId]       int NOT NULL ,
 [CustomerName]    text NOT NULL ,
 [CustomerPhone]   text NOT NULL ,
 [CustomerEmail]   text NOT NULL ,
 [CustomerStreet1] text NOT NULL ,
 [CustomerStreet2] text NULL ,
 [CustomerCity]    text NOT NULL ,
 [CustomerState]   text NOT NULL ,
 [CustomerZipcode] int NOT NULL ,
 [PurchaseTypeId]   NOT NULL ,


 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([OrderId]),
 CONSTRAINT [OrdersVehicles] FOREIGN KEY ([VehicleId])  REFERENCES [Vehicles]([VehicleId]),
 CONSTRAINT [OrdersPurchaseType] FOREIGN KEY ([PurchaseTypeId])  REFERENCES [PurchaseType]([PurchaseTypeId])
);

GO















