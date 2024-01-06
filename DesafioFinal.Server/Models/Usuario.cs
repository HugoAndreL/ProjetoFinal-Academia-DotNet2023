using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DesafioFinal.Server.Models
{
    /// <summary>
    ///     Trabalhadores (Atendentes, Enfermeiros(as), Médicos(as)) do hospital
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
        [EmailAddress]
        [Column(TypeName = "VARCHAR(80)")]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR(35)")]
        [JsonIgnore]
        public string? Senha { get; set; }

        public int? CargoId { get; set; }
        [JsonIgnore]
        public virtual Cargo? Cargo { get; set; }
        
        [JsonIgnore]
        public int LoginId { get; set; }
        [JsonIgnore]
        public virtual Login? Login { get; set; }
    }
}
