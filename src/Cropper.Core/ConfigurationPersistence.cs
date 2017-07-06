#region Using Directives

using System;
using System.IO;
using System.Xml.Serialization;

#endregion

namespace Fusion8.Cropper.Core
{
    internal class ConfigurationPersistence<T>
    {
        private static XmlSerializer serializer;

        #region .ctors

        public ConfigurationPersistence(string xmlRootName, string rootNamespace, params Type[] additionalTypes)
        {
            XmlRootName = xmlRootName;
            RootNamespace = rootNamespace;
            serializer = CreateSerializer(additionalTypes);
        }

        #endregion

        public void Save(string path, T objectToSave)
        {
            using (TextWriter textWriter = new StreamWriter(path))
            {
                serializer.Serialize(textWriter, objectToSave);
            }
        }

        public T Load(string path)
        {
            using (TextReader textReader = new StreamReader(path))
            {
                return (T) serializer.Deserialize(textReader);
            }
        }

        private XmlSerializer CreateSerializer(params Type[] additionalTypes)
        {
            XmlRootAttribute rootAttribute = null;

            if (XmlRootName != null)
                rootAttribute = new XmlRootAttribute(XmlRootName) {Namespace = RootNamespace};

            return new XmlSerializer(typeof(T), null, additionalTypes, rootAttribute, RootNamespace);
        }

        #region Member Fields

        #endregion

        #region Property Accessors

        public string XmlRootName { get; set; }

        public string RootNamespace { get; set; }

        #endregion
    }
}