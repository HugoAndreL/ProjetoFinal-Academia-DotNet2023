using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DesafioFinal.Server.Models
{
    /// <summary>
    ///     Histórico de cargo para auditoria
    /// </summary>
    public class HistoricoCargo
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        [Column(TypeName = "VARCHAR(50)")]
        public string Nome { get; set; }
    }
}