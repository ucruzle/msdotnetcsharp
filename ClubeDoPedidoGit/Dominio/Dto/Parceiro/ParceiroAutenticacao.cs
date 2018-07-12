using System;

namespace Dominio.Dto.Parceiro
{
    public class ParceiroAutenticacao
    {
        public Guid TokenAtual { get; set; }
        public Guid NovoToken { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public byte[] SenhaCriptografada { get; set; }
    }
}
