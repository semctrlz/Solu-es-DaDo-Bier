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
    public partial class frmItens : Form
    {
        int unidade;
        DateTime diaI, diaF;
        string titulo, subtitulo, conta;

        public frmItens(int un, DateTime i, DateTime f, string g, string t, string s)
        {
            unidade = un;
            diaI = i;
            diaF = f;
            conta = g;
            titulo = t;
            subtitulo = s;


            InitializeComponent();
        }

        private void frmItens_Load(object sender, EventArgs e)
        {
            string data = "";

            if (diaI == diaF)
            {
                data = diaI.ToString("d");
            }
            else
            {

                switch (diaI.Month)
                {
                    case 1:
                        data = "Janeiro";
                        break;
                    case 2:
                        data = "Fevereiro";
                        break;
                    case 3:
                        data = "Março";
                        break;
                    case 4:
                        data = "Abril";
                        break;
                    case 5:
                        data = "Maio";
                        break;
                    case 6:
                        data = "Junho";
                        break;
                    case 7:
                        data = "Julho";
                        break;
                    case 8:
                        data = "Agosto";
                        break;
                    case 9:
                        data = "Setembro";
                        break;
                    case 10:
                        data = "Outubro";
                        break;
                    case 11:
                        data = "Novembro";
                        break;
                    case 12:
                        data = "Dezembro";
                        break;
                }
               
            }

            lbTitulo.Text = titulo + " - "+data+"\n" + subtitulo;
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLCmvGraficos bll = new BLLCmvGraficos(cx);

            dgvItens.DataSource = bll.TabelaItensPorConta(unidade, diaI, diaF, conta);



            dgvItens.Columns[0].HeaderText = "Data";
            dgvItens.Columns[0].Width = 80;

            dgvItens.Columns[1].HeaderText = "Codigo";
            dgvItens.Columns[1].Width = 90;

            dgvItens.Columns[2].HeaderText = "Nome";
            dgvItens.Columns[2].Width = 300;

            dgvItens.Columns[3].HeaderText = "Quant.";
            dgvItens.Columns[3].Width = 80;

            dgvItens.Columns[4].HeaderText = "Valor Unit.";
            dgvItens.Columns[4].Width = 90;

            dgvItens.Columns[5].HeaderText = "Valor Total";
            dgvItens.Columns[5].Width = 100;

            dgvItens.Columns[6].HeaderText = "Movimento";
            dgvItens.Columns[6].Width = 90;

            dgvItens.Columns[7].HeaderText = "Requisição";
            dgvItens.Columns[7].Width = 90;



        }
    }
}
