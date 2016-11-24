﻿using GUI.Code.BLL;
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
using GUI.Code.FERRAMENTAS;


namespace GUI.Forms.CMV
{
    public partial class frmGAVSinteticoGeral : Form
    {
        int unidade, idUsuario, pontoAtual;
        bool liberado = false;
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();

        public frmGAVSinteticoGeral(int id)
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

        private string IntToMes(int mes)
        {
            string mesSelecionado = "";

            switch (mes)
            {
                case 1:
                    mesSelecionado = "Janeiro";
                    break;
                case 2:
                    mesSelecionado = "Fevereiro";
                    break;
                case 3:
                    mesSelecionado = "Março";
                    break;
                case 4:
                    mesSelecionado = "Abril";
                    break;
                case 5:
                    mesSelecionado = "Maio";
                    break;
                case 6:
                    mesSelecionado = "Junho";
                    break;
                case 7:
                    mesSelecionado = "Julho";
                    break;
                case 8:
                    mesSelecionado = "Agosto";
                    break;
                case 9:
                    mesSelecionado = "Setembro";
                    break;
                case 10:
                    mesSelecionado = "Outubro";
                    break;
                case 11:
                    mesSelecionado = "Novembro";
                    break;
                case 12:
                    mesSelecionado = "Dezembro";
                    break;
            }


            return mesSelecionado;
        }

        private int MesToInt(string mes)
        {
            int mesSelecionado = 0;

            switch (mes)
            {
                case "Janeiro":
                    mesSelecionado = 1;
                    break;
                case "Fevereiro":
                    mesSelecionado = 2;
                    break;
                case "Março":
                    mesSelecionado = 3;
                    break;
                case "Abril":
                    mesSelecionado = 4;
                    break;
                case "Maio":
                    mesSelecionado = 5;
                    break;
                case "Junho":
                    mesSelecionado = 6;
                    break;
                case "Julho":
                    mesSelecionado = 7;
                    break;
                case "Agosto":
                    mesSelecionado = 8;
                    break;
                case "Setembro":
                    mesSelecionado = 9;
                    break;
                case "Outubro":
                    mesSelecionado = 10;
                    break;
                case "Novembro":
                    mesSelecionado = 11;
                    break;
                case "Dezembro":
                    mesSelecionado = 12;
                    break;
            }
                    return mesSelecionado;
        }

        private void frmSinteticoGeral_Load(object sender, EventArgs e)
        {
            COMUNS com = new COMUNS();

            DTOUsuario modelou = com.UsuarioInfo(idUsuario);

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";
            try
            {
                DafaultValues();
            }
            catch
            {
                MessageBox.Show("Erro ao carregar página.");
            }
            finally
            {
                
            }
        }

        private void DafaultValues()
        {
            liberado = false;

            CarregaMes();
            DateTime data = DateTime.Today;

            COMUNS com = new COMUNS();



            numAno.Value = data.Year;
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUnidade bllun = new BLLUnidade(con);
            
            DTOUsuario modelou = com.UsuarioInfo(idUsuario);

            cbUnidade.DataSource = bllun.ListarUnidades();
            cbUnidade.DisplayMember = "cod_unidade";
            cbUnidade.ValueMember = "id_unidade";
            
          
            if (modelou.PermissaoUsuario < 4)
            {
                cbUnidade.Enabled = false;
            }
            

            cbUnidade.Text = modelou.IdUnidade.ToString("00");

            unidade = Convert.ToInt32(modelou.IdUnidade.ToString());

            CarregaCbGrupos();

            rdValor.Checked = true;
            rdPercent.Checked = false;

            cbComparativo01.Text = Properties.Settings.Default.cbComp01;

            cbComparativo02.Text = Properties.Settings.Default.cbComp02;

            cbGeral.Text = Properties.Settings.Default.cbGeral;

            liberado = true;

            AtualizaCharts();

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
            this.cbComparativo01.DataSource = dataSource1;
            this.cbComparativo01.DisplayMember = "Name1";
            this.cbComparativo01.ValueMember = "Value1";

            //Atualiza grupo 02
            this.cbComparativo02.DataSource = dataSource2;
            this.cbComparativo02.DisplayMember = "Name2";
            this.cbComparativo02.ValueMember = "Value2";

            //Atualiza grupo 03
            this.cbGeral.DataSource = dataSource3;
            this.cbGeral.DisplayMember = "Name3";
            this.cbGeral.ValueMember = "Value3";


        }

        private void AtualizaCharts()
        {
            if (liberado)
            {
                AtualizaGraf1();
                AtualizaGraf2();
                AtualizaPizza1();
                AtualizaDetalhes();
            }

             
            
        }

        private void AtualizaGraf1()
        {

            Graf1.Series[0].Points.Clear();
            Graf1.Series[1].Points.Clear();
            
            if (liberado && (cbComparativo01.Text != "" || cbComparativo02.Text != ""))
            {

                //Variáveis
                double CMVV = 0;
                double CMVP = 0;
                double Custo, Receita, Pax;
                string diaSemana = "";

                lbDetalh0103.Text = "";
                lbDetalh0104.Text = "";

                DataTable tabelaCMV, TotalCmv;
                DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
                int unidade = Convert.ToInt32(cbUnidade.SelectedValue);

                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLCmvGraficos bll = new BLLCmvGraficos(cx);

                tabelaCMV = bll.ListaCmvPorGrupo(unidade, diaI, Convert.ToInt32(cbComparativo01.SelectedValue), 01);
                TotalCmv = bll.Total1CMVPorGrupo(unidade, diaI, Convert.ToInt32(cbComparativo01.SelectedValue), 01);
                Custo = 0;
                Receita = 0;
                Pax = 0;

                #region Grupo01

                if(Convert.ToDouble(TotalCmv.Rows[0][7]) > 0 && Convert.ToDouble(TotalCmv.Rows[0][8]) > 0 && Convert.ToDouble(TotalCmv.Rows[0][9]) > 0)
                { 
                    for (int i = 0; i < tabelaCMV.Rows.Count; i++)
                    {
                        diaSemana = Dia(Convert.ToDateTime(tabelaCMV.Rows[i][0]));

                        Custo += (Convert.ToDouble(tabelaCMV.Rows[i][1]) + Convert.ToDouble(tabelaCMV.Rows[i][2])) * -1;
                        Receita += Convert.ToDouble(tabelaCMV.Rows[i][3]) + Convert.ToDouble(tabelaCMV.Rows[i][4]);
                        Pax += Convert.ToDouble(tabelaCMV.Rows[i][6]) + Convert.ToDouble(tabelaCMV.Rows[i][7]);

                        if (rdPercent.Checked)
                        {
                            try
                            {
                                if (Convert.ToDouble(tabelaCMV.Rows[i][1]) == 0 || Convert.ToDouble(tabelaCMV.Rows[i][3]) == 0)
                                {
                                    CMVP = 0;
                                }
                                else
                                {
                                    CMVP = ((Convert.ToDouble(tabelaCMV.Rows[i][1]) + Convert.ToDouble(tabelaCMV.Rows[i][2])) * -1) / (Convert.ToDouble(tabelaCMV.Rows[i][3]) + Convert.ToDouble(tabelaCMV.Rows[i][4]));
                                }
                            }
                            catch
                            {
                                CMVP = 0;
                            }

                            Graf1.Series["G1"].Points.AddXY(diaSemana, CMVP * 100);

                        }
                        else
                        {
                            try
                            {
                                if (Convert.ToDouble(tabelaCMV.Rows[i][1]) == 0 || Convert.ToDouble(tabelaCMV.Rows[i][6]) == 0)
                                {
                                    CMVV = 0;
                                }
                                else
                                {
                                    CMVV = ((Convert.ToDouble(tabelaCMV.Rows[i][1]) + Convert.ToDouble(tabelaCMV.Rows[i][2])) * -1) / (Convert.ToDouble(tabelaCMV.Rows[i][6]) + Convert.ToDouble(tabelaCMV.Rows[i][7]));
                                }
                            }
                            catch
                            {
                                CMVP = 0;
                            }

                            Graf1.Series["G1"].Points.AddXY(diaSemana, CMVV);
                        }
                    }

                    if (rdPercent.Checked)
                    {
                        try
                        {
                            Graf1.Series["G1"].Points.AddXY(("Total"), (Math.Round(Custo / Receita, 4) * 100));
                        }
                        catch
                        {
                            Graf1.Series["G1"].Points.AddXY(("Total"), 0);
                        }
                    }
                    else
                    {
                        try
                        {
                            Graf1.Series["G1"].Points.AddXY(("Total"), Math.Round(Custo / Pax, 2));
                        }
                        catch
                        {
                            Graf1.Series["G1"].Points.AddXY(("Total"), 0);
                        }
                    }

                    if (Custo == 0 || Receita == 0 || Pax == 0)
                    {
                        lbDetalh0103.Text = "";
                        lbDetalh0104.Text = "";
                    }
                    else
                    {
                        lbDetalh0103.Text = (Math.Round(Custo / Pax, 2)).ToString("R$ 0,0.00");
                        lbDetalh0104.Text = (Math.Round(Custo / Receita, 4) * 100).ToString("0.00") + "%";
                    }

                }

                #endregion

                #region Grupo 2


                Custo = 0;
                Receita = 0;
                Pax = 0;
                lbDetalh0203.Text = "";
                lbDetalh0204.Text = "";
                tabelaCMV = bll.ListaCmvPorGrupo(unidade, diaI, Convert.ToInt32(cbComparativo02.SelectedValue), 01);
                TotalCmv = bll.Total1CMVPorGrupo(unidade, diaI, Convert.ToInt32(cbComparativo02.SelectedValue), 01);

                if (Convert.ToDouble(TotalCmv.Rows[0][7]) > 0 && Convert.ToDouble(TotalCmv.Rows[0][8]) > 0 && Convert.ToDouble(TotalCmv.Rows[0][9]) > 0)
                {

                    for (int i = 0; i < tabelaCMV.Rows.Count; i++)
                    {
                        diaSemana = Dia(Convert.ToDateTime(tabelaCMV.Rows[i][0]));

                        Custo += (Convert.ToDouble(tabelaCMV.Rows[i][1]) + Convert.ToDouble(tabelaCMV.Rows[i][2])) * -1;
                        Receita += Convert.ToDouble(tabelaCMV.Rows[i][3]) + Convert.ToDouble(tabelaCMV.Rows[i][4]);
                        Pax += Convert.ToDouble(tabelaCMV.Rows[i][6]) + Convert.ToDouble(tabelaCMV.Rows[i][7]);

                        if (rdPercent.Checked)
                        {
                            try
                            {
                                if (Convert.ToDouble(tabelaCMV.Rows[i][1]) == 0 || Convert.ToDouble(tabelaCMV.Rows[i][3]) == 0)
                                {
                                    CMVP = 0;
                                }
                                else
                                {
                                    CMVP = ((Convert.ToDouble(tabelaCMV.Rows[i][1]) + Convert.ToDouble(tabelaCMV.Rows[i][2])) * -1) / (Convert.ToDouble(tabelaCMV.Rows[i][3]) + Convert.ToDouble(tabelaCMV.Rows[i][4]));
                                }
                            }
                            catch
                            {
                                CMVP = 0;
                            }

                            Graf1.Series["G2"].Points.AddXY(diaSemana, CMVP * 100);

                        }
                        else
                        {
                            try
                            {
                                if (Convert.ToDouble(tabelaCMV.Rows[i][1]) == 0 || Convert.ToDouble(tabelaCMV.Rows[i][6]) == 0)
                                {
                                    CMVV = 0;
                                }
                                else
                                {
                                    CMVV = ((Convert.ToDouble(tabelaCMV.Rows[i][1]) + Convert.ToDouble(tabelaCMV.Rows[i][2])) * -1) / (Convert.ToDouble(tabelaCMV.Rows[i][6]) + Convert.ToDouble(tabelaCMV.Rows[i][7]));
                                }
                            }
                            catch
                            {
                                CMVP = 0;
                            }

                            Graf1.Series["G2"].Points.AddXY(diaSemana, CMVV);
                        }
                    }


                    if (rdPercent.Checked)
                    {
                        Graf1.Series["G2"].Points.AddXY(("Total"), (Math.Round(Custo / Receita, 4) * 100));
                    }
                    else
                    {
                        Graf1.Series["G2"].Points.AddXY(("Total"), Math.Round(Custo / Pax, 2));

                    }

                    if (Custo == 0 || Receita == 0 || Pax == 0)
                    {
                        lbDetalh0203.Text = "";
                        lbDetalh0204.Text = "";
                    }
                    else
                    {
                        lbDetalh0203.Text = (Math.Round(Custo / Pax, 2)).ToString("R$ 0,0.00");
                        lbDetalh0204.Text = (Math.Round(Custo / Receita, 4) * 100).ToString("0.00") + "%";
                    }
                }
                else
                {

                }
            }
            #endregion

        }

        private void AtualizaGraf2()
        {
            Graf2.Series[0].Points.Clear();
            Graf2.Series[1].Points.Clear();

            if (liberado && cbGeral.Text != "")
            {
                //Variáveis
                double CMVV = 0;
                double Custo, Receita, Pax;
                double meta = 0;
                string diaSemana = "";

                DataTable tabelaCMV, tabelaMeta, TotalCmv;
                DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
                int unidade = Convert.ToInt32(cbUnidade.SelectedValue);

                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLCmvGraficos bll = new BLLCmvGraficos(cx);

                tabelaCMV = bll.ListaCmvPorGrupo(unidade, diaI, Convert.ToInt32(cbGeral.SelectedValue), 01);
                tabelaMeta = bll.MetaPorGrupo(Convert.ToInt32(cbGeral.SelectedValue));
                TotalCmv = bll.Total1CMVPorGrupo(unidade, diaI, Convert.ToInt32(cbGeral.SelectedValue), 01);

                Custo = 0;
                Receita = 0;
                Pax = 0;
                meta = Convert.ToDouble(tabelaMeta.Rows[0][0]);


                if (Convert.ToDouble(TotalCmv.Rows[0][7]) > 0 && Convert.ToDouble(TotalCmv.Rows[0][8]) > 0 && Convert.ToDouble(TotalCmv.Rows[0][9]) > 0)
                {


                    if (tabelaCMV.Rows.Count > 0)
                    {
                        for (int i = 0; i < tabelaCMV.Rows.Count; i++)
                        {
                            diaSemana = Dia(Convert.ToDateTime(tabelaCMV.Rows[i][0]));

                            Custo += ((Convert.ToDouble(tabelaCMV.Rows[i][1]) + Convert.ToDouble(tabelaCMV.Rows[i][2])) * -1);
                            Receita += Convert.ToDouble(tabelaCMV.Rows[i][3]) + Convert.ToDouble(tabelaCMV.Rows[i][4]);
                            Pax += Convert.ToDouble(tabelaCMV.Rows[i][6]) + Convert.ToDouble(tabelaCMV.Rows[i][7]);

                            if (rdPercent.Checked)
                            {
                                try
                                {
                                    if (Convert.ToDouble(tabelaCMV.Rows[i][1]) == 0 || Convert.ToDouble(tabelaCMV.Rows[i][3]) == 0)
                                    {
                                        CMVV = 0;
                                    }
                                    else
                                    {
                                        CMVV = ((Convert.ToDouble(tabelaCMV.Rows[i][1]) + Convert.ToDouble(tabelaCMV.Rows[i][2])) * -1) / (Convert.ToDouble(tabelaCMV.Rows[i][3]) + Convert.ToDouble(tabelaCMV.Rows[i][4]));
                                    }
                                }
                                catch
                                {
                                    CMVV = 0;
                                }
                                meta = Convert.ToDouble(tabelaMeta.Rows[0][1]);
                                Graf2.Series["Valores"].Points.AddXY(diaSemana, Math.Round(CMVV * 100, 2));
                                Graf2.Series["Meta"].Points.AddXY(diaSemana, Math.Round(meta * 100, 2));

                            }
                            else
                            {
                                try
                                {
                                    if (Convert.ToDouble(tabelaCMV.Rows[i][1]) == 0 || Convert.ToDouble(tabelaCMV.Rows[i][6]) == 0)
                                    {
                                        CMVV = 0;
                                    }
                                    else
                                    {
                                        CMVV = ((Convert.ToDouble(tabelaCMV.Rows[i][1]) + Convert.ToDouble(tabelaCMV.Rows[i][2])) * -1) / (Convert.ToDouble(tabelaCMV.Rows[i][6]) + Convert.ToDouble(tabelaCMV.Rows[i][7]));
                                    }
                                }
                                catch
                                {
                                    CMVV = 0;
                                }
                                meta = Convert.ToDouble(tabelaMeta.Rows[0][0]);
                                Graf2.Series["Valores"].Points.AddXY(diaSemana, Math.Round(CMVV, 2));
                                Graf2.Series["Meta"].Points.AddXY(diaSemana, Math.Round(meta, 2));



                            }
                        }
                    }
                    else { }

                    try
                    {
                        if (rdPercent.Checked)
                        {
                            meta = Convert.ToDouble(tabelaMeta.Rows[0][1]);
                            Graf2.Series["Valores"].Points.AddXY(("Total"), (Math.Round(Custo / Receita, 4) * 100));
                            Graf2.Series["Meta"].Points.AddXY("Total", (meta * 100));
                        }
                        else
                        {
                            meta = Convert.ToDouble(tabelaMeta.Rows[0][0]);
                            Graf2.Series["Valores"].Points.AddXY(("Total"), Math.Round(Custo / Pax, 2));
                            Graf2.Series["Meta"].Points.AddXY("Total", meta);

                        }
                        if (Custo == 0 || Receita == 0 || Pax == 0)
                        {
                            lbDetalh0303.Text = "";
                            lbDetalh0304.Text = "";
                        }
                        else
                        {
                            lbDetalh0303.Text = (Math.Round(Custo / Pax, 2)).ToString("R$ 0,0.00");
                            lbDetalh0304.Text = (Math.Round(Custo / Receita, 4) * 100).ToString("0.00") + "%";
                        }
                    }
                    catch

                    {

                    }
                }
                else { }

            }
            


        }

        private void AtualizaPizza1()
        {

            double custoA, custoB, custoL, receitaA, receitaB, receitaL;

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLCmvGraficos bll = new BLLCmvGraficos(cx);

            DataTable totalCusto, totalReceita;

            int grupo = Convert.ToInt32(cbComparativo01.SelectedValue.ToString());

            DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DateTime diaF = diaI.AddDays(-(diaI.Day - 1)).AddMonths(1).AddDays(-1);


            totalCusto = bll.TotalCustoPorGrupoETipo(unidade, diaI, diaF, "A", "01");
            try
            {
                custoA = Convert.ToDouble(totalCusto.Rows[0][0]) * -1;
            }
            catch
            {
                custoA = 0;
            }

            totalCusto = bll.TotalCustoPorGrupoETipo(unidade, diaI, diaF, "B", "01");
            try
            {
                custoB = Convert.ToDouble(totalCusto.Rows[0][0]) * -1;
            }
            catch
            {
                custoB = 0;
            }

            totalCusto = bll.TotalCustoPorGrupo(unidade, diaI, diaF, "02");

            try
            {
                custoL = Convert.ToDouble(totalCusto.Rows[0][0]) * -1;
            }
            catch
            {
                custoL = 0;
            }

            totalReceita = bll.TotalVendaPorGrupo(unidade, diaI, diaF, "A");

            try
            {
                receitaA = Convert.ToDouble(totalReceita.Rows[0][0]);
            }
            catch
            {
                receitaA = 0;
            }

            totalReceita = bll.TotalVendaPorGrupo(unidade, diaI, diaF, "B");

            try
            {
                receitaB = Convert.ToDouble(totalReceita.Rows[0][0]);
            }
            catch
            {
                receitaB = 0;
            }

            totalReceita = bll.TotalVendaPorGrupo(unidade, diaI, diaF, "D");

            try
            {
                receitaL = Convert.ToDouble(totalReceita.Rows[0][0]);
            }
            catch
            {
                receitaL = 0;
            }

            lbC1.Text = $"R$ {custoA.ToString("#,0.00")}";
            lbC2.Text = $"R$ {custoB.ToString("#,0.00")}";
            lbC3.Text = $"R$ {custoL.ToString("#,0.00")}";
            lbR1.Text = $"R$ {receitaA.ToString("#,0.00")}";
            lbR2.Text = $"R$ {receitaB.ToString("#,0.00")}";
            lbR3.Text = $"R$ {receitaL.ToString("#,0.00")}";

            lbt0101.Text = cbComparativo01.Text + " META $";
            lbt0102.Text = cbComparativo01.Text + " META %";
            lbt0103.Text = cbComparativo01.Text + " REALIZADO $";
            lbt0104.Text = cbComparativo01.Text + " REALIZADO %";

            lbt0201.Text = cbComparativo02.Text + " META $";
            lbt0202.Text = cbComparativo02.Text + " META %";
            lbt0203.Text = cbComparativo02.Text + " REALIZADO $";
            lbt0204.Text = cbComparativo02.Text + " REALIZADO %";

            lbt0301.Text = cbGeral.Text + " META $";
            lbt0302.Text = cbGeral.Text + " META %";
            lbt0303.Text = cbGeral.Text + " REALIZADO $";
            lbt0304.Text = cbGeral.Text + " REALIZADO %";


            //PREENCHE PIZZA 01

            #region PIZZA 01

            Pizza1.Series.Clear();


            Series series1 = new Series
            {
                Name = "Custo",
                IsVisibleInLegend = true,
                Color = System.Drawing.Color.Green,
                ChartType = SeriesChartType.Pie
            };
            Pizza1.Series.Add(series1);


            string percent1, percent2, percent3;


            if ((Math.Round(custoA / (custoA + custoB + custoL), 2)) * 100 >= 5)
            {
                percent1 = ((Math.Round(custoA / (custoA + custoB + custoL), 2)) * 100).ToString() + "%";
            }
            else
            {
                percent1 = "";
            }
            if ((Math.Round(custoB / (custoA + custoB + custoL), 2)) * 100 >= 5)
            {
                percent2 = ((Math.Round(custoB / (custoA + custoB + custoL), 2)) * 100).ToString() + "%";
            }
            else
            {
                percent2 = "";
            }
            if ((Math.Round(custoL / (custoA + custoB + custoL), 2)) * 100 >= 5)
            {
                percent3 = ((Math.Round(custoL / (custoA + custoB + custoL), 2)) * 100).ToString() + "%";
            }
            else
            {
                percent3 = "";
            }

            series1.Points.Add(custoA).Color = Color.FromArgb(200, 100, 100);
            series1.Points.Add(custoB).Color = Color.FromArgb(0, 155, 219);
            series1.Points.Add(custoL).Color = Color.FromArgb(61, 96, 32);

            var p1 = series1.Points[0];
            p1.AxisLabel = percent1;

            var p2 = series1.Points[1];
            p2.AxisLabel = percent2;

            var p3 = series1.Points[2];
            p3.AxisLabel = percent3;


            #endregion

            #region PIZZA 02

            Pizza2.Series.Clear();


            Series series2 = new Series
            {
                Name = "Custo",
                IsVisibleInLegend = true,
                Color = System.Drawing.Color.Green,
                ChartType = SeriesChartType.Pie
            };

            Pizza2.Series.Add(series2);


            string percent4, percent5, percent6;


            if ((Math.Round(receitaA / (receitaA + receitaB + receitaL), 2)) * 100 >= 5)
            {
                percent4 = ((Math.Round(receitaA / (receitaA + receitaB + receitaL), 2)) * 100).ToString() + "%";
            }
            else
            {
                percent4 = "";
            }
            if ((Math.Round(receitaB / (receitaA + receitaB + receitaL), 2)) * 100 >= 5)
            {
                percent5 = ((Math.Round(receitaB / (receitaA + receitaB + receitaL), 2)) * 100).ToString() + "%";
            }
            else
            {
                percent5 = "";
            }
            if ((Math.Round(receitaL / (receitaA + receitaB + receitaL), 2)) * 100 >= 5)
            {
                percent6 = ((Math.Round(receitaL / (receitaA + receitaB + receitaL), 2)) * 100).ToString() + "%";
            }
            else
            {
                percent6 = "";
            }

            series2.Points.Add(receitaA).Color = Color.FromArgb(200, 100, 100);
            series2.Points.Add(receitaB).Color = Color.FromArgb(0, 155, 219);
            series2.Points.Add(receitaL).Color = Color.FromArgb(61, 96, 32);

            var p4 = series2.Points[0];
            p4.AxisLabel = percent4;

            var p5 = series2.Points[1];
            p5.AxisLabel = percent5;

            var p6 = series2.Points[2];
            p6.AxisLabel = percent6;


            #endregion



        }

        private void AtualizaDetalhes()
        {

            if (liberado)
            {
                double MetaV, MetaP;
                DataTable totalCusto, totalReceita, meta;

                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLCmvGraficos bll = new BLLCmvGraficos(cx);

                DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
                DateTime diaF = diaI.AddDays(-(diaI.Day - 1)).AddMonths(1).AddDays(-1);
                DateTime DiaA = diaI;
                int unidade = Convert.ToInt32(cbUnidade.SelectedValue);


                int grupo = Convert.ToInt32(cbComparativo01.SelectedValue);

                totalCusto = bll.TotalCustoPorGrupo(unidade, diaI, diaF, grupo);
                totalReceita = bll.TotalReceitaPorGrupo(unidade, diaI, diaF, grupo);

                meta = bll.MetaPorGrupo(grupo);

                MetaV = 0;
                MetaP = 0;

                try
                {
                    MetaV = Convert.ToDouble(meta.Rows[0][0]);
                }
                catch
                {
                    MetaV = 0;
                }
                finally
                {
                    if (MetaV > 0)
                    {
                        lbDetalh0101.Text = $"R$ {MetaV.ToString("#,0.00")}";
                    }
                    else
                    {
                        lbDetalh0101.Text = "-";
                    }
                }

                try
                {
                    MetaP = Convert.ToDouble(meta.Rows[0][1]);
                }
                catch
                {
                    MetaP = 0;
                }
                finally
                {
                    if (MetaP > 0)
                    {
                        lbDetalh0102.Text = $"{(MetaP * 100).ToString()}%";
                    }
                    else
                    {
                        lbDetalh0102.Text = "-";
                    }
                }



                grupo = Convert.ToInt32(cbComparativo02.SelectedValue);

                totalCusto = bll.TotalCustoPorGrupo(unidade, diaI, diaF, grupo);
                totalReceita = bll.TotalReceitaPorGrupo(unidade, diaI, diaF, grupo);


                meta = bll.MetaPorGrupo(grupo);

                MetaV = 0;
                MetaP = 0;

                try
                {
                    MetaV = Convert.ToDouble(meta.Rows[0][0]);
                }
                catch
                {
                    MetaV = 0;
                }
                finally
                {
                    if (MetaV > 0)
                    {
                        lbDetalh0201.Text = $"R$ {MetaV.ToString("#,0.00")}";
                    }
                    else
                    {
                        lbDetalh0201.Text = "-";
                    }
                }

                try
                {
                    MetaP = Convert.ToDouble(meta.Rows[0][1]);
                }
                catch
                {
                    MetaP = 0;
                }
                finally
                {
                    if (MetaP > 0)
                    {
                        lbDetalh0202.Text = $"{(MetaP * 100).ToString()}%";
                    }
                    else
                    {
                        lbDetalh0202.Text = "-";
                    }
                }


                grupo = Convert.ToInt32(cbGeral.SelectedValue);
                DataTable totalPax = bll.TotalPaxPorUnidade(unidade, diaI, diaF);
                totalCusto = bll.TotalCustoPorGrupo(unidade, diaI, diaF, grupo);
                totalReceita = bll.TotalReceitaPorGrupo(unidade, diaI, diaF, grupo);

                meta = bll.MetaPorGrupo(grupo);

                MetaV = 0;
                MetaP = 0;

                try
                {
                    MetaV = Convert.ToDouble(meta.Rows[0][0]);
                }
                catch
                {
                    MetaV = 0;
                }
                finally
                {
                    if (MetaV > 0)
                    {
                        lbDetalh0301.Text = $"R$ {MetaV.ToString("#,0.00")}";
                    }
                    else
                    {
                        lbDetalh0301.Text = "-";
                    }
                }

                try
                {
                    MetaP = Convert.ToDouble(meta.Rows[0][1]);
                }
                catch
                {
                    MetaP = 0;
                }
                finally
                {
                    if (MetaP > 0)
                    {
                        lbDetalh0302.Text = $"{(MetaP * 100).ToString()}%";
                    }
                    else
                    {
                        lbDetalh0302.Text = "-";
                    }
                }

            }
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
        
        private void chart2_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {

                #region VerificaX

                var pos = e.Location;
                if (prevPosition.HasValue && pos == prevPosition.Value)
                    return;
                tooltip.RemoveAll();
                prevPosition = pos;
                var results = Graf2.HitTest(pos.X, pos.Y, false, ChartElementType.PlottingArea);

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
                HitTestResult resultado = Graf2.HitTest(e.X, e.Y);

                // Reset Data Point Attributes
                foreach (DataPoint point in Graf2.Series[0].Points)
                {
                    point.BackSecondaryColor = Color.Black;
                    point.BackHatchStyle = ChartHatchStyle.None;
                    point.BorderWidth = 1;
                }
                foreach (DataPoint point in Graf2.Series[1].Points)
                {
                    point.BackSecondaryColor = Color.Black;
                    point.BackHatchStyle = ChartHatchStyle.None;
                    point.BorderWidth = 1;
                }

                // If the mouse if over a data point
                if (resultado.ChartElementType == ChartElementType.DataPoint)
                {
                    // Find selected data point
                    DataPoint point = Graf2.Series[0].Points[resultado.PointIndex];
                    DataPoint point1 = Graf2.Series[1].Points[resultado.PointIndex];

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
            catch { }
        }
        
        private void chart2_Click(object sender, EventArgs e)
        {

            DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DateTime diaF = diaI.AddDays(-(diaI.Day - 1)).AddMonths(1).AddDays(-1);
            DateTime diaA;


            string titulo;
            int dia;
            int grupo = Convert.ToInt32(cbGeral.SelectedValue);

            if (pontoAtual > 0)
            {
                if (pontoAtual > diaF.Day)
                {
                    titulo = cbGeral.Text + " (" + cbMes.Text + ")";
                    dia = 32;
                    frmDetalheGrafico f = new frmDetalheGrafico(pontoAtual, titulo, grupo, diaI, diaF, unidade, true, true);
                    f.ShowDialog();
                    f.Dispose();

                }
                else
                {
                    diaA = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), pontoAtual);
                    titulo = cbGeral.Text + " (" + pontoAtual.ToString("00") + "/" + Convert.ToInt32(cbMes.SelectedValue).ToString("00") + ")";
                    dia = pontoAtual;
                    frmDetalheGrafico f = new frmDetalheGrafico(pontoAtual, titulo, grupo, diaA, diaA, unidade, true, true);
                    f.ShowDialog();
                    f.Dispose();

                }


            }
        }

        private void cbComparativo01_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbComparativo01.Text != "" && cbComparativo02.Text != "")
            {
                lbComparativo.Text = $"COMPARATIVO ENTRE {cbComparativo01.Text} e {cbComparativo02.Text}";
            }

            if (cbComparativo01.Text != "" && cbComparativo02.Text == "")
            {
                lbComparativo.Text = $"{cbComparativo01.Text}";
            }

            if (cbComparativo01.Text == "" && cbComparativo02.Text != "")
            {
                lbComparativo.Text = $"{cbComparativo02.Text}";
            }

            if (cbComparativo01.Text == "" && cbComparativo02.Text == "")
            {
                lbComparativo.Text = $"";
            }

            if (liberado)
            {
                Properties.Settings.Default.cbComp01 = cbComparativo01.Text;
                Properties.Settings.Default.Save();
            }
            AtualizaGraf1();
            AtualizaDetalhes();

        }

        private void cbGeral_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liberado)
            {
                Properties.Settings.Default.cbGeral = cbGeral.Text;
                Properties.Settings.Default.Save();
            }

            AtualizaGraf2();
            AtualizaDetalhes();
        }

        private void btAnt_Click(object sender, EventArgs e)
        {
            if(MesToInt(cbMes.Text) != 1)
            {
                liberado = false;   
                cbMes.Text = IntToMes(MesToInt(cbMes.Text)-1);
                liberado = true;
                AtualizaCharts();
            }else
            {
                liberado = false;
                cbMes.Text = IntToMes(12);
                numAno.Value = numAno.Value - 1;
                liberado = true;
                AtualizaCharts();
            }
        }

        private void btPos_Click(object sender, EventArgs e)
        {
            if (MesToInt(cbMes.Text) != 12)
            {
                liberado = false;
                cbMes.Text = IntToMes(MesToInt(cbMes.Text) + 1);
                liberado = true;
                AtualizaCharts();
            }
            else
            {
                liberado = false;
                cbMes.Text = IntToMes(1);
                numAno.Value = numAno.Value + 1;
                liberado = true;
                AtualizaCharts();
            }
        }

        private void cbComparativo02_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbComparativo01.Text != "" && cbComparativo02.Text != "")
            {
                lbComparativo.Text = $"COMPARATIVO ENTRE {cbComparativo01.Text} e {cbComparativo02.Text}";
            }

            if (cbComparativo01.Text != "" && cbComparativo02.Text == "")
            {
                lbComparativo.Text = $"{cbComparativo01.Text}";
            }

            if (cbComparativo01.Text == "" && cbComparativo02.Text != "")
            {
                lbComparativo.Text = $"{cbComparativo02.Text}";
            }

            if (cbComparativo01.Text == "" && cbComparativo02.Text == "")
            {
                lbComparativo.Text = $"";
            }

            if (liberado)
            {
                Properties.Settings.Default.cbComp02 = cbComparativo02.Text;
                Properties.Settings.Default.Save();
            }

            AtualizaGraf1();

        }

        private void CarregarConfigs()
        {


        }

    }
}
