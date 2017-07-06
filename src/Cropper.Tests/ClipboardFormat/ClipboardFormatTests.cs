#region Using Directives

using NUnit.Framework;

#endregion

namespace Fusion8.Cropper
{
    [TestFixture]
    public class ClipboardFormatTests
    {
        [Test]
        public void Description_is_Clipboard()
        {
            string expected = "Clipboard";

            ClipboardFormat format = new ClipboardFormat();

            Assert.AreEqual(expected, format.Description);
        }

        [Test]
        public void Extension_is_Clipboard()
        {
            string expected = "Clipboard";

            ClipboardFormat format = new ClipboardFormat();

            Assert.AreEqual(expected, format.Extension);
        }

        [Test]
        public void HostInOptions_is_true()
        {
            ClipboardFormat format = new ClipboardFormat();

            Assert.IsTrue(format.HostInOptions);
        }

        [Test]
        public void ToString_is_Clipboard_Format_Fusion8()
        {
            string expected = "Clipboard Format [Fusion8]";

            ClipboardFormat format = new ClipboardFormat();

            Assert.AreEqual(expected, format.ToString());
        }
    }
}