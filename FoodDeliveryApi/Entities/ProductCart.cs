using FoodDeliveryApi.Contracts;

namespace FoodDeliveryApi.Entities
{
    public class ProductCart : AuditableEntity
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public string CartId { get; set; }
        public Cart Cart { get; set; }
        public int Quantity { get; set; }
    }
}
