using Web.Api.Health_Clinic.Domains;

namespace Web.Api.Health_Clinic.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);
        Usuario BuscarPorId(Guid Id);
        Usuario BuscarPorEmailESenha(string email, string Senha);
        void Deletar(Guid Id);
        List<Clinica> Listar();
        void Atualizar(string email, string senha);
    }
}
