using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesafioFinal.Server.Models
{
    public class TipoAreaAtendimento
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int COD { get; }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Nome { get; set; }
    }
}
