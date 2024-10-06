using CadastroClienteAPI.Models;
using AutoMapper;
using Core;

namespace CadastroClienteAPI.Mappers
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteViewModel, Cliente>().ReverseMap();
        }

    }
}
