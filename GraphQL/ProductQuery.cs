using HotChocolate.Entities;
using HotChocolate.Types;
using HotChocolateExample.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateExample.GraphQL
{
    public class ProductQuery: ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Field("products")
                .Type<ListType<ProductGraph>>().Resolver(context => context.Service<IProductRepository>().GetAll());

        }
    }
}
