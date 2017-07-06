#region Using Directives

using System.Drawing.Imaging;
using NUnit.Framework;

#endregion

namespace Fusion8.Cropper
{
    [TestFixture]
    public class BmpFormatTests
    {
        private class FakeBmpFormat : BmpFormat
        {
            public ImageFormat FormatValue => Format;
        }

        [Test]
        public void Description_is_Bmp()
        {
            string expected = "Bmp";

            BmpFormat format = new BmpFormat();

            Assert.AreEqual(expected, format.Description);
        }

        [Test]
        public void Extension_is_bmp()
        {
            string expected = "bmp";

            BmpFormat format = new BmpFormat();

            Assert.AreEqual(expected, format.Extension);
        }

        [Test]
        public void Format_is_Bmp()
        {
            ImageFormat expected = ImageFormat.Bmp;

            FakeBmpFormat format = new FakeBmpFormat();

            Assert.AreEqual(expected, format.FormatValue);
        }
    }
}