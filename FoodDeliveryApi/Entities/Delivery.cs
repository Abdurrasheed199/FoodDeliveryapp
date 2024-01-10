using FoodDeliveryApi.Contracts;

namespace FoodDeliveryApi.Entities
{
    public class Delivery : AuditableEntity
    {
        public Delivery( DateTime delivered, string customerId) 
        {
            Delivered = delivered;
            CustomerId = customerId;
            IsDelivered = false;
            CreatedBy = "Customer";
            LastModifiedBy = "Customer";
           
        }


        public DateTime Delivered { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public bool IsDelivered { get; set; }
    }
}
