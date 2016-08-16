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
    public partial class frmRELSinteticoGrupos : Form
    {
        int unidade, idUsuario;
        bool liberado = false;
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        DateTime DiaI, DiaF, DiaA;

        public frmRELSinteticoGrupos(int id)
        {
            idUsuario = Convert.ToInt32(id);
            InitializeComponent();
        }

        private void frmRELSinteticoGrupos_Load(object sender, EventArgs e)
        {
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(Convert.ToInt32(idUsuario));

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";
            DafaultValues();
            
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

        private void DafaultValues()
        {
            pn01.Visible = false;
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

            CarregaDgvs();

            liberado = true;
            pn01.Visible = true;

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

            cbGrupo01.Text = "";
            cbGrupo02.Text = "";
            cbGrupo03.Text = "";
            cbGrupo04.Text = "";
            cbGrupo05.Text = "";

            CarregarConfigs();

            liberado = true;

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

        private void SalvarConfigs(int chart)
        {

            ///Cadastrar o tipo de config com o nome GG1 (grafico grupos 1), GG2...

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLConfigUnidade bll = new BLLConfigUnidade(cx);
            DTOConfigUnidade dto = new DTOConfigUnidade();

            DataTable tabela;


            if (chart == 1)
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
            if (chart == 2)
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
            if (chart == 3)
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
            if (chart == 4)
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
            if (chart == 5)
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
        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liberado)
            {
                CarregaDgvs();
            }
        }

        private void CarregaDgvs()
        {
            pn01.Visible = false;

            CarregaDatas();
            CarregaGrupo01();
            CarregaGrupo02();
            CarregaGrupo03();
            CarregaGrupo04();
            CarregaGrupo05();
            CarregaTotal();
            pn01.Visible = true;

        }

        private void CarregaDatas()
        {
            DataGridView dgv = new DataGridView();
            dgv = dgvData;
            dgv.Rows.Clear();

            DiaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DiaF = DiaI.AddDays(-(DiaI.Day - 1)).AddMonths(1).AddDays(-1);
            DiaA = DiaI;
            String[] D;
            string data;
            for (int i = 0; i < 31; i++)
            {
                if (DiaA <= DiaF)
                {
                    data = Dia(DiaA);
                }else
                {
                    data = "";
                }

                D = new string[] { data };
                dgv.Rows.Add(D);
                DiaA = DiaA.AddDays(1);
            }

            D = new string[] { "", "-1" };
            dgv.Rows.Add(D);
                       
            D = new string[] { "TOTAL", "0" };
            dgv.Rows.Add(D);


            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(dgv.Font, FontStyle.Bold);

            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            style2.Font = new Font(dgv.Font, FontStyle.Bold);

            for (int i = 0; i < dgv.Rows.Count; i++)
            {

                try
                {
                    if (dgv.Rows[i].Cells[1].Value.ToString() == "-1")
                    {

                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        dgv.Rows[i].Height = 8;
                    }


                    if (dgv.Rows[i].Cells[1].Value.ToString() == "0")
                    {
                        dgv.Rows[i].DefaultCellStyle = style2;
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.DarkGray;
                        dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        dgv.Rows[i].Height = 24;
                    }
                }
                catch { }
            }
        }

        private void CarregaGrupo01()
        {
            DataGridView dgv = new DataGridView();
            dgv = dgvGrupo01;
            dgv.Rows.Clear();
            ComboBox cb = new ComboBox();
            cb = cbGrupo01;

            //Variáveis
            double CMV = 0;
            double CMV1 = 0;
            double CUSTO = 0;
            double RECEITA = 0;

            int PAX = 0;
            DataTable tabelaCusto, tabelaReceita, totalCusto, totalReceita;
            DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DateTime diaF = diaI.AddDays(-(diaI.Day - 1)).AddMonths(1).AddDays(-1);
            DateTime DiaA = diaI;
            int unidade = Convert.ToInt32(cbUnidade.SelectedValue);

            int c = 0;
            int r = 0;

            //Busca Dados no BD
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLCmvGraficos bll = new BLLCmvGraficos(cx);

            int grupo = 0;

            if (cb.Text != "")
            {
                grupo = Convert.ToInt32(cb.SelectedValue);
            }

            tabelaCusto = bll.TabelaCustoPorGrupo(unidade, diaI, diaF, grupo);

            totalCusto = bll.TotalCustoPorGrupo(unidade, diaI, diaF, grupo);

            totalReceita = bll.TotalReceitaPorGrupo(unidade, diaI, diaF, grupo);

            tabelaReceita = bll.TabelaReceitaPorGrupo(unidade, diaI, diaF, grupo);

            DiaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DiaF = DiaI.AddDays(-(DiaI.Day - 1)).AddMonths(1).AddDays(-1);
            DiaA = DiaI;
            String[] D;

            for (int i = 0; i < 31; i++)
            {
                CUSTO = 0;
                PAX = 0;
                RECEITA = 0;
                CMV = 0;
                CMV1 = 0;


                if (DiaA <= DiaF)
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
                                CUSTO = Convert.ToDouble(tabelaCusto.Rows[c][1]) * -1;
                                PAX = Convert.ToInt32(tabelaReceita.Rows[r][2]);
                                RECEITA = Convert.ToDouble(tabelaReceita.Rows[r][3]);
                                CMV = Math.Round(CUSTO / PAX, 2);
                                CMV1 = Math.Round(CUSTO / RECEITA, 4);

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


                    D = new string[] { CUSTO.ToString("#,0.00"), CMV.ToString("#,0.00"), (CMV1 * 100).ToString() + "%" };

                }
                else
                {
                    D = new string[] { "", "", "" };
                }


                dgv.Rows.Add(D);
                DiaA = DiaA.AddDays(1);
            }

            D = new string[] { "", "", "", "-1" };
            dgv.Rows.Add(D);

            CUSTO = 0;
            PAX = 0;
            RECEITA = 0;
            CMV = 0;
            CMV1 = 0;

            try
            {
                CUSTO = Convert.ToDouble(totalCusto.Rows[0][0]) * -1;
                PAX = Convert.ToInt32(totalReceita.Rows[0][1]);
                RECEITA = Convert.ToDouble(totalReceita.Rows[0][2]);
                CMV = Math.Round(CUSTO / PAX, 2);
                CMV1 = Math.Round(CUSTO / RECEITA, 4);
            }
            catch { }

            string Custo = CUSTO.ToString("#,0.00");
            string Valor = CMV.ToString("#,0.00");
            string Percentual = (CMV1 * 100).ToString() + "%";


            D = new string[] { Custo, Valor, Percentual, "0" };
            dgv.Rows.Add(D);


            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(dgv.Font, FontStyle.Bold);

            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            style2.Font = new Font(dgv.Font, FontStyle.Bold);

            for (int i = 0; i < dgv.Rows.Count; i++)
            {

                try
                {
                    if (dgv.Rows[i].Cells[3].Value.ToString() == "-1")
                    {

                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        dgv.Rows[i].Height = 8;
                    }


                    if (dgv.Rows[i].Cells[3].Value.ToString() == "0")
                    {
                        dgv.Rows[i].DefaultCellStyle = style2;
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.DarkGray;
                        dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        dgv.Rows[i].Height = 24;
                    }
                }
                catch { }
            }

        }

        private void CarregaGrupo02()
        {
            DataGridView dgv = new DataGridView();
            dgv = dgvGrupo02;
            dgv.Rows.Clear();
            ComboBox cb = new ComboBox();
            cb = cbGrupo02;

            //Variáveis
            double CMV = 0;
            double CMV1 = 0;
            double CUSTO = 0;
            double RECEITA = 0;

            int PAX = 0;
            DataTable tabelaCusto, tabelaReceita, totalCusto, totalReceita;
            DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DateTime diaF = diaI.AddDays(-(diaI.Day - 1)).AddMonths(1).AddDays(-1);
            DateTime DiaA = diaI;
            int unidade = Convert.ToInt32(cbUnidade.SelectedValue);

            int c = 0;
            int r = 0;

            //Busca Dados no BD
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLCmvGraficos bll = new BLLCmvGraficos(cx);

            int grupo = 0;

            if (cb.Text != "")
            {
                grupo = Convert.ToInt32(cb.SelectedValue);
            }

            tabelaCusto = bll.TabelaCustoPorGrupo(unidade, diaI, diaF, grupo);

            totalCusto = bll.TotalCustoPorGrupo(unidade, diaI, diaF, grupo);

            totalReceita = bll.TotalReceitaPorGrupo(unidade, diaI, diaF, grupo);

            tabelaReceita = bll.TabelaReceitaPorGrupo(unidade, diaI, diaF, grupo);

            DiaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DiaF = DiaI.AddDays(-(DiaI.Day - 1)).AddMonths(1).AddDays(-1);
            DiaA = DiaI;
            String[] D;

            for (int i = 0; i < 31; i++)
            {
                CUSTO = 0;
                PAX = 0;
                RECEITA = 0;
                CMV = 0;
                CMV1 = 0;


                if (DiaA <= DiaF)
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
                                CUSTO = Convert.ToDouble(tabelaCusto.Rows[c][1]) * -1;
                                PAX = Convert.ToInt32(tabelaReceita.Rows[r][2]);
                                RECEITA = Convert.ToDouble(tabelaReceita.Rows[r][3]);
                                CMV = Math.Round(CUSTO / PAX, 2);
                                CMV1 = Math.Round(CUSTO / RECEITA, 4);

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


                    D = new string[] { CUSTO.ToString("#,0.00"), CMV.ToString("#,0.00"), (CMV1 * 100).ToString() + "%" };

                }
                else
                {
                    D = new string[] { "", "", "" };
                }


                dgv.Rows.Add(D);
                DiaA = DiaA.AddDays(1);
            }

            D = new string[] { "", "", "", "-1" };
            dgv.Rows.Add(D);

            CUSTO = 0;
            PAX = 0;
            RECEITA = 0;
            CMV = 0;
            CMV1 = 0;

            try
            {
                CUSTO = Convert.ToDouble(totalCusto.Rows[0][0]) * -1;
                PAX = Convert.ToInt32(totalReceita.Rows[0][1]);
                RECEITA = Convert.ToDouble(totalReceita.Rows[0][2]);
                CMV = Math.Round(CUSTO / PAX, 2);
                CMV1 = Math.Round(CUSTO / RECEITA, 4);
            }
            catch { }

            string Custo = CUSTO.ToString("#,0.00");
            string Valor = CMV.ToString("#,0.00");
            string Percentual = (CMV1 * 100).ToString() + "%";


            D = new string[] { Custo, Valor, Percentual, "0" };
            dgv.Rows.Add(D);


            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(dgv.Font, FontStyle.Bold);

            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            style2.Font = new Font(dgv.Font, FontStyle.Bold);

            for (int i = 0; i < dgv.Rows.Count; i++)
            {

                try
                {
                    if (dgv.Rows[i].Cells[3].Value.ToString() == "-1")
                    {

                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        dgv.Rows[i].Height = 8;
                    }


                    if (dgv.Rows[i].Cells[3].Value.ToString() == "0")
                    {
                        dgv.Rows[i].DefaultCellStyle = style2;
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.DarkGray;
                        dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        dgv.Rows[i].Height = 24;
                    }
                }
                catch { }
            }
        }

        private void CarregaGrupo03()
        {
            DataGridView dgv = new DataGridView();
            dgv = dgvGrupo03;
            dgv.Rows.Clear();
            ComboBox cb = new ComboBox();
            cb = cbGrupo03;

            //Variáveis
            double CMV = 0;
            double CMV1 = 0;
            double CUSTO = 0;
            double RECEITA = 0;

            int PAX = 0;
            DataTable tabelaCusto, tabelaReceita, totalCusto, totalReceita;
            DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DateTime diaF = diaI.AddDays(-(diaI.Day - 1)).AddMonths(1).AddDays(-1);
            DateTime DiaA = diaI;
            int unidade = Convert.ToInt32(cbUnidade.SelectedValue);

            int c = 0;
            int r = 0;

            //Busca Dados no BD
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLCmvGraficos bll = new BLLCmvGraficos(cx);

            int grupo = 0;

            if (cb.Text != "")
            {
                grupo = Convert.ToInt32(cb.SelectedValue);
            }

            tabelaCusto = bll.TabelaCustoPorGrupo(unidade, diaI, diaF, grupo);

            totalCusto = bll.TotalCustoPorGrupo(unidade, diaI, diaF, grupo);

            totalReceita = bll.TotalReceitaPorGrupo(unidade, diaI, diaF, grupo);

            tabelaReceita = bll.TabelaReceitaPorGrupo(unidade, diaI, diaF, grupo);

            DiaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DiaF = DiaI.AddDays(-(DiaI.Day - 1)).AddMonths(1).AddDays(-1);
            DiaA = DiaI;
            String[] D;

            for (int i = 0; i < 31; i++)
            {
                CUSTO = 0;
                PAX = 0;
                RECEITA = 0;
                CMV = 0;
                CMV1 = 0;


                if (DiaA <= DiaF)
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
                                CUSTO = Convert.ToDouble(tabelaCusto.Rows[c][1]) * -1;
                                PAX = Convert.ToInt32(tabelaReceita.Rows[r][2]);
                                RECEITA = Convert.ToDouble(tabelaReceita.Rows[r][3]);
                                CMV = Math.Round(CUSTO / PAX, 2);
                                CMV1 = Math.Round(CUSTO / RECEITA, 4);

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


                    D = new string[] { CUSTO.ToString("#,0.00"), CMV.ToString("#,0.00"), (CMV1 * 100).ToString() + "%" };

                }
                else
                {
                    D = new string[] { "", "", "" };
                }


                dgv.Rows.Add(D);
                DiaA = DiaA.AddDays(1);
            }

            D = new string[] { "", "", "", "-1" };
            dgv.Rows.Add(D);

            CUSTO = 0;
            PAX = 0;
            RECEITA = 0;
            CMV = 0;
            CMV1 = 0;

            try
            {
                CUSTO = Convert.ToDouble(totalCusto.Rows[0][0]) * -1;
                PAX = Convert.ToInt32(totalReceita.Rows[0][1]);
                RECEITA = Convert.ToDouble(totalReceita.Rows[0][2]);
                CMV = Math.Round(CUSTO / PAX, 2);
                CMV1 = Math.Round(CUSTO / RECEITA, 4);
            }
            catch { }

            string Custo = CUSTO.ToString("#,0.00");
            string Valor = CMV.ToString("#,0.00");
            string Percentual = (CMV1 * 100).ToString() + "%";


            D = new string[] { Custo, Valor, Percentual, "0" };
            dgv.Rows.Add(D);


            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(dgv.Font, FontStyle.Bold);

            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            style2.Font = new Font(dgv.Font, FontStyle.Bold);

            for (int i = 0; i < dgv.Rows.Count; i++)
            {

                try
                {
                    if (dgv.Rows[i].Cells[3].Value.ToString() == "-1")
                    {

                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        dgv.Rows[i].Height = 8;
                    }


                    if (dgv.Rows[i].Cells[3].Value.ToString() == "0")
                    {
                        dgv.Rows[i].DefaultCellStyle = style2;
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.DarkGray;
                        dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        dgv.Rows[i].Height = 24;
                    }
                }
                catch { }
            }
        }

        private void CarregaGrupo04()
        {
            DataGridView dgv = new DataGridView();
            dgv = dgvGrupo04;
            dgv.Rows.Clear();
            ComboBox cb = new ComboBox();
            cb = cbGrupo04;

            //Variáveis
            double CMV = 0;
            double CMV1 = 0;
            double CUSTO = 0;
            double RECEITA = 0;

            int PAX = 0;
            DataTable tabelaCusto, tabelaReceita, totalCusto, totalReceita;
            DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DateTime diaF = diaI.AddDays(-(diaI.Day - 1)).AddMonths(1).AddDays(-1);
            DateTime DiaA = diaI;
            int unidade = Convert.ToInt32(cbUnidade.SelectedValue);

            int c = 0;
            int r = 0;

            //Busca Dados no BD
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLCmvGraficos bll = new BLLCmvGraficos(cx);

            int grupo = 0;

            if (cb.Text != "")
            {
                grupo = Convert.ToInt32(cb.SelectedValue);
            }

            tabelaCusto = bll.TabelaCustoPorGrupo(unidade, diaI, diaF, grupo);

            totalCusto = bll.TotalCustoPorGrupo(unidade, diaI, diaF, grupo);

            totalReceita = bll.TotalReceitaPorGrupo(unidade, diaI, diaF, grupo);

            tabelaReceita = bll.TabelaReceitaPorGrupo(unidade, diaI, diaF, grupo);

            DiaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DiaF = DiaI.AddDays(-(DiaI.Day - 1)).AddMonths(1).AddDays(-1);
            DiaA = DiaI;
            String[] D;

            for (int i = 0; i < 31; i++)
            {
                CUSTO = 0;
                PAX = 0;
                RECEITA = 0;
                CMV = 0;
                CMV1 = 0;


                if (DiaA <= DiaF)
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
                                CUSTO = Convert.ToDouble(tabelaCusto.Rows[c][1]) * -1;
                                PAX = Convert.ToInt32(tabelaReceita.Rows[r][2]);
                                RECEITA = Convert.ToDouble(tabelaReceita.Rows[r][3]);
                                CMV = Math.Round(CUSTO / PAX, 2);
                                CMV1 = Math.Round(CUSTO / RECEITA, 4);

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


                    D = new string[] { CUSTO.ToString("#,0.00"), CMV.ToString("#,0.00"), (CMV1 * 100).ToString() + "%" };

                }
                else
                {
                    D = new string[] { "", "", "" };
                }


                dgv.Rows.Add(D);
                DiaA = DiaA.AddDays(1);
            }

            D = new string[] { "", "", "", "-1" };
            dgv.Rows.Add(D);

            CUSTO = 0;
            PAX = 0;
            RECEITA = 0;
            CMV = 0;
            CMV1 = 0;

            try
            {
                CUSTO = Convert.ToDouble(totalCusto.Rows[0][0]) * -1;
                PAX = Convert.ToInt32(totalReceita.Rows[0][1]);
                RECEITA = Convert.ToDouble(totalReceita.Rows[0][2]);
                CMV = Math.Round(CUSTO / PAX, 2);
                CMV1 = Math.Round(CUSTO / RECEITA, 4);
            }
            catch { }

            string Custo = CUSTO.ToString("#,0.00");
            string Valor = CMV.ToString("#,0.00");
            string Percentual = (CMV1 * 100).ToString() + "%";


            D = new string[] { Custo, Valor, Percentual, "0" };
            dgv.Rows.Add(D);


            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(dgv.Font, FontStyle.Bold);

            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            style2.Font = new Font(dgv.Font, FontStyle.Bold);

            for (int i = 0; i < dgv.Rows.Count; i++)
            {

                try
                {
                    if (dgv.Rows[i].Cells[3].Value.ToString() == "-1")
                    {

                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        dgv.Rows[i].Height = 8;
                    }


                    if (dgv.Rows[i].Cells[3].Value.ToString() == "0")
                    {
                        dgv.Rows[i].DefaultCellStyle = style2;
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.DarkGray;
                        dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        dgv.Rows[i].Height = 24;
                    }
                }
                catch { }
            }
        }

        private void CarregaGrupo05()
        {
            DataGridView dgv = new DataGridView();
            dgv = dgvGrupo05;
            dgv.Rows.Clear();
            ComboBox cb = new ComboBox();
            cb = cbGrupo05;

            //Variáveis
            double CMV = 0;
            double CMV1 = 0;
            double CUSTO = 0;
            double RECEITA = 0;

            int PAX = 0;
            DataTable tabelaCusto, tabelaReceita, totalCusto, totalReceita;
            DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DateTime diaF = diaI.AddDays(-(diaI.Day - 1)).AddMonths(1).AddDays(-1);
            DateTime DiaA = diaI;
            int unidade = Convert.ToInt32(cbUnidade.SelectedValue);

            int c = 0;
            int r = 0;

            //Busca Dados no BD
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLCmvGraficos bll = new BLLCmvGraficos(cx);

            int grupo = 0;

            if (cb.Text != "")
            {
                grupo = Convert.ToInt32(cb.SelectedValue);
            }                        

            tabelaCusto = bll.TabelaCustoPorGrupo(unidade, diaI, diaF, grupo);

            totalCusto = bll.TotalCustoPorGrupo(unidade, diaI, diaF, grupo);

            totalReceita = bll.TotalReceitaPorGrupo(unidade, diaI, diaF, grupo);

            tabelaReceita = bll.TabelaReceitaPorGrupo(unidade, diaI, diaF, grupo);

            DiaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DiaF = DiaI.AddDays(-(DiaI.Day - 1)).AddMonths(1).AddDays(-1);
            DiaA = DiaI;
            String[] D;

            for (int i = 0; i < 31; i++)
            {
                CUSTO = 0;
                PAX = 0;
                RECEITA = 0;
                CMV = 0;
                CMV1 = 0;


                if (DiaA <= DiaF)
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
                                CUSTO = Convert.ToDouble(tabelaCusto.Rows[c][1]) * -1;
                                PAX = Convert.ToInt32(tabelaReceita.Rows[r][2]);
                                RECEITA = Convert.ToDouble(tabelaReceita.Rows[r][3]);
                                CMV = Math.Round(CUSTO / PAX, 2);
                                CMV1 = Math.Round(CUSTO / RECEITA, 4);

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


                    D = new string[] { CUSTO.ToString("#,0.00"), CMV.ToString("#,0.00"), (CMV1 * 100).ToString() + "%" };

                }
                else
                {
                    D = new string[] { "", "", "" };
                }


                dgv.Rows.Add(D);
                DiaA = DiaA.AddDays(1);
            }

            D = new string[] { "", "", "", "-1" };
            dgv.Rows.Add(D);

            CUSTO = 0;
            PAX = 0;
            RECEITA = 0;
            CMV = 0;
            CMV1 = 0;

            try
            {
                CUSTO = Convert.ToDouble(totalCusto.Rows[0][0]) * -1;
                PAX = Convert.ToInt32(totalReceita.Rows[0][1]);
                RECEITA = Convert.ToDouble(totalReceita.Rows[0][2]);
                CMV = Math.Round(CUSTO / PAX, 2);
                CMV1 = Math.Round(CUSTO / RECEITA, 4);
            }
            catch { }

            string Custo = CUSTO.ToString("#,0.00");
            string Valor = CMV.ToString("#,0.00");
            string Percentual = (CMV1 * 100).ToString() + "%";


            D = new string[] { Custo, Valor, Percentual, "0" };
            dgv.Rows.Add(D);


            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(dgv.Font, FontStyle.Bold);

            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            style2.Font = new Font(dgv.Font, FontStyle.Bold);

            for (int i = 0; i < dgv.Rows.Count; i++)
            {

                try
                {
                    if (dgv.Rows[i].Cells[3].Value.ToString() == "-1")
                    {

                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        dgv.Rows[i].Height = 8;
                    }


                    if (dgv.Rows[i].Cells[3].Value.ToString() == "0")
                    {
                        dgv.Rows[i].DefaultCellStyle = style2;
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.DarkGray;
                        dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        dgv.Rows[i].Height = 24;
                    }
                }
                catch { }
            }
        }

        private void CarregaTotal()
        {

            DataGridView dgv = new DataGridView();
            dgv = dgvTotal;
            dgv.Rows.Clear();
            CheckBox cb = new CheckBox();
            

            //Variáveis
            double CMV = 0;
            double CMV1 = 0;
            double CUSTO = 0;
            double RECEITA = 0;

            int PAX = 0;
            DataTable tabelaCusto, tabelaReceita, totalCusto, totalReceita;
            DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DateTime diaF = diaI.AddDays(-(diaI.Day - 1)).AddMonths(1).AddDays(-1);
            DateTime DiaA = diaI;
            int unidade = Convert.ToInt32(cbUnidade.SelectedValue);

            int c = 0;
            int r = 0;

            //Busca Dados no BD
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLCmvGraficos bll = new BLLCmvGraficos(cx);

            int g1 = 0;
            int g2 = 0;
            int g3 = 0;
            int g4 = 0;
            int g5 = 0;


            if (cbGrupo01.Text != "")
            {
                g1 = Convert.ToInt32(cbGrupo01.SelectedValue);
            }

            if (cbGrupo02.Text != "")
            {
                g2 = Convert.ToInt32(cbGrupo02.SelectedValue);
            }

            if (cbGrupo03.Text != "")
            {
                g3 = Convert.ToInt32(cbGrupo03.SelectedValue);
            }

            if (cbGrupo04.Text != "")
            {
                g4 = Convert.ToInt32(cbGrupo04.SelectedValue);
            }

            if (cbGrupo05.Text != "")
            {
                g5 = Convert.ToInt32(cbGrupo05.SelectedValue);
            }

            tabelaCusto = bll.TabelaCustoPorGrupos(unidade, diaI, diaF, g1, g2, g3, g4, g5);

            totalCusto = bll.TotalCustoPorGrupos(unidade, diaI, diaF, g1, g2, g3, g4, g5);

            totalReceita = bll.TotalReceitaPorGrupos(unidade, diaI, diaF, g1, g2, g3, g4, g5);

            tabelaReceita = bll.TabelaReceitaPorGrupos(unidade, diaI, diaF, g1, g2, g3, g4, g5);

            DiaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DiaF = DiaI.AddDays(-(DiaI.Day - 1)).AddMonths(1).AddDays(-1);
            DiaA = DiaI;
            String[] D;

            for (int i = 0; i < 31; i++)
            {
                CUSTO = 0;
                PAX = 0;
                RECEITA = 0;
                CMV = 0;
                CMV1 = 0;


                if (DiaA <= DiaF)
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
                                CUSTO = Convert.ToDouble(tabelaCusto.Rows[c][1]) * -1;
                                PAX = Convert.ToInt32(tabelaReceita.Rows[r][2]);
                                RECEITA = Convert.ToDouble(tabelaReceita.Rows[r][3]);
                                CMV = Math.Round(CUSTO / PAX, 2);
                                CMV1 = Math.Round(CUSTO / RECEITA, 4);

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


                    D = new string[] { CUSTO.ToString("#,0.00"), CMV.ToString("#,0.00"), (CMV1 * 100).ToString() + "%" };

                }
                else
                {
                    D = new string[] { "", "", "" };
                }


                dgv.Rows.Add(D);
                DiaA = DiaA.AddDays(1);
            }

            D = new string[] { "", "", "", "-1" };
            dgv.Rows.Add(D);

            CUSTO = 0;
            PAX = 0;
            RECEITA = 0;
            CMV = 0;
            CMV1 = 0;

            try
            {
                CUSTO = Convert.ToDouble(totalCusto.Rows[0][0]) * -1;
                PAX = Convert.ToInt32(totalReceita.Rows[0][1]);
                RECEITA = Convert.ToDouble(totalReceita.Rows[0][2]);
                CMV = Math.Round(CUSTO / PAX, 2);
                CMV1 = Math.Round(CUSTO / RECEITA, 4);
            }
            catch { }

            string Custo = CUSTO.ToString("#,0.00");
            string Valor = CMV.ToString("#,0.00");
            string Percentual = (CMV1 * 100).ToString() + "%";


            D = new string[] { Custo, Valor, Percentual, "0" };
            dgv.Rows.Add(D);


            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(dgv.Font, FontStyle.Bold);

            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            style2.Font = new Font(dgv.Font, FontStyle.Bold);

            for (int i = 0; i < dgv.Rows.Count; i++)
            {

                try
                {
                    if (dgv.Rows[i].Cells[3].Value.ToString() == "-1")
                    {

                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        dgv.Rows[i].Height = 8;
                    }


                    if (dgv.Rows[i].Cells[3].Value.ToString() == "0")
                    {
                        dgv.Rows[i].DefaultCellStyle = style2;
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.DarkGray;
                        dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        dgv.Rows[i].Height = 24;
                    }
                }
                catch { }
            }
        }

        private string Dia(DateTime dia)
        {
            string diaDaSemana = dia.Day.ToString("00") + "/" +cbMes.Text.Substring(0,3)+" - ";

            switch ((int)dia.DayOfWeek)
            {
                case 0:
                    diaDaSemana += "Dom";
                    break;
                case 1:
                    diaDaSemana += "Seg";
                    break;
                case 2:
                    diaDaSemana += "Ter";
                    break;
                case 3:
                    diaDaSemana += "Qua";
                    break;
                case 4:
                    diaDaSemana += "Qui";
                    break;
                case 5:
                    diaDaSemana += "Sex";
                    break;
                case 6:
                    diaDaSemana += "Sáb";
                    break;
            }

            return diaDaSemana;
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            dgvData.ClearSelection();
        }

        private void dgvGrupo01_SelectionChanged(object sender, EventArgs e)
        {
            dgvGrupo01.ClearSelection();
        }

        private void dgvGrupo02_SelectionChanged(object sender, EventArgs e)
        {
            dgvGrupo02.ClearSelection();
        }

        private void dgvGrupo03_SelectionChanged(object sender, EventArgs e)
        {
            dgvGrupo03.ClearSelection();
        }

        private void dgvGrupo04_SelectionChanged(object sender, EventArgs e)
        {
            dgvGrupo04.ClearSelection();
        }

        private void dgvGrupo05_SelectionChanged(object sender, EventArgs e)
        {
            dgvGrupo05.ClearSelection();
        }

        private void dgvTotal_SelectionChanged(object sender, EventArgs e)
        {
            dgvTotal.ClearSelection();
        }

        private void cbGrupo01_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liberado)
            {
                CarregaGrupo01();
                CarregaTotal();
            }
        }

        private void cbGrupo02_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liberado)
            {
                CarregaGrupo02();
                CarregaTotal();
            }
        }

        private void numAno_ValueChanged(object sender, EventArgs e)
        {
            if (liberado)
            {
                CarregaDgvs();
            }
        }

        private void cbUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liberado)
            {
                CarregaDgvs();
            }
        }

        private void dgvGrupo01_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ComboBox cb = new ComboBox();
            cb = cbGrupo01;

            DataGridView dgv = new DataGridView();
            dgv = dgvGrupo01;

            DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DateTime diaF = diaI.AddDays(-(diaI.Day - 1)).AddMonths(1).AddDays(-1);
            DateTime diaA;

            string titulo;
            int dia;
            int grupo = Convert.ToInt32(cb.SelectedValue);

            if (e.RowIndex >= 0 && dgv.Rows[e.RowIndex].Cells[0].Value.ToString() != "0,00" && dgv.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
            {
                dia = e.RowIndex + 1;
                if (dia > diaF.Day)
                {
                    titulo = cb.Text + " (" + cbMes.Text + ")";
                    dia = 32;
                    frmDetalheGrafico f = new frmDetalheGrafico(dia, titulo, grupo, diaI, diaF, unidade);
                    f.ShowDialog();
                    f.Dispose();
                }
                else
                {

                    diaA = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), dia);
                    titulo = cb.Text + " (" + dia.ToString("00") + "/" + Convert.ToInt32(cbMes.SelectedValue).ToString("00") + ")";
                    frmDetalheGrafico f = new frmDetalheGrafico(dia, titulo, grupo, diaA, diaA, unidade);
                    f.ShowDialog();
                    f.Dispose();


                }
            }
        }

        private void dgvGrupo02_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ComboBox cb = new ComboBox();
            cb = cbGrupo02;

            DataGridView dgv = new DataGridView();
            dgv = dgvGrupo02;

            DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DateTime diaF = diaI.AddDays(-(diaI.Day - 1)).AddMonths(1).AddDays(-1);
            DateTime diaA;

            string titulo;
            int dia;
            int grupo = Convert.ToInt32(cb.SelectedValue);

            if (e.RowIndex >= 0 && dgv.Rows[e.RowIndex].Cells[0].Value.ToString() != "0,00" && dgv.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
            {
                dia = e.RowIndex + 1;
                if (dia > diaF.Day)
                {
                    titulo = cb.Text + " (" + cbMes.Text + ")";
                    dia = 32;
                    frmDetalheGrafico f = new frmDetalheGrafico(dia, titulo, grupo, diaI, diaF, unidade);
                    f.ShowDialog();
                    f.Dispose();
                }
                else
                {

                    diaA = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), dia);
                    titulo = cb.Text + " (" + dia.ToString("00") + "/" + Convert.ToInt32(cbMes.SelectedValue).ToString("00") + ")";
                    frmDetalheGrafico f = new frmDetalheGrafico(dia, titulo, grupo, diaA, diaA, unidade);
                    f.ShowDialog();
                    f.Dispose();


                }
            }
        }

        private void dgvGrupo03_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ComboBox cb = new ComboBox();
            cb = cbGrupo03;

            DataGridView dgv = new DataGridView();
            dgv = dgvGrupo03;

            DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DateTime diaF = diaI.AddDays(-(diaI.Day - 1)).AddMonths(1).AddDays(-1);
            DateTime diaA;

            string titulo;
            int dia;
            int grupo = Convert.ToInt32(cb.SelectedValue);

            if (e.RowIndex >= 0 && dgv.Rows[e.RowIndex].Cells[0].Value.ToString() != "0,00" && dgv.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
            {
                dia = e.RowIndex + 1;
                if (dia > diaF.Day)
                {
                    titulo = cb.Text + " (" + cbMes.Text + ")";
                    dia = 32;
                    frmDetalheGrafico f = new frmDetalheGrafico(dia, titulo, grupo, diaI, diaF, unidade);
                    f.ShowDialog();
                    f.Dispose();
                }
                else
                {

                    diaA = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), dia);
                    titulo = cb.Text + " (" + dia.ToString("00") + "/" + Convert.ToInt32(cbMes.SelectedValue).ToString("00") + ")";
                    frmDetalheGrafico f = new frmDetalheGrafico(dia, titulo, grupo, diaA, diaA, unidade);
                    f.ShowDialog();
                    f.Dispose();


                }
            }
        }

        private void dgvGrupo04_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ComboBox cb = new ComboBox();
            cb = cbGrupo04;

            DataGridView dgv = new DataGridView();
            dgv = dgvGrupo04;

            DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DateTime diaF = diaI.AddDays(-(diaI.Day - 1)).AddMonths(1).AddDays(-1);
            DateTime diaA;

            string titulo;
            int dia;
            int grupo = Convert.ToInt32(cb.SelectedValue);

            if (e.RowIndex >= 0 && dgv.Rows[e.RowIndex].Cells[0].Value.ToString() != "0,00" && dgv.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
            {
                dia = e.RowIndex + 1;
                if (dia > diaF.Day)
                {
                    titulo = cb.Text + " (" + cbMes.Text + ")";
                    dia = 32;
                    frmDetalheGrafico f = new frmDetalheGrafico(dia, titulo, grupo, diaI, diaF, unidade);
                    f.ShowDialog();
                    f.Dispose();
                }
                else
                {

                    diaA = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), dia);
                    titulo = cb.Text + " (" + dia.ToString("00") + "/" + Convert.ToInt32(cbMes.SelectedValue).ToString("00") + ")";
                    frmDetalheGrafico f = new frmDetalheGrafico(dia, titulo, grupo, diaA, diaA, unidade);
                    f.ShowDialog();
                    f.Dispose();


                }
            }
        }

        private void dgvGrupo05_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ComboBox cb = new ComboBox();
            cb = cbGrupo05;

            DataGridView dgv = new DataGridView();
            dgv = dgvGrupo05;

            DateTime diaI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);
            DateTime diaF = diaI.AddDays(-(diaI.Day - 1)).AddMonths(1).AddDays(-1);
            DateTime diaA;

            string titulo;
            int dia;
            int grupo = Convert.ToInt32(cb.SelectedValue);

            if (e.RowIndex >= 0 && dgv.Rows[e.RowIndex].Cells[0].Value.ToString() != "0,00" && dgv.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
            {
                dia = e.RowIndex + 1;
                if (dia > diaF.Day)
                {
                    titulo = cb.Text + " (" + cbMes.Text + ")";
                    dia = 32;
                    frmDetalheGrafico f = new frmDetalheGrafico(dia, titulo, grupo, diaI, diaF, unidade);
                    f.ShowDialog();
                    f.Dispose();
                }
                else
                {

                    diaA = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), dia);
                    titulo = cb.Text + " (" + dia.ToString("00") + "/" + Convert.ToInt32(cbMes.SelectedValue).ToString("00") + ")";
                    frmDetalheGrafico f = new frmDetalheGrafico(dia, titulo, grupo, diaA, diaA, unidade);
                    f.ShowDialog();
                    f.Dispose();


                }
            }
        }

        private void cbGrupo03_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liberado)
            {
                CarregaGrupo03();
                CarregaTotal();
            }
        }

        private void cbGrupo04_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liberado)
            {
                CarregaGrupo04();
                CarregaTotal();
            }
        }

        private void cbGrupo05_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liberado)
            {
                CarregaGrupo05();
                CarregaTotal();
            }
        }



    }
}
