using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Web.Api.Health_Clinic.Contexts;
using Web.Api.Health_Clinic.Domains;
using Web.Api.Health_Clinic.Interfaces;

namespace Web.Api.Health_Clinic.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuario
    {
        private readonly HealtContext _tipoUsuario;

        public TipoUsuarioRepository()
        {
            _tipoUsuario = new HealtContext();
        }

        public void Atualizar(Guid Id, TipoUsuario TipoUsuario)
        {
            TipoUsuario tipoUsuario = _tipoUsuario.TipoUsuario.Find(Id)!;

            if (tipoUsuario != null)
            {
                tipoUsuario.Titulo = tipoUsuario.Titulo;
            }

            _tipoUsuario.TipoUsuario.Update(tipoUsuario!);

            _tipoUsuario.SaveChanges();
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            return _tipoUsuario.TipoUsuario.FirstOrDefault(e => e.IdTipoUsuario == id)!;
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            _tipoUsuario.TipoUsuario.Add(tipoUsuario);

            _tipoUsuario.SaveChanges();
        }

        public void Deletar(Guid Id)
        {
            TipoUsuario tipoUsuario = _tipoUsuario.TipoUsuario.Find(Id)!;

            _tipoUsuario.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return _tipoUsuario.TipoUsuario.ToList();
        }
    }
}
