using FoodDeliveryApi.Contracts;

namespace FoodDeliveryApi.Entities
{
    public class Order : AuditableEntity
    {

        public string ReferenceNumber { get; set; }
        public bool IsApproved { get; set; }
        public string CartId { get; set; }
        public Cart Cart { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public bool PendingOrder { get; set; }

    }
}
