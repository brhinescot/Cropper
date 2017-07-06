using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Fusion8.Cropper.Core 
{
    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("{Name} = {KeyData.ToString(), nq} [{(Global) ? \"global\" : \"local\", nq}]")]
    public class HotKeyData
    {
        /// <summary>
        /// 
        /// </summary>
        public Keys KeyData { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        public Action Action { get; }

        /// <summary>
        /// 
        /// </summary>
        public bool Global { get; }

        /// <summary>
        /// 
        /// </summary>
        public bool Hide { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Group { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"> </param>
        /// <param name="name"></param>
        /// <param name="keyData"></param>
        /// <param name="action"></param>
        /// <param name="global"></param>
        /// <param name="hide"></param>
        /// <param name="group"> </param>
        public HotKeyData(string id, string name, Keys keyData, Action action, bool global = false, bool hide = false, string group = null)
        {
            Id = id;
            Name = name;
            KeyData = keyData;
            Action = action;
            Global = global;
            Hide = hide;
            Group = group;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Invoke()
        {
            Action.DynamicInvoke();
        }
    }
}