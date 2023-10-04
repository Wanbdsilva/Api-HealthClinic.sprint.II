using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Api.Health_Clinic.Domains
{
    [Table(nameof(Comentario))]
    public class Comentario
    {
        [Key]
        public Guid IdComentario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Adicione um comentario sobre seu atendimento !")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Informe a consulta !")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }

        [Required(ErrorMessage = "Informe o paciente !")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }
        
        [Column(TypeName = "BIT")]
        [Required]
        public bool Exibe { get; set; }
    }
}
