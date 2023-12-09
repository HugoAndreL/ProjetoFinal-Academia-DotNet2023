namespace DesafioFinal.Server.Models
{
    public class SenhasConsultorios
    {
        public int SenhaId { get; set; }
        public virtual Senhas Senha { get; set; }

        public int ConsultorioId { get; set; }
        public virtual Consultorio Consultorio { get; set; }
    }
}
