using BrSoftNet.Library.Messages;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BrSoftNet.Library.Utilities
{
    public class ExceptionHandling : UtilitiesFactory<ExceptionHandling>
    {
        public void AddExceptionAndSaveTextFile(Exception ex)
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

            MessageBox.Show(FormsMessages.MensagemArqLogErro,
                            FormsMessages.TituloArquivoLogErro,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
        }

        public void AddExceptionAndSaveEventLogOS(Exception ex)
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
            CreateEventLogSystemOperation(_Exception);
        }

        private void CreateEventLogSystemOperation(string _Exeception)
        {
            EventLog elog = new EventLog();
            elog.Log = "BrSoftNet";
            elog.Source = "Log de Erro de execução de processos";
            elog.WriteEntry(_Exeception, EventLogEntryType.Error);
            elog.Close();
            elog.Dispose();
        }

        private void CreateEventLogTextFile(string _Exeception)
        {
            string DIR = "";
            const string ARQ = "BrSoftNetLogError.txt";
            TextWriter _TextWriter = null;

            DIR = Path.DirectorySeparatorChar + "BrSoftNetLogError";

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
    }
}
