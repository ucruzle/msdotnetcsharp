
namespace MergeEfdPisCofins.Entities
{
    public class BlockMHundred : Bean
    {
        #region :::... Methods ...:::

        public BlockMHundred() { }

        public BlockMHundred(string[] _Line) 
        {
            REG = _Line[1];
            COD_CRED = _Line[2];
            IND_CRED_ORI = string.IsNullOrEmpty(_Line[3]) ? decimal.Parse("0") : decimal.Parse(_Line[3]);
            VL_BC_PIS = string.IsNullOrEmpty(_Line[4]) ? decimal.Parse("0") : decimal.Parse(_Line[4]);
            ALIQ_PIS = string.IsNullOrEmpty(_Line[5]) ? decimal.Parse("0") : decimal.Parse(_Line[5]);
            QUAT_BC_PIS = int.Parse(_Line[6]);
            ALIQ_PIS_QUANT = string.IsNullOrEmpty(_Line[7]) ? decimal.Parse("0") : decimal.Parse(_Line[7]);
            VL_CRED = string.IsNullOrEmpty(_Line[8]) ? decimal.Parse("0") : decimal.Parse(_Line[8]);
            VL_AJUS_ACRES = string.IsNullOrEmpty(_Line[9]) ? decimal.Parse("0") : decimal.Parse(_Line[9]);
            VL_AJUS_REDUC = string.IsNullOrEmpty(_Line[10]) ? decimal.Parse("0") : decimal.Parse(_Line[10]);
            VL_CRED_DIF = string.IsNullOrEmpty(_Line[11]) ? decimal.Parse("0") : decimal.Parse(_Line[11]);
            VL_CRED_DISP = string.IsNullOrEmpty(_Line[12]) ? decimal.Parse("0") : decimal.Parse(_Line[12]);
            IND_DESC_CRED = _Line[13];
            VL_CRED_DESC = string.IsNullOrEmpty(_Line[14]) ? decimal.Parse("0") : decimal.Parse(_Line[14]);
            SLD_CRED = string.IsNullOrEmpty(_Line[15]) ? decimal.Parse("0") : decimal.Parse(_Line[15]);
        }

        #endregion

        #region :::... Properties ...:::

        public string REG { get; set; }
        public string COD_CRED { get; set; }
        public decimal IND_CRED_ORI { get; set; }
        public decimal VL_BC_PIS { get; set; }
        public decimal ALIQ_PIS { get; set; }
        public int QUAT_BC_PIS { get; set; }
        public decimal VL_CRED { get; set; }
        public decimal VL_AJUS_ACRES { get; set; }
        public decimal VL_AJUS_REDUC { get; set; }
        public decimal VL_CRED_DIF { get; set; }
        public decimal VL_CRED_DISP { get; set; }
        public string IND_DESC_CRED { get; set; }
        public decimal VL_CRED_DESC { get; set; }
        public decimal SLD_CRED { get; set; }
        public decimal ALIQ_PIS_QUANT { get; set; }

        #endregion
    }
}
