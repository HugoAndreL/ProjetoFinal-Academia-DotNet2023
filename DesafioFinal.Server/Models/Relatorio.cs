using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DesafioFinal.Server.Models
{
    /// <summary>
    ///     Relatórios do hopistal
    /// </summary>
    [Serializable]
    public class Relatorio
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int Id { get; set; }
        
        [JsonIgnore]
        [Column(TypeName = "VARCHAR(30)")]
        public string Nome { get; set; } = $"Relatório";

        [JsonIgnore]
        public string DataRelatorio { get; set; } = DateTime.Now
            .ToShortDateString();

        [Column(TypeName = "VARCHAR(10)")]
        public string TempoEspera { get; set; } = "00:30:00";

        public int TaxaUtilizacaoGuiche { get; set; }

        public int TaxaUtilizacaoTriagem { get; set; }

        public int TaxaUtilizacaoConsultorio { get; set; }

        public override string ToString()
        {
            return $"{TempoEspera}; {TaxaUtilizacaoGuiche}; {TaxaUtilizacaoTriagem}; {TaxaUtilizacaoConsultorio}";
        }
    }
}
