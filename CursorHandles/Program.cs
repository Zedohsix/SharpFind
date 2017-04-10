using System.Windows.Forms;
using System;

namespace CursorHandles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();

            Console.WriteLine(Environment.OSVersion.VersionString + "\n");

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("CURSOR      | IDENTIFIER      | HEX     | DEC ");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("AppStarting | IDC_APPSTARTING | " + "0x" + Cursors.AppStarting.Handle.ToString("X") + " | " + Cursors.AppStarting.Handle);
            Console.WriteLine("Arrow       | IDC_ARROW       | " + "0x" + Cursors.Arrow.Handle.ToString("X")       + " | " + Cursors.Arrow.Handle);
            Console.WriteLine("Cross       | IDC_CROSS       | " + "0x" + Cursors.Cross.Handle.ToString("X")       + " | " + Cursors.Cross.Handle);
            Console.WriteLine("Help        | IDC_HELP        | " + "0x" + Cursors.Help.Handle.ToString("X")        + " | " + Cursors.Help.Handle);
            Console.WriteLine("IBeam       | IDC_IBEAM       | " + "0x" + Cursors.IBeam.Handle.ToString("X")       + " | " + Cursors.IBeam.Handle);
            Console.WriteLine("No          | IDC_NO          | " + "0x" + Cursors.No.Handle.ToString("X")          + " | " + Cursors.No.Handle);
            Console.WriteLine("SizeAll     | IDC_SIZEALL     | " + "0x" + Cursors.SizeAll.Handle.ToString("X")     + " | " + Cursors.SizeAll.Handle);
            Console.WriteLine("SizeNESW    | IDC_SIZENESW    | " + "0x" + Cursors.SizeNESW.Handle.ToString("X")    + " | " + Cursors.SizeNESW.Handle);
            Console.WriteLine("SizeNS      | IDC_SIZENS      | " + "0x" + Cursors.SizeNS.Handle.ToString("X")      + " | " + Cursors.SizeNS.Handle);
            Console.WriteLine("SizeNWSE    | IDC_SIZENWSE    | " + "0x" + Cursors.SizeNWSE.Handle.ToString("X")    + " | " + Cursors.SizeNWSE.Handle);
            Console.WriteLine("SizeWE      | IDC_SIZEWE      | " + "0x" + Cursors.SizeWE.Handle.ToString("X")      + " | " + Cursors.SizeWE.Handle);
            Console.WriteLine("UpArrow     | IDC_UPARROW     | " + "0x" + Cursors.UpArrow.Handle.ToString("X")     + " | " + Cursors.UpArrow.Handle);
            Console.WriteLine("WaitCursor  | IDC_WAIT        | " + "0x" + Cursors.WaitCursor.Handle.ToString("X")  + " | " + Cursors.WaitCursor.Handle);

            Console.WriteLine("\nPress F to pay respects");
            Console.ReadKey();
        }
    }
}
