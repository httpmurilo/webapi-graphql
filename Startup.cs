using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGraph.Data;
using ApiGraph.Data.Repositories;
using ApiGraph.GraphQL.Schemas;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ApiGraph
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
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ProductRepository>();

            //GraphQL
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<ProductSchema>();
            services.AddGraphQL(o => {o.ExposeExceptions = true;})
                .AddGraphTypes(ServiceLifetime.Scoped);

            services.Configure<IISServerOptions>(options =>options.AllowSynchronousIO =true);
             services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL<ProductSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
