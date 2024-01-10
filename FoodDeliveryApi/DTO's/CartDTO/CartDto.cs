using FoodDeliveryApi.DTO_s.UserCartDTO;
using FoodDeliveryApi.DTO_s.UserDTO;
using FoodDeliveryApi.Entities;

namespace FoodDeliveryApi.DTO_s.CartDTO
{
    public class CartDto
    {
        public string Id { get; set; }
        public UserDto User { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
