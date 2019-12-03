using HotChocolate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateExample.Managers
{
    public  interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetOne(int id);
       
    }
}
