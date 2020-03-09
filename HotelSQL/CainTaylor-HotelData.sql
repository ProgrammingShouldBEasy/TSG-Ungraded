USE [Hotel]

INSERT INTO [Rooms]
([Room Number], [Type], 
[Microwave], [Fridge], [Jacuzzi], [Oven], 
[ADA Accessible], [Standard Occupancy], 
[Maximum Occupancy], [Price], [Extra Person Cost])
VALUES
(201, 'Double', 1,0,1,0,0,2,4,199.99,10),
(202, 'Double', 0,1,0,0,1,2,4,174.99,10),
(203, 'Double', 1,0,1,0,0,2,4,199.99,10),
(204, 'Double', 0,1,0,0,1,2,4,174.99,10),
(205, 'Single', 1,1,1,0,0,2,2,174.99,NULL),
(206, 'Single', 1,1,0,0,1,2,2,149.99,NULL),
(207, 'Single', 1,1,1,0,0,2,2,174.99,NULL),
(208, 'Single', 1,1,0,0,1,2,2,149.99,NULL),
(301, 'Double', 1,0,1,0,0,2,4,199.99,10),
(302, 'Double', 0,1,0,0,1,2,4,174.99,10),
(303, 'Double', 1,0,1,0,0,2,4,174.99,10),
(304, 'Double', 0,1,0,0,1,2,4,199.99,10),
(305, 'Single', 1,1,1,0,0,2,2,174.99,NULL),
(306, 'Single', 1,1,0,0,1,2,2,149.99,NULL),
(307, 'Single', 1,1,1,0,0,2,2,174.99,NULL),
(308, 'Single', 1,1,0,0,1,2,2,149.99,NULL),
(401, 'Suite', 1,1,0,1,1,3,8,399.99,20),
(402, 'Suite', 1,1,0,1,1,3,8,399.99,20);

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

INSERT INTO [Reservations]
([Room Number],[GuestID],[Adults],[Children],[Start Date],
[End Date],[Cost])
VALUES
(308, 2, 1, 9, '2/2/2023', '2/4/2023', 299.98),
(203, 3,	2,	1,	'2/5/2023',	'2/10/2023',	999.95),
(305,	4,	2,	0,	'2/22/2023',	'2/24/2023',	349.98),
(201,	5,	2,	2,	'3/6/2023',	'3/7/2023',	199.99),
(307,	1,	1,	1,	'3/17/2023',	'3/20/2023',	524.97),
(302,	6,	3,	0,	'3/18/2023',	'3/23/2023', 924.95),
(202,	7,	2,	2,	'3/29/2023',	'3/31/2023',	349.98),
(304,	8,	2,	0,	'3/31/2023',	'4/5/2023',	874.95),
(301,	9,	1,	0,	'4/9/2023',	'4/13/2023',	799.96),
(207,	10,	1,	1,	'4/23/2023',	'4/24/2023', 174.99),
(401,	11,	2,	4,	'5/30/2023',	'6/2/2023',	1199.97),
(206,	12,	2,	0,	'6/10/2023',	'6/14/2023',	599.96),
(208,	12,	1,	0,	'6/10/2023',	'6/14/2023',	599.96),
(304,	6,	3,	0,	'6/17/2023',	'6/18/2023',	184.99),
(205,	1,	2,	0,	'6/28/2023',	'7/2/2023',	699.96),
(204,	9,	3,	1,	'7/13/2023',	'7/14/2023',	184.99),
(401,	10,	4,	2,	'7/18/2023',	'7/21/2023', 1259.97),
(303,	3,	2,	1,	'7/28/2023',	'7/29/2023',	199.99),
(305,	3,	1,	0,	'8/30/2023',	'9/1/2023',	349.98),
(208,	2,	2,	0,	'9/16/2023',	'9/17/2023',	149.99),
(203,	5,	2,	2,	'9/13/2023',	'9/15/2023',	399.98),
(401,	4,	2,	2,	'11/22/2023',	'11/25/2023',	1199.97),
(206,	2,	2,	0,	'11/22/2023',	'11/25/2023',	449.97),
(301,	2,	2,	2,	'11/22/2023',	'11/25/2023', 599.97),
(302,	11,	2,	0,	'12/24/2023',	'12/28/2023',	699.96);

DELETE FROM [Reservations]
WHERE Reservations.GuestID = (SELECT GuestID FROM Guests WHERE [Name] = 'Jeremiah Pendergrass');
DELETE FROM [Guests]
WHERE [Name] = 'Jeremiah Pendergrass';