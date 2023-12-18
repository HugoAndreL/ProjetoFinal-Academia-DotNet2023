using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesafioFinal.Server.Models
{
    public class HistoricoSenha
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        [JsonIgnore]
        public int Ordem { get; set; }

        [Required]
        [JsonIgnore]
        public int Numero { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        public string Prioridade { get; set; }
    }
}
