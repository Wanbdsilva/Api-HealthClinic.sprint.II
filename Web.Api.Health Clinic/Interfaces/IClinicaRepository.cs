using Web.Api.Health_Clinic.Domains;

namespace Web.Api.Health_Clinic.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica clinica);
        void Deletar(Guid id);
        List<Clinica> Listar();
        Clinica BuscarPorId(Guid id);
        void Atualizar(Guid id, Clinica clinica);
    }
}
