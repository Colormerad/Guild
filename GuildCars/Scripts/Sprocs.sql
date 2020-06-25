 USE GuildCars
 GO
 
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelSelectAll')
		DROP PROCEDURE ModelSelectAll
GO

CREATE PROCEDURE ModelSelectAll AS
BEGIN
	SELECT ModelId, ModelName, MakeId, UserId, AddedDate
	FROM Model
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelSelect')
		DROP PROCEDURE ModelSelect
GO

CREATE PROCEDURE ModelSelect (
	@ModelId int
) AS
BEGIN
		SELECT  ModelName, MakeId, UserId, AddedDate
		FROM Model
		WHERE ModelId = @ModelId
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelInsert')
		DROP PROCEDURE ModelInsert
GO
CREATE PROCEDURE ModelInsert (
 @ModelId    int output,
 @ModelName  varchar(50),
 @MakeId       int,
 @UserId nvarchar(128),
 @AddedDate datetime


 ) AS
 BEGIN
	INSERT INTO Model (ModelName, MakeId, UserId, AddedDate)
	VALUES(@ModelName, @MakeId, @UserId, @AddedDate)

	SET @ModelId =  SCOPE_IDENTITY(); 
 END
 GO


 IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakeSelectAll')
		DROP PROCEDURE MakeSelectAll
GO

CREATE PROCEDURE MakeSelectAll AS
BEGIN
	SELECT MakeId, MakeName, [UserId], [AddedDate]
	FROM Make
END

GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakeSelect')
		DROP PROCEDURE MakeSelect
GO

CREATE PROCEDURE MakeSelect (
	@MakeId int
) AS
BEGIN
		SELECT  MakeName, [UserId], [AddedDate]
		FROM Make
		WHERE MakeId = @MakeId
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakeInsert')
		DROP PROCEDURE MakeInsert
GO
CREATE PROCEDURE MakeInsert (
 @MakeId      int output,
 @MakeName    varchar(50),
 @UserId nvarchar(128),
 @AddedDate datetime

 ) AS
 BEGIN
	INSERT INTO Make (MakeName,UserId,AddedDate)
	VALUES( @MakeName,@UserId,@AddedDate)

	SET @MakeId =  SCOPE_IDENTITY(); 
 END
 GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'TransmissionSelectAll')
		DROP PROCEDURE TransmissionSelectAll
GO

CREATE PROCEDURE TransmissionSelectAll AS
BEGIN
	SELECT TransmissionId, TransmissionName
	FROM Transmission
END

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'TransmissionSelect')
		DROP PROCEDURE TransmissionSelect
GO

CREATE PROCEDURE TransmissionSelect (
	@TransmissionId int
) AS
BEGIN
		SELECT  TransmissionName
		FROM Transmission
		WHERE TransmissionId = @TransmissionId
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'NewUsedSelectAll')
		DROP PROCEDURE NewUsedSelectAll
GO

CREATE PROCEDURE NewUsedSelectAll AS
BEGIN
	SELECT NewUsedId, NewUsedName
	FROM NewUsed
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'NewUsedSelect')
		DROP PROCEDURE NewUsedSelect
GO

CREATE PROCEDURE NewUsedSelect (
	@NewUsedId int
) AS
BEGIN
		SELECT  NewUsedName
		FROM NewUsed
		WHERE NewUsedId = @NewUsedId
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'BodyStyleSelectAll')
		DROP PROCEDURE BodyStyleSelectAll
GO

CREATE PROCEDURE BodyStyleSelectAll AS
BEGIN
	SELECT BodyStyleId, BodyStyleName
	FROM BodyStyle
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'BodyStyleSelect')
		DROP PROCEDURE BodyStyleSelect
GO

CREATE PROCEDURE BodyStyleSelect (
	@BodyStyleId int
) AS
BEGIN
		SELECT  BodyStyleName
		FROM BodyStyle
		WHERE BodyStyleId = @BodyStyleId
END 
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ExteriorColorSelectAll')
		DROP PROCEDURE ExteriorColorSelectAll
GO

CREATE PROCEDURE ExteriorColorSelectAll AS
BEGIN
	SELECT ExteriorColorId, ExteriorColorName
	FROM ExteriorColor
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ExteriorColorSelect')
		DROP PROCEDURE ExteriorColorSelect
GO

CREATE PROCEDURE ExteriorColorSelect (
	@ExteriorColorId int
) AS
BEGIN
		SELECT  ExteriorColorName
		FROM ExteriorColor
		WHERE ExteriorColorId = @ExteriorColorId
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'InteriorColorSelectAll')
		DROP PROCEDURE InteriorColorSelectAll
GO

CREATE PROCEDURE InteriorColorSelectAll AS
BEGIN
	SELECT InteriorColorId, InteriorColorName
	FROM InteriorColor
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'InteriorColorSelect')
		DROP PROCEDURE InteriorColorSelect
GO

CREATE PROCEDURE InteriorColorSelect (
	@InteriorColorId int
) AS
BEGIN
		SELECT  InteriorColorName
		FROM InteriorColor
		WHERE InteriorColorId = @InteriorColorId
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchaseTypeSelectAll')
		DROP PROCEDURE PurchaseTypeSelectAll
GO

CREATE PROCEDURE PurchaseTypeSelectAll AS
BEGIN
	SELECT PurchaseTypeId, PurchaseTypeName
	FROM PurchaseType
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchaseTypeSelect')
		DROP PROCEDURE PurchaseTypeSelect
GO

CREATE PROCEDURE PurchaseTypeSelect (
	@PurchaseTypeId int
) AS
BEGIN
		SELECT  PurchaseTypeName
		FROM PurchaseType
		WHERE PurchaseTypeId = @PurchaseTypeId
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialsSelectAll')
		DROP PROCEDURE SpecialsSelectAll
GO

CREATE PROCEDURE SpecialsSelectAll AS
BEGIN
	SELECT SpecialId, SpecialName, SpecialDescription, SpecialImageFileName
	FROM Specials
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialSelect')
		DROP PROCEDURE SpecialSelect
GO

CREATE PROCEDURE SpecialSelect (
	@SpecialId int
) AS
BEGIN
		SELECT  SpecialName, SpecialDescription, SpecialImageFileName
		FROM Specials
		WHERE SpecialId = @SpecialId
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialInsert')
		DROP PROCEDURE SpecialInsert
GO
CREATE PROCEDURE SpecialInsert (
 @SpecialId      int output,
 @SpecialName    text,
 @SpecialDescription text,
 @SpecialImageFileName varchar(50)

 ) AS
 BEGIN
	INSERT INTO Specials (SpecialName, SpecialDescription, SpecialImageFileName)
	VALUES( @SpecialName, @SpecialDescription, @SpecialImageFileName)

	SET @SpecialId =  SCOPE_IDENTITY(); 
 END
 GO

 IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialDelete')
		DROP PROCEDURE SpecialDelete
GO
CREATE PROCEDURE SpecialDelete (
	@SpecialId int
	) AS
	BEGIN
		BEGIN TRANSACTION

		DELETE FROM Specials WHERE SpecialId = @SpecialId;

		COMMIT TRANSACTION
	END 
	GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehiclesSelectAll')
		DROP PROCEDURE VehiclesSelectAll
GO
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'OrdersSelectAll')
		DROP PROCEDURE OrdersSelectAll
GO
CREATE PROCEDURE OrdersSelectAll AS
BEGIN
	SELECT OrderId, UserId, OrderDate, OrderTotal, VehicleId, CustomerName, CustomerPhone, CustomerEmail, CustomerStreet1, CustomerStreet2, CustomerCity, CustomerState, CustomerZipcode, PurchaseTypeId
	FROM Orders
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'OrderInsert')
		DROP PROCEDURE OrderInsert
GO
CREATE PROCEDURE OrderInsert (
 @OrderId      int output,
 @UserId       nvarchar(128),
 @OrderDate    datetime,
 @OrderTotal   int,
 @VehicleId    int,
 @CustomerName text,
 @CustomerPhone text,
 @CustomerEmail text,
 @CustomerStreet1 text,
 @CustomerStreet2 text,
 @CustomerCity    text,
 @CustomerState   text,
 @CustomerZipcode int,
 @PurchaseTypeId  int

 ) AS
 BEGIN
	INSERT INTO Orders (UserId, OrderDate, OrderTotal, VehicleId, CustomerName, CustomerPhone, CustomerEmail, CustomerStreet1, CustomerStreet2, CustomerCity, CustomerState, CustomerZipcode, PurchaseTypeId)
	VALUES( @UserId, @OrderDate, @OrderTotal, @VehicleId, @CustomerName, @CustomerPhone, @CustomerEmail, @CustomerStreet1, @CustomerStreet2, @CustomerCity, @CustomerState, @CustomerZipcode, @PurchaseTypeId)

	SET @OrderId =  SCOPE_IDENTITY(); 
 END
 GO

  IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'OrderUpdate')
		DROP PROCEDURE OrderUpdate
GO
CREATE PROCEDURE OrderUpdate (
 @OrderId      int output,
 @UserId       nvarchar(128),
 @OrderDate    datetime,
 @OrderTotal   int,
 @VehicleId    int,
 @CustomerName text,
 @CustomerPhone text,
 @CustomerEmail text,
 @CustomerStreet1 text,
 @CustomerStreet2 text,
 @CustomerCity    text,
 @CustomerState   text,
 @CustomerZipcode int,
 @PurchaseTypeId  int
 ) AS
 BEGIN
	UPDATE Orders SET
 UserId = @UserId,
 OrderDate = @OrderDate,
 OrderTotal = @OrderTotal,
 VehicleId = @VehicleId,
 CustomerName = @CustomerName,
 CustomerPhone = @CustomerPhone,
 CustomerEmail = @CustomerEmail,
 CustomerStreet1 = @CustomerStreet1,
 CustomerStreet2 =  @CustomerStreet2,
 CustomerCity = @CustomerCity ,
 CustomerState = @CustomerState,
 CustomerZipcode = @CustomerZipcode,
 PurchaseTypeId = @PurchaseTypeId  

	WHERE OrderId = @OrderId
 END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'OrderDelete')
		DROP PROCEDURE OrderDelete
GO
CREATE PROCEDURE OrderDelete (
	@OrderId int
	) AS
	BEGIN
		BEGIN TRANSACTION

		DELETE FROM Orders WHERE OrderId = @OrderId;

		COMMIT TRANSACTION
	END 
	GO

	IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'OrderSelect')
		DROP PROCEDURE OrderSelect
GO

CREATE PROCEDURE OrderSelect (
	@OrderId int
) AS
BEGIN
		SELECT  UserId, OrderDate, OrderTotal, VehicleId, CustomerName, CustomerPhone, CustomerEmail, CustomerStreet1, CustomerStreet2, CustomerCity, CustomerState, CustomerZipcode, PurchaseTypeId
		FROM Orders
		WHERE OrderId = @OrderId
END 
GO




CREATE PROCEDURE VehiclesSelectAll AS
BEGIN
	SELECT VehicleId, [Year], [Description], ImageFileName, MSRP, Mileage, VIN, SalePrice, MakeId, ModelId, NewUsedId, BodyStyleId, InteriorColorId, ExteriorColorId, TransmissionId, DateAdded, HasBeenSold, IsFeatured
	FROM Vehicles
	WHERE HasBeenSold = 0
END
GO 

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleInsert')
		DROP PROCEDURE VehicleInsert
GO
CREATE PROCEDURE VehicleInsert (
 @VehicleId      int output,
 @Year           int,
 @Description    varchar(150),
 @ImageFileName  varchar(50),
 @MSRP           int,
 @Mileage        int,
 @VIN            text,
 @SalePrice      int,
 @MakeId         int,
 @ModelId        int ,
 @NewUsedId      int,
 @BodyStyleId    int,
 @InteriorColorId int,
 @ExteriorColorId int,
 @TransmissionId  int,
 @DateAdded      datetime,
 @HasBeenSold    bit,
 @IsFeatured     bit
 ) AS
 BEGIN
	INSERT INTO Vehicles ([Year], [Description], ImageFileName, MSRP, Mileage, VIN, SalePrice, MakeId, ModelId, NewUsedId, BodyStyleId, InteriorColorId, ExteriorColorId, TransmissionId, DateAdded, HasBeenSold, IsFeatured)
	VALUES(@Year, @Description, @ImageFileName, @MSRP, @Mileage, @VIN, @SalePrice, @MakeId, @ModelId, @NewUsedId, @BodyStyleId, @InteriorColorId, @ExteriorColorId, @TransmissionId, @DateAdded, @HasBeenSold, @IsFeatured)

	SET @VehicleId =  SCOPE_IDENTITY(); 
 END
 GO

 IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleUpdate')
		DROP PROCEDURE VehicleUpdate
GO
CREATE PROCEDURE VehicleUpdate (
 @VehicleId      int output,
 @Year           int,
 @Description    varchar(150),
 @ImageFileName  varchar(50),
 @MSRP           int,
 @Mileage        int,
 @VIN            text,
 @SalePrice      int,
 @MakeId         int,
 @ModelId        int ,
 @NewUsedId      int,
 @BodyStyleId    int,
 @InteriorColorId int,
 @ExteriorColorId int,
 @TransmissionId  int,
 @DateAdded      datetime,
 @HasBeenSold     bit,
 @IsFeatured      bit
 ) AS
 BEGIN
	UPDATE Vehicles SET
	[Year] = @Year, 
	[Description] = @Description,
	ImageFileName = @ImageFileName, 
	MSRP = @MSRP, 
	Mileage = @Mileage, 
	VIN = @VIN, 
	SalePrice = @SalePrice, 
	MakeId = @MakeId, 
	ModelId = @ModelId, 
	NewUsedId = @NewUsedId, 
	BodyStyleId = @BodyStyleId, 
	InteriorColorId = @InteriorColorId, 
	ExteriorColorId = @ExteriorColorId, 
	TransmissionId = @TransmissionId, 
	DateAdded = @DateAdded,
	HasBeenSold = @HasBeenSold,
	IsFeatured = @IsFeatured 

	WHERE VehicleId = @VehicleId
 END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleDelete')
		DROP PROCEDURE VehicleDelete
GO
CREATE PROCEDURE VehicleDelete (
	@VehicleId int
	) AS
	BEGIN
		BEGIN TRANSACTION

		DELETE FROM Vehicles WHERE VehicleId = @VehicleId;

		COMMIT TRANSACTION
	END 
	GO

	IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleSelect')
		DROP PROCEDURE VehicleSelect
GO

CREATE PROCEDURE VehicleSelect (
	@VehicleId int
) AS
BEGIN
		SELECT [Year], [Description], ImageFileName, MSRP, Mileage, VIN, SalePrice, MakeId, ModelId, NewUsedId, BodyStyleId, InteriorColorId, ExteriorColorId, TransmissionId, DateAdded, HasBeenSold, IsFeatured
		FROM Vehicles 
		WHERE VehicleId = @VehicleId
END 
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleSelectCondition')
		DROP PROCEDURE VehicleSelectCondition
GO

CREATE PROCEDURE VehicleSelectCondition (
	@NewUsedName varchar(20)
) AS
BEGIN
		SELECT VehicleId, [Year], [Description], ImageFileName, MSRP, Mileage, VIN, SalePrice, Vehicles.MakeId, MakeName, ModelName, Vehicles.ModelId, Vehicles.NewUsedId, BodyStyleId, InteriorColorId, ExteriorColorId, TransmissionId, DateAdded, HasBeenSold, IsFeatured
		FROM  Vehicles

		JOIN NewUsed AS Condition
		ON Condition.NewUsedId = Vehicles.NewUsedId
		INNER JOIN Make ON Make.MakeId = Vehicles.MakeId
		INNER JOIN Model ON Model.ModelId = Vehicles.ModelId
		WHERE Condition.NewUsedName = @NewUsedName
		AND Vehicles.HasBeenSold = 0
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleSelectFeatured')
		DROP PROCEDURE VehicleSelectFeatured
GO

CREATE PROCEDURE VehicleSelectFeatured (
	@IsFeatured bit
) AS
BEGIN
		SET NOCOUNT ON;
		SELECT DISTINCT  Vehicles.VehicleId, Vehicles.[Year], Vehicles.ImageFileName, Vehicles.SalePrice, Vehicles.HasBeenSold, 
						 Vehicles.MakeId, Vehicles.ModelId, Make.MakeName, Model.ModelName
		FROM  Vehicles
		INNER JOIN Make ON Make.MakeId = Vehicles.MakeId
		INNER JOIN Model ON Model.ModelId = Vehicles.ModelId

		
		WHERE Vehicles.IsFeatured = @IsFeatured AND
		Vehicles.HasBeenSold = 0
END 
GO




IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ContactUsForm')
		DROP PROCEDURE ContactUsForm
GO
CREATE PROCEDURE ContactUsForm (

 @ContactUsId  int output,
 @Name         text,
 @Email        text,
 @Phone        text,
 @Message      text

 ) AS
 BEGIN
	INSERT INTO ContactUs([Name], Email, Phone, [Message])
	VALUES( @Name, @Email, @Phone, @Message)

	SET @ContactUsId =  SCOPE_IDENTITY(); 
 END
 GO

 IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleDetails')
		DROP PROCEDURE VehicleDetails
GO

CREATE PROCEDURE VehicleDetails (
	@VehicleId int
) AS
BEGIN
		
		SELECT [Year], MSRP, Mileage, VIN, ImageFileName, [Description], SalePrice, Vehicles.MakeId, Vehicles.ModelId, 
		Make.MakeName, Model.ModelName, Vehicles.InteriorColorId, InteriorColor.InteriorColorName, 
		Vehicles.ExteriorColorId, ExteriorColor.ExteriorColorName, Vehicles.TransmissionId, Transmission.TransmissionName,
		Vehicles.NewUsedId, NewUsedName, Vehicles.BodyStyleId, BodyStyleName
		FROM  Vehicles
		INNER JOIN Make ON Make.MakeId = Vehicles.MakeId
		INNER JOIN Model ON Model.ModelId = Vehicles.ModelId
		INNER JOIN InteriorColor on InteriorColor.InteriorColorId = Vehicles.InteriorColorId
		INNER JOIN ExteriorColor on ExteriorColor.ExteriorColorId = Vehicles.ExteriorColorId
		INNER JOIN Transmission on Transmission.TransmissionId = Vehicles.TransmissionId
		INNER JOIN NewUsed on NewUsed.NewUsedId = Vehicles.NewUsedId
		INNER JOIN BodyStyle on BodyStyle.BodyStyleId =Vehicles.BodyStyleId
		WHERE Vehicles.VehicleId = @VehicleId
END 
GO

 IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAllModels')
		DROP PROCEDURE GetAllModels
GO

CREATE PROCEDURE GetAllModels AS
BEGIN
		SET NOCOUNT ON;
		SELECT DISTINCT  Make.MakeId, Model.ModelId, Make.MakeName AS MakeName, Model.ModelName, Model.MakeId, Model.UserId, Model.AddedDate
		FROM  Model
		INNER JOIN Make ON Make.MakeId = Model.MakeId
END 
GO

 IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAllModelsByMakeID')
		DROP PROCEDURE GetAllModelsByMakeID
GO

CREATE PROCEDURE GetAllModelsByMakeID (
@MakeId int
)AS
BEGIN
		SET NOCOUNT ON;
		SELECT DISTINCT  Make.MakeId, Model.ModelId, Make.MakeName AS MakeName, Model.ModelName, Model.MakeId
		FROM  Model
		INNER JOIN Make ON Make.MakeId = Model.MakeId

		WHERE Make.MakeId = @MakeId
END 
GO


 IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAllNewVehicleReports')
		DROP PROCEDURE GetAllNewVehicleReports
GO

CREATE PROCEDURE GetAllNewVehicleReports
AS
BEGIN
	SELECT SUM(SalePrice) As Total,  
		Make.MakeName, Model.ModelName,
	    NewUsedName,[Year],
		COUNT(*) As Count
		FROM  Vehicles
		INNER JOIN Make ON Make.MakeId = Vehicles.MakeId
		INNER JOIN Model ON Model.ModelId = Vehicles.ModelId
		INNER JOIN NewUsed on NewUsed.NewUsedId = Vehicles.NewUsedId
		WHERE NewUsedName = 'New' AND
		HasBeenSold = 0
		
	GROUP BY 
		ModelName,
		MakeName,
		NewUsedName,
		[Year]


 END
 GO

  IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAllUsedVehicleReports')
		DROP PROCEDURE GetAllUsedVehicleReports
GO

CREATE PROCEDURE GetAllUsedVehicleReports
AS
BEGIN
	SELECT SUM(SalePrice) AS Total,  
		Make.MakeName, Model.ModelName,
	    NewUsedName, [Year],
		COUNT(*) AS Count
		FROM  Vehicles
		INNER JOIN Make ON Make.MakeId = Vehicles.MakeId
		INNER JOIN Model ON Model.ModelId = Vehicles.ModelId
		INNER JOIN NewUsed on NewUsed.NewUsedId = Vehicles.NewUsedId
		WHERE NewUsedName = 'Used' AND
		HasBeenSold = 0
		
	GROUP BY 
		ModelName,
		MakeName,
		NewUsedName, 
		[Year]


 END
 GO

