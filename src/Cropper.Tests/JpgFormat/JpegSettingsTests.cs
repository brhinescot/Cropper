#region Using Directives

using NUnit.Framework;

#endregion

namespace Fusion8.Cropper
{
    [TestFixture]
    public class JpegSettingsTests
    {
        [Test]
        public void Extension_defaults_back_to_jpg_when_nullified()
        {
            string expected = "jpg";

            JpegSettings settings = new JpegSettings();
            settings.Extension = null;

            Assert.AreEqual(expected, settings.Extension);
        }

        [Test]
        public void Extension_is_jpg_by_default()
        {
            string expected = "jpg";

            JpegSettings settings = new JpegSettings();

            Assert.AreEqual(expected, settings.Extension);
        }

        [Test]
        public void Extension_property_is_not_altered()
        {
            string extension = "extension";

            JpegSettings settings = new JpegSettings();
            settings.Extension = extension;

            Assert.AreEqual(extension, settings.Extension);
        }
    }
}