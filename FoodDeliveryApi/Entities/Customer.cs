using FoodDeliveryApi.Contracts;

namespace FoodDeliveryApi.Entities
{
    public class Customer : AuditableEntity
    {
        public Customer(string fullName, string email, string address, string phoneNumber, string userId):base()
        {
            FullName = fullName;
            Email = email;
            Address = address;
            PhoneNumber = phoneNumber;
            UserId = userId;
            CreatedBy = "Customer";
            LastModifiedBy = "Customer";
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        
    }
}
