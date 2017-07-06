using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Fusion8.Cropper.Core 
{
    internal class HotKeyCache : IEnumerable<HotKeyData>
    {
        private readonly Dictionary<ushort, HotKeyData> identifierKeys = new Dictionary<ushort, HotKeyData>();
        private readonly Dictionary<Keys, HotKeyData> keyActions = new Dictionary<Keys, HotKeyData>();

        public Keys this[ushort atom] => identifierKeys.ContainsKey(atom) ? identifierKeys[atom].KeyData : Keys.None;

        public HotKeyData this[Keys keys] => keyActions.ContainsKey(keys) ? keyActions[keys] : null;

        public void Add(HotKeyData keyData, ushort globalAtom = 0)
        {
            if (globalAtom > 0)
            {
                if (identifierKeys.ContainsKey(globalAtom))
                    identifierKeys[globalAtom] = keyData;
                else
                    identifierKeys.Add(globalAtom, keyData);
            }

            if (keyActions.ContainsKey(keyData.KeyData))
                keyActions[keyData.KeyData] = keyData;
            else
                keyActions.Add(keyData.KeyData, keyData);
        }

        public void Remove(ushort atom)
        {
            if (!identifierKeys.ContainsKey(atom))
                return;

            keyActions.Remove(identifierKeys[atom].KeyData);
            identifierKeys.Remove(atom);
        }

        public void Remove(Keys keyData)
        {
            keyActions.Remove(keyData);
        }

        public ushort GetAtom(Keys keyData)
        {
            return (from pair in identifierKeys where pair.Value.KeyData == keyData select pair.Key).FirstOrDefault();
        }

        public IEnumerator<HotKeyData> GetEnumerator()
        {
            return keyActions.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}