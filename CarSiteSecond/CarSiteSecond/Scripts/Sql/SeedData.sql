USE CarSite
GO

INSERT INTO [Specials]
(Title, [Text])
VALUES
('Title 1', 'Text 1')

INSERT INTO [Specials]
(Title, [Text])
VALUES
('Title 2', 'Text 2')

INSERT INTO [Specials]
(Title, [Text])
VALUES
('Title 3', 'Text 3')

INSERT INTO [Specials]
(Title, [Text])
VALUES
('Title 4', 'Text 4')

INSERT INTO [Specials]
(Title, [Text])
VALUES
('Title 5', 'Text 5')

INSERT INTO [AspNetUsers]
([Id],[Email],[EmailConfirmed],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEnabled],[AccessFailedCount],[FirstName],[LastName])
VALUES
('1','email@dot.com',1,1,0,0,0,'Cain','Taylor')

INSERT INTO [AspNetRoles]
([Id],[Name])
VALUES
('1','Admin')

INSERT INTO [AspNetUserRoles]
([UserId],[RoleId])
VALUES
('1','1')

INSERT INTO [Make]
([MakeName],[DateAdded],[UserID])
VALUES
('Acura','2020-04-12','1')

INSERT INTO [Make]
([MakeName],[DateAdded],[UserID])
VALUES
('Audi','2020-04-12','1')

INSERT INTO [Make]
([MakeName],[DateAdded],[UserID])
VALUES
('BMW','2020-04-12','1')

INSERT INTO [Make]
([MakeName],[DateAdded],[UserID])
VALUES
('Buick','2020-04-12','1')

INSERT INTO [Make]
([MakeName],[DateAdded],[UserID])
VALUES
('Cadillac','2020-04-12','1')

INSERT INTO [Model]
([ModelName], [MakeID],[DateAdded],[UserID])
VALUES
('MDX',1,'2020-04-12','1')

INSERT INTO [Model]
([ModelName], [MakeID],[DateAdded],[UserID])
VALUES
('NSX',1,'2020-04-12','1')

INSERT INTO [Model]
([ModelName], [MakeID],[DateAdded],[UserID])
VALUES
('RDX',1,'2020-04-12','1')

INSERT INTO [Model]
([ModelName], [MakeID],[DateAdded],[UserID])
VALUES
('A3',2,'2020-04-12','1')

INSERT INTO [Model]
([ModelName], [MakeID],[DateAdded],[UserID])
VALUES
('A4',2,'2020-04-12','1')

INSERT INTO [Model]
([ModelName], [MakeID],[DateAdded],[UserID])
VALUES
('A5',2,'2020-04-12','1')

INSERT INTO [Model]
([ModelName], [MakeID],[DateAdded],[UserID])
VALUES
('2 Series',3,'2020-04-12','1')

INSERT INTO [Model]
([ModelName], [MakeID],[DateAdded],[UserID])
VALUES
('3 Series',3,'2020-04-12','1')

INSERT INTO [Model]
([ModelName], [MakeID],[DateAdded],[UserID])
VALUES
('4 Series',3,'2020-04-12','1')

INSERT INTO [Model]
([ModelName], [MakeID],[DateAdded],[UserID])
VALUES
('Enclave',4,'2020-04-12','1')

INSERT INTO [Model]
([ModelName], [MakeID],[DateAdded],[UserID])
VALUES
('Encore',4,'2020-04-12','1')

INSERT INTO [Model]
([ModelName], [MakeID],[DateAdded],[UserID])
VALUES
('Envision',4,'2020-04-12','1')

INSERT INTO [Model]
([ModelName], [MakeID],[DateAdded],[UserID])
VALUES
('CT4',5,'2020-04-12','1')

INSERT INTO [Model]
([ModelName], [MakeID],[DateAdded],[UserID])
VALUES
('CT5',5,'2020-04-12','1')

INSERT INTO [Model]
([ModelName], [MakeID],[DateAdded],[UserID])
VALUES
('CT6',5,'2020-04-12','1')

INSERT INTO [Model]
([ModelName], [MakeID],[DateAdded],[UserID])
VALUES
('CT4',5,'2020-04-12','1')

INSERT INTO [PurchaseType]
([Type])
VALUES
('Bank Finance')

INSERT INTO [PurchaseType]
([Type])
VALUES
('Cash')

INSERT INTO [PurchaseType]
([Type])
VALUES
('Dealer Finance')

INSERT INTO [Interior]
([InteriorName])
VALUES
('Red')

INSERT INTO [Interior]
([InteriorName])
VALUES
('Blue')

INSERT INTO [Interior]
([InteriorName])
VALUES
('Black')

INSERT INTO [Interior]
([InteriorName])
VALUES
('Tan')

INSERT INTO [Interior]
([InteriorName])
VALUES
('Beige')

INSERT INTO [Color]
([ColorName])
VALUES
('Red')

INSERT INTO [Color]
([ColorName])
VALUES
('Blue')

INSERT INTO [Color]
([ColorName])
VALUES
('Black')

INSERT INTO [Color]
([ColorName])
VALUES
('Tan')

INSERT INTO [Color]
([ColorName])
VALUES
('Beige')

INSERT INTO [Cars]
([ModelID],[Year],[BodyStyle],[Transmission],[PictureSrc],[InteriorID],[Mileage],[VIN],[SalePrice],[MSRP],[Featured],[ColorID],[Description])
VALUES
(1,2020,'Car','Automatic','/Data/Pictures/Car1.jpg',1,1000,'1FUPCSZB8YDA97969',10000.00,15000.00,0,1,'Car1')

INSERT INTO [Cars]
([ModelID],[Year],[BodyStyle],[Transmission],[PictureSrc],[InteriorID],[Mileage],[VIN],[SalePrice],[MSRP],[Featured],[ColorID],[Description])
VALUES
(4,2019,'SUV','Manual','/Data/Pictures/Car2.jpg',2,1,'2ACPCZZB9YDA95969',1000.00,1000.00,1,2,'Car2')

INSERT INTO [Cars]
([ModelID],[Year],[BodyStyle],[Transmission],[PictureSrc],[InteriorID],[Mileage],[VIN],[SalePrice],[MSRP],[Featured],[ColorID],[Description])
VALUES
(14,2020,'Truck','Manual','/Data/Pictures/Car3.jpg',3,10,'3CCDCSSB9YDA95969',100000.00,120000.00,1,3,'Car3')

INSERT INTO [Contacts]
([Name],[Email],[Phone],[Message])
VALUES
('Ben','ben@email.com','123456789','I love cars!')

INSERT INTO [Contacts]
([Name],[Email],[Phone],[Message])
VALUES
('Jerry','jerry@email.com','ABCDEFGHIJK','I hate cars.')

INSERT INTO [Sales]
([PurchaseType],[Name],[Email],[Street1],[Street2],[City],[State],[Zip],[Phone],[CarID],[UserID],[PurchasePrice])
VALUES
(1,'Name','Email@email.com','Street1','Street2','City','State','12345','123456789',1,1,10000.00)

INSERT INTO [Sales]
([PurchaseType],[Name],[Email],[Street1],[Street2],[City],[State],[Zip],[Phone],[CarID],[UserID],[PurchasePrice])
VALUES
(2,'Name2','Email2@email.com','2Street1','2Street2','City2','State2','22345','223456789',2,1,1000.00)

INSERT INTO [Sales]
([PurchaseType],[Name],[Email],[Street1],[Street2],[City],[State],[Zip],[Phone],[CarID],[UserID],[PurchasePrice])
VALUES
(3,'Name3','Email3@email.com','3Street1','3Street2','City3','State3','32345','323456789',3,1,100000.00)