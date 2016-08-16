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
using System.Windows.Forms.DataVisualization.Charting;


namespace GUI
{
    public partial class frmCMVGestaoAVista : Form
    {
        int idUsuario, unidade, pontoAtual;
        bool inicializado = false;
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        public frmCMVGestaoAVista(int id)
        {
            idUsuario = id;
            InitializeComponent();
        }

        private void frmCMVGestaoAVista_Load(object sender, EventArgs e)
        {
            inicializado = false;
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(cx);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(Convert.ToInt32(idUsuario));

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";

            BLLUnidade bllun = new BLLUnidade(cx);

            cbUnidade.DataSource = bllun.ListarUnidades();

            cbUnidade.DisplayMember = "cod_unidade";
            cbUnidade.ValueMember = "id_unidade";
            cbUnidade.Text = modelou.IdUnidade.ToString();

            
            if (modelou.PermissaoUsuario < 4)
            {
                cbUnidade.Enabled = false;
            }

           DateTime data = DateTime.Today;

            numAno.Value = data.Year;

            CarregaMes();
            inicializado = true;
            AtualizaPagina();
        }

        private void AtualizaPagina()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUnidade bllun = new BLLUnidade(cx);
            DTOUnidade dto = bllun.CarregaModeloUnidade(Convert.ToInt32(cbUnidade.SelectedValue.ToString()));

            unidade = Convert.ToInt32(cbUnidade.SelectedValue);

            BLLConfigUnidade bllconfig = new BLLConfigUnidade(cx);
            DataTable Config = bllconfig.LocalizarConfig("TURNOS_VENDA", unidade);


            if (Config.Rows[0][0].ToString() != "Dia")
            {

                var dataSourceG1 = new List<Language>();
                dataSourceG1.Add(new Language() { Name = "Dia e noite", Value = "1" });
                dataSourceG1.Add(new Language() { Name = "Alimentos e bebidas", Value = "2" });


                //Adicionar ao ComboBox
                this.cbComparativo.DataSource = dataSourceG1;
                this.cbComparativo.DisplayMember = "Name";
                this.cbComparativo.ValueMember = "Value";
                this.cbComparativo.SelectedIndex = 0;

            }
            else
            {
                var dataSourceG1 = new List<Language>();
                
                dataSourceG1.Add(new Language() { Name = "Alimentos e bebidas", Value = "1" });


                //Adicionar ao ComboBox
                this.cbComparativo.DataSource = dataSourceG1;
                this.cbComparativo.DisplayMember = "Name";
                this.cbComparativo.ValueMember = "Value";
                this.cbComparativo.SelectedIndex = 0;
            }



            lbTitulo.Text = $"CMV - {dto.NomeUnidade} - {cbMes.Text.ToUpper()}/{numAno.Value}";
            atualizaChards();
        }

        public class Language
        {
            public string Name { get; set; }
            public string Value { get; set; }
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

        private void atualizaChards()
        {
            CarregaDiaENoite();
        }

        private void CarregaDiaENoite()
        {

            graficoComparativo1.Series[0].Points.Clear();
            graficoComparativo1.Series[1].Points.Clear();

            DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);

            DateTime diaF = diaI.AddDays(-(diaI.Day - 1)).AddMonths(1).AddDays(-1);

            DateTime DiaA = diaI;

            int unidade = Convert.ToInt32(cbUnidade.SelectedValue);

            int paxD, paxN, p, c;
            double cmvD, cmvN;

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLConsultaCMV bll = new BLLConsultaCMV(cx);

            DataTable TabelaCustoD, TabelaCustoN, TabelaPax, totalCustoD, totalCustoN, totalCusto, totalPaxD, totalPaxN;

            TabelaCustoD = bll.TabelaCustoPorTutno(unidade, diaI, diaF, "a");
            TabelaCustoN = bll.TabelaCustoPorTutno(unidade, diaI, diaF, "j");
            TabelaPax = bll.TabelaPaxPorDia(unidade, diaI, diaF);



            totalCustoD = bll.TotalCustoAeB(unidade, diaI, diaF, "a");
            totalCustoN = bll.TotalCustoAeB(unidade, diaI, diaF, "j");
            totalCusto = bll.TotalCustoAeBGeral(unidade, diaI, diaF);
            totalPaxD = bll.TotalPax(unidade, diaI, diaF, 1);
            totalPaxN = bll.TotalPax(unidade, diaI, diaF, 0);

            DiaA = diaI;
            p = 0;
            c = 0;

            if (cbComparativo.SelectedValue.ToString() == "1")
            {
                cmvD = 0;
                cmvN = 0;


                for (int i = 0; i < diaF.Day; i++)
                {
                    try
                    {
                        if (Convert.ToDateTime(TabelaCustoD.Rows[c][0]) != Convert.ToDateTime(TabelaPax.Rows[p][0]))
                        {
                            if (Convert.ToDateTime(TabelaCustoD.Rows[c][0]) > Convert.ToDateTime(TabelaPax.Rows[p][0]))
                            {
                                cmvD = 0;
                                p++;
                            }
                            else
                            {
                                cmvD = 0;
                                c++;
                            }
                        }
                        else
                        {
                            if (Convert.ToDateTime(TabelaCustoD.Rows[c][0]) == DiaA)
                            {
                                cmvD = Math.Round(Convert.ToDouble(TabelaCustoD.Rows[c][1]) / Convert.ToDouble(TabelaPax.Rows[p][1]), 2) * -1;
                                c++;
                                p++;
                            }
                            else
                            {
                                cmvD = 0;
                            }
                        }
                    }
                    catch
                    {
                        cmvD = 0;
                        p++;
                        c++;
                    }
                    graficoComparativo1.Series["Dia"].Points.AddXY(DiaA.Day.ToString(), cmvD);
                    DiaA = DiaA.AddDays(1);
                }

                DiaA = diaI;
                p = 0;
                c = 0;

                for (int i = 0; i < diaF.Day; i++)
                {
                    try
                    {
                        if (Convert.ToDateTime(TabelaCustoN.Rows[c][0]) != Convert.ToDateTime(TabelaPax.Rows[p][0]))
                        {
                            if (Convert.ToDateTime(TabelaCustoN.Rows[c][0]) > Convert.ToDateTime(TabelaPax.Rows[p][0]))
                            {
                                cmvN = 0;
                                p++;
                            }
                            else
                            {
                                cmvN = 0;
                                c++;
                            }
                        }
                        else
                        {
                            if (Convert.ToDateTime(TabelaCustoN.Rows[c][0]) == DiaA)
                            {
                                cmvN = Math.Round(Convert.ToDouble(TabelaCustoN.Rows[c][1]) / Convert.ToDouble(TabelaPax.Rows[p][1]), 2) * -1;
                                c++;
                                p++;
                            }
                            else
                            {
                                cmvN = 0;
                            }
                        }
                    }
                    catch
                    {
                        cmvN = 0;
                        p++;
                        c++;
                    }
                    graficoComparativo1.Series["Noite"].Points.AddXY(DiaA.Day.ToString(), cmvN);
                    DiaA = DiaA.AddDays(1);
                }



                try
                {
                    paxD = Convert.ToInt32(totalPaxD.Rows[0][0]);
                    paxN = Convert.ToInt32(totalPaxN.Rows[0][0]);

                    cmvD = Convert.ToDouble(totalCustoD.Rows[0][0]) / (paxD + paxN);
                    cmvN = Convert.ToDouble(totalCustoN.Rows[0][0]) / (paxD + paxN);

                    graficoComparativo1.Series["Dia"].Points.AddXY("Total", Math.Round(cmvD * -1, 2));
                    graficoComparativo1.Series["Noite"].Points.AddXY("Total", Math.Round(cmvN * -1, 2));

                }
                catch { }


            }
            else
            {

            }
        }
       
        void CarregarPizza1()
        {

            DateTime Diai = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);

            DateTime Diaf = Diai.AddDays(-(Diai.Day - 1)).AddMonths(1).AddDays(-1);

            DateTime DiaA = Diai;

            int unidade = Convert.ToInt32(cbUnidade.SelectedValue);
            
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLConsultaCMV bll = new BLLConsultaCMV(cx);

            DataTable tabela;

            ComparativoCusto.Series.Clear();
                        
            
            Series series1 = new Series
            {
                Name = "Serie1",
                IsVisibleInLegend = true,
                Color = System.Drawing.Color.Green,
                ChartType = SeriesChartType.Pie
            };
            ComparativoCusto.Series.Add(series1);

            double valor1, valor2, valor3;
            string percent1, percent2, percent3;

            tabela = bll.TotalCustoPorTipo(unidade, "a", Diai, Diaf);
            try { valor1 = Convert.ToDouble(tabela.Rows[0][0]); }catch { valor1 = 0; }

            tabela = bll.TotalCustoPorTipo(unidade, "b", Diai, Diaf);

            try { valor2 = Convert.ToDouble(tabela.Rows[0][0]); } catch { valor2 = 0; }

            tabela = bll.TotalCustoPorTipo(unidade, "o", Diai, Diaf);
            try { valor3 = Convert.ToDouble(tabela.Rows[0][0]); } catch { valor3 = 0; }

            if ((Math.Round(valor1 / (valor1 + valor2 + valor3), 2)) * 100 >= 5)
            {
                percent1 = ((Math.Round(valor1 / (valor1 + valor2 + valor3), 2)) * 100).ToString() + "%";
            }else
            {
                percent1 = "";
            }
            if ((Math.Round(valor2 / (valor1 + valor2 + valor3), 2)) * 100 >= 5)
            {
                percent2 = ((Math.Round(valor2 / (valor1 + valor2 + valor3), 2)) * 100).ToString() + "%";
            }
            else
            {
                percent2 = "";
            }
            if ((Math.Round(valor3 / (valor1 + valor2 + valor3), 2)) * 100 >= 5)
            {
                percent3 = ((Math.Round(valor3 / (valor1 + valor2 + valor3), 2)) * 100).ToString() + "%";
            }
            else
            {
                percent3 = "";
            }
            
            series1.Points.Add(valor1);
            series1.Points.Add(valor2);
            series1.Points.Add(valor3);

            var p1 = series1.Points[0];            
            p1.AxisLabel = percent1;
            p1.LegendText = "Alimentos";

            var p2 = series1.Points[1];
            p2.AxisLabel = percent2;
            p2.LegendText = "Bebidas";

            var p3 = series1.Points[2];
            p3.AxisLabel = percent3;
            p3.LegendText = "Outros";
        }
        
        private void cbUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializado)
            {
                AtualizaPagina();
            }
        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializado)
            {
                atualizaChards();
            }
        }

        private void frmCMVGestaoAVista_SizeChanged(object sender, EventArgs e)
        {
            double tamanhoTela = this.Size.Width;

            graficoComparativo1.Width = Convert.ToInt32(tamanhoTela - 30);
        }

        private void graficoComparativo1_MouseMove(object sender, MouseEventArgs e)
        {
        
            #region VerificaX

            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = graficoComparativo1.HitTest(pos.X, pos.Y, false, ChartElementType.PlottingArea);

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
            HitTestResult resultado = graficoComparativo1.HitTest(e.X, e.Y);

            // Reset Data Point Attributes
            foreach (DataPoint point in graficoComparativo1.Series[0].Points)
            {
                point.BackSecondaryColor = Color.Black;
                point.BackHatchStyle = ChartHatchStyle.None;
                point.BorderWidth = 1;
            }
            foreach (DataPoint point in graficoComparativo1.Series[1].Points)
            {
                point.BackSecondaryColor = Color.Black;
                point.BackHatchStyle = ChartHatchStyle.None;
                point.BorderWidth = 1;
            }

            // If the mouse if over a data point
            if (resultado.ChartElementType == ChartElementType.DataPoint)
            {
                // Find selected data point
                DataPoint point = graficoComparativo1.Series[0].Points[resultado.PointIndex];
                DataPoint point1 = graficoComparativo1.Series[1].Points[resultado.PointIndex];

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

        private void numAno_ValueChanged(object sender, EventArgs e)
        {
            if (inicializado)
            {
                AtualizaPagina();
            }
        }
    }
}
