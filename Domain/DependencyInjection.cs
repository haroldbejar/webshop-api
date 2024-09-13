using Domain.Builder;
using Domain.Data;
using Domain.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection services, string conString)
        {
            services.AddDbContext<WebShopContext>(options =>
            {
                options.UseSqlServer(conString);
            });

            return services;
        }

        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(ProductProfile),
                typeof(CategoryProfile),
                typeof(CustomerProfile),
                typeof(OrderProfile),
                typeof(ProductCategoryProfile),
                typeof(OrderDetailProfile));
            return services;
        }

        public static IServiceCollection AddBuilder(this IServiceCollection services)
        {
            services.AddTransient(typeof(BaseBuilder<>));
            services.AddTransient<ProductBuilder>(); 
            services.AddTransient<CategoryBuilder>();
            services.AddTransient<CustomerBuilder>();
            services.AddTransient<OrderBuilder>();
            services.AddTransient<OrderDetailBuilder>();
            services.AddTransient<ProductCategoryBuilder>();
            services.AddTransient<UserBuilder>();
            return services;
        }
    }
}
