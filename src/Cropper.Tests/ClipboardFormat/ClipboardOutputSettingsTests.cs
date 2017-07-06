#region Using Directives

using NUnit.Framework;

#endregion

namespace Fusion8.Cropper
{
    [TestFixture]
    public class ClipboardOutputSettingsTests
    {
        [Test]
        public void Format_is_Bitmap_by_default()
        {
            ClipboardOutputFormat expected = ClipboardOutputFormat.Bitmap;

            ClipboardOutputSettings settings = new ClipboardOutputSettings();

            Assert.AreEqual(expected, settings.Format);
        }

        [Test]
        public void ImageQuality_is_80_by_default()
        {
            int expected = 80;

            ClipboardOutputSettings settings = new ClipboardOutputSettings();

            Assert.AreEqual(expected, settings.ImageQuality);
        }
    }
}