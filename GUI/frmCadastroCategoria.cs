using GUI.Code.BLL;
using GUI.Code.DAL;
using GUI.Code.DTO;
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
    public partial class frmCadastroCategoria : Form
    {
        private int codigo = 0;
        public String operacao;
        public string NomeExclusao;
        public frmCadastroCategoria()
        {
            InitializeComponent();
        }

        private void frmCadastroCategoria_Load(object sender, EventArgs e)
        {

            this.CarregaDados();
            this.alteraBotoes(1);
        }

        private void CarregaDados()
        {

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLGrupo bll = new BLLGrupo(cx);


            dgvCategoria.DataSource = bll.Localizar("");

            dgvCategoria.Columns[0].Visible = false;


            dgvCategoria.Columns[1].HeaderText = "COD";
            dgvCategoria.Columns[1].Width = 50;

            dgvCategoria.Columns[2].HeaderText = "GRUPO";
            dgvCategoria.Columns[2].Width = 107;

            dgvCategoria.Columns[3].HeaderText = "DESCRIÇÃO";
            dgvCategoria.Columns[3].Width = 200;

        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            alteraBotoes(2);
            this.operacao = "alterar";
        }

        private void dgvCategoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.codigo = Convert.ToInt32(dgvCategoria.Rows[e.RowIndex].Cells[0].Value);
                
            }

            this.alteraBotoes(3);
            this.operacao = "alterar";

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLGrupo bll = new BLLGrupo(cx);

            DTOGrupo modelo = bll.CarregaModeloGrupo(codigo);
            txtId.Text = modelo.IdGrupo.ToString();
            txtCod.Text = modelo.CodGrupo.ToString();
            txtNome.Text = modelo.NomeGrupo.ToString();
            txtDesc.Text = modelo.DescGrupo.ToString();
            //carrega dados na tabela


        }

        private void alteraBotoes(int op)
        {
            btSalvar.Enabled = false;
            btExcluir.Enabled = false;
            btEditar.Enabled = false;
            txtNome.Enabled = true;
            txtCod.Enabled = true;
            txtDesc.Enabled = true;


            if (op == 1)
            {
                btSalvar.Enabled = true;
                
            }

            if (op == 2)
            {
                
                btSalvar.Enabled = true;

            }

            if (op == 3)
            {
                btEditar.Enabled = true;
                btExcluir.Enabled = true;
                txtNome.Enabled = false;
                txtCod.Enabled = false;
                txtDesc.Enabled = false;

            }
        }

        private void LimpaCampos()
        {
            txtCod.Clear();
            txtNome.Clear();
            txtId.Clear();
            txtDesc.Clear();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            if ((txtNome.Enabled) && txtNome.Text == "")
            {
                this.Close();

            }
            else {
                this.LimpaCampos();
                this.alteraBotoes(1);
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //leitura dos dados
                DTOGrupo modelo = new DTOGrupo();
                modelo.CodGrupo = Convert.ToString(txtCod.Text);
                modelo.NomeGrupo = Convert.ToString(txtNome.Text);
                modelo.DescGrupo = Convert.ToString(txtDesc.Text);
                

                //conexão
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLGrupo bll = new BLLGrupo(cx);

                if (this.operacao != "alterar")
                {
                    // cadastra fornecedor
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado com sucesso. Grupo: " + modelo.NomeGrupo.ToString() + ".");
                    this.LimpaCampos();
                    this.alteraBotoes(1);
                }
                else
                {
                    // altera fornecedor
                    modelo.IdGrupo = Convert.ToInt32(txtId.Text);
                    bll.Alterar(modelo);
                    MessageBox.Show("Cadastro alterado com sucesso. Grupo: " + modelo.NomeGrupo.ToString() + ".");
                    this.LimpaCampos();
                    this.alteraBotoes(1);
                }

                this.CarregaDados();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja realmente excluir o grupo - " + txtNome.Text + "?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {

                    NomeExclusao = txtNome.Text;
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLGrupo bll = new BLLGrupo(cx);
                    bll.Excluir(Convert.ToInt32(txtId.Text));

                    MessageBox.Show("Grupo "+NomeExclusao+" excluído com sucesso.");
                    NomeExclusao = "";
                    this.LimpaCampos();
                    this.alteraBotoes(1);

                    this.CarregaDados();
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
