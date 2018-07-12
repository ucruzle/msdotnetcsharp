using Infraestrutura.Dao;
using Infraestrutura.Repositorio;
using Infraestrutura.UnitOfWork.Interface;

namespace Infraestrutura.UnitOfWork
{
    public class UnitOfWorkParceiro : IUnitOfWork
    {
        // Campos
        private readonly ContextoDb _contexto;
        private ParceiroRepositorio _parceiros;
        private EnderecoRepositorio _enderecos;
        private PlanoContratadoRepositorio _planoContratado;
        private EnderecoVinculoRepositorio _enderecoVinculo;
        private TokenRepositorio _token;

        // Construtor
        public UnitOfWorkParceiro(ContextoDb contexto)
        {
            _contexto = contexto;
        }

        // Propriedades
        public ParceiroRepositorio ParceiroRepositorio
        {
            get
            {
                if (_parceiros == null)
                {
                    _parceiros = new ParceiroRepositorio(_contexto);
                }
                return _parceiros;
            }
        }

        public EnderecoRepositorio EnderecoRepositorio
        {
            get
            {
                if (_enderecos == null)
                {
                    _enderecos = new EnderecoRepositorio(_contexto);
                }
                return _enderecos;
            }
        }

        public PlanoContratadoRepositorio PlanoContratadoRepositorio
        {
            get
            {
                if (_planoContratado == null)
                {
                    _planoContratado = new PlanoContratadoRepositorio(_contexto);
                }
                return _planoContratado;
            }
        }

        public EnderecoVinculoRepositorio EnderecoVinculoRepositorio
        {
            get
            {
                if (_enderecoVinculo == null)
                {
                    _enderecoVinculo = new EnderecoVinculoRepositorio(_contexto);
                }
                return _enderecoVinculo;
            }
        }

        public TokenRepositorio TokenRepositorio
        {
            get
            {
                if (_token == null)
                {
                    _token = new TokenRepositorio(_contexto);
                }
                return _token;
            }
        }

        // Métodos
        public void Commit()
        {
            _contexto.SaveChanges();
        }
    }
}
