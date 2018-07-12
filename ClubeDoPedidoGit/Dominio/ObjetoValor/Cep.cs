﻿using System;
using Comum.Auxiliares;

namespace Dominio.ObjetoValor
{
    public class Cep
    {
        //Campos
        public Int64? CepCod { get; private set; }
        public const int CepMaxLength = 8;

        //Construtor
        protected Cep() { }
        public Cep(string cep)
        {
            Guard.ForNullOrEmptyDefaultMessage("CEP", cep);
            cep = TextoHelper.GetNumeros(cep);
            Guard.StringLength("CEP", CepMaxLength, cep);
            try
            {
                CepCod = Convert.ToInt64(cep);
            }
            catch (Exception)
            {
                throw new Exception("Cep inválido: " + cep);
            }
        }

        //Metodos
        public bool Vazio()
        {
            return !CepCod.HasValue;
        }
        public string GetCepFormatado()
        {
            if (CepCod == null)
                return "";

            var cep = CepCod.ToString();

            while (cep.Length < 8)
                cep = "0" + cep;

            return cep.Substring(0, 5) + "-" + cep.Substring(5);
        }
    }
}
