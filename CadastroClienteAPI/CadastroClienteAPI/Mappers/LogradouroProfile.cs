using AutoMapper;
using CadastroClienteAPI.Models;
using Core.Entities;

namespace CadastroClienteAPI.Mappers
{
    public class LogradouroProfile : Profile
    {
        public LogradouroProfile()
        {
            CreateMap<LogradouroViewModel, Logradouro>().ReverseMap();
        }

    }
}
