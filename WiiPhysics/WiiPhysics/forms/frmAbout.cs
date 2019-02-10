using System.Windows.Forms;

namespace WiiPhysics
{
    public partial class frmAbout : Form
    {
        #region Constructor
        public frmAbout()
        {
            this.InitializeComponent();
            this.Text = string.Format("About {0}", clsGlobal.AssemblyTitle);
            this.labelProductName.Text = clsGlobal.AssemblyProduct;
            this.labelVersion.Text = string.Format("Version {0}", clsGlobal.AssemblyVersion);
            this.labelCopyright.Text = clsGlobal.AssemblyCopyright;
            this.labelCompanyName.Text = clsGlobal.AssemblyCompany;
            this.textBoxDescription.Text = clsGlobal.AssemblyDescription;
        }
        #endregion
    }
}

