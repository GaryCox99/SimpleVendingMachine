

CREATE FUNCTION [dbo].[InvoiceTotalDue]
(
	@Id INT
)
RETURNS INT
AS
BEGIN
	DECLARE @ReturnVar Money

	SELECT @ReturnVar = (
		SELECT SUM(p.ProductCost)
		FROM dbo.InvoiceItem ii
		INNER JOIN dbo.Product p
			ON p.Id = ii.ProductId
		WHERE
			ii.InvoiceId = @Id
	)

	RETURN @ReturnVar
END
