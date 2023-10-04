using Microsoft.EntityFrameworkCore;
using Web.Api.Health_Clinic.Contexts;
using Web.Api.Health_Clinic.Domains;
using Web.Api.Health_Clinic.Interfaces;

namespace Web.Api.Health_Clinic.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly HealtContext _comentario;

        public ComentarioRepository()
        {
            _comentario = new HealtContext();
        }
        public Comentario BuscarPorId(Guid id)
        {
            try
            {
                return _comentario.Comentario
                    .Select(c => new Comentario
                    {
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,

                        Paciente = new Paciente
                        {
                            Nome = c.Paciente!.Nome
                        },

                        Consulta = new Consulta
                        {
                            IdConsulta = c.Consulta!.IdConsulta,
                        }

                    }).FirstOrDefault(c => c.IdComentario == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Comentario comentario)
        {
            try
            {
                _comentario.Comentario.Add(comentario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Comentario comentarioBuscado = _comentario.Comentario.Find(id)!;

                if (comentarioBuscado != null)
                {
                    _comentario.Comentario.Remove(comentarioBuscado);
                }

                _comentario.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Comentario> Listar()
        {
            try
            {
                return _comentario.Comentario
                    .Select(c => new Comentario
                    {
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,

                        Paciente = new Paciente
                        {
                            Nome = c.Paciente!.Nome
                        },

                        Consulta = new Consulta
                        {
                            IdConsulta = c.Consulta!.IdConsulta,
                        }

                    }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
