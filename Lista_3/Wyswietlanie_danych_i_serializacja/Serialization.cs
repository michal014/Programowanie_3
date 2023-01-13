using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace Wyswietlanie_danych_i_serializacja
{
    class Serialization
    {
        public static Person DeserializeToObject<Person>(string path) 
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using (StreamReader sr = new StreamReader(path))
            {
                return (Person)serializer.Deserialize(sr);
            }
        }

        public static void SerializeToXml<Person>(Person obj, string xmlPath)
        {
            XmlSerializer Serializer2 = new XmlSerializer(typeof(Person));
            using (StreamWriter sw = File.CreateText(xmlPath))
            {
                Serializer2.Serialize(sw, obj);
            }
        }
    }
}
