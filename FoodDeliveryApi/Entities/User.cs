using FoodDeliveryApi.Contracts;

namespace FoodDeliveryApi.Entities
{
    public class User : AuditableEntity
    {

        public User(string firstName, string lastName, string email):base()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public User(string firstName, string lastName, string email, string password, string username) : base()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Username = username;
        }

        public User() : base()
        {
            Orders = new HashSet<Order>();
            UserRoles = new HashSet<UserRole>();
            Carts = new HashSet<Cart>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public bool? IsEmailConfirmed { get; set; }       
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}
