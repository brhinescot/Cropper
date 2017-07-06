using System;
using NUnit.Framework;

namespace Fusion8.Cropper.Extensibility
{
    [TestFixture]
    public class DesignablePluginTests
    {
        [Test]
        public void Connect_throws_exception_when_IPersistableOutput_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new FakeDesignablePlugin().Connect(null));
        }

        private class FakeDesignablePlugin : DesignablePlugin
        {
            protected override void ImageCaptured(object sender, ImageCapturedEventArgs e)
            {
                throw new NotImplementedException();
            }

            public override string Extension
            {
                get { throw new NotImplementedException(); }
            }

            public override string Description
            {
                get { throw new NotImplementedException(); }
            }
        }
    }
}