using FoodDeliveryApi.Contracts;

namespace FoodDeliveryApi.Entities
{
    public class Product : AuditableEntity
    {
        public Product() 
        {
            ProductCarts = new HashSet<ProductCart>();
        }

        public Product(string productName, string productDescription, decimal price, int quantity, string image) 
        {
            ProductName = productName;
            ProductDescription = productDescription;
            Price = price;
            Quantity = quantity;
            IsAvailable = false;
            Image = image;
            CreatedBy = "Customer";
            LastModifiedBy = "Customer";
        }

        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
        public string Image { get; set; }
        public ICollection<ProductCart> ProductCarts { get; set; }
    }
}
