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
        bool geral;

        public frmDetalheGrafico(int d, string t, int g, DateTime di, DateTime df, int un, bool gr, bool setor)
        {
            dia = d;
            titulo = t;
            grupo = g;
            diaI = di;
            diaF = df;
            unidade = un;
            geral = gr;            
           
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
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                try
                {
                    string conta = (dgvDetalhe.Rows[e.RowIndex].Cells[1].Value).ToString().Substring(0, 10);

                    titulo = dgvDetalhe.Rows[e.RowIndex].Cells[1].Value.ToString();

                    frmItens f = new frmItens(unidade, diaI, diaF, conta, titulo, lbReceitaePax.Text, false, false);
                    f.ShowDialog();
                    f.Dispose();
                }
                catch
                {

                }
            }

            if (e.ColumnIndex == 6 && e.RowIndex >= 0)
            {
                try
                {
                    if (dgvDetalhe.Rows[e.RowIndex].Cells[1].Value.ToString() == "TOTAL")
                    {
                        string conta = "Total";

                        titulo = "ABC Total";

                        frmItens f = new frmItens(unidade, diaI, diaF, conta, titulo, lbReceitaePax.Text, true, false);
                        f.ShowDialog();
                        f.Dispose();
                    }
                    else
                    {
                        string conta = (dgvDetalhe.Rows[e.RowIndex].Cells[1].Value).ToString().Substring(0, 10);

                        titulo = "ABC - " + dgvDetalhe.Rows[e.RowIndex].Cells[1].Value.ToString();

                        frmItens f = new frmItens(unidade, diaI, diaF, conta, titulo, lbReceitaePax.Text, true, true);
                        f.ShowDialog();
                        f.Dispose();
                    }
                   
                }
                catch
                {

                }
            }
        }

        private void dgvDetalhe_SelectionChanged(object sender, EventArgs e)
        {
            dgvDetalhe.ClearSelection();
        }

        private void AtualizaDGV()
        {
           String[] T = new string[] { "-1", "CONTA GERENCIAL", "CUSTO", "$", "%"};
            this.dgvDetalhe.Rows.Add(T);

            String[] V;
            int grupoCusto = 01;
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLCmvGraficos bll = new BLLCmvGraficos(cx);
            BLLConsultaCMV bllc = new BLLConsultaCMV(cx);

            DataTable TABELA;
            if (geral)
            {
                TABELA = bll.TabelaCustoCMVReceitaPaxGeral(unidade, diaI, diaF, grupoCusto);
            }
            else
            {
                TABELA = bll.TabelaCustoCMVReceitaPaxPorGrupo(unidade, diaI, diaF, grupo, grupoCusto);

            }

            if (TABELA.Rows.Count > 0)
            {

                for (int i = 0; i < TABELA.Rows.Count; i++)
                {
                    V = new string[] { TABELA.Rows[i][0].ToString(), TABELA.Rows[i][1].ToString(), Convert.ToDouble(TABELA.Rows[i][2]).ToString("#,0.00"), Convert.ToDouble(TABELA.Rows[i][3]).ToString("#,0.00"), Convert.ToDouble(TABELA.Rows[i][4]).ToString("#,0.00") + "%" };
                    this.dgvDetalhe.Rows.Add(V);
                }
            }
            else
            {

            }
            V = new string[] { "0", "", "", "", "" };
            this.dgvDetalhe.Rows.Add(V);

            if (TABELA.Rows.Count > 0)
            {
                V = new string[] { "-1", "TOTAL", Convert.ToDouble(TABELA.Rows[0][5]).ToString("#,0.00"), (Convert.ToDouble(TABELA.Rows[0][5])/Convert.ToDouble(TABELA.Rows[0][7])).ToString("#,0.00"), ((Convert.ToDouble(TABELA.Rows[0][5]) / Convert.ToDouble(TABELA.Rows[0][6]))*100).ToString("#,0.00") + "%" };
                this.dgvDetalhe.Rows.Add(V);
            }


            lbReceitaePax.Text = $"Total Pax = {Convert.ToDouble(TABELA.Rows[0][7]).ToString("#,0")} - total receita = R$ {Convert.ToDouble(TABELA.Rows[0][6]).ToString("#,0.00")}";
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
                    dgvDetalhe.Rows[i].Cells[6].Value = new System.Drawing.Bitmap(1, 1);
                    dgvDetalhe.Rows[i].Cells[5].Value = new System.Drawing.Bitmap(1, 1);

                }


                if (Convert.ToInt32(dgvDetalhe.Rows[i].Cells[0].Value.ToString().Length) == 10)
                {

                    dgvDetalhe.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    this.dgvDetalhe.RowsDefaultCellStyle.BackColor = Color.White;


                }
                
                if (dgvDetalhe.Rows[i].Cells[0].Value.ToString() == "-1" && dgvDetalhe.Rows[i].Cells[1].Value.ToString() != "TOTAL")
                {
                    dgvDetalhe.Rows[i].Cells[6].Value = new System.Drawing.Bitmap(1, 1);
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
