using CadastroCliente.Domain.Entity;
using CadastroCliente.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Data;

public class CadastroDbContext : DbContext, IUnitOfWork
{
    public CadastroDbContext(DbContextOptions<CadastroDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CadastroDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
    public async Task<bool> Commit()
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("DataCadastro").CurrentValue = DateTime.Now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("DataCadastro").IsModified = false;
                entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
            }
        }

        return await base.SaveChangesAsync() > 0;
    }
}
        
