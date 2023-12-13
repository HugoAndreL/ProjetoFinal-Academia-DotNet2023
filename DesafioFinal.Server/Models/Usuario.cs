using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DesafioFinal.Server.Models
{
    /// <summary>
    ///     Trabalhadores (Atendentes, Enfermeiros(as), Médicos(as)) do hospital em questão
    /// </summary>
    public class Usuario
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigátorio!")]
        [Column(TypeName = "VARCHAR(50)")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatorio!")]
        [Column(TypeName = "VARCHAR(80)")]
        public string Email { get; set; }

        public int? CargoId { get; set; }
        [JsonIgnore]
        [Browsable(false)]
        public virtual Cargos? Cargo { get; set; }
    }
}
