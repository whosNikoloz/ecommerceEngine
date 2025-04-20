using System;
using EcommerceEngine.Domain.Enums;

namespace EcommerceEngine.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole Role { get; set; }
        public bool EmailConfirmed { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        
        // Navigation properties
        public ICollection<Order> Orders { get; set; }
        
        public User()
        {
            Orders = new List<Order>();
            Role = UserRole.Customer;
        }
    }
}