#region Using Directives

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace Fusion8.Cropper.Core
{
    public static class ControlExtensions
    {
        public static IEnumerable<Control> GetControlHierarchy(this Control root)
        {
            var queue = new Queue<Control>();

            queue.Enqueue(root);

            do
            {
                Control control = queue.Dequeue();

                yield return control;

                foreach (Control child in control.Controls.OfType<Control>())
                    queue.Enqueue(child);
            } while (queue.Count > 0);
        }
    }
}