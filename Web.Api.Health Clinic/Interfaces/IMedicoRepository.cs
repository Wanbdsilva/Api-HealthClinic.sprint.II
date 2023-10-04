using Web.Api.Health_Clinic.Domains;

namespace Web.Api.Health_Clinic.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medico);
        void Atualizar(Guid Id, Medico medico);
        void Deletar(Guid id);
        List<Medico> Listar();
        Medico BuscarPorId(Guid id);
    }
}
