using GUI.Code.DAL;
using GUI.Code.DTO;
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
        bool banco = false;
        bool folder = false;

        public frmConfigDatabase()
        {          

            InitializeComponent();
        }


        private void btSalvar_Click(object sender, EventArgs e)
        {
            if (txtBancoDeDados.Text == "" && (txtFolder.Text == "" || txtServidor.Text == ""))
            {
                MessageBox.Show("Todos os campos liberados devem ser preenchido.");
            }
            else
            {

                if (TesterConexao())
                {
                    Salvar();
                }
                else
                {
                    MessageBox.Show("Dados incorretos, por favor verifique o Servidor e o Banco digitados.");
                }
            }

        }


        private void frmConfigDatabase_Load(object sender, EventArgs e)
        {
            DTOCaminhos dto = new DTOCaminhos();
            string caminho = dto.ConfigDatabase;
            
            if (banco == false && folder == true)
            {
                txtFolder.Text = "";
                txtBancoDeDados.Text = "";
                txtServidor.Text = "";
            }
            else
            {       txtFolder.Text = Properties.Settings.Default.pastaConfig;
                txtServidor.Text = Properties.Settings.Default.servidor;
                    txtBancoDeDados.Text = Properties.Settings.Default.banco;
                
            }
        }


        private void Salvar()
        {
            DTOCaminhos dto = new DTOCaminhos();

            if (txtFolder.Text != "" && txtBancoDeDados.Text == "" && txtServidor.Text == "")
            {
                Properties.Settings.Default.pastaConfig = txtFolder.Text;
                Properties.Settings.Default.Save();
                RetornaConfigs();
                txtBancoDeDados.Enabled = true;
                txtFolder.Enabled = true;
            }
            else
            {
                string caminho = $@"{dto.ConfigDatabase}\conn.txt";
                
                try
                {
                    if (File.Exists(caminho))
                    {
                        File.Delete(caminho);
                    }

                    StreamWriter arquivo = new StreamWriter(caminho);

                    arquivo.WriteLine(txtServidor.Text);
                    arquivo.WriteLine(txtBancoDeDados.Text);

                    arquivo.Close();

                    Properties.Settings.Default.servidor = txtServidor.Text;
                    Properties.Settings.Default.banco = txtBancoDeDados.Text;
                    Properties.Settings.Default.Save();

                    MessageBox.Show("Configuração realizada com sucesso!\nO programa será reiniciado");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Ocorreu um erro grave.\nPor favor contate o administrador do sistema.");

                }
            }
        }

        private bool TesterConexao()
        {

            bool conectado = false;
            string servidor, banco;

            servidor = txtServidor.Text;
            banco = txtBancoDeDados.Text;

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = @"Data Source=" + servidor + ";Initial Catalog = " + banco + "; Persist Security Info=True;User ID = semctrlz; Password=shamboga152099";

            try
            {
                conn.Open();
                conn.Close();
                conectado = true;
            }
            catch
            {

            }

            return conectado;

        }

        private void btTestar_Click(object sender, EventArgs e)
        {
            if (TesterConexao())
            {
                MessageBox.Show("Conexão efetuada com sucesso.");
            }else
            {
                MessageBox.Show("Erro na conexão.");
            }
        }

        private void btProcurar_Click(object sender, EventArgs e)
        {

            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFolder.Text = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.pastaConfig = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.Save();

            }


        }

        private void RetornaConfigs()
        {
            string caminho = $@"{Properties.Settings.Default.pastaConfig}\conn.txt";

            StreamReader arquivo = new StreamReader(caminho);
            txtServidor.Text = arquivo.ReadLine();
            txtBancoDeDados.Text = arquivo.ReadLine();
        }


    }
}
