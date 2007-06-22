using Fusion8.Cropper.Extensibility;

namespace Fusion8.Cropper
{
    public partial class Options : BaseConfigurationForm
    {
        private ClipboardOutputFormat format = ClipboardOutputFormat.Bitmap;

        public ClipboardOutputFormat Format
        {
            get
            {
                if (radioPng.Checked)
                    format = ClipboardOutputFormat.Png;
                else if (radioJpg.Checked)
                    format = ClipboardOutputFormat.Jpg;
                else
                    format = ClipboardOutputFormat.Bitmap;

                return format;
            }
            set
            {
                format = value;
                if (format == ClipboardOutputFormat.Png)
                    radioPng.Checked = true;
                else if (format == ClipboardOutputFormat.Jpg)
                    radioJpg.Checked = true;
                else
                    radioBitmap.Checked = true;
            }
        }

        public int ImageQuality
        {
            get { return qualitySlider.Value; }
            set { qualitySlider.Value = value; }
        }

        public Options()
        {
            InitializeComponent();

            jpgDescription.Text = SR.JpgDescription;
            bitmapDescription.Text = SR.BitmapDescription;
            pngDescription.Text = SR.PngDescription;
            imageQuality.Text = SR.ImageQuality(ImageQuality);
        }

        private void HandleQualitySliderValueChanged(object sender, System.EventArgs e)
        {
            imageQuality.Text = SR.ImageQuality(ImageQuality);
        }
    }
}