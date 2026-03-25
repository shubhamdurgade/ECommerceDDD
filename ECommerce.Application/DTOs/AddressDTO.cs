using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs
{
    public class AddressDTO
    {
        public AddressDTO(string street, string city, string state, string postalCode, string country)
        {
            Street=street;
            City=city;
            State=state;
            PostalCode=postalCode;
            Country=country;
        }

        [Required, MaxLength(250)]
        public string Street { get; set; } = null!;

        [Required, MaxLength(100)]

        public String City { get; set; } = null!;

        [Required, MaxLength(100)]
        public string State { get; set; } = null!;

        [Required, MaxLength(20)]
        public string PostalCode { get; set; } = null!;

        [Required, MaxLength(100)]

        public string Country { get; set; } = null!; 
    }
}
