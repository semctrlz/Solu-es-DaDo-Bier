using BLL;
using DAL;
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
    public partial class frmConsultaProduto : Form
    {
        public int codigo = 0;
        private string Busca = "select * from produto";
        private int QuantFiltros = 0;

        public frmConsultaProduto()
        {
            InitializeComponent();
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {

            Busca = "select * from produto";
            QuantFiltros = 0;


            if(cbGrupo.Text != "" || txtNome.Text != "" || txtMarca.Text != "" || txtModelo.Text != "" || cbAtivos.Checked == true)
            {
                Busca = Busca + " WHERE";
            }
            if (cbGrupo.Text != "")
            {
                Busca = Busca + " grupo_produto like '%" + cbGrupo.Text + "%'";
                QuantFiltros = QuantFiltros+1;
            }
                       

            if(txtNome.Text != "")
            {

                if(QuantFiltros > 0)
                {
                    Busca = Busca + " and";
                }
                Busca = Busca + " nome_produto like '%" + txtNome.Text + "%'";
                QuantFiltros = QuantFiltros + 1;
            }

            if (txtMarca.Text != "")
            {

                if (QuantFiltros > 0)
                {
                    Busca = Busca + " and";
                }

                Busca = Busca + " marca_produto like '%" + txtMarca.Text + "%'";
                QuantFiltros = QuantFiltros + 1;
            }

            if (txtModelo.Text != "")
            {

                if (QuantFiltros > 0)
                {
                    Busca = Busca + " and";
                }

                Busca = Busca + " modelo_produto like '%" + txtModelo.Text + "%'";
                QuantFiltros = QuantFiltros + 1;
            }

            if (cbAtivos.Checked == true)
            {

                if (QuantFiltros > 0)
                {
                    Busca = Busca + " and";
                }

                Busca = Busca + " ativo_produto = 1";
                QuantFiltros = QuantFiltros + 1;
            }

            

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLProduto bll = new BLLProduto(cx);

            dgvProduto.DataSource = bll.ConsultaProduto(Busca);
            
        }

        private void frmConsultaProduto_Load(object sender, EventArgs e)
        {
            cbAtivos.Checked = true;
            btLocalizar_Click(sender,e);

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLGrupo bll = new BLLGrupo(cx);
            cbGrupo.DataSource = bll.Localizar("");
            cbGrupo.DisplayMember = "nome_grupo";
            cbGrupo.ValueMember = "nome_grupo";
            cbGrupo.Text = "";

            dgvProduto.Columns[0].Visible = false;
            dgvProduto.Columns[2].Visible = false;
            dgvProduto.Columns[3].Visible = false;

            dgvProduto.Columns[1].HeaderText = "NOME";
            dgvProduto.Columns[1].Width = 150;
            
            dgvProduto.Columns[4].HeaderText = "GRUPO";
            dgvProduto.Columns[4].Width = 150;
            dgvProduto.Columns[5].HeaderText = "MARCA";
            dgvProduto.Columns[5].Width = 150;
            dgvProduto.Columns[6].HeaderText = "MODELO";
            dgvProduto.Columns[6].Width = 150;
            dgvProduto.Columns[7].HeaderText = "DESCRIÇÃO";
            dgvProduto.Columns[7].Width = 250;
            dgvProduto.Columns[8].HeaderText = "FOTO";
            dgvProduto.Columns[8].Width = 50;
            dgvProduto.Columns[9].HeaderText = "ATIVO";
            dgvProduto.Columns[9].Width = 50;
           
            
        }

        private void dgvProduto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.codigo = Convert.ToInt32(dgvProduto.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }

        

    }
}
