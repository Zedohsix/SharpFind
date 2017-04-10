/* ListViewEx.cs
** This file is part #Find.
** 
** Copyright 2017 by Babiker M Babiker <bestivitiness@gmail.com>
** Licensed under MIT
** <https://github.com/Zedohsix/SharpFind>
*/

using System.Windows.Forms;
using System;
using SharpFind.Classes;

namespace SharpFind.Controls
{
    public class ListViewEx : ListView
    {
        public ListViewEx()
        {
            // Eliminate the annoying flicker
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint  |
                     ControlStyles.EnableNotifyMessage, true);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            if (Environment.OSVersion.Version.Major >= 6)
                NativeMethods.SetWindowTheme(Handle, "explorer", null);

            base.OnHandleCreated(e);
        }
    }
}