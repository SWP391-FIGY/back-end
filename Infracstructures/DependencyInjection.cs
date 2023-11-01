using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Infracstructures.Services;
using Infracstructures.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infracstructures
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfractstructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("BirdFarmDB"))
            );
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<ICurrentTime, CurrentTime>();
            services.AddServiceDependency();
            return services;
        }

        private static IServiceCollection AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IBirdService, BirdService>();
            services.AddScoped<ICageService, CageService>();
            services.AddScoped<IFeedingPlanService, FeedingPlanService>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IMealMenuService, MealMenuService>();
            services.AddScoped<IMenuDetailService, MenuDetailService>();
            services.AddScoped<IPurchaseOrderDetailService, PurchaseOrderDetailService>();
            services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
            services.AddScoped<IPurchaseRequestService, PurchaseRequestService>();
            services.AddScoped<ISpeciesService, SpeciesService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IUserService, UserService>();
            return services; 
        }
    }

}
