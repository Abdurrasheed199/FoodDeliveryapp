using FoodDeliveryApi.Contracts;

namespace FoodDeliveryApi.Entities
{
    public class Admin : AuditableEntity
    {
      
       
       public string UserId { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public int Age { get; set; }
       public string Email { get; set; }
    }
}
