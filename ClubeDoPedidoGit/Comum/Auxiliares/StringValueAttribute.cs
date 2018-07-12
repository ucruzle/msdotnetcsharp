using System;

namespace Comum.Auxiliares
{
    public class StringValueAttribute : Attribute
    {
        // Propriedades
        public string StringValue { get; protected set; }

        // Construtor
        public StringValueAttribute(string value)
        {
            StringValue = value;
        }
    }
}
