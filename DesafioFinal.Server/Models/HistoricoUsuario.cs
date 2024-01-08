using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesafioFinal.Server.Models
{
    /// <summary>
    ///     Histórico de Usuario para fins de auditoria
    /// </summary>
    public class HistoricoUsuario
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
    }
}