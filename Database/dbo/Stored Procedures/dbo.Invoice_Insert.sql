

CREATE PROCEDURE [dbo].[Invoice_Insert] ( @Id INT = NULL,
	@NameOnCard VARCHAR(50) ,
	@CreditCardNumber VARCHAR(20) ,
	@CreditCardExpiration VARCHAR(6) ,
	@CreditCardCVV VARCHAR(3) ,
	@CreditCardZipcode VARCHAR(5) ,
	@TransactionTotalDue MONEY ,
	@TransactionTotalQuantity INT ,
	@TransactionStatus VARCHAR(20) = 'CartEmpty'
)
AS
BEGIN
	INSERT INTO dbo.Invoice
		(
			NameOnCard ,
			CreditCardNumber ,
			CreditCardExpiration ,
			CreditCardCVV ,
			CreditCardZipcode ,
			TransactionTotalDue ,
			TransactionTotalQuantity ,
			TransactionStatus ,
			CreatedDate
		)
	VALUES
		(
			@NameOnCard ,
			@CreditCardNumber ,
			@CreditCardExpiration ,
			@CreditCardCVV ,
			@CreditCardZipcode ,
			@TransactionTotalDue ,
			@TransactionTotalQuantity ,
			@TransactionStatus ,
			GETDATE()
		)

	-- Return the system generated identity value
	SET @Id = SCOPE_IDENTITY()

	-- Return the row column values
	EXEC dbo.Invoice_ReadByID @Id
END