

CREATE PROCEDURE [dbo].[Invoice_Update] ( @Id INT ,
		@NameOnCard VARCHAR(50) = NULL ,
		@CreditCardNumber VARCHAR(20) = NULL ,
		@CreditCardExpiration VARCHAR(6) = NULL ,
		@CreditCardCVV VARCHAR(3) = NULL ,
		@CreditCardZipcode VARCHAR(5) = NULL ,
		@TransactionStatus VARCHAR(20) = 'CartEmpty'
	)
AS
	UPDATE
		dbo.Invoice
	SET
		NameOnCard = @NameOnCard ,
		CreditCardNumber = @CreditCardNumber ,
		CreditCardExpiration = @CreditCardExpiration ,
		CreditCardCVV = @CreditCardCVV ,
		CreditCardZipcode = @CreditCardZipcode ,
		TransactionTotalDue = dbo.InvoiceTotalDue(@Id) ,
		TransactionTotalQuantity = dbo.InvoiceTotalQuantity(@Id) ,
		TransactionStatus = @TransactionStatus
	WHERE
		Id = @Id

	-- Return the row column values
	EXEC dbo.Invoice_ReadByID @Id
