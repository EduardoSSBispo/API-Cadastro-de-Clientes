using AutoMapper;
using CadastroClienteAPI.Models;
using Core.DTO;

namespace CadastroClienteAPI.Mappers
{
    public class ClienteLogradouroDTOProfile : Profile
    {
        public ClienteLogradouroDTOProfile()
        {
            CreateMap<ClienteViewModel, ClienteLogradouroDTO>().ForMember(dest => dest.Logotipo, opt => opt.Ignore());
        }

    }
}
