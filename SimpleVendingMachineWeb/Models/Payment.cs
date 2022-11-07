namespace SimpleVendingMachineWeb.Models
{
    public class Payment
    {
        public int? Id { get; set; }
        public int InvoiceId { get; set; }
        public string NameOnCard { get; set; }
        public string CreditCardNumber { get; set; }
        public string CreditCardExpiration { get; set; }
        public string CreditCardCVV { get; set; }
        public string Zipcode { get; set; }
        public int TotalProducts { get; set; }
        public double TotalPayment { get; set; }
        public string TransactionStatus { get; set; }

    }
}
