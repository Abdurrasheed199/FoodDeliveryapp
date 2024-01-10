using FoodDeliveryApi.DTO_s.UserDTO;
using FoodDeliveryApi.Entities;

namespace FoodDeliveryApi.DTO_s.CustomerDTO
{
    public class CustomerDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public UserDto User { get; set; }
    }
}
