using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesafioFinal.Server.Models
{
    /// <summary>
    ///     Permissões do sitema
    /// </summary>
    public class Funcionalidade
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public int CargoId { get; set; }
        [JsonIgnore]
        public virtual Cargo? Cargo { get; set; }
    }
}