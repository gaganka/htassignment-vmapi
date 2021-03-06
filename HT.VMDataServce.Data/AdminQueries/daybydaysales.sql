/****** Script for day by day sales for prev 30 days  ******/
SELECT Ord.[ID]
      ,Ord.[OrderDate]
      ,Ord.[OrderValue]
	  ,Pyt.[AmountPaid]
	  ,Prd.[Name] AS 'Produt Name'
	  ,OrdIt.[Quantity]
	  ,OrdIt.[LineItemTotal]
FROM 
	[HTVMDEVDB01].[dbo].[Order] Ord
JOIN 
	[HTVMDEVDB01].[dbo].[OrderPayment] Pyt
ON
	Pyt.OrderId = Ord.Id
JOIN
	[HTVMDEVDB01].[dbo].[OrderItem] OrdIt
ON 
	OrdIt.OrderId = Ord.ID
JOIN
	[HTVMDEVDB01].[dbo].[Product] Prd
ON
	OrdIt.ProductId = PRd.ID
WHERE
	DATEDIFF(DAY,GETDATE(),Ord.OrderDate) <= 30