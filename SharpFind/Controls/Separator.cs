/* Separator.cs
** This file is part #Find.
** 
** Copyright 2017 by Babiker M Babiker <bestivitiness@gmail.com>
** Licensed under MIT
** <https://github.com/Zedohsix/SharpFind>
*/

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace SharpFind.Controls
{
    public class Separator : Control
    {
        public enum _Orientation { Horizontal, Vertical }
        private _Orientation shape;

        /// <summary>
        /// Depending on the OS version, this property decides whether an "edge"
        /// line should be drawn underneath the separator line.
        /// </summary>
        private bool DrawEdge { get; set; }
        private string color;

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Indicates whether the control should be drawn vertically or horizontally.")]
        public _Orientation Orientation
        {
            get { return shape; }
            set
            {
                shape = value;
                switch (shape)
                {
                    case _Orientation.Horizontal:
                        Width  = Height;
                        Height = 10;
                        break;
                    case _Orientation.Vertical:
                        Height = Width;
                        Width  = 10;
                        break;
                }
                Invalidate();
            }
        }

        public Separator()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            Size = new Size(120, 10);

            // Requires <supportedOS Id="{...}"/> to be uncommented in app.manifest
            var OsVer = Environment.OSVersion.Version.Major;
            if (OsVer == 5.0)
            { 
                color = "#848284";
                DrawEdge = true;
            } // Windows 2000
            else if (OsVer >= 5.1 && OsVer <= 5.2)
            {
                color = "#D0D0BF";
                DrawEdge = false;
            } // Windows XP to Server 2003
            else if (OsVer >= 6.0 && OsVer <= 6.1)
            {
                color = "#D5DFE5";
                DrawEdge = true;
            } // Windows Vista to 7
            else if (OsVer == 10.0)
            { 
                color = "#DCDCDC";
                DrawEdge = false;
            } // Windows Server 2012 to 8.1
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            switch (shape)
            {
                case _Orientation.Horizontal:
                    Height = 10;
                    break;
                case _Orientation.Vertical:
                    Width = 10;
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var pen = new Pen(ColorTranslator.FromHtml(color), 1.0F))
            {
                switch (shape)
                {
                    case _Orientation.Horizontal:
                                      e.Graphics.DrawLine(pen, 0, 5, Width, 5);
                        if (DrawEdge) e.Graphics.DrawLine(Pens.White, 0, 6, Width, 6);
                        break;
                    case _Orientation.Vertical:
                                      e.Graphics.DrawLine(pen, 5, 0, 5, Height);
                        if (DrawEdge) e.Graphics.DrawLine(Pens.White, 6, 0, 6, Height);
                        break;
                }
            }
        }
    }
}