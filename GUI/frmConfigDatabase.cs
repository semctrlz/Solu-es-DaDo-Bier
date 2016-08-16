using GUI.Code.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmConfigDatabase : Form
    {
        public frmConfigDatabase()
        {
            InitializeComponent();
        }
        private string Db = "";
        private void btSalvar_Click(object sender, EventArgs e)
        {

            try {
                StreamWriter arquivo = new StreamWriter("ConfiguracaoBanco.txt", false);

               
                arquivo.WriteLine(txtBancoDeDados.Text);
                arquivo.WriteLine(txtUsuario.Text);
                arquivo.WriteLine(txtSenha.Text);
                arquivo.Close();
                MessageBox.Show("Arquivo atualizado com sucesso.");
            }
            catch(Exception erro)
            {

                MessageBox.Show(erro.Message);
            }


        }


        private void frmConfigDatabase_Load(object sender, EventArgs e)
        {
            try
            {
                StreamReader arquivo = new StreamReader("ConfiguracaoBanco.txt");
                
                txtBancoDeDados.Text = arquivo.ReadLine();
                txtUsuario.Text = arquivo.ReadLine();
                txtSenha.Text = arquivo.ReadLine();
                arquivo.Close();

                // Testar a conexão

                SqlConnection conexao = new SqlConnection();
                
                conexao.Open();
                conexao.Close();
                
            }
            catch (SqlException errob)
            {

                MessageBox.Show("Erro ao se conectar ao banco de dados. \n" +
                "Acesse as configurações do banco de dados e informe os parâmetros de conexão.\n"+errob);
                    
            }
            catch (Exception erros)
            {

                MessageBox.Show(erros.Message);
            }

        }

        

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            OpenFileDialog saveFileDialog1 = new OpenFileDialog();
            saveFileDialog1.Filter = "Mdf Database|*.mdf";
            saveFileDialog1.Title = "Buscar banco de dados.";
            saveFileDialog1.ShowDialog();

            Db = saveFileDialog1.FileName;

            txtBancoDeDados.Text = Db.ToString().Replace(@"\",@"\\");
        }
    }
}
