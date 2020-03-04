USE SGBank
--OH°Ohio°6.25
--PA°Pennsylvania°6.75
--MI°Michigan°60
--IN°Indiana°6.00
--CA°California°20

--ProductType°CostPerSquareFoot°LaborCostPerSquareFoot
--1 Carpet°2.25°2.10
--2 Laminate°20.75°2.10
--3 Tile°3.50°4.15
--4 Wood°5.15°4.75
--5 MarbleFlooring°20°25

--INSERT INTO Orders([OrderDate], [name], [state], [productID], [area])
--VALUES
--('3-4-2020', 'John', 'OH', 1, 101),
--('3-4-2020', 'John', 'OH', 1, 101),
--('3-4-2020', 'John', 'OH', 1, 101),
--('3-4-2020', 'John', 'OH', 1, 101),
--('3-4-2020', 'John', 'OH', 1, 101);

SELECT 
	Orders.[orderNumber], Orders.[OrderDate], Orders.[name], Orders.[state], Orders.[productID], 
	Products.[product name], Products.[price per sq ft], Products.[labor per sq ft],
	States.[state name], States.[tax rate]
FROM Orders
JOIN Products ON Orders.[productID] = Products.[ProductID]
JOIN States ON Orders.[state] = States.[StateAbbreviation];