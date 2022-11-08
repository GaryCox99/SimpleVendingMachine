

CREATE FUNCTION [dbo].[InvoiceTotalQuantity]
(
	@Id INT
)
RETURNS INT
AS
BEGIN
	DECLARE @ReturnVar Money

	SELECT @ReturnVar = (
		SELECT SUM(ii.ProductQuantity)
		FROM dbo.Invoice i
		INNER JOIN dbo.InvoiceItem ii
			ON ii.InvoiceId = i.Id
		WHERE
			i.Id = @Id
	)

	RETURN @ReturnVar
END
