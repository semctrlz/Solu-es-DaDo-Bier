using GUI.Code.BLL;
using GUI.Code.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Forms.CMV
{
    public partial class frmConsultaAeB : Form
    {
        bool retorno = false;
        public string codigo = "";
        int linha = 0;
        public frmConsultaAeB(bool ret)
        {
            retorno = ret;
            InitializeComponent();
                       
        }

        private void frmConsultaAeB_Load(object sender, EventArgs e)
        {
            AtualizaDgv();
            dgvItens.Columns[0].HeaderText = "CODIGO";
            dgvItens.Columns[0].Width = 80;

            dgvItens.Columns[1].HeaderText = "NOME";
            dgvItens.Columns[1].Width = 400;

            dgvItens.Columns[2].HeaderText = "U.M.";
            dgvItens.Columns[2].Width = 50;

            dgvItens.Columns[3].HeaderText = "F.C";
            dgvItens.Columns[3].Width = 80;
            
            txtNome.Focus();
        }

        private void AtualizaDgv()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLAeB bll = new BLLAeB(cx);
            
            dgvItens.DataSource = bll.LocalizarNome(txtNome.Text.Trim());
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            AtualizaDgv();
            linha = 0;
        }

        private void dgvItens_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && retorno)
            {
                this.codigo = dgvItens.Rows[e.RowIndex].Cells[0].ToString();
                this.Close();
            }
        }

        private void frmConsultaAeB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if ((linha+1) < dgvItens.Rows.Count)
                {
                    linha++;
                    AtualizaSelecao();
                }

            }

            if (e.KeyCode == Keys.Up)
            {
                if (linha > 0)
                {
                    linha--;
                    AtualizaSelecao();
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (dgvItens.Rows.Count > 0)
                {
                    codigo = dgvItens.Rows[linha].Cells[0].Value.ToString();
                }
                else
                {
                    codigo = "";
                }
                this.Close();
            }
            if (e.KeyCode == Keys.Escape)
            {
                codigo = "";

                this.Close();
            }
        }

        private void AtualizaSelecao()
        {
            dgvItens.Rows[linha].Selected = true;
        }

        private void dgvItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                linha = e.RowIndex;
            }
        }
    }
}
