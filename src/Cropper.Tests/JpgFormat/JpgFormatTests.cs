#region Using Directives

using NUnit.Framework;

#endregion

namespace Fusion8.Cropper
{
    [TestFixture]
    public class JpgFormatTests
    {
        [Test]
        public void Description_is_Jpeg()
        {
            string expected = "Jpeg";

            JpgFormat format = new JpgFormat();

            Assert.AreEqual(expected, format.Description);
        }

        [Test]
        public void Extension_is_jpg()
        {
            string expected = "jpg";

            JpgFormat format = new JpgFormat();

            Assert.AreEqual(expected, format.Extension);
        }

        [Test]
        public void HostInOptions_is_true()
        {
            JpgFormat format = new JpgFormat();

            Assert.IsTrue(format.HostInOptions);
        }

        [Test]
        public void ToString_is_Jpeg_Format_Fusion8_()
        {
            string expected = "Jpeg Format [Fusion8] ";

            JpgFormat format = new JpgFormat();

            Assert.AreEqual(expected, format.ToString());
        }
    }
}