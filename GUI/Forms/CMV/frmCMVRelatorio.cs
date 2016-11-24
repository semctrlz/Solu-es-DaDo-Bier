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

namespace GUI
{
    public partial class frmCMVRelatorio : Form
    {

        #region Variáveis
        double tamanho_tabela;
        int idUsuario = 0;
        bool inicializado = false;
        

        #endregion

        #region Inicialização

        public frmCMVRelatorio(int id)
        {
            idUsuario = id;
            InitializeComponent();
        }

        private void frmCMVRelatorio_Load(object sender, EventArgs e)
        {            
            DefaultValues();            
        }

        #endregion


        public class Language
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        public void DefaultValues()
        {
            inicializado = false;
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(Convert.ToInt32(idUsuario));

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";

            BLLUnidade bllun = new BLLUnidade(con);

            cbUnidade.DataSource = bllun.ListarUnidades();

            cbUnidade.DisplayMember = "cod_unidade";
            cbUnidade.ValueMember = "id_unidade";
cbUnidade.Text = modelou.IdUnidade.ToString("00");

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

            lbTitulo.Text = $"CMV - {dto.NomeUnidade} - {cbMes.Text.ToUpper()}/{numAno.Value}";

            AtualizaDGVs();
            
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
            this.cbMes.SelectedIndex = mesAtual-1;
            





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
                AtualizaPagina();
            }
        }

        private void numAno_ValueChanged(object sender, EventArgs e)
        {
            if (inicializado)
            {
                AtualizaPagina();
            }
        }

        private void CarregaDgvResumo()
        {
            dgvResumo.Rows.Clear();

            #region VARIÁVEIS COMUNS

            DateTime DataI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);

            DateTime DataF = DataI.AddDays(-(DataI.Day - 1)).AddMonths(1).AddDays(-1);

            DataTable consulta;

            int unidade = Convert.ToInt32(cbUnidade.SelectedValue.ToString());
            string consultaAtual, valor, nome, titulo;
            double vendaBruta = 0;

            //V = Valor, T = Título, E = Espaço C = cabeçalho
            String[] V, T, E;

            //Espaço vazio
            
            E = new string[] { "E", "", "" };

            #endregion

            #region CUSTOS
            titulo = "CUSTOS";
            T = new string[] { "Tit", titulo, "" };
            this.dgvResumo.Rows.Add(T);

            #region Alimentos

            //Alimentos

            consultaAtual = "A";
            nome = "ALIMENTOS";
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLConsultaCMV bllcmv = new BLLConsultaCMV(cx);
            consulta = bllcmv.TotalCustoPorTipo(unidade, consultaAtual, DataI, DataF);

            if (consulta.Rows.Count > 0)
            {
                try
                {
                    valor = Convert.ToDouble(consulta.Rows[0][0]).ToString("#,0.00");
                }
                catch
                {
                    valor = 0.ToString("#,0.00");
                }
                V = new string[] { "Cus", nome, "R$ " + valor };
            }
            else
            {
                V = new string[] { "Cus", nome, "0.00" };
            }

            this.dgvResumo.Rows.Add(V);

            #endregion

            #region Bebidas

            //Bebidas

            consultaAtual = "B";
            nome = "BEBIDAS";

            consulta = bllcmv.TotalCustoPorTipo(unidade, consultaAtual, DataI, DataF);

            if (consulta.Rows.Count > 0)
            {
                try
                {
                    valor = Convert.ToDouble(consulta.Rows[0][0]).ToString("#,0.00");
                }
                catch
                {
                    valor = 0.ToString("#,0.00");
                }
                V = new string[] { "Cus", nome, "R$ " + valor };
            }
            else
            {
                V = new string[] { "Cus", nome, "0.00" };
            }

            this.dgvResumo.Rows.Add(V);

            #endregion

            #region Ajustes e perdas

            //Ajustes e perdas

            consultaAtual = "C";
            nome = "AJUSTES E PERDAS";

            consulta = bllcmv.TotalCustoPorTipo(unidade, consultaAtual, DataI, DataF);

            if (consulta.Rows.Count > 0)
            {
                try
                {
                    valor = Convert.ToDouble(consulta.Rows[0][0]).ToString("#,0.00");
                }
                catch
                {
                    valor = 0.ToString("#,0.00");
                }
                V = new string[] { "Cus", nome, "R$ " + valor };
            }
            else
            {
                V = new string[] { "Cus", nome, "0.00" };
            }

            this.dgvResumo.Rows.Add(V);

            #endregion

            #region Alimentação de funcionários

            //Alimentação de funcionários

            consultaAtual = "F";
            nome = "FUNCIONÁRIOS";

            consulta = bllcmv.TotalCustoPorTipo(unidade, consultaAtual, DataI, DataF);

            if (consulta.Rows.Count > 0)
            {
                try
                {
                    valor = Convert.ToDouble(consulta.Rows[0][0]).ToString("#,0.00");
                }
                catch
                {
                    valor = 0.ToString("#,0.00");
                }
                V = new string[] { "Cus", nome, "R$ " + valor };
            }
            else
            {
                V = new string[] { "Cus", nome, "0.00" };
            }

            this.dgvResumo.Rows.Add(V);

            #endregion

            #region Eventos

            //Alimentação de funcionários

            consultaAtual = "E";
            nome = "EVENTOS";

            consulta = bllcmv.TotalCustoPorTipo(unidade, consultaAtual, DataI, DataF);

            if (consulta.Rows.Count > 0)
            {
                try
                {
                    valor = Convert.ToDouble(consulta.Rows[0][0]).ToString("#,0.00");
                    V = new string[] { "Cus", nome, "R$ " + valor };
                    this.dgvResumo.Rows.Add(V);
                }
                catch
                {

                }

            }
            else
            {

            }


            #endregion

            #region Diversos

            //Diversos

            consultaAtual = "O";
            nome = "DIVERSOS";

            consulta = bllcmv.LocalizarCustoPorSetor(unidade, consultaAtual, DataI, DataF);

            if (consulta.Rows.Count > 0)
            {
                for (int i = 0; i < consulta.Rows.Count; i++)
                {

                    try
                    {
                        nome = Convert.ToString(consulta.Rows[i][0]);
                        valor = Convert.ToDouble(consulta.Rows[i][1]).ToString("#,0.00");
                        V = new string[] { "Cus", nome, "R$ " + valor };
                        this.dgvResumo.Rows.Add(V);
                    }
                    catch
                    {
                    }
                }
            }

            #endregion

            #endregion

            #region RECEITA / PAX
            titulo = "RECEITA / PAX";

            //Adiciona um espaço vazio
            this.dgvResumo.Rows.Add(E);
            T = new string[] { "Tit", titulo, "" };
            this.dgvResumo.Rows.Add(T);

            #region Venda Bruta

            nome = "RECEITA BRUTA";

            consulta = bllcmv.LocalizarReceitaTotal(unidade, DataI, DataF);

            if (consulta.Rows.Count > 0)
            {
                try
                {
                    valor = Convert.ToDouble(consulta.Rows[0][0]).ToString("#,0.00");
                    vendaBruta = Convert.ToDouble(consulta.Rows[0][0]);
                }
                catch
                {
                    valor = 0.ToString("#,0.00");
                    vendaBruta = 0;
                }
                V = new string[] { "Cus", nome, "R$ " + valor };
            }
            else
            {
                V = new string[] { "Cus", nome, "0.00" };
            }

            this.dgvResumo.Rows.Add(V);

            #endregion

            #region Pax Dia

            nome = "CLIENTES ALMOÇO";

            consulta = bllcmv.LocalizarPaxPorTurno(unidade, DataI, DataF, 1);

            if (consulta.Rows.Count > 0)
            {
                try
                {
                    valor = Convert.ToDouble(consulta.Rows[0][0]).ToString("0");
                }
                catch
                {
                    valor = 0.ToString("0");
                }
                V = new string[] { "Cus", nome, valor };
            }
            else
            {
                V = new string[] { "Cus", nome, "0" };
            }

            this.dgvResumo.Rows.Add(V);

            #endregion

            #region Pax Noite

            nome = "CLIENTES JANTAR";

            consulta = bllcmv.LocalizarPaxPorTurno(unidade, DataI, DataF, 2);

            if (consulta.Rows.Count > 0)
            {
                try
                {
                    valor = Convert.ToDouble(consulta.Rows[0][0]).ToString("0");
                }
                catch
                {
                    valor = 0.ToString("0");
                }
                V = new string[] { "Cus", nome, valor };
            }
            else
            {
                V = new string[] { "Cus", nome, "0" };
            }

            this.dgvResumo.Rows.Add(V);

            #endregion

            #region Pax Total

            nome = "CLIENTES TOTAIS";

            consulta = bllcmv.LocalizarPaxPorTurno(unidade, DataI, DataF, 1);

            if (consulta.Rows.Count > 0)
            {
                try
                {
                    valor = Convert.ToDouble(consulta.Rows[0][0]).ToString();
                }
                catch
                {
                    valor = 0.ToString();
                }

                V = new string[] { "Cus", nome, valor };
            }
            else
            {
                valor = "0";
            }

            consulta = bllcmv.LocalizarPaxPorTurno(unidade, DataI, DataF, 2);

            if (consulta.Rows.Count > 0)
            {
                try
                {
                    valor = (Convert.ToDouble(valor) + Convert.ToDouble(consulta.Rows[0][0])).ToString("0");
                    
                }
                catch
                {
                    valor = (Convert.ToDouble(valor) + 0).ToString("0");
                }

            }
            else
            {
                valor = "0";
            }
           
            V = new string[] { "Cus", nome, valor };
            this.dgvResumo.Rows.Add(V);

            #endregion

            #endregion

            #region CORTESIAS
            titulo = "CORTESIAS";

            //Adiciona um espaço vazio
            this.dgvResumo.Rows.Add(E);
            T = new string[] { "Tit", titulo, "" };
            this.dgvResumo.Rows.Add(T);

            nome = "CORTESIAS TOTAIS";

            consulta = bllcmv.LocalizarCortesias(unidade, DataI, DataF);

            if (consulta.Rows.Count > 0)
            {
                try
                {
                    valor = Convert.ToDouble(consulta.Rows[0][0]).ToString("#,0.00");
                }
                catch
                {
                    valor = 0.ToString("#,0.00");
                }
                V = new string[] { "Cus", nome, "R$ " + valor };
            }
            else
            {
                V = new string[] { "Cus", nome, "0.00" };
            }

            this.dgvResumo.Rows.Add(V);

            #endregion

            #region IMPOSTOS 
            titulo = "IMPOSTOS";

            //Adiciona um espaço vazio
            this.dgvResumo.Rows.Add(E);
            T = new string[] { "Tit", titulo, "" };
            this.dgvResumo.Rows.Add(T);

            nome = "IMPOSTOS TOTAIS";


            //Busca valor Com impostos

            double valorAlimentos, valorBebidas, outrosValores, impostoA, impostoB;

            //Alimentos
            consulta = bllcmv.LocalizaReceitaGrupo(unidade, DataI, DataF, "A");

            try
            {
                valorAlimentos = Convert.ToDouble(consulta.Rows[0][0]);
            }
            catch
            {
                valorAlimentos = 0;
            }

            //Bebidas
            consulta = bllcmv.LocalizaReceitaGrupo(unidade, DataI, DataF, "B");

            try
            {
                valorBebidas = Convert.ToDouble(consulta.Rows[0][0]);
            }
            catch
            {
                valorBebidas = 0;
            }

            //Diversos
            consulta = bllcmv.LocalizaReceitaDiversas(unidade, DataI, DataF);

            try
            {
                outrosValores = Convert.ToDouble(consulta.Rows[0][0]);
            }
            catch
            {
                outrosValores = 0;
            }

            BLLConfigImposto bllimp = new BLLConfigImposto(cx);

            //Impostos
            consulta = bllimp.localizarValoresTotaisImpostos(unidade);
            try
            {
                impostoA = Convert.ToDouble(consulta.Rows[0][0]) / 100;
            }
            catch
            {
                impostoA = 0;
            }
            try
            {
                impostoB = Convert.ToDouble(consulta.Rows[0][1]) / 100;
            }
            catch
            {
                impostoB = 0;
            }


            //Venda bruta

            if (vendaBruta > 0)
            {
                valorAlimentos -= (valorAlimentos * impostoA);
                valorBebidas -= (valorBebidas * impostoB);

                valor = (100-(((valorAlimentos + valorBebidas + outrosValores) / vendaBruta) * 100)).ToString("#.00") + "%";

                V = new string[] { "Cus", nome, valor };
            }
            else
            {
                V = new string[] { "set", nome, "0,00%" };
            }
                this.dgvResumo.Rows.Add(V);

            //Busca Valor sem impostos

            //com imposto / sem imposto

            
            #endregion

            //Formata tudo
            
        }

        private void CarregaDgvA()
        {
            dgvA.Rows.Clear();

            #region VARIÁVEIS COMUNS

            DateTime DataI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);

            DateTime DataF = DataI.AddDays(-(DataI.Day - 1)).AddMonths(1).AddDays(-1);

            DataTable consultaCusto, consultaCentro, consultaPax;

            int unidade = Convert.ToInt32(cbUnidade.SelectedValue.ToString());
            int paxD, paxN;

            double valorTotal, meta, valorRealizado, metaD, metaN;
            string nome, turno, tipo, conta;

            String[] V, T, E, C, S;

            //V = Valor, T = Título, E = Espaço C = Cabeçalho, S = Subtitulo
            C = new string[] { "C", "SETOR", "CUSTO", "META", "REAL." };
            E = new string[] { "E", "", "", "", "" };

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLConsultaCMV bllcmv = new BLLConsultaCMV(cx);

            //Busca pax Dia e Noite

            BLLConfigUnidade bllconfig = new BLLConfigUnidade(cx);

            consultaPax = bllconfig.LocalizarConfig("TURNOS_VENDA", unidade);
            string config;

            try
            {
                config = consultaPax.Rows[0][0].ToString();
            }
            catch
            {
                config = "";
            }


            paxD = 0;
            paxN = 0;
            metaD = 0;
            metaN = 0;

            if (config == "Dia")
            {
                consultaPax = bllcmv.LocalizarPaxPorTurno(unidade, DataI, DataF, 1);
                try
                {
                    paxD = Convert.ToInt32(Math.Round(Convert.ToDouble(consultaPax.Rows[0][0]), 0));
                }
                catch
                {
                    paxD = 0;
                }

                consultaPax = bllcmv.LocalizarPaxPorTurno(unidade, DataI, DataF, 2);

                try
                {
                    paxN = Convert.ToInt32(Math.Round(Convert.ToDouble(consultaPax.Rows[0][0]), 0));
                }
                catch
                {
                    paxN = 0;
                }

                consultaPax = bllcmv.TotalMetaPorTipoETurno(unidade, "A", "");
                try
                {
                    metaD = Convert.ToDouble(consultaPax.Rows[0][0]);
                }
                catch
                {

                }

            }
            else if (config != "Dia")
            {


                consultaPax = bllcmv.LocalizarPaxPorTurno(unidade, DataI, DataF, 1);
                try
                {
                    paxD = Convert.ToInt32(Math.Round(Convert.ToDouble(consultaPax.Rows[0][0]), 0));
                }
                catch
                {
                    paxD = 0;
                }

                consultaPax = bllcmv.LocalizarPaxPorTurno(unidade, DataI, DataF, 2);

                try
                {
                    paxN = Convert.ToInt32(Math.Round(Convert.ToDouble(consultaPax.Rows[0][0]), 0));
                }
                catch
                {
                    paxN = 0;
                }

                consultaPax = bllcmv.TotalMetaPorTipoETurno(unidade, "A", "A");

                metaD = Convert.ToDouble(consultaPax.Rows[0][0]) * -1;

                consultaPax = bllcmv.TotalMetaPorTipoETurno(unidade, "A", "J");

                metaN = Convert.ToDouble(consultaPax.Rows[0][0]) * -1;


            }

            #endregion


            //Adiciona o cabeçalho
            this.dgvA.Rows.Add(C);
            
            nome = "ALIMENTOS";
            turno = "a";
            tipo = "a";
            consultaCusto = bllcmv.TotalCustoPorTipo(unidade, tipo, DataI, DataF);

            try
            {
                valorTotal = Convert.ToDouble(consultaCusto.Rows[0][0]);
            }
            catch
            {
                valorTotal = 0;
            }

            if ((paxD + paxN) == 0)
            {
                valorRealizado = 0;
            }
            else
            {
                valorRealizado = valorTotal / (paxD + paxN);
            }

            T = new string[] { "Tit", nome, valorTotal.ToString("#,0.00"), (metaD + metaN).ToString("#,0.00"), valorRealizado.ToString("#0,0.00") };
            this.dgvA.Rows.Add(T);


            //Custo dia e noite

            if (config != "Dia")
            {

                #region Dia                

                tipo = "A";
                nome = "DIA";
                turno = "A";
                //Acrescenta Setores alimentos dia

                consultaCusto = bllcmv.TotalCustoPorSetorTipoETurno(unidade, tipo, DataI, DataF, turno);

                try
                {
                    valorTotal = Convert.ToDouble(consultaCusto.Rows[0][0]);
                }
                catch
                {
                    valorTotal = 0;
                }

                if ((paxD + paxN) == 0)
                {
                    valorRealizado = 0;
                }
                else
                {
                    valorRealizado = valorTotal / (paxD + paxN);
                }

                S = new string[] { "sub", nome, valorTotal.ToString("#,0.00"), metaD.ToString("#,0.00"), valorRealizado.ToString("#,0.00") };
                this.dgvA.Rows.Add(S);

                BLLConfigCusto bllconfigC = new BLLConfigCusto(cx);

                consultaCentro = bllconfigC.ListarContasPorUnidadeTurnoETipo(unidade, turno, tipo);

                for (int i = 0; i < consultaCentro.Rows.Count; i++)
                {

                    conta = consultaCentro.Rows[i][0].ToString();

                    consultaCusto = bllcmv.TotalCustoPorUnidadeDataEConta(unidade, conta, DataI, DataF);

                    try { valorTotal = Convert.ToDouble(consultaCusto.Rows[0][0]); } catch { valorTotal = 0; }

                    conta = $"{consultaCentro.Rows[i][0].ToString()} - {consultaCentro.Rows[i][1].ToString()}";
                    valorTotal *= Convert.ToDouble(consultaCentro.Rows[i][3]);
                    meta = Convert.ToDouble(consultaCentro.Rows[i][4]) * -1;

                    if ((paxD + paxN) != 0) { valorRealizado = valorTotal / (paxN + paxD); } else { valorRealizado = 0; }

                    V = new string[] { "set", conta, valorTotal.ToString("#,0.00"), meta.ToString("#,0.00"), valorRealizado.ToString("#,0.00") };
                    this.dgvA.Rows.Add(V);
                }

                #endregion

                #region Noite                

                tipo = "A";
                nome = "NOITE";
                turno = "J";
                //Acrescenta Setores alimentos nOITE

                consultaCusto = bllcmv.TotalCustoPorSetorTipoETurno(unidade, tipo, DataI, DataF, turno);

                try
                {
                    valorTotal = Convert.ToDouble(consultaCusto.Rows[0][0]);
                }
                catch
                {
                    valorTotal = 0;
                }

                if ((paxD + paxN) == 0)
                {
                    valorRealizado = 0;
                }
                else
                {
                    valorRealizado = valorTotal / (paxD + paxN);
                }

                S = new string[] { "sub", nome, valorTotal.ToString("#,0.00"), metaN.ToString("#,0.00"), valorRealizado.ToString("#,0.00") };
                this.dgvA.Rows.Add(S);

                consultaCentro = bllconfigC.ListarContasPorUnidadeTurnoETipo(unidade, turno, tipo);

                for (int i = 0; i < consultaCentro.Rows.Count; i++)
                {

                    conta = consultaCentro.Rows[i][0].ToString();

                    consultaCusto = bllcmv.TotalCustoPorUnidadeDataEConta(unidade, conta, DataI, DataF);

                    try { valorTotal = Convert.ToDouble(consultaCusto.Rows[0][0]); } catch { valorTotal = 0; }

                    conta = $"{consultaCentro.Rows[i][0].ToString()} - {consultaCentro.Rows[i][1].ToString()}";
                    valorTotal *= Convert.ToDouble(consultaCentro.Rows[i][3]);
                    meta = Convert.ToDouble(consultaCentro.Rows[i][4]) * -1;

                    if ((paxD + paxN) != 0) { valorRealizado = valorTotal / (paxN + paxD); } else { valorRealizado = 0; }

                    V = new string[] { "set", conta, valorTotal.ToString("#,0.00"), meta.ToString("#,0.00"), valorRealizado.ToString("#,0.00") };
                    this.dgvA.Rows.Add(V);
                }


                //Eventos

                //ajustes e perdas

                //Formata tudo

                #endregion

            }
            else
            {
                #region Dia                

                tipo = "A";
                nome = "DIA";
                turno = "";
                //Acrescenta Setores alimentos dia

                consultaCusto = bllcmv.TotalCustoPorSetorTipoETurno(unidade, tipo, DataI, DataF, turno);

                try
                {
                    valorTotal = Convert.ToDouble(consultaCusto.Rows[0][0]);
                }
                catch
                {
                    valorTotal = 0;
                }

                if ((paxD + paxN) == 0)
                {
                    valorRealizado = 0;
                }
                else
                {
                    valorRealizado = valorTotal / (paxD + paxN);
                }

                S = new string[] { "sub", nome, valorTotal.ToString("#,0.00"), metaD.ToString("#,0.00"), valorRealizado.ToString("#,0.00") };
                this.dgvA.Rows.Add(S);

                BLLConfigCusto bllconfigC = new BLLConfigCusto(cx);

                consultaCentro = bllconfigC.ListarContasPorUnidadeTurnoETipo(unidade, turno, tipo);

                for (int i = 0; i < consultaCentro.Rows.Count; i++)
                {

                    conta = consultaCentro.Rows[i][0].ToString();

                    consultaCusto = bllcmv.TotalCustoPorUnidadeDataEConta(unidade, conta, DataI, DataF);

                    try { valorTotal = Convert.ToDouble(consultaCusto.Rows[0][0]); } catch { valorTotal = 0; }

                    conta = $"{consultaCentro.Rows[i][0].ToString()} - {consultaCentro.Rows[i][1].ToString()}";
                    valorTotal *= Convert.ToDouble(consultaCentro.Rows[i][3]);
                    meta = Convert.ToDouble(consultaCentro.Rows[i][4]) * -1;

                    if ((paxD + paxN) != 0) { valorRealizado = valorTotal / (paxN + paxD); } else { valorRealizado = 0; }

                    V = new string[] { "set", conta, valorTotal.ToString("#,0.00"), meta.ToString("#,0.00"), valorRealizado.ToString("#,0.00") };
                    this.dgvA.Rows.Add(V);
                }

                #endregion

            }

            #region Ajustes                

            consultaCusto = bllcmv.VerificaSetorNoConfig(unidade, "9.5.02.100");

            if (Convert.ToInt32(consultaCusto.Rows[0][0]) > 0)
            {
                BLLConfigCusto bllconfigC = new BLLConfigCusto(cx);

                this.dgvA.Rows.Add(E);
                //AJUSTES E PERDAS

                tipo = "C";
                nome = "AJUSTES E PERDAS";
                turno = "O";
                //Acrescenta Setores alimentos NOITE

                consultaCusto = bllcmv.TotalCustoPorSetorTipoETurno(unidade, tipo, DataI, DataF, turno);

                try
                {
                    valorTotal = Convert.ToDouble(consultaCusto.Rows[0][0]);
                }
                catch
                {
                    valorTotal = 0;
                }

                if ((paxD + paxN) == 0)
                {
                    valorRealizado = 0;
                }
                else
                {
                    valorRealizado = valorTotal / (paxD + paxN);
                }

                S = new string[] { "sub", nome, "CUSTO", "META", "REAL." };
                this.dgvA.Rows.Add(S);

                consultaCentro = bllconfigC.ListarContasPorUnidadeTurnoETipo(unidade, turno, tipo);


                conta = consultaCentro.Rows[0][0].ToString();

                consultaCusto = bllcmv.TotalCustoPorUnidadeDataEConta(unidade, conta, DataI, DataF);

                try { valorTotal = Convert.ToDouble(consultaCusto.Rows[0][0]); } catch { valorTotal = 0; }

                conta = $"{consultaCentro.Rows[0][0].ToString()} - {consultaCentro.Rows[0][1].ToString()}";
                valorTotal *= Convert.ToDouble(consultaCentro.Rows[0][3]);
                meta = Convert.ToDouble(consultaCentro.Rows[0][4]) * -1;

                if ((paxD + paxN) != 0) { valorRealizado = valorTotal / (paxN + paxD); } else { valorRealizado = 0; }

                V = new string[] { "set", conta, valorTotal.ToString("#,0.00"), meta.ToString("#,0.00"), valorRealizado.ToString("#,0.00") };
                this.dgvA.Rows.Add(V);

            }

            #endregion
            
            #region Eventos

            //EVENTOS

            try
            {
                BLLConfigCusto bllconfigC = new BLLConfigCusto(cx);

                tipo = "E";
                nome = "EVENTOS";
                turno = "O";
                //Acrescenta Setores alimentos nOITE
                consultaCusto = bllcmv.VerificaSetorNoConfig(unidade, "9.5.02.118");
                if (Convert.ToInt32(consultaCusto.Rows[0][0]) > 0)
                {
                    this.dgvA.Rows.Add(E);

                    consultaCusto = bllcmv.TotalCustoPorSetorTipoETurno(unidade, tipo, DataI, DataF, turno);

                    try
                    {
                        valorTotal = Convert.ToDouble(consultaCusto.Rows[0][0]);
                    }
                    catch
                    {
                        valorTotal = 0;
                    }

                    if ((paxD + paxN) == 0)
                    {
                        valorRealizado = 0;
                    }
                    else
                    {
                        valorRealizado = valorTotal / (paxD + paxN);
                    }

                    S = new string[] { "sub", nome, "CUSTO", "META", "REAL." };
                    this.dgvA.Rows.Add(S);

                    consultaCentro = bllconfigC.ListarContasPorUnidadeTurnoETipo(unidade, turno, tipo);

                    conta = consultaCentro.Rows[0][0].ToString();

                    consultaCusto = bllcmv.TotalCustoPorUnidadeDataEConta(unidade, conta, DataI, DataF);

                    try { valorTotal = Convert.ToDouble(consultaCusto.Rows[0][0]); } catch { valorTotal = 0; }

                    conta = $"{consultaCentro.Rows[0][0].ToString()} - {consultaCentro.Rows[0][1].ToString()}";
                    valorTotal *= Convert.ToDouble(consultaCentro.Rows[0][3]);
                    meta = Convert.ToDouble(consultaCentro.Rows[0][4]) * -1;

                    if ((paxD + paxN) != 0) { valorRealizado = valorTotal / (paxN + paxD); } else { valorRealizado = 0; }

                    V = new string[] { "set", conta, valorTotal.ToString("#,0.00"), meta.ToString("#,0.00"), valorRealizado.ToString("#,0.00") };
                    this.dgvA.Rows.Add(V);

                }
                else
                {

                }
                
            }
            catch { }
                #endregion            
        }

        private void CarregaDgvB()
        {
            dgvB.Rows.Clear();

            #region VARIÁVEIS COMUNS

            DateTime DataI = new DateTime(Convert.ToInt32(numAno.Value), Convert.ToInt32(cbMes.SelectedValue), 1);

            DateTime DataF = DataI.AddDays(-(DataI.Day - 1)).AddMonths(1).AddDays(-1);

            DataTable consultaCusto, consultaCentro, consultaPax;

            int unidade = Convert.ToInt32(cbUnidade.SelectedValue.ToString());
            int paxD, paxN;

            double valorTotal, meta, valorRealizado, metaD, metaN;
            string nome, turno, tipo, conta;

            String[] V, T, E, C, S;

            //V = Valor, T = Título, E = Espaço C = Cabeçalho, S = Subtitulo
            C = new string[] { "C", "SETOR", "CUSTO", "META", "REAL." };
            E = new string[] { "E", "", "", "", "" };
            
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLConsultaCMV bllcmv = new BLLConsultaCMV(cx);

            //Busca pax Dia e Noite

            BLLConfigUnidade bllconfig = new BLLConfigUnidade(cx);

            consultaPax = bllconfig.LocalizarConfig("TURNOS_VENDA", unidade);
            string config;

            try
            {
                config = consultaPax.Rows[0][0].ToString();
            }
            catch
            {
                config = "";
            }


            paxD = 0;
            paxN = 0;
            metaD = 0;
            metaN = 0;

            if (config == "Dia")
            {
                consultaPax = bllcmv.LocalizarPaxPorTurno(unidade, DataI, DataF, 1);
                try
                {
                    paxD = Convert.ToInt32(Math.Round(Convert.ToDouble(consultaPax.Rows[0][0]), 0));
                }
                catch
                {
                    paxD = 0;
                }

                consultaPax = bllcmv.LocalizarPaxPorTurno(unidade, DataI, DataF, 2);

                try
                {
                    paxN = Convert.ToInt32(Math.Round(Convert.ToDouble(consultaPax.Rows[0][0]), 0));
                }
                catch
                {
                    paxN = 0;
                }

                consultaPax = bllcmv.TotalMetaPorTipoETurno(unidade, "A", "");
                try
                {
                    metaD = Convert.ToDouble(consultaPax.Rows[0][0]);
                }
                catch
                {

                }

            }
            else if (config != "Dia")
            {


                consultaPax = bllcmv.LocalizarPaxPorTurno(unidade, DataI, DataF, 1);
                try
                {
                    paxD = Convert.ToInt32(Math.Round(Convert.ToDouble(consultaPax.Rows[0][0]), 0));
                }
                catch
                {
                    paxD = 0;
                }

                consultaPax = bllcmv.LocalizarPaxPorTurno(unidade, DataI, DataF, 2);

                try
                {
                    paxN = Convert.ToInt32(Math.Round(Convert.ToDouble(consultaPax.Rows[0][0]), 0));
                }
                catch
                {
                    paxN = 0;
                }

                consultaPax = bllcmv.TotalMetaPorTipoETurno(unidade, "A", "A");

                metaD = Convert.ToDouble(consultaPax.Rows[0][0]) * -1;

                consultaPax = bllcmv.TotalMetaPorTipoETurno(unidade, "A", "J");

                metaN = Convert.ToDouble(consultaPax.Rows[0][0]) * -1;


            }

            #endregion


            //Adiciona o cabeçalho
            this.dgvB.Rows.Add(C);

            nome = "BEBIDAS";
            turno = "A";
            tipo = "B";
            consultaCusto = bllcmv.TotalCustoPorTipo(unidade, tipo, DataI, DataF);

            try
            {
                valorTotal = Convert.ToDouble(consultaCusto.Rows[0][0]);
            }
            catch
            {
                valorTotal = 0;
            }

            if ((paxD + paxN) == 0)
            {
                valorRealizado = 0;
            }
            else
            {
                valorRealizado = valorTotal / (paxD + paxN);
            }

            T = new string[] { "Tit", nome, valorTotal.ToString("#,0.00"), (metaD + metaN).ToString("#,0.00"), valorRealizado.ToString("#0,0.00") };
            this.dgvB.Rows.Add(T);


            //Custo dia e noite

            if (config != "Dia")
            {

                #region Dia                

                tipo = "B";
                nome = "DIA";
                turno = "A";
                //Acrescenta Setores alimentos dia

                consultaCusto = bllcmv.TotalCustoPorSetorTipoETurno(unidade, tipo, DataI, DataF, turno);

                try
                {
                    valorTotal = Convert.ToDouble(consultaCusto.Rows[0][0]);
                }
                catch
                {
                    valorTotal = 0;
                }

                if ((paxD + paxN) == 0)
                {
                    valorRealizado = 0;
                }
                else
                {
                    valorRealizado = valorTotal / (paxD + paxN);
                }

                S = new string[] { "sub", nome, valorTotal.ToString("#,0.00"), metaD.ToString("#,0.00"), valorRealizado.ToString("#,0.00") };
                this.dgvB.Rows.Add(S);

                BLLConfigCusto bllconfigC = new BLLConfigCusto(cx);

                consultaCentro = bllconfigC.ListarContasPorUnidadeTurnoETipo(unidade, turno, tipo);

                for (int i = 0; i < consultaCentro.Rows.Count; i++)
                {

                    conta = consultaCentro.Rows[i][0].ToString();

                    consultaCusto = bllcmv.TotalCustoPorUnidadeDataEConta(unidade, conta, DataI, DataF);

                    try { valorTotal = Convert.ToDouble(consultaCusto.Rows[0][0]); } catch { valorTotal = 0; }

                    conta = $"{consultaCentro.Rows[i][0].ToString()} - {consultaCentro.Rows[i][1].ToString()}";
                    valorTotal *= Convert.ToDouble(consultaCentro.Rows[i][3]);
                    meta = Convert.ToDouble(consultaCentro.Rows[i][4]) * -1;

                    if ((paxD + paxN) != 0) { valorRealizado = valorTotal / (paxN + paxD); } else { valorRealizado = 0; }

                    V = new string[] { "set", conta, valorTotal.ToString("#,0.00"), meta.ToString("#,0.00"), valorRealizado.ToString("#,0.00") };
                    this.dgvB.Rows.Add(V);
                }


                #endregion

                #region Noite                

                tipo = "B";
                nome = "NOITE";
                turno = "J";
                //Acrescenta Setores alimentos nOITE

                consultaCusto = bllcmv.TotalCustoPorSetorTipoETurno(unidade, tipo, DataI, DataF, turno);

                try
                {
                    valorTotal = Convert.ToDouble(consultaCusto.Rows[0][0]);
                }
                catch
                {
                    valorTotal = 0;
                }

                if ((paxD + paxN) == 0)
                {
                    valorRealizado = 0;
                }
                else
                {
                    valorRealizado = valorTotal / (paxD + paxN);
                }

                S = new string[] { "sub", nome, valorTotal.ToString("#,0.00"), metaN.ToString("#,0.00"), valorRealizado.ToString("#,0.00") };
                this.dgvB.Rows.Add(S);

                consultaCentro = bllconfigC.ListarContasPorUnidadeTurnoETipo(unidade, turno, tipo);

                for (int i = 0; i < consultaCentro.Rows.Count; i++)
                {

                    conta = consultaCentro.Rows[i][0].ToString();

                    consultaCusto = bllcmv.TotalCustoPorUnidadeDataEConta(unidade, conta, DataI, DataF);

                    try { valorTotal = Convert.ToDouble(consultaCusto.Rows[0][0]); } catch { valorTotal = 0; }

                    conta = $"{consultaCentro.Rows[i][0].ToString()} - {consultaCentro.Rows[i][1].ToString()}";
                    valorTotal *= Convert.ToDouble(consultaCentro.Rows[i][3]);
                    meta = Convert.ToDouble(consultaCentro.Rows[i][4]) * -1;

                    if ((paxD + paxN) != 0) { valorRealizado = valorTotal / (paxN + paxD); } else { valorRealizado = 0; }

                    V = new string[] { "set", conta, valorTotal.ToString("#,0.00"), meta.ToString("#,0.00"), valorRealizado.ToString("#,0.00") };
                    this.dgvB.Rows.Add(V);
                }
                
                #endregion

            }
            else
            {
                #region Dia                

                tipo = "B";
                nome = "DIA";
                turno = "";
                //Acrescenta Setores alimentos dia

                consultaCusto = bllcmv.TotalCustoPorSetorTipoETurno(unidade, tipo, DataI, DataF, turno);

                try
                {
                    valorTotal = Convert.ToDouble(consultaCusto.Rows[0][0]);
                }
                catch
                {
                    valorTotal = 0;
                }

                if ((paxD + paxN) == 0)
                {
                    valorRealizado = 0;
                }
                else
                {
                    valorRealizado = valorTotal / (paxD + paxN);
                }

                S = new string[] { "sub", nome, valorTotal.ToString("#,0.00"), metaD.ToString("#,0.00"), valorRealizado.ToString("#,0.00") };
                this.dgvB.Rows.Add(S);

                BLLConfigCusto bllconfigC = new BLLConfigCusto(cx);

                consultaCentro = bllconfigC.ListarContasPorUnidadeTurnoETipo(unidade, turno, tipo);

                for (int i = 0; i < consultaCentro.Rows.Count; i++)
                {

                    conta = consultaCentro.Rows[i][0].ToString();

                    consultaCusto = bllcmv.TotalCustoPorUnidadeDataEConta(unidade, conta, DataI, DataF);

                    try { valorTotal = Convert.ToDouble(consultaCusto.Rows[0][0]); } catch { valorTotal = 0; }

                    conta = $"{consultaCentro.Rows[i][0].ToString()} - {consultaCentro.Rows[i][1].ToString()}";
                    valorTotal *= Convert.ToDouble(consultaCentro.Rows[i][3]);
                    meta = Convert.ToDouble(consultaCentro.Rows[i][4]) * -1;

                    if ((paxD + paxN) != 0) { valorRealizado = valorTotal / (paxN + paxD); } else { valorRealizado = 0; }

                    V = new string[] { "set", conta, valorTotal.ToString("#,0.00"), meta.ToString("#,0.00"), valorRealizado.ToString("#,0.00") };
                    this.dgvB.Rows.Add(V);
                }

                #endregion

            }

            #region DIVERSOS                

            consultaCusto = bllcmv.VerificaSetorNoConfig(unidade, "9.5.02.100");
            if (Convert.ToInt32(consultaCusto.Rows[0][0]) > 0)
            {
                BLLConfigCusto bllconfigC = new BLLConfigCusto(cx);

                this.dgvB.Rows.Add(E);
                //AJUSTES E PERDAS

                tipo = "O";
                nome = "DIVERSOS";
                turno = "O";
                //Acrescenta Setores alimentos NOITE

                consultaCusto = bllcmv.TotalCustoPorSetorTipoETurno(unidade, tipo, DataI, DataF, turno);

                try
                {
                    valorTotal = Convert.ToDouble(consultaCusto.Rows[0][0]);
                }
                catch
                {
                    valorTotal = 0;
                }

                if ((paxD + paxN) == 0)
                {
                    valorRealizado = 0;
                }
                else
                {
                    valorRealizado = valorTotal / (paxD + paxN);
                }

                S = new string[] { "sub", nome, "CUSTO", "META", "REAL." };
                this.dgvB.Rows.Add(S);

                consultaCentro = bllconfigC.ListarContasPorUnidadeTurnoETipo(unidade, turno, tipo);


                for (int i = 0; i < consultaCentro.Rows.Count; i++)
                {

                    conta = consultaCentro.Rows[i][0].ToString();

                    consultaCusto = bllcmv.TotalCustoPorUnidadeDataEConta(unidade, conta, DataI, DataF);

                    try { valorTotal = Convert.ToDouble(consultaCusto.Rows[0][0]); } catch { valorTotal = 0; }

                    conta = $"{consultaCentro.Rows[i][0].ToString()} - {consultaCentro.Rows[i][1].ToString()}";
                    valorTotal *= Convert.ToDouble(consultaCentro.Rows[i][3]);
                    meta = Convert.ToDouble(consultaCentro.Rows[i][4]) * -1;

                    if ((paxD + paxN) != 0) { valorRealizado = valorTotal / (paxN + paxD); } else { valorRealizado = 0; }

                    V = new string[] { "set", conta, valorTotal.ToString("#,0.00"), meta.ToString("#,0.00"), valorRealizado.ToString("#,0.00") };
                    this.dgvB.Rows.Add(V);
                }
            }

            #endregion

        }

        private void AtualizaDGVs()
        {
            dgvA.Rows.Clear();
            dgvB.Rows.Clear();
            dgvResumo.Rows.Clear();

            CarregaDgvA();
            CarregaDgvB();
            CarregaDgvResumo();

            FormataTudo();
        }

        private void FormataTudo()
        {

            #region DgvA


            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(dgvA.Font, FontStyle.Bold);

            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            style2.Font = new Font(dgvA.Font, FontStyle.Bold);

            dgvA.Rows[1].DataGridView.GridColor = Color.Black;
            for (int i = 0; i < dgvA.Rows.Count; i++)
            {


                if (dgvA.Rows[i].Cells[0].Value.ToString() == "Tit")
                {

                    dgvA.Rows[i].DefaultCellStyle = style;
                    dgvA.Rows[i].DefaultCellStyle.BackColor = Color.Black;
                    dgvA.Rows[i].DataGridView.ForeColor = Color.White;
                }


                if (dgvA.Rows[i].Cells[0].Value.ToString() == "sub")
                {
                    dgvA.Rows[i].DefaultCellStyle = style2;
                    dgvA.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                    dgvA.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }

                if (dgvA.Rows[i].Cells[0].Value.ToString() == "C")
                {
                    dgvA.Rows[i].DefaultCellStyle = style2;
                    dgvA.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                    dgvA.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }

                if (dgvA.Rows[i].Cells[0].Value.ToString() == "E")
                {
                    dgvA.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    dgvA.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                }


                if (dgvA.Rows[i].Cells[0].Value.ToString() == "set")
                {

                    dgvA.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    this.dgvA.RowsDefaultCellStyle.BackColor = Color.White;


                }
            }


            #endregion

            #region DgvB

            style = new DataGridViewCellStyle();
            style.Font = new Font(dgvB.Font, FontStyle.Bold);

            style2 = new DataGridViewCellStyle();
            style2.Font = new Font(dgvB.Font, FontStyle.Bold);

            dgvB.Rows[1].DataGridView.GridColor = Color.Black;
            for (int i = 0; i < dgvB.Rows.Count; i++)
            {


                if (dgvB.Rows[i].Cells[0].Value.ToString() == "Tit")
                {

                    dgvB.Rows[i].DefaultCellStyle = style;
                    dgvB.Rows[i].DefaultCellStyle.BackColor = Color.Black;
                    dgvB.Rows[i].DataGridView.ForeColor = Color.White;
                }


                if (dgvB.Rows[i].Cells[0].Value.ToString() == "sub")
                {
                    dgvB.Rows[i].DefaultCellStyle = style2;
                    dgvB.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                    dgvB.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }

                if (dgvB.Rows[i].Cells[0].Value.ToString() == "C")
                {
                    dgvB.Rows[i].DefaultCellStyle = style2;
                    dgvB.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                    dgvB.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }

                if (dgvB.Rows[i].Cells[0].Value.ToString() == "E")
                {
                    dgvB.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    dgvB.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                }


                if (dgvB.Rows[i].Cells[0].Value.ToString() == "set")
                {

                    dgvB.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    this.dgvB.RowsDefaultCellStyle.BackColor = Color.White;


                }
            }


            #endregion

            #region DgvResumo

            style = new DataGridViewCellStyle();
            style.Font = new Font(dgvResumo.Font, FontStyle.Bold);

            style2 = new DataGridViewCellStyle();
            style2.Font = new Font(dgvResumo.Font, FontStyle.Bold);

            dgvResumo.Rows[1].DataGridView.GridColor = Color.Black;
            for (int i = 0; i < dgvResumo.Rows.Count; i++)
            {


                if (dgvResumo.Rows[i].Cells[0].Value.ToString() == "Tit")
                {

                    dgvResumo.Rows[i].DefaultCellStyle = style;
                    dgvResumo.Rows[i].DefaultCellStyle.BackColor = Color.Black;
                    dgvResumo.Rows[i].DataGridView.ForeColor = Color.White;
                }


                if (dgvResumo.Rows[i].Cells[0].Value.ToString() == "sub")
                {
                    dgvResumo.Rows[i].DefaultCellStyle = style2;
                    dgvResumo.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                    dgvResumo.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }

                if (dgvResumo.Rows[i].Cells[0].Value.ToString() == "C")
                {
                    dgvResumo.Rows[i].DefaultCellStyle = style2;
                    dgvResumo.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                    dgvResumo.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }

                if (dgvResumo.Rows[i].Cells[0].Value.ToString() == "E")
                {
                    dgvResumo.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    dgvResumo.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                }


                if (dgvResumo.Rows[i].Cells[0].Value.ToString() == "Cus")
                {

                    dgvResumo.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    this.dgvResumo.RowsDefaultCellStyle.BackColor = Color.White;


                }
            }


            #endregion

        }

        private void frmCMVRelatorio_Resize(object sender, EventArgs e)
        {
            AtualizaTamanhoTabela();         
           
        }

        private void AtualizaTamanhoTabela()
        {

            tamanho_tabela = tabelaExibicao.Size.Width;

            double TabelaA = 0.39;
            double TabelaB = 0.39;
            double TabelaR = 0.20;
            

            TabelaA *= tamanho_tabela;
            TabelaB *= tamanho_tabela;
            TabelaR *= tamanho_tabela;


            #region TabelaA

            //Margem direita para rolagem
            dgvA.Columns[1].Width = Convert.ToInt32(TabelaA * 0.47);
            dgvA.Columns[2].Width = Convert.ToInt32(TabelaA * 0.21);
            dgvA.Columns[3].Width = Convert.ToInt32(TabelaA * 0.16);
            dgvA.Columns[4].Width = Convert.ToInt32(TabelaA * 0.16);

            #endregion

            #region TabelaB
            dgvB.Columns[1].Width = Convert.ToInt32(TabelaB * 0.47);
            dgvB.Columns[2].Width = Convert.ToInt32(TabelaB * 0.21);
            dgvB.Columns[3].Width = Convert.ToInt32(TabelaB * 0.16);
            dgvB.Columns[4].Width = Convert.ToInt32(TabelaB * 0.16);

            #endregion

            #region TabelaR

            dgvResumo.Columns[1].Width = Convert.ToInt32(TabelaR * 0.6);
            dgvResumo.Columns[2].Width = Convert.ToInt32(TabelaR * 0.4);

            #endregion
            
        }

        private void dgvA_SelectionChanged(object sender, EventArgs e)
        {
            dgvA.ClearSelection();
        }

        private void dgvB_SelectionChanged(object sender, EventArgs e)
        {
            dgvB.ClearSelection();
        }

        private void dgvResumo_SelectionChanged(object sender, EventArgs e)
        {
            dgvResumo.ClearSelection();
        }
    }
}
