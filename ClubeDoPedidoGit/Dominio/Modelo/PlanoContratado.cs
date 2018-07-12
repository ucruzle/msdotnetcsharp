namespace Dominio.Modelo
{
    public class PlanoContratado
    {
        // Propriedades
        public int PlanoContratadoID { get; set; }
        public int PlanoID { get; set; }
        public int ParceiroID { get; set; }
        public int QuantidadeProdutosPorPlano { get; set; }
        public int QuantidadeProdutosCadastrados { get; set; }

        // Relacionamentos
        public virtual Plano Plano { get; set; }
        public virtual Parceiro Parceiro { get; set; }

        // Construtor
        public PlanoContratado() { }
    }
}
