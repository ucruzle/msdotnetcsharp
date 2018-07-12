using System;
using Dominio.Dto.Endereco;
using Dominio.Modelo;
using Regras.Validacao;

namespace Regras.Negocio
{
    public class RegistrarEndereco : RouleFactory<RegistrarEndereco>
    {
        public RegistrarEndereco()
        {

        }

        public Endereco RegistroNovoEndereco(EnderecoDto dto)
        {
            var endereco = new Endereco();

            endereco.Logradouro = ValidarLogradouro.CreateInstance.SetLogradouro(dto.Logradouro);
            endereco.Numero = ValidarNumero.CreateInstance.SetNumero(dto.Numero);
            endereco.Complemento = ValidarComplemento.CreateInstance.SetComplemento(dto.Complemento);
            endereco.Bairro = ValidarBairro.CreateInstance.SetBairro(dto.Bairro);
            endereco.Cidade = ValidarCidade.CreateInstance.SetCidade(dto.Cidade);
            endereco.Cep = ValidarCep.CreateInstance.SetCep(dto.Cep);
            endereco.Uf = ValidarUF.CreateInstance.SetUF(dto.Uf);
            endereco.PontoReferencia = dto.PontoReferencia;
            endereco.TipoEnderecoID = dto.TipoEnderecoID;
            endereco.DataInclusao = DateTime.Now;
            endereco.Ativo = true;

            return endereco;
        }
    }
}
