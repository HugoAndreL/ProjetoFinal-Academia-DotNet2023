namespace DesafioFinal.Server.Models
{
    public class SenhasGuiches
    {
        public int SenhaId { get; set; }
        public virtual Senhas Senha { get; set; }

        public int GuicheId { get; set; }
        public virtual Guiche Guiche{ get; set; }
    }
}
