using System;
using System.Windows.Forms;
using WiimoteLib;

namespace WiiPhysics
{
    public partial class frmSplash : Form
    {
        #region Form Variables
        // boolean to test whether this is the first time the form is loaded
        private bool _isStartUp;

        // Wiimote collection
        private WiimoteCollection _mWC;
        #endregion

        #region Constructor
        public frmSplash(WiimoteCollection mWC, bool isStartup)
        {
            this.InitializeComponent();
            this._mWC = mWC;
            this.findAllWiiMotes();
            this.tsProgbar.Maximum = this._mWC.Count;
            this._isStartUp = isStartup;
        }
        #endregion

        #region Form Events
        private void frmSplash_Load(object sender, EventArgs e)
        {
            // Set Text on Form Loading
            if (this._isStartUp)
            {
                int length = -1;
                for (int i = 0; i < 2; i++)
                {
                    length = clsGlobal.AssemblyVersion.IndexOf(".", (int)(length + 1));
                }
                this.lbTitle.Text = clsGlobal.AssemblyTitle + string.Format(" v{0}", clsGlobal.AssemblyVersion.Substring(0, length))
                    + " is loading, please wait...";
            }
            else
            {
                this.lbTitle.Text = "Reconnecting Controllers";
            }
            this.lbInformation.Text = clsGlobal.AssemblyCopyright;
            this.timer1.Enabled = true;
        }

        private void frmSplash_Click(object sender, EventArgs e)
        {
            // If no controllers found then click on the form to continue
            if (this._mWC.Count == 0)
            {
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // If no controllers found then click on the picturebox to continue
            if (this._mWC.Count == 0)
            {
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Connect to each Wiimote
            if (this._mWC.Count > 0)
            {
                foreach (Wiimote wiimote in this._mWC)
                {
                    wiimote.Connect();
                    this.tsProgbar.Value++;
                }
                // Wait for 3s and close form
                System.Threading.Thread.Sleep(3000);
                this.timer1.Enabled = false;
                this.Close();
            }
        }
        #endregion

        #region Private Methods
        private void findAllWiiMotes()
        {
            // Find all Wiimotes connected to the computer
            try
            {
                this._mWC.FindAllWiimotes();
            }
            catch (WiimoteNotFoundException ex)
            {
                this.tsProgbar.Visible = false;
                this.tsStatusLb.Text = ex.Message + " Please check the status of controllers and click to continue.";
            }
            catch (WiimoteException ex)
            {
                MessageBox.Show(ex.Message, "Wiimote error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unknown error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        #endregion
    }
}

