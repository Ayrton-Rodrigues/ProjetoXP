using CadastroCliente.Data;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Api.Configuration
{
    public static class ConfigCadastroDbContext
    {
        public static IServiceCollection AddConfigDbContext(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<CadastroDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
