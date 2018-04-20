#region Using Directives

using System;
using System.Drawing;
using System.Windows.Forms;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper
{
    public partial class JpegOptions : BaseConfigurationForm
    {
        public string Extension
        {
            get => radioJpeg.Checked ? "jpeg" : "jpg";
            set
            {
                switch (value) {
                    case "jpeg":
                        radioJpeg.Checked = true;
                        break;
                    default:
                        radioJpg.Checked = true;
                        break;
                }
            }
        }

        public JpegOptions()
        {
            InitializeComponent();
        }
    }
}