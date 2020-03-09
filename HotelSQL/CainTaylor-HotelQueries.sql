--1. Write a query that returns a list of reservations that end in July 2023, including the name of the guest, the room number(s), and the reservation dates.
--SELECT Guests.[Name], [Room to Reservation].[Room Number], Reservation.[Start Date], Reservation.[End Date]
--FROM Reservation
--JOIN [Room to Reservation] ON Reservation.ReservationID = [Room to Reservation].ReservationID
--JOIN Guests ON Guests.GuestID = Reservation.GuestID
--WHERE Reservation.[End Date] >= '7/1/2023' and Reservation.[End Date] <= '7/31/2023'

--Name	Room Number	Start Date	End Date
--Walter Holaway	204	2023-07-13	2023-07-14
--Cain	205	2023-06-28	2023-07-02
--Bettyann Seery	303	2023-07-28	2023-07-29
--Wilfred Vise	401	2023-07-18	2023-07-21

--2. Write a query that returns a list of all reservations for rooms with a jacuzzi, displaying the guest's name, the room number, and the dates of the reservation.
--SELECT Guests.[Name], [Room to Reservation].[Room Number], Reservation.[Start Date], Reservation.[End Date]
--FROM Reservation
--JOIN [Room to Reservation] ON Reservation.ReservationID = [Room to Reservation].ReservationID
--JOIN Guests ON Guests.GuestID = Reservation.GuestID
--JOIN Rooms ON [Room to Reservation].[Room Number] = Rooms.[Room Number]
--WHERE Rooms.[Room Number] in (SELECT [Room Number] FROM [Room to Amenities] WHERE [Room to Amenities].AmenityID = 3)

--Name	Room Number	Start Date	End Date
--Karie Yang	201	2023-03-06	2023-03-07
--Bettyann Seery	203	2023-02-05	2023-02-10
--Karie Yang	203	2023-09-13	2023-09-15
--Cain	205	2023-06-28	2023-07-02
--Wilfred Vise	207	2023-04-23	2023-04-24
--Walter Holaway	301	2023-04-09	2023-04-13
--Mack Simmer	301	2023-11-22	2023-11-25
--Bettyann Seery	303	2023-07-28	2023-07-29
--Duane Cullison	305	2023-02-22	2023-02-24
--Bettyann Seery	305	2023-08-30	2023-09-01
--Cain	307	2023-03-17	2023-03-20

--3. Write a query that returns all the rooms reserved for a specific guest, including the guest's name, the room(s) reserved, 
--the starting date of the reservation, and how many people were included in the reservation. (Choose a guest's name from the existing data.)
--SELECT Guests.[Name], Reservation.[Start Date], Reservation.[End Date], [Room to Reservation].[Room Number], 
--([Room to Reservation].Adults + [Room to Reservation].Children) Total
--FROM Guests
--JOIN [Reservation] ON Reservation.GuestID = Guests.GuestID
--JOIN [Room to Reservation] ON Reservation.ReservationID = [Room to Reservation].ReservationID
--WHERE Guests.[Name] = 'Mack Simmer';

--Name	Start Date	End Date	Room Number	Total
--Mack Simmer	2023-11-22	2023-11-25	206	2
--Mack Simmer	2023-09-16	2023-09-17	208	2
--Mack Simmer	2023-11-22	2023-11-25	301	4
--Mack Simmer	2023-02-02	2023-02-04	308	1

--4. Write a query that returns a list of rooms, reservation ID, and per-room cost for each reservation. 
--The results should include all rooms, whether or not there is a reservation associated with the room.
--SELECT [Rooms].[Room Number], [Room to Reservation].ReservationID,  [Room Type].[Base Price]
--FROM [Rooms]
--LEFT JOIN [Room to Reservation] ON Rooms.[Room Number] = [Room to Reservation].[Room Number]
--LEFT JOIN [Room Type] ON Rooms.Size = [Room Type].Size;

--Room Number	ReservationID	Base Price
--201	4	174.99
--202	7	174.99
--203	2	174.99
--203	20	174.99
--204	15	174.99
--205	14	149.99
--206	12	149.99
--206	22	149.99
--207	10	149.99
--208	12	149.99
--208	19	149.99
--301	9	174.99
--301	22	174.99
--302	6	174.99
--302	23	174.99
--303	17	174.99
--304	13	174.99
--305	3	149.99
--305	18	149.99
--306	NULL	149.99
--307	5	149.99
--308	1	149.99
--401	11	399.99
--401	16	399.99
--401	21	399.99
--402	NULL	399.99


--5. Write a query that returns all the rooms accommodating at least three guests and that are reserved on any date in April 2023.
--SELECT [Room to Reservation].[Room Number]
--FROM [Room to Reservation]
--JOIN Reservation ON [Room to Reservation].ReservationID = Reservation.ReservationID
--WHERE [Room to Reservation].Adults + [Room to Reservation].Children >= 3 and 
----Checks for start dates before April that runs through at least the start of April 2023.
--((Reservation.[Start Date] <= '4/1/2023' and Reservation.[End Date] >= '4/1/2023') or
----Checks start dates that occur within April 2023.
--(Reservation.[Start Date] >= '4/1/2023' and Reservation.[Start Date] <= '4/30/2023') or
----Checks end dates that occur within April 2023.
--(Reservation.[End Date] >= '4/1/2023' and Reservation.[End Date] <= '4/30/2023'))

--No rooms meet that criteria.

--6. Write a query that returns a list of all guest names and the number of reservations per guest, 
--sorted starting with the guest with the most reservations and then by the guest's last name.
--SELECT Guests.[Name], COUNT(Reservation.GuestID) [Total Reservations]
--FROM Guests
--JOIN Reservation ON Guests.GuestID = Reservation.GuestID
--WHERE Guests.GuestID in (SELECT Reservation.GuestID FROM Reservation)
--GROUP BY Guests.[Name]
--ORDER BY [Total Reservations], Guests.[Name]

--Name	Total Reservations
--Joleen Tison	1
--Zachery Luechtefeld	1
--Aurore Lipton	2
--Cain	2
--Duane Cullison	2
--Karie Yang	2
--Maritza Tilton	2
--Walter Holaway	2
--Wilfred Vise	2
--Bettyann Seery	3
--Mack Simmer	3

--7. Write a query that displays the name, address, and phone number of a guest based on their phone number. (Choose a phone number from the existing data.)
--SELECT Guests.Name, Guests.Address, Guests.Phone
--FROM Guests
--WHERE Guests.Phone = '1235554789'

--Name	Address	Phone
--Cain	Your Address	1235554789

--For each query, include:

--The request from this assignment as a comment above the query, including the number
--The query itself
--The results of the query in a comment under the query