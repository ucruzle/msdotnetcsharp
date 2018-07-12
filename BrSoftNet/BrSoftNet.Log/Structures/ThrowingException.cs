using System;

namespace BrSoftNet.Log.Structures
{
    [Serializable]
    public class ThrowingException
    {
        public string Id { get; set; }
        public string IdChangeHeader { get; set; }
        public string Formulario { get; set; }
        public string Tarefa { get; set; }
        public string FuncaoDisparador { get; set; }
        public string TipoExcecao { get; set; }
        public string MensagemExcecao { get; set; }
    }
}
