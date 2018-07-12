using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MergeEfdPisCofins.Infrastructure;
using System.IO;
using MergeEfdPisCofins.Entities;
using System.Linq;

namespace MergeEfdPisCofins
{
    public partial class frmMain : Form
    {
        #region :::... Global Fields ...:::

        DataTable _DataTableOfTo = null;
        DataTable _DataTableParticipant = null;
        DataTable _DataTableBlockM = null;
        DataTable _DataTableCodeCredit = null;
        DataTable _DataTableTabelaContribuicaoSocialApurada = null;
        DataTable _DataTableTabelaSituacaoTributariaPisPasepCstPis = null;
        DataTable _DataTableTabelaBaseCalculoCredito = null;

        int _ProcessCount = 0;

        #region :::... Counters ...:::

        int _0000Count = 0;
        int _0001Count = 0;
        int _0100Count = 0;
        int _0110Count = 0;
        int _0111Count = 0;
        int _0140Count = 0;
        int _0150Count = 0;
        int _0190Count = 0;
        int _0200Count = 0;
        int _0205Count = 0;
        int _0400Count = 0;
        int _0450Count = 0;
        int _0500Count = 0;
        int _0600Count = 0;
        int _0990Count = 0;
        int _1001Count = 0;
        int _1100Count = 0;
        int _1500Count = 0;
        int _1990Count = 0;
        int _9001Count = 1;
        int _9990Count = 1;
        int _9999Count = 1;
        int _A001Count = 0;
        int _A010Count = 0;
        int _A100Count = 0;
        int _A110Count = 0;
        int _A170Count = 0;
        int _A990Count = 0;
        int _C001Count = 0;
        int _C010Count = 0;
        int _C100Count = 0;
        int _C110Count = 0;
        int _C120Count = 0;
        int _C170Count = 0;
        int _C500Count = 0;
        int _C501Count = 0;
        int _C505Count = 0;
        int _C990Count = 0;
        int _D001Count = 0;
        int _D010Count = 0;
        int _D100Count = 0;
        int _D101Count = 0;
        int _D105Count = 0;
        int _D500Count = 0;
        int _D501Count = 0;
        int _D505Count = 0;
        int _D990Count = 0;
        int _F001Count = 0;
        int _F010Count = 0;
        int _F100Count = 0;
        int _F120Count = 0;
        int _F990Count = 0;
        int _M001Count = 0;
        int _M100Count = 0;
        int _M105Count = 0;
        int _M200Count = 0;
        int _M210Count = 0;
        int _M400Count = 0;
        int _M410Count = 0;
        int _M500Count = 0;
        int _M505Count = 0;
        int _M600Count = 0;
        int _M610Count = 0;
        int _M800Count = 0;
        int _M810Count = 0;
        int _M990Count = 0;
        int _9900Count = 0;

        #endregion

        #region :::... Accumulators ...:::

        int _ACUMULATOR_BLOCK_0 = 0;
        int _ACUMULATOR_BLOCK_A = 0;
        int _ACUMULATOR_BLOCK_C = 0;
        int _ACUMULATOR_BLOCK_D = 0;
        int _ACUMULATOR_BLOCK_F = 0;
        int _ACUMULATOR_BLOCK_M = 0;
        int _ACUMULATOR_BLOCK_1 = 0;
        int _ACUMULATOR_BLOCK_9 = 0;
        int _ACUMULATOR_FILE = 0;

        #endregion

        TextWriter _TextWriter;

        List<string> _SSAFileTextFilled = null;
        List<string> _SAPFileTextFilled = null;

        #endregion

        #region :::... Constructors ...:::

        public frmMain()
        {
            InitializeComponent();
            startForm();
        }

        #endregion 

        #region :::... Methods ...:::

        private void startForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.LoadXMLFile();
        }

        private void LoadSSATXTFile()
        {
            txtLoadSSATXTFile.Text = CustomLibrary.CreateInstance.OpenTXTFile();
        }

        private void LoadSAPTXTFile()
        {
            txtLoadSAPTXTFile.Text = CustomLibrary.CreateInstance.OpenTXTFile();
        }

        private void LoadXMLFile()
        {
            _DataTableOfTo = CustomLibrary.CreateInstance.LoadLedgerAccounts().Tables[0];
            _DataTableParticipant = CustomLibrary.CreateInstance.LoadParticipant().Tables[0];
            _DataTableBlockM = CustomLibrary.CreateInstance.LoadBlockM().Tables[0];
            _DataTableCodeCredit = CustomLibrary.CreateInstance.LoadCreditTypeTable().Tables[0];
            _DataTableTabelaBaseCalculoCredito = CustomLibrary.CreateInstance.LoadCreditCalcBase().Tables[0];
            _DataTableTabelaContribuicaoSocialApurada = CustomLibrary.CreateInstance.LoadSocialContributionCalculed().Tables[0];
            _DataTableTabelaSituacaoTributariaPisPasepCstPis = CustomLibrary.CreateInstance.LoadTaxSituationPisPasepCstPis().Tables[0];
            dataGridViewAtTo.DataSource = _DataTableOfTo;
        }

        private void SaveFileMerge()
        {
            txtSaveFileMerge.Text = CustomLibrary.CreateInstance.SaveFile();
        }

        private bool IsFinishiBlockZeroHundredElevenSSADataCollection() 
        {
            bool _IsZeroHundredEleven = false;

            foreach (string item in _SSAFileTextFilled)
            {
                if (item.Substring(0, 6) == "|0111|")
                {
                    _IsZeroHundredEleven = true;
                    break;
                }
            }

            return _IsZeroHundredEleven;
        }

        private bool IsFinishiBlockZeroHundredElevenSAPDataCollection()
        {
            bool _IsZeroHundredEleven = false;

            foreach (string item in _SAPFileTextFilled)
            {
                if (item.Substring(0, 6) == "|0111|")
                {
                    _IsZeroHundredEleven = true;
                    break;
                }
            }

            return _IsZeroHundredEleven;
        }

        private void FillZeroBlockHeader() 
        {
            int i = 0;

            if (IsFinishiBlockZeroHundredElevenSSADataCollection())
            {
                while (_SSAFileTextFilled[i].Substring(0, 6) != "|0111|")
                {
                    _TextWriter.WriteLine(_SSAFileTextFilled[i]);
                    CountBlock(_SSAFileTextFilled[i]);
                    i++;
                    _ProcessCount++;
                }
            }

            if (IsFinishiBlockZeroHundredElevenSAPDataCollection())
            {
                while (_SAPFileTextFilled[i].Substring(0, 6) != "|0111|")
                {
                    _TextWriter.WriteLine(_SAPFileTextFilled[i]);
                    CountBlock(_SAPFileTextFilled[i]);
                    i++;
                    _ProcessCount++;
                }
            }

            if (IsFinishiBlockZeroHundredElevenSAPDataCollection() && IsFinishiBlockZeroHundredElevenSSADataCollection())
            {
                while (_SAPFileTextFilled[i].Substring(0, 6) != "|0111|")
                {
                    _TextWriter.WriteLine(_SAPFileTextFilled[i]);
                    CountBlock(_SAPFileTextFilled[i]);
                    i++;
                    _ProcessCount++;
                }
            }
        }

        private void FillZeroBlockOneHundredEleven() 
        {
            decimal _REC_BRU_NCUM_TRIB_MI_SAP = 0;
            decimal _REC_BRU_NCUM_TRIB_MI_SSA = 0;
            decimal _REC_BRU_NCUM_TRIB_MI = 0;

            decimal _REC_BRU_NCUM_NT_MI_SAP = 0;
            decimal _REC_BRU_NCUM_NT_MI_SSA = 0;
            decimal _REC_BRU_NCUM_NT_MI = 0;

            decimal _REC_BRU_NCUM_EXP_SAP = 0;
            decimal _REC_BRU_NCUM_EXP_SSA = 0;
            decimal _REC_BRU_NCUM_EXP = 0;

            decimal _REC_BRU_CUM_SAP = 0;
            decimal _REC_BRU_CUM_SSA = 0;
            decimal _REC_BRU_CUM = 0;

            decimal _REC_BRU_TOTAL_SAP = 0;
            decimal _REC_BRU_TOTAL_SSA = 0;
            decimal _REC_BRU_TOTAL = 0;

            string _0111_ToMerge = "";

            foreach (string item in _SAPFileTextFilled) 
            { 
                if (item.Substring(0, 6) == "|0111|") 
                {
                    _0111_ToMerge = item;
                    string[] _Line = item.Split('|');
                    _REC_BRU_NCUM_TRIB_MI_SAP = decimal.Parse(_Line[2]);
                    _REC_BRU_NCUM_NT_MI_SAP = decimal.Parse(_Line[3]);
                    _REC_BRU_NCUM_EXP_SAP = decimal.Parse(_Line[4]);
                    _REC_BRU_CUM_SAP = decimal.Parse(_Line[5]);
                    _REC_BRU_TOTAL_SAP = decimal.Parse(_Line[6]);
                    break; 
                } 
            }

            foreach (string item in _SSAFileTextFilled) 
            { 
                if (item.Substring(0, 6) == "|0111|") 
                { 
                    string[] _Line = item.Split('|');
                    _REC_BRU_NCUM_TRIB_MI_SSA = decimal.Parse(_Line[2]);
                    _REC_BRU_NCUM_NT_MI_SSA = decimal.Parse(_Line[3]);
                    _REC_BRU_NCUM_EXP_SSA = decimal.Parse(_Line[4]);
                    _REC_BRU_CUM_SSA = decimal.Parse(_Line[5]);
                    _REC_BRU_TOTAL_SSA = decimal.Parse(_Line[6]);
                    break; 
                } 
            }

            _REC_BRU_NCUM_TRIB_MI = _REC_BRU_NCUM_TRIB_MI_SAP + _REC_BRU_NCUM_TRIB_MI_SSA;
            _REC_BRU_NCUM_NT_MI = _REC_BRU_NCUM_NT_MI_SAP + _REC_BRU_NCUM_NT_MI_SSA;
            _REC_BRU_NCUM_EXP = _REC_BRU_NCUM_EXP_SAP + _REC_BRU_NCUM_EXP_SSA;
            _REC_BRU_CUM = _REC_BRU_CUM_SAP + _REC_BRU_CUM_SSA;
            _REC_BRU_TOTAL = _REC_BRU_TOTAL_SAP + _REC_BRU_TOTAL_SSA;

            StringBuilder _Sb = new StringBuilder();
            _Sb.Append("|");
            _Sb.Append("0111");
            _Sb.Append("|");
            _Sb.Append(_REC_BRU_NCUM_TRIB_MI.ToString());
            _Sb.Append("|");
            _Sb.Append(_REC_BRU_NCUM_NT_MI.ToString());
            _Sb.Append("|");
            _Sb.Append(_REC_BRU_NCUM_EXP.ToString());
            _Sb.Append("|");
            _Sb.Append(_REC_BRU_CUM.ToString());
            _Sb.Append("|");
            _Sb.Append(_REC_BRU_TOTAL.ToString());
            _Sb.Append("|");

            _TextWriter.WriteLine(_Sb.ToString());

            CountBlock(_Sb.ToString());

            _ProcessCount++;
        }

        private void FillBlockZeroHundredFortyToHundredFifity() 
        {
            List<CNPJ> _CNPJCollection = CustomLibrary.CreateInstance.GetListFromXMLFileParticipant(_DataTableParticipant);
            bool _Is0140 = false;
            int _Block = 0;

            foreach (string item in _SAPFileTextFilled)
            {
                string[] _Line = item.Split('|');

                if (_Line[1] == "0140")
                {
                    if (_CNPJCollection.Exists(p => p.SAP == _Line[4]))
                    {
                        _Is0140 = true;
                        _TextWriter.WriteLine(item);
                        CountBlock(item);
                    }
                    else 
                    {
                        _Is0140 = false;
                    }
                }
                else if(_Is0140)
                {
                    _Block = int.Parse(_Line[1]);

                    if (_Block >= 150 && _Block <= 450)
                    {
                        _TextWriter.WriteLine(item);
                        CountBlock(item);
                    }
                    else if(_Block > 450) 
                    {
                        break;
                    }
                }
            }

            _Is0140 = false;
            _Block = 0;

            foreach (string item in _SSAFileTextFilled)
            {
                string[] _Line = item.Split('|');

                if (_Line[1] == "0140")
                {
                    if (_CNPJCollection.Exists(p => p.SSA == _Line[4]))
                    {
                        _Is0140 = true;
                        _TextWriter.WriteLine(item);
                        CountBlock(item);
                    }
                    else
                    {
                        _Is0140 = false;
                    }
                }
                else if (_Is0140)
                {
                    _Block = int.Parse(_Line[1]);

                    if (_Block >= 150 && _Block <= 450)
                    {
                        _TextWriter.WriteLine(item);
                        CountBlock(item);
                    }
                    else if (_Block > 450)
                    {
                        break;
                    }
                }
            }

            _ProcessCount++;
        }

        private void FillZeroBlockFiveHundred() 
        {
            List<OfTo> _OfToListFromXMLFile = CustomLibrary.CreateInstance.GetListFromXMLFileOfTo(_DataTableOfTo);
            int _Block = 0;

            foreach (string item in _SAPFileTextFilled)
            {
                string[] _Line = item.Split('|');

                _Block = int.Parse(_Line[1]);

                if (_Block == 500)
                {
                    _TextWriter.WriteLine(item);
                    CountBlock(item);
                }
                else if (_Block > 500)
                {
                    break;
                }
            }

            _Block = 0;

            foreach (string item in _SSAFileTextFilled)
            {
                string[] _Line = item.Split('|');

                _Block = int.Parse(_Line[1]);

                if (_Block == 500)
                {

                    string _COD_CTA = "";

                    foreach (OfTo _OfTo in _OfToListFromXMLFile)
                    {
                        _COD_CTA = _OfTo.SSA == _Line[6] ? _OfTo.SAP : string.Empty;
                        break;
                    }

                    if (!string.IsNullOrEmpty(_COD_CTA))
                    {
                        _TextWriter.WriteLine(item.Replace(_Line[6], _COD_CTA));
                        CountBlock(item);
                    }
                    else 
                    {
                        _TextWriter.WriteLine(item);
                        CountBlock(item);
                    }
                }
                else if (_Block > 500)
                {
                    break;
                }
            }

            _ProcessCount++;
        }

        private void FillBlockZeroSixHundred() 
        {
            int _Block = 0;

            foreach (string item in _SAPFileTextFilled)
            {
                string[] _Line = item.Split('|');

                _Block = int.Parse(_Line[1]);

                if (_Block == 600)
                {
                    _TextWriter.WriteLine(item);
                    CountBlock(item);
                }
                else if (_Block > 600) 
                {
                    break;
                }
            }

            foreach (string item in _SSAFileTextFilled)
            {
                string[] _Line = item.Split('|');

                _Block = int.Parse(_Line[1]);

                if (_Block == 600)
                {
                    _TextWriter.WriteLine(item);
                    CountBlock(item);
                }
                else if (_Block > 600)
                {
                    break;
                }
            }

            _ProcessCount++;
        }

        private void CloseZeroBlock() 
        {
            AccumulatorBlock("0990");
            _TextWriter.WriteLine(string.Format("|0990|{0}|", _ACUMULATOR_BLOCK_0));
            _ProcessCount++;
        }

        private void FillABlock() 
        {
            bool _IsABlock = false;
            bool _OpenBlock = false;
            bool _HasZero = false;

            foreach (string item in _SAPFileTextFilled)
            {
                string[] _Line = item.Split('|');

                if (_Line[1] == "A001")
                {
                    if (_Line[2] == "1")
                    {
                        _OpenBlock = false;
                        break;
                    }
                    else 
                    {
                        _IsABlock = true;
                        _OpenBlock = true;
                        _HasZero = true;
                    }
                }
                else if (_Line[1] == "A990")
                {
                    break;
                }

                if (_IsABlock) 
                {
                    _TextWriter.WriteLine(item);
                    CountBlock(item);
                }
            }

            _IsABlock = false;

            foreach (string item in _SSAFileTextFilled)
            {
                string[] _Line = item.Split('|');

                if (_Line[1] == "A001")
                {
                    if (_Line[2] == "1")
                    {
                        _OpenBlock = false;
                        break;
                    }
                    else
                    {
                        _IsABlock = true;
                        _OpenBlock = true;
                    }
                }
                else if (_Line[1] == "A990")
                {
                    break;
                }

                if (_IsABlock)
                {
                    if ((_Line[1] == "A001") && (_Line[2] == "0") && !(_HasZero))
                    {
                        _TextWriter.WriteLine(item);
                        CountBlock(item);
                    }
                    else if (_Line[1] != "A001")
                    {
                        _TextWriter.WriteLine(item);
                        CountBlock(item);
                    }
                }
            }

            if (!_OpenBlock)
            {
                _TextWriter.WriteLine(string.Format("|A001|{0}|", 1));
                _TextWriter.WriteLine(string.Format("|A990|{0}|", 2));
            }
            else
            {
                CloseABlock();
            }

            _ProcessCount++;
        }

        private void CloseABlock() 
        {
            AccumulatorBlock("A990");
            _TextWriter.WriteLine(string.Format("|A990|{0}|", _ACUMULATOR_BLOCK_A));
            _ProcessCount++;
        }

        private void FillCBlock() 
        {
            bool _IsCBlock = false;
            bool _OpenBlock = false;
            bool _HasZero = false;

            foreach (string item in _SAPFileTextFilled)
            {
                string[] _Line = item.Split('|');

                if (_Line[1] == "C001")
                {
                    if (_Line[2] == "1")
                    {
                        _OpenBlock = false;
                        break;
                    }
                    else
                    {
                        _IsCBlock = true;
                        _OpenBlock = true;
                        _HasZero = true;
                    }
                }
                else if (_Line[1] == "C990")
                {
                    break;
                }

                if (_IsCBlock)
                {
                    _TextWriter.WriteLine(item);
                    CountBlock(item);
                }
            }

            _IsCBlock = false;

            foreach (string item in _SSAFileTextFilled)
            {
                string[] _Line = item.Split('|');

                if (_Line[1] == "C001")
                {
                    if (_Line[2] == "1")
                    {
                        _OpenBlock = false;
                        break;
                    }
                    else
                    {
                        _IsCBlock = true;
                        _OpenBlock = true;
                    }
                }
                else if (_Line[1] == "C990")
                {
                    break;
                }

                if (_IsCBlock)
                {
                    if ((_Line[1] == "C001") && (_Line[2] == "0") && !(_HasZero))
                    {
                        _TextWriter.WriteLine(item);
                        CountBlock(item);
                    }
                    else if (_Line[1] != "C001")
                    {
                        _TextWriter.WriteLine(item);
                        CountBlock(item);
                    }
                }
            }

            if (!_OpenBlock)
            {
                _TextWriter.WriteLine(string.Format("|C001|{0}|", 1));
                _TextWriter.WriteLine(string.Format("|C990|{0}|", 2));
            }
            else
            {
                CloseCBlock();
            }

            _ProcessCount++;
        }

        private void CloseCBlock() 
        {
            AccumulatorBlock("C990");
            _TextWriter.WriteLine(string.Format("|C990|{0}|", _ACUMULATOR_BLOCK_C));
            _ProcessCount++;
        }

        private void FillDBlock()
        {
            bool _IsABlock = false;
            bool _OpenBlock = false;
            bool _HasZero = false;

            foreach (string item in _SAPFileTextFilled)
            {
                string[] _Line = item.Split('|');

                if (_Line[1] == "D001")
                {
                    if (_Line[2] == "1")
                    {
                        _OpenBlock = false;
                        break;
                    }
                    else
                    {
                        _IsABlock = true;
                        _OpenBlock = true;
                    }
                }
                else if (_Line[1] == "D990")
                {
                    break;
                }

                if (_IsABlock)
                {
                    _TextWriter.WriteLine(item);
                    CountBlock(item);
                    _HasZero = true;
                }
            }

            _IsABlock = false;

            foreach (string item in _SSAFileTextFilled)
            {
                string[] _Line = item.Split('|');

                if (_Line[1] == "D001")
                {
                    if (_Line[2] == "1")
                    {
                        _OpenBlock = false;
                        break;
                    }
                    else
                    {
                        _IsABlock = true;
                        _OpenBlock = true;
                    }
                }
                else if (_Line[1] == "D990")
                {
                    break;
                }

                if (_IsABlock)
                {
                    if ((_Line[1] == "D001") && (_Line[2] == "0") && !(_HasZero))
                    {
                        _TextWriter.WriteLine(item);
                        CountBlock(item);
                    }
                    else if (_Line[1] != "D001")
                    {
                        _TextWriter.WriteLine(item);
                        CountBlock(item);
                    }
                }
            }

            if (!_OpenBlock)
            {
                _TextWriter.WriteLine(string.Format("|D001|{0}|", 1));
                _TextWriter.WriteLine(string.Format("|D990|{0}|", 2));
            }
            else
            {
                CloseDBlock();
            }

            _ProcessCount++;
        }

        private void CloseDBlock()
        {
            AccumulatorBlock("D990");
            _TextWriter.WriteLine(string.Format("|D990|{0}|", _ACUMULATOR_BLOCK_D));
            _ProcessCount++;
        }

        private void FillFBlock()
        {
            bool _IsABlock = false;
            bool _OpenBlock = false;
            bool _HasZero = false;

            foreach (string item in _SAPFileTextFilled)
            {
                string[] _Line = item.Split('|');

                if (_Line[1] == "F001")
                {
                    if (_Line[2] == "1")
                    {
                        _OpenBlock = false;
                        break;
                    }
                    else
                    {
                        _IsABlock = true;
                        _OpenBlock = true;
                        _HasZero = true;
                    }
                }
                else if (_Line[1] == "F990")
                {
                    break;
                }

                if (_IsABlock)
                {
                    _TextWriter.WriteLine(item);
                    CountBlock(item);
                }
            }

            _IsABlock = false;

            foreach (string item in _SSAFileTextFilled)
            {
                string[] _Line = item.Split('|');

                if (_Line[1] == "F001")
                {
                    if (_Line[2] == "1")
                    {
                        _OpenBlock = false;
                        break;
                    }
                    else
                    {
                        _IsABlock = true;
                        _OpenBlock = true;
                    }
                }
                else if (_Line[1] == "F990")
                {
                    break;
                }

                if (_IsABlock)
                {
                    if ((_Line[1] == "F001") && (_Line[2] == "0") && !(_HasZero))
                    {
                        _TextWriter.WriteLine(item);
                        CountBlock(item);
                    }
                    else if (_Line[1] != "F001")
                    {
                        _TextWriter.WriteLine(item);
                        CountBlock(item);
                    }
                }
            }

            if (!_OpenBlock)
            {
                _TextWriter.WriteLine(string.Format("|F001|{0}|", 1));
                _TextWriter.WriteLine(string.Format("|F990|{0}|", 2));
            }
            else
            {
                CloseFBlock();
            }

            _ProcessCount++;
        }

        private void CloseFBlock()
        {
            AccumulatorBlock("F990");
            _TextWriter.WriteLine(string.Format("|F990|{0}|", _ACUMULATOR_BLOCK_F));
            _ProcessCount++;
        }

        private void FillBlockMHeader(bool _doWriteMBlock) 
        {
            foreach (string item in _SAPFileTextFilled)
            {
                string[] _Line = item.Split('|');

                if (_Line[1] == "M001")
                {
                    if (_doWriteMBlock)
                    {
                        _TextWriter.WriteLine(item);
                        CountBlock(item);
                        break;
                    }
                    else 
                    {
                        string _OpenMBlock = "|M001|1|";
                        _TextWriter.WriteLine(_OpenMBlock);
                        CountBlock(_OpenMBlock);
                        break;
                    }
                }
            }

            _ProcessCount++;
        }

        private void FillBlockMOneHundred() 
        {
            foreach (string item in _SAPFileTextFilled)
            {
                if (item.Substring(1, 2) == "M1")
                {
                    _TextWriter.WriteLine(item);
                    CountBlock(item);
                }
            }

            foreach (string item in _SSAFileTextFilled)
            {
                if (item.Substring(1, 2) == "M1")
                {
                    _TextWriter.WriteLine(item);
                    CountBlock(item);
                }
            }

            _ProcessCount++;
        }

        private void FillBlockMTwoHundred() 
        {
            decimal _VL_TOT_CONT_NC_PER_SAP = 0;
            decimal _VL_TOT_CRED_DESC_SAP = 0;
            decimal _VL_TOT_CRED_DESC_ANT_SAP = 0;
            decimal _VL_TOT_CONT_NC_DEV_SAP = 0;
            decimal _VL_RET_NC_SAP = 0;
            decimal _VL_OUT_DED_NC_SAP = 0;
            decimal _VL_CONT_NC_REC_SAP = 0;
            decimal _VL_TOT_CONT_CUM_PER_SAP = 0;
            decimal _VL_RET_CUM_SAP = 0;
            decimal _VL_OUT_DED_CUM_SAP = 0;
            decimal _VL_CONT_CUM_REC_SAP = 0;
            decimal _VL_TOT_CONT_REC_SAP = 0;

            decimal _VL_TOT_CONT_NC_PER_SSA = 0;
            decimal _VL_TOT_CRED_DESC_SSA = 0;
            decimal _VL_TOT_CRED_DESC_ANT_SSA = 0;
            decimal _VL_TOT_CONT_NC_DEV_SSA = 0;
            decimal _VL_RET_NC_SSA = 0;
            decimal _VL_OUT_DED_NC_SSA = 0;
            decimal _VL_CONT_NC_REC_SSA = 0;
            decimal _VL_TOT_CONT_CUM_PER_SSA = 0;
            decimal _VL_RET_CUM_SSA = 0;
            decimal _VL_OUT_DED_CUM_SSA = 0;
            decimal _VL_CONT_CUM_REC_SSA = 0;
            decimal _VL_TOT_CONT_REC_SSA = 0;

            decimal _VL_TOT_CONT_NC_PER = 0;
            decimal _VL_TOT_CRED_DESC = 0;
            decimal _VL_TOT_CRED_DESC_ANT = 0;
            decimal _VL_TOT_CONT_NC_DEV = 0;
            decimal _VL_RET_NC = 0;
            decimal _VL_OUT_DED_NC = 0;
            decimal _VL_CONT_NC_REC = 0;
            decimal _VL_TOT_CONT_CUM_PER = 0;
            decimal _VL_RET_CUM = 0;
            decimal _VL_OUT_DED_CUM = 0;
            decimal _VL_CONT_CUM_REC = 0;
            decimal _VL_TOT_CONT_REC = 0;

            string _M200_ToMerge = "";

            foreach (string item in _SAPFileTextFilled)
            {
                if (item.Substring(0, 6) == "|M200|")
                {
                    _M200_ToMerge = item;
                    string[] _Line = item.Split('|');
                    _VL_TOT_CONT_NC_PER_SAP = decimal.Parse(_Line[2]);
                    _VL_TOT_CRED_DESC_SAP = decimal.Parse(_Line[3]);
                    _VL_TOT_CRED_DESC_ANT_SAP = decimal.Parse(_Line[4]);
                    _VL_TOT_CONT_NC_DEV_SAP = decimal.Parse(_Line[5]);
                    _VL_RET_NC_SAP = decimal.Parse(_Line[6]);
                    _VL_OUT_DED_NC_SAP = decimal.Parse(_Line[7]);
                    _VL_CONT_NC_REC_SAP = decimal.Parse(_Line[8]);
                    _VL_TOT_CONT_CUM_PER_SAP = decimal.Parse(_Line[9]);
                    _VL_RET_CUM_SAP = decimal.Parse(_Line[10]);
                    _VL_OUT_DED_CUM_SAP = decimal.Parse(_Line[11]);
                    _VL_CONT_CUM_REC_SAP = decimal.Parse(_Line[12]);
                    _VL_TOT_CONT_REC_SAP = decimal.Parse(_Line[13]);
                    break;
                }
            }

            foreach (string item in _SSAFileTextFilled)
            {
                if (item.Substring(0, 6) == "|M200|")
                {
                    string[] _Line = item.Split('|');
                    _VL_TOT_CONT_NC_PER_SSA = decimal.Parse(_Line[2]);
                    _VL_TOT_CRED_DESC_SSA = decimal.Parse(_Line[3]);
                    _VL_TOT_CRED_DESC_ANT_SSA = decimal.Parse(_Line[4]);
                    _VL_TOT_CONT_NC_DEV_SSA = decimal.Parse(_Line[5]);
                    _VL_RET_NC_SSA = decimal.Parse(_Line[6]);
                    _VL_OUT_DED_NC_SSA = decimal.Parse(_Line[7]);
                    _VL_CONT_NC_REC_SSA = decimal.Parse(_Line[8]);
                    _VL_TOT_CONT_CUM_PER_SSA = decimal.Parse(_Line[9]);
                    _VL_RET_CUM_SSA = decimal.Parse(_Line[10]);
                    _VL_OUT_DED_CUM_SSA = decimal.Parse(_Line[11]);
                    _VL_CONT_CUM_REC_SSA = decimal.Parse(_Line[12]);
                    _VL_TOT_CONT_REC_SSA = decimal.Parse(_Line[13]);
                    break;
                }
            }

            _VL_TOT_CONT_NC_PER = _VL_TOT_CONT_NC_PER_SAP + _VL_TOT_CONT_NC_PER_SSA;
            _VL_TOT_CRED_DESC = _VL_TOT_CRED_DESC_SAP + _VL_TOT_CRED_DESC_SSA;
            _VL_TOT_CRED_DESC_ANT = _VL_TOT_CRED_DESC_ANT_SAP + _VL_TOT_CRED_DESC_ANT_SSA;
            _VL_TOT_CONT_NC_DEV = _VL_TOT_CONT_NC_DEV_SAP + _VL_TOT_CONT_NC_DEV_SSA;
            _VL_RET_NC = _VL_RET_NC_SAP + _VL_RET_NC_SSA;
            _VL_OUT_DED_NC = _VL_OUT_DED_NC_SAP + _VL_OUT_DED_NC_SSA;
            _VL_CONT_NC_REC = _VL_CONT_NC_REC_SAP + _VL_CONT_NC_REC_SSA;
            _VL_TOT_CONT_CUM_PER = _VL_TOT_CONT_CUM_PER_SAP + _VL_TOT_CONT_CUM_PER_SSA;
            _VL_RET_CUM = _VL_RET_CUM_SAP + _VL_RET_CUM_SSA;
            _VL_OUT_DED_CUM = _VL_OUT_DED_CUM_SAP + _VL_OUT_DED_CUM_SSA;
            _VL_CONT_CUM_REC = _VL_CONT_CUM_REC_SAP + _VL_CONT_CUM_REC_SSA;
            _VL_TOT_CONT_REC = _VL_TOT_CONT_REC_SAP + _VL_TOT_CONT_REC_SSA;

            StringBuilder _Sb = new StringBuilder();
            _Sb.Append("|");
            _Sb.Append("M200");
            _Sb.Append("|");
            _Sb.Append(_VL_TOT_CONT_NC_PER.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_TOT_CRED_DESC.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_TOT_CRED_DESC_ANT.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_TOT_CONT_NC_DEV.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_RET_NC.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_OUT_DED_NC.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_CONT_NC_REC.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_TOT_CONT_CUM_PER.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_RET_CUM.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_OUT_DED_CUM.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_CONT_CUM_REC.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_TOT_CONT_REC.ToString());
            _Sb.Append("|");

            _TextWriter.WriteLine(_Sb.ToString());

            CountBlock(_Sb.ToString());

            _ProcessCount++;
        }

        private void FillBlockMThreeHundred() 
        {
            foreach (string item in _SAPFileTextFilled)
            {
                if (item.Substring(1, 2) == "M3")
                {
                    _TextWriter.WriteLine(item);
                    CountBlock(item);
                }
            }

            foreach (string item in _SSAFileTextFilled)
            {
                if (item.Substring(1, 2) == "M3")
                {
                    _TextWriter.WriteLine(item);
                    CountBlock(item);
                }
            }

            _ProcessCount++;
        }

        private void FillBlockMFourHundred() 
        {
            foreach (string item in _SAPFileTextFilled)
            {
                if (item.Substring(1, 2) == "M4")
                {
                    _TextWriter.WriteLine(item);
                    CountBlock(item);
                }
            }

            foreach (string item in _SSAFileTextFilled)
            {
                if (item.Substring(1, 2) == "M4")
                {
                    _TextWriter.WriteLine(item);
                    CountBlock(item);
                }
            }

            _ProcessCount++;
        }

        private void FillBlockMFiveHundred() 
        {
            foreach (string item in _SAPFileTextFilled)
            {
                if (item.Substring(1, 2) == "M5")
                {
                    _TextWriter.WriteLine(item);
                    CountBlock(item);
                }
            }

            foreach (string item in _SSAFileTextFilled)
            {
                if (item.Substring(1, 2) == "M5")
                {
                    _TextWriter.WriteLine(item);
                    CountBlock(item);
                }
            }

            _ProcessCount++;
        }

        private void FillBlockMSixHundred()
        {
            decimal _VL_TOT_CONT_NC_PER_SAP = 0;
            decimal _VL_TOT_CRED_DESC_SAP = 0;
            decimal _VL_TOT_CRED_DESC_ANT_SAP = 0;
            decimal _VL_TOT_CONT_NC_DEV_SAP = 0;
            decimal _VL_RET_NC_SAP = 0;
            decimal _VL_OUT_DED_NC_SAP = 0;
            decimal _VL_CONT_NC_REC_SAP = 0;
            decimal _VL_TOT_CONT_CUM_PER_SAP = 0;
            decimal _VL_RET_CUM_SAP = 0;
            decimal _VL_OUT_DED_CUM_SAP = 0;
            decimal _VL_CONT_CUM_REC_SAP = 0;
            decimal _VL_TOT_CONT_REC_SAP = 0;

            decimal _VL_TOT_CONT_NC_PER_SSA = 0;
            decimal _VL_TOT_CRED_DESC_SSA = 0;
            decimal _VL_TOT_CRED_DESC_ANT_SSA = 0;
            decimal _VL_TOT_CONT_NC_DEV_SSA = 0;
            decimal _VL_RET_NC_SSA = 0;
            decimal _VL_OUT_DED_NC_SSA = 0;
            decimal _VL_CONT_NC_REC_SSA = 0;
            decimal _VL_TOT_CONT_CUM_PER_SSA = 0;
            decimal _VL_RET_CUM_SSA = 0;
            decimal _VL_OUT_DED_CUM_SSA = 0;
            decimal _VL_CONT_CUM_REC_SSA = 0;
            decimal _VL_TOT_CONT_REC_SSA = 0;

            decimal _VL_TOT_CONT_NC_PER = 0;
            decimal _VL_TOT_CRED_DESC = 0;
            decimal _VL_TOT_CRED_DESC_ANT = 0;
            decimal _VL_TOT_CONT_NC_DEV = 0;
            decimal _VL_RET_NC = 0;
            decimal _VL_OUT_DED_NC = 0;
            decimal _VL_CONT_NC_REC = 0;
            decimal _VL_TOT_CONT_CUM_PER = 0;
            decimal _VL_RET_CUM = 0;
            decimal _VL_OUT_DED_CUM = 0;
            decimal _VL_CONT_CUM_REC = 0;
            decimal _VL_TOT_CONT_REC = 0;

            string _M200_ToMerge = "";

            foreach (string item in _SAPFileTextFilled)
            {
                if (item.Substring(0, 6) == "|M600|")
                {
                    _M200_ToMerge = item;
                    string[] _Line = item.Split('|');
                    _VL_TOT_CONT_NC_PER_SAP = decimal.Parse(_Line[2]);
                    _VL_TOT_CRED_DESC_SAP = decimal.Parse(_Line[3]);
                    _VL_TOT_CRED_DESC_ANT_SAP = decimal.Parse(_Line[4]);
                    _VL_TOT_CONT_NC_DEV_SAP = decimal.Parse(_Line[5]);
                    _VL_RET_NC_SAP = decimal.Parse(_Line[6]);
                    _VL_OUT_DED_NC_SAP = decimal.Parse(_Line[7]);
                    _VL_CONT_NC_REC_SAP = decimal.Parse(_Line[8]);
                    _VL_TOT_CONT_CUM_PER_SAP = decimal.Parse(_Line[9]);
                    _VL_RET_CUM_SAP = decimal.Parse(_Line[10]);
                    _VL_OUT_DED_CUM_SAP = decimal.Parse(_Line[11]);
                    _VL_CONT_CUM_REC_SAP = decimal.Parse(_Line[12]);
                    _VL_TOT_CONT_REC_SAP = decimal.Parse(_Line[13]);
                    break;
                }
            }

            foreach (string item in _SSAFileTextFilled)
            {
                if (item.Substring(0, 6) == "|M600|")
                {
                    string[] _Line = item.Split('|');
                    _VL_TOT_CONT_NC_PER_SSA = decimal.Parse(_Line[2]);
                    _VL_TOT_CRED_DESC_SSA = decimal.Parse(_Line[3]);
                    _VL_TOT_CRED_DESC_ANT_SSA = decimal.Parse(_Line[4]);
                    _VL_TOT_CONT_NC_DEV_SSA = decimal.Parse(_Line[5]);
                    _VL_RET_NC_SSA = decimal.Parse(_Line[6]);
                    _VL_OUT_DED_NC_SSA = decimal.Parse(_Line[7]);
                    _VL_CONT_NC_REC_SSA = decimal.Parse(_Line[8]);
                    _VL_TOT_CONT_CUM_PER_SSA = decimal.Parse(_Line[9]);
                    _VL_RET_CUM_SSA = decimal.Parse(_Line[10]);
                    _VL_OUT_DED_CUM_SSA = decimal.Parse(_Line[11]);
                    _VL_CONT_CUM_REC_SSA = decimal.Parse(_Line[12]);
                    _VL_TOT_CONT_REC_SSA = decimal.Parse(_Line[13]);
                    break;
                }
            }

            _VL_TOT_CONT_NC_PER = _VL_TOT_CONT_NC_PER_SAP + _VL_TOT_CONT_NC_PER_SSA;
            _VL_TOT_CRED_DESC = _VL_TOT_CRED_DESC_SAP + _VL_TOT_CRED_DESC_SSA;
            _VL_TOT_CRED_DESC_ANT = _VL_TOT_CRED_DESC_ANT_SAP + _VL_TOT_CRED_DESC_ANT_SSA;
            _VL_TOT_CONT_NC_DEV = _VL_TOT_CONT_NC_DEV_SAP + _VL_TOT_CONT_NC_DEV_SSA;
            _VL_RET_NC = _VL_RET_NC_SAP + _VL_RET_NC_SSA;
            _VL_OUT_DED_NC = _VL_OUT_DED_NC_SAP + _VL_OUT_DED_NC_SSA;
            _VL_CONT_NC_REC = _VL_CONT_NC_REC_SAP + _VL_CONT_NC_REC_SSA;
            _VL_TOT_CONT_CUM_PER = _VL_TOT_CONT_CUM_PER_SAP + _VL_TOT_CONT_CUM_PER_SSA;
            _VL_RET_CUM = _VL_RET_CUM_SAP + _VL_RET_CUM_SSA;
            _VL_OUT_DED_CUM = _VL_OUT_DED_CUM_SAP + _VL_OUT_DED_CUM_SSA;
            _VL_CONT_CUM_REC = _VL_CONT_CUM_REC_SAP + _VL_CONT_CUM_REC_SSA;
            _VL_TOT_CONT_REC = _VL_TOT_CONT_REC_SAP + _VL_TOT_CONT_REC_SSA;

            StringBuilder _Sb = new StringBuilder();
            _Sb.Append("|");
            _Sb.Append("M600");
            _Sb.Append("|");
            _Sb.Append(_VL_TOT_CONT_NC_PER.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_TOT_CRED_DESC.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_TOT_CRED_DESC_ANT.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_TOT_CONT_NC_DEV.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_RET_NC.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_OUT_DED_NC.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_CONT_NC_REC.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_TOT_CONT_CUM_PER.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_RET_CUM.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_OUT_DED_CUM.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_CONT_CUM_REC.ToString());
            _Sb.Append("|");
            _Sb.Append(_VL_TOT_CONT_REC.ToString());
            _Sb.Append("|");

            _TextWriter.WriteLine(_Sb.ToString());

            CountBlock(_Sb.ToString());

            _ProcessCount++;
        }

        private void FillBlockMSevenHundred()
        {
            foreach (string item in _SAPFileTextFilled)
            {
                if (item.Substring(1, 2) == "M7")
                {
                    _TextWriter.WriteLine(item);
                    CountBlock(item);
                }
            }

            foreach (string item in _SSAFileTextFilled)
            {
                if (item.Substring(1, 2) == "M7")
                {
                    _TextWriter.WriteLine(item);
                    CountBlock(item);
                }
            }

            _ProcessCount++;
        }

        private void FillBlockMEightHundred()
        {
            foreach (string item in _SAPFileTextFilled)
            {
                if (item.Substring(1, 2) == "M8")
                {
                    _TextWriter.WriteLine(item);
                    CountBlock(item);
                }
            }

            foreach (string item in _SSAFileTextFilled)
            {
                if (item.Substring(1, 2) == "M8")
                {
                    _TextWriter.WriteLine(item);
                    CountBlock(item);
                }
            }

            _ProcessCount++;
        }

        private void CloseBlockM()
        {
            AccumulatorBlock("M990");
            _TextWriter.WriteLine(string.Format("|M990|{0}|", _ACUMULATOR_BLOCK_M));
            _ProcessCount++;
        }

        private void FillBlockOne() 
        {
            bool _IsABlock = false;
            bool _OpenBlock = false;

            foreach (string item in _SAPFileTextFilled)
            {
                string[] _Line = item.Split('|');

                if (_Line[1] == "1001")
                {
                    if (_Line[2] == "1")
                    {
                        _OpenBlock = false;
                        break;
                    }
                    else
                    {
                        _IsABlock = true;
                        _OpenBlock = true;
                    }
                }
                else if (_Line[1] == "1990")
                {
                    break;
                }

                if (_IsABlock)
                {
                    _TextWriter.WriteLine(item);
                    CountBlock(item);
                }
            }

            _IsABlock = false;

            foreach (string item in _SSAFileTextFilled)
            {
                string[] _Line = item.Split('|');

                if (_Line[1] == "1001")
                {
                    if (_Line[2] == "1")
                    {
                        _OpenBlock = false;
                        break;
                    }
                    else
                    {
                        _IsABlock = true;
                        _OpenBlock = true;
                    }
                }
                else if (_Line[1] == "1990")
                {
                    break;
                }

                if (_IsABlock)
                {
                    _TextWriter.WriteLine(item);
                    CountBlock(item);
                }
            }

            if (!_OpenBlock)
            {
                _TextWriter.WriteLine(string.Format("|1001|{0}|", 1));
                _TextWriter.WriteLine(string.Format("|1990|{0}|", 2));
            }
            else
            {
                CloseBlockOne();
            }

            _ProcessCount++;
        }

        private void CloseBlockOne() 
        {
            AccumulatorBlock("1990");
            _TextWriter.WriteLine(string.Format("|1990|{0}|", _ACUMULATOR_BLOCK_1));
            _ProcessCount++;
        }

        private void FillBlockNine() 
        {
            _TextWriter.WriteLine("|9001|0|");
            if (_0000Count > 0) { _TextWriter.WriteLine(string.Format("|9900|0000|{0}|", _0000Count)); _9900Count++; }
            if (_0001Count > 0) { _TextWriter.WriteLine(string.Format("|9900|0001|{0}|", _0001Count)); _9900Count++; }
            if (_0100Count > 0) { _TextWriter.WriteLine(string.Format("|9900|0100|{0}|", _0100Count)); _9900Count++; }
            if (_0110Count > 0) { _TextWriter.WriteLine(string.Format("|9900|0110|{0}|", _0110Count)); _9900Count++; }
            if (_0111Count > 0) { _TextWriter.WriteLine(string.Format("|9900|0111|{0}|", _0111Count)); _9900Count++; }
            if (_0140Count > 0) { _TextWriter.WriteLine(string.Format("|9900|0140|{0}|", _0140Count)); _9900Count++; }
            if (_0150Count > 0) { _TextWriter.WriteLine(string.Format("|9900|0150|{0}|", _0150Count)); _9900Count++; }
            if (_0190Count > 0) { _TextWriter.WriteLine(string.Format("|9900|0190|{0}|", _0190Count)); _9900Count++; }
            if (_0200Count > 0) { _TextWriter.WriteLine(string.Format("|9900|0200|{0}|", _0200Count)); _9900Count++; }
            if (_0205Count > 0) { _TextWriter.WriteLine(string.Format("|9900|0205|{0}|", _0205Count)); _9900Count++; }
            if (_0400Count > 0) { _TextWriter.WriteLine(string.Format("|9900|0400|{0}|", _0400Count)); _9900Count++; }
            if (_0450Count > 0) { _TextWriter.WriteLine(string.Format("|9900|0450|{0}|", _0450Count)); _9900Count++; }
            if (_0500Count > 0) { _TextWriter.WriteLine(string.Format("|9900|0500|{0}|", _0500Count)); _9900Count++; }
            if (_0600Count > 0) { _TextWriter.WriteLine(string.Format("|9900|0600|{0}|", _0600Count)); _9900Count++; }
            if (_ACUMULATOR_BLOCK_0 > 0) { _TextWriter.WriteLine(string.Format("|9900|0990|{0}|", 1)); _9900Count++; }
            //if (_ACUMULATOR_FILE > 0) { _TextWriter.WriteLine(string.Format("|9900|9999|{0}|", _ACUMULATOR_FILE)); _9900Count++; }
            if (_A001Count > 0) { _TextWriter.WriteLine(string.Format("|9900|A001|{0}|", _A001Count)); _9900Count++; }
            if (_A010Count > 0) { _TextWriter.WriteLine(string.Format("|9900|A010|{0}|", _A010Count)); _9900Count++; }
            if (_A100Count > 0) { _TextWriter.WriteLine(string.Format("|9900|A100|{0}|", _A100Count)); _9900Count++; }
            if (_A110Count > 0) { _TextWriter.WriteLine(string.Format("|9900|A110|{0}|", _A110Count)); _9900Count++; }
            if (_A170Count > 0) { _TextWriter.WriteLine(string.Format("|9900|A170|{0}|", _A170Count)); _9900Count++; }
            if (_ACUMULATOR_BLOCK_A > 0) { _TextWriter.WriteLine(string.Format("|9900|A990|{0}|", 1)); _9900Count++; }
            if (_C001Count > 0) { _TextWriter.WriteLine(string.Format("|9900|C001|{0}|", _C001Count)); _9900Count++; }
            if (_C010Count > 0) { _TextWriter.WriteLine(string.Format("|9900|C010|{0}|", _C010Count)); _9900Count++; }
            if (_C100Count > 0) { _TextWriter.WriteLine(string.Format("|9900|C100|{0}|", _C100Count)); _9900Count++; }
            if (_C110Count > 0) { _TextWriter.WriteLine(string.Format("|9900|C110|{0}|", _C110Count)); _9900Count++; }
            if (_C120Count > 0) { _TextWriter.WriteLine(string.Format("|9900|C120|{0}|", _C120Count)); _9900Count++; }
            if (_C170Count > 0) { _TextWriter.WriteLine(string.Format("|9900|C170|{0}|", _C170Count)); _9900Count++; }
            if (_C500Count > 0) { _TextWriter.WriteLine(string.Format("|9900|C500|{0}|", _C500Count)); _9900Count++; }
            if (_C501Count > 0) { _TextWriter.WriteLine(string.Format("|9900|C501|{0}|", _C501Count)); _9900Count++; }
            if (_C505Count > 0) { _TextWriter.WriteLine(string.Format("|9900|C505|{0}|", _C505Count)); _9900Count++; }
            if (_ACUMULATOR_BLOCK_C > 0) { _TextWriter.WriteLine(string.Format("|9900|C990|{0}|", 1)); _9900Count++; }
            if (_D001Count > 0) { _TextWriter.WriteLine(string.Format("|9900|D001|{0}|", _D001Count)); _9900Count++; }
            if (_D010Count > 0) { _TextWriter.WriteLine(string.Format("|9900|D010|{0}|", _D010Count)); _9900Count++; }
            if (_D100Count > 0) { _TextWriter.WriteLine(string.Format("|9900|D100|{0}|", _D100Count)); _9900Count++; }
            if (_D101Count > 0) { _TextWriter.WriteLine(string.Format("|9900|D101|{0}|", _D101Count)); _9900Count++; }
            if (_D105Count > 0) { _TextWriter.WriteLine(string.Format("|9900|D105|{0}|", _D105Count)); _9900Count++; }
            if (_D500Count > 0) { _TextWriter.WriteLine(string.Format("|9900|D500|{0}|", _D500Count)); _9900Count++; }
            if (_D501Count > 0) { _TextWriter.WriteLine(string.Format("|9900|D501|{0}|", _D501Count)); _9900Count++; }
            if (_D505Count > 0) { _TextWriter.WriteLine(string.Format("|9900|D505|{0}|", _D505Count)); _9900Count++; }
            if (_ACUMULATOR_BLOCK_D > 0) { _TextWriter.WriteLine(string.Format("|9900|D990|{0}|", 1)); _9900Count++; }
            if (_F001Count > 0) { _TextWriter.WriteLine(string.Format("|9900|F001|{0}|", _F001Count)); _9900Count++; }
            if (_F010Count > 0) { _TextWriter.WriteLine(string.Format("|9900|F010|{0}|", _F010Count)); _9900Count++; }
            if (_F120Count > 0) { _TextWriter.WriteLine(string.Format("|9900|F120|{0}|", _F120Count)); _9900Count++; }
            if (_ACUMULATOR_BLOCK_F > 0) { _TextWriter.WriteLine(string.Format("|9900|F990|{0}|", 1)); _9900Count++; }
            if (_M001Count > 0) { _TextWriter.WriteLine(string.Format("|9900|M001|{0}|", _M001Count)); _9900Count++; }
            if (_M100Count > 0) { _TextWriter.WriteLine(string.Format("|9900|M100|{0}|", _M100Count)); _9900Count++; }
            if (_M105Count > 0) { _TextWriter.WriteLine(string.Format("|9900|M105|{0}|", _M105Count)); _9900Count++; }
            if (_M200Count > 0) { _TextWriter.WriteLine(string.Format("|9900|M200|{0}|", _M200Count)); _9900Count++; }
            if (_M210Count > 0) { _TextWriter.WriteLine(string.Format("|9900|M210|{0}|", _M210Count)); _9900Count++; }
            if (_M400Count > 0) { _TextWriter.WriteLine(string.Format("|9900|M400|{0}|", _M400Count)); _9900Count++; }
            if (_M410Count > 0) { _TextWriter.WriteLine(string.Format("|9900|M410|{0}|", _M410Count)); _9900Count++; }
            if (_M500Count > 0) { _TextWriter.WriteLine(string.Format("|9900|M500|{0}|", _M500Count)); _9900Count++; }
            if (_M505Count > 0) { _TextWriter.WriteLine(string.Format("|9900|M505|{0}|", _M505Count)); _9900Count++; }
            if (_M600Count > 0) { _TextWriter.WriteLine(string.Format("|9900|M600|{0}|", _M600Count)); _9900Count++; }
            if (_M610Count > 0) { _TextWriter.WriteLine(string.Format("|9900|M610|{0}|", _M610Count)); _9900Count++; }
            if (_M800Count > 0) { _TextWriter.WriteLine(string.Format("|9900|M800|{0}|", _M800Count)); _9900Count++; }
            if (_M810Count > 0) { _TextWriter.WriteLine(string.Format("|9900|M810|{0}|", _M810Count)); _9900Count++; }
            if (_ACUMULATOR_BLOCK_M > 0) { _TextWriter.WriteLine(string.Format("|9900|M990|{0}|", 1)); _9900Count++; }
            if (_1001Count > 0) { _TextWriter.WriteLine(string.Format("|9900|1001|{0}|", _1001Count)); _9900Count++; }
            if (_1100Count > 0) { _TextWriter.WriteLine(string.Format("|9900|1100|{0}|", _1100Count)); _9900Count++; }
            if (_1500Count > 0) { _TextWriter.WriteLine(string.Format("|9900|1500|{0}|", _1500Count)); _9900Count++; }
            if (_ACUMULATOR_BLOCK_1 > 0) { _TextWriter.WriteLine(string.Format("|9900|1990|{0}|", 1)); _9900Count++; }
            if (_9001Count > 0) { _TextWriter.WriteLine(string.Format("|9900|9001|{0}|", _9001Count)); _9900Count++; }
            if (_9990Count > 0) { _TextWriter.WriteLine(string.Format("|9900|9990|{0}|", _9990Count)); _9900Count++; }
            if (_9999Count > 0) { _TextWriter.WriteLine(string.Format("|9900|9999|{0}|", _9999Count)); _9900Count++; }
            if (_9900Count > 0) { _9900Count++; _TextWriter.WriteLine(string.Format("|9900|9900|{0}|", _9900Count)); _9900Count++; }
            if (_9900Count > 0) { AccumulatorBlock("9990"); _TextWriter.WriteLine(string.Format("|9990|{0}|", _ACUMULATOR_BLOCK_9)); }
            CloseFile();
            _ProcessCount++;
        }

        private void CloseFile() 
        {
            AccumulatorBlock("9999");
            _TextWriter.WriteLine(string.Format("|9999|{0}|", _ACUMULATOR_FILE));
            _ProcessCount++;
        }

        private void CountBlock(string _Block) 
        {
            string[] _LineValues = _Block.Split('|');

            switch (_LineValues[1])
            {
                case "0000":
                    _0000Count++;
                    break;
                case "0001":
                    _0001Count++;
                    break;
                case "0100":
                    _0100Count++;
                    break;
                case "0110":
                    _0110Count++;
                    break;
                case "0111":
                    _0111Count++;
                    break;
                case "0140":
                    _0140Count++;
                    break;
                case "0150":
                    _0150Count++;
                    break;
                case "0190":
                    _0190Count++;
                    break;
                case "0200":
                    _0200Count++;
                    break;
                case "0205":
                    _0205Count++;
                    break;
                case "0400":
                    _0400Count++;
                    break;
                case "0450":
                    _0450Count++;
                    break;
                case "0500":
                    _0500Count++;
                    break;
                case "0600":
                    _0600Count++;
                    break;
                case "1001":
                    _1001Count++;
                    break;
                case "1100":
                    _1100Count++;
                    break;
                case "1500":
                    _1500Count++;
                    break;
                case "9001":
                    _9001Count++;
                    break;
                case "9900":
                    _9900Count++;
                    break;
                case "A001":
                    _A001Count++;
                    break;
                case "A010":
                    _A010Count++;
                    break;
                case "A100":
                    _A100Count++;
                    break;
                case "A110":
                    _A110Count++;
                    break;
                case "A170":
                    _A170Count++;
                    break;
                case "C001":
                    _C001Count++;
                    break;
                case "C010":
                    _C010Count++;
                    break;
                case "C100":
                    _C100Count++;
                    break;
                case "C110":
                    _C110Count++;
                    break;
                case "C120":
                    _C120Count++;
                    break;
                case "C170":
                    _C170Count++;
                    break;
                case "C500":
                    _C500Count++;
                    break;
                case "C501":
                    _C501Count++;
                    break;
                case "C505":
                    _C505Count++;
                    break;
                case "D001":
                    _D001Count++;
                    break;
                case "D010":
                    _D010Count++;
                    break;
                case "D100":
                    _D100Count++;
                    break;
                case "D101":
                    _D101Count++;
                    break;
                case "D105":
                    _D105Count++;
                    break;
                case "D500":
                    _D500Count++;
                    break;
                case "D501":
                    _D501Count++;
                    break;
                case "D505":
                    _D505Count++;
                    break;
                case "F001":
                    _F001Count++;
                    break;
                case "F010":
                    _F010Count++;
                    break;
                case "F100":
                    _F100Count++;
                    break;
                case "F120":
                    _F120Count++;
                    break;
                case "M001":
                    _M001Count++;
                    break;
                case "M100":
                    _M100Count++;
                    break;
                case "M105":
                    _M105Count++;
                    break;
                case "M200":
                    _M200Count++;
                    break;
                case "M210":
                    _M210Count++;
                    break;
                case "M400":
                    _M400Count++;
                    break;
                case "M410":
                    _M410Count++;
                    break;
                case "M500":
                    _M500Count++;
                    break;
                case "M505":
                    _M505Count++;
                    break;
                case "M600":
                    _M600Count++;
                    break;
                case "M610":
                    _M610Count++;
                    break;
                case "M800":
                    _M800Count++;
                    break;
                case "M810":
                    _M810Count++;
                    break;
                default:
                    break;
            }

            _ProcessCount++;
        }

        private void AccumulatorBlock(string _BlockClose)
        {
            switch (_BlockClose)
            {
                case "0990":
                    _0990Count++;
                    _ACUMULATOR_BLOCK_0 += _0990Count + _0000Count + _0001Count + _0100Count + _0110Count + _0111Count + _0140Count + _0150Count + _0190Count + _0200Count + _0205Count + _0400Count + _0450Count + _0500Count + _0600Count;
                    break;
                case "1990":
                    _1990Count++;
                    _ACUMULATOR_BLOCK_1 += _1990Count + _1001Count + _1100Count + _1500Count;
                    break;
                case "9990":
                    _ACUMULATOR_BLOCK_9 += _9990Count + _9999Count + _9001Count + _9900Count - 1;
                    break;
                case "9999":
                    _ACUMULATOR_FILE += _ACUMULATOR_BLOCK_0 + _ACUMULATOR_BLOCK_1 + _ACUMULATOR_BLOCK_9 + _ACUMULATOR_BLOCK_A + _ACUMULATOR_BLOCK_C + _ACUMULATOR_BLOCK_D + _ACUMULATOR_BLOCK_F + _ACUMULATOR_BLOCK_M;
                    break;
                case "A990":
                    _A990Count++;
                    _ACUMULATOR_BLOCK_A += _A990Count + _A001Count + _A010Count + _A100Count + _A110Count + _A170Count;
                    break;
                case "C990":
                    _C990Count++;
                    _ACUMULATOR_BLOCK_C += _C990Count + _C001Count + _C010Count + _C100Count + _C110Count + _C120Count + _C170Count + _C500Count + _C501Count + _C505Count;
                    break;
                case "D990":
                    _D990Count++;
                    _ACUMULATOR_BLOCK_D += _D990Count + _D001Count + _D010Count + _D100Count + _D101Count + _D105Count + _D500Count + _D501Count + _D505Count;
                    break;
                case "F990":
                    _F990Count++;
                    _ACUMULATOR_BLOCK_F += _F990Count + _F001Count + _F010Count + _F100Count + _F120Count;
                    break;
                case "M990":
                    _M990Count++;
                    _ACUMULATOR_BLOCK_M += _M990Count + _M001Count + _M100Count + _M105Count + _M200Count + _M210Count + _M400Count + _M410Count + _M500Count + _M505Count + _M600Count + _M610Count + _M800Count + _M810Count;
                    break;
                default:
                    break;
            }

            _ProcessCount++;
        }

        private void ClearCash() 
        {
            #region :::... Counters ...:::

             _0000Count = 0;
             _0001Count = 0;
             _0100Count = 0;
             _0110Count = 0;
             _0111Count = 0;
             _0140Count = 0;
             _0150Count = 0;
             _0190Count = 0;
             _0200Count = 0;
             _0205Count = 0;
             _0400Count = 0;
             _0450Count = 0;
             _0500Count = 0;
             _0600Count = 0;
             _0990Count = 0;
             _1001Count = 0;
             _1100Count = 0;
             _1500Count = 0;
             _1990Count = 0;
             _9001Count = 1;
             _9990Count = 1;
             _9999Count = 1;
             _A001Count = 0;
             _A010Count = 0;
             _A100Count = 0;
             _A110Count = 0;
             _A170Count = 0;
             _A990Count = 0;
             _C001Count = 0;
             _C010Count = 0;
             _C100Count = 0;
             _C110Count = 0;
             _C120Count = 0;
             _C170Count = 0;
             _C500Count = 0;
             _C501Count = 0;
             _C505Count = 0;
             _C990Count = 0;
             _D001Count = 0;
             _D010Count = 0;
             _D100Count = 0;
             _D101Count = 0;
             _D105Count = 0;
             _D500Count = 0;
             _D501Count = 0;
             _D505Count = 0;
             _D990Count = 0;
             _F001Count = 0;
             _F010Count = 0;
             _F100Count = 0;
             _F120Count = 0;
             _F990Count = 0;
             _M001Count = 0;
             _M100Count = 0;
             _M105Count = 0;
             _M200Count = 0;
             _M210Count = 0;
             _M400Count = 0;
             _M410Count = 0;
             _M500Count = 0;
             _M505Count = 0;
             _M600Count = 0;
             _M610Count = 0;
             _M800Count = 0;
             _M810Count = 0;
             _M990Count = 0;
             _9900Count = 0;

            #endregion

            #region :::... Accumulators ...:::

             _ACUMULATOR_BLOCK_0 = 0;
             _ACUMULATOR_BLOCK_A = 0;
             _ACUMULATOR_BLOCK_C = 0;
             _ACUMULATOR_BLOCK_D = 0;
             _ACUMULATOR_BLOCK_F = 0;
             _ACUMULATOR_BLOCK_M = 0;
             _ACUMULATOR_BLOCK_1 = 0;
             _ACUMULATOR_BLOCK_9 = 0;
             _ACUMULATOR_FILE = 0;

            #endregion

            _SSAFileTextFilled = null;
            _SAPFileTextFilled = null;
        }

        private void MergeFile() 
        {
            try
            {
                _SSAFileTextFilled = CustomLibrary.CreateInstance.GetListFromTextFile(txtLoadSSATXTFile.Text);
                _SAPFileTextFilled = CustomLibrary.CreateInstance.GetListFromTextFile(txtLoadSAPTXTFile.Text);

                // cria o objeto para escrever em um arquivo texto
                _TextWriter = File.CreateText(txtSaveFileMerge.Text);

                #region :::... Escreve o Bloco 0 no SPED ...:::

                FillZeroBlockHeader();
                FillZeroBlockOneHundredEleven();
                FillBlockZeroHundredFortyToHundredFifity();
                FillZeroBlockFiveHundred();
                FillBlockZeroSixHundred();
                CloseZeroBlock();

                #endregion

                #region :::... Escreve o Bloco A no SPED ...:::

                FillABlock();

                #endregion

                #region :::... Escreve o Bloco C no SPED ...:::

                FillCBlock();

                #endregion

                #region :::... Escreve o Bloco D no SPED ...:::

                FillDBlock();

                #endregion

                #region :::... Escreve o Bloco F no SPED ...:::

                FillFBlock();

                #endregion

                #region :::... Escreve o Bloco M no SPED ...:::

                FillBlockM(false);

                #endregion

                #region :::... Escreve o Bloco 1 no SPED ...:::

                FillBlockOne();

                #endregion

                #region :::... Escreve o Bloco 9 no SPED ...:::

                FillBlockNine();

                #endregion

                _TextWriter.Close();

                CustomLibrary.CreateInstance.ExecuteProgressBar(progressMerge, lblLoadDesc, _ProcessCount);

                DialogResult _Result = MessageBox.Show("Operação Concluída", "Operação concluída com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (_Result == DialogResult.OK)
                {
                    CustomLibrary.CreateInstance.ShowContentFile(txtSaveFileMerge.Text, "notepad.exe");
                    CustomLibrary.CreateInstance.ClearProgressBar(progressMerge, lblLoadDesc, _ProcessCount);
                    ClearCash();
                }
            }
            catch (Exception _Exception) 
            {
                throw _Exception;
                CustomLibrary.CreateInstance.AddException(_Exception);
            }
        }

        private void FillBlockM(bool _doWriteMBlock)
        {
            if (_doWriteMBlock)
            {
                FillBlockMHeader(true);
                FillBlockMOneHundred();
                FillBlockMTwoHundred();
                FillBlockMThreeHundred();
                FillBlockMFourHundred();
                FillBlockMFiveHundred();
                FillBlockMSixHundred();
                FillBlockMSevenHundred();
                FillBlockMEightHundred();
                CloseBlockM();
            }
            else 
            {
                FillBlockMHeader(false);
                CloseBlockM();
            }
        }

        #endregion

        #region :::... Events ...:::

        private void lnkLoadSSATXTFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadSSATXTFile();
        }

        private void lnkLoadSAPTXTFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadSAPTXTFile();
        }

        private void lnkSaveFielMerge_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileMerge();
        }

        private void btnCreateFileMerge_Click(object sender, EventArgs e)
        {
            MergeFile();
        }

        #endregion



        public string[] _Line { get; set; }
    }
}
