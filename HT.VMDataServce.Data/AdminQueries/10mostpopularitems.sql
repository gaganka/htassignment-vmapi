SELECT TOP 10
	SUM(OI.Quantity) AS 'Qty Sold'
	, OI.ProductId
	, Prd.[Name]
FROM
	[dbo].[OrderItem] OI
JOIN
	[dbo].[Product] Prd
ON 
	Prd.ID = OI.ProductId
JOIN
	[dbo].[Order] Ord
ON 
	Ord.ID = OI.OrderId
WHERE DATEDIFF(DAY,GETDATE(),Ord.OrderDate) <=7
GROUP BY OI.ProductId, Prd.[Name]
ORDER BY COUNT(OI.Quantity) DESC