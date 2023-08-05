namespace CadastroCliente.Domain.Entity;

public class Endereco : Entity
{
    public Guid ClienteId { get; private set; }
    public string Numero { get; private set; }

    public string Bairro { get; private set; }

    public string Cidade { get; private set; }

    public string Estado { get; private set; }

    public string Cep { get; private set; }

    public Endereco(string numero, string bairro, string cidade, string estado, string cep, Guid clienteId)
    {

        Numero = numero;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
        Cep = cep;
        ClienteId = clienteId;
    }
}


