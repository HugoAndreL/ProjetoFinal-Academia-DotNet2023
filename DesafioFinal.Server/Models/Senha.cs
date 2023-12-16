using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DesafioFinal.Server.Models
{
    public class Senha
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int Numero { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        public string Prioridade { get; set; }
    }
}
