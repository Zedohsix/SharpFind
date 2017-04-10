/* NativeMethods.cs
** This file is part #Find.
** 
** Copyright 2017 by Babiker M Babiker <bestivitiness@gmail.com>
** Licensed under MIT
** <https://github.com/Zedohsix/SharpFind>
*/

using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System;

namespace SharpFind.Classes
{
    internal static class NativeMethods
    {
        #region Constants

        // RedrawWindow flags
        /// <summary>
        /// Invalidate lprcUpdate or hrgnUpdate (only one may be not NULL). If
        /// both are NULL, the entire window is invalidated.
        /// </summary>
        public const int RDW_INVALIDATE = 0x1;
        /// <summary>
        /// Includes child windows, if any, in the repainting operation.
        /// </summary>
        public const int RDW_ALLCHILDREN = 0x80;
        /// <summary>
        /// Causes the affected windows (as specified by the RDW_ALLCHILDREN flag)
        /// to receive WM_NCPAINT, WM_ERASEBKGND, and WM_PAINT messages, if
        /// necessary, before the function returns.
        /// </summary>
        public const int RDW_UPDATENOW = 0x100;
        /// <summary>
        /// Causes any part of the nonclient area of the window that intersects
        /// the update region to receive a WM_NCPAINT message.
        /// </summary>
        public const int RDW_FRAME = 0x400;


        // SetWindowPos flags
        /// <summary>
        /// Applies new frame styles set using the SetWindowLong function.
        /// </summary>
        public const int SWP_FRAMECHANGED = 0x20;
        /// <summary>
        /// Does not change the owner window's position in the Z order.
        /// </summary>
        public const int SWP_NOOWNERZORDER = 0x200;


        // GetWindowLong flags
        /// <summary>
        /// Retrieves a handle to the application instance.
        /// </summary>
        public const int GWL_HINSTANCE = -6;
        /// <summary>
        /// Retrieves the identifier of the window.
        /// </summary>
        public const int GWL_ID = -12;
        /// <summary>
        /// Retrieves the window styles.
        /// </summary>
        public const int GWL_STYLE = -16;
        /// <summary>
        /// Retrieves the extended window styles.
        /// </summary>
        public const int GWL_EXSTYLE = -20;
        /// <summary>
        /// Retrieves the user data associated with the window.
        /// </summary>
        public const int GWL_USERDATA = -21;


        // GetClassLong flags
        /// <summary>
        /// Retrieves a handle to the background brush associated with the class.
        /// </summary>
        public const int GCL_HBRBACKGROUND = -10;
        /// <summary>
        /// Retrieves a handle to the cursor associated with the class.
        /// </summary>
        public const int GCL_HCURSOR = -12;
        /// <summary>
        /// Retrieves a handle to the icon associated with the class.
        /// </summary>
        public const int GCL_HICON = -14;
        /// <summary>
        /// Retrieves the size, in bytes, of the extra window memory associated
        /// with each window in the class.
        /// </summary>
        public const int GCL_CBWNDEXTRA = -18;
        /// <summary>
        /// Retrieves the size, in bytes, of the extra memory associated with the class.
        /// </summary>
        public const int GCL_CBCLSEXTRA = -20;
        /// <summary>
        /// Retrieves the address of the window procedure associated with the class.
        /// </summary>
        public const int GCL_WNDPROC = -24;
        /// <summary>
        /// Retrieves the window-class style bits.
        /// </summary>
        public const int GCL_STYLE = -26;
        /// <summary>
        /// Retrieves an ATOM value that uniquely identifies the window class.
        /// </summary>
        public const int GCW_ATOM = -32;
        /// <summary>
        /// Retrieves a handle to the small icon associated with the class.
        /// </summary>
        public const int GCL_HICONSM = -34;

        /// <summary>
        /// Indicates that the position of the cursor hot spot is in a title bar.
        /// </summary>
        public const int HTCAPTION = 0x2;

        // Menu flags
        /// <summary>
        /// Specifies that the menu item opens a drop-down menu or submenu.
        /// </summary>
        public const int MF_POPUP = 0x010;
        /// <summary>
        /// Indicates that uPosition gives the zero-based relative position of
        /// the menu item.
        /// </summary>
        public const int MF_BYPOSITION = 0x400;
        /// <summary>
        /// Draws a horizontal dividing line.
        /// </summary>
        public const int MF_SEPARATOR = 0x800;

        #endregion
        #region Enumerations

        /// <summary>
        /// The current show state of a specified window. 
        /// </summary>
        internal enum ShowWindowCommands
        {
            SW_HIDE            = 0,
            SW_SHOWNORMAL      = 1,
            SW_SHOWMINIMIZED   = 2,
            SW_MAXIMIZE        = 3,
            SW_MAXIMIZED       = 3,
            SW_SHOWNOACTIVATE  = 4,
            SW_SHOW            = 5,
            SW_MINIMIZE        = 6,
            SW_SHOWMINNOACTIVE = 7,
            SW_SHOWNA          = 8,
            SW_RESTORE         = 9
        }

        [Flags]
        internal enum SnapshotFlags : uint
        {
            TH32CS_INHERIT      = 0x80000000,
            TH32CS_SNAPALL      = TH32CS_SNAPHEAPLIST | TH32CS_SNAPMODULE  |
                                                        TH32CS_SNAPPROCESS |
                                                        TH32CS_SNAPTHREAD,
            TH32CS_SNAPHEAPLIST = 0x00000001,
            TH32CS_SNAPMODULE   = 0x00000008,
            TH32CS_SNAPMODULE32 = 0x00000010,
            TH32CS_SNAPPROCESS  = 0x00000002,
            TH32CS_SNAPTHREAD   = 0x00000004,
        }

        /// <summary>
        /// Defines how the color data for the source rectangle is to be
        /// combined with the color data for the destination rectangle to
        /// achieve the final color.
        /// </summary>
        internal enum RasterOperations : uint
        {
            BLACKNESS   = 0x00000042,
            CAPTUREBLT  = 0x40000000,
            DSTINVERT   = 0x00550009,
            MERGECOPY   = 0x00C000CA,
            MERGEPAINT  = 0x00BB0226,
            NOTSRCCOPY  = 0x00330008,
            NOTSRCERASE = 0x001100A6,
            PATCOPY     = 0x00F00021,
            PATINVERT   = 0x005A0049,
            PATPAINT    = 0x00FB0A09,
            SRCAND      = 0x008800C6,
            SRCCOPY     = 0x00CC0020,
            SRCERASE    = 0x00440328,
            SRCINVERT   = 0x00660046,
            SRCPAINT    = 0x00EE0086,
            WHITENESS   = 0x00FF0062
        }

        [Flags]
        internal enum ThreadAccess : int
        {
            TERMINATE            = 0x0001,
            SUSPEND_RESUME       = 0x0002,
            GET_CONTEXT          = 0x0008,
            SET_CONTEXT          = 0x0010,
            SET_INFORMATION      = 0x0020,
            QUERY_INFORMATION    = 0x0040,
            SET_THREAD_TOKEN     = 0x0080,
            IMPERSONATE          = 0x0100,
            DIRECT_IMPERSONATION = 0x0200
        }

        internal enum THREADINFOCLASS : int
        {
            ThreadBasicInformation,          //  0
            ThreadTimes,                     //  1
            ThreadPriority,                  //  2
            ThreadBasePriority,              //  3
            ThreadAffinityMask,              //  4
            ThreadImpersonationToken,        //  5
            ThreadDescriptorTableEntry,      //  6
            ThreadEnableAlignmentFaultFixup, //  7
            ThreadEventPair,                 //  8
            ThreadQuerySetWin32StartAddress, //  9
            ThreadZeroTlsCell,               // 10
            ThreadPerformanceCount,          // 11
            ThreadAmILastThread,             // 12
            ThreadIdealProcessor,            // 13
            ThreadPriorityBoost,             // 14
            ThreadSetTlsArrayAddress,        // 15
            ThreadIsIoPending,               // 16
            ThreadHideFromDebugger           // 17
        }

        // The list is too big. I didn't want to waste bytes. I only added the
        // ones used by the program.
        internal enum WindowsMessages : uint
        {
            WM_LBUTTONUP     = 0x202,
            WM_MOUSEMOVE     = 0x200,
            WM_NCLBUTTONDOWN = 0xA1,
            WM_NULL          = 0x00,
            WM_PAINT         = 0xF,
            WM_SYSCOMMAND    = 0x112
        }

        #endregion
        #region Structures

        /// <summary>
        /// Describes an entry from a list of the modules belonging to the
        /// specified process.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct MODULEENTRY32
        {
            internal uint dwSize;
            internal uint th32ModuleID;
            internal uint th32ProcessID;
            internal uint GlblcntUsage;
            internal uint ProccntUsage;
            internal IntPtr modBaseAddr;
            internal uint modBaseSize;
            internal IntPtr hModule;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            internal string szModule;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            internal string szExePath;
        }

        /// <summary>
        /// The POINT structure defines the x- and y- coordinates of a point.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }

        /// <summary>
        /// The RECT structure defines the coordinates of the upper-left and
        /// lower-right corners of a rectangle.
        /// </summary>
        internal struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        /// <summary>
        /// Contains information used by ShellExecuteEx.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct SHELLEXECUTEINFO
        {
            internal int cbSize;
            internal uint fMask;
            internal IntPtr hwnd;
            [MarshalAs(UnmanagedType.LPTStr)]
            internal string lpVerb;
            [MarshalAs(UnmanagedType.LPTStr)]
            internal string lpFile;
            [MarshalAs(UnmanagedType.LPTStr)]
            internal string lpParameters;
            [MarshalAs(UnmanagedType.LPTStr)]
            internal string lpDirectory;
            internal int nShow;
            internal IntPtr hInstApp;
            internal IntPtr lpIDList;
            [MarshalAs(UnmanagedType.LPTStr)]
            internal string lpClass;
            internal IntPtr hkeyClass;
            internal uint dwHotKey;
            internal IntPtr hIcon;
            internal IntPtr hProcess;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct THREADENTRY32
        {
            internal uint dwSize;
            internal uint cntUsage;
            internal uint th32ThreadID;
            internal uint th32OwnerProcessID;
            internal uint tpBasePri;
            internal uint tpDeltaPri;
            internal uint dwFlags;
        }

        /// <summary>
        /// Contains information about the placement of a window on the screen.
        /// </summary>
        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        internal struct WINDOWPLACEMENT
        {
            public uint length;
            public uint flags;
            public ShowWindowCommands showCmd;
            public POINT ptMinPosition;
            public POINT ptMaxPosition;
            public RECT rcNormalPosition;
        }

        #endregion
        #region user32.dll

        /// <summary>
        /// Retrieves the specified value from the WNDCLASSEX structure associated
        /// with the specified window.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window and, indirectly, the class to which the window
        /// belongs.
        /// </param>
        /// 
        /// <param name="nIndex">
        /// The value to be retrieved.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is the requested value.
        /// </returns>
        [DllImport("user32.dll", EntryPoint = "GetClassLong")]
        internal static extern uint GetClassLongPtr32(IntPtr hWnd, int nIndex);

        /// <summary>
        /// Same as GetClassLongPtr32, but for x64 systems.
        /// </summary>
        [DllImport("user32.dll", EntryPoint = "GetClassLongPtr")]
        internal static extern IntPtr GetClassLongPtr64(IntPtr hWnd, int nIndex);

        /// <summary>
        /// Retrieves the name of the class to which the specified window belongs.
        /// </summary>
        ///
        /// <param name="hWnd">
        /// A handle to the window and, indirectly, the class to which the window
        /// belongs.
        /// </param>
        ///
        /// <param name="lpClassName">
        /// The class name string
        /// </param>
        ///
        /// <param name="nMaxCount">
        /// The length of the lpClassName buffer, in characters
        /// </param>
        ///
        /// <returns>
        /// If the function succeeds, the return value is the number of characters
        /// copied to the buffer.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        /// <summary>
        /// Retrieves the coordinates of a window's client area.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window whose client coordinates are to be retrieved.
        /// </param>
        /// 
        /// <param name="lpRect">
        /// A pointer to a RECT structure that receives the client coordinates.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// </returns>
        [DllImport("user32.dll")]
        internal static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        /// <summary>
        /// Retrieves a handle to a device context (DC) for the client area of
        /// a specified window or for the entire screen.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window whose DC is to be retrieved. If this value
        /// is NULL, GetDC retrieves the DC for the entire screen.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is a handle to the DC
        /// for the specified window's client area.
        /// </returns>
        [DllImport("user32.dll")]
        internal static extern IntPtr GetDC(IntPtr hWnd);

        /// <summary>
        /// Enables the application to access the window menu for copying and
        /// modifying.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window that will own a copy of the window menu.
        /// </param>
        /// 
        /// <param name="bRevert">
        /// The action to be taken. If this parameter is FALSE, GetSystemMenu
        /// returns a handle to the copy of the window menu currently in use.
        /// The copy is initially identical to the window menu, but it can be
        /// modified. If this parameter is TRUE, GetSystemMenu resets the window
        /// menu back to the default state. The previous window menu, if any, is
        /// destroyed.
        /// </param>
        /// 
        /// <returns>
        /// If the bRevert parameter is FALSE, the return value is a handle to a
        /// copy of the window menu. If the bRevert parameter is TRUE, the return
        /// value is NULL.
        /// </returns>
        [DllImport("user32.dll")]
        internal static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        /// <summary>
        /// Retrieves the device context (DC) for the entire window, including
        /// title bar, menus, and scroll bars. A window device context permits
        /// painting anywhere in a window, because the origin of the device
        /// context is the upper-left corner of the window instead of the client
        /// area.
        /// 
        /// GetWindowDC assigns default attributes to the window device context
        /// each time it retrieves the device context. Previous attributes are lost.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window with a device context that is to be retrieved.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is a handle to a device
        /// context for the specified window.
        /// </returns>
        [DllImport("user32.dll")]
        internal static extern IntPtr GetWindowDC(IntPtr hWnd);

        /// <summary>
        /// Retrieves information about the specified window. The function also
        /// retrieves the 32-bit (DWORD) value at the specified offset into the
        /// extra window memory.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window and, indirectly, the class to which the window
        /// belongs.
        /// </param>
        /// 
        /// <param name="nIndex">
        /// The zero-based offset to the value to be retrieved.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is the requested value.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        /// <summary>
        /// Same as GetWindowLong, but for compatibility with both 32-bit and
        /// 64-bit versions of Windows
        /// </summary>
        [DllImport("user32.dll", SetLastError = true, EntryPoint = "GetWindowLongA")]
        internal static extern int GetWindowLongPtr(IntPtr hwnd, int nIndex);

        /// <summary>
        /// Retrieves the show state and the restored, minimized, and maximized
        /// positions of the specified window.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window.
        /// </param>
        /// 
        /// <param name="lpwndpl">
        /// A pointer to the WINDOWPLACEMENT structure that receives the show
        /// state and position information.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// Retrieves the dimensions of the bounding rectangle of the specified
        /// window. The dimensions are given in screen coordinates that are
        /// relative to the upper-left corner of the screen.
        /// </summary>
        /// 
        /// <param name="hwnd">
        /// A handle to the window.
        /// </param>
        /// 
        /// <param name="lpRect">
        /// A pointer to a RECT structure that receives the screen coordinates of
        /// the upper-left and lower-right corners of the window.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        /// <summary>
        /// Copies the text of the specified window's title bar (if it has one)
        /// into a buffer.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window or control containing the text.
        /// </param>
        /// 
        /// <param name="lpString">
        /// The buffer that will receive the text.
        /// </param>
        /// 
        /// <param name="nMaxCount">
        /// The maximum number of characters to copy to the buffer, including the
        /// null character.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is the length, in
        /// characters, of the copied string.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// Retrieves the identifier of the thread that created the specified
        /// window.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window.
        /// </param>
        /// 
        /// <param name="lpdwProcessId">
        /// A pointer to a variable that receives the process identifier.
        /// </param>
        /// 
        /// <returns>
        /// The return value is the identifier of the thread that created the window.
        /// </returns>
        [DllImport("user32.dll")]
        internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, ref int lpdwProcessId);

        /// <summary>
        /// Inserts a new menu item into a menu, moving other items down the menu.
        /// </summary>
        /// 
        /// <param name="hMenu">
        /// A handle to the menu to be changed.
        /// </param>
        /// 
        /// <param name="uPosition">
        /// The menu item before which the new menu item is to be inserted, as
        /// determined by the uFlags parameter.
        /// </param>
        /// 
        /// <param name="uFlags">
        /// Controls the interpretation of the uPosition parameter and the
        /// content, appearance, and behavior of the new menu item. This parameter
        /// must include one of the following required values.
        /// </param>
        /// 
        /// <param name="uIDNewItem">
        /// The identifier of the new menu item or, if the uFlags parameter has 
        /// the MF_POPUP flag set, a handle to the drop-down menu or submenu.
        /// </param>
        /// 
        /// <param name="lpNewItem">
        /// The content of the new menu item.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern bool InsertMenu(IntPtr hMenu, uint uPosition,
                                                             uint uFlags, 
                                                             uint uIDNewItem,
                                                             [MarshalAs(UnmanagedType.LPTStr)]string lpNewItem);

        /// <summary>
        /// The InvalidateRect function adds a rectangle to the specified window's
        /// update region.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window whose update region has changed.
        /// </param>
        /// 
        /// <param name="lpRect">
        /// A pointer to a RECT structure that contains the client coordinates of
        /// the rectangle to be added to the update region.
        /// </param>
        /// 
        /// <param name="bErase">
        /// Specifies whether the background within the update region is to be
        /// erased when the update region is processed.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        [DllImport("user32.dll")]
        internal static extern int InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        /// <summary>
        /// Determines whether the specified rectangle is empty.
        /// </summary>
        /// 
        /// <param name="lprc">
        /// Pointer to a RECT structure that contains the logical coordinates of
        /// the rectangle.
        /// </param>
        /// 
        /// <returns>
        /// If the rectangle is empty, the return value is nonzero.
        /// </returns>
        [DllImport("user32.dll")]
        internal static extern bool IsRectEmpty(ref RECT lprc);

        /// <summary>
        /// Determines whether the specified window handle identifies an existing
        /// window.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window to be tested.
        /// </param>
        /// 
        /// <returns>
        /// If the window handle identifies an existing window, the return value
        /// is nonzero.
        /// </returns>
        [DllImport("user32.dll")]
        internal static extern bool IsWindow(IntPtr hWnd);

        /// <summary>
        /// Determines whether the specified window is enabled for mouse and
        /// keyboard input.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window to be tested.
        /// </param>
        /// 
        /// <returns>
        /// If the window is enabled, the return value is nonzero.
        /// If the window is not enabled, the return value is zero.
        /// </returns>
        [DllImport("user32.dll")]
        internal static extern bool IsWindowEnabled(IntPtr hWnd);

        /// <summary>
        /// Determines whether the specified window is a native Unicode window.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window to be tested.
        /// </param>
        /// 
        /// <returns>
        /// If the window is a native Unicode window, the return value is nonzero.
        /// </returns>
        [DllImport("user32.dll")]
        internal static extern bool IsWindowUnicode(IntPtr hWnd);

        /// <summary>
        /// Determines the visibility state of the specified window.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window to be tested.
        /// </param>
        /// 
        /// <returns>
        /// If the specified window, its parent window, its parent's parent
        /// window, and so forth, have the WS_VISIBLE style, the return value is
        /// nonzero. Otherwise, the return value is zero. 
        /// 
        /// Because the return value specifies whether the window has the
        /// WS_VISIBLE style, it may be nonzero even if the window is totally
        /// obscured by other windows. 
        /// </returns>
        [DllImport("user32.dll")]
        internal static extern bool IsWindowVisible(IntPtr hWnd);

        /// <summary>
        /// Determines whether a window is maximized.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window to be tested.
        /// </param>
        /// 
        /// <returns>
        /// If the window is zoomed, the return value is nonzero.
        /// If the window is not zoomed, the return value is zero.
        /// </returns>
        [DllImport("user32.dll")]
        internal static extern bool IsZoomed(IntPtr hWnd);

        /// <summary>
        /// Loads the specified cursor resource from the executable (.EXE) file
        /// associated with an application instance.
        /// </summary>
        ///
        /// <param name="hInstance">
        /// A handle to an instance of the module whose executable file contains the
        /// cursor to be loaded.
        /// </param>
        ///
        /// <param name="lpCursorName">
        /// The name of the cursor resource to be loaded.
        /// </param>
        [DllImport("user32.dll")]
        internal static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        /// <summary>
        /// The OffsetRect function moves the specified rectangle by the
        /// specified offsets.
        /// </summary>
        /// 
        /// <param name="lprc">
        /// Pointer to a RECT structure that contains the logical coordinates of
        /// the rectangle to be moved.
        /// </param>
        /// 
        /// <param name="dx">
        /// Specifies the amount to move the rectangle left or right. This
        /// parameter must be a negative value to move the rectangle to the left.
        /// </param>
        /// 
        /// <param name="dy">
        /// Specifies the amount to move the rectangle up or down. This parameter
        /// must be a negative value to move the rectangle up.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// </returns>
        [DllImport("user32.dll")]
        internal static extern bool OffsetRect(ref RECT lprc, int dx, int dy);

        /// <summary>
        /// The RedrawWindow function updates the specified rectangle or region
        /// in a window's client area.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window to be redrawn. If this parameter is NULL, the
        /// desktop window is updated.
        /// </param>
        /// 
        /// <param name="lprcUpdate">
        /// A pointer to a RECT structure containing the coordinates, in device
        /// units, of the update rectangle.
        /// </param>
        /// 
        /// <param name="hrgnUpdate">
        /// A handle to the update region.
        /// </param>
        /// 
        /// <param name="flags">
        /// One or more redraw flags.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// </returns>
        [DllImport("user32.dll")]
        internal static extern bool RedrawWindow(IntPtr hWnd,
                                                 IntPtr lprcUpdate,
                                                 IntPtr hrgnUpdate,
                                                 uint flags);

        /// <summary>
        /// Releases the mouse capture from a window in the current thread and
        /// restores normal mouse input processing.
        /// </summary>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// </returns>
        [DllImport("user32.dll")]
        internal static extern bool ReleaseCapture();

        /// <summary>
        /// The ReleaseDC function releases a device context (DC), freeing it
        /// for use by other applications. The effect of the ReleaseDC function
        /// depends on the type of DC. It frees only common and window DCs. It
        /// has no effect on class or private DCs.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window whose DC is to be released.
        /// </param>
        /// 
        /// <param name="hDC">
        /// A handle to the DC to be released.
        /// </param>
        /// 
        /// <returns>
        /// The return value indicates whether the DC was released. If the DC was
        /// released, the return value is 1
        /// </returns>
        [DllImport("user32.dll")]
        internal static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        /// <summary>
        /// Sets the mouse capture to the specified window belonging to the
        /// current thread.SetCapture captures mouse input either when the mouse
        /// is over the capturing window, or when the mouse button was pressed
        /// while the mouse was over the capturing window and the button is still
        /// down. Only one window at a time can capture the mouse.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// A handle to the window in the current thread that is to capture the
        /// mouse.
        /// </param>
        /// 
        /// <returns>
        /// The return value is a handle to the window that had previously
        /// captured the mouse.
        /// </returns>
        [DllImport("user32.dll")]
        internal static extern IntPtr SetCapture(IntPtr hWnd);

        /// <summary>
        /// Sets the cursor shape.
        /// </summary>
        ///
        /// <param name="hCursor">
        /// A handle to the cursor.
        /// </param>
        [DllImport("user32.dll")]
        internal static extern IntPtr SetCursor(IntPtr hCursor);

        /// <summary>
        /// Updates the client area of the specified window by sending a WM_PAINT
        /// message to the window if the window's update region is not empty. 
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// Handle to the window to be updated.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// </returns>
        [DllImport("user32.dll")]
        internal static extern bool UpdateWindow(IntPtr hWnd);

        /// <summary>
        /// Retrieves a handle to the window that contains the specified point.
        /// </summary>
        /// 
        /// <param name="point">
        /// The point to be checked.
        /// </param>
        /// 
        /// <returns>
        /// The return value is a handle to the window that contains the point.
        /// If no window exists at the given point, the return value is NULL.
        /// </returns>
        [DllImport("user32.dll")]
        internal static extern IntPtr WindowFromPoint(Point point);

        #endregion
        #region gdi32.dll

        /// <summary>
        /// The GetDeviceCaps function retrieves device-specific information for
        /// the specified device.
        /// </summary>
        /// 
        /// <param name="hdc">
        /// A handle to the DC.
        /// </param>
        /// 
        /// <param name="nIndex">
        /// The item to be returned. This parameter can be one of the following
        /// values.
        /// </param>
        /// 
        /// <returns>
        /// The return value specifies the value of the desired item.
        /// When nIndex is BITSPIXEL and the device has 15bpp or 16bpp, the
        /// return value is 16.
        /// </returns>
        [DllImport("gdi32.dll")]
        internal static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        /// <summary>
        /// Paints the specified rectangle using the brush that is currently
        /// selected into the specified device context. The brush color and the
        /// surface color or colors are combined by using the specified raster
        /// operation.
        /// </summary>
        /// 
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// 
        /// <param name="nXLeft">
        /// The x-coordinate, in logical units, of the upper-left corner of the
        /// rectangle to be filled.
        /// </param>
        /// 
        /// <param name="nYLeft">
        /// The y-coordinate, in logical units, of the upper-left corner of the
        /// rectangle to be filled.
        /// </param>
        /// 
        /// <param name="nWidth">
        /// The width, in logical units, of the rectangle.
        /// </param>
        /// 
        /// <param name="nHeight">
        /// The height, in logical units, of the rectangle.
        /// </param>
        /// 
        /// <param name="dwRop">
        /// The raster operation code. This code can be one of the following values.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// </returns>
        [DllImport("gdi32.dll")]
        internal static extern bool PatBlt(IntPtr hdc, int nXLeft, int nYLeft,
                                                       int nWidth, int nHeight,
                                                       RasterOperations dwRop);

        #endregion
        #region kernel32.dll

        /// <summary>
        /// Closes an open object handle.
        /// </summary>
        /// 
        /// <param name="hObject">
        /// A valid handle to an open object.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CloseHandle(IntPtr hObject);

        /// <summary>
        /// Takes a snapshot of the specified processes, as well as the heaps,
        /// modules, and threads used by these processes.
        /// </summary>
        /// 
        /// <param name="dwFlags">
        /// The portions of the system to be included in the snapshot.
        /// The parameters are defined in <c>SnapshotFlags</c>.
        /// </param>
        /// 
        /// <param name="th32ProcessID">
        /// The process identifier of the process to be included in the snapshot.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, it returns an open handle to the specified
        /// snapshot.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr CreateToolhelp32Snapshot(SnapshotFlags dwFlags, int th32ProcessID);

        /// <summary>
        /// Retrieves the process identifier of the calling process.
        /// </summary>
        /// 
        /// <returns>
        /// The return value is the process identifier of the calling process.
        /// </returns>
        [DllImport("kernel32.dll")]
        internal static extern uint GetCurrentProcessId();

        /// <summary>
        /// Retrieves the priority class for the specified process. This value,
        /// together with the priority value of each thread of the process,
        /// determines each thread's base priority level.
        /// </summary>
        /// 
        /// <param name="hProcess">
        /// A handle to the process.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is the priority class of
        /// the specified process.
        /// </returns>
        [DllImport("kernel32.dll")]
        internal static extern uint GetPriorityClass(IntPtr hProcess);

        /// <summary>
        /// Retrieves a string from the specified section in an initialization file.
        /// </summary>
        /// 
        /// <param name="lpAppName">
        /// The name of the section containing the key name. If this parameter is
        /// NULL, the GetPrivateProfileString function copies all section names
        /// in the file to the supplied buffer.
        /// </param>
        /// 
        /// <param name="lpKeyName">
        /// The name of the key whose associated string is to be retrieved. If this
        /// parameter is NULL, all key names in the section specified by the lpAppName
        /// parameter are copied to the buffer specified by the lpReturnedString
        /// parameter.
        /// </param>
        /// 
        /// <param name="lpDefault">
        /// A default string. If the lpKeyName key cannot be found in the
        /// initialization file, GetPrivateProfileString copies the default string to
        /// the lpReturnedString buffer. If this parameter is NULL, the default is an
        /// empty string, "".
        /// </param>
        /// 
        /// <param name="lpReturnedString">
        /// A pointer to the buffer that receives the retrieved string.
        /// </param>
        /// 
        /// <param name="nSize">
        /// The size of the buffer pointed to by the lpReturnedString parameter, in
        /// characters.
        /// </param>
        /// 
        /// <param name="lpFileName">
        /// The name of the initialization file.
        /// </param>
        /// 
        /// <returns>
        /// The return value is the number of characters copied to the buffer, not
        /// including the terminating null character.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        internal static extern uint GetPrivateProfileString(string lpAppName, 
                                                            string lpKeyName, 
                                                            string lpDefault,
                                                            string lpReturnedString, 
                                                            int nSize,
                                                            string lpFileName);

        /// <summary>
        /// Retrieves information about the first module associated with a
        /// process.
        /// </summary>
        /// 
        /// <param name="hSnapshot">
        /// A handle to the snapshot returned from a previous call to the
        /// <c>CreateToolhelp32Snapshot</c> function.
        /// </param>
        /// 
        /// <param name="lpme">
        /// A pointer to a <c>MODULEENTRY32</c> structure.
        /// </param>
        /// 
        /// <returns>
        /// Returns TRUE if the first entry of the module list has been copied
        /// to the buffer or FALSE otherwise.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        internal static extern bool Module32First(IntPtr hSnapshot, ref MODULEENTRY32 lpme);

        /// <summary>
        /// Retrieves information about the next module associated with a
        /// process.
        /// </summary>
        /// 
        /// <param name="hSnapshot">
        /// A handle to the snapshot returned from a previous call to the
        /// <c>CreateToolhelp32Snapshot</c> function.
        /// </param>
        /// 
        /// <param name="lpme">
        /// A pointer to a <c>MODULEENTRY32</c> structure.
        /// </param>
        /// 
        /// <returns>
        /// Returns TRUE if the first entry of the module list has been copied
        /// to the buffer or FALSE otherwise.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        internal static extern bool Module32Next(IntPtr hSnapshot, ref MODULEENTRY32 lpme);

        /// <summary>
        /// Opens an existing thread object.
        /// </summary>
        /// 
        /// <param name="dwDesiredAccess">
        /// The access to the thread object. This access right is checked
        /// against the security descriptor for the thread. This parameter can
        /// be one or more of the thread access rights.
        /// </param>
        /// 
        /// <param name="bInheritHandle">
        /// If this value is TRUE, processes created by this process will
        /// inherit the handle. Otherwise, the processes do not inherit this
        /// handle.
        /// </param>
        /// 
        /// <param name="dwThreadId">
        /// The identifier of the thread to be opened.
        /// </param>
        /// 
        /// <returns>
        /// If the function succeeds, the return value is an open handle to the
        /// specified thread.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

        /// <summary>
        /// Retrieves information about the first thread of any process
        /// encountered in a system snapshot.
        /// </summary>
        /// 
        /// <param name="hSnapshot">
        /// A handle to the snapshot returned from a previous call to the
        /// <c>CreateToolhelp32Snapshot</c> function.
        /// </param>
        /// 
        /// <param name="lpte">
        /// A pointer to a <c>THREADENTRY32</c> structure.
        /// </param>
        /// 
        /// <returns>
        /// Returns TRUE if the first entry of the module list has been copied
        /// to the buffer or FALSE otherwise.
        /// </returns>
        [DllImport("kernel32.dll")]
        internal static extern bool Thread32First(IntPtr hSnapshot, ref THREADENTRY32 lpte);

        /// <summary>
        /// Retrieves information about the next thread of any process
        /// encountered in a system snapshot.
        /// </summary>
        /// 
        /// <param name="hSnapshot">
        /// A handle to the snapshot returned from a previous call to the
        /// <c>CreateToolhelp32Snapshot</c> function.
        /// </param>
        /// 
        /// <param name="lpte">
        /// A pointer to a <c>THREADENTRY32</c> structure.
        /// </param>
        /// 
        /// <returns>
        /// Returns TRUE if the first entry of the module list has been copied
        /// to the buffer or FALSE otherwise.
        /// </returns>
        [DllImport("kernel32.dll")]
        internal static extern bool Thread32Next(IntPtr hSnapshot, ref THREADENTRY32 lpte);

        /// <summary>
        /// Copies a string into the specified section of an initialization file.
        /// </summary>
        /// 
        /// <param name="lpAppName">
        /// The name of the section to which the string will be copied. If the
        /// section does not exist, it is created. The name of the section is
        /// case-independent; the string can be any combination of uppercase and
        /// lowercase letters.
        /// </param>
        /// 
        /// <param name="lpKeyName">
        /// The name of the key to be associated with a string. If the key does
        /// not exist in the specified section, it is created. If this parameter
        /// is NULL, the entire section, including all entries within the
        /// section, is deleted.
        /// </param>
        /// 
        /// <param name="lpString">
        /// A null-terminated string to be written to the file. If this parameter
        /// is NULL, the key pointed to by the lpKeyName parameter is deleted.
        /// </param>
        /// <param name="lpFileName">
        /// The name of the initialization file.
        /// </param>
        /// 
        /// <returns>
        /// If the function successfully copies the string to the initialization
        /// file, the return value is nonzero.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern int WritePrivateProfileString(string lpAppName, 
                                                             string lpKeyName,
                                                             string lpString,
                                                             string lpFileName);

        #endregion
        #region shell32.dll

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        internal static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

        #endregion
        #region ntdll.dll

        /// <summary>
        /// Retrieves information about the specified thread.
        /// </summary>
        /// 
        /// <param name="threadHandle">
        /// A handle to the thread about which information is being requested.
        /// </param>
        /// 
        /// <param name="threadInformationClass">
        /// If this parameter is the ThreadQuerySetWin32StartAddress value of
        /// the THREADINFOCLASS enumeration, the function returns the start
        /// address of the thread.
        /// </param>
        /// 
        /// <param name="threadInformation">
        /// A pointer to a buffer in which the function writes the requested
        /// information.
        /// </param>
        /// <param name="threadInformationLength">
        /// The size of the buffer pointed to by the <c>ThreadInformation</c>
        /// parameter, in bytes.
        /// </param>
        /// 
        /// <param name="returnLength">
        /// A pointer to a variable in which the function returns the size of
        /// the requested information.
        /// </param>
        /// 
        /// <returns>
        /// Returns an NTSTATUS success or error code.
        /// </returns>
        [DllImport("ntdll.dll", SetLastError = true)]
        internal static extern int NtQueryInformationThread(IntPtr threadHandle,
                                                            THREADINFOCLASS threadInformationClass, 
                                                            IntPtr threadInformation, 
                                                            int threadInformationLength, 
                                                            IntPtr returnLength);

        #endregion
        #region uxtheme.dll

        /// <summary>
        /// Causes a window to use a different set of visual style information
        /// than its class normally uses. In this context, it will be used to
        /// apply the native Window ListView theme.
        /// </summary>
        /// 
        /// <param name="hWnd">
        /// Handle to the window whose visual style information is to be changed.
        /// </param>
        /// 
        /// <param name="pszSubAppName">
        /// Pointer to a string that contains the application name to use in place
        /// of the calling application's name.
        /// </param>
        /// 
        /// <param name="pszSubIdList">
        /// Pointer to a string that contains a semicolon-separated list of CLSID
        /// names to use in place of the actual list passed by the window's class.
        /// </param>
        /// 
        /// <returns>
        /// If this function succeeds, it returns S_OK. Otherwise, it returns an
        /// HRESULT error code.
        /// </returns>
        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        internal static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, 
                                                               string pszSubIdList);

        #endregion
        #region shlwapi.dll

        /// <summary>
        /// Converts a numeric value into a string that represents the number
        /// expressed as a size value in bytes, kilobytes, megabytes, or
        /// gigabytes, depending on the size.
        /// </summary>
        /// 
        /// <param name="fileSize">
        /// The numeric value to be converted.
        /// </param>
        /// 
        /// <param name="buffer">
        /// A pointer to a buffer that receives the converted string.
        /// </param>
        /// 
        /// <param name="bufferSize">
        /// The size of the buffer pointed to by <c>buffer</c>.
        /// </param>
        /// 
        /// <returns>
        /// Returns a pointer to the converted string, or NULL if the conversion fails.
        /// </returns>
        [DllImport("shlwapi.dll", CharSet = CharSet.Auto)]
        internal static extern long StrFormatByteSize(long fileSize, StringBuilder buffer, int bufferSize);

        #endregion
        #region WinUser.h & CommCtrl.h Definitions

        internal static class Styles
        {
            /// <summary>
            /// Based on Windows Kits\8.1\Include\um\WinUser.h
            /// </summary>
            internal static class ClassStyles
            {
                internal static readonly int
                CS_VREDRAW         = 0x0001,
                CS_HREDRAW         = 0x0002,
                CS_DBLCLKS         = 0x0008,
                CS_OWNDC           = 0x0020,
                CS_CLASSDC         = 0x0040,
                CS_PARENTDC        = 0x0080,
                CS_NOCLOSE         = 0x0200,
                CS_SAVEBITS        = 0x0800,
                CS_BYTEALIGNCLIENT = 0x1000,
                CS_BYTEALIGNWINDOW = 0x2000,
                CS_GLOBALCLASS     = 0x4000,
                CS_IME             = 0x00010000,
                CS_DROPSHADOW      = 0x00020000;
            }

            /// <summary>
            /// Based on Windows Kits\8.1\Include\um\WinUser.h
            /// See: https://msdn.microsoft.com/en-us/library/windows/desktop/ms632600(v=vs.85).aspx
            /// </summary>
            internal static class WindowStyles
            {
                internal static readonly long
                WS_OVERLAPPED       = 0x00000000L,
                WS_POPUP            = 0x80000000L,
                WS_CHILD            = 0x40000000L,
                WS_MINIMIZE         = 0x20000000L,
                WS_VISIBLE          = 0x10000000L,
                WS_DISABLED         = 0x08000000L,
                WS_CLIPSIBLINGS     = 0x04000000L,
                WS_CLIPCHILDREN     = 0x02000000L,
                WS_MAXIMIZE         = 0x01000000L,
                WS_CAPTION          = 0x00C00000L,
                WS_BORDER           = 0x00800000L,
                WS_DLGFRAME         = 0x00400000L,
                WS_VSCROLL          = 0x00200000L,
                WS_HSCROLL          = 0x00100000L,
                WS_SYSMENU          = 0x00080000L,
                WS_THICKFRAME       = 0x00040000L,
                WS_GROUP            = 0x00020000L,
                WS_TABSTOP          = 0x00010000L,
                WS_MINIMIZEBOX      = 0x00020000L,
                WS_MAXIMIZEBOX      = 0x00010000L,
//              WS_TILED            = WS_OVERLAPPED,
//              WS_ICONIC           = WS_MINIMIZE,
//              WS_SIZEBOX          = WS_THICKFRAME,
//              WS_TILEDWINDOW      = WS_OVERLAPPEDWINDOW,
                WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU |
                                      WS_THICKFRAME | WS_MINIMIZEBOX          |
                                      WS_MAXIMIZEBOX,
                WS_POPUPWINDOW      = WS_POPUP | WS_BORDER | WS_SYSMENU;
//              WS_CHILDWINDOW      = WS_CHILD;
            }

            /// <summary>
            /// Based on Windows Kits\8.1\Include\um\WinUser.h
            /// </summary>
            internal static class WindowStylesEx
            {
                internal static readonly long
                WS_EX_DLGMODALFRAME       = 0x00000001L,
                WS_EX_NOPARENTNOTIFY      = 0x00000004L,
                WS_EX_TOPMOST             = 0x00000008L,
                WS_EX_ACCEPTFILES         = 0x00000010L,
                WS_EX_TRANSPARENT         = 0x00000020L,
                WS_EX_MDICHILD            = 0x00000040L,
                WS_EX_TOOLWINDOW          = 0x00000080L,
                WS_EX_WINDOWEDGE          = 0x00000100L,
                WS_EX_CLIENTEDGE          = 0x00000200L,
                WS_EX_CONTEXTHELP         = 0x00000400L,
                WS_EX_RIGHT               = 0x00001000L,
                WS_EX_LEFT                = 0x00000000L,
                WS_EX_RTLREADING          = 0x00002000L,
                WS_EX_LTRREADING          = 0x00000000L,
                WS_EX_LEFTSCROLLBAR       = 0x00004000L,
                WS_EX_RIGHTSCROLLBAR      = 0x00000000L,
                WS_EX_CONTROLPARENT       = 0x00010000L,
                WS_EX_STATICEDGE          = 0x00020000L,
                WS_EX_APPWINDOW           = 0x00040000L,
//              WS_EX_OVERLAPPEDWINDOW    = WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE,
//              WS_EX_PALETTEWINDOW       = WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST,
                WS_EX_LAYERED             = 0x00080000,
                WS_EX_NOINHERITLAYOUT     = 0x00100000L,
                WS_EX_NOREDIRECTIONBITMAP = 0x00200000L,
                WS_EX_LAYOUTRTL           = 0x00400000L,
                WS_EX_COMPOSITED          = 0x02000000L,
                WS_EX_NOACTIVATE          = 0x08000000L;
            }

            /// <summary>
            /// Class: Button
            /// Based on Windows Kits\8.1\Include\um\WinUser.h
            /// </summary>
            internal static class ButtonControlStyles
            {
                internal static readonly long
                BS_PUSHBUTTON      = 0x00000000L,
                BS_DEFPUSHBUTTON   = 0x00000001L,
                BS_CHECKBOX        = 0x00000002L,
                BS_AUTOCHECKBOX    = 0x00000003L,
                BS_RADIOBUTTON     = 0x00000004L,
                BS_3STATE          = 0x00000005L,
                BS_AUTO3STATE      = 0x00000006L,
                BS_GROUPBOX        = 0x00000007L,
                BS_USERBUTTON      = 0x00000008L,
                BS_AUTORADIOBUTTON = 0x00000009L,
//              BS_PUSHBOX         = 0x0000000AL,
                BS_OWNERDRAW       = 0x0000000BL,
//              BS_TYPEMASK        = 0x0000000FL,
                BS_LEFTTEXT        = 0x00000020L,
                BS_TEXT            = 0x00000000L,
                BS_ICON            = 0x00000040L,
                BS_BITMAP          = 0x00000080L,
                BS_LEFT            = 0x00000100L,
                BS_RIGHT           = 0x00000200L,
                BS_CENTER          = 0x00000300L,
                BS_TOP             = 0x00000400L,
                BS_BOTTOM          = 0x00000800L,
                BS_VCENTER         = 0x00000C00L,
                BS_PUSHLIKE        = 0x00001000L,
                BS_MULTILINE       = 0x00002000L,
                BS_NOTIFY          = 0x00004000L,
                BS_FLAT            = 0x00008000L,
                BS_RIGHTBUTTON     = BS_LEFTTEXT;
            }

            /// <summary>
            /// Class: ComboBox
            /// Based on Windows Kits\8.1\Include\um\WinUser.h
            /// </summary>
            internal static class ComboBoxStyles
            {
                internal static readonly long
                CBS_SIMPLE            = 0x0001L,
                CBS_DROPDOWN          = 0x0002L,
                CBS_DROPDOWNLIST      = 0x0003L,
                CBS_OWNERDRAWFIXED    = 0x0010L,
                CBS_OWNERDRAWVARIABLE = 0x0020L,
                CBS_AUTOHSCROLL       = 0x0040L,
                CBS_OEMCONVERT        = 0x0080L,
                CBS_SORT              = 0x0100L,
                CBS_HASSTRINGS        = 0x0200L,
                CBS_NOINTEGRALHEIGHT  = 0x0400L,
                CBS_DISABLENOSCROLL   = 0x0800L,
                CBS_UPPERCASE         = 0x2000L,
                CBS_LOWERCASE         = 0x4000L;
            }

            /// <summary>
            /// Based on Windows Kits\8.1\CommCtrl.h
            /// </summary>
            internal static class CommonControlStyles
            {
                internal static readonly long
                CCS_TOP           = 0x00000001L,
                CCS_NOMOVEY       = 0x00000002L,
                CCS_BOTTOM        = 0x00000003L,
                CCS_NORESIZE      = 0x00000004L,
                CCS_NOPARENTALIGN = 0x00000008L,
                CCS_ADJUSTABLE    = 0x00000020L,
                CCS_NODIVIDER     = 0x00000040L,
                CCS_VERT          = 0x00000080L,
                CCS_LEFT          = CCS_VERT | CCS_TOP,
                CCS_RIGHT         = CCS_VERT | CCS_BOTTOM,
                CCS_NOMOVEX       = CCS_VERT | CCS_NOMOVEY;
            }

            /// <summary>
            /// Class: SysDateTimePick32
            /// Based on Windows Kits\8.1\CommCtrl.h
            /// </summary>
            internal static class DateTimeControlStyles
            {
                internal static readonly int
                DTS_UPDOWN                 = 0x0001,
                DTS_SHOWNONE               = 0x0002,
                DTS_SHORTDATEFORMAT        = 0x0000,
                DTS_LONGDATEFORMAT         = 0x0004,
//              DTS_SHORTDATECENTURYFORMAT = 0x000C,
                DTS_TIMEFORMAT             = 0x0009,
                DTS_APPCANPARSE            = 0x0010,
                DTS_RIGHTALIGN             = 0x0020;
            }

            /// <summary>
            /// Class: #32770
            /// Based on Windows Kits\8.1\Include\um\WinUser.h
            /// </summary>
            internal static class DialogBoxStyles
            {
                internal static readonly long
                DS_ABSALIGN      = 0x01L,
                DS_SYSMODAL      = 0x02L,
                DS_LOCALEDIT     = 0x20L,
                DS_SETFONT       = 0x40L,
                DS_MODALFRAME    = 0x80L,
                DS_NOIDLEMSG     = 0x100L,
                DS_SETFOREGROUND = 0x200L,
                DS_3DLOOK        = 0x0004L,
                DS_FIXEDSYS      = 0x0008L,
                DS_NOFAILCREATE  = 0x0010L,
                DS_CONTROL       = 0x0400L,
                DS_CENTER        = 0x0800L,
                DS_CENTERMOUSE   = 0x1000L,
                DS_CONTEXTHELP   = 0x2000L,
                DS_USEPIXELS     = 0x8000L,
                DS_SHELLFONT     = DS_SETFONT | DS_FIXEDSYS;
            }

            /// <summary>
            /// Class: Edit
            /// Based on Windows Kits\8.1\Include\um\WinUser.h
            /// </summary>
            internal static class EditControlStyles
            {
                internal static readonly long
                ES_LEFT        = 0x0000L,
                ES_CENTER      = 0x0001L,
                ES_RIGHT       = 0x0002L,
                ES_MULTILINE   = 0x0004L,
                ES_UPPERCASE   = 0x0008L,
                ES_LOWERCASE   = 0x0010L,
                ES_PASSWORD    = 0x0020L,
                ES_AUTOVSCROLL = 0x0040L,
                ES_AUTOHSCROLL = 0x0080L,
                ES_NOHIDESEL   = 0x0100L,
                ES_OEMCONVERT  = 0x0400L,
                ES_READONLY    = 0x0800L,
                ES_WANTRETURN  = 0x1000L,
                ES_NUMBER      = 0x2000L;
            }

            /// <summary>
            /// Class: SysHeader32
            /// Based on Windows Kits\8.1\CommCtrl.h
            /// </summary>
            internal static class HeaderControlStyles
            {
                internal static readonly int
                HDS_HORZ       = 0x0000,
                HDS_BUTTONS    = 0x0002,
                HDS_HOTTRACK   = 0x0004,
                HDS_HIDDEN     = 0x0008,
                HDS_DRAGDROP   = 0x0040,
                HDS_FULLDRAG   = 0x0080,
                HDS_FILTERBAR  = 0x0100,
                HDS_FLAT       = 0x0200,
                HDS_CHECKBOXES = 0x0400,
                HDS_NOSIZING   = 0x0800,
                HDS_OVERFLOW   = 0x1000;
            }

            /// <summary>
            /// Class: ListBox
            /// Based on Windows Kits\8.1\Include\um\WinUser.h
            /// </summary>
            internal static class ListBoxStyles
            {
                internal static readonly long
                LBS_NOTIFY            = 0x0001L,
                LBS_SORT              = 0x0002L,
                LBS_NOREDRAW          = 0x0004L,
                LBS_MULTIPLESEL       = 0x0008L,
                LBS_OWNERDRAWFIXED    = 0x0010L,
                LBS_OWNERDRAWVARIABLE = 0x0020L,
                LBS_HASSTRINGS        = 0x0040L,
                LBS_USETABSTOPS       = 0x0080L,
                LBS_NOINTEGRALHEIGHT  = 0x0100L,
                LBS_MULTICOLUMN       = 0x0200L,
                LBS_WANTKEYBOARDINPUT = 0x0400L,
                LBS_EXTENDEDSEL       = 0x0800L,
                LBS_DISABLENOSCROLL   = 0x1000L,
                LBS_NODATA            = 0x2000L,
                LBS_NOSEL             = 0x4000L,
                LBS_COMBOBOX          = 0x8000L;
            }

            /// <summary>
            /// Class: SysListView32
            /// Based on Windows Kits\8.1\CommCtrl.h
            /// </summary>
            internal static class ListViewStyles
            {
                internal static readonly int
                LVS_ICON            = 0x0000,
                LVS_REPORT          = 0x0001,
                LVS_SMALLICON       = 0x0002,
                LVS_LIST            = 0x0003,
                LVS_TYPEMASK        = 0x0003,
                LVS_SINGLESEL       = 0x0004,
                LVS_SHOWSELALWAYS   = 0x0008,
                LVS_SORTASCENDING   = 0x0010,
                LVS_SORTDESCENDING  = 0x0020,
                LVS_SHAREIMAGELISTS = 0x0040,
                LVS_NOLABELWRAP     = 0x0080,
                LVS_AUTOARRANGE     = 0x0100,
                LVS_EDITLABELS      = 0x0200,
                LVS_OWNERDATA       = 0x1000,
                LVS_NOSCROLL        = 0x2000,
//              LVS_TYPESTYLEMASK   = 0xFC00,
                LVS_ALIGNTOP        = 0x0000,
                LVS_ALIGNLEFT       = 0x0800,
                LVS_ALIGNMASK       = 0x0C00,
                LVS_OWNERDRAWFIXED  = 0x0400,
                LVS_NOCOLUMNHEADER  = 0x4000,
                LVS_NOSORTHEADER    = 0x8000;
            }

            /// <summary>
            /// Class: MDIClient
            /// Based on Windows Kits\8.1\Include\um\WinUser.h
            /// </summary>
            internal static class MDIClientStyles
            {
                internal static readonly int
                MDIS_ALLCHILDSTYLES = 0x0001;
            }

            /// <summary>
            /// Class: SysMonthCal32
            /// Based on Windows Kits\8.1\CommCtrl.h
            /// </summary>
            internal static class MonthCalendarControlStyles
            {
                internal static readonly int
                MCS_DAYSTATE         = 0x0001,
                MCS_MULTISELECT      = 0x0002,
                MCS_WEEKNUMBERS      = 0x0004,
                MCS_NOTODAYCIRCLE    = 0x0008,
                MCS_NOTODAY          = 0x0010,
                MCS_NOTRAILINGDATES  = 0x0040,
                MCS_SHORTDAYSOFWEEK  = 0x0080,
                MCS_NOSELCHANGEONNAV = 0x0100;
            }

            /// <summary>
            /// Class: SysPager
            /// Based on Windows Kits\8.1\CommCtrl.h
            /// </summary>
            internal static class PagerControlStyles
            {
                internal static readonly int
                PGS_VERT       = 0x00000000,
                PGS_HORZ       = 0x00000001,
                PGS_AUTOSCROLL = 0x00000002,
                PGS_DRAGNDROP  = 0x00000004;
            }

            /// <summary>
            /// Class: msctls_progress32
            /// Based on Windows Kits\8.1\CommCtrl.h
            /// </summary>
            internal static class ProgressControlStyles
            {
                internal static readonly int
                PBS_SMOOTH   = 0x01,
                PBS_VERTICAL = 0x04;
            }

            /// <summary>
            /// Class: ScrollBar
            /// Based on Windows Kits\8.1\Include\um\WinUser.h
            /// </summary>
            internal static class ScrollbarStyles
            {
                internal static readonly long
                SBS_HORZ                    = 0x0000L,
                SBS_VERT                    = 0x0001L,
                SBS_TOPALIGN                = 0x0002L,
                SBS_LEFTALIGN               = 0x0002L,
                SBS_BOTTOMALIGN             = 0x0004L,
                SBS_RIGHTALIGN              = 0x0004L,
                SBS_SIZEBOXTOPLEFTALIGN     = 0x0002L,
                SBS_SIZEBOXBOTTOMRIGHTALIGN = 0x0004L,
                SBS_SIZEBOX                 = 0x0008L,
                SBS_SIZEGRIP                = 0x0010L;
            }

            /// <summary>
            /// Class: msctls_statusbar32
            /// Based on Windows Kits\8.1\CommCtrl.h
            /// </summary>
            internal static class StatusBarStyles
            {
                internal static readonly int
                SBARS_SIZEGRIP = 0x0100,
                SBARS_TOOLTIPS = 0x0800,
                SBT_TOOLTIPS   = 0x0800;
            }

            /// <summary>
            /// Class: Static
            /// Based on Windows Kits\8.1\Include\um\WinUser.h
            /// </summary>
            internal static class StaticControlStyles
            {
                internal static readonly long
                SS_LEFT            = 0x00000000L,
                SS_CENTER          = 0x00000001L,
                SS_RIGHT           = 0x00000002L,
                SS_ICON            = 0x00000003L,
                SS_BLACKRECT       = 0x00000004L,
                SS_GRAYRECT        = 0x00000005L,
                SS_WHITERECT       = 0x00000006L,
                SS_BLACKFRAME      = 0x00000007L,
                SS_GRAYFRAME       = 0x00000008L,
                SS_WHITEFRAME      = 0x00000009L,
                SS_USERITEM        = 0x0000000AL,
                SS_SIMPLE          = 0x0000000BL,
                SS_LEFTNOWORDWRAP  = 0x0000000CL,
                SS_OWNERDRAW       = 0x0000000DL,
                SS_BITMAP          = 0x0000000EL,
                SS_ENHMETAFILE     = 0x0000000FL,
                SS_ETCHEDHORZ      = 0x00000010L,
                SS_ETCHEDVERT      = 0x00000011L,
                SS_ETCHEDFRAME     = 0x00000012L,
                SS_TYPEMASK        = 0x0000001FL,
                SS_REALSIZECONTROL = 0x00000040L,
                SS_NOPREFIX        = 0x00000080L,
                SS_NOTIFY          = 0x00000100L,
                SS_CENTERIMAGE     = 0x00000200L,
                SS_RIGHTJUST       = 0x00000400L,
                SS_REALSIZEIMAGE   = 0x00000800L,
                SS_SUNKEN          = 0x00001000L,
                SS_EDITCONTROL     = 0x00002000L,
                SS_ENDELLIPSIS     = 0x00004000L,
                SS_PATHELLIPSIS    = 0x00008000L,
                SS_WORDELLIPSIS    = 0x0000C000L,
                SS_ELLIPSISMASK    = 0x0000C000L;
            }

            /// <summary>
            /// Class: ToolbarWindow32
            /// Based on Windows Kits\8.1\CommCtrl.h
            /// </summary>
            internal static class ToolbarControlStyles
            {
                internal static readonly int
                TBSTYLE_TOOLTIPS     = 0x0100,
                TBSTYLE_WRAPABLE     = 0x0200,
                TBSTYLE_ALTDRAG      = 0x0400,
                TBSTYLE_FLAT         = 0x0800,
                TBSTYLE_LIST         = 0x1000,
                TBSTYLE_CUSTOMERASE  = 0x2000,
                TBSTYLE_REGISTERDROP = 0x4000,
                TBSTYLE_TRANSPARENT  = 0x8000;
            }

            /// <summary>
            /// Class: ReBarWindow32
            /// Based on Windows Kits\8.1\CommCtrl.h
            /// </summary>
            internal static class RebarControlStyles
            {
                internal static readonly int
                RBS_TOOLTIPS        = 0x00000100,
                RBS_VARHEIGHT       = 0x00000200,
                RBS_BANDBORDERS     = 0x00000400,
                RBS_FIXEDORDER      = 0x00000800,
                RBS_REGISTERDROP    = 0x00001000,
                RBS_AUTOSIZE        = 0x00002000,
                RBS_VERTICALGRIPPER = 0x00004000,
                RBS_DBLCLKTOGGLE    = 0x00008000;
            }

            /// <summary>
            /// Class: SysAnimate32
            /// Based on Windows Kits\8.1\CommCtrl.h
            /// </summary>
            internal static class AnimationControlStyles
            {
                internal static readonly int
                ACS_CENTER      = 0x0001,
                ACS_TRANSPARENT = 0x0002,
                ACS_AUTOPLAY    = 0x0004,
                ACS_TIMER       = 0x0008;
            }

            /// <summary>
            /// Class: SysLink
            /// Based on Windows Kits\8.1\CommCtrl.h
            /// </summary>
            internal static class SysLinkControlStyles
            {
                internal static readonly int
                LWS_TRANSPARENT     = 0x0001,
                LWS_IGNORERETURN    = 0x0002,
                LWS_NOPREFIX        = 0x0004,
                LWS_USEVISUALSTYLE  = 0x0008,
                LWS_USECUSTOMTEXT   = 0x0010,
                LWS_RIGHT           = 0x0020;
            }

            /// <summary>
            /// Class: msctls_trackbar32
            /// Based on Windows Kits\8.1\CommCtrl.h
            /// </summary>
            internal static class TrackbarControlStyles
            {
                internal static readonly int
                TBS_AUTOTICKS        = 0x0001,
                TBS_VERT             = 0x0002,
                TBS_HORZ             = 0x0000,
                TBS_TOP              = 0x0004,
                TBS_BOTTOM           = 0x0000,
                TBS_LEFT             = 0x0004,
                TBS_RIGHT            = 0x0000,
                TBS_BOTH             = 0x0008,
                TBS_NOTICKS          = 0x0010,
                TBS_ENABLESELRANGE   = 0x0020,
                TBS_FIXEDLENGTH      = 0x0040,
                TBS_NOTHUMB          = 0x0080,
                TBS_TOOLTIPS         = 0x0100,
                TBS_REVERSED         = 0x0200,
                TBS_DOWNISLEFT       = 0x0400,
                TBS_NOTIFYBEFOREMOVE = 0x0800,
                TBS_TRANSPARENTBKGND = 0x1000;
            }

            /// <summary>
            /// Class: SysTabControl32
            /// Based on Windows Kits\8.1\CommCtrl.h
            /// </summary>
            internal static class TabControlStyles
            {
                internal static readonly int
                TCS_SCROLLOPPOSITE    = 0x0001,
                TCS_BOTTOM            = 0x0002,
                TCS_RIGHT             = 0x0002,
                TCS_MULTISELECT       = 0x0004,
                TCS_FLATBUTTONS       = 0x0008,
                TCS_FORCEICONLEFT     = 0x0010,
                TCS_FORCELABELLEFT    = 0x0020,
                TCS_HOTTRACK          = 0x0040,
                TCS_VERTICAL          = 0x0080,
                TCS_TABS              = 0x0000,
                TCS_BUTTONS           = 0x0100,
                TCS_SINGLELINE        = 0x0000,
                TCS_MULTILINE         = 0x0200,
                TCS_RIGHTJUSTIFY      = 0x0000,
                TCS_FIXEDWIDTH        = 0x0400,
                TCS_RAGGEDRIGHT       = 0x0800,
                TCS_FOCUSONBUTTONDOWN = 0x1000,
                TCS_OWNERDRAWFIXED    = 0x2000,
                TCS_TOOLTIPS          = 0x4000,
                TCS_FOCUSNEVER        = 0x8000;
            }

            /// <summary>
            /// Class: tooltips_class32
            /// Based on Windows Kits\8.1\CommCtrl.h
            /// </summary>
            internal static class TooltipStyles
            {
                internal static readonly int
                TTS_ALWAYSTIP      = 0x01,
                TTS_NOPREFIX       = 0x02,
                TTS_NOANIMATE      = 0x10,
                TTS_NOFADE         = 0x20,
                TTS_BALLOON        = 0x40,
                TTS_CLOSE          = 0x80,
                TTS_USEVISUALSTYLE = 0x100;
            }

            /// <summary>
            /// Class: SysTreeView32
            /// Based on Windows Kits\8.1\CommCtrl.h
            /// </summary>
            internal static class TreeViewControlStyles
            {
                internal static readonly int
                TVS_HASBUTTONS      = 0x0001,
                TVS_HASLINES        = 0x0002,
                TVS_LINESATROOT     = 0x0004,
                TVS_EDITLABELS      = 0x0008,
                TVS_DISABLEDRAGDROP = 0x0010,
                TVS_SHOWSELALWAYS   = 0x0020,
                TVS_RTLREADING      = 0x0040,
                TVS_NOTOOLTIPS      = 0x0080,
                TVS_CHECKBOXES      = 0x0100,
                TVS_TRACKSELECT     = 0x0200,
                TVS_SINGLEEXPAND    = 0x0400,
                TVS_INFOTIP         = 0x0800,
                TVS_FULLROWSELECT   = 0x1000,
                TVS_NOSCROLL        = 0x2000,
                TVS_NONEVENHEIGHT   = 0x4000,
                TVS_NOHSCROLL       = 0x8000;
            }

            /// <summary>
            /// Class: msctls_updown32
            /// Based on Windows Kits\8.1\CommCtrl.h
            /// </summary>
            internal static class UpDownControlStyles
            {
                internal static readonly int
                UDS_WRAP        = 0x0001,
                UDS_SETBUDDYINT = 0x0002,
                UDS_ALIGNRIGHT  = 0x0004,
                UDS_ALIGNLEFT   = 0x0008,
                UDS_AUTOBUDDY   = 0x0010,
                UDS_ARROWKEYS   = 0x0020,
                UDS_HORZ        = 0x0040,
                UDS_NOTHOUSANDS = 0x0080,
                UDS_HOTTRACK    = 0x0100;
            }
        }

        #endregion
        #region Process Priority Definitions

        /// <summary>
        /// As documented on:
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms683211(v=vs.85).aspx
        /// </summary>
        internal static class PriorityClass
        {
            internal static readonly uint
            NORMAL_PRIORITY_CLASS         = 0x20,
            IDLE_PRIORITY_CLASS           = 0x40,
            HIGH_PRIORITY_CLASS           = 0x80,
            REALTIME_PRIORITY_CLASS       = 0x100,
            BELOW_NORMAL_PRIORITY_CLASS   = 0x4000,
            ABOVE_NORMAL_PRIORITY_CLASS   = 0x8000,
            PROCESS_MODE_BACKGROUND_BEGIN = 0x100000,
            PROCESS_MODE_BACKGROUND_END   = 0x200000;
        }

        #endregion
    }   
}