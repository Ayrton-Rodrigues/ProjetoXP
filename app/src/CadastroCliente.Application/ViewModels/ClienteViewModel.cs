using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Application.ViewModels;

public class ClienteViewModel
{
     
    [Key]
    public Guid Id { get; set; }
    
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(200, ErrorMessage = "O campo {0} precisa conter entre {2} e {1} caracter", MinimumLength = 2)]
     public required string Nome { get; set; }    
    
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(50, ErrorMessage = "O campo {0} precisa conter entre {2} e {1} caracter", MinimumLength = 2)]
    public required string Email { get; set; }

    public DateTime DataCadastro { get; set; } 
    public DateTime? DataAtualizacao { get; set; }

    public EnderecoViewModel? EnderecoViewModel { get; set; }


}

