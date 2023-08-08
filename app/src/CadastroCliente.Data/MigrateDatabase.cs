using CadastroCliente.Domain.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Data
{
    public static class MigrateDatabase
    {
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope.ServiceProvider
                                 .GetService<CadastroDbContext>();

                serviceDb?.Database.EnsureDeleted();
                serviceDb?.Database.Migrate();


                IniciarDados.Iniciador(serviceDb);
            }
        }
    }

    public static class IniciarDados
    {
        public static void Iniciador(CadastroDbContext context)
        {
            var clientes = new List<Cliente>
            {
                new Cliente { Nome = "João Silva", Email = "joao.silva@example.com" ,DataCadastro = DateTime.Now },
                new Cliente { Nome = "Maria Silva", Email = "maria.silva@example.com" ,DataCadastro = DateTime.Now }
              
            };
            
            if (!context.Clientes.Any())
            {
                context.AddRange(clientes);
                context.SaveChanges();
            }

            var enderecos = new List<Endereco>
            {                    
                new Endereco { ClienteId = clientes.First(x => x.Nome == "João Silva").Id, Numero = "123", Bairro = "Centro",Cidade = "São Paulo", Estado = "SP", Cep = "01000000", Cliente = clientes.First(x => x.Nome == "João Silva")},
                new Endereco { ClienteId = clientes.First(x => x.Nome == "Maria Silva").Id, Numero = "133", Bairro = "Centro",Cidade = "São Paulo", Estado = "SP", Cep = "01000000", Cliente = clientes.First(x => x.Nome == "Maria Silva")}
            };
            
            if (!context.Enderecos.Any())
            {
                context.AddRange(enderecos);
                context.SaveChanges();
            }
        }
    }
}
