using System;
using Comum.Mensagens;
using Dominio.ObjetoValor;

namespace Regras.Validacao
{
    public class ValidarTelefone : RouleFactory<ValidarTelefone>
    {
        public ValidarTelefone() { }

        public string SetFoneFixo(string telefone)
        {
            if (telefone == null) throw new Exception(MensagensValidacao.ObrigatorioTelefone);
            var resultado = new Telefone(telefone.Substring(0, 2), telefone.Substring(2));
            return resultado.GetTelefoneCompleto();
        }

        public string SetFoneMovel(string celular)
        {
            if (celular == null) throw new Exception(MensagensValidacao.ObrigatorioCelular);
            var resultado = new Telefone(celular.Substring(0, 2), celular.Substring(2));
            return resultado.GetTelefoneCompleto();
        }
    }
}
