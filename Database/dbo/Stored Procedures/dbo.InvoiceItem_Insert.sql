

CREATE PROCEDURE [dbo].[InvoiceItem_Insert] ( @Id INT ,
	@InvoiceId INT ,
	@ProductId INT ,
	@ProductQuantity INT
)
AS
BEGIN
	INSERT INTO dbo.InvoiceItem
		(
			InvoiceId ,
			ProductId ,
			ProductQuantity
		)
	VALUES
		(
			@InvoiceId ,
			@ProductId ,
			@ProductQuantity
		)

	-- Return the system generated identity value
	SET @Id = SCOPE_IDENTITY()

	-- Return the row column values
	EXEC dbo.InvoiceItem_ReadByID @Id
END