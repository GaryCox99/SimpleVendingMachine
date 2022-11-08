

CREATE PROCEDURE [dbo].[Invoice_Delete] (@Id INT)
	AS
	BEGIN
		DELETE FROM dbo.Invoice
		WHERE Id = @Id;
	END;
