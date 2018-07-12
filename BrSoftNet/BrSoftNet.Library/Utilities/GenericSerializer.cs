using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BrSoftNet.Library.Utilities
{
    public class GenericSerializer<T> where T : new()
    {
        public string GenSerializer(T Obj)
        {
            XmlSerializer customSerializer = null;
            MemoryStream ms1 = null;
            XmlTextWriter xmlWriter = null;
            XmlDocument xmlDoc = null;
            XmlNodeList emptyNodes = null;
            MemoryStream ms2 = null;
            string ret = "";

            try
            {
                //definição do tipo de objeto que o XmlSerializer trabalhará.
                customSerializer = new XmlSerializer(typeof(T));

                //instanciando um MemoryStrem que receberá o resultado da serialização
                using (ms1 = new MemoryStream())
                {
                    xmlWriter = new XmlTextWriter(ms1, Encoding.UTF8);
                    customSerializer.Serialize(xmlWriter, Obj);

                    //instanciando um outro MemoryStream que será utilizado para criar em tempo de execução um XmlDocument
                    using (ms2 = (MemoryStream)xmlWriter.BaseStream)
                    {
                        ms2.Position = 0;
                        xmlDoc = new XmlDocument();
                        xmlDoc.Load(ms2);

                        //Verifica se houve algum erro na serialização que possa fazer  que o XmlDocument esteja nulo ou vazio
                        if (xmlDoc != null && xmlDoc.HasChildNodes)
                        {
                            //Esse bloco de comando remove nodes vazios do XmlDocument
                            emptyNodes = xmlDoc.SelectNodes(@"//*[not(node())]");
                            if (emptyNodes.Count > 0)
                            {
                                for (int i = emptyNodes.Count - 1; i >= 0; i--)
                                {
                                    emptyNodes[i].ParentNode.RemoveChild(emptyNodes[i]);
                                }
                            }

                            //bloco que retira alguns nodes indesejados
                            ret = xmlDoc.InnerXml;
                            ret = ret.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", "").Trim();
                            ret = ret.Replace(" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "").Trim();
                            ret = ret.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "").Trim();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                customSerializer = null;
                ms1 = null;
                xmlWriter = null;
                xmlDoc = null;
                emptyNodes = null;
                ms2 = null;
            }
            return ret;
        }

        public T GenDeserializer(string pXML)
        {
            UTF8Encoding encoding = null;
            XmlDocument xmlDoc = null;
            MemoryStream ms1 = null;
            XmlSerializer customSerializer = null;
            T Obj = default(T);
            try
            {
                xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(pXML);

                encoding = new UTF8Encoding();
                using (ms1 = new MemoryStream(encoding.GetBytes(xmlDoc.InnerXml)))
                {
                    ms1.Position = 0;
                    customSerializer = new XmlSerializer(typeof(T));
                    Obj = (T)customSerializer.Deserialize(ms1);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                encoding = null;
                xmlDoc = null;
                ms1 = null;
                customSerializer = null;
            }
            return Obj;
        }
    }
}
