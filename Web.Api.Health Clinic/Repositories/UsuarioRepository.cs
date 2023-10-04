using Web.Api.Health_Clinic.Contexts;
using Web.Api.Health_Clinic.Domains;
using Web.Api.Health_Clinic.Interfaces;
using Web.Api.Health_Clinic.Utils;

namespace Web.Api.Health_Clinic.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealtContext _usuario;

        public UsuarioRepository()
        {
            _usuario = new HealtContext();
        }
        public void Atualizar(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorEmailESenha(string email, string Senha)
        {
            try
            {
                Usuario usuarioBuscado = _usuario.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,

                        TipoUsuario = new TipoUsuario
                        {
                            Titulo = u.TipoUsuario!.Titulo
                        }
                    }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(Senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario BuscarPorId(Guid Id)
        {
            try
            {
                Usuario usuarioBuscado = _usuario.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,

                        TipoUsuario = new TipoUsuario
                        {
                            Titulo = u.TipoUsuario!.Titulo
                        }
                    }).FirstOrDefault(u => u.IdUsuario == Id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _usuario.Add(usuario);

                _usuario.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid Id)
        {
            Usuario usuario = _usuario.Usuario.Find(Id)!;

            _usuario.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
