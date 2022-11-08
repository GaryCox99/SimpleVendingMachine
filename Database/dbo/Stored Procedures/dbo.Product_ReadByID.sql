

CREATE PROCEDURE [dbo].[Product_ReadByID] ( @Id INT
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
		Id = @Id
