/* Separator.cs
** This file is part #Find.
** 
** Copyright 2017 by Babiker M Babiker<bestivitiness@gmail.com>
** Licensed under MIT
** <https://github.com/Zedohsix/SharpFind>
*/

using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System;
using SharpFind.Classes;

namespace SharpFind.Forms
{
    public partial class Frm_ModuleInfo : Form
    {
        public Frm_ModuleInfo()
        {
            InitializeComponent();
        }

        private Process ParentProcess { get; set; }
        private static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
        private int moduleCount, threadCount;

        #region Events

        private void Frm_ModuleInfo_Load(object sender, EventArgs e)
        {
            GetModuleSummary();

            if (LBL_Path_R.Text != string.Empty)
            {
                GetModuleDetails(ParentProcess.Id);
                GetThreadDetails(ParentProcess.Id);
            }
        }

        private void LNKLBL_Explore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowFileInExplorer(LBL_Path_R.Text);
        }

        private void TC_Details_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (TC_Details.SelectedIndex)
            {
                case 0:
                    if (!LV_Module.Visible)
                    {
                        LV_Thread.Visible = false;
                        LV_Module.Visible = true;
                        LV_Module.BringToFront();
                    }
                    break;
                case 1:
                    if (!LV_Thread.Visible)
                    {
                        LV_Module.Visible = false;
                        LV_Thread.Visible = true;
                        LV_Thread.BringToFront();
                    }
                    break;
            }
        }

        private void LV_Module_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowObjectProperties(LV_Module.SelectedItems[0].Tag?.ToString());
        }

        private void BTN_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
        #region Functions

        /// <summary>
        /// Formats the given numeric value into KB, MB, GB, etc.
        /// </summary>
        /// 
        /// <param name="byteCount">
        /// Number of bytes to be formatted.
        /// </param>
        private static string FormatByteSize(long byteCount)
        {
            var sb = new StringBuilder(10);
            NativeMethods.StrFormatByteSize(byteCount, sb, sb.Capacity);

            return sb.ToString();
        }

        private static IntPtr GetThreadStartAddress(uint tid)
        {
            var hThread = NativeMethods.OpenThread(NativeMethods.ThreadAccess.QUERY_INFORMATION, false, tid);
            if (hThread == IntPtr.Zero)
                throw new Win32Exception(Marshal.GetLastWin32Error(), "Unable to open thread.");

            var dwStartAddress = Marshal.AllocHGlobal(IntPtr.Size);
            try
            {
                const int STATUS_SUCCESS = 0x0;
                const NativeMethods.THREADINFOCLASS flag = NativeMethods.THREADINFOCLASS.ThreadQuerySetWin32StartAddress;
                var ntStatus = NativeMethods.NtQueryInformationThread(hThread, flag, dwStartAddress, IntPtr.Size, IntPtr.Zero);
                if (ntStatus != STATUS_SUCCESS)
                    throw new Win32Exception($"NtQueryInformationThread failure. NTSTATUS returns 0x{ntStatus:X4}.");

                return Marshal.ReadIntPtr(dwStartAddress);
            }
            finally
            {
                NativeMethods.CloseHandle(hThread);
                Marshal.FreeHGlobal(dwStartAddress);
            }
        }

        /// <summary>
        /// Returns the actual start address of a thread.
        /// </summary>
        /// 
        /// <param name="p">
        /// The target process that is used to retrieve information about the
        /// modules.
        /// </param>
        /// 
        /// <param name="startAddress">
        /// Address of function's first byte in target process.
        /// </param>
        private static string GetThreadStartAddress(Process p, long startAddress)
        {
            foreach (ProcessModule pm in p.Modules)
            {
                if (startAddress >= (long)pm.BaseAddress && startAddress <= (long)pm.BaseAddress + pm.ModuleMemorySize)
                    return pm.ModuleName + "+0x" + (startAddress - (long)pm.BaseAddress).ToString("X2");
            }
            return string.Empty;
        }

        #endregion
        #region Methods

        /// <summary>
        /// Opens the directory of the designated file in Explorer and selects it.
        /// </summary>
        /// 
        /// <param name="path">
        /// Path to the file.
        /// </param>
        private static void ShowFileInExplorer(string path)
        {
            var winDir = Environment.GetEnvironmentVariable("windir");
            if (winDir == null)
                return;

            var explorer = Path.Combine(winDir, "explorer.exe");
            var args = $"/select, {"\"" + path + "\""}";
            Process.Start(explorer, args);
        }

        /// <summary>
        /// Displays the properties windows for the specified file.
        /// </summary>
        /// 
        /// <param name="path">
        /// Path to the file.
        /// </param>
        private static void ShowObjectProperties(string path)
        {
            const int SW_SHOW = 5;

            var info    = new NativeMethods.SHELLEXECUTEINFO();
            info.cbSize = Marshal.SizeOf(info);
            info.lpVerb = "properties";
            info.lpFile = path;
            info.nShow  = SW_SHOW;
            info.fMask  = 0xc;

            if (!NativeMethods.ShellExecuteEx(ref info))
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        /// <summary>
        /// Retrieves very minimal information about the specified process.
        /// </summary>
        private void GetModuleSummary()
        {
            var pNoExt = Path.GetFileNameWithoutExtension(LBL_Process_R.Text);
            foreach (var p in Process.GetProcessesByName(pNoExt))
            {
                if (p.ProcessName == "Idle" || p.ProcessName == "System")
                    return;

                // Retrieve the process icon
                using (var moduleIcon = Icon.ExtractAssociatedIcon(p.MainModule.FileName))
                    PB_Icon.Image = moduleIcon?.ToBitmap();

                LBL_PID_R.Text  = Convert.ToString(p.Id);
                LBL_Path_R.Text = p.MainModule.FileName;

                ParentProcess = p;
            }
        }

        /// <summary>
        /// Retrieves the names of all loaded modules in the process, their base
        /// address and size on disk.
        /// </summary>
        /// 
        /// <param name="pid">
        /// Id of the process.
        /// </param>
        private void GetModuleDetails(int pid)
        {
            const NativeMethods.SnapshotFlags flags = NativeMethods.SnapshotFlags.TH32CS_SNAPMODULE | 
                                                      NativeMethods.SnapshotFlags.TH32CS_SNAPMODULE32;

            var hModuleSnap = NativeMethods.CreateToolhelp32Snapshot(flags, pid);
            if (hModuleSnap == INVALID_HANDLE_VALUE)
                return;

            var modEntry = new NativeMethods.MODULEENTRY32()
            {
                dwSize = (uint)Marshal.SizeOf(typeof(NativeMethods.MODULEENTRY32)),
                th32ModuleID = 0
            };

            if (!NativeMethods.Module32First(hModuleSnap, ref modEntry))
            {
                NativeMethods.CloseHandle(hModuleSnap);
                return;
            }

            do
            {
                try
                {
                    var modPath = modEntry.szExePath;
                    var modInfo = FileVersionInfo.GetVersionInfo(modPath);
                    var modSize = new FileInfo(modPath).Length;
                    var lvi     = new ListViewItem(modEntry.szModule)
                    {
                        Tag         = modInfo.FileName,
                        ToolTipText = modInfo.FileName        + "\n" +
                                      modInfo.LegalCopyright  + "\n" +
                                      modInfo.FileDescription + "\n" +
                                      modInfo.ProductVersion
                    };
                    lvi.SubItems.Add("0x" + modEntry.modBaseAddr.ToString("X4"));
                    lvi.SubItems.Add(FormatByteSize(modSize));
                    LV_Module.Items.Add(lvi);
                }
                catch
                {
                     break;
                }
            }
            while (NativeMethods.Module32Next(hModuleSnap, ref modEntry));

            // Close the object
            NativeMethods.CloseHandle(hModuleSnap);

            /* Sort the items and remove the duplicate module name. The
            ** duplication happens because SnapshotFlags searches for both 32-bit
            ** and 64-bit modules. Therefore, it adds the main module from both
            ** TH32CS_SNAPMODULE and TH32CS_SNAPMODULE32.
            */
            LV_Module.Items[0].BackColor = SystemColors.GradientActiveCaption;
            LV_Module.Sorting = SortOrder.Ascending;
            for (var i = 0; i < LV_Module.Items.Count - 1; i++)
            {
                if (LV_Module.Items[i].Tag.Equals(LV_Module.Items[i + 1].Tag))
                {
                    LV_Module.Items[i].BackColor = SystemColors.GradientActiveCaption;
                    LV_Module.Items[i + 1].Remove();
                    i--;
                }
                moduleCount = i;
            }

            SetModuleCount();
        }

        private void SetModuleCount()
        {
            LBL_Modules_R.Text = $"{moduleCount} modules attached;"; 
        }

        /// <summary>
        /// Retrieves the thread Ids, starting address, and priority level of
        /// the specified process.
        /// </summary>
        private void GetThreadDetails(int pid)
        {
            const NativeMethods.SnapshotFlags flags = NativeMethods.SnapshotFlags.TH32CS_SNAPTHREAD;
            var hModuleSnap = NativeMethods.CreateToolhelp32Snapshot(flags, pid);
            if (hModuleSnap == INVALID_HANDLE_VALUE)
                return;

            var threadEntry = new NativeMethods.THREADENTRY32
            {
                dwSize   = (uint)Marshal.SizeOf(typeof(NativeMethods.THREADENTRY32)),
                cntUsage = 0
            };

            if (!NativeMethods.Thread32First(hModuleSnap, ref threadEntry))
            {
                NativeMethods.CloseHandle(hModuleSnap);
                return;
            }

            do
            {
                if (threadEntry.th32OwnerProcessID == pid)
                {
                    var lvi      = new ListViewItem(threadEntry.th32ThreadID.ToString());
                    var address  = (long)GetThreadStartAddress(threadEntry.th32ThreadID);
                    var priority = string.Empty;

                    lvi.SubItems.Add(GetThreadStartAddress(ParentProcess, address));

                    switch (threadEntry.tpBasePri)
                    {
                        case  1: priority = "Idle";          break;
                        case  6: priority = "Lowest";        break;
                        case  7: priority = "Below Normal";  break;
                        case  8: priority = "Normal";        break;
                        case  9: priority = "Above Normal";  break;
                        case 10: priority = "Highest";       break;
                        case 15: priority = "Time Critical"; break;
                    }

                    lvi.SubItems.Add(priority /* + " (" + threadEntry.tpBasePri + ")" */);
                    LV_Thread.Items.Add(lvi);
                }
            }
            while (NativeMethods.Thread32Next(hModuleSnap, ref threadEntry));

            // Close the object
            NativeMethods.CloseHandle(hModuleSnap);

            LV_Thread.Sorting = SortOrder.Ascending;
            threadCount = LV_Thread.Items.Count;
            SetThreadCount();
        }

        private void SetThreadCount()
        {
            LBL_Modules_R.Text = LBL_Modules_R.Text + $" {threadCount} threads";
        }

        #endregion
    }
}