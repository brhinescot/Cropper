#region Using Directives

using NUnit.Framework;

#endregion

namespace Fusion8.Cropper
{
    public class PrinterOutputTests
    {
        [Test]
        public void Extension_is_Printer()
        {
            string expected = "Printer";

            PrinterOutput format = new PrinterOutput();

            Assert.AreEqual(expected, format.Extension);
        }

        [Test]
        public void Description_is_Printer()
        {
            string expected = "Printer";

            PrinterOutput format = new PrinterOutput();

            Assert.AreEqual(expected, format.Description);
        }
    }
}