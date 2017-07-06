#region Using Directives

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

#endregion

namespace Fusion8.Cropper.Core
{
    public struct CropSize : IEquatable<CropSize>, IComparable<CropSize>, IXmlSerializable
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public CropSize(int width, int height) : this()
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{Width} x {Height}";
        }

        public bool Equals(CropSize other)
        {
            return other.Width == Width && other.Height == Height;
        }

        public int CompareTo(CropSize other)
        {
            return Width - other.Width != 0 ? Width - other.Width : Height - other.Height;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is CropSize)) return false;
            CropSize cropSize = (CropSize) obj;
            return Width == cropSize.Width && Height == cropSize.Height;
        }

        public override int GetHashCode()
        {
            return Width + 29 * Height;
        }

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            Width = Convert.ToInt32(reader.GetAttribute("Width"));
            Height = Convert.ToInt32(reader.GetAttribute("Height"));
            reader.Read();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Width", Width.ToString());
            writer.WriteAttributeString("Height", Height.ToString());
        }
    }
}