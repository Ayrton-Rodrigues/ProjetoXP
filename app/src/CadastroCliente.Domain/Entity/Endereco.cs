namespace CadastroCliente.Domain.Entity;

public class Endereco : Entity
{
    public Guid ClienteId { get; set; }
    public required string Numero { get; set; }

    public required string Bairro { get; set; }

    public required string Cidade { get; set; }

    public required string Estado { get; set; }

    public required string Cep { get; set; }
    
    public required Cliente Cliente { get; set; }
}


