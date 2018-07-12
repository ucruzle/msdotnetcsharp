using System;
using System.Data;
using System.Xml.Serialization;

namespace BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects
{
    [Serializable]
    public class RgTelefone
    {
        public int IdEmpr { get; set; }

        public int IdRg { get; set; }

        public int SeqTel { get; set; }

        public int IdTipoFone { get; set; }

        public string DDDFone { get; set; }

        public string NroFone { get; set; }

        public string Contato { get; set; }

        public string EMail { get; set; }

        public string Principal { get; set; }

        public RgTelefone() { }

        public RgTelefone(DataRow _Row)
        {
            IdEmpr = int.Parse(_Row["cod_empr"].ToString());
            IdRg = int.Parse(_Row["cod_rg"].ToString());
            SeqTel = int.Parse(_Row["seq_tel"].ToString());
            IdTipoFone = int.Parse(_Row["cod_tipo_fone"].ToString());
            DDDFone = _Row["ddd_fone"].ToString();
            NroFone = _Row["numero_fone"].ToString();
            Contato = _Row["contato"].ToString();
            EMail = _Row["e_mail"].ToString();
            Principal = _Row["principal"].ToString();
        }

        public RgTelefone(int _IdEmpr, int _IdRg, int _SeqTel, int _IdTipoFone, string _DDDFone, string _NroFone, string _Contato, string _EMail, string _Principal)
        {
            IdEmpr = _IdEmpr;
            IdRg = _IdRg;
            SeqTel = _SeqTel;
            IdTipoFone = _IdTipoFone;
            DDDFone = _DDDFone;
            NroFone = _NroFone;
            Contato = _Contato;
            EMail = _EMail;
            Principal = _Principal;
        }
    }
}
