namespace SimpleVendingMachine.Models
{
    public class InvoiceItem
    {
        public int? Id { get; set; }
        public int? InvoiceId { get; set; }
        public string? Name { get; set; }
        public int? Quantity { get; set; }
    }
}
