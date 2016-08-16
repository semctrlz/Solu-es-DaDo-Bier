using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmConfigDatabase f = new frmConfigDatabase();
            f.ShowDialog();
            f.Dispose();
        }

        private void btBeckup_Click(object sender, EventArgs e)
        {
            frmBeckupDatabase f = new frmBeckupDatabase();
            f.ShowDialog();
            f.Dispose();
        }
    }
}
