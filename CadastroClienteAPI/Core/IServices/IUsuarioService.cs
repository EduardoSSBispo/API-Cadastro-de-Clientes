using Core.DTO;
using Core.Entities;

namespace Core.IServices
{
    public interface IUsuarioService
    {
        public Usuario Create(UsuarioDTO usuario);

        public void Edit(UsuarioDTO usuario);

        public void Delete(int id);

        public UsuarioDTO? Get(int id);
    }
}
