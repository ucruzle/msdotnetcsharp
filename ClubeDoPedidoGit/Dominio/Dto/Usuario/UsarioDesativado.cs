namespace Dominio.Dto.Usuario
{
    public class UsarioDesativado
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public byte[] SenhaCriptografada { get; set; }
    }
}
