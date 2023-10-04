using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Api.Health_Clinic.Domains
{
    [Table(nameof(Medico))]
    [Index(nameof(CRM), IsUnique = true)]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do médico é obrigatório !")]
        public string? Nome { get; set; }

        [Column(TypeName = "CHAR(12)")]
        [Required(ErrorMessage = "O CRM é obrigatorio")]
        [StringLength(12)]
        public string? CRM { get; set; }

        [Required(ErrorMessage = "A especialidade do médico é obrigatória !")]
        public Guid IdEspecialidadeMedica { get; set; }

        [ForeignKey(nameof(IdEspecialidadeMedica))]
        public EspecialidadeMedica? Especialidade { get; set; }

        [Required(ErrorMessage = "Informe o Usuario !")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
