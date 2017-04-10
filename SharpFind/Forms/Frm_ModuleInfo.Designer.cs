namespace SharpFind.Forms
{
    partial class Frm_ModuleInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GB_Summary = new System.Windows.Forms.GroupBox();
            this.LBL_Path_R = new System.Windows.Forms.Label();
            this.LBL_Process_R = new System.Windows.Forms.Label();
            this.LBL_PID_R = new System.Windows.Forms.Label();
            this.LBL_Modules_R = new System.Windows.Forms.Label();
            this.LBL_Path = new System.Windows.Forms.Label();
            this.LBL_Modules = new System.Windows.Forms.Label();
            this.LBL_PID = new System.Windows.Forms.Label();
            this.LBL_Process = new System.Windows.Forms.Label();
            this.PB_Icon = new System.Windows.Forms.PictureBox();
            this.TC_Details = new System.Windows.Forms.TabControl();
            this.TP_Module = new System.Windows.Forms.TabPage();
            this.TP_Thread = new System.Windows.Forms.TabPage();
            this.BTN_Close = new System.Windows.Forms.Button();
            this.PNL_Top = new System.Windows.Forms.Panel();
            this.PNL_Bottom = new System.Windows.Forms.Panel();
            this.separator1 = new SharpFind.Controls.Separator();
            this.LV_Module = new SharpFind.Controls.ListViewEx();
            this.COL_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.COL_Base = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.COL_Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LV_Thread = new SharpFind.Controls.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.separator2 = new SharpFind.Controls.Separator();
            this.LNKLBL_Explore = new SharpFind.Controls.LinkLabelEx();
            this.GB_Summary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Icon)).BeginInit();
            this.TC_Details.SuspendLayout();
            this.PNL_Top.SuspendLayout();
            this.PNL_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // GB_Summary
            // 
            this.GB_Summary.Controls.Add(this.separator2);
            this.GB_Summary.Controls.Add(this.LNKLBL_Explore);
            this.GB_Summary.Controls.Add(this.LBL_Path_R);
            this.GB_Summary.Controls.Add(this.LBL_Process_R);
            this.GB_Summary.Controls.Add(this.LBL_PID_R);
            this.GB_Summary.Controls.Add(this.LBL_Modules_R);
            this.GB_Summary.Controls.Add(this.LBL_Path);
            this.GB_Summary.Controls.Add(this.LBL_Modules);
            this.GB_Summary.Controls.Add(this.LBL_PID);
            this.GB_Summary.Controls.Add(this.LBL_Process);
            this.GB_Summary.Controls.Add(this.PB_Icon);
            this.GB_Summary.Location = new System.Drawing.Point(8, 8);
            this.GB_Summary.Name = "GB_Summary";
            this.GB_Summary.Size = new System.Drawing.Size(406, 83);
            this.GB_Summary.TabIndex = 0;
            this.GB_Summary.TabStop = false;
            // 
            // LBL_Path_R
            // 
            this.LBL_Path_R.AutoEllipsis = true;
            this.LBL_Path_R.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LBL_Path_R.Location = new System.Drawing.Point(133, 62);
            this.LBL_Path_R.Name = "LBL_Path_R";
            this.LBL_Path_R.Size = new System.Drawing.Size(221, 13);
            this.LBL_Path_R.TabIndex = 9;
            this.LBL_Path_R.Text = "-";
            // 
            // LBL_Process_R
            // 
            this.LBL_Process_R.AutoSize = true;
            this.LBL_Process_R.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LBL_Process_R.Location = new System.Drawing.Point(133, 14);
            this.LBL_Process_R.Name = "LBL_Process_R";
            this.LBL_Process_R.Size = new System.Drawing.Size(10, 13);
            this.LBL_Process_R.TabIndex = 8;
            this.LBL_Process_R.Text = "-";
            // 
            // LBL_PID_R
            // 
            this.LBL_PID_R.AutoSize = true;
            this.LBL_PID_R.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LBL_PID_R.Location = new System.Drawing.Point(133, 30);
            this.LBL_PID_R.Name = "LBL_PID_R";
            this.LBL_PID_R.Size = new System.Drawing.Size(10, 13);
            this.LBL_PID_R.TabIndex = 7;
            this.LBL_PID_R.Text = "-";
            // 
            // LBL_Modules_R
            // 
            this.LBL_Modules_R.AutoSize = true;
            this.LBL_Modules_R.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LBL_Modules_R.Location = new System.Drawing.Point(133, 46);
            this.LBL_Modules_R.Name = "LBL_Modules_R";
            this.LBL_Modules_R.Size = new System.Drawing.Size(10, 13);
            this.LBL_Modules_R.TabIndex = 6;
            this.LBL_Modules_R.Text = "-";
            // 
            // LBL_Path
            // 
            this.LBL_Path.AutoSize = true;
            this.LBL_Path.Location = new System.Drawing.Point(81, 62);
            this.LBL_Path.Name = "LBL_Path";
            this.LBL_Path.Size = new System.Drawing.Size(29, 13);
            this.LBL_Path.TabIndex = 5;
            this.LBL_Path.Text = "Path";
            // 
            // LBL_Modules
            // 
            this.LBL_Modules.AutoSize = true;
            this.LBL_Modules.Location = new System.Drawing.Point(81, 46);
            this.LBL_Modules.Name = "LBL_Modules";
            this.LBL_Modules.Size = new System.Drawing.Size(47, 13);
            this.LBL_Modules.TabIndex = 4;
            this.LBL_Modules.Text = "Modules";
            // 
            // LBL_PID
            // 
            this.LBL_PID.AutoSize = true;
            this.LBL_PID.Location = new System.Drawing.Point(81, 31);
            this.LBL_PID.Name = "LBL_PID";
            this.LBL_PID.Size = new System.Drawing.Size(25, 13);
            this.LBL_PID.TabIndex = 3;
            this.LBL_PID.Text = "PID";
            // 
            // LBL_Process
            // 
            this.LBL_Process.AutoSize = true;
            this.LBL_Process.Location = new System.Drawing.Point(81, 14);
            this.LBL_Process.Name = "LBL_Process";
            this.LBL_Process.Size = new System.Drawing.Size(45, 13);
            this.LBL_Process.TabIndex = 2;
            this.LBL_Process.Text = "Process";
            // 
            // PB_Icon
            // 
            this.PB_Icon.Location = new System.Drawing.Point(13, 12);
            this.PB_Icon.Name = "PB_Icon";
            this.PB_Icon.Size = new System.Drawing.Size(49, 64);
            this.PB_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PB_Icon.TabIndex = 0;
            this.PB_Icon.TabStop = false;
            // 
            // TC_Details
            // 
            this.TC_Details.Controls.Add(this.TP_Module);
            this.TC_Details.Controls.Add(this.TP_Thread);
            this.TC_Details.Location = new System.Drawing.Point(8, 103);
            this.TC_Details.Name = "TC_Details";
            this.TC_Details.SelectedIndex = 0;
            this.TC_Details.Size = new System.Drawing.Size(406, 20);
            this.TC_Details.TabIndex = 1;
            this.TC_Details.SelectedIndexChanged += new System.EventHandler(this.TC_Details_SelectedIndexChanged);
            // 
            // TP_Module
            // 
            this.TP_Module.Location = new System.Drawing.Point(4, 22);
            this.TP_Module.Name = "TP_Module";
            this.TP_Module.Size = new System.Drawing.Size(398, 0);
            this.TP_Module.TabIndex = 0;
            this.TP_Module.Text = "Module Details";
            this.TP_Module.UseVisualStyleBackColor = true;
            // 
            // TP_Thread
            // 
            this.TP_Thread.Location = new System.Drawing.Point(4, 22);
            this.TP_Thread.Name = "TP_Thread";
            this.TP_Thread.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Thread.Size = new System.Drawing.Size(398, 0);
            this.TP_Thread.TabIndex = 1;
            this.TP_Thread.Text = "Thread Details";
            this.TP_Thread.UseVisualStyleBackColor = true;
            // 
            // BTN_Close
            // 
            this.BTN_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTN_Close.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BTN_Close.Location = new System.Drawing.Point(340, 353);
            this.BTN_Close.Name = "BTN_Close";
            this.BTN_Close.Size = new System.Drawing.Size(75, 23);
            this.BTN_Close.TabIndex = 3;
            this.BTN_Close.Text = "&Close";
            this.BTN_Close.UseVisualStyleBackColor = true;
            this.BTN_Close.Click += new System.EventHandler(this.BTN_Close_Click);
            // 
            // PNL_Top
            // 
            this.PNL_Top.Controls.Add(this.GB_Summary);
            this.PNL_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.PNL_Top.Location = new System.Drawing.Point(0, 0);
            this.PNL_Top.Name = "PNL_Top";
            this.PNL_Top.Padding = new System.Windows.Forms.Padding(5);
            this.PNL_Top.Size = new System.Drawing.Size(422, 97);
            this.PNL_Top.TabIndex = 4;
            // 
            // PNL_Bottom
            // 
            this.PNL_Bottom.Controls.Add(this.separator1);
            this.PNL_Bottom.Controls.Add(this.LV_Module);
            this.PNL_Bottom.Controls.Add(this.BTN_Close);
            this.PNL_Bottom.Controls.Add(this.LV_Thread);
            this.PNL_Bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNL_Bottom.Location = new System.Drawing.Point(0, 97);
            this.PNL_Bottom.Name = "PNL_Bottom";
            this.PNL_Bottom.Size = new System.Drawing.Size(422, 384);
            this.PNL_Bottom.TabIndex = 5;
            // 
            // separator1
            // 
            this.separator1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.separator1.Location = new System.Drawing.Point(8, 359);
            this.separator1.Name = "separator1";
            this.separator1.Orientation = SharpFind.Controls.Separator._Orientation.Horizontal;
            this.separator1.Size = new System.Drawing.Size(326, 10);
            this.separator1.TabIndex = 11;
            // 
            // LV_Module
            // 
            this.LV_Module.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LV_Module.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.COL_Name,
            this.COL_Base,
            this.COL_Size});
            this.LV_Module.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LV_Module.FullRowSelect = true;
            this.LV_Module.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LV_Module.Location = new System.Drawing.Point(8, 26);
            this.LV_Module.Name = "LV_Module";
            this.LV_Module.ShowItemToolTips = true;
            this.LV_Module.Size = new System.Drawing.Size(406, 319);
            this.LV_Module.TabIndex = 0;
            this.LV_Module.TileSize = new System.Drawing.Size(168, 45);
            this.LV_Module.UseCompatibleStateImageBehavior = false;
            this.LV_Module.View = System.Windows.Forms.View.Details;
            this.LV_Module.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LV_Module_MouseDoubleClick);
            // 
            // COL_Name
            // 
            this.COL_Name.Text = "Name";
            this.COL_Name.Width = 184;
            // 
            // COL_Base
            // 
            this.COL_Base.Text = "Base Address";
            this.COL_Base.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.COL_Base.Width = 115;
            // 
            // COL_Size
            // 
            this.COL_Size.Text = "Size";
            this.COL_Size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.COL_Size.Width = 85;
            // 
            // LV_Thread
            // 
            this.LV_Thread.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LV_Thread.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.LV_Thread.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LV_Thread.FullRowSelect = true;
            this.LV_Thread.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LV_Thread.Location = new System.Drawing.Point(8, 26);
            this.LV_Thread.Name = "LV_Thread";
            this.LV_Thread.ShowItemToolTips = true;
            this.LV_Thread.Size = new System.Drawing.Size(406, 319);
            this.LV_Thread.TabIndex = 6;
            this.LV_Thread.TileSize = new System.Drawing.Size(168, 45);
            this.LV_Thread.UseCompatibleStateImageBehavior = false;
            this.LV_Thread.View = System.Windows.Forms.View.Details;
            this.LV_Thread.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Thread Id";
            this.columnHeader1.Width = 63;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Start Address";
            this.columnHeader2.Width = 236;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Priority Level";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 85;
            // 
            // separator2
            // 
            this.separator2.Location = new System.Drawing.Point(66, 16);
            this.separator2.Name = "separator2";
            this.separator2.Orientation = SharpFind.Controls.Separator._Orientation.Vertical;
            this.separator2.Size = new System.Drawing.Size(10, 57);
            this.separator2.TabIndex = 11;
            // 
            // LNKLBL_Explore
            // 
            this.LNKLBL_Explore.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(159)))));
            this.LNKLBL_Explore.AutoSize = true;
            this.LNKLBL_Explore.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LNKLBL_Explore.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.LNKLBL_Explore.Location = new System.Drawing.Point(360, 62);
            this.LNKLBL_Explore.Name = "LNKLBL_Explore";
            this.LNKLBL_Explore.Size = new System.Drawing.Size(41, 13);
            this.LNKLBL_Explore.TabIndex = 10;
            this.LNKLBL_Explore.TabStop = true;
            this.LNKLBL_Explore.Text = "explore";
            this.LNKLBL_Explore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LNKLBL_Explore_LinkClicked);
            // 
            // Frm_ModuleInfo
            // 
            this.AcceptButton = this.BTN_Close;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 481);
            this.Controls.Add(this.TC_Details);
            this.Controls.Add(this.PNL_Bottom);
            this.Controls.Add(this.PNL_Top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ModuleInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Module Info";
            this.Load += new System.EventHandler(this.Frm_ModuleInfo_Load);
            this.GB_Summary.ResumeLayout(false);
            this.GB_Summary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Icon)).EndInit();
            this.TC_Details.ResumeLayout(false);
            this.PNL_Top.ResumeLayout(false);
            this.PNL_Bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GB_Summary;
        private System.Windows.Forms.TabControl TC_Details;
        private System.Windows.Forms.TabPage TP_Module;
        private System.Windows.Forms.TabPage TP_Thread;
        private System.Windows.Forms.Button BTN_Close;
        private System.Windows.Forms.Panel PNL_Top;
        private System.Windows.Forms.Panel PNL_Bottom;
        private System.Windows.Forms.PictureBox PB_Icon;
        private System.Windows.Forms.Label LBL_Path;
        private System.Windows.Forms.Label LBL_Modules;
        private System.Windows.Forms.Label LBL_PID;
        private System.Windows.Forms.Label LBL_Process;
        private Controls.LinkLabelEx LNKLBL_Explore;
        internal System.Windows.Forms.Label LBL_Path_R;
        internal System.Windows.Forms.Label LBL_Process_R;
        internal System.Windows.Forms.Label LBL_PID_R;
        internal System.Windows.Forms.Label LBL_Modules_R;
        private Controls.ListViewEx LV_Module;
        private System.Windows.Forms.ColumnHeader COL_Name;
        private System.Windows.Forms.ColumnHeader COL_Base;
        private System.Windows.Forms.ColumnHeader COL_Size;
        private Controls.Separator separator1;
        private Controls.Separator separator2;
        private Controls.ListViewEx LV_Thread;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}