using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WiiPhysics
{
    public partial class frmDataTab : Form
    {
        public frmDataTab()
        {
            InitializeComponent();
        }


        /*
         * Ideas:
         * This dialog should act as a control that can start logging for a set interval?
         * After the interval has elapsed it should look at the data collected over that interval anf obtain an average which goes into col2
         * The last time should be remembered such that this can be repeated until all of the data is collected
         * Ideally each time the average is obatined the data from the grid will be plotted to see how it is doing
         * This will work for hooke's law measurements, maybe circular motion?
         */
        private void button1_Click(object sender, EventArgs e)
        {
            clsGlobal.g_objfrmMDIMain.startLogging();
        }
    }
}
