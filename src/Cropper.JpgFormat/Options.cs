using Fusion8.Cropper.Extensibility;

namespace Fusion8.Cropper
{
    public partial class JpegOptions : BaseConfigurationForm
    {
        public string Extension
        {
            get { return extension.Text; }
            set { extension.Text = value; }
        }

        public JpegOptions()
        {
            InitializeComponent();
        }
    }
}