using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Comum.Mensagens;
using Dominio.Dto.Usuario;
using Dominio.Modelo;
using Infraestrutura.Dao;

namespace Infraestrutura.Repositorio
{
    public class UsuarioRepositorio
    {
        // Campos
        private readonly ContextoDb _contexto;

        // Construtor
        public UsuarioRepositorio(ContextoDb contexto)
        {
            _contexto = contexto;
        }

        // Métodos
        public IEnumerable<Usuario> BuscaUsuarios()
        {
            return _contexto.UsuarioDb;
        }

        public Usuario AutenticaUsuario(UsuarioAutenticacao dto)
        {
            var usuarioAutenticado = _contexto.UsuarioDb.Where(usuario =>
                usuario.Email == dto.Email &&
                usuario.Senha == dto.SenhaCriptografada &&
                usuario.Ativo).FirstOrDefault();

            if (usuarioAutenticado == null)
                return usuarioAutenticado;


            _contexto.Entry(usuarioAutenticado).State = EntityState.Modified;
            _contexto.SaveChanges();

            return usuarioAutenticado;
        }

        public Usuario BuscaUsuarioPorID(int id)
        {
            return _contexto.UsuarioDb.Where(x => x.UsuarioID == id).FirstOrDefault();
        }

        public Usuario CadastrarUsuario(Usuario usuario)
        {
            var retorno = _contexto.UsuarioDb.Where(x => x.Email == usuario.Email).FirstOrDefault();
            if (retorno != null) return new Usuario();
            _contexto.UsuarioDb.Add(usuario);
            return usuario;
        }

        public string AlterarUsuario(Usuario usuario)
        {
            usuario.DataAlteracao = DateTime.Now;
            _contexto.Entry(usuario).State = EntityState.Modified;
            return MensagensGlobal.EdicaoSucesso;
        }

        public string DesativarUsuario(UsarioDesativado dto)
        {
            var usuario = _contexto.UsuarioDb.Where(x => x.Email == dto.Email &&
                x.Senha == dto.SenhaCriptografada).FirstOrDefault();
            usuario.DataAlteracao = DateTime.Now;
            usuario.Ativo = false;
            _contexto.Entry(usuario).State = EntityState.Modified;
            return MensagensGlobal.UsuarioDesativado;
        }

        public void Dispose()
        {
            if (_contexto != null)
            {
                _contexto.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
