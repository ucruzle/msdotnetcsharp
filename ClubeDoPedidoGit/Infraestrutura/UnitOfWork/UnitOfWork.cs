using Infraestrutura.Dao;
using Infraestrutura.Repositorio;
using Infraestrutura.UnitOfWork.Interface;

namespace Infraestrutura.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        // Campos
        private readonly ContextoDb _contexto;
        private UsuarioRepositorio _usuarios;
        private EnderecoRepositorio _enderecos;
        private ParceiroRepositorio _parceiros;

        // Construtor
        public UnitOfWork(ContextoDb contexto)
        {
            _contexto = contexto;
        }

        // Propriedades
        public UsuarioRepositorio UsuarioRepositorio
        {
            get
            {
                if (_usuarios == null)
                {
                    _usuarios = new UsuarioRepositorio(_contexto);
                }
                return _usuarios;
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

        public ParceiroRepositorio ParceiroRepositorio {
            get
            {
                if (_parceiros == null)
                {
                    _parceiros = new ParceiroRepositorio(_contexto);
                }
                return _parceiros;
            }
        }


        // Métodos
        public void Commit()
        {
            _contexto.SaveChanges();
        }
    }
}
