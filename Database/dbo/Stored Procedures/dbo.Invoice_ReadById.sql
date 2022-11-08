

CREATE PROCEDURE [dbo].[Invoice_ReadByID] ( @Id INT
	)
AS
	SET ANSI_NULLS ON
	SET NOCOUNT ON

	SELECT 
		Id ,
		NameOnCard ,
		CreditCardNumber ,
		CreditCardExpiration ,
		CreditCardCVV ,
		CreditCardZipcode ,
		TransactionTotalDue ,
		TransactionTotalQuantity ,
		TransactionStatus ,
		CreatedDate
	FROM 
		dbo.Invoice
	WHERE
		Id = @Id
