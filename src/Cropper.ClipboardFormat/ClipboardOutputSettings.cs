namespace Fusion8.Cropper
{
    public class ClipboardOutputSettings
    {
        public ClipboardOutputSettings()
        {
            ImageQuality = 80;
        }

        public int ImageQuality { get; set; }

        public ClipboardOutputFormat Format { get; set; }
    }
}