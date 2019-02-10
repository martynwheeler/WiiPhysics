using System;
using System.Windows.Forms;

namespace WiiPhysics
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                clsGlobal.g_objfrmMDIMain = new frmMDIMain();
                Application.Run(clsGlobal.g_objfrmMDIMain);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "WiiMote Physics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}

