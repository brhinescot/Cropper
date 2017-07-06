#region Using Directives

using System;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

#endregion

namespace Fusion8.Cropper.Core
{
    /// <summary>
    ///     The button that opens <see cref="UITypeEditor" /> controls.
    /// </summary>
    public class DropDownButton : Button
    {
        private bool hover;
        private bool pushed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DropDownButton" /> class.
        /// </summary>
        public DropDownButton()
        {
            Initialize();
        }

        private void Initialize()
        {
            SetStyle(ControlStyles.Selectable, true);
            BackColor = SystemColors.Control;
            ForeColor = SystemColors.ControlText;
            TabStop = false;
            IsDefault = false;
            Cursor = Cursors.Default;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            FlatAppearance.BorderSize = 1;
        }

        /// <summary>
        ///     Raises the <see cref="System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            hover = true;
        }

        /// <summary>
        ///     Raises the <see cref="System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            hover = false;
        }

        /// <summary>
        ///     Raises the <see cref="System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="arg">The <see cref="System.Windows.Forms.MouseEventArgs" /> instance containing the event data.</param>
        protected override void OnMouseDown(MouseEventArgs arg)
        {
            base.OnMouseDown(arg);
            if (arg.Button != MouseButtons.Left) return;

            pushed = true;
            Invalidate();
        }

        /// <summary>
        ///     Raises the <see cref="System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="arg">The <see cref="System.Windows.Forms.MouseEventArgs" /> instance containing the event data.</param>
        protected override void OnMouseUp(MouseEventArgs arg)
        {
            base.OnMouseUp(arg);
            if (arg.Button != MouseButtons.Left) return;

            pushed = false;
            Invalidate();
        }

        /// <summary>
        ///     This member overrides <see cref="Control.OnPaint">Control.OnPaint</see>.
        /// </summary>
        protected override void OnPaint(PaintEventArgs pe)
        {
            if (Application.RenderWithVisualStyles)
                ComboBoxRenderer.DrawDropDownButton(
                    pe.Graphics,
                    ClientRectangle,
                    !Enabled ? ComboBoxState.Disabled : (pushed ? ComboBoxState.Pressed : (hover || Focused ? ComboBoxState.Hot : ComboBoxState.Normal)));
            else
                ControlPaint.DrawComboButton(
                    pe.Graphics,
                    ClientRectangle,
                    !Enabled ? ButtonState.Inactive : (pushed ? ButtonState.Pushed : ButtonState.Normal));
        }
    }
}