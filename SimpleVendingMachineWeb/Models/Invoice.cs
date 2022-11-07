namespace SimpleVendingMachine.Models
{
    public class Invoice
    {
        public int? Id { get; set; }
        public string? Type { get; set; }
        public double? InvoiceTotal { get; set; }
        public int? ProductTotal { get; set; }
        public string? Status { get; set; } 
        public DateTime? Created { get; set; }

    }
}
