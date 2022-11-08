using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseModels
{
    [Table("Product")]
    public class Product : IModel<Product>
    {
        [Key]
        [Editable(false)]
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCost { get; set; }
        public string ProductQuantity { get; set; }

        public Product Clone()
        {
            return new Product
            {
                Id = Id,
                ProductName = ProductName,
                ProductCost = ProductCost,
                ProductQuantity = ProductQuantity,
            };
        }
    }
}