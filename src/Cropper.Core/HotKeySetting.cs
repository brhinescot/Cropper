namespace Fusion8.Cropper.Core
{
    public class HotKeySetting
    {
        public HotKeyAction Action { get; set; }
        public string KeyCode { get; set; }
        public bool Global { get; set; }

        public HotKeySetting() { }

        public HotKeySetting(HotKeyAction action, bool global, string keyCode)
        {
            Action = action;
            Global = global;
            KeyCode = keyCode;
        }
    }
}