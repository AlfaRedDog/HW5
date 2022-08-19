using DataAcess.Datatables;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataAcess.Consumers.Customer;
using DataAcess.Datatables.Repositories.interfaces;
using DataAcess.Datatables.Repositories;
using DataAcess.Consumers.Item;

namespace HW5
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

            string dbConnString = Configuration.GetConnectionString("SQLConnectionString");

            services.AddDbContext<DBShopContext>(options =>
            {
                options.UseSqlServer(dbConnString);
            });

            services.AddScoped<IDBShopContext, DBShopContext>();

            services.AddTransient<ICustomersRepository, CustomersRepository>();
            services.AddTransient<IItemsRepository, ItemsRepository>();
            services.AddTransient<IProvidersRepository, ProvidersRepository>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();

            services.AddMassTransit(x =>
            {
                x.AddConsumer<CRUCustomerConsumer>();
                x.AddConsumer<FindCustomersConsumer>();
                x.AddConsumer<CRUItemConsumer>();
                x.AddConsumer<FindItemsConsumer>();

                //add others consumers
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });

                    cfg.ReceiveEndpoint("CRUCustomer", ep => ep.ConfigureConsumer<CRUCustomerConsumer>(context));
                    cfg.ReceiveEndpoint("FindCustomers", ep => ep.ConfigureConsumer<FindCustomersConsumer>(context));
                    cfg.ReceiveEndpoint("FindItems", ep => ep.ConfigureConsumer<FindItemsConsumer>(context));
                    cfg.ReceiveEndpoint("CRUItem", ep => ep.ConfigureConsumer<CRUItemConsumer>(context));
                    //add other endpoints
                });
            });

            services.AddMassTransitHostedService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using IServiceScope serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            using var context = serviceScope.ServiceProvider.GetService<DBShopContext>();

            context.Database.Migrate();

            app.UseRouting();
        }
    }
}
