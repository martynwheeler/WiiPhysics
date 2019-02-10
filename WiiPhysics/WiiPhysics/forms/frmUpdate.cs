using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WiiPhysics
{
    public partial class frmUpdate : Form
    {
        #region Form Variables
        // Boolean to determine whether an update has been found
        bool updateFound;
        #endregion

        #region Constructor
        public frmUpdate()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Form Events
        private void frmUpdate_Load(object sender, EventArgs e)
        {
            // On Form Load trigger the check for update event to run
            btnOKCancel.Text = "Cancel";
            lbInformation.Text = "Please wait...";
            backgroundWorker1.RunWorkerAsync();
        }

        private void btnOKCancel_Click(object sender, EventArgs e)
        {
            switch (btnOKCancel.Text)
            {
                case "Cancel":
                    {
                        lbInformation.Text = "Cancelling Request...";
                        DialogResult = DialogResult.Cancel;
                    }
                    break;
                case "OK":
                    {
                        if (updateFound) DialogResult = DialogResult.OK;
                        else DialogResult = DialogResult.Cancel;
                    }
                    break;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            updateFound = clsGlobal.g_objfrmMDIMain.checkForUpdates();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnOKCancel.Text = "OK";
            if (updateFound)
            {
                lbInformation.Text = "New update found.";
            }
            else
            {
                lbInformation.Text = "You are already up to date.";
            }
        }
        #endregion
    }
}
