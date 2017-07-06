#region Using Directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace Fusion8.Cropper.Core
{
    public static class HotKeys
    {
        private const string RegistrationSuffix = "CropperHotKeys";
        private const Keys ModifierKeys = Keys.Alt | Keys.Control | Keys.Shift;

        private static readonly HotKeyCache Cache = new HotKeyCache();

        public static IEnumerable<HotKeyData> GetRegisteredHotKeys(bool includeHidden = false)
        {
            return Cache.Where(data => includeHidden || !data.Hide);
        }

        public static void UpdateHotKey(string id, Keys keyData)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            HotKeyData data = Cache.FirstOrDefault(hkd => hkd.Id == id);
            if (data == null)
                return;

            Cache.Remove(data.KeyData);
            data.KeyData = keyData;
            Cache.Add(data);
        }

        public static void RegisterGlobal(string id, Keys keyData, IWin32Window window, string name, Action action, bool hide = false, string groupName = null)
        {
            RegisterGlobal(new HotKeyData(id, name, keyData, action, true, hide, groupName), window);
        }

        public static void RegisterLocal(string id, Keys keyData, string name, Action action, bool hide = false, string groupName = null)
        {
            RegisterLocal(new HotKeyData(id, name, keyData, action, false, hide, groupName));
        }

        public static void Unregister(Keys keyData, IWin32Window window)
        {
            ushort atom = Cache.GetAtom(keyData);
            if (atom != 0)
            {
                NativeMethods.GlobalDeleteAtom(atom);
                NativeMethods.UnregisterHotKey(window.Handle, atom);

                Cache.Remove(atom);
            }
            else
            {
                Cache.Remove(keyData);
            }
        }

        public static void Process(Keys keyData)
        {
            if (keyData == Keys.None)
                return;

            HotKeyData data = Cache[keyData];
            data?.Invoke();
        }

        public static Keys GetKeyData(IntPtr atom)
        {
            return Cache[(ushort) atom];
        }

        private static void RegisterGlobal(HotKeyData keyData, IWin32Window window)
        {
            Keys keys = keyData.KeyData;

            ushort atom = NativeMethods.GlobalAddAtom(RegistrationSuffix + keys + DateTime.Now.Ticks);

            NativeMethods.RegisterHotKey(window.Handle, atom, GetModifierFlag(keys), (int) (keys & ~ModifierKeys));

            Cache.Add(keyData, atom);
        }

        private static void RegisterLocal(HotKeyData keyData)
        {
            Cache.Add(keyData);
        }

        private static uint GetModifierFlag(Keys keys)
        {
            uint modifier = 0;
            if ((keys & Keys.Alt) == Keys.Alt)
                modifier |= NativeMethods.MOD_ALT;
            if ((keys & Keys.Control) == Keys.Control)
                modifier |= NativeMethods.MOD_CONTROL;
            if ((keys & Keys.Shift) == Keys.Shift)
                modifier |= NativeMethods.MOD_SHIFT;
            return modifier;
        }
    }
}