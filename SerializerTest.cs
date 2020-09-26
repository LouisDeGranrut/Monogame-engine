using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

namespace Serializer
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Création d'un objet
            MySerializableClass serializableClass = new MySerializableClass();
            serializableClass.ID = 1;
            serializableClass.MyDictionnary.Add("test1", 20);
            serializableClass.MyDictionnary.Add("test2", 350);
            for (int i = 0; i < 10; i++)
            {
                MySubClass subClass = new MySubClass() { Name = "Object " + i, Value = i * 10 };
                serializableClass.SubClasses.Add(subClass);
            }
            #endregion

            serializableClass.SaveToJson("MyFile");
            serializableClass.SaveToXml("MyFile");

            MySerializableClass fromXmlFile = MySerializableClass.OpenFromXml("MyFile");
            MySerializableClass fromJsonFile = MySerializableClass.OpenFromJson("MyFile");

            Console.Read();
        }
    }

    // Utilisé pour le XML.
    [Serializable()]
    [XmlRoot("SerializableClass")]
    // Utilisé pour le JSON.
    [DataContract]
    public class MySerializableClass
    {
        #region Propriétés
        // Utilisé pour le XML.
        // [XmlAttribute] Pas prévu par le sérialiseur de sérialiser un dictionnary en XML
        [XmlIgnore]
        // Utilisé pour le JSON.
        [DataMember]
        public Dictionary<string, int> MyDictionnary { get; private set; }

        // Utilisé pour le XML.
        [XmlAttribute]
        // Utilisé pour le JSON.
        [DataMember]
        public int ID { get; set; }

        // Utilisé pour le XML.
        [XmlElement]
        // Utilisé pour le JSON.
        [DataMember]
        public List<MySubClass> SubClasses { get; private set; }
        #endregion

        #region Constructeur
        public MySerializableClass()
        {
            MyDictionnary = new Dictionary<string, int>();
            SubClasses = new List<MySubClass>();
        }
        #endregion

        #region Sérialisation
        public void SaveToXml(string FileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(MySerializableClass));
            FileStream stream = File.Create(FileName + ".xml");
            ser.Serialize(stream, this);
            stream.Close();
        }

        public void SaveToJson(string FileName)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(MySerializableClass));
            FileStream stream = File.Create(FileName + ".json");
            ser.WriteObject(stream, this);
            stream.Close();
        }
        #endregion

        #region Désérialisation
        public static MySerializableClass OpenFromXml(string FileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(MySerializableClass));
            MemoryStream stream = new MemoryStream(File.ReadAllBytes(FileName + ".xml"));
            return (MySerializableClass)ser.Deserialize(stream);
        }

        public static MySerializableClass OpenFromJson(string FileName)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(MySerializableClass));
            MemoryStream stream = new MemoryStream(File.ReadAllBytes(FileName + ".json"));
            return (MySerializableClass)ser.ReadObject(stream);
        }
        #endregion
    }

    [Serializable()]
    [DataContract]
    public class MySubClass
    {
        [XmlAttribute]
        [DataMember]
        public string Name { get; set; }

        [XmlAttribute]
        [DataMember]
        public int Value { get; set; }
    }
}
