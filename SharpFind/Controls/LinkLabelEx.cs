/* LinkLabelEx.cs
** This file is part #Find.
** 
** Copyright 2017 by Babiker M Babiker <bestivitiness@gmail.com>
** Licensed under MIT
** <https://github.com/Zedohsix/SharpFind>
*/

using System.Drawing;
using System.Windows.Forms;
using System;
using SharpFind.Classes;

namespace SharpFind.Controls
{
    public class LinkLabelEx : LinkLabel
    {
        #region Variables

        private readonly Color linkColor       = ColorTranslator.FromHtml("#0066CC");
        private readonly Color activeLinkColor = ColorTranslator.FromHtml("#00509F");

        private const int WM_SETCURSOR = 0x0020;
        private const int IDC_HAND     = 32649;

        #endregion

        public LinkLabelEx()
        {
            LinkColor = linkColor;
            ActiveLinkColor = activeLinkColor;
            LinkBehavior = LinkBehavior.HoverUnderline;
        }

        #region Use Win32 hand cursor

        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == WM_SETCURSOR)
            {
                NativeMethods.SetCursor(NativeMethods.LoadCursor(IntPtr.Zero, IDC_HAND));
                msg.Result = IntPtr.Zero;
                return;
            }
            base.WndProc(ref msg);
        }

        #endregion
    }
}