using System;
namespace Fusion8.Cropper.Core
{
    public struct CropSize : IEquatable<CropSize>, IComparable<CropSize>
    {
        private int width;
        private int height;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public CropSize(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public override string ToString()
        {
            return string.Format("{0} x {1}", width, height);
        }

        public bool Equals(CropSize other)
        {
            return (other.Width == Width && other.Height == Height) ;
        }

        public int CompareTo(CropSize other)
        {
            return (Width - other.Width != 0) ? (Width - other.Width) : (Height - other.Height);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is CropSize)) return false;
            CropSize cropSize = (CropSize) obj;
            return width == cropSize.width && height == cropSize.height;
        }

        public override int GetHashCode()
        {
            return width + 29*height;
        }
    }
}