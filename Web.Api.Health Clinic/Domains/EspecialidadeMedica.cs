using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Api.Health_Clinic.Domains
{
    [Table(nameof(EspecialidadeMedica))]
    public class EspecialidadeMedica
    {
        [Key]
        public Guid IdEspecialidadeMedica { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A especialidade do médico é obrigatório !")]
        public string? Especialidade { get; set; }
    }
}
