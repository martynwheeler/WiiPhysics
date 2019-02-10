namespace WiiPhysics
{
    partial class frmMDIMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMDIMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileCloseChild = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpenInsight = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsCollectionMode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsTiming = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsReconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsTableData = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowTileVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowTileHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogging = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoggingStart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoggingStop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpContents = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpIndex = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuHelpUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuTools,
            this.mnuWindow,
            this.mnuLogging,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.mnuWindow;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(813, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileNew,
            this.mnuFileOpen,
            this.mnuFileSep1,
            this.mnuFileCloseChild,
            this.mnuFileSep2,
            this.mnuFileSave,
            this.mnuFileOpenInsight,
            this.mnuFileSep3,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuFile.Size = new System.Drawing.Size(35, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileNew
            // 
            this.mnuFileNew.Enabled = false;
            this.mnuFileNew.Image = ((System.Drawing.Image)(resources.GetObject("mnuFileNew.Image")));
            this.mnuFileNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuFileNew.Name = "mnuFileNew";
            this.mnuFileNew.Size = new System.Drawing.Size(240, 22);
            this.mnuFileNew.Text = "&New";
            this.mnuFileNew.Visible = false;
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Enabled = false;
            this.mnuFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("mnuFileOpen.Image")));
            this.mnuFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(202, 22);
            this.mnuFileOpen.Text = "&Open";
            this.mnuFileOpen.Visible = false;
            // 
            // mnuFileSep1
            // 
            this.mnuFileSep1.Name = "mnuFileSep1";
            this.mnuFileSep1.Size = new System.Drawing.Size(199, 6);
            this.mnuFileSep1.Visible = false;
            // 
            // mnuFileCloseChild
            // 
            this.mnuFileCloseChild.Name = "mnuFileCloseChild";
            this.mnuFileCloseChild.Size = new System.Drawing.Size(202, 22);
            this.mnuFileCloseChild.Text = "&Close Window";
            this.mnuFileCloseChild.Click += new System.EventHandler(this.mnuFileCloseWindow_Click);
            // 
            // mnuFileSep2
            // 
            this.mnuFileSep2.Name = "mnuFileSep2";
            this.mnuFileSep2.Size = new System.Drawing.Size(199, 6);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuFileSave.Image")));
            this.mnuFileSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(202, 22);
            this.mnuFileSave.Text = "&Save";
            this.mnuFileSave.ToolTipText = "Save the current data";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // mnuFileOpenInsight
            // 
            this.mnuFileOpenInsight.Name = "mnuFileOpenInsight";
            this.mnuFileOpenInsight.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuFileOpenInsight.Size = new System.Drawing.Size(240, 22);
            this.mnuFileOpenInsight.Text = "&View Data in iLOG Studio";
            this.mnuFileOpenInsight.Click += new System.EventHandler(this.mnuFileOpenInsight_Click);
            // 
            // mnuFileSep3
            // 
            this.mnuFileSep3.Name = "mnuFileSep3";
            this.mnuFileSep3.Size = new System.Drawing.Size(199, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(202, 22);
            this.mnuFileExit.Text = "E&xit";
            this.mnuFileExit.ToolTipText = "Quit WiiMote Physics";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolsCollectionMode,
            this.mnuToolsTiming,
            this.mnuToolsReconnect,
            this.mnuToolsTableData});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(44, 20);
            this.mnuTools.Text = "&Tools";
            // 
            // mnuToolsCollectionMode
            // 
            this.mnuToolsCollectionMode.Name = "mnuToolsCollectionMode";
            this.mnuToolsCollectionMode.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.mnuToolsCollectionMode.Size = new System.Drawing.Size(230, 22);
            this.mnuToolsCollectionMode.Text = "Collection &Mode";
            this.mnuToolsCollectionMode.ToolTipText = "Setup data collection";
            this.mnuToolsCollectionMode.Click += new System.EventHandler(this.mnuToolsCollectionMode_Click);
            // 
            // mnuToolsTiming
            // 
            this.mnuToolsTiming.Name = "mnuToolsTiming";
            this.mnuToolsTiming.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.mnuToolsTiming.Size = new System.Drawing.Size(230, 22);
            this.mnuToolsTiming.Text = "Setup T&iming";
            this.mnuToolsTiming.ToolTipText = "Select continuous or timed sampling";
            this.mnuToolsTiming.Click += new System.EventHandler(this.mnuToolsTiming_Click);
            // 
            // mnuToolsReconnect
            // 
            this.mnuToolsReconnect.Name = "mnuToolsReconnect";
            this.mnuToolsReconnect.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuToolsReconnect.Size = new System.Drawing.Size(230, 22);
            this.mnuToolsReconnect.Text = "&Reconnect Controllers";
            this.mnuToolsReconnect.ToolTipText = "Close all windows and reconnect controllers";
            this.mnuToolsReconnect.Click += new System.EventHandler(this.mnuToolsReconnect_Click);
            // 
            // mnuToolsTableData
            // 
            this.mnuToolsTableData.Name = "mnuToolsTableData";
            this.mnuToolsTableData.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.mnuToolsTableData.Size = new System.Drawing.Size(230, 22);
            this.mnuToolsTableData.Text = "Table of Data";
            this.mnuToolsTableData.Visible = false;
            this.mnuToolsTableData.Click += new System.EventHandler(this.mnuToolsTableData_Click);
            // 
            // mnuWindow
            // 
            this.mnuWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWindowCascade,
            this.mnuWindowTileVertical,
            this.mnuWindowTileHorizontal});
            this.mnuWindow.Name = "mnuWindow";
            this.mnuWindow.Size = new System.Drawing.Size(57, 20);
            this.mnuWindow.Text = "&Window";
            // 
            // mnuWindowCascade
            // 
            this.mnuWindowCascade.Name = "mnuWindowCascade";
            this.mnuWindowCascade.Size = new System.Drawing.Size(152, 22);
            this.mnuWindowCascade.Text = "&Cascade";
            this.mnuWindowCascade.Click += new System.EventHandler(this.mnuWindowCascade_Click);
            // 
            // mnuWindowTileVertical
            // 
            this.mnuWindowTileVertical.Name = "mnuWindowTileVertical";
            this.mnuWindowTileVertical.Size = new System.Drawing.Size(152, 22);
            this.mnuWindowTileVertical.Text = "Tile &Vertical";
            this.mnuWindowTileVertical.Click += new System.EventHandler(this.mnuWindowTileVertical_Click);
            // 
            // mnuWindowTileHorizontal
            // 
            this.mnuWindowTileHorizontal.Name = "mnuWindowTileHorizontal";
            this.mnuWindowTileHorizontal.Size = new System.Drawing.Size(152, 22);
            this.mnuWindowTileHorizontal.Text = "Tile &Horizontal";
            this.mnuWindowTileHorizontal.Click += new System.EventHandler(this.mnuWindowTileHorizontal_Click);
            // 
            // mnuLogging
            // 
            this.mnuLogging.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLoggingStart,
            this.mnuLoggingStop});
            this.mnuLogging.Name = "mnuLogging";
            this.mnuLogging.Size = new System.Drawing.Size(56, 20);
            this.mnuLogging.Text = "&Logging";
            // 
            // mnuLoggingStart
            // 
            this.mnuLoggingStart.Name = "mnuLoggingStart";
            this.mnuLoggingStart.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
            this.mnuLoggingStart.Size = new System.Drawing.Size(153, 22);
            this.mnuLoggingStart.Text = "St&art";
            this.mnuLoggingStart.ToolTipText = "Start data collection";
            this.mnuLoggingStart.Click += new System.EventHandler(this.mnuLoggingStart_Click);
            // 
            // mnuLoggingStop
            // 
            this.mnuLoggingStop.Enabled = false;
            this.mnuLoggingStop.Name = "mnuLoggingStop";
            this.mnuLoggingStop.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F6)));
            this.mnuLoggingStop.Size = new System.Drawing.Size(153, 22);
            this.mnuLoggingStop.Text = "St&op";
            this.mnuLoggingStop.ToolTipText = "Stop data collection";
            this.mnuLoggingStop.Click += new System.EventHandler(this.mnuLoggingStop_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpContents,
            this.mnuHelpIndex,
            this.mnuHelpSearch,
            this.toolStripSeparator5,
            this.mnuHelpUpdates,
            this.mnuHelpAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(40, 20);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuHelpContents
            // 
            this.mnuHelpContents.Name = "mnuHelpContents";
            this.mnuHelpContents.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mnuHelpContents.Size = new System.Drawing.Size(174, 22);
            this.mnuHelpContents.Text = "&Contents";
            this.mnuHelpContents.Click += new System.EventHandler(this.mnuHelpContents_Click);
            // 
            // mnuHelpIndex
            // 
            this.mnuHelpIndex.Name = "mnuHelpIndex";
            this.mnuHelpIndex.Size = new System.Drawing.Size(174, 22);
            this.mnuHelpIndex.Text = "&Index";
            this.mnuHelpIndex.Click += new System.EventHandler(this.mnuHelpIndex_Click);
            // 
            // mnuHelpSearch
            // 
            this.mnuHelpSearch.Name = "mnuHelpSearch";
            this.mnuHelpSearch.Size = new System.Drawing.Size(174, 22);
            this.mnuHelpSearch.Text = "&Search";
            this.mnuHelpSearch.Click += new System.EventHandler(this.mnuHelpSearch_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(171, 6);
            this.toolStripSeparator5.Visible = false;
            // 
            // mnuHelpUpdates
            // 
            this.mnuHelpUpdates.Name = "mnuHelpUpdates";
            this.mnuHelpUpdates.Size = new System.Drawing.Size(174, 22);
            this.mnuHelpUpdates.Text = "Check for &Updates";
            this.mnuHelpUpdates.Click += new System.EventHandler(this.mnuHelpUpdates_Click);
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.Size = new System.Drawing.Size(174, 22);
            this.mnuHelpAbout.Text = "&About...";
            this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 458);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(813, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatusLabel1.Text = "Stopped";
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "./docs/help/WiiMotePhysics.chm";
            // 
            // frmMDIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 480);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMDIMain";
            this.Text = "WiiMote Physics v4";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMDIMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMDIMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileCloseChild;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuFileNew;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.ToolStripSeparator mnuFileSep1;
        private System.Windows.Forms.ToolStripSeparator mnuFileSep2;
        private System.Windows.Forms.ToolStripSeparator mnuFileSep3;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpContents;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpIndex;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpSearch;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpUpdates;
        private System.Windows.Forms.ToolStripMenuItem mnuLogging;
        private System.Windows.Forms.ToolStripMenuItem mnuLoggingStart;
        private System.Windows.Forms.ToolStripMenuItem mnuLoggingStop;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsCollectionMode;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsReconnect;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsTiming;
        private System.Windows.Forms.ToolStripMenuItem mnuWindow;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowCascade;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowTileHorizontal;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowTileVertical;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsTableData;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpenInsight;
    }
}