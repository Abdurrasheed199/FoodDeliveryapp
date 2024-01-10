using FoodDeliveryApi.Context;
using FoodDeliveryApi.Implementation.Repositories;
using FoodDeliveryApi.Implementation.Services;
using FoodDeliveryApi.Interface.Repositories;
using FoodDeliveryApi.Interface.Services;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryApi.Configure
{
    public static class StartupClass
    {

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString));
            return services;

        }
        public static IServiceCollection MyScoped(this IServiceCollection services)
        {
            //services.AddScoped<IUserStore<User>, UserRepository>();
            //services.AddScoped<IUserRoleStore<User>, UserRepository>();
            //services.AddScoped<IUserEmailStore<User>, UserRepository>();
            //services.AddScoped<IQueryableUserStore<User>, UserRepository>();
            //services.AddScoped<IUserPhoneNumberStore<User>, UserRepository>();
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IRoleStore<Role>, RoleRepository>();
            //services.AddIdentity<User, Role>().AddDefaultTokenProviders();
            //services.AddScoped<IIdentityService, IdentityService>();
            //services.AddScoped<IEmployeeService, EmployeeService>();
            //services.AddScoped<IEmployeeRespository, EmployeeRepository>();
            //services.AddScoped<ICadreLevelService, CadreLevelService>();
            //services.AddScoped<ICadreLevelRepository, CadreLevelRepository>();
            //services.AddScoped<IEarningsRepository, EarningsRepository>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDeliveryService, DeliveryService>();
            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
