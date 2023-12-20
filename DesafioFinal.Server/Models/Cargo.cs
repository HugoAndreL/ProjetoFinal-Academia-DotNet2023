﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        [Column(TypeName = "VARCHAR(50)")]
        public string Nome { get; set; }

        [JsonIgnore]
        public virtual ICollection<Usuario>? Usuarios { get; set; }
    }
}
