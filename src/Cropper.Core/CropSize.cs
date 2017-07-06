using System;

namespace Fusion8.Cropper.Core
{
    public struct CropSize : IEquatable<CropSize>, IComparable<CropSize>
    {
        public int Width { get; }

        public int Height { get; }

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
    }
}