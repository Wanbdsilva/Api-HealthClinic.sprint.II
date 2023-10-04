using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Api.Health_Clinic.Domains
{
    [Table(nameof(Paciente))]
    [Index(nameof(CPF), IsUnique = true)]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do paciente é obrigatório !")]
        public string? Nome { get; set; }

        [Column(TypeName = "CHAR(11)")]
        [Required(ErrorMessage = "O numero do CPF é obrigatório")]
        [StringLength(11)]
        public string? CPF { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Informe pelo menos um telefone para contato !")]
        public string? Telefone { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data de nascimento é obrigatoria!")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Informe o Usuario !")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
