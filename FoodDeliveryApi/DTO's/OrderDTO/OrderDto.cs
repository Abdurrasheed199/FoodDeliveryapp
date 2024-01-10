using FoodDeliveryApi.DTO_s.CartDTO;
using FoodDeliveryApi.DTO_s.UserDTO;
using FoodDeliveryApi.Entities;

namespace FoodDeliveryApi.DTO_s.OrderDTO
{
    public class OrderDto
    {
        public string Id { get; set; }
        public string ReferenceNumber { get; set; }
        public CartDto Cart { get; set; }
        public UserDto User { get; set; }
        public DateTime Date { get; set; }
        public string PendingOrder { get;set; }
    }
}
