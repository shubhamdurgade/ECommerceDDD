using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs
{
    public class OrderItemRequestDTO
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Quantity must be at leasrt 1")]
        public int Quantity { get; set; }

    }
}
