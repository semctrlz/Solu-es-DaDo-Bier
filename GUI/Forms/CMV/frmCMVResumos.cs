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

namespace GUI.Forms.CMV
{
    public partial class frmCMVResumos : Form
    {
        int idUsuario, unidade, mes;
        bool atualizarCusto, custoselected;
        string mesAtual;
        

        public frmCMVResumos(int id)
        {
            idUsuario = id;
            InitializeComponent();
        }

        private void dgvCusto_Enter(object sender, EventArgs e)
        {
            CarregaResumoCusto();
        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            atualizarCusto = true;            

            if (custoselected)
            {
                CarregaResumoCusto();
            }else
            {
                CarregaResumoReceita();
            }
            
        }

        private void tabCusto_Enter(object sender, EventArgs e)
        {
            custoselected = true;
            CarregaResumoCusto();
        }

        private void tabReceita_Enter(object sender, EventArgs e)
        {
            custoselected = false;
            CarregaResumoReceita();
        }

        private void frmCMVResumos_Load(object sender, EventArgs e)
        {
            DefaultValues();
        }

        private void DefaultValues()
        {
            custoselected = true;
            atualizarCusto = true;            

            numAno.Value = DateTime.Now.Year;
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(Convert.ToInt32(idUsuario));

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";
            
            BLLUnidade bllun = new BLLUnidade(con);
            cbUnidade.DataSource = bllun.Localizar("");
            cbUnidade.DisplayMember = "cod_unidade";
            cbUnidade.ValueMember = "id_unidade";
            cbUnidade.Text = modelou.IdUnidade.ToString();

            unidade = modelou.IdUnidade;


            if (modelou.PermissaoUsuario < 4)
            {

                cbUnidade.Enabled = false;
            }


            mes = Convert.ToInt32(DateTime.Now.Month);

            #region Case Mês

            switch (mes)
            {
                case 1:
                    mesAtual = "Janeiro";
                    break;
                case 2:
                    mesAtual = "Fevereiro";
                    break;
                case 3:
                    mesAtual = "Março";
                    break;
                case 4:
                    mesAtual = "Abril";
                    break;
                case 5:
                    mesAtual = "Maio";
                    break;
                case 6:
                    mesAtual = "Junho";
                    break;
                case 7:
                    mesAtual = "Julho";
                    break;
                case 8:
                    mesAtual = "Agosto";
                    break;
                case 9:
                    mesAtual = "Setembro";
                    break;
                case 10:
                    mesAtual = "Outubro";
                    break;
                case 11:
                    mesAtual = "Novembro";
                    break;
                case 12:
                    mesAtual = "Dezembro";
                    break;
                default:
                    mesAtual = "";
                    break;
            }

            #endregion


            cbMes.Text = mesAtual;
        }

        private void dgvCusto_SelectionChanged(object sender, EventArgs e)
        {
            dgvCusto.ClearSelection();
        }

        private int mestoint(String mes)
        {
            int mesatual = 0;

            switch (mes)
            {
                case "Janeiro":
                    mesatual = 1;
                    break;
                case "Fevereiro":
                    mesatual = 2;
                    break;
                case "Março":
                    mesatual = 3;
                    break;
                case "Abril":
                    mesatual = 4;
                    break;
                case "Maio":
                    mesatual = 5;
                    break;
                case "Junho":
                    mesatual = 6;
                    break;
                case "Julho":
                    mesatual = 7;
                    break;
                case "Agosto":
                    mesatual = 8;
                    break;
                case "Setembro":
                    mesatual = 9;
                    break;
                case "Outubro":
                    mesatual = 10;
                    break;
                case "Novembro":
                    mesatual = 11;
                    break;
                case "Dezembro":
                    mesatual = 12;
                    break;
                default:
                    mesatual = 0;
                    break;
            }

            return mesatual;
        }

        private string semana(int dia)
        {
           string diaSemana = "";

            switch (dia)
            {
                case 0:
                    diaSemana = "D";
                    break;
                case 1:
                    diaSemana = "S";
                    break;
                case 2:
                    diaSemana = "T";
                    break;
                case 3:
                    diaSemana = "Q";
                    break;
                case 4:
                    diaSemana = "Q";
                    break;
                case 5:
                    diaSemana = "S";
                    break;
                case 6:
                    diaSemana = "S";
                    break;
                
            }

            return diaSemana;
        }


        private void CarregaResumoCusto()
        {           


            if (atualizarCusto)
            {

                Comuns.loading ld = new Comuns.loading();
                ld.SetMessage("CARREGANDO CUSTOS...\n Por favor, aguarde."); // "Loading data. Please wait..."
                ld.TopMost = true;
                ld.StartPosition = FormStartPosition.CenterScreen;
                ld.WindowState = FormWindowState.Normal;

                ld.Show();
                ld.Refresh();

                try
                {

                    DataTable custo = new DataTable();

                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLCmvGraficos bll = new BLLCmvGraficos(cx);
                    DataTable contas = bll.ListaSetoresCadastradosPorUnidade(unidade);
                    DataTable custoDia;

                    custo.Columns.Add("DATA", typeof(string));

                    DateTime Diai = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(mestoint(cbMes.Text)), 1);

                    DateTime Diaf = Diai.AddDays(-(Diai.Day - 1)).AddMonths(1).AddDays(-1);

                    int dias = Diaf.Day;

                    for (int i = 0; i < contas.Rows.Count; i++)
                    {
                        custo.Columns.Add(contas.Rows[i][1].ToString(), typeof(string));
                    }

                    for (int i = 0; i < dias; i++)
                    {
                        custo.Rows.Add();
                    }

                    //Roda cada uma das linhas e coloca data

                    for (int i = 0; i < dias; i++)
                    {
                        DateTime dia = new DateTime(Convert.ToInt32(numAno.Value), mestoint(cbMes.Text), i + 1);
                        custo.Rows[i]["DATA"] = dia.ToString("d") + " - " + semana((int)dia.DayOfWeek);
                    }

                    string valor = "";

                    for (int i = 0; i < contas.Rows.Count; i++)
                    {
                        custoDia = bll.TotalCustoPorContaEData(unidade, Diai, Diaf, contas.Rows[i][0].ToString());
                       
                        DateTime diaCusto = Diai;
                        //Adiciona o valor das na tabela

                        for (int g = 0; g < dias; g++)
                        {
                            try
                            {
                                if (Convert.ToDateTime(custoDia.Rows[g][0]) == diaCusto)
                                {
                                    valor = Convert.ToDouble(custoDia.Rows[g][1]).ToString("#,0.00");
                                }
                                else
                                {
                                    valor = "-";
                                }


                            }
                            catch
                            {
                                valor = "-";
                            }
                            finally
                            {
                                custo.Rows[g][i + 2] = valor;

                                diaCusto.AddDays(1);
                            }
                        }

                    }

                    dgvCusto.DataSource = custo;
                    atualizarCusto = false;

                }
                catch
                {

                }
                finally
                {
                    ld.Close();
                }             



            }

        }

        private void CarregaResumoReceita()
        {

        }
    }
}
