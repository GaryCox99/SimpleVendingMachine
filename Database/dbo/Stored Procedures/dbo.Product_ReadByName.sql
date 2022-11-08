

CREATE PROCEDURE [dbo].[Product_ReadByName] (@ProductName VARCHAR(50)
	)
AS
	SET ANSI_NULLS ON
	SET NOCOUNT ON

	SELECT 
		Id, 
		ProductName,
		ProductCost,
		ProductQuantity
	FROM 
		dbo.Product
	WHERE
		ProductName = @ProductName
