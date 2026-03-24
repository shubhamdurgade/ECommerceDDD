using AutoMapper;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Services;
using ECommerce_Application.DTOs;
using ECommerce_Infrastructure.Repository;

namespace ECommerce_Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRespository _orderRepository;
        private readonly OrderDomainService _orderDomainService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public OrderService(ICustomerRepository customerRepository, IProductRepository productRepository, OrderRepository orderRepository, OrderDomainService orderDomainService)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _orderDomainService = orderDomainService;
        }

        public async Task<OrderDTO> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null) return null;

            return _mapper.Map<OrderDTO>(order); 
        }

        public async Task<int> PlaceOrderAsync(CreateOrderRequestDTO request)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            // Use AddressDTO directly, as it is already imported via using ECommerce_Application.DTOs;
            var shippingAddress = new Address(
                request.ShippingAddress.Street,
                request.ShippingAddress.City,
                request.ShippingAddress.State,
                request.ShippingAddress.PostalCode,
                request.ShippingAddress.Country
            );
             
            // Use AddressDTO directly in the Order constructor.
            var order = new Order(request.CustomerId, shippingAddress);

            foreach(var item in request.Items)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                if(product == null){
                    throw new Exception($"Product with ID {item.ProductId} not found");
                }

                order.AddItem(product, item.Quantity);
            }

            if(!_orderDomainService.CanPlaceOrder(customer, order.Items.ToList()))
            {
                throw new Exception("Order cannot be placed due to business rules.");
            }

            await _orderRepository.AddAsync(order);
            return order.Id;
        }
    }
}
