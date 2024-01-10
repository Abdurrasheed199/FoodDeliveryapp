using FoodDeliveryApi.Contracts;

namespace FoodDeliveryApi.Entities
{
    public class Cart : AuditableEntity
    { 
        public Cart() 
        {
            ProductCarts = new HashSet<ProductCart>();
        }



        public decimal TotalAmount { get; set; }
        public bool IsActive { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<ProductCart> ProductCarts { get; set; }

    }
}
