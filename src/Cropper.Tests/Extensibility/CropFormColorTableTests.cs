#region Using Directives

using System;
using System.Drawing;
using NUnit.Framework;

#endregion

namespace Fusion8.Cropper.Extensibility
{
    [TestFixture]
    public class CropFormColorTableTests
    {
        private class FakeCropFormColorTable : CropFormColorTable
        {
            public override Color TabColor => throw new NotImplementedException();

            public override Color TabHighlightColor => throw new NotImplementedException();

            public override Color TabTextColor => throw new NotImplementedException();

            public override Color TabTextHighlightColor => throw new NotImplementedException();

            public override Color FormColor => throw new NotImplementedException();

            public override Color FormHighlightColor => throw new NotImplementedException();

            public override Color FormTextColor => throw new NotImplementedException();

            public override Color FormTextHighlightColor => throw new NotImplementedException();

            public override Color LineColor => throw new NotImplementedException();

            public override Color LineHighlightColor => throw new NotImplementedException();
        }

        [Test]
        public void TabAlphaChannel_is_200_by_default()
        {
            int expected = 200;

            FakeCropFormColorTable colorTable = new FakeCropFormColorTable();

            Assert.AreEqual(expected, colorTable.TabAlphaChannel);
        }
    }
}