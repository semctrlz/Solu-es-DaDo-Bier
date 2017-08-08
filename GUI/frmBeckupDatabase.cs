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
using GUI.Code.DTO;

namespace GUI
{
    public partial class frmBeckupDatabase : Form
    {
        public frmBeckupDatabase()
        {
            InitializeComponent();
        }

        public static string name = System.Environment.MachineName;
       
        private void btBeckup_Click(object sender, EventArgs e)
        {

            try
            {

                DateTime dt = DateTime.Now;
                SaveFileDialog d = new SaveFileDialog();
                d.Filter = "Backup Files|*.bak";
                d.FileName = $"Backup_{dt.ToString("dd")}-{dt.ToString("MM")}-{dt.ToString("yyyy")}";
                d.ShowDialog();

                if (d.FileName != "")
                {
                    String nomeBanco = Properties.Settings.Default.banco;
                    String localBackup = d.FileName;
                    String conexao = DadosDaConexao.StringDaConexao;


                    SQLServerBackup.BackupDataBase(conexao, nomeBanco, d.FileName);


                    MessageBox.Show("Backup realizado com sucesso.");

                }

            }

            catch (Exception erro)
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
                    String nomeBanco = Properties.Settings.Default.banco;
                    String localBackup = d.FileName;
                    String conexao = DadosDaConexao.StringDaConexao;

                    SQLServerBackup.RestauraDatabase(conexao, nomeBanco, d.FileName);

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
