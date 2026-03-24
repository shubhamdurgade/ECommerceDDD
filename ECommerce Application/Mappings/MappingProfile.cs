using AutoMapper;
using ECommerce.Domain.Entities;
using ECommerce_Application.DTOs;
using ECommerce_Infrastructure; 

namespace ECommerce_Application.NewFolder
{
    public class MappingProfile : Profile
    {

        public MappingProfile() 
        {
            //Product mappings
            CreateMap<Product, ProductDTO>();
            CreateMap<CreateProductDTO, Product>();

            //Order mappings
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderItem, OrderItemDTO>();

            //Address mappings
            CreateMap<Address, AddressDTO>();
        }

    }
}
