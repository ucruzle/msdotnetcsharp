using BrSoftNet.App.Business.Processes.OverallRecord.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSoftNet.App.UI.Win.OverallRecord.DataMaintenance
{
    [Serializable]
    public class OverallRecordServiceHelper : MappingFactory<OverallRecordServiceHelper>
    {
        public RegistroGeralProcessMapping RetornaMapaDadosRegistroGeral(RgRegGeral _RgRegGeral, RgEndereco _RgEndereco, List<RgTelefone> _RgTelefoneCollection, List<RgRegGeralNatureza> _RgRegGeralNaturezaCollection, RgFisicaJuridica _RgFisicaJuridica) 
        {
            List<RgRegGeral> _RgRegGerais = new List<RgRegGeral>();
            List<RgEndereco> _RgEnderecos = new List<RgEndereco>();
            List<RgTelefone> _RgTelefones = new List<RgTelefone>();
            List<RgRegGeralNatureza> _RgRegGeralNaturezas = new List<RgRegGeralNatureza>();
            List<RgFisicaJuridica> _RgFisicasJuridicas = new List<RgFisicaJuridica>();
            RegistroGeralProcessMapping _RegistroGeralProcessMapping = null;

            _RgRegGerais.Add(new RgRegGeral(
                _RgRegGeral.IdEmpr,
                _RgRegGeral.IdRg,
                _RgRegGeral.RazaoSocial,
                _RgRegGeral.TipoRg,
                _RgRegGeral.IdStatus,
                _RgRegGeral.DataHora != DateTime.Parse("01/01/0001 00:00:00") ? _RgRegGeral.DataHora.ToString() : "01/01/0001 00:00:00",
                _RgRegGeral.Usuario,
                _RgRegGeral.NomeFantasia,
                _RgRegGeral.OptanteSimples));

            _RgEnderecos.Add(new RgEndereco(
                _RgEndereco.IdEmpr,
                _RgEndereco.IdRg,
                _RgEndereco.Endereco,
                _RgEndereco.Nro,
                _RgEndereco.Bairro,
                _RgEndereco.Complemento,
                _RgEndereco.CEP,
                _RgEndereco.IdMunicipio,
                _RgEndereco.CxPostal,
                _RgEndereco.HomePage,
                _RgEndereco.EMail));

            foreach (RgTelefone _RgTelefone in _RgTelefoneCollection)
            {
                _RgTelefones.Add(new RgTelefone(
                    _RgTelefone.IdEmpr,
                    _RgTelefone.IdRg,
                    _RgTelefone.SeqTel,
                    _RgTelefone.IdTipoFone,
                    _RgTelefone.DDDFone,
                    _RgTelefone.NroFone,
                    _RgTelefone.Contato,
                    _RgTelefone.EMail,
                    _RgTelefone.Principal));
            }

            foreach (RgRegGeralNatureza _RgRegGeralNatureza in _RgRegGeralNaturezaCollection)
            {
                _RgRegGeralNaturezas.Add(new RgRegGeralNatureza(
                    _RgRegGeralNatureza.IdEmpr,
                    _RgRegGeralNatureza.IdRg,
                    _RgRegGeralNatureza.IdNatureza,
                    _RgRegGeralNatureza.IdStatusNat,
                    _RgRegGeralNatureza.DataHora != DateTime.Parse("01/01/0001 00:00:00") ? _RgRegGeralNatureza.DataHora.ToString() : "01/01/0001 00:00:00",
                    _RgRegGeralNatureza.Usuario));
            }

            _RgFisicasJuridicas.Add(new RgFisicaJuridica(
                _RgFisicaJuridica.IdEmpr,
                _RgFisicaJuridica.IdRg,
                _RgFisicaJuridica.NroCPF,
                _RgFisicaJuridica.DigCPF,
                _RgFisicaJuridica.NroRg,
                _RgFisicaJuridica.DigRg,
                _RgFisicaJuridica.DtEmissao != DateTime.Parse("01/01/0001 00:00:00") ? _RgFisicaJuridica.DtEmissao.ToString() : "01/01/0001 00:00:00",
                _RgFisicaJuridica.OrgaoExpRg,
                _RgFisicaJuridica.InscrMunicipal,
                _RgFisicaJuridica.CGC,
                _RgFisicaJuridica.FilialCGC,
                _RgFisicaJuridica.DigCGC,
                _RgFisicaJuridica.InscEstadual,
                _RgFisicaJuridica.NroBanco,
                _RgFisicaJuridica.NroAgencia,
                _RgFisicaJuridica.DigAgencia,
                _RgFisicaJuridica.NroConta,
                _RgFisicaJuridica.DigConta,
                _RgFisicaJuridica.IdTipoCta,
                _RgFisicaJuridica.CEI));

            _RegistroGeralProcessMapping = new RegistroGeralProcessMapping();

            _RegistroGeralProcessMapping.RgRegGerais = _RgRegGerais;
            _RegistroGeralProcessMapping.RgEnderecos = _RgEnderecos;
            _RegistroGeralProcessMapping.RgTelefones = _RgTelefones;
            _RegistroGeralProcessMapping.RgRegGeralNaturezas = _RgRegGeralNaturezas;
            _RegistroGeralProcessMapping.RgFisicasJuridicas = _RgFisicasJuridicas;

            return _RegistroGeralProcessMapping;
        }
    }
}
