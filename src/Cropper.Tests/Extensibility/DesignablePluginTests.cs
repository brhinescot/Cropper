#region Using Directives

using System;
using NUnit.Framework;

#endregion

namespace Fusion8.Cropper.Extensibility
{
    [TestFixture]
    public class DesignablePluginTests
    {
        private class FakeDesignablePlugin : DesignablePlugin
        {
            public override string Extension => throw new NotImplementedException();

            public override string Description => throw new NotImplementedException();

            protected override void ImageCaptured(object sender, ImageCapturedEventArgs e)
            {
                throw new NotImplementedException();
            }
        }

        [Test]
        public void Connect_throws_exception_when_IPersistableOutput_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new FakeDesignablePlugin().Connect(null));
        }
    }
}