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
    public partial class frmConsultaFornecedor : Form
    {
        public int codigo = 0;
        int idUsuario;
        public frmConsultaFornecedor(int usuario)
        {
            idUsuario = usuario;

            InitializeComponent();
        }

        private void btConsulta_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLFornecedor bll = new BLLFornecedor(cx);

            if (rdFantasia.Checked)
            {
                dgvDados.DataSource = bll.LocalizarFantasia(txtConsulta.Text);
            }
            else
            {
                dgvDados.DataSource = bll.LocalizarRazao(txtConsulta.Text);
            }


        }

        private void frmConsultaFornecedor_Load(object sender, EventArgs e)
        {


            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(idUsuario);

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";


            btConsulta_Click(sender, e);
            dgvDados.Columns[0].Visible = false;
            dgvDados.Columns[3].Visible = false;
            dgvDados.Columns[4].Visible = false;
            dgvDados.Columns[5].Visible = false;
            dgvDados.Columns[6].Visible = false;
           

            dgvDados.Columns[1].HeaderText = "FANTASIA";
            dgvDados.Columns[1].Width = 150;
            dgvDados.Columns[2].HeaderText = "RAZÃO SOCIAL";
            dgvDados.Columns[2].Width = 150;
            dgvDados.Columns[7].HeaderText = "LOGRADOURO";
            dgvDados.Columns[7].Width = 150;
            dgvDados.Columns[8].HeaderText = "NÚMERO";
            dgvDados.Columns[8].Width = 50;
            dgvDados.Columns[9].HeaderText = "COMPLEMENTO";
            dgvDados.Columns[9].Width = 150;
            dgvDados.Columns[10].HeaderText = "BAIRRO";
            dgvDados.Columns[10].Width = 150;
            dgvDados.Columns[11].HeaderText = "CIDADE";
            dgvDados.Columns[11].Width = 150;
            dgvDados.Columns[12].HeaderText = "ESTADO";
            dgvDados.Columns[12].Width = 50;
            dgvDados.Columns[13].HeaderText = "CEP";
            dgvDados.Columns[13].Width = 80;
            dgvDados.Columns[14].HeaderText = "CONTATO";
            dgvDados.Columns[14].Width = 90;
            dgvDados.Columns[15].HeaderText = "CNPJ";
            dgvDados.Columns[15].Width = 120;

        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0)
            {
                this.codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
