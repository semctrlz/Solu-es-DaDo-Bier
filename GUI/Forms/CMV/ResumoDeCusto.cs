using GUI.Code.BLL;
using GUI.Code.DAL;
using GUI.Code.DTO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI.Forms.CMV
{
    public partial class ResumoDeCusto : Form
    {
        #region Variáveis

        uint mesAtual, mesSelecionado;
        string selecaoMes;
        DateTime dataSelecionada;
        int idUsuario, unidade, pontoAtual;
        bool Liberado;
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();

        #endregion

        #region Inicialização

        public ResumoDeCusto(uint id)
        {
            idUsuario = Convert.ToInt32(id);

        }

        private void frmCMVSecoes_Load(object sender, EventArgs e)
        {
           
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(Convert.ToInt32(idUsuario));

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUnidade bllun = new BLLUnidade(cx);
            cbUnidade.DataSource = bllun.Localizar("");
            cbUnidade.DisplayMember = "cod_unidade";
            cbUnidade.ValueMember = "id_unidade";
cbUnidade.Text = modelou.IdUnidade.ToString("00");

            unidade = modelou.IdUnidade;


            if (modelou.PermissaoUsuario < 4)
            {

                cbUnidade.Enabled = false;
            }

            #region Case Mês
            txtAno.Value = Convert.ToUInt32(DateTime.Now.Year);
            mesAtual = Convert.ToUInt32(DateTime.Now.Month);

            switch (mesAtual)
            {
                case 1:
                    selecaoMes = "Janeiro";
                    break;
                case 2:
                    selecaoMes = "Fevereiro";
                    break;
                case 3:
                    selecaoMes = "Março";
                    break;
                case 4:
                    selecaoMes = "Abril";
                    break;
                case 5:
                    selecaoMes = "Maio";
                    break;
                case 6:
                    selecaoMes = "Junho";
                    break;
                case 7:
                    selecaoMes = "Julho";
                    break;
                case 8:
                    selecaoMes = "Agosto";
                    break;
                case 9:
                    selecaoMes = "Setembro";
                    break;
                case 10:
                    selecaoMes = "Outubro";
                    break;
                case 11:
                    selecaoMes = "Novembro";
                    break;
                case 12:
                    selecaoMes = "Dezembro";
                    break;
                default:
                    selecaoMes = "";
                    break;
            }

            #endregion

            mesSelecionado = mesAtual;
            cbMes.Text = selecaoMes;
            
            mesAtual = Convert.ToUInt32(DateTime.Now.Month);


            //Oculta os dias desnecessários
            
            redefineMesSelecionado();
            VerificaDias();
            AtualizaDados();


            AtualizaChart();
            //Libera para edição

            Liberado = true;
           
    
        }

        #endregion

        #region Clique/MouseMove

        private void btAddVenda_Click(object sender, EventArgs e)
        {
            frmExcelToDB f = new frmExcelToDB(Convert.ToUInt32(idUsuario));
            this.Hide();
            f.ShowDialog();
            this.Show();
            f.Dispose();
            AtualizaDados();
            AtualizaChart();

        }

        private void btAddCusto_Click(object sender, EventArgs e)
        {
            btAddVenda_Click(sender, e);
        }

        private void btExclui01_Click(object sender, EventArgs e)
        {
            Excluir(1);
            AtualizaChart();
        }

        private void btExclui02_Click(object sender, EventArgs e)
        {
            Excluir(2);
            AtualizaChart();
        }

        private void btExclui03_Click(object sender, EventArgs e)
        {
            Excluir(3);
            AtualizaChart();
        }

        private void btExclui04_Click(object sender, EventArgs e)
        {
            Excluir(4);
            AtualizaChart();
        }

        private void btExclui05_Click(object sender, EventArgs e)
        {
            Excluir(5);
            AtualizaChart();
        }

        private void btExclui06_Click(object sender, EventArgs e)
        {
            Excluir(6);
            AtualizaChart();
        }

        private void btExclui07_Click(object sender, EventArgs e)
        {
            Excluir(7);
            AtualizaChart();
        }

        private void btExclui08_Click(object sender, EventArgs e)
        {
            Excluir(8);
            AtualizaChart();
        }

        private void btExclui09_Click(object sender, EventArgs e)
        {
            Excluir(9);
            AtualizaChart();
        }

        private void btExclui10_Click(object sender, EventArgs e)
        {
            Excluir(10);
            AtualizaChart();
        }

        private void btExclui11_Click(object sender, EventArgs e)
        {
            Excluir(11);
            AtualizaChart();
        }

        private void btExclui12_Click(object sender, EventArgs e)
        {
            Excluir(12);
            AtualizaChart();
        }

        private void btExclui13_Click(object sender, EventArgs e)
        {
            Excluir(13);
            AtualizaChart();
        }

        private void btExclui14_Click(object sender, EventArgs e)
        {
            Excluir(14);
            AtualizaChart();
        }

        private void btExclui15_Click(object sender, EventArgs e)
        {
            Excluir(15);
            AtualizaChart();
        }

        private void btExclui16_Click(object sender, EventArgs e)
        {
            Excluir(16);
            AtualizaChart();
        }

        private void btExclui17_Click(object sender, EventArgs e)
        {
            Excluir(17);
            AtualizaChart();
        }

        private void btExclui18_Click(object sender, EventArgs e)
        {
            Excluir(18);
            AtualizaChart();
        }

        private void btExclui19_Click(object sender, EventArgs e)
        {
            Excluir(19);
            AtualizaChart();
        }

        private void btExclui20_Click(object sender, EventArgs e)
        {
            Excluir(20);
            AtualizaChart();
        }

        private void btExclui21_Click(object sender, EventArgs e)
        {
            Excluir(21);
            AtualizaChart();
        }

        private void btExclui22_Click(object sender, EventArgs e)
        {
            Excluir(22);
            AtualizaChart();
        }

        private void btExclui23_Click(object sender, EventArgs e)
        {
            Excluir(23);
            AtualizaChart();
        }

        private void btExclui24_Click(object sender, EventArgs e)
        {
            Excluir(24);
            AtualizaChart();
        }

        private void btExclui25_Click(object sender, EventArgs e)
        {
            Excluir(25);
            AtualizaChart();
        }

        private void btExclui26_Click(object sender, EventArgs e)
        {
            Excluir(26);
            AtualizaChart();
        }

        private void btExclui27_Click(object sender, EventArgs e)
        {
            Excluir(27);
            AtualizaChart();
        }

        private void btExclui28_Click(object sender, EventArgs e)
        {
            Excluir(28);
            AtualizaChart();
        }

        private void btExclui29_Click(object sender, EventArgs e)
        {
            Excluir(29);
            AtualizaChart();
        }

        private void btExclui30_Click(object sender, EventArgs e)
        {
            Excluir(30);
            AtualizaChart();
        }

        private void btExclui31_Click(object sender, EventArgs e)
        {
            Excluir(31);
            AtualizaChart();
        }

        private void graficoVendaPax_Click(object sender, EventArgs e)
        {
            if (pontoAtual > 0)
            {
                MessageBox.Show($"Você clicou no dia {pontoAtual.ToString()}");
            }
        }

        private void graficoVendaPax_MouseMove(object sender, MouseEventArgs e)
        {
            #region VerificaX

            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = graficoVendaPax.HitTest(pos.X, pos.Y, false, ChartElementType.PlottingArea);

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
            HitTestResult resultado = graficoVendaPax.HitTest(e.X, e.Y);

            // Reset Data Point Attributes
            foreach (DataPoint point in graficoVendaPax.Series[0].Points)
            {
                point.BackSecondaryColor = Color.Black;
                point.BackHatchStyle = ChartHatchStyle.None;
                point.BorderWidth = 1;
            }

            // If the mouse if over a data point
            if (resultado.ChartElementType == ChartElementType.DataPoint)
            {
                // Find selected data point
                DataPoint point = graficoVendaPax.Series[0].Points[resultado.PointIndex];

                // Change the appearance of the data point
                point.BackSecondaryColor = Color.White;
                point.BackHatchStyle = ChartHatchStyle.Percent25;
                point.BorderWidth = 2;
                
               // label3.Text = graficoVendaPax.Series[0].Points[resultado.PointIndex].ToString();

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

        #endregion

        #region Change

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Liberado)
            {
                redefineMesSelecionado();
                AtualizaDados();
                VerificaDias();
                AtualizaChart();
            }
           
        }

        private void txtAno_ValueChanged(object sender, EventArgs e)
        {
            if (Liberado)
            {
                redefineMesSelecionado();
                VerificaDias();
                AtualizaDados();
                AtualizaChart();
            }
           
        }

        private void cbUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Liberado)
            {
                redefineMesSelecionado();
                VerificaDias();
                AtualizaDados();
            }
        }

        #endregion

        #region Outros

        private void VerificaDias()
        {

            
            mesSelecionado = Convert.ToUInt32(dataSelecionada.Month);

            pn01.Visible = true;
            pn02.Visible = true;
            pn03.Visible = true;
            pn04.Visible = true;
            pn05.Visible = true;
            pn06.Visible = true;
            pn07.Visible = true;
            pn08.Visible = true;
            pn09.Visible = true;
            pn10.Visible = true;
            pn11.Visible = true;
            pn12.Visible = true;
            pn13.Visible = true;
            pn14.Visible = true;
            pn15.Visible = true;
            pn16.Visible = true;
            pn17.Visible = true;
            pn18.Visible = true;
            pn19.Visible = true;
            pn20.Visible = true;
            pn21.Visible = true;
            pn22.Visible = true;
            pn23.Visible = true;
            pn24.Visible = true;
            pn25.Visible = true;
            pn26.Visible = true;
            pn27.Visible = true;
            pn28.Visible = true;
            pn29.Visible = true;
            pn30.Visible = true;
            pn31.Visible = true;


            if(mesSelecionado == 4 || mesSelecionado == 6 || mesSelecionado == 9 || mesSelecionado == 11)
            {
                pn31.Visible = false;
            }
            else if (mesSelecionado == 2)
            {
                    pn30.Visible = false;
                    pn31.Visible = false;

                if (Convert.ToUInt32(txtAno.Value)%4 != 0)
                {
                    pn29.Visible = false;
                }
            }


            #region PosicionaDias

            int BaseX = 6;
            int BaseY = 40;
            
            int ajuste = 106;

            int indicex = Convert.ToInt32(dataSelecionada.DayOfWeek);
            int indicey = 0;

            pn01.Location = new Point(BaseX+(ajuste*indicex), BaseY+(ajuste*indicey));
            indicex++;
            if(indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn02.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn03.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn04.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn05.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn06.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn07.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn08.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn09.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn10.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn11.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn12.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn13.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn14.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn15.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn16.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn17.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn18.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn19.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn20.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn21.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn22.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn23.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn24.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn25.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn26.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn27.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn28.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn29.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn30.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }

            pn31.Location = new Point(BaseX + (ajuste * indicex), BaseY + (ajuste * indicey));
            indicex++;
            if (indicex == 7)
            {
                indicex = 0;
                indicey++;
            }



            #endregion

            #region ColoreDias


            Color domSab = Color.FromArgb(200, 170, 168);
            Color padrao = Color.FromArgb(200, 200, 200);


            pn01.BackColor = padrao;
            pn02.BackColor = padrao;
            pn03.BackColor = padrao;
            pn04.BackColor = padrao;
            pn05.BackColor = padrao;
            pn06.BackColor = padrao;
            pn07.BackColor = padrao;
            pn08.BackColor = padrao;
            pn09.BackColor = padrao;
            pn10.BackColor = padrao;
            pn11.BackColor = padrao;
            pn12.BackColor = padrao;
            pn13.BackColor = padrao;
            pn14.BackColor = padrao;
            pn15.BackColor = padrao;
            pn16.BackColor = padrao;
            pn17.BackColor = padrao;
            pn18.BackColor = padrao;
            pn19.BackColor = padrao;
            pn20.BackColor = padrao;
            pn21.BackColor = padrao;
            pn22.BackColor = padrao;
            pn23.BackColor = padrao;
            pn24.BackColor = padrao;
            pn25.BackColor = padrao;
            pn26.BackColor = padrao;
            pn27.BackColor = padrao;
            pn28.BackColor = padrao;
            pn29.BackColor = padrao;
            pn30.BackColor = padrao;
            pn31.BackColor = padrao;

            
            if (Convert.ToDouble(pn01.Location.X) == BaseX || Convert.ToDouble(pn01.Location.X) == 6*ajuste+BaseX)
            {
                pn01.BackColor = domSab;
               
            }

            if (Convert.ToDouble(pn02.Location.X) == BaseX || Convert.ToDouble(pn02.Location.X) == 6*ajuste+BaseX)
            {
                pn02.BackColor = domSab;
               
            }

            if (Convert.ToDouble(pn03.Location.X) == BaseX || Convert.ToDouble(pn03.Location.X) == 6*ajuste+BaseX)
            {
                pn03.BackColor = domSab;
                
            }

            if (Convert.ToDouble(pn04.Location.X) == BaseX || Convert.ToDouble(pn04.Location.X) == 6*ajuste+BaseX)
            {
                pn04.BackColor = domSab;
            }

            if (Convert.ToDouble(pn05.Location.X) == BaseX || Convert.ToDouble(pn05.Location.X) == 6*ajuste+BaseX)
            {
                pn05.BackColor = domSab;
            }

            if (Convert.ToDouble(pn06.Location.X) == BaseX || Convert.ToDouble(pn06.Location.X) == 6*ajuste+BaseX)
            {
                pn06.BackColor = domSab;
            }

            if (Convert.ToDouble(pn07.Location.X) == BaseX || Convert.ToDouble(pn07.Location.X) == 6*ajuste+BaseX)
            {
                pn07.BackColor = domSab;
            }

            if (Convert.ToDouble(pn08.Location.X) == BaseX || Convert.ToDouble(pn08.Location.X) == 6*ajuste+BaseX)
            {
                pn08.BackColor = domSab;
            }

            if (Convert.ToDouble(pn09.Location.X) == BaseX || Convert.ToDouble(pn09.Location.X) == 6*ajuste+BaseX)
            {
                pn09.BackColor = domSab;
            }

            if (Convert.ToDouble(pn10.Location.X) == BaseX || Convert.ToDouble(pn10.Location.X) == 6*ajuste+BaseX)
            {
                pn10.BackColor = domSab;
            }

            if (Convert.ToDouble(pn11.Location.X) == BaseX || Convert.ToDouble(pn11.Location.X) == 6*ajuste+BaseX)
            {
                pn11.BackColor = domSab;
            }

            if (Convert.ToDouble(pn12.Location.X) == BaseX || Convert.ToDouble(pn12.Location.X) == 6*ajuste+BaseX)
            {
                pn12.BackColor = domSab;
            }

            if (Convert.ToDouble(pn13.Location.X) == BaseX || Convert.ToDouble(pn13.Location.X) == 6*ajuste+BaseX)
            {
                pn13.BackColor = domSab;
            }

            if (Convert.ToDouble(pn14.Location.X) == BaseX || Convert.ToDouble(pn14.Location.X) == 6*ajuste+BaseX)
            {
                pn14.BackColor = domSab;
            }

            if (Convert.ToDouble(pn15.Location.X) == BaseX || Convert.ToDouble(pn15.Location.X) == 6*ajuste+BaseX)
            {
                pn15.BackColor = domSab;
            }

            if (Convert.ToDouble(pn16.Location.X) == BaseX || Convert.ToDouble(pn16.Location.X) == 6*ajuste+BaseX)
            {
                pn16.BackColor = domSab;
            }

            if (Convert.ToDouble(pn17.Location.X) == BaseX || Convert.ToDouble(pn17.Location.X) == 6*ajuste+BaseX)
            {
                pn17.BackColor = domSab;
            }

            if (Convert.ToDouble(pn18.Location.X) == BaseX || Convert.ToDouble(pn18.Location.X) == 6*ajuste+BaseX)
            {
                pn18.BackColor = domSab;
            }

            if (Convert.ToDouble(pn19.Location.X) == BaseX || Convert.ToDouble(pn19.Location.X) == 6*ajuste+BaseX)
            {
                pn19.BackColor = domSab;
            }

            if (Convert.ToDouble(pn20.Location.X) == BaseX || Convert.ToDouble(pn20.Location.X) == 6*ajuste+BaseX)
            {
                pn20.BackColor = domSab;
            }

            if (Convert.ToDouble(pn21.Location.X) == BaseX || Convert.ToDouble(pn21.Location.X) == 6*ajuste+BaseX)
            {
                pn21.BackColor = domSab;
            }

            if (Convert.ToDouble(pn22.Location.X) == BaseX || Convert.ToDouble(pn22.Location.X) == 6*ajuste+BaseX)
            {
                pn22.BackColor = domSab;
            }

            if (Convert.ToDouble(pn23.Location.X) == BaseX || Convert.ToDouble(pn23.Location.X) == 6*ajuste+BaseX)
            {
                pn23.BackColor = domSab;
            }

            if (Convert.ToDouble(pn24.Location.X) == BaseX || Convert.ToDouble(pn24.Location.X) == 6*ajuste+BaseX)
            {
                pn24.BackColor = domSab;
            }

            if (Convert.ToDouble(pn25.Location.X) == BaseX || Convert.ToDouble(pn25.Location.X) == 6*ajuste+BaseX)
            {
                pn25.BackColor = domSab;
            }

            if (Convert.ToDouble(pn26.Location.X) == BaseX || Convert.ToDouble(pn26.Location.X) == 6*ajuste+BaseX)
            {
                pn26.BackColor = domSab;
            }

            if (Convert.ToDouble(pn27.Location.X) == BaseX || Convert.ToDouble(pn27.Location.X) == 6*ajuste+BaseX)
            {
                pn27.BackColor = domSab;
            }

            if (Convert.ToDouble(pn28.Location.X) == BaseX || Convert.ToDouble(pn28.Location.X) == 6*ajuste+BaseX)
            {
                pn28.BackColor = domSab;
            }

            if (Convert.ToDouble(pn29.Location.X) == BaseX || Convert.ToDouble(pn29.Location.X) == 6*ajuste+BaseX)
            {
                pn29.BackColor = domSab;
            }

            if (Convert.ToDouble(pn30.Location.X) == BaseX || Convert.ToDouble(pn30.Location.X) == 6*ajuste+BaseX)
            {
                pn30.BackColor = domSab;
            }

            if (Convert.ToDouble(pn31.Location.X) == BaseX || Convert.ToDouble(pn31.Location.X) == 6*ajuste+BaseX)
            {
                pn31.BackColor = domSab;
            }



            #endregion

            
        }

        private void redefineMesSelecionado()
        {
            if (cbMes.Text != "")
            {
                #region Case Mês

                switch (cbMes.Text)
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
                    default:
                        mesSelecionado = 0;
                        break;
                }

                #endregion
                
                dataSelecionada = new DateTime(Convert.ToInt32(txtAno.Value), Convert.ToInt32(mesSelecionado), 1);

            }
            


        }

        private void AtualizaDados()
        {

            DateTime dataatual = dataSelecionada;

            DateTime Diai = new DateTime(dataatual.Year, dataatual.Month, 1);

            DateTime Diaf = Diai.AddDays(-(Diai.Day - 1)).AddMonths(1).AddDays(-1);

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

            #region Atualiza Valores de venda

            //Preenche os dados (R$)

            DateTime dataBusca = new DateTime(Convert.ToInt32(txtAno.Value), Convert.ToInt32(mesSelecionado), 1);

            BLLDados bll = new BLLDados(cx);

            DataTable tabelaVenda = bll.LocalizarVenda(Diai, Diaf, Convert.ToInt32(cbUnidade.SelectedValue));

            int i = 0;
            string valoratual;


            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor01.Text = valoratual;
            i++;

            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor02.Text = valoratual;
            i++;

            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor03.Text = valoratual;
            i++;

            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor04.Text = valoratual;
            i++;

            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor05.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor06.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor07.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor08.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor09.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor10.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor11.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor12.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor13.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor14.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor15.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor16.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor17.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor18.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor19.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor20.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor21.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor22.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor23.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor24.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor25.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor26.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor27.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor28.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor29.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor30.Text = valoratual;
            i++;
            try { valoratual = "R$ "+ Convert.ToDouble(tabelaVenda.Rows[i][1]).ToString("#,0.00"); }
            catch { valoratual = ""; }

            lbValor31.Text = valoratual;
            i++;
            

            #endregion
            
            #region Atualiza Valores de Pax
            
            DataTable tabelapax = bll.LocalizarPaxDiario(Diai, Diaf, Convert.ToInt32(cbUnidade.SelectedValue));

            i = 0;
           
            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax01.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax02.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax03.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax04.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax05.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax06.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax07.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax08.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax09.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax10.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax11.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax12.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax13.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax14.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax15.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax16.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax17.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax18.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax19.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax20.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax21.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax22.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax23.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax24.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax25.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax26.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax27.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax28.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax29.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax30.Text = valoratual;
            i++;

            try { valoratual = Convert.ToDouble(tabelapax.Rows[i][1]).ToString("0"); }
            catch { valoratual = ""; }

            lbPax31.Text = valoratual;
            


            
            #endregion
            
        }

        private void Excluir(int dia)
        {
            DialogResult d = MessageBox.Show($"Deseja realmente os dados do dia {dia} de {cbMes.Text}?", "Aviso", MessageBoxButtons.YesNo);
            if (d.ToString() == "Yes")
            {

               
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

                DTODados ven = new DTODados();
                BLLDados bllven = new BLLDados(cx);

                DateTime data = new DateTime(Convert.ToInt32(txtAno.Value), Convert.ToInt32(mesSelecionado), dia);
                
                bllven.Excluir(data, Convert.ToInt32(cbUnidade.SelectedValue));
                bllven.ExcluirPaxDia(data, Convert.ToInt32(cbUnidade.SelectedValue));

                AtualizaDados();
                
                
            }


        }

        private void AtualizaChart()
        {

            graficoVendaPax.Series[0].Points.Clear();
            graficoVendaPax.Series[1].Points.Clear();
            graficoVendaReceita.Series[0].Points.Clear();
            graficoVendaReceita.Series[1].Points.Clear();

            #region Pax

            DateTime Diai = new DateTime(Convert.ToInt32(txtAno.Value), Convert.ToInt32(mesSelecionado), 1);

            DateTime Diaf = Diai.AddDays(-(Diai.Day - 1)).AddMonths(1).AddDays(-1);


               

                

                DALConexao cxpax = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLDados bllpax = new BLLDados(cxpax);
                DataTable tabela = bllpax.LocalizarPaxDiario(Diai, Diaf, Convert.ToInt32(cbUnidade.SelectedValue));

                double paxtotal = 0;
                double paxanterior = 0;
                double paxatual = 0;
                double media;
               
           

                
                    for (int i = 0; i < Diaf.Day; i++)
                    {

                        try { paxatual = Convert.ToDouble(tabela.Rows[i][1]); }
                        catch { paxatual = 0; }

                        media = (paxatual + paxanterior) / 2;

                        graficoVendaPax.Series["Dias"].Points.AddXY((i + 1).ToString(), paxatual);
                        graficoVendaPax.Series["Linha"].Points.AddXY((i + 1).ToString(), media);

                        try { paxanterior = Convert.ToDouble(tabela.Rows[i][1]); }
                        catch { paxanterior = 0; }

                        paxtotal += paxatual;
                    }
                
               
                lbTituloPax.Text = $"PAX total de {cbMes.Text}: {paxtotal.ToString("0")}";
           
            #endregion

            #region Receita

            try
            {

                
                DALConexao cxven = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLDados bllven = new BLLDados(cxven);
                DataTable tabelav = bllven.LocalizarVenda(Diai, Diaf, Convert.ToInt32(cbUnidade.SelectedValue.ToString()));
                                
                double vendatotal = 0;
                double vendaanterior = 0;
                double vendaatual = 0;
                media = 0;
                lbTituloReceita.Text = "RECEITA";
                
                
                    for (int i = 0; i < Diaf.Day; i++)
                    {
                        vendaatual = 0;
                        try { vendaatual = Convert.ToDouble(tabelav.Rows[i][1]); }
                        catch { }

                        media = (vendaatual + vendaanterior) / 2;

                        graficoVendaReceita.Series["Dias"].Points.AddXY((i + 1).ToString(), vendaatual);
                        graficoVendaReceita.Series["Linha"].Points.AddXY((i + 1).ToString(), media);

                        try { vendaanterior = Convert.ToDouble(tabelav.Rows[i][1]); }
                        catch { vendaanterior = 0; }

                        vendatotal += vendaatual;
                    }
                
                

                lbTituloReceita.Text += $" total de {cbMes.Text}: R$ {vendatotal.ToString("0,0.00")}";

                }
            catch { }
            
            #endregion

            this.graficoVendaPax.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graficoVendaPax_MouseMove);
            
        }

        #endregion

    }
}
