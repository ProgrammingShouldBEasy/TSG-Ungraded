USE [CarSite]
GO

SELECT Cars.Year, Model.ModelName as Model, Make.MakeName as Make,COUNT(DISTINCT Cars.id) as "Count", SUM(Cars.MSRP) as StockValue
FROM [Cars]
JOIN Model ON Model.id = Cars.ModelID
JOIN Make ON Make.id = Model.MakeID
GROUP BY Model.ModelName, Make.MakeName, Cars.Year