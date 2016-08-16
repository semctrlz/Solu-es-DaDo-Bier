using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Code.DAL;
using Ferramentas;

namespace GUI
{
    public partial class frmBeckupDatabase : Form
    {
        public frmBeckupDatabase()
        {
            InitializeComponent();
        }

        private void btBeckup_Click(object sender, EventArgs e)
        {

            try
            {
                SaveFileDialog d = new SaveFileDialog();
                d.Filter = "Backup Files|*.bak";
                d.ShowDialog();

                if (d.FileName != "")
                {
                    

                    
                    MessageBox.Show("Backup realizado com sucesso.");
                }
            }

            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

        private void btRestaura_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog d = new OpenFileDialog();
                d.Filter = "Backup Files|*.bak";
                d.ShowDialog();

                if (d.FileName != "")
                {

                    
                    MessageBox.Show("Restauração realizada com sucesso.");
                }
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}
