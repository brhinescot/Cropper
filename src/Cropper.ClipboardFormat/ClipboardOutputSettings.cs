namespace Fusion8.Cropper
{
    public class ClipboardOutputSettings
    {
        private int imageQuality = 80;
        private ClipboardOutputFormat format;

        public int ImageQuality
        {
            get { return imageQuality; }
            set { imageQuality = value; }
        }

        public ClipboardOutputFormat Format
        {
            get { return format; }
            set { format = value; }
        }
    }
}