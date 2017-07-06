namespace Fusion8.Cropper
{
    public class JpegSettings
    {
        private string extension;

        public string Extension
        {
            get => extension ?? (extension = "jpg");
            set => extension = value;
        }
    }
}