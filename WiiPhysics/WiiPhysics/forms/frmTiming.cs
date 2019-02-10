using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WiiPhysics
{
    public partial class frmTiming : Form
    {
        #region Constructor
        public frmTiming()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Form Events
        private void frmTiming_Load(object sender, EventArgs e)
        {
            // read values from registry to setup
            this.lbInformation.Text = "Select time over which to take data or \r\nrun continuous sampling.";
            string subkey = @"Software\MDWSoftware\WiiPhysics\Parameters";
            RegistryKey key = Registry.CurrentUser.CreateSubKey(subkey);
            if (key.GetValue("EndTime") != null)
            {
                this.tbEndTime.Text = key.GetValue("EndTime").ToString();
            }
            else
            {
                this.tbEndTime.Text = "30";
            }
        }

        private void frmTiming_FormClosing(object sender, FormClosingEventArgs e)
        {
            // write new values to registry
            string subkey = @"Software\MDWSoftware\WiiPhysics\Parameters";
            RegistryKey key = Registry.CurrentUser.CreateSubKey(subkey);
            key.SetValue("EndTime", double.Parse(this.tbEndTime.Text));
            key.SetValue("ContinuousScan", this.cbContinuous.Checked);
        }

        private void cbContinuous_CheckedChanged(object sender, EventArgs e)
        {
            // respond to change in check box
            if (this.cbContinuous.Checked)
            {
                this.tbEndTime.Enabled = false;
            }
            else
            {
                this.tbEndTime.Enabled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region Public Accessor Methods
        // These methods transfer data to and from the Main Form
        public double endTime
        {
            get
            {
                if (this.cbContinuous.Checked)
                {
                    return double.PositiveInfinity;
                }
                return double.Parse(this.tbEndTime.Text);
            }
            set
            {
                if (value == double.PositiveInfinity)
                {
                    this.cbContinuous.Checked = true;
                    this.tbEndTime.Enabled = false;
                }
                else
                {
                    this.cbContinuous.Checked = false;
                    this.tbEndTime.Text = value.ToString();
                }
            }
        }
        #endregion
    }
}

