#region Using Directives

using System.Collections.ObjectModel;
using Fusion8.Cropper.Extensibility;

#endregion

namespace Fusion8.Cropper.Core
{
    /// <summary>
    ///     Summary description for ImageOutputFormats.
    /// </summary>
    public class ImageOutputCollection : Collection<IPersistableImageFormat>
    {
        public IPersistableImageFormat this[string name]
        {
            get
            {
                IPersistableImageFormat returnFormat = null;
                foreach (IPersistableImageFormat imageFormat in this)
                    if (imageFormat.Description == name)
                        returnFormat = imageFormat;
                return returnFormat;
            }
        }
    }
}