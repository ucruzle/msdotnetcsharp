using System;
using System.IO;
using System.Windows.Forms;

namespace BrSoftNet.Library.Utilities
{
    public class FileIO : UtilitiesFactory<FileIO>
    {
        public string onOpenFile()
        {
            string _Result = "";

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = "C:\\";
            openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
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

        public string onReadFile(string path)
        {
            String s = File.ReadAllText(path);
            s = s.Replace("\r", " ");
            s = s.Replace("\n", " ");
            s = s.Replace("\t", " ");

            return s.Trim();
        }
    }
}
