using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryApi.Contracts
{
    public abstract class BaseEntity : BaseEntity<string>
    {
        protected BaseEntity() => Id = Guid.NewGuid().ToString();
    }

    public abstract class BaseEntity<TId>
    {
        [Key]
        public TId Id { get; set; } = default!;
    }
}
