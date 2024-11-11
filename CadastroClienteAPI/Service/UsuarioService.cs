using AutoMapper;
using Core.DTO;
using Core.Entities;
using Core.IServices;
using System.Security.Cryptography;
using System.Text;

namespace Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly CadastroContext _context;
        private readonly IMapper _mapper;

        public UsuarioService(CadastroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Usuario Create(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            if (usuarioDTO.Senha != null)
            {
                using var hmac = new HMACSHA512();
                byte[] senhaHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(usuarioDTO.Senha));
                byte[] SaltSenha = hmac.Key;

                usuario.SaltSenha = SaltSenha;
                usuario.HashSenha = senhaHash;
            }

            _context.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }

        public void Delete(int id)
        {
            var usuario = _context.Usuario.Find(id);

            _context.Usuario.Remove(usuario);
            _context.SaveChanges();
        }

        public void Edit(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            _context.Add(usuario);
            _context.SaveChanges();
        }

        public UsuarioDTO? Get(int id)
        {
            var usuario = _mapper.Map<UsuarioDTO>(_context.Usuario.Find(id));

            return usuario;
        }
    }
}
