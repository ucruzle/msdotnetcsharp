using System;

namespace BrSoftNet.Log.Structures
{
    [Serializable]
    public class ChangesHeader
    {
        public string Id { get; set; }
        public int CodigoRegistro { get; set; }
        public string NomeProcesso { get; set; }
        public string TipoModificacao { get; set; }
        public string Usuario { get; set; }
        public DateTime DataHora { get; set; }
        public string StatusExecucao { get; set; }
    }
}
