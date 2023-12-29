using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DesafioFinal.Server.Models
{
    /// <summary>
    ///     Areas de Atendimento do hospital
    /// </summary>
    public class AreaAtendimento
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string Nome { get; set; }

        public int TipoAreaAtendimentoId { get; set; }
        [JsonIgnore]
        public virtual TipoAreaAtendimento? TipoAreaAtendimento { get; set; }
    }
}
