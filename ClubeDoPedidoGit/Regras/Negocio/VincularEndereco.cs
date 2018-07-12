using Dominio.Modelo;
using Regras.Validacao;

namespace Regras.Negocio
{
    public class VincularEndereco : RouleFactory<VincularEndereco>
    {
        public VincularEndereco()
        {

        }

        public EnderecoVinculo MapVinculo(int vinculoID, int enderecoID, int tipoVinculado)
        {
            var vinculo = new EnderecoVinculo();

            vinculo.VinculoID = ValidarId.CreateInstance.SetId("Vinculo", vinculoID);
            vinculo.EnderecoID = ValidarId.CreateInstance.SetId("Endereco", enderecoID);
            vinculo.TipoVinculado = ValidarId.CreateInstance.SetId("Tipo Vinculado", tipoVinculado);

            return vinculo;
        }
    }
}
