namespace FoodDeliveryApi.Contracts
{
    public abstract class AuditableEntity : AuditableEntity<string>
    {
    }

    public abstract class AuditableEntity<T> : BaseEntity, IAuditableEntity, ISoftDelete
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; private set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }

        protected AuditableEntity() : base() 
        {
            CreatedOn = DateTime.UtcNow;
            LastModifiedOn = DateTime.UtcNow;
        }
}   }
