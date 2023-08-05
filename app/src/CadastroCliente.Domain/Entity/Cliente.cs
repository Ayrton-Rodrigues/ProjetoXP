namespace CadastroCliente.Domain.Entity;

public class Cliente : Entity
{

 
    public string Nome { get; private set; }
    
    public string Email { get; private set; }
    
    public DateTime DataCadastro { get; private set; }

    public Endereco Endereco { get; private set; }

    public Cliente(string nome, string email,DateTime dataCadastro , Endereco endereco)
    {
        Nome = nome;
        Email = email;
        DataCadastro = dataCadastro;
        Endereco = endereco;
    }
    
}


