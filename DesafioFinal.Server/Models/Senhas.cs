using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioFinal.Server.Models
{
    /// <summary>
    ///     Senhas do hospital
    /// </summary>
    public class Senhas
    {
        [Key]
        [Required]
        public int Ordem { get; set; }

        public int Senha { get; set; }
        
        [Required]
        [Column(TypeName = "VARCHAR(20)")]
        public string GuiTriCon { get; set; } = "GUI";
        
        // 1 - Normal, 2 - Prioritario
        [Required(ErrorMessage = "Prioridade é obrigátorio! Tente novamente.")]
        public int Prioridade { get; set; }
    }
}
