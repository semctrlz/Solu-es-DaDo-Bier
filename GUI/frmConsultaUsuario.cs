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
    public partial class frmConsultaUsuario : Form
    {

        public int codigo = 0;
        public frmConsultaUsuario()
        {
            InitializeComponent();
        }

        private void frmConsultaUsuario_Load(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bll = new BLLUsuario(cx);

            dgvUsuario.DataSource = bll.Localizar("");


            dgvUsuario.RowHeadersVisible = false;
            dgvUsuario.AllowUserToResizeColumns = false;



            foreach (DataGridViewRow row in dgvUsuario.Rows)
            {
                row.Height = 20;
            }


            dgvUsuario.Columns[0].Visible = false;

            dgvUsuario.Columns[1].HeaderText = "NOME";
            dgvUsuario.Columns[1].Width = 200;

            dgvUsuario.Columns[2].HeaderText = "LOGIN";
            dgvUsuario.Columns[2].Width = 100;

            dgvUsuario.Columns[3].HeaderText = "SENHA";
            dgvUsuario.Columns[3].Width = 100;

            dgvUsuario.Columns[4].HeaderText = "INICIAIS";
            dgvUsuario.Columns[4].Width = 100;

            dgvUsuario.Columns[5].HeaderText = "UNI.";
            dgvUsuario.Columns[5].Width = 50;

            dgvUsuario.Columns[6].HeaderText = "NV";
            dgvUsuario.Columns[6].Width = 50;
        }

        private void dgvUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.codigo = Convert.ToInt32(dgvUsuario.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
            this.Close();
        }
    }
}
