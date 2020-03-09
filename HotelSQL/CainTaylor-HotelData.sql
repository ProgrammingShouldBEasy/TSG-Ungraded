USE [Hotel]

INSERT INTO [Room Type]
([Size], [Base Price], [Extra Person Charge], [Standard Occupancy], [Maximum Occupancy])
VALUES
('Double', 174.99, 10, 2, 4),
('Single', 149.99, NULL, 2, 2),
('Suite', 399.99, 20, 3, 8);

INSERT INTO [Rooms]
([Room Number], [Size], [ADA])
VALUES
(201, 'Double', 0),
(202, 'Double', 1),
(203, 'Double', 0),
(204, 'Double', 1),
(205, 'Single', 0),
(206, 'Single', 1),
(207, 'Single', 0),
(208, 'Single', 1),
(301, 'Double', 0),
(302, 'Double', 1),
(303, 'Double', 0),
(304, 'Double', 1),
(305, 'Single', 0),
(306, 'Single', 1),
(307, 'Single', 0),
(308, 'Single', 1),
(401, 'Suite', 1),
(402, 'Suite', 1);

INSERT INTO [Guests]
([Name],[Address],[City],[State],[Zip],[Phone])
VALUES
('Cain', 'Your Address', 'City', 'State', 12345, 1235554789),
('Mack Simmer', '379 Old Shore Street', 'Council Bluffs', 'IA', 51501, 2915530508),
('Bettyann Seery', '750 Wintergreen Dr.', 'Wasilla', 'AK', 99654, 4782779632),
('Duane Cullison', '9662 Foxrun Lane', 'Harlingen', 'TX', 78552, 3084940198),
('Karie Yang',	'9378 W. Augusta Ave.','West Deptford','NJ',08096,2147300298),
('Aurore Lipton',	'762 Wild Rose Street',	'Saginaw',	'MI',	48601,	3775070974),
('Zachery Luechtefeld',	'7 Poplar Dr.',	'Arvada',	'CO',	80003,	8144852615),
('Jeremiah Pendergrass',	'70 Oakwood St.',	'Zion',	'IL',	60099,	2794910960),
('Walter Holaway',	'7556 Arrowhead St.',	'Cumberland',	'RI',	02864,	4463966785),
('Wilfred Vise',	'77 West Surrey Street',	'Oswego',	'NY',	13126,	8347271001),
('Maritza Tilton',	'939 Linda Rd.',	'Burke',	'VA',	22015,	4463516860),
('Joleen Tison',	'87 Queen St.',	'Drexel Hill',	'PA',	19026,	2318932755);

INSERT INTO [Reservation]
([GuestID],[Start Date],[End Date])
VALUES
(2, '2/2/2023', '2/4/2023'),
(3,	'2/5/2023',	'2/10/2023'),
(4, '2/22/2023', '2/24/2023'),
(5, '3/6/2023',	'3/7/2023'),
(1,'3/17/2023',	'3/20/2023'),
(6,'3/18/2023','3/23/2023'),
(7,'3/29/2023',	'3/31/2023'),
(8,'3/31/2023',	'4/5/2023'),
(9,'4/9/2023',	'4/13/2023'),
(10,'4/23/2023',	'4/24/2023'),
(11,'5/30/2023',	'6/2/2023'),
--(12,'6/10/2023',	'6/14/2023'),
(12,'6/10/2023',	'6/14/2023'),
(6,'6/17/2023',	'6/18/2023'),
(1,'6/28/2023',	'7/2/2023'),
(9,'7/13/2023',	'7/14/2023'),
(10,'7/18/2023',	'7/21/2023'),
(3,'7/28/2023',	'7/29/2023'),
(3,'8/30/2023',	'9/1/2023'),
(2,'9/16/2023',	'9/17/2023'),
(5,'9/13/2023',	'9/15/2023'),
(4,'11/22/2023',	'11/25/2023'),
--(2,'11/22/2023',	'11/25/2023'),
(2,'11/22/2023',	'11/25/2023'),
(11,'12/24/2023',	'12/28/2023');
INSERT INTO [Room to Reservation]
([Room Number], [ReservationID], [Adults], [Children])
VALUES
(308, 1, 1, 0),
(203, 2, 2, 1),
(305, 3, 2, 0),
(201, 4, 2,	2),
(307, 5, 1,	1),
(302, 6, 3,	0),
(202, 7, 2,	2),
(304, 8, 2,	0),
(301,	9,	1,	0),
(207,	10,	1,	1),
(401,	11,	2,	4),
(206,	12, 2,	0),
(208,	12,	1,	0),
(304,	13,	3,	0),
(205,	14,	2,	0),
(204,	15,	3,	1),
(401,	16,	4,	2),
(303,	17, 2,	1),
(305,	18,	1,	0),
(208,	19,	2,	0),
(203,	20,	2,	2),
(401,	21,	2,	2),
(206,	22,	2,	0),
(301,	22, 2,	2),
(302,	23,	2,	0);
INSERT INTO [Amenities]
([Amenity Name], [Charge])
VALUES
('Microwave', 0),
('Fridge', 0),
('Jacuzzi', 25),
('Oven', 0);
INSERT INTO [Room to Amenities]
([Room Number], [AmenityID])
VALUES
(201, 1),
(201, 3),
(202, 2),
(203, 1),
(203, 3),
(204, 2),
(205, 1),
(205, 2),
(205, 3),
(206, 1),
(206, 2),
(207, 1),
(207, 2),
(207, 3),
(208, 1),
(208, 2),
(301, 1),
(301, 3),
(302, 2),
(303, 1),
(303, 3),
(304, 2),
(305, 1),
(305, 2),
(305, 3),
(306, 1),
(306, 2),
(307, 1),
(307, 2),
(307, 3),
(308, 1),
(308, 2),
(401, 1),
(401, 2),
(401, 4),
(402, 1),
(402, 2),
(402, 4);

DELETE FROM [Room to Reservation]
WHERE [Room to Reservation].ReservationID = 
(SELECT Reservation.ReservationID FROM Reservation WHERE Reservation.GuestID = 
(SELECT GuestID FROM Guests WHERE [Name] = 'Jeremiah Pendergrass'));
DELETE FROM [Reservation]
WHERE Reservation.GuestID = (SELECT GuestID FROM Guests WHERE [Name] = 'Jeremiah Pendergrass');
DELETE FROM [Guests]
WHERE [Name] = 'Jeremiah Pendergrass';