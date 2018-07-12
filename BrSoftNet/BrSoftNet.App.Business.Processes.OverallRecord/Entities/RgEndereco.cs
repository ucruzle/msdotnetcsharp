using System;
using System.Data;
using System.Xml.Serialization;

namespace BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects
{
    [Serializable]
    public class RgEndereco
    {
        public int IdEmpr { get; set; }

        public int IdRg { get; set; }

        public string Endereco { get; set; }

        public string Nro { get; set; }

        public string Bairro { get; set; }

        public string Complemento { get; set; }

        public int CEP { get; set; }

        public int IdMunicipio { get; set; }

        public int CxPostal { get; set; }

        public string HomePage { get; set; }

        public string EMail { get; set; }

        public RgEndereco() { }

        public RgEndereco(DataRow _Row) 
        {
            IdEmpr = int.Parse(_Row["cod_empr"].ToString());
            IdRg = int.Parse(_Row["cod_rg"].ToString());
            Endereco = _Row["endereco"].ToString();
            Nro = _Row["nro_endereco"].ToString();
            Bairro = _Row["bairro"].ToString();
            Complemento = _Row["complemento"].ToString();
            CEP = int.Parse(_Row["cep"].ToString());
            IdMunicipio = int.Parse(_Row["cod_municipio"].ToString());
            CxPostal = int.Parse(_Row["cx_postal"].ToString());
            HomePage = _Row["home_page"].ToString();
            EMail = _Row["e_mail"].ToString();
        }

        public RgEndereco(int _IdEmpr, int _IdRg, string _Endereco, string _Nro, string _Bairro, string _Complemento, int _CEP, int _IdMunicipio, int _CxPostal, string _HomePage, string _EMail)
        {
            IdEmpr = _IdEmpr;
            IdRg = _IdRg;
            Endereco = _Endereco;
            Nro = _Nro;
            Bairro = _Bairro;
            Complemento = _Complemento;
            CEP = _CEP;
            IdMunicipio = _IdMunicipio;
            CxPostal = _CxPostal;
            HomePage = _HomePage;
            EMail = _EMail;
        }
    }
}
