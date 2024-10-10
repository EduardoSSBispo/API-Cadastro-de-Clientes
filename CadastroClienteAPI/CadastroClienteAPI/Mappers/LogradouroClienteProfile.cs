using AutoMapper;
using CadastroClienteAPI.Models;
using Core.Entities;

namespace CadastroClienteAPI.Mappers
{
    public class LogradouroClienteProfile : Profile
    {
        public LogradouroClienteProfile()
        {
            CreateMap<ClienteViewModel, Logradouro>().ReverseMap();
        }

    }
}
