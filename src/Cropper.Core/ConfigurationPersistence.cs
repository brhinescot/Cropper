#region Using Directives

using System;
using System.IO;
using System.Xml.Serialization;

#endregion

namespace Fusion8.Cropper.Core
{
    internal class ConfigurationPersistence<T>
    {
        #region Member Fields

        private string xmlRootName;
        private string rootNamespace;

        #endregion

        #region Property Accessors

        public string XmlRootName
        {
            get => xmlRootName;
            set => xmlRootName = value;
        }

        public string RootNamespace
        {
            get => rootNamespace;
            set => rootNamespace = value;
        }

        #endregion

        private static XmlSerializer serializer;

        #region .ctors

        public ConfigurationPersistence(string xmlRootName, string rootNamespace, params Type[] additionalTypes)
        {
            this.xmlRootName = xmlRootName;
            this.rootNamespace = rootNamespace;
            serializer = CreateSerializer(additionalTypes);
        }

        #endregion

        public void Save(string path, T objectToSave)
        {
            using (TextWriter textWriter = new StreamWriter(path))
                serializer.Serialize(textWriter, objectToSave);
        }

        public T Load(string path)
        {
            using (TextReader textReader = new StreamReader(path))
                return (T)serializer.Deserialize(textReader);
        }

        private XmlSerializer CreateSerializer(params Type[] additionalTypes)
        {
            XmlRootAttribute rootAttribute = null;

            if (xmlRootName != null)
            {
                rootAttribute = new XmlRootAttribute(xmlRootName) {Namespace = rootNamespace};
            }

            return new XmlSerializer(typeof(T), null, additionalTypes, rootAttribute, rootNamespace);
        }
    }
}