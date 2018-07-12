using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BrSoftNet.Library.Utilities
{
    public class SerializationData : UtilitiesFactory<SerializationData>
    {
        public string GetSerializableData(IList _Collection, string _CollectionName) 
        {
            string _Result = string.Empty;

            //Criar um Namespace para o XML
            XmlSerializerNamespaces xmlNamespace = new XmlSerializerNamespaces();
            //Adicionar um item vazio para remover o Namespace xsi, xsd do XML
            xmlNamespace.Add("", "");
            //Obviamente o XmlSerializerNamespaces serve para adicionar um novo namespace também.
            //A linha abaixo vai adicionar xsd no XML
            xmlNamespace.Add("namespace", "value");

            //Configurações do XML
            XmlWriterSettings settings = new XmlWriterSettings();
            //A linha abaixo omite a declaração do XML: <?xml version="1.0" encoding="utf-8"?>
            settings.OmitXmlDeclaration = true;
            //Definir a codificação do XML
            settings.Encoding = Encoding.UTF8;
            //Identar o XML automaticamente
            settings.Indent = true;

            //MemoryStream para colocar o XML em memória
            MemoryStream stream = new MemoryStream();

            //Usar o Create do XmlTextWriter para aplicar as configurações no XML
            XmlWriter writer = XmlTextWriter.Create(stream, settings);

            //Definir o Type e o elemento raiz do XML (contatos)
            XmlSerializer ser = new XmlSerializer(_Collection.GetType(), new XmlRootAttribute(_CollectionName));

            //Serializar o list, com o Namespace para o XmlWriter
            ser.Serialize(writer, _Collection, xmlNamespace);

            //Converter o XmlWriter para string
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, (int)stream.Length);
            _Result = Encoding.UTF8.GetString(stream.ToArray());

            return _Result;
        }

        public string GetSerializableData(Object _Object, string _CollectionName)
        {
            string _Result = string.Empty;

            //Criar um Namespace para o XML
            XmlSerializerNamespaces xmlNamespace = new XmlSerializerNamespaces();
            //Adicionar um item vazio para remover o Namespace xsi, xsd do XML
            xmlNamespace.Add("", "");
            //Obviamente o XmlSerializerNamespaces serve para adicionar um novo namespace também.
            //A linha abaixo vai adicionar xsd no XML
            xmlNamespace.Add("namespace", "value");

            //Configurações do XML
            XmlWriterSettings settings = new XmlWriterSettings();
            //A linha abaixo omite a declaração do XML: <?xml version="1.0" encoding="utf-8"?>
            settings.OmitXmlDeclaration = true;
            //Definir a codificação do XML
            settings.Encoding = Encoding.UTF8;
            //Identar o XML automaticamente
            settings.Indent = true;

            //MemoryStream para colocar o XML em memória
            MemoryStream stream = new MemoryStream();

            //Usar o Create do XmlTextWriter para aplicar as configurações no XML
            XmlWriter writer = XmlTextWriter.Create(stream, settings);

            //Definir o Type e o elemento raiz do XML (contatos)
            XmlSerializer ser = new XmlSerializer(_Object.GetType(), new XmlRootAttribute(_CollectionName));

            //Serializar o list, com o Namespace para o XmlWriter
            ser.Serialize(writer, _Object, xmlNamespace);

            //Converter o XmlWriter para string
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, (int)stream.Length);
            _Result = Encoding.UTF8.GetString(stream.ToArray());

            return _Result;
        }
    }
}
