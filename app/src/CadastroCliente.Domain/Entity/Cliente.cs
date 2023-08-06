namespace CadastroCliente.Domain.Entity;

public class Cliente : Entity
{

    public required string Nome { get; set; }

    public required string Email { get; set; }

    public DateTime DataCadastro { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    
    public  Endereco? Endereco { get; set; }
}


