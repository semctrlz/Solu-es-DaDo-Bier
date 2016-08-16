using GUI.Code.DAL;
using GUI.Code.BLL;
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
    public partial class frmConexoes : Form
    {
        int idUsuario;
        public frmConexoes(int id)
        {
            idUsuario = id;
            InitializeComponent();
        }

        private void frmConexoes_Load(object sender, EventArgs e)
        {

            CaregaDGV();
        }

        private void dgvConexoes_SelectionChanged(object sender, EventArgs e)
        {
            dgvConexoes.ClearSelection();
        }

        private void CaregaDGV()
        {
            dgvConexoes.Rows.Clear();
            lbConexaoAtual.Text = "Local: ";

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(cx);

            DataTable tabela = bllu.ListarConexoes(idUsuario);

            lbConexaoAtual.Text += bllu.IpLocal();

            if (tabela.Rows.Count > 0)
            {
                for (int i = 0; i < tabela.Rows.Count; i++)
                {
                    string ip = Convert.ToString(tabela.Rows[i][0]);

                    String[] C = new string[] { ip };
                    this.dgvConexoes.Rows.Add(C);
                }
            }

        }

        private void dgvConexoes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {

               
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLLog blllog = new BLLLog(cx);
                blllog.excluir(idUsuario, dgvConexoes.Rows[e.RowIndex].Cells[0].Value.ToString());

                CaregaDGV();

            }
        }
    }
}
