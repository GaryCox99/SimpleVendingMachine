using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    [Table("Invoice")]
    public class Invoice : IModel<Invoice>
    {
        [Key]
        [Editable(false)]
        public string Id { get; set; }
        public string NameOnCard { get; set; }
        public string CreditCardNumber { get; set; }
        public string CreditCardExpiration { get; set; }
        public string CreditCardCVV { get; set; }
        public string CreditCardZipcode { get; set; }
        public string TransactionTotalDue { get; set; }
        public string TransactionTotalQuantity { get; set; }
        public string TransactionStatus { get; set; }
        public string CreatedDate { get; set; }

        public Invoice Clone()
        {
            return new Invoice
            {
                Id = Id,
                NameOnCard = NameOnCard,
                CreditCardNumber = CreditCardNumber,
                CreditCardExpiration = CreditCardExpiration,
                CreditCardCVV = CreditCardCVV,
                CreditCardZipcode = CreditCardZipcode,
                TransactionTotalDue = TransactionTotalDue,
                TransactionTotalQuantity = TransactionTotalQuantity,
                TransactionStatus = TransactionStatus,
                CreatedDate = CreatedDate,
            };
        }
    }
}
