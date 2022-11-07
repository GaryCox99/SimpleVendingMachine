namespace SimpleVendingMachine.Models
{
    public class Product
    {
        public int Id { get; set; } = -1;
        public string? Name { get; set; }
        public double Cost { get; set; }
        public int Quantity { get; set; }

    }
}
