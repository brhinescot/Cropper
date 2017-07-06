#region Using Directives

using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper
{
    /// <summary>
    /// Summary description for PrinterOutput.
    /// </summary>
    public class PrinterOutput : DesignablePlugin
    {
        private Image capturedImage;

        public override string Extension
        {
            get { return "Printer"; }
        }

        public override string Description
        {
            get { return "Printer"; }
        }

        public override void Disconnect()
        {
            base.Disconnect();
            if (capturedImage != null)
                capturedImage.Dispose();
        }

        private void Print()
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printImage = new PrintDocument();

            printImage.DocumentName = "Cropper Captured Image";
            printImage.PrintPage += OnPrintPage;

            printDialog.Document = printImage;

            DialogResult result = printDialog.ShowDialog();

            // Send print message
            try
            {
                if (result == DialogResult.OK)
                    printImage.Print();
            }
            catch (InvalidPrinterException)
            {
                ShowPrintError();
            }
            finally
            {
                printImage.Dispose();
                printDialog.Dispose();
            }
        }

        // Print Event Handler
        //
        private void OnPrintPage(object sender, PrintPageEventArgs ppea)
        {
            try
            {
                PrintDocument document = (PrintDocument)sender;
                SizeF imageInches = CalculateSizeInInches(capturedImage);
                PointF originInches = CalculateOriginInInches(imageInches, document);
                ppea.Graphics.DrawImage(capturedImage, originInches.X, originInches.Y);
            }
            catch (InvalidPrinterException)
            {
                ShowPrintError();
            }
        }

        private static void ShowPrintError()
        {
            MessageBox.Show(
                "There was a problem printing the image.  Please verify you are able to " +
                "connect to the printer if it is on a network share.",
                "Printing Problem",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private static SizeF CalculateSizeInInches(Image image)
        {
            return new SizeF(
                image.Width / image.VerticalResolution,
                image.Height / image.HorizontalResolution);
        }

        private PointF CalculateOriginInInches(SizeF sizesInInches, PrintDocument document)
        {
            PointF point = new PointF();
            point.X = (((document.DefaultPageSettings.Bounds.Width / 100) -
                        sizesInInches.Width) / 2) * capturedImage.HorizontalResolution;
            point.Y = (((document.DefaultPageSettings.Bounds.Height / 100) -
                        sizesInInches.Height) / 2) * capturedImage.VerticalResolution;
            return point;
        }

        protected override void ImageCaptured(object sender, ImageCapturedEventArgs e)
        {
            capturedImage = e.FullSizeImage;
            Print();
        }
    }
}