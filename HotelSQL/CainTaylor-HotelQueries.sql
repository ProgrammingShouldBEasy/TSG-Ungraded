--1. Write a query that returns a list of reservations that end in July 2023, including the name of the guest, the room number(s), and the reservation dates.
--SELECT Reservations.[Room Number], Guests.[Name], Reservations.[Start Date], Reservations.[End Date] FROM [Reservations]
--JOIN Guests ON Reservations.GuestID = Guests.GuestID
--WHERE Reservations.[End Date] >= '7/1/2023' and Reservations.[End Date] <= '7/31/2023';

--Room Number	Name	Start Date	End Date
--205	Cain	2023-06-28	2023-07-02
--204	Walter Holaway	2023-07-13	2023-07-14
--401	Wilfred Vise	2023-07-18	2023-07-21
--303	Bettyann Seery	2023-07-28	2023-07-29

--2. Write a query that returns a list of all reservations for rooms with a jacuzzi, displaying the guest's name, the room number, and the dates of the reservation.
--SELECT Reservations.[Room Number], Guests.[Name], Reservations.[Start Date], Reservations.[End Date] FROM [Reservations]
--JOIN Guests ON Reservations.GuestID = Guests.GuestID
--WHERE Reservations.[Room Number] in (SELECT Rooms.[Room Number] FROM Rooms Where Jacuzzi = 1);

--Room Number	Name	Start Date	End Date
--203	Bettyann Seery	2023-02-05	2023-02-10
--305	Duane Cullison	2023-02-22	2023-02-24
--201	Karie Yang	2023-03-06	2023-03-07
--307	Cain	2023-03-17	2023-03-20
--301	Walter Holaway	2023-04-09	2023-04-13
--207	Wilfred Vise	2023-04-23	2023-04-24
--205	Cain	2023-06-28	2023-07-02
--303	Bettyann Seery	2023-07-28	2023-07-29
--305	Bettyann Seery	2023-08-30	2023-09-01
--203	Karie Yang	2023-09-13	2023-09-15
--301	Mack Simmer	2023-11-22	2023-11-25

--3. Write a query that returns all the rooms reserved for a specific guest, including the guest's name, the room(s) reserved, 
--the starting date of the reservation, and how many people were included in the reservation. (Choose a guest's name from the existing data.)
--SELECT Guests.[Name], Reservations.[Room Number], Reservations.[Start Date], Reservations.[Adults] + Reservations.[Children] 'Total People'
--FROM Reservations
--JOIN Guests ON Reservations.GuestID = Guests.GuestID
--WHERE Reservations.GuestID in (SELECT Guests.GuestID WHERE [Name] = 'Cain');

--Name	Room Number	Start Date	Total People
--Cain	307	2023-03-17	2
--Cain	205	2023-06-28	2

--4. Write a query that returns a list of rooms, reservation ID, and per-room cost for each reservation. 
--The results should include all rooms, whether or not there is a reservation associated with the room.
--SELECT Rooms.[Room Number], Reservations.[ReservationID], Reservations.[Cost]
--FROM Rooms
--LEFT JOIN Reservations ON Rooms.[Room Number] = Reservations.[Room Number]

--Room Number	ReservationID	Cost
--201	4	199.99
--202	7	349.98
--203	2	999.95
--203	21	399.98
--204	16	184.99
--205	15	699.96
--206	12	599.96
--206	23	449.97
--207	10	174.99
--208	13	599.96
--208	20	149.99
--301	9	799.96
--301	24	599.97
--302	6	924.95
--302	25	699.96
--303	18	199.99
--304	14	184.99
--305	3	349.98
--305	19	349.98
--306	NULL	NULL
--307	5	524.97
--308	1	299.98
--401	11	1199.97
--401	17	1259.97
--401	22	1199.97
--402	NULL	NULL

--5. Write a query that returns all the rooms accommodating at least three guests and that are reserved on any date in April 2023.
--SELECT Reservations.[Room Number], Guests.[Name], Reservations.Adults, Reservations.Children, Reservations.[Start Date], Reservations.[End Date], Reservations.Cost
--FROM Reservations
--JOIN Guests ON Reservations.GuestID = Guests.GuestID
--WHERE Reservations.Adults + Reservations.Children >= 3 and 
----Checks for start dates before April that runs through at least the start of April 2023.
--((Reservations.[Start Date] <= '4/1/2023' and Reservations.[End Date] >= '4/1/2023') or
----Checks start dates that occur within April 2023.
--(Reservations.[Start Date] >= '4/1/2023' and Reservations.[Start Date] <= '4/30/2023') or
----Checks end dates that occur within April 2023.
--(Reservations.[End Date] >= '4/1/2023' and Reservations.[End Date] <= '4/30/2023'))

--There are no results.

--6. Write a query that returns a list of all guest names and the number of reservations per guest, 
--sorted starting with the guest with the most reservations and then by the guest's last name.
--SELECT Guests.[Name], COUNT(Reservations.GuestID) [Total Reservations]
--FROM Guests
--JOIN Reservations ON Guests.GuestID = Reservations.GuestID
--WHERE Guests.GuestID in (SELECT Reservations.GuestID FROM Reservations)
--GROUP BY Guests.[Name]

--Name	Total Reservations
--Aurore Lipton	2
--Bettyann Seery	3
--Cain	2
--Duane Cullison	2
--Joleen Tison	2
--Karie Yang	2
--Mack Simmer	4
--Maritza Tilton	2
--Walter Holaway	2
--Wilfred Vise	2
--Zachery Luechtefeld	1

--7. Write a query that displays the name, address, and phone number of a guest based on their phone number. (Choose a phone number from the existing data.)
--SELECT Guests.[Name], Guests.[Address], Guests.Phone
--FROM Guests
--WHERE Guests.Phone = 2915530508;

--Name	Address	Phone
--Mack Simmer	379 Old Shore Street	2915530508

--For each query, include:

--The request from this assignment as a comment above the query, including the number
--The query itself
--The results of the query in a comment under the query