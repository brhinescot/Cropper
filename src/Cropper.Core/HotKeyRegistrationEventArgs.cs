using System;
using System.Windows.Forms;

namespace Fusion8.Cropper.Core {
    public class HotKeyRegistrationEventArgs : EventArgs
    {
        public Keys KeyData { get; }
        public Keys OldKeyData { get; }
        public bool Global { get; set; }
        public Action Action { get; }
        public string Name { get; }
        public string Id { get; set; }

        public HotKeyRegistrationEventArgs(string id, string name, Keys keyData, Action action, Keys oldKeyData, bool global)
        {
            Id = id;
            KeyData = keyData;
            Action = action;
            OldKeyData = oldKeyData;
            Global = global;
            Name = name;
        }
    }
}