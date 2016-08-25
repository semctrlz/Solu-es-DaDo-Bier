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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI.Forms.CMV
{
    public partial class frmSinteticoPorGrupo : Form
    {
        int unidade, idUsuario, pontoAtual;
        bool liberado = false;
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();

        public frmSinteticoPorGrupo(int id)
        {
            idUsuario = id;
            InitializeComponent();
        }

        public class Language
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public string Name1 { get; set; }
            public string Value1 { get; set; }
            public string Name2 { get; set; }
            public string Value2 { get; set; }
            public string Name3 { get; set; }
            public string Value3 { get; set; }
            public string Name4 { get; set; }
            public string Value4 { get; set; }
            public string Name5 { get; set; }
            public string Value5 { get; set; }
        }

        private void frmSinteticoPorGrupo_Load(object sender, EventArgs e)
        {
            
            
            Comuns.loading ld = new Comuns.loading();
            ld.SetMessage("CARREGANDO...\n Por favor, aguarde."); // "Loading data. Please wait..."
            ld.TopMost = true;
            ld.StartPosition = FormStartPosition.CenterScreen;
            ld.WindowState = FormWindowState.Maximized;
            
            ld.Show();
            ld.Refresh();

    

            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(Convert.ToInt32(idUsuario));

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";

            DafaultValues();
            ld.Close();

        }

        private void DafaultValues()
        {
            liberado = false;

            CarregaMes();
            DateTime data = DateTime.Today;

            numAno.Value = data.Year;
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUnidade bllun = new BLLUnidade(con);
            BLLUsuario bllu = new BLLUsuario(con);
            DTOUsuario modelou = bllu.CarregaModeloUsuario(Convert.ToInt32(idUsuario));

            cbUnidade.DataSource = bllun.ListarUnidades();
            cbUnidade.DisplayMember = "cod_unidade";
            cbUnidade.ValueMember = "id_unidade";
            cbUnidade.Text = modelou.IdUnidade.ToString();

            if (modelou.PermissaoUsuario < 4)
            {
                cbUnidade.Enabled = false;
            }

            unidade = Convert.ToInt32(cbUnidade.SelectedValue);

            CarregaCbGrupos();

            rdValor.Checked = true;
            rdPercent.Checked = false;

            liberado = true;

            AtualizaChart01();
            AtualizaChart02();
            AtualizaChart03();

            if(cbGrupo01.Text != "" || cbGrupo02.Text != "" || cbGrupo03.Text != "" || cbGrupo04.Text != "" || cbGrupo02.Text != "")
            {
                AtualizaChart04();
                AtualizaChart05();
            }

            lbG1.Text = cbGrupo01.Text;
            lbG2.Text = cbGrupo02.Text;
            lbG3.Text = cbGrupo03.Text;            
        }

        private void CarregaMes()
        {

            DateTime data = DateTime.Today;
            int mesAtual = data.Month;

            var dataSource = new List<Language>();
            dataSource.Add(new Language() { Name = "Janeiro", Value = "1" });
            dataSource.Add(new Language() { Name = "Fevereiro", Value = "2" });
            dataSource.Add(new Language() { Name = "Março", Value = "3" });
            dataSource.Add(new Language() { Name = "Abril", Value = "4" });
            dataSource.Add(new Language() { Name = "Maio", Value = "5" });
            dataSource.Add(new Language() { Name = "Junho", Value = "6" });
            dataSource.Add(new Language() { Name = "Julho", Value = "7" });
            dataSource.Add(new Language() { Name = "Agosto", Value = "8" });
            dataSource.Add(new Language() { Name = "Setembro", Value = "9" });
            dataSource.Add(new Language() { Name = "Outubro", Value = "10" });
            dataSource.Add(new Language() { Name = "Novembro", Value = "11" });
            dataSource.Add(new Language() { Name = "Dezembro", Value = "12" });

            //Adicionar ao ComboBox
            this.cbMes.DataSource = dataSource;
            this.cbMes.DisplayMember = "Name";
            this.cbMes.ValueMember = "Value";
            this.cbMes.SelectedIndex = mesAtual - 1;

        }

        private void cbGrupo01_SelectedIndexChanged(object sender, EventArgs e)
        {

            lbG1.Text = cbGrupo01.Text;
            if (liberado)
            {
            AtualizaChart01();
            AtualizaChart04();
            AtualizaChart05();
                SalvarConfigs(1);
            }
        }

        private void cbGrupo02_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbG2.Text = cbGrupo02.Text;
            if (liberado)
            {
            AtualizaChart02();
            AtualizaChart04();
            AtualizaChart05();

                SalvarConfigs(2);
            }
        }

        private void cbGrupo03_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbG3.Text = cbGrupo03.Text;

            if (liberado)
            {
            AtualizaChart03();
            AtualizaChart04();
            AtualizaChart05();
                SalvarConfigs(3);
            }
        }

        private void cbGrupo04_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liberado)
            {
                AtualizaChart04();
                AtualizaChart05();

                SalvarConfigs(4);
            }
        }

        private void cbGrupo05_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liberado)
            {
                AtualizaChart04();
                AtualizaChart05();

                SalvarConfigs(5);
            }
        }

        private void CarregaCbGrupos()
        {

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLCmvGrupo bllg = new BLLCmvGrupo(cx);
            DataTable tabela = bllg.LocalizarGrupo(unidade);

            var dataSource1 = new List<Language>();
            dataSource1.Add(new Language() { Name1 = "", Value1 = "0" });
            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                dataSource1.Add(new Language() { Name1 = tabela.Rows[i][1].ToString(), Value1 = Convert.ToInt32(tabela.Rows[i][0]).ToString() });
            }
            var dataSource2 = new List<Language>();
            dataSource2.Add(new Language() { Name2 = "", Value2 = "0" });

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                dataSource2.Add(new Language() { Name2 = tabela.Rows[i][1].ToString(), Value2 = Convert.ToInt32(tabela.Rows[i][0]).ToString() });
            }
            var dataSource3 = new List<Language>();
            dataSource3.Add(new Language() { Name3 = "", Value3 = "0" });

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                dataSource3.Add(new Language() { Name3 = tabela.Rows[i][1].ToString(), Value3 = Convert.ToInt32(tabela.Rows[i][0]).ToString() });
            }
            var dataSource4 = new List<Language>();
            dataSource4.Add(new Language() { Name4 = "", Value4 = "0" });

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                dataSource4.Add(new Language() { Name4 = tabela.Rows[i][1].ToString(), Value4 = Convert.ToInt32(tabela.Rows[i][0]).ToString() });
            }
            var dataSource5 = new List<Language>();
            dataSource5.Add(new Language() { Name5 = "", Value5 = "0" });

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                dataSource5.Add(new Language() { Name5 = tabela.Rows[i][1].ToString(), Value5 = Convert.ToInt32(tabela.Rows[i][0]).ToString() });
            }
            liberado = false;
            //Atualiza grupo 01
            this.cbGrupo01.DataSource = dataSource1;
            this.cbGrupo01.DisplayMember = "Name1";
            this.cbGrupo01.ValueMember = "Value1";            

            //Atualiza grupo 02
            this.cbGrupo02.DataSource = dataSource2;
            this.cbGrupo02.DisplayMember = "Name2";
            this.cbGrupo02.ValueMember = "Value2";           

            //Atualiza grupo 03
            this.cbGrupo03.DataSource = dataSource3;
            this.cbGrupo03.DisplayMember = "Name3";
            this.cbGrupo03.ValueMember = "Value3";            

            //Atualiza pizza 04
            this.cbGrupo04.DataSource = dataSource4;
            this.cbGrupo04.DisplayMember = "Name4";
            this.cbGrupo04.ValueMember = "Value4";            

            //Atualiza pizza 05
            this.cbGrupo05.DataSource = dataSource5;
            this.cbGrupo05.DisplayMember = "Name5";
            this.cbGrupo05.ValueMember = "Value5";            

            lbG1.Text = "";
            lbG2.Text = "";
            lbG3.Text = "";
            
            cbGrupo01.Text = "";
            cbGrupo02.Text = "";
            cbGrupo03.Text = "";
            cbGrupo04.Text = "";
            cbGrupo05.Text = "";                       

            CarregarConfigs();

            liberado = true;

            AtualizaCharts();
            
        }

        private void AtualizaCharts()
        {
            if (liberado)
            {

                AtualizaChart01();
                AtualizaChart02();
                AtualizaChart03();
                AtualizaChart04();
                AtualizaChart05();
            }
        }

        private void AtualizaChart01()
        {
            chart0.Series[0].Points.Clear();
            chart0.Series[1].Points.Clear();

            if (liberado && cbGrupo01.Text != "")
            {
                //Variáveis
                double CMV = 0;
                double CUSTO = 0;
                double RECEITA = 0;

                int PAX = 0;
                double meta = 0;
                DataTable tabelaCusto, tabelaReceita, totalCusto, totalReceita, tabelaMeta;
                DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
                DateTime diaF = diaI.AddDays(-(diaI.Day - 1)).AddMonths(1).AddDays(-1);
                DateTime DiaA = diaI;
                int unidade = Convert.ToInt32(cbUnidade.SelectedValue);
                string Diadasemana;
                int c = 0;
                int r = 0;

                //Busca Dados no BD
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLCmvGraficos bll = new BLLCmvGraficos(cx);

                int grupo = Convert.ToInt32(cbGrupo01.SelectedValue.ToString());

                tabelaCusto = bll.TabelaCustoPorGrupo(unidade, diaI, diaF, grupo);
                totalCusto = bll.TotalCustoPorGrupo(unidade, diaI, diaF, grupo);

                tabelaReceita = bll.TabelaReceitaPorGrupo(unidade, diaI, diaF, grupo);
                totalReceita = bll.TotalReceitaPorGrupo(unidade, diaI, diaF, grupo);

                tabelaMeta = bll.MetaPorGrupo(grupo);

                if (rdPercent.Checked)
                {
                    meta = Convert.ToDouble(tabelaMeta.Rows[0][1]);
                }
                else
                {
                    meta = Convert.ToDouble(tabelaMeta.Rows[0][0]);
                }

                for (int i = 0; i < diaF.Day; i++)
                {
                    try
                    {
                        if (Convert.ToDateTime(tabelaCusto.Rows[c][0]) != Convert.ToDateTime(tabelaReceita.Rows[r][0]))
                        {
                            if (Convert.ToDateTime(tabelaCusto.Rows[c][0]) > Convert.ToDateTime(tabelaReceita.Rows[r][0]))
                            {
                                CMV = 0;
                                r++;
                            }
                            else
                            {
                                CMV = 0;
                                c++;
                            }
                        }
                        else
                        {
                            if (Convert.ToDateTime(tabelaCusto.Rows[c][0]) == DiaA)
                            {
                                if (rdPercent.Checked)
                                {
                                    CUSTO = Convert.ToDouble(tabelaCusto.Rows[c][1]) * -1;
                                    RECEITA = Convert.ToDouble(tabelaReceita.Rows[r][3]);

                                    CMV = CUSTO / RECEITA;
                                    CMV = Math.Round(CMV, 4);
                                }
                                else
                                {
                                    CUSTO = Convert.ToDouble(tabelaCusto.Rows[c][1]) * -1;
                                    PAX = Convert.ToInt32(tabelaReceita.Rows[r][2]);

                                    CMV = Math.Round(CUSTO / PAX, 2);
                                }
                                c++;
                                r++;
                            }
                            else
                            {
                                CMV = 0;
                            }
                        }
                    }
                    catch
                    {
                        CMV = 0;
                        r++;
                        c++;
                    }

                    Diadasemana = Dia(DiaA);

                    chart0.Series["Valores"].Points.AddXY(Diadasemana, CMV);

                    chart0.Series["Meta"].Points.AddXY(Diadasemana, meta);

                    DiaA = DiaA.AddDays(1);
                }

                CMV = 0;

                try
                {
                    if (rdPercent.Checked)
                    {
                        CUSTO = Convert.ToDouble(totalCusto.Rows[0][0]) * -1;
                        RECEITA = Convert.ToDouble(totalReceita.Rows[0][2]);

                        CMV = CUSTO / RECEITA;
                        CMV = Math.Round(CMV, 4);
                    }
                    else
                    {
                        CUSTO = Convert.ToDouble(totalCusto.Rows[0][0]) * -1;
                        PAX = Convert.ToInt32(totalReceita.Rows[0][1]);

                        CMV = Math.Round(CUSTO / PAX, 2);
                    }

                }
                catch { }

                chart0.Series["Valores"].Points.AddXY("Total", CMV);
                chart0.Series["Meta"].Points.AddXY("Total", meta);


                if (rdPercent.Checked)
                {
                    chart0.Series["Valores"].LabelFormat = "0.0%";
                }
                else
                {
                    chart0.Series["Valores"].LabelFormat = "0.00";
                }
            }
            else
            {

            }

        }                

        private void AtualizaChart02()
        {
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();

            if (liberado && cbGrupo02.Text != "")
            {
                //Variáveis
                double CMV = 0;
                double CUSTO = 0;
                double RECEITA = 0;

                int PAX = 0;
                double meta = 0;
                DataTable tabelaCusto, tabelaReceita, totalCusto, totalReceita, tabelaMeta;
                DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
                DateTime diaF = diaI.AddDays(-(diaI.Day - 1)).AddMonths(1).AddDays(-1);
                DateTime DiaA = diaI;
                int unidade = Convert.ToInt32(cbUnidade.SelectedValue);
                string Diadasemana;
                int c = 0;
                int r = 0;

                //Busca Dados no BD
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLCmvGraficos bll = new BLLCmvGraficos(cx);

                int grupo = Convert.ToInt32(cbGrupo02.SelectedValue.ToString());

                tabelaCusto = bll.TabelaCustoPorGrupo(unidade, diaI, diaF, grupo);
                totalCusto = bll.TotalCustoPorGrupo(unidade, diaI, diaF, grupo);

                tabelaReceita = bll.TabelaReceitaPorGrupo(unidade, diaI, diaF, grupo);
                totalReceita = bll.TotalReceitaPorGrupo(unidade, diaI, diaF, grupo);

                tabelaMeta = bll.MetaPorGrupo(grupo);

                if (rdPercent.Checked)
                {
                    meta = Convert.ToDouble(tabelaMeta.Rows[0][1]);
                }
                else
                {
                    meta = Convert.ToDouble(tabelaMeta.Rows[0][0]);
                }

                for (int i = 0; i < diaF.Day; i++)
                {
                    try
                    {
                        if (Convert.ToDateTime(tabelaCusto.Rows[c][0]) != Convert.ToDateTime(tabelaReceita.Rows[r][0]))
                        {
                            if (Convert.ToDateTime(tabelaCusto.Rows[c][0]) > Convert.ToDateTime(tabelaReceita.Rows[r][0]))
                            {
                                CMV = 0;
                                r++;
                            }
                            else
                            {
                                CMV = 0;
                                c++;
                            }
                        }
                        else
                        {
                            if (Convert.ToDateTime(tabelaCusto.Rows[c][0]) == DiaA)
                            {
                                if (rdPercent.Checked)
                                {
                                    CUSTO = Convert.ToDouble(tabelaCusto.Rows[c][1]) * -1;
                                    RECEITA = Convert.ToDouble(tabelaReceita.Rows[r][3]);

                                    CMV = CUSTO / RECEITA;
                                    CMV = Math.Round(CMV, 4);
                                }
                                else
                                {
                                    CUSTO = Convert.ToDouble(tabelaCusto.Rows[c][1]) * -1;
                                    PAX = Convert.ToInt32(tabelaReceita.Rows[r][2]);

                                    CMV = Math.Round(CUSTO / PAX, 2);
                                }
                                c++;
                                r++;
                            }
                            else
                            {
                                CMV = 0;
                            }
                        }
                    }
                    catch
                    {
                        CMV = 0;
                        r++;
                        c++;
                    }

                    Diadasemana = Dia(DiaA);

                    chart1.Series["Valores"].Points.AddXY(Diadasemana, CMV);

                    chart1.Series["Meta"].Points.AddXY(Diadasemana, meta);

                    DiaA = DiaA.AddDays(1);
                }

                CMV = 0;

                try
                {
                    if (rdPercent.Checked)
                    {
                        CUSTO = Convert.ToDouble(totalCusto.Rows[0][0]) * -1;
                        RECEITA = Convert.ToDouble(totalReceita.Rows[0][2]);

                        CMV = CUSTO / RECEITA;
                        CMV = Math.Round(CMV, 4);
                    }
                    else
                    {
                        CUSTO = Convert.ToDouble(totalCusto.Rows[0][0]) * -1;
                        PAX = Convert.ToInt32(totalReceita.Rows[0][1]);

                        CMV = Math.Round(CUSTO / PAX, 2);
                    }

                }
                catch { }

                chart1.Series["Valores"].Points.AddXY("Total", CMV);
                chart1.Series["Meta"].Points.AddXY("Total", meta);

                if (rdPercent.Checked)
                {
                    chart1.Series["Valores"].LabelFormat = "0.0%";
                }
                else
                {
                    chart1.Series["Valores"].LabelFormat = "0.00";
                }
            }
            else
            {

            }
        }

        private void AtualizaChart03()
        {
                chart2.Series[0].Points.Clear();
                chart2.Series[1].Points.Clear();

            if (liberado && cbGrupo03.Text != "")
            {

                //Variáveis
                double CMV = 0;
                double CUSTO = 0;
                double RECEITA = 0;

                int PAX = 0;
                double meta = 0;
                DataTable tabelaCusto, tabelaReceita, totalCusto, totalReceita, tabelaMeta;
                DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
                DateTime diaF = diaI.AddDays(-(diaI.Day - 1)).AddMonths(1).AddDays(-1);
                DateTime DiaA = diaI;
                int unidade = Convert.ToInt32(cbUnidade.SelectedValue);
                string Diadasemana;
                int c = 0;
                int r = 0;

                //Busca Dados no BD
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLCmvGraficos bll = new BLLCmvGraficos(cx);

                int grupo = Convert.ToInt32(cbGrupo03.SelectedValue.ToString());

                tabelaCusto = bll.TabelaCustoPorGrupo(unidade, diaI, diaF, grupo);
                totalCusto = bll.TotalCustoPorGrupo(unidade, diaI, diaF, grupo);

                tabelaReceita = bll.TabelaReceitaPorGrupo(unidade, diaI, diaF, grupo);
                totalReceita = bll.TotalReceitaPorGrupo(unidade, diaI, diaF, grupo);

                tabelaMeta = bll.MetaPorGrupo(grupo);

                if (rdPercent.Checked)
                {
                    meta = Convert.ToDouble(tabelaMeta.Rows[0][1]);
                }
                else
                {
                    meta = Convert.ToDouble(tabelaMeta.Rows[0][0]);
                }



                for (int i = 0; i < diaF.Day; i++)
                {
                    try
                    {
                        if (Convert.ToDateTime(tabelaCusto.Rows[c][0]) != Convert.ToDateTime(tabelaReceita.Rows[r][0]))
                        {
                            if (Convert.ToDateTime(tabelaCusto.Rows[c][0]) > Convert.ToDateTime(tabelaReceita.Rows[r][0]))
                            {
                                CMV = 0;
                                r++;
                            }
                            else
                            {
                                CMV = 0;
                                c++;
                            }
                        }
                        else
                        {
                            if (Convert.ToDateTime(tabelaCusto.Rows[c][0]) == DiaA)
                            {
                                if (rdPercent.Checked)
                                {
                                    CUSTO = Convert.ToDouble(tabelaCusto.Rows[c][1]) * -1;
                                    RECEITA = Convert.ToDouble(tabelaReceita.Rows[r][3]);

                                    CMV = CUSTO / RECEITA;
                                    CMV = Math.Round(CMV, 4);
                                }
                                else
                                {
                                    CUSTO = Convert.ToDouble(tabelaCusto.Rows[c][1]) * -1;
                                    PAX = Convert.ToInt32(tabelaReceita.Rows[r][2]);

                                    CMV = Math.Round(CUSTO / PAX, 2);
                                }
                                c++;
                                r++;
                            }
                            else
                            {
                                CMV = 0;
                            }
                        }
                    }
                    catch
                    {
                        CMV = 0;
                        r++;
                        c++;
                    }

                    Diadasemana = Dia(DiaA);

                    chart2.Series["Valores"].Points.AddXY(Diadasemana, CMV);

                    chart2.Series["Meta"].Points.AddXY(Diadasemana, meta);

                    DiaA = DiaA.AddDays(1);
                }

                CMV = 0;

                try
                {
                    if (rdPercent.Checked)
                    {
                        CUSTO = Convert.ToDouble(totalCusto.Rows[0][0]) * -1;
                        RECEITA = Convert.ToDouble(totalReceita.Rows[0][2]);

                        CMV = CUSTO / RECEITA;
                        CMV = Math.Round(CMV, 4);
                    }
                    else
                    {
                        CUSTO = Convert.ToDouble(totalCusto.Rows[0][0]) * -1;
                        PAX = Convert.ToInt32(totalReceita.Rows[0][1]);

                        CMV = Math.Round(CUSTO / PAX, 2);
                    }

                }
                catch { }

                chart2.Series["Valores"].Points.AddXY("Total", CMV);
                chart2.Series["Meta"].Points.AddXY("Total", meta);

                if (rdPercent.Checked)
                {
                    chart2.Series["Valores"].LabelFormat = "0.0%";
                    chart2.Series["Meta"].LabelFormat = "0.0%";

                }
                else
                {
                    chart2.Series["Valores"].LabelFormat = "0.00";
                    chart2.Series["Meta"].LabelFormat = "0.00";

                }

            }
            else
            {

            }
        }

        private void AtualizaChart04()
        {
            DateTime Diai = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);

            DateTime Diaf = Diai.AddDays(-(Diai.Day - 1)).AddMonths(1).AddDays(-1);

            DateTime DiaA = Diai;

            int unidade = Convert.ToInt32(cbUnidade.SelectedValue);

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLCmvGraficos bll = new BLLCmvGraficos(cx);

            DataTable tabelac, tabelar;

            chart3.Series.Clear();


            Series series1 = new Series
            {
                Name = "Serie1",
                IsVisibleInLegend = true,
                Color = System.Drawing.Color.Green,
                ChartType = SeriesChartType.Pie
            };
            chart3.Series.Add(series1);

            double valor1, valor2, valor3, valor4, valor5;
            string percent1, percent2, percent3, percent4, percent5;

            tabelac = bll.TotalCustoPorGrupo(unidade, Diai, Diaf, Convert.ToInt32(cbGrupo01.SelectedValue));
            tabelar = bll.TotalReceitaPorGrupo(unidade, Diai, Diaf, Convert.ToInt32(cbGrupo01.SelectedValue));

            try { valor1 = Convert.ToDouble(tabelac.Rows[0][0])/ Convert.ToDouble(tabelar.Rows[0][1]); } catch { valor1 = 0; }

            tabelac = bll.TotalCustoPorGrupo(unidade, Diai, Diaf, Convert.ToInt32(cbGrupo02.SelectedValue));
            tabelar = bll.TotalReceitaPorGrupo(unidade, Diai, Diaf, Convert.ToInt32(cbGrupo02.SelectedValue));

            try { valor2 = Convert.ToDouble(tabelac.Rows[0][0]) / Convert.ToDouble(tabelar.Rows[0][1]); } catch { valor2 = 0; }

            tabelac = bll.TotalCustoPorGrupo(unidade, Diai, Diaf, Convert.ToInt32(cbGrupo03.SelectedValue));
            tabelar = bll.TotalReceitaPorGrupo(unidade, Diai, Diaf, Convert.ToInt32(cbGrupo03.SelectedValue));

            try { valor3 = Convert.ToDouble(tabelac.Rows[0][0]) / Convert.ToDouble(tabelar.Rows[0][1]); } catch { valor3 = 0; }

            tabelac = bll.TotalCustoPorGrupo(unidade, Diai, Diaf, Convert.ToInt32(cbGrupo04.SelectedValue));
            tabelar = bll.TotalReceitaPorGrupo(unidade, Diai, Diaf, Convert.ToInt32(cbGrupo04.SelectedValue));

            try { valor4 = Convert.ToDouble(tabelac.Rows[0][0]) / Convert.ToDouble(tabelar.Rows[0][1]); } catch { valor4 = 0; }

            tabelac = bll.TotalCustoPorGrupo(unidade, Diai, Diaf, Convert.ToInt32(cbGrupo05.SelectedValue));
            tabelar = bll.TotalReceitaPorGrupo(unidade, Diai, Diaf, Convert.ToInt32(cbGrupo05.SelectedValue));

            try { valor5 = Convert.ToDouble(tabelac.Rows[0][0]) / Convert.ToDouble(tabelar.Rows[0][1]); } catch { valor5 = 0; }




            if ((Math.Round(valor1 / (valor1 + valor2 + valor3+ valor4 + valor5), 2)) * 100 >= 5)
            {
                percent1 = ((Math.Round(valor1 / (valor1 + valor2 + valor3 + valor4 + valor5), 2)) * 100).ToString() + "%";
            }
            else
            {
                percent1 = "";
            }
            if ((Math.Round(valor2 / (valor1 + valor2 + valor3 + valor4 + valor5), 2)) * 100 >= 5)
            {
                percent2 = ((Math.Round(valor2 / (valor1 + valor2 + valor3 + valor4 + valor5), 2)) * 100).ToString() + "%";
            }
            else
            {
                percent2 = "";
            }
            if ((Math.Round(valor3 / (valor1 + valor2 + valor3 + valor4 + valor5), 2)) * 100 >= 5)
            {
                percent3 = ((Math.Round(valor3 / (valor1 + valor2 + valor3 + valor4 + valor5), 2)) * 100).ToString() + "%";
            }
            else
            {
                percent3 = "";
            }

            if ((Math.Round(valor4 / (valor1 + valor2 + valor3 + valor4 + valor5), 2)) * 100 >= 5)
            {
                percent4 = ((Math.Round(valor4 / (valor1 + valor2 + valor3 + valor4 + valor5), 2)) * 100).ToString() + "%";
            }
            else
            {
                percent4 = "";
            }

            if ((Math.Round(valor5 / (valor1 + valor2 + valor3 + valor4 + valor5), 2)) * 100 >= 5)
            {
                percent5 = ((Math.Round(valor5 / (valor1 + valor2 + valor3 + valor4 + valor5), 2)) * 100).ToString() + "%";
            }
            else
            {
                percent5 = "";
            }

            series1.Points.Add(valor1).Color = Color.Red;            
            series1.Points.Add(valor2).Color = Color.RoyalBlue;
            series1.Points.Add(valor3).Color = Color.Green;
            series1.Points.Add(valor4).Color = Color.Orange;
            series1.Points.Add(valor5).Color = Color.DarkViolet;

            var p1 = series1.Points[0];
            p1.AxisLabel = percent1;           

            var p2 = series1.Points[1];
            p2.AxisLabel = percent2;            

            var p3 = series1.Points[2];
            p3.AxisLabel = percent3;

            var p4 = series1.Points[3];
            p4.AxisLabel = percent4;

            var p5 = series1.Points[4];
            p5.AxisLabel = percent5;

        }

        private void AtualizaChart05()
        {
            DateTime Diai = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);

            DateTime Diaf = Diai.AddDays(-(Diai.Day - 1)).AddMonths(1).AddDays(-1);

            DateTime DiaA = Diai;

            int unidade = Convert.ToInt32(cbUnidade.SelectedValue);

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLCmvGraficos bll = new BLLCmvGraficos(cx);

            DataTable tabelac, tabelar;

            chart4.Series.Clear();


            Series series1 = new Series
            {
                Name = "Serie1",
                IsVisibleInLegend = true,
                Color = System.Drawing.Color.Green,
                ChartType = SeriesChartType.Pie
            };
            chart4.Series.Add(series1);

            double valor1, valor2, valor3, valor4, valor5;
            string percent1, percent2, percent3, percent4, percent5;

            tabelac = bll.TotalCustoPorGrupo(unidade, Diai, Diaf, Convert.ToInt32(cbGrupo01.SelectedValue));
            tabelar = bll.TotalReceitaPorGrupo(unidade, Diai, Diaf, Convert.ToInt32(cbGrupo01.SelectedValue));

            try { valor1 = Convert.ToDouble(tabelac.Rows[0][0]) / Convert.ToDouble(tabelar.Rows[0][2]); } catch { valor1 = 0; }

            tabelac = bll.TotalCustoPorGrupo(unidade, Diai, Diaf, Convert.ToInt32(cbGrupo02.SelectedValue));
            tabelar = bll.TotalReceitaPorGrupo(unidade, Diai, Diaf, Convert.ToInt32(cbGrupo02.SelectedValue));

            try { valor2 = Convert.ToDouble(tabelac.Rows[0][0]) / Convert.ToDouble(tabelar.Rows[0][2]); } catch { valor2 = 0; }

            tabelac = bll.TotalCustoPorGrupo(unidade, Diai, Diaf, Convert.ToInt32(cbGrupo03.SelectedValue));
            tabelar = bll.TotalReceitaPorGrupo(unidade, Diai, Diaf, Convert.ToInt32(cbGrupo03.SelectedValue));

            try { valor3 = Convert.ToDouble(tabelac.Rows[0][0]) / Convert.ToDouble(tabelar.Rows[0][2]); } catch { valor3 = 0; }

            tabelac = bll.TotalCustoPorGrupo(unidade, Diai, Diaf, Convert.ToInt32(cbGrupo04.SelectedValue));
            tabelar = bll.TotalReceitaPorGrupo(unidade, Diai, Diaf, Convert.ToInt32(cbGrupo04.SelectedValue));

            try { valor4 = Convert.ToDouble(tabelac.Rows[0][0]) / Convert.ToDouble(tabelar.Rows[0][2]); } catch { valor4 = 0; }

            tabelac = bll.TotalCustoPorGrupo(unidade, Diai, Diaf, Convert.ToInt32(cbGrupo05.SelectedValue));
            tabelar = bll.TotalReceitaPorGrupo(unidade, Diai, Diaf, Convert.ToInt32(cbGrupo05.SelectedValue));

            try { valor5 = Convert.ToDouble(tabelac.Rows[0][0]) / Convert.ToDouble(tabelar.Rows[0][2]); } catch { valor5 = 0; }




            if ((Math.Round(valor1 / (valor1 + valor2 + valor3 + valor4 + valor5), 2)) * 100 >= 5)
            {
                percent1 = ((Math.Round(valor1 / (valor1 + valor2 + valor3 + valor4 + valor5), 2)) * 100).ToString() + "%";
            }
            else
            {
                percent1 = "";
            }
            if ((Math.Round(valor2 / (valor1 + valor2 + valor3 + valor4 + valor5), 2)) * 100 >= 5)
            {
                percent2 = ((Math.Round(valor2 / (valor1 + valor2 + valor3 + valor4 + valor5), 2)) * 100).ToString() + "%";
            }
            else
            {
                percent2 = "";
            }
            if ((Math.Round(valor3 / (valor1 + valor2 + valor3 + valor4 + valor5), 2)) * 100 >= 5)
            {
                percent3 = ((Math.Round(valor3 / (valor1 + valor2 + valor3 + valor4 + valor5), 2)) * 100).ToString() + "%";
            }
            else
            {
                percent3 = "";
            }

            if ((Math.Round(valor4 / (valor1 + valor2 + valor3 + valor4 + valor5), 2)) * 100 >= 5)
            {
                percent4 = ((Math.Round(valor4 / (valor1 + valor2 + valor3 + valor4 + valor5), 2)) * 100).ToString() + "%";
            }
            else
            {
                percent4 = "";
            }

            if ((Math.Round(valor5 / (valor1 + valor2 + valor3 + valor4 + valor5), 2)) * 100 >= 5)
            {
                percent5 = ((Math.Round(valor5 / (valor1 + valor2 + valor3 + valor4 + valor5), 2)) * 100).ToString() + "%";
            }
            else
            {
                percent5 = "";
            }

            series1.Points.Add(valor1).Color = Color.Red;
            series1.Points.Add(valor2).Color = Color.RoyalBlue;
            series1.Points.Add(valor3).Color = Color.Green;
            series1.Points.Add(valor4).Color = Color.Orange;
            series1.Points.Add(valor5).Color = Color.DarkViolet;

            var p1 = series1.Points[0];
            p1.AxisLabel = percent1;

            var p2 = series1.Points[1];
            p2.AxisLabel = percent2;

            var p3 = series1.Points[2];
            p3.AxisLabel = percent3;

            var p4 = series1.Points[3];
            p4.AxisLabel = percent4;

            var p5 = series1.Points[4];
            p5.AxisLabel = percent5;
        }

        private string Dia(DateTime dia)
        {
            string diaDaSemana = dia.Day.ToString() + "\n";

            switch ((int)dia.DayOfWeek)
            {
                case 0:
                    diaDaSemana += "D";
                    break;
                case 1:
                    diaDaSemana += "S";
                    break;
                case 2:
                    diaDaSemana += "T";
                    break;
                case 3:
                    diaDaSemana += "Q";
                    break;
                case 4:
                    diaDaSemana += "Q";
                    break;
                case 5:
                    diaDaSemana += "S";
                    break;
                case 6:
                    diaDaSemana += "S";
                    break;
            }

            return diaDaSemana;
        }
        
        private void cbUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liberado)
            {
                unidade = Convert.ToInt32(cbUnidade.SelectedValue.ToString());
                CarregaCbGrupos();
                AtualizaCharts();
            }
        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {

            AtualizaCharts();

        }

        private void numAno_ValueChanged(object sender, EventArgs e)
        {

            AtualizaCharts();

        }

        private void rdValor_CheckedChanged(object sender, EventArgs e)
        {

            AtualizaCharts();

        }

        private void rdPercent_CheckedChanged(object sender, EventArgs e)
        {

            AtualizaCharts();

        }

        private void SalvarConfigs(int chart)
        {

            ///Cadastrar o tipo de config com o nome GG1 (grafico grupos 1), GG2...

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLConfigUnidade bll = new BLLConfigUnidade(cx);
            DTOConfigUnidade dto = new DTOConfigUnidade();

            DataTable tabela;


            if (chart == 1)
            {
                if (cbGrupo01.SelectedValue.ToString() != "0")
                {

                    dto.TipoConfig = "GG1";
                    dto.Config = cbGrupo01.SelectedValue.ToString();
                    dto.IdUnidade = unidade;
                    dto.IdUsuario = idUsuario;

                    tabela = bll.LocalizarConfigUsuario("GG1", unidade, idUsuario);

                    if (tabela.Rows.Count > 0)
                    {
                        bll.AlterarU(dto);
                    }
                    else
                    {
                        bll.Incluir(dto);
                    }
                }
                else
                {
                    bll.ExcluirporUsuario("GG1", unidade, idUsuario);
                }
            }
            if (chart == 2)
            {
                if (cbGrupo02.SelectedValue.ToString() != "0")
                {
                    dto.TipoConfig = "GG2";
                    dto.Config = cbGrupo02.SelectedValue.ToString();
                    dto.IdUnidade = unidade;
                    dto.IdUsuario = idUsuario;

                    tabela = bll.LocalizarConfigUsuario("GG2", unidade, idUsuario);
                    if (tabela.Rows.Count > 0)
                    {
                        bll.AlterarU(dto);
                    }
                    else
                    {
                        bll.Incluir(dto);
                    }
                }
                else
                {
                    bll.ExcluirporUsuario("GG2", unidade, idUsuario);
                }
            }
            if (chart == 3)
            {
                if (cbGrupo03.SelectedValue.ToString() != "0")
                {
                    dto.TipoConfig = "GG3";
                    dto.Config = cbGrupo03.SelectedValue.ToString();
                    dto.IdUnidade = unidade;
                    dto.IdUsuario = idUsuario;

                    tabela = bll.LocalizarConfigUsuario("GG3", unidade, idUsuario);
                    if (tabela.Rows.Count > 0)
                    {
                        bll.AlterarU(dto);
                    }
                    else
                    {
                        bll.Incluir(dto);
                    }
                }
                else
                {
                    bll.ExcluirporUsuario("GG3", unidade, idUsuario);
                }
            }
            if (chart == 4)
            {
                if (cbGrupo04.SelectedValue.ToString() != "0")
                {
                    dto.TipoConfig = "GG4";
                    dto.Config = cbGrupo04.SelectedValue.ToString();
                    dto.IdUnidade = unidade;
                    dto.IdUsuario = idUsuario;

                    tabela = bll.LocalizarConfigUsuario("GG4", unidade, idUsuario);

                    if (tabela.Rows.Count > 0)
                    {
                        bll.AlterarU(dto);
                    }
                    else
                    {
                        bll.Incluir(dto);
                    }
                }
                else
                {
                    bll.ExcluirporUsuario("GG4", unidade, idUsuario);
                }
            }
            if (chart == 5)
            {
                if (cbGrupo05.SelectedValue.ToString() != "0")
                {
                    dto.TipoConfig = "GG5";
                    dto.Config = cbGrupo05.SelectedValue.ToString();
                    dto.IdUnidade = unidade;
                    dto.IdUsuario = idUsuario;

                    tabela = bll.LocalizarConfigUsuario("GG5", unidade, idUsuario);

                    if (tabela.Rows.Count > 0)
                    {
                        bll.AlterarU(dto);
                    }
                    else
                    {
                        bll.Incluir(dto);
                    }
                }
                else
                {
                    bll.ExcluirporUsuario("GG5", unidade, idUsuario);
                }
            }
        }

        private void chart0_MouseMove(object sender, MouseEventArgs e)
        {
            #region VerificaX

            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart0.HitTest(pos.X, pos.Y, false, ChartElementType.PlottingArea);

            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.PlottingArea)
                {
                    var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);

                    //Atribui à variável o número da coluna que o mouse está sobre.
                    pontoAtual = Convert.ToInt32(Math.Round(xVal));

                }
            }

            #endregion

            #region Pinta Ponto selecionado

            // Call HitTest
            HitTestResult resultado = chart0.HitTest(e.X, e.Y);

            // Reset Data Point Attributes
            foreach (DataPoint point in chart0.Series[0].Points)
            {
                point.BackSecondaryColor = Color.Black;
                point.BackHatchStyle = ChartHatchStyle.None;
                point.BorderWidth = 1;
            }
            foreach (DataPoint point in chart0.Series[1].Points)
            {
                point.BackSecondaryColor = Color.Black;
                point.BackHatchStyle = ChartHatchStyle.None;
                point.BorderWidth = 1;
            }

            // If the mouse if over a data point
            if (resultado.ChartElementType == ChartElementType.DataPoint)
            {
                // Find selected data point
                DataPoint point = chart0.Series[0].Points[resultado.PointIndex];
                DataPoint point1 = chart0.Series[1].Points[resultado.PointIndex];

                // Change the appearance of the data point
                point.BackSecondaryColor = Color.White;
                point.BackHatchStyle = ChartHatchStyle.Percent25;
                point.BorderWidth = 2;
                point1.BackSecondaryColor = Color.White;
                point1.BackHatchStyle = ChartHatchStyle.Percent25;
                point1.BorderWidth = 2;

                // label3.Text = graficoComparativo1.Series[0].Points[resultado.PointIndex].ToString();

            }
            else
            {
                // Set default cursor
                this.Cursor = Cursors.Default;

                //Se o mouse não está sobre nehuma coluna, atribui à variável o valor 0.
                pontoAtual = 0;

            }

            #endregion
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            #region VerificaX

            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false, ChartElementType.PlottingArea);

            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.PlottingArea)
                {
                    var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);

                    //Atribui à variável o número da coluna que o mouse está sobre.
                    pontoAtual = Convert.ToInt32(Math.Round(xVal));

                }
            }

            #endregion

            #region Pinta Ponto selecionado

            // Call HitTest
            HitTestResult resultado = chart1.HitTest(e.X, e.Y);

            // Reset Data Point Attributes
            foreach (DataPoint point in chart1.Series[0].Points)
            {
                point.BackSecondaryColor = Color.Black;
                point.BackHatchStyle = ChartHatchStyle.None;
                point.BorderWidth = 1;
            }
            foreach (DataPoint point in chart1.Series[1].Points)
            {
                point.BackSecondaryColor = Color.Black;
                point.BackHatchStyle = ChartHatchStyle.None;
                point.BorderWidth = 1;
            }

            // If the mouse if over a data point
            if (resultado.ChartElementType == ChartElementType.DataPoint)
            {
                // Find selected data point
                DataPoint point = chart1.Series[0].Points[resultado.PointIndex];
                DataPoint point1 = chart1.Series[1].Points[resultado.PointIndex];

                // Change the appearance of the data point
                point.BackSecondaryColor = Color.White;
                point.BackHatchStyle = ChartHatchStyle.Percent25;
                point.BorderWidth = 2;
                point1.BackSecondaryColor = Color.White;
                point1.BackHatchStyle = ChartHatchStyle.Percent25;
                point1.BorderWidth = 2;

                // label3.Text = graficoComparativo1.Series[0].Points[resultado.PointIndex].ToString();

            }
            else
            {
                // Set default cursor
                this.Cursor = Cursors.Default;

                //Se o mouse não está sobre nehuma coluna, atribui à variável o valor 0.
                pontoAtual = 0;

            }

            #endregion
        }

        private void chart0_Click(object sender, EventArgs e)
        {

            DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DateTime diaF = diaI.AddDays(-(diaI.Day - 1)).AddMonths(1).AddDays(-1);
            DateTime diaA;
            
            
            string titulo;
            int dia;
            int grupo = Convert.ToInt32(cbGrupo01.SelectedValue);
            
            if (pontoAtual > 0)
            {
                if (pontoAtual > diaF.Day)
                {                    
                    titulo = cbGrupo01.Text + " (" + cbMes.Text + ")";
                    dia = 32;
                    frmDetalheGrafico f = new frmDetalheGrafico(pontoAtual, titulo, grupo, diaI, diaF, unidade);
                    f.ShowDialog();
                    f.Dispose();

                }
                else
                {
                    diaA = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), pontoAtual);
                    titulo = cbGrupo01.Text + " (" + pontoAtual.ToString("00")+"/"+Convert.ToInt32(cbMes.SelectedValue).ToString("00") + ")";
                    dia = pontoAtual;
                    frmDetalheGrafico f = new frmDetalheGrafico(pontoAtual, titulo, grupo, diaA, diaA, unidade);
                    f.ShowDialog();
                    f.Dispose();

                }


            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DateTime diaF = diaI.AddDays(-(diaI.Day - 1)).AddMonths(1).AddDays(-1);
            DateTime diaA;


            string titulo;
            int dia;
            int grupo = Convert.ToInt32(cbGrupo02.SelectedValue);

            if (pontoAtual > 0)
            {
                if (pontoAtual > diaF.Day)
                {
                    titulo = cbGrupo02.Text + " (" + cbMes.Text + ")";
                    dia = 32;
                    frmDetalheGrafico f = new frmDetalheGrafico(pontoAtual, titulo, grupo, diaI, diaF, unidade);
                    f.ShowDialog();
                    f.Dispose();

                }
                else
                {
                    diaA = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), pontoAtual);
                    titulo = cbGrupo02.Text + " (" + pontoAtual.ToString("00") + "/" + Convert.ToInt32(cbMes.SelectedValue).ToString("00") + ")";
                    dia = pontoAtual;
                    frmDetalheGrafico f = new frmDetalheGrafico(pontoAtual, titulo, grupo, diaA, diaA, unidade);
                    f.ShowDialog();
                    f.Dispose();

                }


            }
        }

        private void chart2_Click(object sender, EventArgs e)
        {
            DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DateTime diaF = diaI.AddDays(-(diaI.Day - 1)).AddMonths(1).AddDays(-1);
            DateTime diaA;


            string titulo;
            int dia;
            int grupo = Convert.ToInt32(cbGrupo03.SelectedValue);

            if (pontoAtual > 0)
            {
                if (pontoAtual > diaF.Day)
                {
                    titulo = cbGrupo03.Text + " (" + cbMes.Text + ")";
                    dia = 32;
                    frmDetalheGrafico f = new frmDetalheGrafico(pontoAtual, titulo, grupo, diaI, diaF, unidade);
                    f.ShowDialog();
                    f.Dispose();

                }
                else
                {
                    diaA = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), pontoAtual);
                    titulo = cbGrupo03.Text + " (" + pontoAtual.ToString("00") + "/" + Convert.ToInt32(cbMes.SelectedValue).ToString("00") + ")";
                    dia = pontoAtual;
                    frmDetalheGrafico f = new frmDetalheGrafico(pontoAtual, titulo, grupo, diaA, diaA, unidade);
                    f.ShowDialog();
                    f.Dispose();

                }


            }
        }

        private void chart2_MouseMove(object sender, MouseEventArgs e)
        {
            #region VerificaX

            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart2.HitTest(pos.X, pos.Y, false, ChartElementType.PlottingArea);

            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.PlottingArea)
                {
                    var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);

                    //Atribui à variável o número da coluna que o mouse está sobre.
                    pontoAtual = Convert.ToInt32(Math.Round(xVal));

                }
            }

            #endregion

            #region Pinta Ponto selecionado

            // Call HitTest
            HitTestResult resultado = chart2.HitTest(e.X, e.Y);

            // Reset Data Point Attributes
            foreach (DataPoint point in chart2.Series[0].Points)
            {
                point.BackSecondaryColor = Color.Black;
                point.BackHatchStyle = ChartHatchStyle.None;
                point.BorderWidth = 1;
            }
            foreach (DataPoint point in chart2.Series[1].Points)
            {
                point.BackSecondaryColor = Color.Black;
                point.BackHatchStyle = ChartHatchStyle.None;
                point.BorderWidth = 1;
            }

            // If the mouse if over a data point
            if (resultado.ChartElementType == ChartElementType.DataPoint)
            {
                // Find selected data point
                DataPoint point = chart2.Series[0].Points[resultado.PointIndex];
                DataPoint point1 = chart2.Series[1].Points[resultado.PointIndex];

                // Change the appearance of the data point
                point.BackSecondaryColor = Color.White;
                point.BackHatchStyle = ChartHatchStyle.Percent25;
                point.BorderWidth = 2;
                point1.BackSecondaryColor = Color.White;
                point1.BackHatchStyle = ChartHatchStyle.Percent25;
                point1.BorderWidth = 2;

                // label3.Text = graficoComparativo1.Series[0].Points[resultado.PointIndex].ToString();

            }
            else
            {
                // Set default cursor
                this.Cursor = Cursors.Default;

                //Se o mouse não está sobre nehuma coluna, atribui à variável o valor 0.
                pontoAtual = 0;

            }

            #endregion
        }

        private void CarregarConfigs()
        {
            liberado = false;
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLConfigUnidade bll = new BLLConfigUnidade(cx);
            DTOConfigUnidade dto = new DTOConfigUnidade();

            BLLCmvGrupo bllg = new BLLCmvGrupo(cx);


            DataTable tabela, tabelag;

            cbGrupo01.Text = "";
            cbGrupo02.Text = "";
            cbGrupo03.Text = "";
            cbGrupo04.Text = "";
            cbGrupo05.Text = "";

            tabela = bll.LocalizarConfigUsuario("GG1", unidade, idUsuario);

            if (tabela.Rows.Count > 0)
            {
                tabelag = bllg.LocalizarGrupoPorId(Convert.ToInt32(tabela.Rows[0][0]));

                try
                {
                    cbGrupo01.Text = tabelag.Rows[0][1].ToString();
                }
                catch
                {
                    cbGrupo01.Text = "";
                }

                lbG1.Text = cbGrupo01.Text;
            }           

            tabela = bll.LocalizarConfigUsuario("GG2", unidade, idUsuario);

            if (tabela.Rows.Count > 0)
            {
                tabelag = bllg.LocalizarGrupoPorId(Convert.ToInt32(tabela.Rows[0][0]));
                try
                {
                    cbGrupo02.Text = tabelag.Rows[0][1].ToString();
                }
                catch
                {
                    cbGrupo02.Text = "";
                }
                lbG2.Text = cbGrupo02.Text;
            }
           
            tabela = bll.LocalizarConfigUsuario("GG3", unidade, idUsuario);

            if (tabela.Rows.Count > 0)
            {
                tabelag = bllg.LocalizarGrupoPorId(Convert.ToInt32(tabela.Rows[0][0]));
                try
                {
                    cbGrupo03.Text = tabelag.Rows[0][1].ToString();
                }
                catch
                {
                    cbGrupo03.Text = "";
                }
                lbG3.Text = cbGrupo03.Text;
            }
            
            tabela = bll.LocalizarConfigUsuario("GG4", unidade, idUsuario);

            if (tabela.Rows.Count > 0)
            {
                tabelag = bllg.LocalizarGrupoPorId(Convert.ToInt32(tabela.Rows[0][0]));
                try
                {
                    cbGrupo04.Text = tabelag.Rows[0][1].ToString();
                }
                catch
                {

                }
            }
            tabela = bll.LocalizarConfigUsuario("GG5", unidade, idUsuario);

            if (tabela.Rows.Count > 0)
            {
                tabelag = bllg.LocalizarGrupoPorId(Convert.ToInt32(tabela.Rows[0][0]));
                try
                {
                    cbGrupo05.Text = tabelag.Rows[0][1].ToString();
                }
                catch { }
            }
            liberado = true;
        }
               
    }
}
