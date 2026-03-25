using ECommerce.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace ECommerce.Infrastructure
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required, MaxLength(200)]
        public string Name { get; private set; } = null!;

        [Column(TypeName = "decimal(12,2)")]
        public decimal Price { get; private set; }
        [MaxLength(1000)]
        public string? Description { get; private set; }

        public int StcokQuantity { get; private set; }

        public ICollection<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();
        
        private Product() { }

        public Product(string name, decimal price, string? description, int stockQuantity)
        {
            Name = name;
            Price = price;
            Description = description;
            StcokQuantity = stockQuantity;
        }

        public void ChangePrice(decimal newPrice)
        {
            if(newPrice< 0)
                throw new ArgumentException("Price cannot be positive.");

            Price = newPrice;
        }

        public void ReduceStock(int quantity)
        {
            if (quantity > StcokQuantity)
                throw new ArgumentException("Insufficient stock.");
            StcokQuantity -= quantity;
        }
    }
}
