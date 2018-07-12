using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Data;
using System.Configuration;
using MergeEfdPisCofins.Entities;
using System.Globalization;

namespace MergeEfdPisCofins.Infrastructure
{
    public class CustomLibrary : Singleton<CustomLibrary>
    {
        public string OpenTXTFile()
        {
            string _Result = "";

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = "C:\\";
            openFile.Filter = "Arquivos de texto|*.txt|Todos os arquivos|*.*";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _Result = openFile.FileName.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                                    "Erro ao Carregar o Arquivo!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }

            return _Result;
        }

        public string OpenXMLFile()
        {
            string _Result = "";

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = "C:\\";
            openFile.Filter = "Arquivos XML|*.xml|Todos os arquivos|*.*";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _Result = openFile.FileName.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                                    "Erro ao Carregar o Arquivo!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }

            return _Result;
        }

        public string SaveFile()
        {
            string _Result = "";

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.InitialDirectory = "C:\\";
            saveFile.Filter = "Arquivos de texto|*.txt|Todos os arquivos|*.*";
            saveFile.FileName = "Merge";
            saveFile.FilterIndex = 2;
            saveFile.RestoreDirectory = true;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _Result = saveFile.FileName.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                                    "Erro ao Carregar o Arquivo!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }

            return _Result;
        }

        public string ReadFile(string path)
        {
            String s = File.ReadAllText(path);
            s = s.Replace("\r", " ");
            s = s.Replace("\n", " ");
            s = s.Replace("\t", " ");

            return s.Trim();
        }

        public void ShowContentFile(string _Arguments, string _FileName) 
        {
            Process notepad = new Process();
            notepad.StartInfo.FileName = _FileName;
            notepad.StartInfo.Arguments = _Arguments;
            notepad.Start();
        }

        public List<string> GetListFromTextFile(string _File) 
        {
            List<string> _TextFileList = null;
            StreamReader _Stream = null;

            try
            {
                _TextFileList = new List<string>();
                //_Stream = new StreamReader(_File, Encoding.UTF7);
                CultureInfo _CultureInfo = new CultureInfo("pt-BR");

                _Stream = new StreamReader(_File, Encoding.GetEncoding(_CultureInfo.TextInfo.ANSICodePage));

                while (!_Stream.EndOfStream)
                {
                    _TextFileList.Add(_Stream.ReadLine());
                }

                _Stream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _TextFileList ?? null;
        }

        public List<OfTo> GetListFromXMLFileOfTo(DataTable _DataTableXMLFileOfTo) 
        {
            List<OfTo> _XMLFileList = null;

            try
            {
                _XMLFileList = new List<OfTo>();

                foreach (DataRow row in _DataTableXMLFileOfTo.Rows)
                {
                    _XMLFileList.Add(new OfTo() { SSA = row["SSA"].ToString(), SAP = row["SAP"].ToString() });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _XMLFileList ?? null;
        }

        public List<CNPJ> GetListFromXMLFileParticipant(DataTable _DataTableXMLFileParticipant)
        {
            List<CNPJ> _XMLFileList = null;

            try
            {
                _XMLFileList = new List<CNPJ>();

                foreach (DataRow row in _DataTableXMLFileParticipant.Rows)
                {
                    _XMLFileList.Add(new CNPJ() { SSA = row["SSA"].ToString(), SAP = row["SAP"].ToString() });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _XMLFileList ?? null;
        }

        public List<BlockM> GetListFromXMLFileBlockM(DataTable _DataTableXMLFileBlockM)
        {
            List<BlockM> _XMLFileList = null;

            try
            {
                _XMLFileList = new List<BlockM>();

                foreach (DataRow row in _DataTableXMLFileBlockM.Rows)
                {
                    _XMLFileList.Add(new BlockM() { Node = row["M"].ToString() });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _XMLFileList ?? null;
        }

        public List<CreditType> GetListFromXMLFileCreditType(DataTable _DataTableXMLFileCreditType)
        {
            List<CreditType> _XMLFileList = null;

            try
            {
                _XMLFileList = new List<CreditType>();

                foreach (DataRow row in _DataTableXMLFileCreditType.Rows)
                {
                    _XMLFileList.Add(new CreditType() { Code = row["Codigo"].ToString(), Description = row["Descricao"].ToString() });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _XMLFileList ?? null;
        }

        public List<SocialContributionCalculed> GetListFromXMLFileSocialContributionCalculed(DataTable _DataTableXMLFileSocialContributionCalculed)
        {
            List<SocialContributionCalculed> _XMLFileList = null;

            try
            {
                _XMLFileList = new List<SocialContributionCalculed>();

                foreach (DataRow row in _DataTableXMLFileSocialContributionCalculed.Rows)
                {
                    _XMLFileList.Add(new SocialContributionCalculed() { Code = row["Codigo"].ToString(), Description = row["Descricao"].ToString() });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _XMLFileList ?? null;
        }

        public List<TaxSituationPisPasepCstPis> GetListFromXMLFileTaxSituationPisPasepCstPis(DataTable _DataTableXMLFileTaxSituationPisPasepCstPis)
        {
            List<TaxSituationPisPasepCstPis> _XMLFileList = null;

            try
            {
                _XMLFileList = new List<TaxSituationPisPasepCstPis>();

                foreach (DataRow row in _DataTableXMLFileTaxSituationPisPasepCstPis.Rows)
                {
                    _XMLFileList.Add(new TaxSituationPisPasepCstPis() { Code = row["Codigo"].ToString(), Description = row["Descricao"].ToString() });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _XMLFileList ?? null;
        }

        public List<CreditCalcBase> GetListFromXMLFileCreditCalcBase(DataTable _DataTableXMLFileCreditCalcBase)
        {
            List<CreditCalcBase> _XMLFileList = null;

            try
            {
                _XMLFileList = new List<CreditCalcBase>();

                foreach (DataRow row in _DataTableXMLFileCreditCalcBase.Rows)
                {
                    _XMLFileList.Add(new CreditCalcBase() { Code = row["Codigo"].ToString(), Description = row["Descricao"].ToString() });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _XMLFileList ?? null;
        }

        public DataSet LoadLedgerAccounts() 
        {
            DataSet ds = null;

            ds = new DataSet("ContasContabeis");
            ds.ReadXml(ConfigurationManager.AppSettings["XMLFileOfTo"].ToString() + "\\DePara.xml");

            return ds;
        }

        public DataSet LoadParticipant() 
        {
            DataSet ds = null;

            ds = new DataSet("Filiais");
            ds.ReadXml(ConfigurationManager.AppSettings["XMLFileParticipant"].ToString() + "\\SapSsaCNPJ.xml");

            return ds;
        }

        public DataSet LoadBlockM() 
        {
            DataSet ds = null;

            ds = new DataSet("BlockM");
            ds.ReadXml(ConfigurationManager.AppSettings["XMLFileBlockM"].ToString() + "\\BlockM.xml");

            return ds;
        }

        public DataSet LoadCreditTypeTable()
        {
            DataSet ds = null;

            ds = new DataSet("TabelaTipoCredito");
            ds.ReadXml(ConfigurationManager.AppSettings["XMLFileTabelaTipoCredito"].ToString() + "\\TabelaTipoCredito.xml");

            return ds;
        }

        public DataSet LoadSocialContributionCalculed()
        {
            DataSet ds = null;

            ds = new DataSet("TabelaContribuicaoSocialApurada");
            ds.ReadXml(ConfigurationManager.AppSettings["XMLFileTabelaContribuicaoSocialApurada"].ToString() + "\\TabelaContribuicaoSocialApurada.xml");

            return ds;
        }

        public DataSet LoadTaxSituationPisPasepCstPis()
        {
            DataSet ds = null;

            ds = new DataSet("TabelaSituacaoTributariaPisPasepCstPis");
            ds.ReadXml(ConfigurationManager.AppSettings["XMLFileTabelaSituacaoTributariaPisPasepCstPis"].ToString() + "\\TabelaSituacaoTributariaPisPasepCstPis.xml");

            return ds;
        }

        public DataSet LoadCreditCalcBase()
        {
            DataSet ds = null;

            ds = new DataSet("TabelaBaseCalculoCredito");
            ds.ReadXml(ConfigurationManager.AppSettings["XMLFileTabelaBaseCalculoCredito"].ToString() + "\\TabelaBaseCalculoCredito.xml");

            return ds;
        }

        public void AddException(Exception ex)
        {
            StringBuilder sb = new StringBuilder();

            while (ex != null)
            {
                sb.Append("Data ");
                sb.Append(DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                sb.Append("\n");
                sb.Append(" Hora ");
                sb.Append(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
                sb.Append(" Tipo de Exceção: ");
                sb.Append(ex.GetType().ToString());
                sb.Append("\n");
                sb.Append(" Menssage: ");
                sb.Append(ex.Message);
                sb.Append("\n");
                sb.Append(" Ação ");
                sb.Append(ex.TargetSite.ToString());
                sb.Append("\n");
                ex = ex.InnerException;
            }

            string _Exception = sb.ToString();
            CreateEventLogTextFile(_Exception);

            MessageBox.Show("Houve um erro na aplicação", "ERRO",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        }

        private void CreateEventLogSystemOperation(string _Exeception)
        {
            EventLog elog = new EventLog();
            elog.Log = "EDFPisCofins";
            elog.Source = "Log de Erros EFD PIS COFINS";
            elog.WriteEntry(_Exeception, EventLogEntryType.Error);
            elog.Close();
            elog.Dispose();
        }

        private void CreateEventLogTextFile(string _Exeception) 
        {
            string DIR = "";
            const string ARQ = "LogEfdPisCofis.txt";
            TextWriter _TextWriter = null;

            DIR = Path.DirectorySeparatorChar + "LogError";

            bool dirExiste = Directory.Exists(DIR);

            if (!dirExiste)
            {
                Directory.CreateDirectory(DIR);
            }

            string _FILE = DIR + Path.DirectorySeparatorChar + ARQ;

            if (!File.Exists(_FILE))
            {
                _TextWriter = File.CreateText(_FILE);
                _TextWriter.WriteLine(_Exeception);
                _TextWriter.Close();
            }
            else 
            {
                string _Text = File.ReadAllText(_FILE, ASCIIEncoding.ASCII);
                _Text += "\n" + _Exeception;
                _TextWriter = File.CreateText(_FILE);
                _TextWriter.WriteLine(_Text);
                _TextWriter.Close();
            }
        }

        public void ExecuteProgressBar(ProgressBar _ProgressBar, Label _Label, int _MaximunValue) 
        {
			int _Count = 0;

            _ProgressBar.Value = 0;
            _ProgressBar.Step = 1;

            for (int i = 0; i < _MaximunValue; i++)
            {
                _Count++;

                if (_Count % 100 == 0)
                {
                    _Label.Text = string.Format("Aguarde, informação sendo processada em...{0} %", _Count);
                    _ProgressBar.PerformStep();
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(40);
                }
            }
        }

        public void ClearProgressBar(ProgressBar _ProgressBar, Label _Label, int _MaximunValue) 
        {
            _ProgressBar.Value = 0;
            _ProgressBar.Step = 1;
            _MaximunValue = 0;
            _Label.Text = string.Empty;
        }
    }
}
