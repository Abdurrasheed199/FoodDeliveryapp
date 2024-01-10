using FoodDeliveryApi.DTO_s.CustomerDTO;

namespace FoodDeliveryApi.DTO_s.DeliveryDTO
{
    public class CreateDeliveryRequestModel
    {
        public DateTime Delivered { get; set; }
        public string CustomerId { get; set; }
        public bool IsDelivered { get; set; }
    }
}
