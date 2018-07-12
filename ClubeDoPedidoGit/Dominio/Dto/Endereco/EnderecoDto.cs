using System;

namespace Dominio.Dto.Endereco
{
    public class EnderecoDto
    {
        public int TipoEnderecoID { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public string PontoReferencia { get; set; }
        public DateTime DataInclusao { get; set; }
        public bool Ativo { get; set; }
    }
}
