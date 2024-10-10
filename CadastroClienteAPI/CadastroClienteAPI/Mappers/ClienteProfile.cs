using AutoMapper;
using CadastroClienteAPI.Models;
using Core.Entities;

namespace CadastroClienteAPI.Mappers
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteViewModel, Cliente>().ForMember(dest => dest.Logotipo, opt => opt.Ignore());
        }

    }
}
