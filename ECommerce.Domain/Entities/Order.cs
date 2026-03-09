using ECommerce_Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        [Required]
        public int CustomerId { get; private set; }

        public DateTime OrderDate { get; private set; }

        public Address ShippingAddress { get; private set; } = null!;

        [Column(TypeName = "decimal(12,2)")]

        public decimal TotalAmount { get; private set; }

        public Customer Customer { get; private set; } = null!;

        public ICollection<OrderItem> Items { get; private set; } = new List<OrderItem>();
        
        private Order() { }

        public Order(int customerId, DateTime orderDate, Address shippingAddress, decimal totalAmount)
        {
            CustomerId = customerId;
            OrderDate = orderDate;
            ShippingAddress = shippingAddress;
            TotalAmount = totalAmount;
        }

        public void AddItem(Product product,int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");
            
            if(product.StcokQuantity < quantity)
                throw new ArgumentException("Insufficient stock for the product.");

            var existingItem = Items.FirstOrDefault(i => i.ProductId == product.Id);
            if(existingItem != null)
            {
                existingItem.IncreaseQuantity(quantity);
            }
            else
            {
                 Items.Add(new OrderItem(this,product.Id, product.Name, quantity, product.Price));
            }

            product.ReduceStock(quantity);
            CalculateTotalAmount();
        }

        private void CalculateTotalAmount()
        {
            TotalAmount = Items.Sum(i => i.Quantity * i.UnitPrice);
        }
    }
}
