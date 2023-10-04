using Web.Api.Health_Clinic.Domains;

namespace Web.Api.Health_Clinic.Interfaces
{
    public interface IComentarioRepository
    {
        void Cadastrar(Comentario comentario);
        void Deletar(Guid id);
        List<Comentario> Listar();
        Comentario BuscarPorId(Guid id);
    }
}
