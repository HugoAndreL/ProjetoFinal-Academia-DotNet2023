using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesafioFinal.Server.Models
{
    /// <summary>
    ///     Histórico de senha para ficar no display
    /// </summary>
    public class HistoricoSenha
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        public int Prioridade { get; set; }
    }
}
