using System;

namespace BrSoftNet.Log.Structures
{
    [Serializable]
    public class ChangeItem
    {
        public string IdChangeHeader { get; set; }
        public int IdItem { get; set; }
        public string NomeTabela { get; set; }
        public string NomeCampo { get; set; }
        public object ValorAntigo { get; set; }
        public object ValorNovo { get; set; }
    }
}
