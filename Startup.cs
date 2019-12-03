using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using HotChocolate.Entities;
using HotChocolate.Execution.Configuration;
using HotChocolate.Managers;
using HotChocolateExample.GraphQL;
using HotChocolateExample.Managers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HotChocolate
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<EntityContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:CarvedRock"]));

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddDataLoaderRegistry();

            // Add GraphQL Services
            //  .AddMutationType<MutationType>()

            services.AddGraphQL(sp => SchemaBuilder.New()
                    .AddQueryType<ProductQuery>()
                    .Create(),
                new QueryExecutionOptions
                {
                    TracingPreference = TracingPreference.OnDemand,
                    IncludeExceptionDetails = true
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, EntityContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            dbContext.Seed();
            app.UseGraphQL("/graphql")
               .UseGraphiQL("/graphql")
               .UsePlayground("/graphql", "/ui/playground")
               .UseVoyager("/graphql");
        }
    }
}
