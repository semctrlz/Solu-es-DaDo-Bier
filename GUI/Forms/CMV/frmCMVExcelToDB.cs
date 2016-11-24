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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Forms.CMV
{
    public partial class frmExcelToDB : Form
    {
        #region Variáveis

        uint idUsuario, mes;
        int unidade;
        string mesAtual, tipo;
        DateTime competencia;

        #endregion

        #region Inicialização

        public frmExcelToDB(uint id)
        {
            idUsuario = id;
            InitializeComponent();
        }

        private void frmExcelToDB_Load(object sender, EventArgs e)
        {
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(Convert.ToInt32(idUsuario));

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";
            LimparTela();

        }

        #endregion

        #region Clique
        
        private void addBd_Click(object sender, EventArgs e)
        {
            if(dgvExcel.Rows.Count > 0)
            {
                DialogResult d = MessageBox.Show("Deseja realmente lançar estes dados no banco de dados?\nSe sim, clique em \"Sim\" e aguarde.", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {                    
                    AddDB();
                    LimparTela();                                        
                }
            }
        }

        private void btColarDados_Click(object sender, EventArgs e)
        {

            PainelLoading("Por favor, aguarde enquanto o programa executa a cópia dos dados do Excel.");

            btColarDados.Enabled = false;

            #region colar dados do excel


            DataObject o = (DataObject)Clipboard.GetDataObject();
            if (o.GetDataPresent(DataFormats.Text))
            {
                if (dgvExcel.RowCount > 0)
                    dgvExcel.Rows.Clear();

                if (dgvExcel.ColumnCount > 0)
                    dgvExcel.Columns.Clear();

                bool columnsAdded = false;
                string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                foreach (string pastedRow in pastedRows)
                {
                    string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });

                    if (!columnsAdded)
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            dgvExcel.Columns.Add("col" + i, pastedRowCells[i]);

                        columnsAdded = true;
                        continue;
                    }

                    dgvExcel.Rows.Add();
                    int myRowIndex = dgvExcel.Rows.Count - 1;

                    using (DataGridViewRow myDataGridViewRow = dgvExcel.Rows[myRowIndex])
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            myDataGridViewRow.Cells[i].Value = pastedRowCells[i].Replace("R$","").Trim();
                    }
                }
            }

            pnAguarde.Visible = false;
            btColarDados.Enabled = true;

            #endregion

            try
            {
                competencia = Convert.ToDateTime(dgvExcel.Rows[1].Cells[0].Value);
            }
            catch { }
            //Verifica o tipo de dado
            try
            {
                if (dgvExcel.Columns[0].HeaderText == "DATA" && dgvExcel.Columns[1].HeaderText == "PERIODO" && dgvExcel.Columns[2].HeaderText == "GRUPO")
                {
                    lbTipoDado.Text = "Dados do relatório de venda.";
                    btColarDados.Enabled = false;
                    btAddBd.Enabled = true;
                    cbMes.Enabled = false;
                    AtualizaMes(competencia.Month);
                    tipo = "venda";
                }
                else if (dgvExcel.Columns[0].HeaderText == "DATA" && dgvExcel.Columns[1].HeaderText == "PERIODO" && dgvExcel.Columns[2].HeaderText == "CLIMA")
                {
                    lbTipoDado.Text = "Dados do relatório de PAX";
                    btColarDados.Enabled = false;
                    btAddBd.Enabled = true;
                    cbMes.Enabled = false;
                    AtualizaMes(competencia.Month);
                    tipo = "pax";
                }
                else if (dgvExcel.Columns[0].HeaderText == "Data Movimento" && dgvExcel.Columns[1].HeaderText == "Tipo Movimento" && dgvExcel.Columns[2].HeaderText == "Tipo Operacao")
                {
                    lbTipoDado.Text = "Dados do relatório de Custo";
                    btColarDados.Enabled = false;
                    btAddBd.Enabled = true;
                    cbMes.Enabled = false;
                    AtualizaMes(competencia.Month);
                    tipo = "custo";
                }
                else
                {
                    MessageBox.Show("Não foi possível identificar o tipo de dado que você está tentando colar.\n " +
                        "Por favor, verifique se os dados copiados provém do relatório correto.", "Erro");

                    this.LimparTela();

                }

            }
            catch { MessageBox.Show("Erro ao colar os dados."); }
            PainelLoading("");

        }
        
        #endregion

        #region Outros

        private void LimparTela()
        {
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(Convert.ToInt32(idUsuario));

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


            mes = Convert.ToUInt32(DateTime.Now.Month);

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
            dgvExcel.Rows.Clear();
            dgvExcel.Columns.Clear();
            lbTipoDado.Text = "Copie o conteúdo desejado do Excel e clique em \"Colar dados\"";
            btColarDados.Enabled = true;
            btAddBd.Enabled = false;
        }

        private void AddDB()
        {

            DateTime DataI = new DateTime(Convert.ToDateTime(dgvExcel.Rows[1].Cells[0].Value).Year, Convert.ToDateTime(dgvExcel.Rows[1].Cells[0].Value).Month, 1);

            DateTime DataF = DataI.AddDays(-(DataI.Day - 1)).AddMonths(1).AddDays(-1);

            #region Venda


            if (tipo == "venda")
            {

                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

                DTODados ven = new DTODados();
                BLLDados bllven = new BLLDados(cx);

                bllven.Excluir(Convert.ToDateTime(dgvExcel.Rows[1].Cells[0].Value), Convert.ToInt32(cbUnidade.SelectedValue));
                
                for (int i = 0; i < dgvExcel.RowCount; i++)
                {
                    
                    ven.DataVenda = Convert.ToDateTime(dgvExcel.Rows[i].Cells[0].Value);
                    ven.GrupoVenda = Convert.ToInt32(dgvExcel.Rows[i].Cells[2].Value);
                    ven.CanceladosVenda = Convert.ToDouble(dgvExcel.Rows[i].Cells[6].Value);
                    ven.CortesiasVenda = Convert.ToDouble(dgvExcel.Rows[i].Cells[7].Value);
                    ven.PromocoesVenda = Convert.ToDouble(dgvExcel.Rows[i].Cells[8].Value);
                    ven.QuantVenda = Convert.ToDouble(dgvExcel.Rows[i].Cells[9].Value);
                    ven.QuantTotalVenda = Convert.ToDouble(dgvExcel.Rows[i].Cells[10].Value);
                    ven.ValorVenda = Convert.ToDouble(dgvExcel.Rows[i].Cells[18].Value);
                    ven.ValorTotalVenda = Convert.ToDouble(dgvExcel.Rows[i].Cells[19].Value);
                    ven.IdUsuario = Convert.ToInt32(idUsuario);
                    ven.IdUnidade = Convert.ToInt32(cbUnidade.SelectedValue);

                    bllven.Incluir(ven);

                }

                this.LimparTela();
                
            }
            #endregion

            #region Pax
            else if (tipo == "pax")
            {
                
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

                DTODados pax = new DTODados();
                BLLDados bllven = new BLLDados(cx);

                bllven.ExcluirPax(DataI, DataF, Convert.ToInt32(cbUnidade.SelectedValue));

                for (int i = 0; i < dgvExcel.RowCount; i++)
                {

                    if (dgvExcel.Rows[i].Cells[27].Value.ToString() == "FALSO")
                        {
                        pax.DataPax = Convert.ToDateTime(dgvExcel.Rows[i].Cells[0].Value);
                        pax.TurnoPax = Convert.ToInt32(dgvExcel.Rows[i].Cells[1].Value);
                        pax.Pax = Convert.ToDouble(dgvExcel.Rows[i].Cells[6].Value);
                        pax.IdUsuario = Convert.ToInt32(idUsuario);
                        pax.IdUnidade = Convert.ToInt32(cbUnidade.SelectedValue);

                        pax.DiaTurno = (((int)pax.DataPax.DayOfWeek)+1).ToString()+"."+ pax.TurnoPax;



                        bllven.IncluirPax(pax);
                    }
                }

                this.LimparTela();

            }

            #endregion

            #region Custo

            else if (tipo == "custo")
            {

                
                
                DateTime dataatual = Convert.ToDateTime(dgvExcel.Rows[1].Cells[0].Value);

                DateTime Diai = new DateTime(dataatual.Year, dataatual.Month, 1);

                DateTime Diaf = Diai.AddDays(-(Diai.Day - 1)).AddMonths(1).AddDays(-1);

                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

                DTODados cus = new DTODados();
                BLLDados bllven = new BLLDados(cx);
                BLLExcessoesCusto bllexc = new BLLExcessoesCusto(cx);

                bllven.ExcluirCusto(Diai, Diaf, Convert.ToInt32(cbUnidade.SelectedValue));
                
                string tipo, op;

                for (int i = 0; i < dgvExcel.RowCount; i++)
                {
                    
                    tipo = dgvExcel.Rows[i].Cells[3].Value.ToString();
                    op = dgvExcel.Rows[i].Cells[2].Value.ToString();

                    if (dgvExcel.Rows[i].Cells[5].Value.ToString() != "")
                    {
                        //tipo == "CONSUMO - CMV DIVERSOS - A&B" || op == "110.2R" || op == "140.3A" || op == "110.2S" || op == "110.2E" || op == "110.2Y" || op == "110.2U" || op == "210.2B"


                        cus.DataCusto = Convert.ToDateTime(dgvExcel.Rows[i].Cells[0].Value);
                        cus.TipoMovCusto = dgvExcel.Rows[i].Cells[1].Value.ToString();
                        cus.TipoOperacaoCusto = dgvExcel.Rows[i].Cells[2].Value.ToString();
                        cus.DescricaoCusto = dgvExcel.Rows[i].Cells[3].Value.ToString();
                        cus.CodItemCusto = dgvExcel.Rows[i].Cells[4].Value.ToString();
                        cus.ContaGerencialCusto = dgvExcel.Rows[i].Cells[5].Value.ToString();
                        cus.MovimentoCusto = Convert.ToInt32(dgvExcel.Rows[i].Cells[6].Value);
                        cus.QuantMovCusto = Convert.ToDouble(dgvExcel.Rows[i].Cells[8].Value.ToString());
                        cus.ValorUnitarioCusto = Math.Round((Convert.ToDouble(dgvExcel.Rows[i].Cells[9].Value) / cus.QuantMovCusto), 4);
                        cus.TipoDocCusto = dgvExcel.Rows[i].Cells[10].Value.ToString();
                        cus.DocumentoCusto = dgvExcel.Rows[i].Cells[11].Value.ToString();

                        if(cus.TipoOperacaoCusto == "800.01" || (cus.TipoOperacaoCusto == "800.02" && cus.TipoOperacaoCusto == "9.5.02.106") || cus.TipoOperacaoCusto == "110.2R" || cus.TipoOperacaoCusto == "140.3A" || cus.TipoOperacaoCusto == "110.2S" || cus.TipoOperacaoCusto == "110.2E" || cus.TipoOperacaoCusto == "110.2Y" || cus.TipoOperacaoCusto == "110.2U" || cus.TipoOperacaoCusto == "210.2B" || cus.TipoOperacaoCusto == "191.0" || cus.TipoOperacaoCusto == "800.90" || cus.TipoOperacaoCusto == "800.95")
                        {
                            cus.Grupo = "01";
                        }
                        else if(cus.TipoOperacaoCusto == "800.06")
                        {
                            cus.Grupo = "06";
                        }
                        else if (cus.TipoOperacaoCusto == "800.05")
                        {
                            cus.Grupo = "05";
                        }

                        else if (cus.TipoOperacaoCusto == "800.10")
                        {
                            cus.Grupo = "10";
                        }
                        else if (cus.TipoOperacaoCusto == "800.02")
                        {
                            cus.Grupo = "02";
                        }
                        else
                        {
                            cus.Grupo = "";
                        }

                        if (cus.ContaGerencialCusto == "9.5.02.107")
                        {
                            if (cus.CodItemCusto == "01.12.0008")
                            {
                                cus.ValorUnitarioCusto *= 0.096;
                            }
                            else if (cus.CodItemCusto == "01.12.0017")
                            {
                                cus.ValorUnitarioCusto *= 0.62;
                            }
                        }
                        cus.IdUsuario = Convert.ToInt32(idUsuario);
                        cus.IdUnidade = Convert.ToInt32(cbUnidade.SelectedValue);

                        cus.QuantMovCusto *= -1;

                        if (cus.TipoOperacaoCusto == "191.0" || cus.TipoOperacaoCusto == "800.95")
                        {
                            cus.QuantMovCusto *= -1;                           
                        }
                        else
                        {
                            
                        }
                        
                         bllven.IncluirCusto(cus);

                    }
                }

                this.LimparTela();
               
            }

            #endregion

            else
            {
                MessageBox.Show("Esta tabela não atende ao pré-requisitos para ser adicionada ao banco de dados.");
                this.LimparTela();
            }


        }

        private void AtualizaMes(int mestabela)
        {
            
            switch (mestabela)
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

            cbMes.Text = mesAtual;

           
        }

        private void PainelLoading(string mensagem)
        {

            #region Painel de aguardar

            if (mensagem == "")
            {
                pnAguarde.Visible = false;
            }
            else
            {

                pnAguarde.Location = new Point(this.ClientSize.Width / 2 - pnAguarde.Size.Width / 2, this.ClientSize.Height / 2 - pnAguarde.Size.Height / 2);
                pnAguarde.Anchor = AnchorStyles.None;
                lbLoadingAviso.Text = mensagem;

                pnAguarde.Visible = true;

            }
            #endregion


        }

        #endregion
    }
}
