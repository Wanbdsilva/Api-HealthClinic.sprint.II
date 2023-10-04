using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Api.Health_Clinic.Domains
{
    [Table(nameof(Clinica))]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome da clínica é obrigatório !")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Endereço da clínica é obrigatório !")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Razão social da clínica é obrigatório !")]
        public string? RazaoSocial { get; set; }

        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "CNPJ é obrigatorio")]
        [StringLength(14)]
        public string? CNPJ { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Horario de funcionamento é obrigatoria!")]
        public DateTime HorarioFuncionamento { get; set; }
    }
}
