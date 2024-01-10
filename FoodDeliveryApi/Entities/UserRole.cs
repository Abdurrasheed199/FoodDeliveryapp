using FoodDeliveryApi.Contracts;

namespace FoodDeliveryApi.Entities
{
    public class UserRole : AuditableEntity
    {
        public UserRole() 
        {

        }

         
        public string UserId { get; set; }  
        public string RoleId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
