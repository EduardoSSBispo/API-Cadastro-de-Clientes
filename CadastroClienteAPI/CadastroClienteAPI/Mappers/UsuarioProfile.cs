using AutoMapper;
using Core.DTO;
using Core.Entities;

namespace CadastroClienteAPI.Mappers
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile() 
        { 
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }        
    }
}
