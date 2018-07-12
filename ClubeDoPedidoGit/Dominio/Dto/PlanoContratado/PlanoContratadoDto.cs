namespace Dominio.Dto.PlanoContratado
{
    public class PlanoContratadoDto
    {
        public int PlanoContratadoID { get; set; }
        public int PlanoID { get; set; }
        public int ParceiroID { get; set; }
        public int QuantidadeProdutosPorPlano { get; set; }
        public int QuantidadeProdutosCadastrados { get; set; }
    }
}
