using Dominio.Modelo;
using Infraestrutura.Dao;

namespace Infraestrutura.Repositorio
{
    public class PlanoContratadoRepositorio
    {
        // Campos
        private readonly ContextoDb _contexto;

        // Construtor
        public PlanoContratadoRepositorio(ContextoDb contexto)
        {
            _contexto = contexto;
        }

        // Métodos
        public PlanoContratado NovaAssinaturaPlano(PlanoContratado planoContratado)
        {
           return _contexto.PlanoContratadoDb.Add(planoContratado);
        }
    }

}
