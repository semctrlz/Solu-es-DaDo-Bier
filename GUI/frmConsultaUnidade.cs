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

namespace GUI
{
    
    public partial class frmConsultaUnidade : Form
    {
        public int codigo = 0;
        public frmConsultaUnidade()
        {
            InitializeComponent();
        }

        private void frmConsultaUnidade_Load(object sender, EventArgs e)
        {
            this.CarregaBanco();
            

        }

        private void dgvUnidade_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.codigo = Convert.ToInt32(dgvUnidade.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
            this.Close();
            
        }

        private void CarregaBanco()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUnidade bll = new BLLUnidade(cx);

            dgvUnidade.DataSource = bll.Localizar("");


            foreach (DataGridViewRow row in dgvUnidade.Rows)
            {
                row.Height = 30;
            }


            dgvUnidade.Columns[0].Visible = false;

            dgvUnidade.Columns[1].HeaderText = "NOME";
            dgvUnidade.Columns[1].Width = 105;

            dgvUnidade.Columns[2].HeaderText = "UNIDADE";
            dgvUnidade.Columns[2].Width = 100;

            
        }

    }
}
