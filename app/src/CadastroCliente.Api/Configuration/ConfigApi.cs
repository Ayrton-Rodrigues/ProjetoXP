using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CadastroCliente.Api.Configuration
{
    public static class ConfigApi
    {
        public static IServiceCollection ApiConfig(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(
                options => options.SuppressModelStateInvalidFilter = true);

            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            services.ResolveDependencies();
            

            return services;
        }

        
    }
}
