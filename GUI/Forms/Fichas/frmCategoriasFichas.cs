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

namespace GUI.Forms.Fichas
{
    public partial class frmCategoriasFichas : Form
    {

        string tipo;
        public string categoria;
        bool herdado;
        int unidade, idUsuario;
        
        public frmCategoriasFichas(string _tipo, bool _herdado, int id)
        {
            tipo = _tipo;
            herdado = _herdado;
            idUsuario = id;

            InitializeComponent();
        }

        private void frmCategoriasFichas_Load(object sender, EventArgs e)
        {
            this.Text = $"Cadastro de {tipo}";
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(Convert.ToInt32(idUsuario));

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";

            DefaultValues();
            CarregarDgv();

        }

        private void DefaultValues()
        {
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUnidade bllun = new BLLUnidade(con);
            BLLUsuario bllu = new BLLUsuario(con);
            DTOUsuario modelou = bllu.CarregaModeloUsuario(Convert.ToInt32(idUsuario));

            cbUnidade.DataSource = bllun.ListarUnidades();
            cbUnidade.DisplayMember = "cod_unidade";
            cbUnidade.ValueMember = "id_unidade";
            cbUnidade.Text = modelou.IdUnidade.ToString();

            if (modelou.PermissaoUsuario < 4)
            {
                cbUnidade.Enabled = false;
            }

            unidade = Convert.ToInt32(cbUnidade.SelectedValue);

            txtId.Clear();
            txtNome.Clear();
            dgvCat.Rows.Clear();
            lbNome.Text = "Nome " + tipo;
            lbDesc.Text = "Descrição " + tipo;

        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            if(txtId.Text == "")
            {
                Salvar();                
            }
            else
            {
                Alterar();
            }

            if (herdado)
            {
                DialogResult d = MessageBox.Show("Deseja voltar à tela anterior para continuar o cadastro de onde parou?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    
                    this.Close();
                }
            }

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {

        }

        private void CarregarDgv()
        {
            dgvCat.Rows.Clear();
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

            DataTable tabela;

            if(tipo == "Setor")
            {
                BLLBuffet blls = new BLLBuffet(cx);
                tabela = blls.Listar();

                if (tabela.Rows.Count > 0)
                {

                    for(int i = 0; tabela.Rows.Count > i; i++)
                    {
                        String[] V = new string[] { tabela.Rows[i][0].ToString(), tabela.Rows[i][1].ToString(), tabela.Rows[i][2].ToString() };
                        dgvCat.Rows.Add(V);
                    }
                    
                }

            }
            else if (tipo == "Categoria")
            {
                BLLCategoria bllc = new BLLCategoria(cx);
                tabela = bllc.Listar();

                if (tabela.Rows.Count > 0)
                {

                    for (int i = 0; tabela.Rows.Count > i; i++)
                    {
                        String[] V = new string[] { tabela.Rows[i][0].ToString(), tabela.Rows[i][1].ToString(), tabela.Rows[i][2].ToString() };
                        dgvCat.Rows.Add(V);
                    }

                }
            }
            else
            {
                BLLSubCategoria bllsc = new BLLSubCategoria(cx);
                tabela = bllsc.Listar();

                if (tabela.Rows.Count > 0)
                {

                    for (int i = 0; tabela.Rows.Count > i; i++)
                    {
                        String[] V = new string[] { tabela.Rows[i][0].ToString(), tabela.Rows[i][1].ToString(), tabela.Rows[i][2].ToString() };
                        dgvCat.Rows.Add(V);
                    }

                }
            }



        }

        private void Salvar()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);


            if (txtNome.Text.Trim() != "")
            {
                
                if (tipo == "Setor")
                {
                    BLLBuffet blls = new BLLBuffet(cx);
                    DTOBuffet dtob = new DTOBuffet();

                    dtob.NomeBuffet = txtNome.Text.Trim().ToUpper();
                    dtob.DescBuffet = txtDesc.Text.Trim().ToUpper();

                    blls.Incluir(dtob);

                    this.categoria = dtob.NomeBuffet;

                    txtNome.Clear();
                    txtDesc.Clear();
                    
                    CarregarDgv();


                }
                if (tipo == "Categoria")
                {
                    BLLCategoria bllc = new BLLCategoria(cx);
                    DTOCategoria dtoc = new DTOCategoria();

                    dtoc.NomeCat = txtNome.Text.Trim().ToUpper();
                    dtoc.DescCat = txtDesc.Text.Trim().ToUpper();

                    bllc.Incluir(dtoc);

                    this.categoria = dtoc.NomeCat;

                    txtNome.Clear();
                    txtDesc.Clear();

                    CarregarDgv();

                }
                if (tipo == "Subcategoria")
                {
                    BLLSubCategoria bllsc = new BLLSubCategoria(cx);
                    DTOSubCategoria dtosc = new DTOSubCategoria();

                    dtosc.NomeSCat = txtNome.Text.Trim().ToUpper();
                    dtosc.DescSCat = txtDesc.Text.Trim().ToUpper();

                    bllsc.Incluir(dtosc);

                    this.categoria = dtosc.NomeSCat;

                    txtNome.Clear();
                    txtDesc.Clear();

                    CarregarDgv();
                }
            }
            
        }

        private void Alterar()
        {

        }

    }
}
