using System.Diagnostics;

namespace Fusion8.Cropper.Core {
    [DebuggerDisplay("Keys={((Keys)KeyCode).ToString()}")]
    public class HotKeySetting
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int KeyCode { get; set; }
    }
}