using HotChocolate.Entities;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateExample.GraphQL
{
    public class ProductGraph : ObjectType<Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(t => t.Name);
            descriptor.Field(t => t.Description);
            descriptor.Field(t => t.Price);
            descriptor.Field(t => t.Rating);
            descriptor.Field(t => t.PhotoFileName);
            descriptor.Field(t => t.IntroducedAt);
        }
    }
}
