using Web.Api.Health_Clinic.Domains;

namespace Web.Api.Health_Clinic.Interfaces
{
    public interface ITipoUsuario
    {
        void Cadastrar(TipoUsuario tipoUsuario);
        void Deletar(Guid Id);
        List<TipoUsuario> Listar();
        TipoUsuario BuscarPorId(Guid id);
        void Atualizar(Guid Id, TipoUsuario TipoUsuario);
    }
}
