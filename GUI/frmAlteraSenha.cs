using GUI.Code.BLL;
using GUI.Code.DAL;
using GUI.Code.DTO;
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

namespace GUI
{
    public partial class frmAlteraSenha : Form
    {
        int IdUsuario;
        String NomeUsuario;
        String SenhaUsuario;
        String LoginUsuario;
        String IniciaisUsuario;
        

        public frmAlteraSenha(int Id, string Nome, string Usuario, string Iniciais)
        {

            IdUsuario = Id;
            NomeUsuario = Nome;
            LoginUsuario = Usuario;

           

                string StringDeConexao = DadosDaConexao.StringDaConexao.ToString();
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = StringDeConexao;


                    SqlCommand cmd = new SqlCommand("select * from usuario where id_usuario = '" + IdUsuario + "';", cn);
                    cn.Open();
                    SqlDataReader dados = cmd.ExecuteReader();

                    if (dados.HasRows)

                        dados.Read();

                    SenhaUsuario = Convert.ToString(dados["senha_usuario"]);

                }



                IniciaisUsuario = Iniciais;

                InitializeComponent();

           
        }

        private void frmAlteraSenha_Load(object sender, EventArgs e)
        {

                lbUsuario.Text = LoginUsuario + " (" + IniciaisUsuario + ")";

        }

        private void btAltera_Click(object sender, EventArgs e)
        {

            if (SenhaUsuario == txtSenhaAtual.Text)
            {

                if (txtNovaSenha1.Text == "")
                {

                    MessageBox.Show("O campo Nova senha não pode ficar vazio.");
                    txtNovaSenha1.BackColor = Color.IndianRed;
                    txtNovaSenha1.Select();

                }
                else {

                    if (txtNovaSenha2.Text == "")
                    {
                        MessageBox.Show("O campo Repetir nova senha não pode ficar vazio.");
                        txtNovaSenha2.BackColor = Color.IndianRed;
                        txtNovaSenha2.Select();

                    }
                    else
                    {

                        if (txtNovaSenha1.Text != txtNovaSenha2.Text)
                        {

                            txtNovaSenha1.BackColor = Color.IndianRed;
                            txtNovaSenha2.BackColor = Color.IndianRed;
                            txtNovaSenha1.Select();
                            MessageBox.Show("As senhas devem ser iguais.");
                        }
                        else
                        {
                            //Altera DB

                            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                            BLLUsuario bll = new BLLUsuario(cx);

                            //leitura dos dados
                            DTOUsuario modelo = new DTOUsuario();
                            modelo.SenhaUsuario = txtNovaSenha2.Text;
                            modelo.IdUsuario = Convert.ToInt32(IdUsuario);
                            bll.AlterarSenha(modelo);
                            MessageBox.Show("Senha alterada com sucesso.");
                            this.Close();


                        }
                    }

                }
                
            }
            else
            {

                txtSenhaAtual.BackColor = Color.IndianRed;
                txtSenhaAtual.Select();
                MessageBox.Show("Senha informada inválida.");

            }
        }

        private void txtNovaSenha1_TextChanged(object sender, EventArgs e)
        {
            txtNovaSenha1.BackColor = Color.White;
            txtNovaSenha2.BackColor = Color.White;
        }

        private void txtNovaSenha2_TextChanged(object sender, EventArgs e)
        {
            txtNovaSenha1.BackColor = Color.White;
            txtNovaSenha2.BackColor = Color.White;
        }

        private void btCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSenhaAtual_TextChanged(object sender, EventArgs e)
        {
            txtSenhaAtual.BackColor = Color.White;
        }

        private void txtSenhaAtual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btAltera_Click(sender, e);

            }


            if (e.KeyCode == Keys.Escape)
            {
                btCancela_Click(sender, e);

            }
        }

        private void txtNovaSenha1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btAltera_Click(sender, e);

            }


            if (e.KeyCode == Keys.Escape)
            {
                btCancela_Click(sender, e);

            }
        }

        private void txtNovaSenha2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btAltera_Click(sender, e);

            }


            if (e.KeyCode == Keys.Escape)
            {
                btCancela_Click(sender, e);

            }
        }

        private DALConexao conexao;

        private void LocalizarSenha(int codigo)
        {


            DTOUsuario modelo = new DTOUsuario();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from usuario where (id_usuario) =" + codigo.ToString();
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.SenhaUsuario = Convert.ToString(registro["senha_usuario"]);
                SenhaUsuario = modelo.SenhaUsuario;


            }
        }

    }
}
