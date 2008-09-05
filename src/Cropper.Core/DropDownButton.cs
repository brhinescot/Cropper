#region License Information

/**********************************************************************************
Shared Source License for Cropper
Copyright 9/07/2004 Brian Scott
http://blogs.geekdojo.net/brian

This license governs use of the accompanying software ('Software'), and your
use of the Software constitutes acceptance of this license.

You may use the Software for any commercial or noncommercial purpose,
including distributing derivative works.

In return, we simply require that you agree:
1. Not to remove any copyright or other notices from the Software. 
2. That if you distribute the Software in source code form you do so only
   under this license (i.e. you must include a complete copy of this license
   with your distribution), and if you distribute the Software solely in
   object form you only do so under a license that complies with this
   license.
3. That the Software comes "as is", with no warranties. None whatsoever.
   This means no express, implied or statutory warranty, including without
   limitation, warranties of merchantability or fitness for a particular
   purpose or any warranty of title or non-infringement. Also, you must pass
   this disclaimer on whenever you distribute the Software or derivative
   works.
4. That no contributor to the Software will be liable for any of those types
   of damages known as indirect, special, consequential, or incidental
   related to the Software or this license, to the maximum extent the law
   permits, no matter what legal theory it’s based on. Also, you must pass
   this limitation of liability on whenever you distribute the Software or
   derivative works.
5. That if you sue anyone over patents that you think may apply to the
   Software for a person's use of the Software, your license to the Software
   ends automatically.
6. That the patent rights, if any, granted in this license only apply to the
   Software, not to any derivative works you make.
7. That the Software is subject to U.S. export jurisdiction at the time it
   is licensed to you, and it may be subject to additional export or import
   laws in other places.  You agree to comply with all such laws and
   regulations that may apply to the Software after delivery of the software
   to you.
8. That if you are an agency of the U.S. Government, (i) Software provided
   pursuant to a solicitation issued on or after December 1, 1995, is
   provided with the commercial license rights set forth in this license,
   and (ii) Software provided pursuant to a solicitation issued prior to
   December 1, 1995, is provided with “Restricted Rights” as set forth in
   FAR, 48 C.F.R. 52.227-14 (June 1987) or DFAR, 48 C.F.R. 252.227-7013
   (Oct 1988), as applicable.
9. That your rights under this License end automatically if you breach it in
   any way.
10.That all rights not expressly granted to you in this license are reserved.

**********************************************************************************/

#endregion

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
    /// The button that opens <see cref="UITypeEditor"/> controls.
    /// </summary>
    public class DropDownButton : Button
    {
        private bool pushed;
        private bool hover;

        /// <summary>
        /// Initializes a new instance of the <see cref="DropDownButton"/> class.
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
        /// Raises the <see cref="System.Windows.Forms.Control.MouseEnter"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            hover = true;
        }

        /// <summary>
        /// Raises the <see cref="System.Windows.Forms.Control.MouseLeave"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            hover = false;
        }

        /// <summary>
        /// Raises the <see cref="System.Windows.Forms.Control.MouseDown"/> event.
        /// </summary>
        /// <param name="arg">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseDown(MouseEventArgs arg)
        {
            base.OnMouseDown(arg);
            if (arg.Button == MouseButtons.Left)
            {
                pushed = true;
                Invalidate();
            }
        }

        /// <summary>
        /// Raises the <see cref="System.Windows.Forms.Control.MouseUp"/> event.
        /// </summary>
        /// <param name="arg">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        protected override void OnMouseUp(MouseEventArgs arg)
        {
            base.OnMouseUp(arg);
            if (arg.Button == MouseButtons.Left)
            {
                pushed = false;
                Invalidate();
            }
        }

        /// <summary>
        /// This member overrides <see cref="Control.OnPaint">Control.OnPaint</see>.
        /// </summary>
        protected override void OnPaint(PaintEventArgs pe)
        {
            if (Application.RenderWithVisualStyles)
                ComboBoxRenderer.DrawDropDownButton(
                    pe.Graphics, 
                    ClientRectangle, 
                    !Enabled ? ComboBoxState.Disabled : (pushed ? ComboBoxState.Pressed : ((hover || Focused) ? ComboBoxState.Hot : ComboBoxState.Normal)));
            else 
                ControlPaint.DrawComboButton(
                    pe.Graphics, 
                    ClientRectangle,
                    !Enabled ? ButtonState.Inactive : (pushed ? ButtonState.Pushed : ((hover || Focused) ? ButtonState.Normal : ButtonState.Normal)));
        }
    }
}