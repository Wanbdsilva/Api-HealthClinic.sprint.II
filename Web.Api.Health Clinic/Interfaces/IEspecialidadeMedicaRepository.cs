using Web.Api.Health_Clinic.Domains;

namespace Web.Api.Health_Clinic.Interfaces
{
    public interface IEspecialidadeMedicaRepository
    {
        void Cadastrar(EspecialidadeMedica especialidade);
        void Deletar(Guid Id);
        List<EspecialidadeMedica> Listar();
        EspecialidadeMedica BuscarPorId(Guid id);
        void Atualizar(Guid Id, EspecialidadeMedica especialidade);
    }
}
