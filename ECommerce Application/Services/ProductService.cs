using ECommerce_Application.DTOs; 
using ECommerce_Infrastructure;
using ECommerce.Domain.Repositories;
using AutoMapper;

namespace ECommerce_Application.Services
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

        public Task<IEnumerable<ProductDTO>> GetAllProductAsync()
        {
            var pro
        }

        public Task<ProductDTO> GetProductByIdAsync(int it)
        {
            throw new NotImplementedException();
        }
    }
}
