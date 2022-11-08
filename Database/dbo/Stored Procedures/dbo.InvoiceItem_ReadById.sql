

CREATE PROCEDURE [dbo].[InvoiceItem_ReadById] ( @Id INT
	)
AS
	SET ANSI_NULLS ON
	SET NOCOUNT ON

	SELECT 
		Id ,
		InvoiceId ,
		ProductId ,
		ProductQuantity
	FROM 
		dbo.InvoiceItem
	WHERE
		Id = @Id
