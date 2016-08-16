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
    public partial class frmConsultaBasica_Produto : Form
    {
        private string operacao = "";
        int idUsuario;
        public frmConsultaBasica_Produto(int op, int usuario)
        {

            idUsuario = usuario;

            if(op == 1)
            {
                operacao = "busca";
            }
            if(op == 2)
            {
                operacao = "altera";
            }
            

            InitializeComponent();
        }

        public int codigo = 0;
        private string Busca = "select * from produto";
        private int QuantFiltros = 0;

        private void frmConsultaBasica_Produto_Load(object sender, EventArgs e)
        {
            
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(idUsuario);
            
            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";
            
            cbAtivos.Checked = true;
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLGrupo bll = new BLLGrupo(cx);
            cbGrupo.DataSource = bll.Localizar("");
            cbGrupo.DisplayMember = "nome_grupo";
            cbGrupo.ValueMember = "id_grupo";
            cbGrupo.Text = "";

            btDetalhes.Enabled = false;


            this.btLocalizar_Click(sender, e);
        }

        private void Atualizar()
        {

            
            dgvProduto.Columns[0].Visible = false;
            
            dgvProduto.Columns[1].HeaderText = "NOME";
            dgvProduto.Columns[1].Width = 150;

            dgvProduto.Columns[2].HeaderText = "COD";
            dgvProduto.Columns[2].Width = 80;

            dgvProduto.Columns[3].Visible = false;

            dgvProduto.Columns[4].HeaderText = "GRUPO";
            dgvProduto.Columns[4].Width = 100;

            dgvProduto.Columns[5].HeaderText = "MARCA";
            dgvProduto.Columns[5].Width = 150;

            dgvProduto.Columns[6].HeaderText = "MODELO";
            dgvProduto.Columns[6].Width = 150;

            dgvProduto.Columns[7].HeaderText = "DESCRIÇÃO";
            dgvProduto.Columns[7].Width = 250;

            dgvProduto.Columns[8].HeaderText = "ATIVO";
            dgvProduto.Columns[8].Width = 50;

            dgvProduto.Columns[9].HeaderText = "DATA CRIAÇÃO";
            dgvProduto.Columns[9].Width = 100;

            dgvProduto.Columns[10].Visible = false;

            dgvProduto.Columns[11].HeaderText = "CRIADOR";
            dgvProduto.Columns[11].Width = 75;

            
            if (operacao == "busca")
            {
                cbAtivos.Enabled = false;
            }
            else
            {
                cbAtivos.Enabled = true;
            }

        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            Busca = "select p.id_produto, p.nome_produto, p.cod_produto, p.id_grupo, g.nome_grupo, "+
                "p.marca_produto, p. modelo_produto, p.desc_produto, p.ativo_produto, p.data_criacao_produto, "+
                "p.id_usuario, u.Iniciais_usuario from produto p inner join grupo g on "+
                "p.id_grupo = g.id_grupo inner join usuario u on p.id_usuario = u.id_usuario";
            QuantFiltros = 0;


            if (cbGrupo.Text != "" || txtNome.Text != "" || txtMarca.Text != "" || txtModelo.Text != "" || cbAtivos.Checked == true)
            {
                Busca = Busca + " WHERE";
            }
            if (cbGrupo.Text != "")
            {
                Busca = Busca + " p.id_grupo = " + cbGrupo.SelectedValue;
                QuantFiltros = QuantFiltros + 1;
            }


            if (txtNome.Text != "")
            {

                if (QuantFiltros > 0)
                {
                    Busca = Busca + " and";
                }
                Busca = Busca + " p.nome_produto like '%" + txtNome.Text + "%'";
                QuantFiltros = QuantFiltros + 1;
            }

            if (txtMarca.Text != "")
            {

                if (QuantFiltros > 0)
                {
                    Busca = Busca + " and";
                }

                Busca = Busca + " p.marca_produto like '%" + txtMarca.Text + "%'";
                QuantFiltros = QuantFiltros + 1;
            }

            if (txtModelo.Text != "")
            {

                if (QuantFiltros > 0)
                {
                    Busca = Busca + " and";
                }

                Busca = Busca + " p.modelo_produto like '%" + txtModelo.Text + "%'";
                QuantFiltros = QuantFiltros + 1;
            }

            if (cbAtivos.Checked == true)
            {

                if (QuantFiltros > 0)
                {
                    Busca = Busca + " and";
                }

                Busca = Busca + " p.ativo_produto = 1";
                QuantFiltros = QuantFiltros + 1;
            }

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLProduto bll = new BLLProduto(cx);

            dgvProduto.DataSource = bll.ConsultaProduto(Busca);
            this.Atualizar();
        }

        private void dgvProduto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            
            if (operacao == "busca" || operacao == "altera")
            {

                if (e.RowIndex >= 0)
                {
                    this.codigo = Convert.ToInt32(dgvProduto.Rows[e.RowIndex].Cells[0].Value);
                    this.Close();
                }
                


        }
            else
            {
                codigo = Convert.ToInt32(dgvProduto.Rows[e.RowIndex].Cells[0].Value);

                frmDadosProduto frm = new frmDadosProduto(codigo);
                frm.ShowDialog();
                frm.Dispose();
            }
          
        }

        private void btImagem_Click(object sender, EventArgs e)
        {
            frmDadosProduto frm = new frmDadosProduto(codigo);
            frm.ShowDialog();
            frm.Dispose();
        }

        private void dgvProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                codigo = Convert.ToInt32(dgvProduto.Rows[e.RowIndex].Cells[0].Value);
                btDetalhes.Enabled = true;

            }
            catch { }
        }

        private void btDetalhes_Click(object sender, EventArgs e)
        {

            frmDadosProduto frm = new frmDadosProduto(codigo);
            frm.ShowDialog();
            frm.Dispose();

        }

        

        private void frmConsultaBasica_Produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();

            }

            if (e.KeyCode == Keys.Enter)
            {
                this.btLocalizar_Click(sender, e);

            }

        }
    }
}
