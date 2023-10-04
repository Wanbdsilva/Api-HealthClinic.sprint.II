using Web.Api.Health_Clinic.Contexts;
using Web.Api.Health_Clinic.Domains;
using Web.Api.Health_Clinic.Interfaces;

namespace Web.Api.Health_Clinic.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealtContext _medico;

        public MedicoRepository()
        {
            _medico = new HealtContext();
        }
        public void Atualizar(Guid Id, Medico medico)
        {
            Medico medico1 = _medico.Medico.Find(Id)!;

            if (medico != null)
            {
                medico.IdMedico = medico.IdMedico ;
            }

            _medico.Medico.Update(medico!);

            _medico.SaveChanges();
        }

        public Medico BuscarPorId(Guid id)
        {
            return _medico.Medico.FirstOrDefault(e => e.IdMedico == id)!;
        }

        public void Cadastrar(Medico medico)
        {
            _medico.Medico.Add(medico);

            _medico.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Medico medico = _medico.Medico.Find(id)!;

            _medico.SaveChanges();
        }

        public List<Medico> Listar()
        {
            try
            {
                return _medico.Medico.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
