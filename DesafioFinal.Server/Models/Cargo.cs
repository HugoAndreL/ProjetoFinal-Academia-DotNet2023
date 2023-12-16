using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesafioFinal.Server.Models
{
    /// <summary>
    ///     Cargos do hospital em questão
    /// </summary>
    public class Cargo
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Nome { get; set; }

        [JsonIgnore]
        public virtual ICollection<Usuario>? Usuarios { get; set; }
    }
}
