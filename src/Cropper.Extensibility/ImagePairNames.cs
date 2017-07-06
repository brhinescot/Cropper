#region Using Directives

using System.Runtime.InteropServices;

#endregion

namespace Fusion8.Cropper.Extensibility
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImagePairNames
    {
        public string FullSize { get; }

        public string Thumbnail { get; }

        public ImagePairNames(string fullSize, string thumbnail) : this()
        {
            FullSize = fullSize;
            Thumbnail = thumbnail;
        }

        public static bool operator ==(ImagePairNames leftPair, ImagePairNames rightPair)
        {
            return leftPair.FullSize.Equals(rightPair.FullSize) && leftPair.Thumbnail.Equals(rightPair.Thumbnail);
        }

        public static bool operator !=(ImagePairNames leftPair, ImagePairNames rightPair)
        {
            return !(leftPair == rightPair);
        }

        public override int GetHashCode()
        {
            return FullSize.GetHashCode() + Thumbnail.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            ImagePairNames imagePair = (ImagePairNames) obj;

            return this == imagePair;
        }
    }
}