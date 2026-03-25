using AutoMapper;
using ECommerce.Domain.Entities;
using ECommerce.Application.DTOs;
using ECommerce.Infrastructure; 

namespace ECommerce.Application.MappingProfile
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
