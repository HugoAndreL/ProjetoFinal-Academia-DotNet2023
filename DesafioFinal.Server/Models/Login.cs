using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DesafioFinal.Server.Models
{
    /// <summary>
    ///     Todos os logins dos usuarios 
    /// </summary>
    public class Login
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int Id { get; set; }
        
        [Column(TypeName = "VARCHAR(50)")]
        public string Username { get; set; }

        [Column(TypeName = "VARCHAR(35)")]
        public string Password { get; set; }

        [JsonIgnore]
        public virtual Usuario? Usuario { get; set; }

        [JsonIgnore]
        public string? Token { get; set; }

        public int? AaId { get; set; }
        [JsonIgnore]
        public virtual AreaAtendimento? AreaAtendimento { get; set; }
    }
}
