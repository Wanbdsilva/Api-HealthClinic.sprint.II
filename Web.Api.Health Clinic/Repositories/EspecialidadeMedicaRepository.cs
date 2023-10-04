using Web.Api.Health_Clinic.Contexts;
using Web.Api.Health_Clinic.Domains;
using Web.Api.Health_Clinic.Interfaces;

namespace Web.Api.Health_Clinic.Repositories
{
    public class EspecialidadeMedicaRepository : IEspecialidadeMedicaRepository
    {
        private readonly HealtContext _especialidadeMedica;

        public EspecialidadeMedicaRepository()
        {
            _especialidadeMedica = new HealtContext();
        }
        public void Atualizar(Guid Id, EspecialidadeMedica especialidade)
        {
            EspecialidadeMedica especialidadeMedica = _especialidadeMedica.EspecialidadeMedica.Find(Id)!;

            if (especialidade != null)
            {
                especialidade.Especialidade = especialidade.Especialidade;
            }

            _especialidadeMedica.EspecialidadeMedica.Update(especialidade!);

            _especialidadeMedica.SaveChanges();
        }

        public EspecialidadeMedica BuscarPorId(Guid id)
        {
            return _especialidadeMedica.EspecialidadeMedica.FirstOrDefault(e => e.IdEspecialidadeMedica == id)!;
        }

        public void Cadastrar(EspecialidadeMedica especialidade)
        {
            _especialidadeMedica.EspecialidadeMedica.Add(especialidade);

            _especialidadeMedica.SaveChanges();
        }

        public void Deletar(Guid Id)
        {
            EspecialidadeMedica especialidade = _especialidadeMedica.EspecialidadeMedica.Find(Id)!;

            _especialidadeMedica.SaveChanges();
        }

        public List<EspecialidadeMedica> Listar()
        {
            try
            {
                return _especialidadeMedica.EspecialidadeMedica.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        } 
    }
}
