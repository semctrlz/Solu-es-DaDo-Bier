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
    public partial class frmCadastroMixUnidade : Form
    {
        public int IdUnidadeUser = 0;
        private int IdUsuario = 0;
        private string busca = "";
        private int carregasetor = 0;
        private int idExcluir = 0;
        private int codigo = 0;
        private string produtoexcluido = "";
        private string estoqueminexcluido = "";

        public frmCadastroMixUnidade(int Usuario)
        {

            IdUsuario = Usuario;
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            if (cbProduto.Text == "")
            {
                MessageBox.Show("O campo 'Produto' não pode ficar em branco.");
                cbProduto.Select();
            }
            else
            {
                if (txtEstoqueMinimo.Text == "")
                {
                    MessageBox.Show("O campo 'Estoque mínimo' não pode ficar em branco.");
                    txtEstoqueMinimo.Select();
                }
                else
                {
                try
                {
                    //leitura dos dados
                    DTOMixUnidade modelo = new DTOMixUnidade();
                    modelo.IdSetor = Convert.ToInt32(cbSetor.SelectedValue);
                    modelo.IdUnidade = Convert.ToInt32(cbUnidade.SelectedValue);
                    modelo.EstoqueMinimo = Convert.ToInt32(txtEstoqueMinimo.Text);
                    modelo.IdProduto = Convert.ToInt32(cbProduto.SelectedValue);

                    //conexão
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLMixUnidade bll = new BLLMixUnidade(cx);

                    bll.Incluir(modelo);

                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message);
                    }
                    this.LimpaCampos(1);
                    this.CarregaDados();
                }
            }
        }

        private void frmCadastroMixUnidade_Load(object sender, EventArgs e)
        {
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(IdUsuario);

            IdUnidadeUser = modelou.IdUnidade;

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";


            if (modelou.PermissaoUsuario < 4)
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLUnidade bll = new BLLUnidade(cx);
                cbUnidade.DataSource = bll.Localizar("");
                cbUnidade.DisplayMember = "cod_unidade";
                cbUnidade.ValueMember = "id_unidade";
                cbUnidade.Text = IdUnidadeUser.ToString();



    cbUnidade.Text = modelou.IdUnidade.ToString("00");
                cbUnidade.Enabled = false;
            }
            else
            {


                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLUnidade bll = new BLLUnidade(cx);
                cbUnidade.DataSource = bll.Localizar("");
                cbUnidade.DisplayMember = "cod_unidade";
                cbUnidade.ValueMember = "id_unidade";
                cbUnidade.Text = IdUnidadeUser.ToString();
            }



            busca = "select * from setor WHERE id_unidade = " + cbUnidade.Text;
           
            //Preenche o combobox Setor

            DALConexao cxs = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLSetor blls = new BLLSetor(cxs);
            cbSetor.DataSource = blls.Localizar(busca);
            cbSetor.DisplayMember = "nome_setor";
            cbSetor.ValueMember = "id_setor";
            cbSetor.Text = "";

            //Preenche o produto Setor
            DALConexao cxp = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLProduto bllp = new BLLProduto(cxp);
            cbProduto.DataSource = bllp.LocalizarNome("");
            cbProduto.DisplayMember = "nome_produto";
            cbProduto.ValueMember = "id_produto";
            cbProduto.Text = "";





            alteraBotoes(1);
            carregasetor = 1;

        }

        private void atualizaCB()
        {

            busca = "select * from setor WHERE id_unidade = " + cbUnidade.Text;


            DALConexao cxs = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLSetor blls = new BLLSetor(cxs);
            cbSetor.DataSource = blls.Localizar(busca);
            cbSetor.DisplayMember = "nome_setor";
            cbSetor.ValueMember = "id_setor";
           
        }

        private void alteraBotoes(int op)
        {
            btSalvar.Enabled = false;
            btExcluir.Enabled = false;
            btEditar.Enabled = false;
            pnCadastro.Enabled = true;
            gbInformacoesSetor.Enabled = false;
            gbProduto.Enabled = false;


            if (op == 1)
            {
                gbInformacoesSetor.Enabled = true;
                
            }

            if (op == 2)
            {

                btSalvar.Enabled = true;
                btEditar.Enabled = true;
                btExcluir.Enabled = true;
                gbProduto.Enabled = true;

            }

           
        }

        private void cbSetor_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (carregasetor == 1)
            {
                this.CarregaDados();
                this.alteraBotoes(2);
            }
        }

        private void cbUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (carregasetor == 1) {
                this.atualizaCB();
                
            }
        }

        private void LimpaCampos(int tipo)
        {
            if (tipo == 1)
            {
                cbProduto.Text = "";
                txtEstoqueMinimo.Clear();
                cbProduto.Select();
                
            }
            else
            { 
                cbSetor.Text = "";
                cbProduto.Text = "";
                txtEstoqueMinimo.Clear();
                cbUnidade.Text = IdUnidadeUser.ToString();

            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            if ((cbSetor.Enabled) && cbSetor.Text == "")
            {
                this.Close();

            }
            else {

                this.btEditar_Click(sender, e);
            }
        }

        private void CarregaDados()
        {

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLMixUnidade bll = new BLLMixUnidade(cx);

            busca = "SELECT m.id_mix, m.id_unidade, u.cod_unidade, u.nome_unidade, "+
                "m.id_produto, p.nome_produto, p.marca_produto, p.modelo_produto, m.id_setor, "+
                "s.nome_setor, m.estoque_min_setor from mix_unidade m inner join setor s on m.id_setor "+
                "= s.id_setor inner join unidade u on m.id_unidade = u.id_unidade inner join produto p "+
                "on m.id_produto = p.id_produto WHERE id_unidade = " + cbUnidade.SelectedValue;
            dgvDados.DataSource = bll.Localizar(Convert.ToInt32(cbUnidade.SelectedValue), Convert.ToInt32(cbSetor.SelectedValue));


            dgvDados.Columns[0].Visible = false;
            dgvDados.Columns[1].Visible = false;
            dgvDados.Columns[2].Visible = false;
            dgvDados.Columns[3].Visible = false;
            dgvDados.Columns[4].Visible = false;
            dgvDados.Columns[8].Visible = false;
            dgvDados.Columns[9].Visible = false;

            dgvDados.Columns[5].HeaderText = "PRODUTO";
            dgvDados.Columns[5].Width = 200;
            dgvDados.Columns[6].HeaderText = "MARCA";
            dgvDados.Columns[6].Width = 118;
            dgvDados.Columns[7].HeaderText = "MODELO";
            dgvDados.Columns[7].Width = 118;
            dgvDados.Columns[10].HeaderText = "ESTOQUE MÍN.";
            dgvDados.Columns[10].Width = 70;


        }

        private void cbProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmConsultaBasica_Produto f = new frmConsultaBasica_Produto(1, IdUsuario);
                f.ShowDialog();

                if (f.codigo != 0)
                {
                    
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLProduto bll = new BLLProduto(cx);

                    DTOProduto modelo = bll.CarregaModeloProduto(f.codigo);
                    
                    cbProduto.Text = modelo.NomeProduto.ToString();
                    
                }
                

                f.Dispose();

            }
        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0)
            {

                cbProduto.Text = dgvDados.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtEstoqueMinimo.Text = dgvDados.Rows[e.RowIndex].Cells[10].Value.ToString();


                this.idExcluir = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLMixUnidade bll = new BLLMixUnidade(cx);
                bll.Excluir(idExcluir);
                this.CarregaDados();

            }

           

        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            this.LimpaCampos(1);
            this.alteraBotoes(1);
            cbSetor.Text = "";
            this.dgvDados.DataSource = null;
            cbSetor.Select();
        }

        private void txtEstoqueMinimo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btSalvar_Click(sender, e);

            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (codigo > 0)
            {
                cbProduto.Text = produtoexcluido;
                txtEstoqueMinimo.Text = estoqueminexcluido;

                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLMixUnidade bll = new BLLMixUnidade(cx);
                bll.Excluir(codigo);
                this.CarregaDados();

            }
        }

        private void dgvDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
            produtoexcluido = dgvDados.Rows[e.RowIndex].Cells[5].Value.ToString();
            estoqueminexcluido = dgvDados.Rows[e.RowIndex].Cells[10].Value.ToString();
        }
    }
}
