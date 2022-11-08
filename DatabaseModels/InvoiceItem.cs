using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels
{
    [Table("InvoiceItem")]
    public class InvoiceItem : IModel<InvoiceItem>
    {
        [Key]
        [Editable(false)]
        public string Id { get; set; }
        public string InvoiceId { get; set; }
        public string ProductId { get; set; }
        public string ProductQuantity { get; set; }

        public InvoiceItem Clone()
        {
            return new InvoiceItem
            {
                Id = Id,
                InvoiceId = InvoiceId,
                ProductId = ProductId,
                ProductQuantity = ProductQuantity,
            };
        }
    }
}
