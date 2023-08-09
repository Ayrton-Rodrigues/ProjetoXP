using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Application.ViewModels
{
    public class EnderecoViewModel
    {
         
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa conter entre {2} e {1} caracter", MinimumLength = 2)]
        public required string Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(8, ErrorMessage = "O campo {0} precisa conter entre {2} e {1} caracter", MinimumLength = 8)]
        public required string Cep { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa conter entre {2} e {1} caracter", MinimumLength = 2)]
        public required string Bairro { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa conter entre {2} e {1} caracter", MinimumLength = 2)]
        public required string Cidade { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa conter entre {2} e {1} caracter", MinimumLength = 2)]
        public required string Estado { get; set; }

        public Guid? ClienteId { get; set; }

    }
}
       

 

