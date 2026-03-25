using ECommerce.Application.DTOs; 
using ECommerce.Infrastructure;
using ECommerce.Domain.Repositories;
using AutoMapper;

namespace ECommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> AddProductAsync(CreateProductDTO productDto)
        {
            var product = new Product(productDto.Name, productDto.Price, productDto.Description, productDto.StockQuantity);
            await _productRepository.AddAsync(product);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProductByIdAsync(int it)
        {
            var product = await _productRepository.GetByIdAsync(it);
            return _mapper.Map<ProductDTO>(product);
        }
    }
}
