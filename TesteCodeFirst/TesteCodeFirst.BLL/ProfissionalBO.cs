using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using TesteCodeFirst.Entities;
using TesteCodeFirst.DAL;

namespace TesteCodeFirst.BLL
{
    public class ProfissionalBO
    {
        [Dependency]
        public ProfissionalDAO DAO { get; set; }

        public List<ResumoDadosProfissional> ListarResumoProfissionais()
        {
            return DAO.ListarResumoProfissionais();
        }

        public Profissional ObterDadosProfissional(int id)
        {
            Profissional profissional =
                DAO.FindByPrimaryKey(id);
            if (profissional == null)
            {
                throw new Exception(
                    "Foi informado um Id de Profissional inválido.");
            }
            return profissional;
        }

        public bool ValidarDadosProfissional(
            Profissional profissional,
            out string CampoInconsistente,
            out string DescricaoInconsistencia)
        {
            CampoInconsistente = null;
            DescricaoInconsistencia = null;

            if (!ValidarCPF(profissional.CPF))
            {
                CampoInconsistente = "CPF";
                DescricaoInconsistencia = "CPF inválido.";
                return false;
            }

            if (DAO.CPFJaExistente(profissional.Id.HasValue ?
                     profissional.Id.Value : 0,
                     profissional.CPF))
            {
                CampoInconsistente = "CPF";
                DescricaoInconsistencia =
                    "CPF já cadastrado anteriormente.";
                return false;
            }

            return true;
        }

        public void IncluirDadosProfissional(
            Profissional profissional)
        {
            DAO.Insert(profissional);
            DAO.UnitOfWork.Commit();
        }

        public void AtualizarDadosProfissional(
            Profissional profissional)
        {
            DAO.Update(profissional);
            DAO.UnitOfWork.Commit();
        }

        public void ExcluirProfissional(int id)
        {
            Profissional profissional =
                DAO.FindByPrimaryKey(id);
            DAO.Delete(profissional);
            DAO.UnitOfWork.Commit();
        }

        private bool ValidarCPF(string vrCPF)
        {
            string valor = vrCPF.Replace(".", "");
            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(
                  valor[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }

            else
            {
                if (numeros[9] != 11 - resultado)
                    return false;
            }

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];
            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
            {
                if (numeros[10] != 11 - resultado)
                    return false;
            }

            return true;
        }
    }
}