namespace Fusion8.Cropper
{
    public class JpegSettings
    {
        private string extension;

        public string Extension
        {
            get
            {
                if (extension == null)
                    extension = "jpg";
                return extension;
            }
            set { extension = value; }
        }
    }
}