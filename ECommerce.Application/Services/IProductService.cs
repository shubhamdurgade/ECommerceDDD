using ECommerce.Application.DTOs;

namespace ECommerce.Application.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductAsync();

        Task<ProductDTO> GetProductByIdAsync(int it);

        Task<ProductDTO> AddProductAsync(CreateProductDTO productDTO);
    }
}
