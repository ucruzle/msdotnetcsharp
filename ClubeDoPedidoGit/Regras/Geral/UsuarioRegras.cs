using System;
using Dominio.Dto.Usuario;
using Dominio.Enum;
using Dominio.Modelo;
using Regras.Validacao;

namespace Regras.Geral
{
    public class UsuarioRegras : RouleFactory<UsuarioRegras> 
    {
        // Construtor
        public UsuarioRegras()
        {

        }

        // Regras
        public UsuarioAutenticacao AltenticacaoUsuario(UsuarioAutenticacao dto)
        {
            var usuario = new Usuario();

            dto.Email = ValidarEmail.CreateInstance.SetEmail(dto.Email);
            dto.SenhaCriptografada = ValidarSenha.CreateInstance.SetSenha(dto.Senha);
            dto.TokenAtual = ValidarToken.CreateInstance.SetToken(dto.TokenAtual);
            dto.NovoToken = TokenRegras.CreateInstance.GerarNovoToken();
            return dto;
        }

        public Usuario CadastroNovoUsuarioMobile(UsuarioMobile dto)
        {
            var usuario = new Usuario();

            usuario.Nome = ValidarNome.CreateInstance.SetNome(dto.Nome);
            usuario.Senha = ValidarSenhaCadastro.CreateInstance.SetSenhaCadastro(dto.Senha, dto.ConfirmaSenha);
            usuario.Celular = ValidarTelefone.CreateInstance.SetFoneMovel(dto.Celular);
            usuario.Email = ValidarEmail.CreateInstance.SetEmail(dto.Email);
            usuario.TipoUsuarioID = (int)TipoUsuario.Movel;
            usuario.DataInclusao =  DateTime.Now;
            usuario.Ativo = true;

            return usuario;
        }

        public Usuario CadastroNovoUsuarioParceiro(UsuarioParceiro dto)
        {
            var usuario = new Usuario();

            usuario.Nome = ValidarNome.CreateInstance.SetNome(dto.Nome);
            usuario.Senha = ValidarSenhaCadastro.CreateInstance.SetSenhaCadastro(dto.Senha, dto.ConfirmaSenha);
            usuario.Celular = dto.Celular != null ? ValidarTelefone.CreateInstance.SetFoneMovel(dto.Celular) : string.Empty;
            usuario.Celular = ValidarTelefone.CreateInstance.SetFoneFixo(dto.Telefone);
            usuario.Email = ValidarEmail.CreateInstance.SetEmail(dto.Email);
            usuario.TipoUsuarioID = (int)TipoUsuario.Parceiro;
            usuario.DataInclusao = DateTime.Now;
            usuario.Ativo = false;

            return usuario;
        }

        public UsarioDesativado DesativarUsuario(UsarioDesativado dto)
        {
            dto.Email = ValidarEmail.CreateInstance.SetEmail(dto.Email);
            dto.SenhaCriptografada = ValidarSenha.CreateInstance.SetSenha(dto.Senha);
            return dto;
        }
    }
}
