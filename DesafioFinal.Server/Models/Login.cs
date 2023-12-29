using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DesafioFinal.Server.Models
{
    public class Login
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string Username { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        public string Password { get; set; }

        [JsonIgnore]
        public virtual Usuario? Usuario { get; set; }
    }
}
