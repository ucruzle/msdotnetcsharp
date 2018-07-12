using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Comum.Mensagens;
using Dominio.Dto.Parceiro;
using Dominio.Modelo;
using Infraestrutura.Dao;

namespace Infraestrutura.Repositorio
{
    public class ParceiroRepositorio
    {
        // Campos
        private readonly ContextoDb _contexto;

        // Construtor
        public ParceiroRepositorio(ContextoDb contexto)
        {
            _contexto = contexto;
        }

        // Métodos
        public IEnumerable<Parceiro> BuscaParceiros()
        {
            return _contexto.ParceiroDb;
        }

        public Parceiro BuscaParceiroPorID(int id)
        {
            return _contexto.ParceiroDb.Where(x => x.ParceiroID == id).FirstOrDefault();
        }

        public Parceiro AutenticaParceiro(ParceiroAutenticacao dto)
        {
            var parceiroAutenticado = _contexto.ParceiroDb.Where(parceiro =>
                parceiro.Email == dto.Email &&
                parceiro.Senha == dto.SenhaCriptografada &&
                parceiro.Ativo).FirstOrDefault();

            if (parceiroAutenticado == null)
                return parceiroAutenticado;

            _contexto.Entry(parceiroAutenticado).State = EntityState.Modified;
            _contexto.SaveChanges();

            return parceiroAutenticado;
        }

        public Parceiro CadastrarParceiro(Parceiro parceiro)
        {
            var retorno = _contexto.ParceiroDb.Where(x => x.Email == parceiro.Email).FirstOrDefault();

            if (retorno != null)
                throw new Exception(MensagensGlobal.ParceiroEmailDuplicado);

            _contexto.ParceiroDb.Add(parceiro);
            return parceiro;
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
