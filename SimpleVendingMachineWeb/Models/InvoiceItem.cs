namespace SimpleVendingMachine.Models
{
    public class InvoiceItem
    {
        public int? Id { get; set; }
        public int? InvoiceId { get; set; }
        public string? ProductName { get; set; }
        public int? Quantity { get; set; }
        public decimal? ItemTotal { get; set; }
    }
}
