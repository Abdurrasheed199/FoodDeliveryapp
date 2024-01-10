using FoodDeliveryApi.Contracts;

namespace FoodDeliveryApi.Entities
{
    public class Role : AuditableEntity
    {

        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}
