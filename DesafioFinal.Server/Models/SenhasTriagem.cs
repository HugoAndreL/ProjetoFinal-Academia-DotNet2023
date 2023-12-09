namespace DesafioFinal.Server.Models
{
    public class SenhasTriagem
    {
        public int SenhaId { get; set; }
        public virtual Senhas Senha { get; set; }

        public int TriagemId { get; set; }
        public virtual Triagem Triagem { get; set; }
    }
}
