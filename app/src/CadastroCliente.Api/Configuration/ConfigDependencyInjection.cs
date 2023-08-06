using AutoMapper;
using CadastroCliente.Application.AutoMapper;
using CadastroCliente.Application.Services;
using CadastroCliente.Data;
using CadastroCliente.Data.Repository;
using CadastroCliente.Domain.Interfaces;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace CadastroCliente.Api.Configuration
{
    public static class ConfigDependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<CadastroDbContext>();

            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfig());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);            

            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<IClienteService, ClienteService>();
            


            return services;
        }
    }
}
