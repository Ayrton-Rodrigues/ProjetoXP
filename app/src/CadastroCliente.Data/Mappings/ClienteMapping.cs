using CadastroCliente.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(x => x.Nome)
                .IsRequired();


            builder.Property(x => x.Email)
                .IsRequired();

            builder.Property(x => x.DataCadastro)
                .IsRequired();

            builder.HasOne(x => x.Endereco)
                .WithOne(x => x.Cliente)
                .HasForeignKey<Endereco>(x => x.ClienteId);
        }
    }
}

 