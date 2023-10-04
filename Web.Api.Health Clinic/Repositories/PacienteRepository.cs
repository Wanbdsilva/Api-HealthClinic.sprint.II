using Web.Api.Health_Clinic.Contexts;
using Web.Api.Health_Clinic.Domains;
using Web.Api.Health_Clinic.Interfaces;
using Web.Api.Health_Clinic.Utils;

namespace Web.Api.Health_Clinic.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealtContext _paciente;

        public PacienteRepository()
        {
            _paciente = new HealtContext();
        }
        public void Atualizar(Guid Id, Paciente paciente)
        {
            Paciente paciente1 = _paciente.Paciente.Find(Id)!;

            if (paciente != null)
            {
                _paciente.Paciente = _paciente.Paciente;
            }

            _paciente.Paciente.Update(paciente!);

            _paciente.SaveChanges();
        }

        public Paciente BuscarPorId(Guid id)
        {
            return _paciente.Paciente.FirstOrDefault(e => e.IdPaciente == id)!;
        }

        public void Cadastrar(Paciente paciente)
        {
            _paciente.Paciente.Add(paciente);

            _paciente.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
