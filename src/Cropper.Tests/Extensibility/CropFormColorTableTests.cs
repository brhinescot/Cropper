using System;
using System.Drawing;
using NUnit.Framework;

namespace Fusion8.Cropper.Extensibility
{
    [TestFixture]
    public class CropFormColorTableTests
    {
        [Test]
        public void TabAlphaChannel_is_200_by_default()
        {
            int expected = 200;

            FakeCropFormColorTable colorTable = new FakeCropFormColorTable();

            Assert.AreEqual(expected, colorTable.TabAlphaChannel);
        }

        private class FakeCropFormColorTable : CropFormColorTable
        {
            public override Color TabColor
            {
                get { throw new NotImplementedException(); }
            }

            public override Color TabHighlightColor
            {
                get { throw new NotImplementedException(); }
            }

            public override Color TabTextColor
            {
                get { throw new NotImplementedException(); }
            }

            public override Color TabTextHighlightColor
            {
                get { throw new NotImplementedException(); }
            }

            public override Color FormColor
            {
                get { throw new NotImplementedException(); }
            }

            public override Color FormHighlightColor
            {
                get { throw new NotImplementedException(); }
            }

            public override Color FormTextColor
            {
                get { throw new NotImplementedException(); }
            }

            public override Color FormTextHighlightColor
            {
                get { throw new NotImplementedException(); }
            }

            public override Color LineColor
            {
                get { throw new NotImplementedException(); }
            }

            public override Color LineHighlightColor
            {
                get { throw new NotImplementedException(); }
            }
        }
    }
}