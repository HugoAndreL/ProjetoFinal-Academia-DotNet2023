using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesafioFinal.Server.Models
{
    public class Cargos
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Nome { get; set; }

        [JsonIgnore]
        [Browsable(false)]
        public virtual ICollection<Usuario>? Usuarios { get; set; }
    }
}
