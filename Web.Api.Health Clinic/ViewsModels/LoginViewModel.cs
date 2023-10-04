using System.ComponentModel.DataAnnotations;

namespace Web.Api.Health_Clinic.ViewsModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email obrigatorio!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatoria!")]
        public string? Senha { get; set; }
    }
}
