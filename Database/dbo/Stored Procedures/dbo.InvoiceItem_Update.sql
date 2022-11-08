

CREATE PROCEDURE [dbo].[InvoiceItem_Update] ( @Id INT ,
		@ProductQuantity INT
	)
AS
	UPDATE
		dbo.InvoiceItem
	SET
		ProductQuantity = @ProductQuantity
	WHERE
		Id = @Id

	-- Return the row column values
	EXEC dbo.InvoiceItem_ReadByID @Id
