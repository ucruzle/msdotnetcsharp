using Dominio.Dto.PlanoContratado;
using Dominio.Modelo;
using Regras.Validacao;

namespace Regras.Negocio
{
    public class RegistrarPlanoContratado : RouleFactory<RegistrarPlanoContratado>
    {
        public RegistrarPlanoContratado()
        {

        }

        public PlanoContratado RegistroNovaAssinaturaPlanoContratado(PlanoContratadoDto dto)
        {
            var contrato = new PlanoContratado();

            contrato.ParceiroID = ValidarId.CreateInstance.SetId("Parceiro", dto.ParceiroID);
            contrato.PlanoID = ValidarId.CreateInstance.SetId("Plano", dto.PlanoID);
            contrato.QuantidadeProdutosCadastrados = 0;
            contrato.QuantidadeProdutosPorPlano = dto.QuantidadeProdutosPorPlano;

            return contrato;
        }
    }
}
