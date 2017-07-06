using System.Drawing.Imaging;
using NUnit.Framework;

namespace Fusion8.Cropper
{
    [TestFixture]
    public class PngFormatTests
    {
        [Test]
        public void Extension_is_png()
        {
            string expected = "png";

            PngFormat format = new PngFormat();

            Assert.AreEqual(expected, format.Extension);
        }

        [Test]
        public void Description_is_Png()
        {
            string expected = "Png";

            PngFormat format = new PngFormat();

            Assert.AreEqual(expected, format.Description);
        }

        [Test]
        public void Format_is_Png()
        {
            ImageFormat expected = ImageFormat.Png;

            FakePngFormat format = new FakePngFormat();

            Assert.AreEqual(expected, format.FormatValue);
        }

        private class FakePngFormat : PngFormat
        {
            public ImageFormat FormatValue
            {
                get { return Format; }
            }
        }
    }
}