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
    public partial class frmDetalheGrafico : Form
    {
        int dia, grupo, unidade;
        string titulo, diaDaSemana;
        DateTime diaI, diaF;

        public frmDetalheGrafico(int d, string t, int g, DateTime di, DateTime df, int un)
        {
            dia = d;
            titulo = t;
            grupo = g;
            diaI = di;
            diaF = df;
            unidade = un;
           
            InitializeComponent();
        }

        private void frmDetalheGrafico_Load(object sender, EventArgs e)
        {
            this.Text += " - "+titulo;

            if(diaI == diaF)
            {

                switch ((int) diaI.DayOfWeek)
                {
                    case 1:
                        diaDaSemana =" - Segunda";
                        break;
                    case 2:
                        diaDaSemana =" - Terça";
                        break;
                    case 3:
                        diaDaSemana =" - Quarta";
                        break;
                    case 4:
                        diaDaSemana =" - Quinta";
                        break;
                    case 5:
                        diaDaSemana =" - Sexta";
                        break;
                    case 6:
                        diaDaSemana =" - Sábado";
                        break;
                    case 0:
                        diaDaSemana =" - Domingo";
                        break;                    
                }
                titulo += diaDaSemana;
            }


            label1.Text = titulo;

            AtualizaDGV();
            formataDGV();
        }

        private void Sair()
        {
            this.Close();
        }

        private void dgvDetalhe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvDetalhe.Rows[e.RowIndex].Cells[0].Value);


            if (e.ColumnIndex == 5)
            {
                if (e.RowIndex >= 0)
                {

                    titulo = dgvDetalhe.Rows[e.RowIndex].Cells[1].Value.ToString();

                    frmItens f = new frmItens(unidade, diaI, diaF, id, titulo, lbReceitaePax.Text);
                    f.ShowDialog();
                    f.Dispose();
                }
            }
        }

        private void dgvDetalhe_SelectionChanged(object sender, EventArgs e)
        {
            dgvDetalhe.ClearSelection();
        }

        private void AtualizaDGV()
        {
            string conta, id;
            double custo, valor, percent;
            String[] T = new string[] { "-1", "CONTA GERENCIAL", "CUSTO", "$", "%" };
            this.dgvDetalhe.Rows.Add(T);

            String[] V;


            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLCmvGraficos bll = new BLLCmvGraficos(cx);

            DataTable TABELAC = bll.TabelaCustoPorConta(unidade, diaI, diaF, grupo);
            DataTable TABELAR = bll.TotalReceitaPorGrupo(unidade, diaI, diaF, grupo);
            DataTable TABELACT = bll.TotalCustoPorGrupo(unidade, diaI, diaF, grupo);

            if (TABELAC.Rows.Count > 0)
            {

                for (int i = 0; i < TABELAC.Rows.Count; i++)
                {
                    try
                    {
                        id = TABELAC.Rows[i][0].ToString();
                    }
                    catch
                    {
                        id = 0.ToString();
                    }
                    try
                    {
                        conta = TABELAC.Rows[i][1].ToString();
                    }
                    catch
                    {
                        conta = 0.ToString();
                    }
                    try
                    {
                        custo = Convert.ToDouble(TABELAC.Rows[i][2]);
                    }
                    catch
                    {
                        custo = 0;
                    }
                    try
                    {
                        valor = (custo * -1) / Convert.ToDouble(TABELAR.Rows[0][1]);
                    }
                    catch
                    {
                        valor = 0;
                    }
                    try
                    {
                        percent = ((custo * -1) / Convert.ToDouble(TABELAR.Rows[0][2])) * 100;
                    }
                    catch
                    {
                        percent = 0;
                    }

                    V = new string[] { id, conta, custo.ToString("#,0.00"), valor.ToString("#,0.00"), percent.ToString("#,0.00")+"%" };
                    this.dgvDetalhe.Rows.Add(V);
                    
                }

                V = new string[] { "0", "", "", "", "" };
                this.dgvDetalhe.Rows.Add(V);
                
                custo = Convert.ToDouble(TABELACT.Rows[0][0]);
                valor = (custo *-1)/ Convert.ToDouble(TABELAR.Rows[0][1]);
                percent = ((custo*-1) / Convert.ToDouble(TABELAR.Rows[0][2])) * 100;

                V = new string[] { "-1", "TOTAL", custo.ToString("#,0.00"), valor.ToString("#,0.00"), percent.ToString("#,0.00") + "%" };
                this.dgvDetalhe.Rows.Add(V);

                lbReceitaePax.Text = TABELAR.Rows[0][1].ToString() + " clientes atendidos. Receita total R$ " + Convert.ToDouble(TABELAR.Rows[0][2]).ToString("#,0.00");

            }

        }

        private void formataDGV()
        {

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(dgvDetalhe.Font, FontStyle.Bold);

            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            style2.Font = new Font(dgvDetalhe.Font, FontStyle.Bold);

            dgvDetalhe.Rows[1].DataGridView.GridColor = Color.Black;
            for (int i = 0; i < dgvDetalhe.Rows.Count; i++)
            {


                if (dgvDetalhe.Rows[i].Cells[0].Value.ToString() == "-2")
                {

                    dgvDetalhe.Rows[i].DefaultCellStyle = style;
                    dgvDetalhe.Rows[i].DefaultCellStyle.BackColor = Color.Black;
                    dgvDetalhe.Rows[i].DataGridView.ForeColor = Color.White;
                }


                if (dgvDetalhe.Rows[i].Cells[0].Value.ToString() == "-1")
                {
                    dgvDetalhe.Rows[i].DefaultCellStyle = style2;
                    dgvDetalhe.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                    dgvDetalhe.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }


                if (dgvDetalhe.Rows[i].Cells[0].Value.ToString() == "0")
                {
                    dgvDetalhe.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    dgvDetalhe.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                }


                if (Convert.ToInt32(dgvDetalhe.Rows[i].Cells[0].Value) > 0)
                {

                    dgvDetalhe.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    this.dgvDetalhe.RowsDefaultCellStyle.BackColor = Color.White;


                }

                if (Convert.ToInt32(dgvDetalhe.Rows[i].Cells[0].Value) <= 0)
                {
                    dgvDetalhe.Rows[i].Cells[5].Value = new System.Drawing.Bitmap(1, 1);
                }
            }           

        }
        
        private void frmDetalheGrafico_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
