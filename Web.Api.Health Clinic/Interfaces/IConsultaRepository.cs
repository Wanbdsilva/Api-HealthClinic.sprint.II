using Web.Api.Health_Clinic.Domains;

namespace Web.Api.Health_Clinic.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consulta);
        void Deletar(Guid id);
        List<Consulta> Listar();
        Consulta BuscarPorId(Guid id);
        void Atualizar(Guid id, Consulta consulta);
    }
}
