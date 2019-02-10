using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WiiPhysics
{
    public partial class frmSetup : Form
    {
        #region Form Variables
        // Maximum number of channels for display (set in clsGlobal)
        private static int _maxChannel = clsGlobal.maxChannel;

        // Boolean array listing which graphs to plot
        private bool[] _graphsToShow = new bool[_maxChannel - 1];

        // Boolean variable to distinguish between Wiimote and Balanceboard
        private bool _isWiiMote;

        // String containing the type of scan
        private string _scanMode;
        #endregion

        #region Constructor
        public frmSetup()
        {
            this.InitializeComponent();
        }
        #endregion

        #region Form Events
        private void frmSetup_Load(object sender, EventArgs e)
        {
            /*
            foreach (Control control in this.gbDisplay.Controls)
            {
                CheckBox chkBox = control as CheckBox;
                if (chkBox != null)
                {
                    MessageBox.Show(chkBox.Name.ToString());
                }
            }
            */

            // loop through buttons and enable/disable according to whether WiiMote or BalanceBoard
            foreach (RadioButton button in this.gbScanMode.Controls)
            {
                // WiiMote Detected
                if (this._isWiiMote && button.Name == "rbBalanceBoard")
                {
                    button.Enabled = false;
                }
                // BalanceBoard Detected
                else if (!this._isWiiMote && button.Name != "rbBalanceBoard")
                {
                    button.Enabled = false;
                    this.tbBarLength.Visible = false;
                    this.lbBarLength.Visible = false;
                }
                // Set up the graph display according to the type of scan
                if (button.Checked)
                {
                    this.setUpCheckBoxes(button);
                }
            }
        }

        private void frmSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Write out Barlength to the registry
            string subkey = @"Software\MDWSoftware\WiiPhysics\Parameters";
            Registry.CurrentUser.CreateSubKey(subkey).SetValue("BarLength", double.Parse(this.tbBarLength.Text));
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            // Change chackboxes in response to user selecting a new scan mode
            for (int i = 0; i < this.gbDisplay.Controls.Count; i++)
            {
                CheckBox box = (CheckBox)this.gbDisplay.Controls[i];
                box.Checked = true;
            }
            foreach (RadioButton button in this.gbScanMode.Controls)
            {
                if (button.Checked)
                {
                    this.setUpCheckBoxes(button);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        #endregion

        #region Private Methods
        private void setUpCheckBoxes(RadioButton rb)
        {
            // Method to set up checkboxes according to the type of scanmode
            switch (rb.Name)
            {
                case "rbAccelerometer":
                    this.cbDisplay1.Visible = true;
                    this.cbDisplay1.Text = "x-Acceleration";
                    this.cbDisplay2.Visible = true;
                    this.cbDisplay2.Text = "y-Acceleration";
                    this.cbDisplay3.Visible = true;
                    this.cbDisplay3.Text = "z-Acceleration";
                    this.cbDisplay4.Visible = true;
                    this.cbDisplay4.Checked = false;
                    this.cbDisplay4.Text = "Total Acceleration";
                    this.cbDisplay5.Visible = false;
                    this.cbDisplay5.Checked = false;
                    return;

                case "rbMotionSensor":
                    this.cbDisplay1.Visible = true;
                    this.cbDisplay1.Text = "Distance";
                    this.cbDisplay2.Visible = false;
                    this.cbDisplay2.Checked = false;
                    this.cbDisplay3.Visible = false;
                    this.cbDisplay3.Checked = false;
                    this.cbDisplay4.Visible = false;
                    this.cbDisplay4.Checked = false;
                    this.cbDisplay5.Visible = false;
                    this.cbDisplay5.Checked = false;
                    return;

                case "rbPositionSensor":
                    this.cbDisplay1.Visible = true;
                    this.cbDisplay1.Checked = false;
                    this.cbDisplay1.Text = "x1-Position";
                    this.cbDisplay2.Visible = true;
                    this.cbDisplay2.Text = "y1-Position";
                    this.cbDisplay3.Visible = true;
                    this.cbDisplay3.Checked = false;
                    this.cbDisplay3.Text = "x2-Position";
                    this.cbDisplay4.Visible = true;
                    this.cbDisplay4.Checked = false;
                    this.cbDisplay4.Text = "y2-Position";
                    this.cbDisplay5.Visible = false;
                    this.cbDisplay5.Checked = false;
                    return;

                case "rbOneDMotion":
                    this.cbDisplay1.Visible = true;
                    this.cbDisplay1.Text = "Distance";
                    this.cbDisplay2.Visible = true;
                    this.cbDisplay2.Text = "y-Acceleration";
                    this.cbDisplay3.Visible = true;
                    this.cbDisplay3.Checked = false;
                    this.cbDisplay3.Text = "Velocity";
                    this.cbDisplay4.Visible = false;
                    this.cbDisplay4.Checked = false;
                    this.cbDisplay5.Visible = false;
                    this.cbDisplay5.Checked = false;
                    return;

                case "rbCircularMotion":
                    this.cbDisplay1.Visible = true;
                    this.cbDisplay1.Checked = false;
                    this.cbDisplay1.Text = "x-Trigger";
                    this.cbDisplay2.Visible = true;
                    this.cbDisplay2.Text = "y-Trigger";
                    this.cbDisplay3.Visible = true;
                    this.cbDisplay3.Text = "y-Acceleration";
                    this.cbDisplay4.Visible = false;
                    this.cbDisplay4.Checked = false;
                    this.cbDisplay5.Visible = false;
                    this.cbDisplay5.Checked = false;
                    return;

                case "rbBalanceBoard":
                    this.cbDisplay1.Visible = true;
                    this.cbDisplay1.Text = "Total Force";
                    this.cbDisplay2.Visible = true;
                    this.cbDisplay2.Text = "Top Left";
                    this.cbDisplay3.Visible = true;
                    this.cbDisplay3.Text = "Top Right";
                    this.cbDisplay4.Visible = true;
                    this.cbDisplay4.Text = "Bottom Left";
                    this.cbDisplay5.Visible = true;
                    this.cbDisplay5.Text = "Bottom Right";
                    return;
            }
        }
        #endregion

        #region Public Accessor Methods
        // These methods transfer data to and from the Main Form
        public double barLength
        {
            get
            {
                return double.Parse(this.tbBarLength.Text);
            }
            set
            {
                this.tbBarLength.Text = value.ToString();
            }
        }

        public bool[] graphsToShow
        {
            get
            {
                for (int i = 0; i < this.gbDisplay.Controls.Count; i++)
                {
                    CheckBox box = (CheckBox) this.gbDisplay.Controls[i];
                    this._graphsToShow[i] = box.Checked;
                }
                return this._graphsToShow;
            }
            set
            {
                this._graphsToShow = value;
                for (int i = 0; i < this.gbDisplay.Controls.Count; i++)
                {
                    CheckBox box = (CheckBox) this.gbDisplay.Controls[i];
                    box.Checked = this._graphsToShow[i];
                }
            }
        }

        public bool isWiiMote
        {
            set
            {
                this._isWiiMote = value;
            }
        }

        public string scanMode
        {
            get
            {
                foreach (RadioButton button in this.gbScanMode.Controls)
                {
                    if (button.Checked)
                    {
                        this._scanMode = button.Name;
                    }
                }
                return this._scanMode;
            }
            set
            {
                this._scanMode = value;
                foreach (RadioButton button in this.gbScanMode.Controls)
                {
                    if (button.Name == this._scanMode)
                    {
                        button.Checked = true;
                    }
                }
            }
        }
        #endregion
    }
}

