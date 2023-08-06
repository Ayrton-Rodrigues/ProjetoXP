using AutoMapper;
using CadastroCliente.Application.ViewModels;
using CadastroCliente.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Cliente, ClienteViewModel>()
                .ForMember(x => x.EnderecoViewModel, o => o.MapFrom(x => x.Endereco)).ReverseMap();


            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();           
        }

    }
}
