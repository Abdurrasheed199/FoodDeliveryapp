using FoodDeliveryApi.DTO_s.CustomerDTO;

namespace FoodDeliveryApi.DTO_s.DeliveryDTO
{
    public class DeliveryDto
    {
        public string Id { get; set; }
        public DateTime Delivered { get; set; }
        public CustomerDto Customer { get; set; }
        public bool IsDelivered { get; set; }
    }
}
