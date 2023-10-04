using Web.Api.Health_Clinic.Domains;

namespace Web.Api.Health_Clinic.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente paciente);
        void Deletar(Guid id);
        void Atualizar(Guid Id, Paciente paciente);
        Paciente BuscarPorId(Guid id);
    }
}
