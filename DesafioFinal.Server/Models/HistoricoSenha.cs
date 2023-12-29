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

        [Required]
        [JsonIgnore]
        public int Ordem { get; set; }

        [Required]
        [JsonIgnore]
        public int Numero { get; set; }

        public int Prioridade { get; set; }
    }
}
