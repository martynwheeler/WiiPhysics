using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
using Microsoft.Win32;
using WiimoteLib;

namespace WiiPhysics
{
    public partial class frmMDIMain : Form
    {
        #region Form Variables
        // Wiimote collection
        private WiimoteCollection mWC;

        // Dictionary to hold device ID
        private Dictionary<Guid, frmDataWindow> mWiimoteMap;

        // Form closing reason
        private bool updateClosing;

        // Unsaved Data
        private bool dataToSave;
        private bool dataToDisplay;

        #endregion

        #region Constructor
        public frmMDIMain()
        {
            this.InitializeComponent();
            this.mWiimoteMap = new Dictionary<Guid, frmDataWindow>();
            this.mWC = new WiimoteCollection();
            this.updateClosing = false;
            this.dataToSave = false;
            this.dataToDisplay = false;
            this.showSplash(true);
        }
        #endregion

        #region Form Events
        private void frmMDIMain_Load(object sender, EventArgs e)
        {
            // Setup form's title
            int length = -1;
            for (int i = 0; i < 2; i++)
            {
                length = clsGlobal.AssemblyVersion.IndexOf(".", (int) (length + 1));
            }
            this.Text = clsGlobal.AssemblyTitle + string.Format(" v{0}", clsGlobal.AssemblyVersion.Substring(0, length));
            this.readRegistryValues();
            // Check if Wiimotes connected
            if (this.mWC.Count > 0)
            {
                this.openWiiMoteWindows();
            }
            else
            {
                this.mnuToolsCollectionMode.Enabled = false;
                this.mnuToolsTiming.Enabled = false;
                this.mnuLogging.Enabled = false;
            }
            // Check whether iLOG is installed on Machine
            string subkey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{8364FF02-6B7C-4EBC-8353-9DC3D6816A84}";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(subkey);
            if (key == null)
            {
                mnuFileOpenInsight.Enabled = false;
            }
        }

        private void frmMDIMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            string infoMessage, infoCaption;
            if (updateClosing)
            {
                infoCaption = "New version detected";
                infoMessage = "Quit WiiMote Physics and install the new version?";
            }
            else
            {
                if (this.dataToSave)
                {
                    infoCaption = "Warning";
                    infoMessage = "Unsaved Data, Really Quit WiiMote Physics?";
                }
                else
                {
                    infoCaption = "Exit";
                    infoMessage = "Really Quit WiiMote Physics?";
                }
            }

            if (MessageBox.Show(infoMessage, infoCaption, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (updateClosing)
                {
                    // navigate the default web browser to our app homepage (the url comes from the xml content)
                    Process.Start(clsGlobal.url.Remove(clsGlobal.url.Length - 1));
                }
                // Disconnect ALL wiimotes
                foreach (Wiimote wiimote in this.mWC)
                {
                    wiimote.Disconnect();
                }
                this.writeRegistryValues();
            }
            else
            {
                updateClosing = false;
                e.Cancel = true;
            }
        }
        #endregion

        #region Menu Events
        private void mnuFileCloseWindow_Click(object sender, EventArgs e)
        {
            if (base.MdiChildren.Length == 1)
            {
                this.stopLogging();
            }
            if (base.MdiChildren.Length > 0)
            {
                try
                {
                    ((frmDataWindow) base.ActiveMdiChild).Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (this.dataToSave)
            {
                string subkey = @"Software\MDWSoftware\WiiPhysics\Directory";
                RegistryKey key = Registry.CurrentUser.CreateSubKey(subkey);
                if (key.GetValue("LastFolder") != null)
                {
                    this.saveFileDialog1.InitialDirectory = key.GetValue("LastFolder").ToString();
                }
                else
                {
                    this.saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                }
                this.saveFileDialog1.Title = "Save Data";
                this.saveFileDialog1.FileName = "WiiData_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".csv";
                this.saveFileDialog1.Filter = "CSV Files|*.csv|All Files|*.*";
                if (this.saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    try
                    {
                        writeDataToFile(this.saveFileDialog1.FileName);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Error Writing to File", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    finally
                    {
                        FileInfo info = new FileInfo(this.saveFileDialog1.FileName);
                        key.SetValue("LastFolder", info.DirectoryName);
                        this.dataToSave = false;
                    }
                }
            }
        }

        private void mnuFileOpenInsight_Click(object sender, EventArgs e)
        {
            if (this.dataToDisplay)
            {
                if (IsProcessOpen("iLOG"))
                {
                    MessageBox.Show("iLOG is already running. Please close the current instance before displaying data.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    string subkey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{8364FF02-6B7C-4EBC-8353-9DC3D6816A84}";
                    RegistryKey key = Registry.LocalMachine.OpenSubKey(subkey);
                    string pathToInsight = key.GetValue("InstallLocation") + "iLOG.exe";
                    string tmpFile = Environment.GetEnvironmentVariable("TEMP") + @"\WiiData.tmp";
                    try
                    {
                        Process.Start(pathToInsight, tmpFile);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Error Opening iLOG Studio", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
        }

        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            using (frmAbout objfrmAbout = new frmAbout())
            {
                objfrmAbout.ShowDialog();
            }
        }

        private void mnuHelpContents_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, this.helpProvider1.HelpNamespace);
        }

        private void mnuHelpIndex_Click(object sender, EventArgs e)
        {
            Help.ShowHelpIndex(this, this.helpProvider1.HelpNamespace);
        }

        private void mnuHelpSearch_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, this.helpProvider1.HelpNamespace, HelpNavigator.Find, "");
        }

        private void mnuHelpUpdates_Click(object sender, EventArgs e)
        {
            string subkey = @"Software\MDWSoftware\WiiPhysics\Update";
            Registry.CurrentUser.CreateSubKey(subkey).SetValue("LastCheck", DateTime.Today);
            using (frmUpdate objfrmUpdate = new frmUpdate())
            {
                if (objfrmUpdate.ShowDialog() == DialogResult.OK)
                {
                    updateClosing = true;
                    Application.Exit();
                }
            }
        }

        private void mnuLoggingStart_Click(object sender, EventArgs e)
        {
            this.startLogging();
        }

        private void mnuLoggingStop_Click(object sender, EventArgs e)
        {
            this.stopLogging();
        }

        private void mnuToolsCollectionMode_Click(object sender, EventArgs e)
        {
            foreach (frmDataWindow objfrmDataWindow in base.MdiChildren)
            {
                if (objfrmDataWindow == base.ActiveMdiChild)
                {
                    using (frmSetup objfrmSetup = new frmSetup())
                    {
                        objfrmSetup.scanMode = objfrmDataWindow.scanMode;
                        objfrmSetup.barLength = objfrmDataWindow.barLength;
                        if (objfrmDataWindow.Wiimote.WiimoteState.ExtensionType == ExtensionType.None)
                        {
                            objfrmSetup.isWiiMote = true;
                        }
                        objfrmSetup.graphsToShow = objfrmDataWindow.graphsToShow;
                        if (objfrmSetup.ShowDialog() == DialogResult.OK)
                        {
                            objfrmDataWindow.scanMode = objfrmSetup.scanMode;
                            objfrmDataWindow.barLength = objfrmSetup.barLength;
                            objfrmDataWindow.graphsToShow = objfrmSetup.graphsToShow;
                        }
                    }
                }
            }
        }

        private void mnuToolsReconnect_Click(object sender, EventArgs e)
        {
            if (base.MdiChildren.Length > 0)
            {
                try
                {
                    foreach (frmDataWindow objfrmDataWindow in base.MdiChildren)
                    {
                        objfrmDataWindow.Close();
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            this.mWiimoteMap.Clear();
            this.mWC.Clear();
            this.showSplash(false);
            if (this.mWC.Count > 0)
            {
                this.openWiiMoteWindows();
                this.mnuToolsCollectionMode.Enabled = true;
                this.mnuToolsTiming.Enabled = true;
                this.mnuLogging.Enabled = true;
            }
            else
            {
                this.mnuToolsCollectionMode.Enabled = false;
                this.mnuToolsTiming.Enabled = false;
                this.mnuLogging.Enabled = false;
            }
        }

        private void mnuToolsTiming_Click(object sender, EventArgs e)
        {
            using (frmTiming objfrmTiming = new frmTiming())
            {
                frmDataWindow activeMdiChild = (frmDataWindow) base.ActiveMdiChild;
                objfrmTiming.endTime = activeMdiChild.endTime;
                if (objfrmTiming.ShowDialog() == DialogResult.OK)
                {
                    foreach (frmDataWindow objfrmDataWindow in base.MdiChildren)
                    {
                        objfrmDataWindow.endTime = objfrmTiming.endTime;
                    }
                }
            }
        }

        private void mnuToolsTableData_Click(object sender, EventArgs e)
        {
            /* 
             * Need to check only one wiimote open and the table is connected to the data from that controller
             */
            frmDataTab objfrmDataTab = new frmDataTab()
            {
                MdiParent = this,
                Text = "DataTable"
            };
            objfrmDataTab.Show();
        }

        private void mnuWindowCascade_Click(object sender, EventArgs e)
        {
            base.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuWindowTileHorizontal_Click(object sender, EventArgs e)
        {
            base.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuWindowTileVertical_Click(object sender, EventArgs e)
        {
            base.LayoutMdi(MdiLayout.TileVertical);
        }
        #endregion

        #region Private Methods
        private void readRegistryValues()
        {
            string subkey = @"Software\MDWSoftware\WiiPhysics\Update";
            RegistryKey key = Registry.CurrentUser.CreateSubKey(subkey);
            if (key.GetValue("LastCheck") != null)
            {
                TimeSpan span = (TimeSpan) (DateTime.Today - Convert.ToDateTime(key.GetValue("LastCheck")));
                if (span.Days > 30)
                {
                    Registry.CurrentUser.CreateSubKey(subkey).SetValue("LastCheck", DateTime.Today);
                    if (checkForUpdates())
                    {
                        updateClosing = true;
                        Application.Exit();
                    }
                }
            }
            subkey = @"Software\MDWSoftware\WiiPhysics\Window";
            key = Registry.CurrentUser.CreateSubKey(subkey);
            string keyVal = (string) key.GetValue("WindowState");
            if (keyVal != null)
            {
                if (keyVal.CompareTo("Maximized") == 0)
                {
                    base.WindowState = FormWindowState.Maximized;
                }
                else if (keyVal.CompareTo("Minimized") == 0)
                {
                    base.WindowState = FormWindowState.Minimized;
                }
                else
                {
                    base.WindowState = FormWindowState.Normal;
                }
            }
            if (base.WindowState == FormWindowState.Normal)
            {
                if ((key.GetValue("X") != null) && (key.GetValue("Y") != null))
                {
                    base.Location = new System.Drawing.Point((int) key.GetValue("X"), (int) key.GetValue("Y"));
                }
                if ((key.GetValue("Width") != null) && (key.GetValue("Height") != null))
                {
                    base.Size = new Size((int) key.GetValue("Width"), (int) key.GetValue("Height"));
                }
            }
        }

        private void writeRegistryValues()
        {
            string subkey = @"Software\MDWSoftware\WiiPhysics\Window";
            RegistryKey key = Registry.CurrentUser.CreateSubKey(subkey);
            string keyVal = "";
            if (base.WindowState == FormWindowState.Maximized)
            {
                keyVal = "Maximized";
            }
            else if (base.WindowState == FormWindowState.Maximized)
            {
                keyVal = "Minimized";
            }
            else
            {
                keyVal = "Normal";
            }
            key.SetValue("WindowState", keyVal);
            if (base.WindowState == FormWindowState.Normal)
            {
                key.SetValue("X", base.Location.X);
                key.SetValue("Y", base.Location.Y);
                key.SetValue("Width", base.Size.Width);
                key.SetValue("Height", base.Size.Height);
            }
        }

        private void showSplash(bool isStartup)
        {
            frmSplash splash = new frmSplash(this.mWC, isStartup);
            splash.ShowDialog();
            splash.Dispose();
        }

        private void openWiiMoteWindows()
        {
            int count = 1;
            foreach (Wiimote wiimote in this.mWC)
            {
                frmDataWindow objfrmDataWindow = new frmDataWindow(wiimote)
                {
                    MdiParent = this,
                    Text = "Wiimote " + count.ToString()
                };
                this.mWiimoteMap[wiimote.ID] = objfrmDataWindow;
                wiimote.WiimoteChanged += new EventHandler<WiimoteChangedEventArgs>(this.wm_WiimoteChanged);
                wiimote.WiimoteExtensionChanged += new EventHandler<WiimoteExtensionChangedEventArgs>(this.wm_WiimoteExtensionChanged);
                wiimote.SetLEDs(count++);
                string subkey = @"Software\MDWSoftware\WiiPhysics\Parameters";
                RegistryKey key = Registry.CurrentUser.CreateSubKey(subkey);
                if (key.GetValue("BarLength") != null)
                {
                    objfrmDataWindow.barLength = Convert.ToDouble(key.GetValue("BarLength"));
                }
                else
                {
                    objfrmDataWindow.barLength = 0.2;
                }
                if ((key.GetValue("EndTime") != null) && (key.GetValue("ContinuousScan") != null))
                {
                    if (Convert.ToBoolean(key.GetValue("ContinuousScan")))
                    {
                        objfrmDataWindow.endTime = double.PositiveInfinity;
                    }
                    else
                    {
                        objfrmDataWindow.endTime = Convert.ToDouble(key.GetValue("EndTime"));
                    }
                }
                else
                {
                    objfrmDataWindow.endTime = double.PositiveInfinity;
                }
                if (wiimote.WiimoteState.ExtensionType != ExtensionType.BalanceBoard)
                {
                    wiimote.SetReportType(InputReport.IRExtensionAccel, IRSensitivity.Maximum, true);
                    objfrmDataWindow.scanMode = "rbAccelerometer";
                    objfrmDataWindow.graphsToShow[0] = true;
                    objfrmDataWindow.graphsToShow[1] = true;
                    objfrmDataWindow.graphsToShow[2] = true;
                    objfrmDataWindow.graphsToShow[3] = false;
                }
                else
                {
                    wiimote.SetLEDs(true, false, false, false);
                    objfrmDataWindow.scanMode = "rbBalanceBoard";
                    objfrmDataWindow.graphsToShow[0] = true;
                    objfrmDataWindow.graphsToShow[1] = true;
                    objfrmDataWindow.graphsToShow[2] = true;
                    objfrmDataWindow.graphsToShow[3] = true;
                    objfrmDataWindow.graphsToShow[4] = true;
                }
                objfrmDataWindow.Show();
                try
                {
                    switch (base.MdiChildren.Length)
                    {
                        case 0:
                            {
                                continue;
                            }
                        case 1:
                            {
                                base.ActiveMdiChild.WindowState = FormWindowState.Maximized;
                                continue;
                            }
                    }
                    base.LayoutMdi(MdiLayout.TileHorizontal);
                    continue;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Unknown error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    continue;
                }
            }
        }

        private void writeDataToFile(string fileName)
        {
            int numberOfChannels = clsGlobal.maxChannel;
            StreamWriter writer = new StreamWriter(fileName);
            foreach (frmDataWindow objfrmDataWindow in base.MdiChildren)
            {
                // Add different headers corresponding to different datasets
                switch (objfrmDataWindow.scanMode)
                {
                    case "rbAccelerometer":
                        writer.WriteLine("Time, x-Acceleration, y-Acceleration, z-Acceleration, Acceleration," + objfrmDataWindow.Text);
                        numberOfChannels = 5;
                        break;

                    case "rbMotionSensor":
                        writer.WriteLine("Time, Displacement," + objfrmDataWindow.Text);
                        numberOfChannels = 2;
                        break;

                    case "rbPositionSensor":
                        writer.WriteLine("Time, x1-Position, y1-Position, x2-Position, y2-Position," + objfrmDataWindow.Text);
                        numberOfChannels = 5;
                        break;

                    case "rbOneDMotion":
                        writer.WriteLine("Time, Displacement, Acceleration, Velocity," + objfrmDataWindow.Text);
                        numberOfChannels = 4;
                        break;

                    case "rbCircularMotion":
                        writer.WriteLine("Time, x-Trigger, y-Trigger, Acceleration," + objfrmDataWindow.Text);
                        numberOfChannels = 4;
                        break;

                    case "rbBalanceBoard":
                        writer.WriteLine("Time, Force, Force(TL), Force(TR), Force(BL), Force(BR)," + objfrmDataWindow.Text);
                        numberOfChannels = 6;
                        break;
                }
                for (int i = 0; i < objfrmDataWindow.numDataPoints; i++)
                {
                    string lineofText = "";
                    for (int j = 0; j < numberOfChannels; j++)
                    {
                        if (j == 0)
                        {
                            lineofText += string.Format("{0:0.0000000}, ", objfrmDataWindow.dataToSave[j, i]);
                        }
                        else
                        {
                            lineofText += string.Format("{0:0.00000000}, ", objfrmDataWindow.dataToSave[j, i]);
                        }
                    }
                    lineofText = lineofText.Remove(lineofText.Length - 2);
                    writer.WriteLine(lineofText);
                }
            }
            writer.Close();
        }

        private bool IsProcessOpen(string name)
        {
            //here we're going to get a list of all running processes on
            //the computer
            foreach (Process clsProcess in Process.GetProcesses())
            {
                //now we're going to see if any of the running processes
                //match the currently running processes. Be sure to not
                //add the .exe to the name you provide, i.e: NOTEPAD,
                //not NOTEPAD.EXE or false is always returned even if
                //notepad is running.
                //Remember, if you have the process running more than once, 
                //say IE open 4 times the loop thr way it is now will close all 4,
                //if you want it to just close the first one it finds
                //then add a return; after the Kill
                if (clsProcess.ProcessName.Contains(name))
                {
                    //if the process is found to be running then we
                    //return a true
                    return true;
                }
            }
            //otherwise we return a false
            return false;
        }
        #endregion

        #region Public Events
        public void startLogging()
        {
            if (base.MdiChildren.Length > 0)
            {
                this.dataToSave = true;
                this.dataToDisplay = true;
                this.mnuTools.Enabled = false;
                this.mnuHelp.Enabled = false;
                this.mnuFileSave.Enabled = false;
                this.mnuFileOpenInsight.Enabled = false;
                if (this.mnuLoggingStart.Text == "St&art")
                {
                    this.toolStripStatusLabel1.Text = "Acquiring Data";
                    this.mnuLoggingStart.Text = "Pa&use";
                }
                else
                {
                    this.toolStripStatusLabel1.Text = "Paused";
                    this.mnuLoggingStart.Text = "St&art";
                }
                this.mnuLoggingStop.Enabled = true;
                foreach (frmDataWindow objfrmDataWindow in base.MdiChildren)
                {
                    objfrmDataWindow.startTimer();
                }
            }
        }

        public void stopLogging()
        {
            this.toolStripStatusLabel1.Text = "Stopped";
            this.mnuTools.Enabled = true;
            this.mnuHelp.Enabled = true;
            this.mnuFileSave.Enabled = true;
            this.mnuFileOpenInsight.Enabled = true;
            this.mnuLoggingStart.Text = "St&art";
            this.mnuLoggingStop.Enabled = false;
            foreach (frmDataWindow objfrmDataWindow in base.MdiChildren)
            {
                objfrmDataWindow.stopTimer();
            }
            string tmpFile = Environment.GetEnvironmentVariable("TEMP") + @"\WiiData.tmp";
            writeDataToFile(tmpFile);
        }

        public bool checkForUpdates()
        {
            // in newVersion variable we will store the version info from xml file
            Version newVersion = null;
            // and in this variable we will put the url we would like to open so that the user can download the new version
            // it can be a homepage or a direct link to zip/exe file
            XmlTextReader reader = null;
            try
            {
                // provide the XmlTextReader with the URL of our xml document
                string xmlURL = "http://wiiphysics.site88.net/downloads/wiiphysics_version.xml";
                reader = new XmlTextReader(xmlURL);
                // simply (and easily) skip the junk at the beginning
                reader.MoveToContent();
                // internal - as the XmlTextReader moves only forward, we save current xml element name in elementName variable. 
                // When we parse a text node, we refer to elementName to check what was the node name
                string elementName = "";
                // we check if the xml starts with a proper "wiiphysics" element node
                if ((reader.NodeType == XmlNodeType.Element) &&
                    (reader.Name == "wiiphysics"))
                {
                    while (reader.Read())
                    {
                        // when we find an element node, we remember its name
                        if (reader.NodeType == XmlNodeType.Element)
                            elementName = reader.Name;
                        else
                        {
                            // for text nodes...
                            if ((reader.NodeType == XmlNodeType.Text) &&
                                (reader.HasValue))
                            {
                                // we check what the name of the node was
                                switch (elementName)
                                {
                                    case "version":
                                        // thats why we keep the version info in xxx.xxx.xxx.xxx format the Version class 
                                        // does the parsing for us
                                        newVersion = new Version(reader.Value);
                                        break;
                                    case "url":
                                        clsGlobal.url = reader.Value;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                if (reader != null) reader.Close();
            }
            // get the running version
            Version curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            // compare the versions
            if (curVersion.CompareTo(newVersion) < 0) return true;
            else return false;
        }

        public void wm_WiimoteChanged(object sender, WiimoteChangedEventArgs e)
        {
            this.mWiimoteMap[((Wiimote)sender).ID].UpdateState(e);
        }

        public void wm_WiimoteExtensionChanged(object sender, WiimoteExtensionChangedEventArgs e)
        {
            this.mWiimoteMap[((Wiimote) sender).ID].UpdateExtension(e);
            if (e.Inserted)
            {
                ((Wiimote) sender).SetReportType(InputReport.IRExtensionAccel, true);
            }
            else
            {
                ((Wiimote) sender).SetReportType(InputReport.IRAccel, true);
            }
        }
        #endregion
    }
}

