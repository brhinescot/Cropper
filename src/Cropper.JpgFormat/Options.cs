#region Using Directives

using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper
{
    public partial class JpegOptions : BaseConfigurationForm
    {
        public JpegOptions()
        {
            InitializeComponent();
        }

        public string Extension
        {
            get => extension.Text;
            set => extension.Text = value;
        }
    }
}