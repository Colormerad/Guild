 USE GuildCars
 GO
 
 IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DbReset')
		DROP PROCEDURE DbReset
GO

CREATE PROCEDURE DbReset AS

BEGIN
		DELETE FROM AspNetUsers WHERE id = '00000000-0000-0000-0000-000000000000' ;
	DELETE FROM Orders;
	DELETE FROM Vehicles;
	
	DELETE FROM Model;
	DELETE FROM Make;
	DELETE FROM Transmission;
	DELETE FROM NewUsed;
	DELETE FROM BodyStyle;
	DELETE FROM ExteriorColor;
	DELETE FROM InteriorColor;
	DELETE FROM PurchaseType;
	DELETE FROM Specials;
	DELETE FROM ContactUs;
	

	DBCC CHECKIDENT ('Model', RESEED, 0)
	DBCC CHECKIDENT ('Make', RESEED, 0)
	DBCC CHECKIDENT ('Transmission', RESEED, 0)
	DBCC CHECKIDENT ('BodyStyle', RESEED, 0)
	DBCC CHECKIDENT ('NewUsed', RESEED, 0)
	DBCC CHECKIDENT ('ExteriorColor', RESEED, 0)
	DBCC CHECKIDENT ('InteriorColor', RESEED, 0)
	DBCC CHECKIDENT ('PurchaseType', RESEED, 0)
	DBCC CHECKIDENT ('Specials', RESEED, 0)
	DBCC CHECKIDENT ('Orders', RESEED, 0)
	DBCC CHECKIDENT ('Vehicles', RESEED, 0)
	DBCC CHECKIDENT ('ContactUs', RESEED, 0)
	


	
	SET IDENTITY_INSERT Make ON
	INSERT INTO Make (MakeId, MakeName,UserId,AddedDate)
	Values ('1', 'Baddieux', '00000000-0000-0000-0000-000000000000', '2020-05-05'),
	('2', 'Yoshi Goombadson', '00000000-0000-0000-0000-000000000000', '2020-05-05'),
	('3', 'Splaturn', '00000000-0000-0000-0000-000000000000', '2020-05-05');
	SET IDENTITY_INSERT Make OFF

	SET IDENTITY_INSERT Model ON
	INSERT INTO Model (ModelId, ModelName, MakeId, UserId, AddedDate)
	Values ('1', 'Tooths', '1', '00000000-0000-0000-0000-000000000000', '2020-05-05' ),
	('2', 'Whoosh', '1', '00000000-0000-0000-0000-000000000000', '2020-05-05'),
	('3', 'Wart', '1', '00000000-0000-0000-0000-000000000000', '2020-05-05'),
	('4', 'Green Machine', '2', '00000000-0000-0000-0000-000000000000', '2020-05-05'),
	('5', 'Think Pink', '2', '00000000-0000-0000-0000-000000000000', '2020-05-05'),
	('6', 'Notso Shy', '2', '00000000-0000-0000-0000-000000000000', '2020-05-05'),
	('7', 'Beep', '3', '00000000-0000-0000-0000-000000000000', '2020-05-05'),
	('8', 'Candieez', '3', '00000000-0000-0000-0000-000000000000', '2020-05-05'),
	('9', 'OldSkool', '3', '00000000-0000-0000-0000-000000000000', '2020-05-05')
	SET IDENTITY_INSERT Model OFF

	SET IDENTITY_INSERT Transmission ON
	INSERT INTO Transmission (TransmissionId, TransmissionName)
	VALUES (1, 'Automatic'),
	(2, 'Manual'),
	(3, 'CVT')
	SET IDENTITY_INSERT Transmission OFF

	SET IDENTITY_INSERT NewUsed ON
	INSERT INTO NewUsed (NewUsedId, NewUsedName)
	VALUES (1, 'New'),
	(2, 'Used')
	SET IDENTITY_INSERT NewUsed OFF

	SET IDENTITY_INSERT BodyStyle ON
	INSERT INTO BodyStyle (BodyStyleId, BodyStyleName)
	Values ('1', 'ATV'),
	('2', 'Kart'),
	('3', 'Motorcycle')
	SET IDENTITY_INSERT BodyStyle OFF

	SET IDENTITY_INSERT ExteriorColor ON
	INSERT INTO ExteriorColor (ExteriorColorId, ExteriorColorName)
	Values ('1', 'Black'),
	('2', 'Red'),
	('3', 'Blue'),
	('4', 'Purple'),
	('5', 'Green'),
	('6', 'Pink')
	SET IDENTITY_INSERT ExteriorColor OFF

	SET IDENTITY_INSERT InteriorColor ON
	INSERT INTO InteriorColor (InteriorColorId, InteriorColorName)
	Values ('1', 'Black'),
	('2', 'Red'),
	('3', 'Blue')
	SET IDENTITY_INSERT InteriorColor OFF

	SET IDENTITY_INSERT PurchaseType ON
	INSERT INTO PurchaseType (PurchaseTypeId, PurchaseTypeName)
	Values ('1', 'Financing'),
	('2', 'Cash')
	SET IDENTITY_INSERT PurchaseType OFF

	SET IDENTITY_INSERT Specials ON
	INSERT INTO Specials (SpecialId, SpecialName, SpecialDescription, SpecialImageFileName)
	Values ('1', 'Flower Cup Champion', 'Grand champions of the flower cup get 0% financing for 12 months!', 'FlowerCup.png'),
	('2', 'Blue Shell Magnet', 'Hit by more than 5 blue shells? $500 discount!', 'Blueshell.png'),
	('3', 'Starman', 'Trade a starman for 10% off your next vehicle!', 'starman.png')
	SET IDENTITY_INSERT Specials OFF

	SET IDENTITY_INSERT Vehicles ON
	INSERT INTO Vehicles(VehicleId, [Year], [Description], ImageFileName, MSRP, Mileage, VIN, SalePrice, MakeId, ModelId, NewUsedId, BodyStyleId, InteriorColorId, ExteriorColorId, TransmissionId, DateAdded, HasBeenSold, IsFeatured)
	Values ('1', '2019', 'A Chomping Good Ride!', 'KoopaChomp.jpg', '1500', '24342', 'V111', '1500', '1', '1', '2', '2', '2', '5', '1', '2020-05-05', '0', '1'),
		   ('2', '2020', 'Ka-Boom!', 'BulletBillKart.png', '2000', '100', 'V222', '1800', '1', '2', '1', '2', '2', '1', '1', '2020-05-05', '0', '0'),
		   ('3', '2018', 'Wa-hah hah hah!', 'WarioKart.png', '1000', '10000', 'V333', '1000', '1', '3', '2', '2', '2', '4', '1', '2020-05-13', '0', '1'),
		   ('4', '2020', 'Egg-citing!', 'YoshiCycle.jpg', '4000', '1', 'V4444', '3900', '2', '4', '1', '3', '2', '5', '1', '2020-05-13', '0', '0'),
		   ('5', '2016', 'Royally Amazing!', 'PeachCycle.jpg', '2200', '120904', 'V555', '2200', '2', '5', '2', '3', '2', '6', '2', '2020-05-14', '0', '1'),
		   ('6', '2020', 'Out of this world.', 'RosalinaATV.jpg', '1200', '120', 'V666', '1200', '2', '6', '1', '1', '2', '3', '1', '2020-05-14', '0', '0'),
		   ('7', '1818', 'Clicky Clack this buggy Attack!', 'OldBuggy.jpg', '100', '1200000', 'V777', '100', '3', '7', '2', '2', '2', '4', '1', '2020-05-14', '0', '1'),
		   ('8', '2020', 'One Sweet Ride!', 'CandyCrush.png', '3000', '2', 'V888', '3000', '3', '8', '1', '2', '2', '4', '1', '2020-05-14', '0', '0'),
		   ('9', '2015', 'The OG', 'MarioKartATV.jpg', '1400', '4110', 'V999', '1400', '3', '9', '2', '1', '2', '2', '3', '2020-05-14', '0', '1'),
	('10', '2020', 'One Sweet Ride!', 'CandyCrush.png', '3000', '3', 'V1010', '3000', '3', '8', '1', '3', '2', '4', '1', '2020-05-14', '0', '1'),
	('11', '1818', 'Clicky Clack this buggy Attack!', 'OldBuggy.jpg', '300', '876899', 'V1111', '300', '3', '7', '2', '3', '2', '4', '2', '2020-05-14', '0', '0')
	SET IDENTITY_INSERT Vehicles OFF

	SET IDENTITY_INSERT Orders ON
	INSERT INTO Orders (OrderId, UserId, OrderDate, OrderTotal, VehicleId, CustomerName, CustomerPhone, CustomerEmail, CustomerStreet1, CustomerStreet2, CustomerCity, CustomerState, CustomerZipcode, PurchaseTypeId )
	Values ('1', '00000000-0000-0000-0000-000000000000', '2020-12-12', '500', '2', 'Peach', '555-555-5555', 'peach@mushroomkingdom.com', '1 Infinity Dr', null, 'Mushroom', 'Kingdom', '01337', '2'),
	('2', '00000000-0000-0000-0000-000000000000', '2020-11-12', '1500', '1', 'Mario', '555-555-5555', 'marioh@mushroomkingdom.com', '88 Pipe ln', 'apt. 2', 'Mushroom', 'Kingdom', '01337', '1')
	SET IDENTITY_INSERT Orders OFF

	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
	Values('00000000-0000-0000-0000-000000000000', 0, 0, 'test@test.com', 0,0,0,'test');

	SET IDENTITY_INSERT ContactUs ON
	INSERT INTO ContactUs(ContactUsId, [Name], Email, Phone, [Message])
	Values ('1', 'Test', 'test@test.com', '555-555-5555', 'Testing')
	SET IDENTITY_INSERT ContactUs OFF

END