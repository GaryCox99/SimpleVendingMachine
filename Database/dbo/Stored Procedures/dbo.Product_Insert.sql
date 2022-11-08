

CREATE PROCEDURE [dbo].[Product_Insert] ( @Id INT = NULL,
	@ProductName VARCHAR(50) ,
	@ProductCost MONEY ,
	@ProductQuantity INT
)
AS
BEGIN
	INSERT INTO dbo.Product
		(
			ProductName ,
			ProductCost ,
			ProductQuantity
		)
	VALUES
		(
			@ProductName ,
			@ProductCost ,
			@ProductQuantity
		)

	-- Return the system generated identity value
	SET @Id = SCOPE_IDENTITY()

	-- Return the row column values
	EXEC dbo.Product_ReadByID @Id
END