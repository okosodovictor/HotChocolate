using HotChocolate.Entities;
using HotChocolateExample.Managers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolate.Managers
{
    public class ProductRepository: IProductRepository
    {
        private readonly EntityContext _dbContext;

        public ProductRepository(EntityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetOne(int id)
        {
            return await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
