

CREATE PROCEDURE [dbo].[Product_Update] ( @Id INT ,
		@ProductQuantity INT
	)
AS
	UPDATE
		dbo.Product
	SET
		ProductQuantity = @ProductQuantity
	WHERE
		Id = @Id

	-- Return the row column values
	EXEC dbo.Product_ReadByID @Id
