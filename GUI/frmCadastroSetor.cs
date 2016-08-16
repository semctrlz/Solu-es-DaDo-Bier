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
    public partial class frmCadastroSetor : Form
    {
        public string NomeProdutoExcluido = "";
        public String operacao;
        private int IdUsuario = 0;
        private int codigo = 0;
        private int IdUnidadeUser = 0;
        private string Busca = "";
        private int carregaUnidade = 0;

        public frmCadastroSetor(int idUsuario)
        {

            IdUsuario = idUsuario;
            
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                //leitura dos dados
                DTOSetor modelo = new DTOSetor();
                modelo.NomeSetor = txtNomeSetor.Text;
                modelo.IdUnidade = Convert.ToInt32(cbUnidade.Text);
                
                //conexão
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLSetor bll = new BLLSetor(cx);

                if (this.operacao == "inserir")
                {

                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado com sucesso. Produto: " + modelo.NomeSetor.ToString() + ".");
                    this.LimpaCampos();
                    this.alteraBotoes(1);

                }
                else
                {
                    // altera produto
                    modelo.IdSetor = Convert.ToInt32(txtId.Text);
                    bll.Alterar(modelo);
                    MessageBox.Show("Cadastro alterado com sucesso. Produto: " + modelo.NomeSetor.ToString() + ".");
                    this.LimpaCampos();
                    this.alteraBotoes(1);
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

            this.CarregaDados();


        }

        private void frmCadastroSetor_Load(object sender, EventArgs e)
        {

            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(IdUsuario);

            IdUnidadeUser = modelou.IdUnidade;

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";


            if(modelou.PermissaoUsuario < 4)
            {
                cbUnidade.Text = modelou.IdUnidade.ToString();
                cbUnidade.Enabled = false;
            }
            else
            {


                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLUnidade bll = new BLLUnidade(cx);
                cbUnidade.DataSource = bll.Localizar("");
                cbUnidade.DisplayMember = "cod_unidade";
                cbUnidade.ValueMember = "cod_unidade";
                cbUnidade.Text = IdUnidadeUser.ToString();
            }


            







            alteraBotoes(2);
            this.operacao = "inserir";
            this.CarregaDados();
            carregaUnidade = 1;
            
        }

        private void alteraBotoes(int op)
        {
            btSalvar.Enabled = false;
            btExcluir.Enabled = false;
            btEditar.Enabled = false;
            pnCadastro.Enabled = true;


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
                pnCadastro.Enabled = false;
            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            alteraBotoes(2);
            this.operacao = "alterar";
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja realmente excluir o registo - " + txtNomeSetor.Text + "?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {

                    NomeProdutoExcluido = txtNomeSetor.Text;
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLSetor bll = new BLLSetor(cx);
                    bll.Excluir(Convert.ToInt32(txtId.Text));

                    MessageBox.Show("Registro " + NomeProdutoExcluido + " excluído com sucesso.");
                    NomeProdutoExcluido = "";
                    this.LimpaCampos();
                    this.alteraBotoes(1);
                    this.CarregaDados();
                }
            }
            catch
            {
                MessageBox.Show("Impossível excluir o registro " + txtNomeSetor.Text + ". \n Ele está sendo utilizado em outro local.");
                this.alteraBotoes(3);
            }
        }

        private void LimpaCampos()
        {

            txtId.Clear();
            txtNomeSetor.Clear();
            cbUnidade.Text = IdUnidadeUser.ToString();
        }

        private void CarregaDados()
        {

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLSetor bll = new BLLSetor(cx);

            

            Busca = "select * from setor WHERE id_unidade = "+ cbUnidade.Text;
            dgvDados.DataSource = bll.Localizar(Busca);

            dgvDados.Columns[0].Visible = false;


            dgvDados.Columns[1].HeaderText = "SETOR";
            dgvDados.Columns[1].Width = 275;

            dgvDados.Columns[2].HeaderText = "UNIDADE";
            dgvDados.Columns[2].Width = 80;

            
        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);

            }

            this.alteraBotoes(3);
            this.operacao = "alterar";

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLSetor bll = new BLLSetor(cx);

            DTOSetor modelo = bll.CarregaModeloGrupo(codigo);
            txtId.Text = modelo.IdSetor.ToString();
            txtNomeSetor.Text = modelo.NomeSetor.ToString();
            cbUnidade.Text = modelo.IdUnidade.ToString();
            
            //carrega dados na tabela
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            if ((txtNomeSetor.Enabled) && txtNomeSetor.Text == "")
            {
                this.Close();

            }
            else {
                this.LimpaCampos();
                this.alteraBotoes(1);
            }
        }

        private void cbUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (carregaUnidade != 0)
            {
                this.CarregaDados();
            }
        }
    }
}
