using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;

namespace Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IValidatorService<OrderDetail>, ProductService>();

            return services;
        }
    }
}
