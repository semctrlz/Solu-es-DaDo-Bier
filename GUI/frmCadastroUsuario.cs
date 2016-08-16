using GUI.Code.BLL;
using GUI.Code.DAL;
using GUI.Code.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCadastroUsuario : GUI.frmModeloFormularioDeCadastro
    {
        public frmCadastroUsuario()
        {
            InitializeComponent();
        }

        private void frmCadastroUsuario_Load(object sender, EventArgs e)
        {
            CbNivel.Items.Add("Visualizador");
            CbNivel.Items.Add("Operador");
            CbNivel.Items.Add("Líder");
            CbNivel.Items.Add("Administrador");

            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUnidade bllun = new BLLUnidade(cx);


            cbUnidade.DataSource = bllun.ListarUnidades();

            cbUnidade.DisplayMember = "cod_unidade";
            cbUnidade.ValueMember = "id_unidade";
            cbUnidade.Text = "";
            
            alteraBotoes(1);
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            alteraBotoes(2);
            this.operacao = "inserir";
            txtNome.Select();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            if (!(txtNome.Enabled) && txtNome.Text == "")
            {
                this.Close();

            }
            else {
                this.LimpaCampos();
                this.alteraBotoes(1);
            }
        }

        public void LimpaCampos()
        {
            txtNome.Clear();
            txtLogin.Clear();
            CbNivel.Text = "";
            txtIniciais.Clear();
            cbUnidade.Text = "";
            txtemail.Clear();
            
        }

        private int NvAcesso = 0;

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //leitura dos dados
                DTOUsuario modelo = new DTOUsuario();
                modelo.NomeUsuario = txtNome.Text;
                modelo.LoginUsuario = txtLogin.Text;

                modelo.SenhaUsuario = "dado@" + DateTime.Now.Year;

                modelo.IniciaisUsuario = txtIniciais.Text;
                modelo.EmailUsuario = txtemail.Text;

                if (CbNivel.Text == "Visualizador")
                {
                    NvAcesso = 1;
                }
                else if (CbNivel.Text == "Operador")
                {
                    NvAcesso = 2;
                }
                else if (CbNivel.Text == "Líder")
                {
                    NvAcesso = 3;
                }
                else if (CbNivel.Text == "Administrador")
                {
                    NvAcesso = 4;
                }
                modelo.PermissaoUsuario = NvAcesso;

                modelo.IdUnidade = Convert.ToInt32(cbUnidade.Text);


                //conexão
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLUsuario bll = new BLLUsuario(cx);

                if (this.operacao == "inserir")
                {
                    // cadastra usuario
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado com sucesso. Usuário: " + modelo.LoginUsuario.ToString() + ".");
                    this.LimpaCampos();
                    this.alteraBotoes(1);
                }
                else
                {
                    // altera fornecedor
                    modelo.IdUsuario = Convert.ToInt32(txtIdUsuario.Text);
                    bll.Alterar(modelo);
                    MessageBox.Show("Cadastro alterado com sucesso. Usuário: " + modelo.LoginUsuario.ToString() + ".");
                    this.LimpaCampos();
                    this.alteraBotoes(1);
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }
        private String Acesso;

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaUsuario fc = new frmConsultaUsuario();
            fc.ShowDialog();

            
            if (fc.codigo != 0)
            {
                this.alteraBotoes(3);
                this.operacao = "alterar";

                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLUsuario bll = new BLLUsuario(cx);

                DTOUsuario modelo = bll.CarregaModeloUsuario(fc.codigo);
                txtNome.Text = modelo.NomeUsuario.ToString();
                txtLogin.Text = modelo.LoginUsuario.ToString();
                txtIniciais.Text = modelo.IniciaisUsuario.ToString();
                txtIdUsuario.Text = modelo.IdUsuario.ToString();
                cbUnidade.Text = modelo.IdUnidade.ToString();
                txtemail.Text = modelo.EmailUsuario.ToString();

                if(modelo.PermissaoUsuario == 1)
                {
                    Acesso = "Visualizador";
                }
                else if(modelo.PermissaoUsuario == 2)
                {
                    Acesso = "Operador";
                }
                else if (modelo.PermissaoUsuario == 3)
                {
                    Acesso = "Líder";
                }
                else if (modelo.PermissaoUsuario == 4)
                {
                    Acesso = "Administrador";
                }

                CbNivel.Text = Acesso;
                cbUnidade.Text = modelo.IdUnidade.ToString();
            }
            else {
                this.LimpaCampos();
                this.alteraBotoes(1);
            }
            fc.Dispose();
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            this.alteraBotoes(2);
            
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja realmente excluir o usuário - " + txtNome.Text + "?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLUsuario bll = new BLLUsuario(cx);
                    bll.Excluir(Convert.ToInt32(txtIdUsuario.Text));
                    this.LimpaCampos();
                    this.alteraBotoes(1);
                }
            }
            catch
            {
                MessageBox.Show("Impossível excluir o registro. \n O registro está sendo utilizado em outro local.");
                this.alteraBotoes(3);
            }
        }

    }
}

