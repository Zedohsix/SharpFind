/* WindowHighlighter.cs
** This file is part #Find.
** 
** Copyright 2017 by Babiker M Babiker <bestivitiness@gmail.com>
** Licensed under MIT
** <https://github.com/Zedohsix/SharpFind>
*/

using System;
using System.Drawing;
using static SharpFind.Classes.NativeMethods;

namespace SharpFind.Classes
{
    public class WindowHighlighter
    {
        /// <summary>
        /// Highlights the designated window by drawing a rectangle around
        /// it, just like Microsoft Spy++.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// Handle to the object to be highlighted.
        /// </param>
        /// 
        /// <param name="useNativeHighlighter">
        /// If true, the rectangle will be drawn using the native PatBlt
        /// function.
        /// </param>
        public static void Highlight(IntPtr hWnd, bool useNativeHighlighter)
        {
            var rect = new RECT();
            var hDC = GetWindowDC(hWnd);

            if (hWnd == IntPtr.Zero || !IsWindow(hWnd))
                return;

            GetWindowRect(hWnd, out rect);
            OffsetRect(ref rect, -rect.left, -rect.top);

            // The thickness of the frame
            const int width = 3;

            if (hDC == IntPtr.Zero)
                return;

            if (!IsRectEmpty(ref rect))
            {
                if (useNativeHighlighter)
                {
                    // Top side
                    PatBlt(hDC,
                           rect.left,
                           rect.top,
                           rect.right - rect.left,
                           width,
                           RasterOperations.PATINVERT);

                    // Left side
                    PatBlt(hDC,
                           rect.left,
                           rect.bottom - width,
                           width,
                           -(rect.bottom - rect.top - 2 * width),
                           RasterOperations.PATINVERT);
                    
                    // Right side
                    PatBlt(hDC,
                           rect.right - width,
                           rect.top + width,
                           width,
                           rect.bottom - rect.top - 2 * width,
                           RasterOperations.PATINVERT);
                    
                    // Bottom side
                    PatBlt(hDC,
                           rect.right,
                           rect.bottom - width,
                           -(rect.right - rect.left),
                           width,
                           RasterOperations.PATINVERT);
                }
                else
                {
                    // Simple GDI+ rectangle drawing
                    using (var pen = new Pen(ColorTranslator.FromHtml("#FF0000"), 4F))
                    {
                        using (var g = Graphics.FromHdc(hDC))
                            g.DrawRectangle(pen, 0, 0, rect.right - rect.left,
                                                       rect.bottom - rect.top);
                    }
                }
            }

            ReleaseDC(hWnd, hDC);
        }

        /// <summary>
        /// Refreshes the window to get rid of the previously drawn rectangle.
        /// </summary>
        public static void Refresh(IntPtr hWnd)
        {
            InvalidateRect(hWnd, IntPtr.Zero, true);
            UpdateWindow(hWnd);
            RedrawWindow(hWnd, IntPtr.Zero, IntPtr.Zero, RDW_FRAME      |
                                                         RDW_INVALIDATE |
                                                         RDW_UPDATENOW  |
                                                         RDW_ALLCHILDREN);
        }
    }
}