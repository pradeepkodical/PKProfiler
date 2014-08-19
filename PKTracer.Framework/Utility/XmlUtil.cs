using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace PKTracer.Framework.Utility
{
    public class XmlUtil
    {
        public static string SerializeObject(object item)
        {
            StringBuilder builder = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            XmlSerializer serializer = new XmlSerializer(item.GetType());
            using (XmlWriter writer = XmlWriter.Create(builder, settings))
            {
                serializer.Serialize(writer, item);
            }
            return builder.ToString();
        }

        public static T Deserialize<T>(string strXML)
        {
            object obj = null;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlReaderSettings settings = new XmlReaderSettings();
            using (StringReader stringReader = new StringReader(strXML))
            {
                using (XmlReader xmlReader = XmlReader.Create(stringReader, settings))
                {
                    obj = serializer.Deserialize(xmlReader);

                }
            }
            return (T)obj;
        }
    }
}
