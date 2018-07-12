using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace BrSoftNet.Library.Utilities
{
    public class UserInterfaceWin : UtilitiesFactory<UserInterfaceWin>
    {
        public void onExit(Form form)
        {
            if (MessageBox.Show("Desaja sair?",
                                "Operação de Encerramento",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question) == DialogResult.OK)
            {
                form.Close();
            }
        }

        public void onInicializeProperties(Form form, bool isMdiContainer)
        {
            if (isMdiContainer)
            {
                form.IsMdiContainer = true;
            }
            else
            {
                form.IsMdiContainer = false;
            }

            form.WindowState = FormWindowState.Maximized;
        }

        public void onInicializePositionFormModal(Form form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        public void onShowMDIChildrenForm(Form formMDIParent, Form formMDIChildren)
        {
            try
            {
                formMDIChildren.MdiParent = formMDIParent;
                formMDIChildren.Show();
            }
            finally
            {
                formMDIChildren = null;
            }
        }

        public void onCloseMDIChildrenForm(Form formMDIParent)
        {
            foreach (var formMDIChildren in formMDIParent.MdiChildren)
            {
                formMDIChildren.Close();
            }
        }

        public void onPositionCascadeLayoutMDIChildrenForm(Form formMDIParent)
        {
            formMDIParent.LayoutMdi(MdiLayout.Cascade);
        }

        public void onPositionHorizontalLayoutMDIChildrenForm(Form formMDIParent)
        {
            formMDIParent.LayoutMdi(MdiLayout.TileHorizontal);
        }

        public void onPositionVerticalLayoutMDIChildrenForm(Form formMDIParent)
        {
            formMDIParent.LayoutMdi(MdiLayout.TileVertical);
        }

        public void onCallWindowsCalc() 
        {
            System.Diagnostics.Process _Process = new System.Diagnostics.Process();
            _Process.StartInfo.FileName = "calc.exe";
            _Process.Start();
        }

        public string SaveDirectoryPath()
        {
            string _Result;

            FolderBrowserDialog _FolderBrowserDialog = new FolderBrowserDialog();

            if (_FolderBrowserDialog.ShowDialog() == DialogResult.Cancel)
            {
                _Result = string.Empty;
            }
            else 
            {
                _Result = _FolderBrowserDialog.SelectedPath;
            }

            return _Result;
        }

        public void ExecuteProgressBar(ProgressBar _ProgressBar, Label _Label, int _MaximunValue)
        {
            int _Maximun = _MaximunValue >= 10000 ? _MaximunValue : 10000;
            int _Count = 0;

            _ProgressBar.Value = 0;
            _ProgressBar.Step = 1;

            for (int i = 0; i < _Maximun; i++)
            {
                _Count++;

                if (_Count % 100 == 0)
                {
                    _Label.Text = string.Format("Informação sendo processada em...{0} %", _Count);
                    _ProgressBar.PerformStep();
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(40);
                }
            }
        }

        public string GetIDSession()
        {
            string _Id = string.Empty;
            Guid _NewGuid = Guid.NewGuid();

            _Id = "SESID" + _NewGuid.ToString().Substring(24, 12).ToUpper();

            return _Id;
        }

        public string GetFormTitleText(string _FullText, string _TextAdded) 
        {
            string _Title = string.Empty;

            if (!string.IsNullOrEmpty(_TextAdded))
            {
                _Title = string.Format(_FullText, _TextAdded);
            }

            return _Title;
        }
    }
}
