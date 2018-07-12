using System;
using Dominio.Dto.Parceiro;
using Dominio.Modelo;
using Regras.Validacao;

namespace Regras.Negocio
{
    public class RegistrarParceiro : RouleFactory<RegistrarParceiro>
    {
        public RegistrarParceiro() { }

        public Parceiro RegistroNovoParceiro(ParceiroDto dto)
        {
            var parceiro = new Parceiro();

            parceiro.NomeFantasia = ValidarNome.CreateInstance.SetNome(dto.NomeFantasia);
            //Implementar parte do cpf
            parceiro.RamoAtividadeID = 3;
            parceiro.Email = ValidarEmail.CreateInstance.SetEmail(dto.Email);
            parceiro.Senha = ValidarSenhaCadastro.CreateInstance.SetSenhaCadastro(dto.Senha, dto.ConfirmaSenha);
            parceiro.Telefone = ValidarTelefone.CreateInstance.SetFoneFixo(dto.Telefone);
            parceiro.Celular = ValidarTelefone.CreateInstance.SetFoneMovel(dto.Celular);
            parceiro.DataInclusao = DateTime.Now;
            parceiro.Ativo = true;

            return parceiro;
        }
    }
}
