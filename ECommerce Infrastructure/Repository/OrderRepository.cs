using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_Infrastructure.Repository
{
    public class OrderRepository : IOrderRespository
    {
        private readonly ECommerceDbContext _dbContext;

        public OrderRepository(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _dbContext.Orders
                .Include(o => o.Items)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
