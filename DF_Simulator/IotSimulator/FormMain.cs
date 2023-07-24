using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOTSimulator
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buildSimulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            frmBuildSimulator oFrm = new frmBuildSimulator();
            oFrm.StartPosition = FormStartPosition.CenterScreen;
            oFrm.ShowDialog(this);
            oFrm.Dispose();
            oFrm = null;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBGJobsStatus oFrm = new frmBGJobsStatus();
            oFrm.StartPosition = FormStartPosition.CenterScreen;
            oFrm.ShowDialog(this);
            oFrm.Dispose();
            oFrm = null;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
