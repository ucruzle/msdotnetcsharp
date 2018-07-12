using System;

namespace Dominio.Dto.Usuario
{
    public class UsuarioAutenticacao
    {
        public Guid TokenAtual { get; set; }
        public Guid NovoToken{ get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public byte[] SenhaCriptografada { get; set; }
    }
}
