using System;
using Comum.Mensagens;
using Dominio.ObjetoValor;

namespace Regras.Validacao
{
    public class ValidarCep : RouleFactory<ValidarCep>
    {
        public ValidarCep() { }

        public string SetCep(string cep)
        {
            var cepNovo = new Cep(cep);
            if (cepNovo.Vazio())
                throw new Exception(MensagensValidacao.ObrigatorioCep);
            return cepNovo.CepCod.ToString();
        }
    }
}
