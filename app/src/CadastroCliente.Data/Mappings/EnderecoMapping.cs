using CadastroCliente.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroCliente.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(x => x.Bairro)
                .IsRequired();
            builder.Property(x => x.Numero)
                .IsRequired();
            builder.Property(x => x.Estado)
                .IsRequired();
            builder.Property(x => x.Cidade)
                .IsRequired();
            builder.Property(x => x.Cep)
                .IsRequired();   
            builder.Property(x => x.ClienteId)
                .IsRequired();

            builder.HasOne(x => x.Cliente)
                .WithOne(x => x.Endereco);                
               

        }
    }
}
  
