using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolate.Entities
{
    public class EntityContext:DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
