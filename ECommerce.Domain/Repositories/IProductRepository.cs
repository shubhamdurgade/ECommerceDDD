using ECommerce_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);

        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product> AddAsync(Product product);

        Task UpdateAsync(Product product);
    }
}
