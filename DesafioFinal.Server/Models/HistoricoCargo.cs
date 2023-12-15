using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesafioFinal.Server.Models
{
    public class HistoricoCargo
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Nome { get; set; }
    }
}
