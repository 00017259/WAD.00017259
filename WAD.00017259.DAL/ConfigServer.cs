using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WAD._00017259.DAL.Interfaces;
using WAD._00017259.DAL.Repositories;
using WAD._00017259.Data;

namespace WAD._00017259.DAL
{
    public static class ConfigServices
    {
        public static IServiceCollection ConfigServicesDal(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
