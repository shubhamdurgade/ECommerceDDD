using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace ECommerce.Domain.Entities
{
    [Index(nameof(Email),Name = "Index_RegistrationNumber", IsUnique = true)]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; private set; }

        [Required,MaxLength(100)]
        public string FirstName { get; private set; } = null!;

        [MaxLength(100)]
        public string? LastName { get; private set; }

        [Required,EmailAddress]
        public string Email { get; private set; } = null!;

        public Address Address { get; private set; } = null!;

        public ICollection<Order> Orders { get; private set; } = new List<Order>();

        private Customer() { }

        public Customer(string firstName, string? lastName, string email, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
        } 
    }
}
