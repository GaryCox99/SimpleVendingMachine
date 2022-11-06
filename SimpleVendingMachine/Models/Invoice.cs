namespace SimpleVendingMachine.Models
{
    public class Invoice
    {
        public int? Id { get; set; }
        public string? Type { get; set; }
        public double? Total { get; set; }
        public string? Status { get; set; } 
        public DateTime? Created { get; set; }

    }
}
