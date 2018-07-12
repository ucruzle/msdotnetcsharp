using Dominio.Dto.Endereco;
using Dominio.Dto.PlanoContratado;

namespace Dominio.Dto.Parceiro
{
    public class ParceiroDto
    {
        public int ParceiroID { get; set; }
        public string NomeFantasia { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmaSenha { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public EnderecoDto Endereco { get; set; }
        public PlanoContratadoDto PlanoContratado { get; set; }
    }
}
