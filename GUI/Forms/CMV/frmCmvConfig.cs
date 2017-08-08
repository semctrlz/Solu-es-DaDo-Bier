using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Code.DAL;
using GUI.Code.BLL;
using GUI.Code.DTO;
namespace GUI
{
    public partial class frmCmvConfig : Form
    {

        #region Inicialização

        int idUsuario;
        bool inicializado = false;

        public frmCmvConfig(int id)
        {
            idUsuario = id;
            InitializeComponent();
        }

        private void frmCmvConfig_Load(object sender, EventArgs e)
        {

            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(Convert.ToInt32(idUsuario));

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";
            LimparTela();
            LimparDados();
            CarregarCG();
            CarregaDgvCusto();
            CarregaReceita();
            CarregaCbDias();
            inicializado = true;
        }

        #endregion

        #region Custo

        public class Language
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        private void LimparTela()
        {
            #region Combobox unidade
                      
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(Convert.ToInt32(idUsuario));

                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLUnidade bllun = new BLLUnidade(cx);

            if (!inicializado)
            {
                cbUnidade.DataSource = bllun.ListarUnidades();
                cbUnidade.DisplayMember = "cod_unidade";
                cbUnidade.ValueMember = "id_unidade";
    cbUnidade.Text = modelou.IdUnidade.ToString("00");

                if (modelou.PermissaoUsuario < 4)
                {

                    cbUnidade.Enabled = false;
                }
            }
            #endregion

            #region Config tipo de controle de  venda

            int unidade = Convert.ToInt32(cbUnidade.SelectedValue);
            string tipoConfig = "TURNOS_VENDA";
            
            BLLConfigUnidade bllconfig = new BLLConfigUnidade(cx);
            
            DTOConfigUnidade modeloconfig = bllconfig.CarregaModeloConfig(tipoConfig, unidade);

            if (string.IsNullOrEmpty(modeloconfig.Config))
            {
                var dataSource = new List<Language>();


                dataSource.Add(new Language() { Name = "Almoço e janter (Custo, receita e pax)", Value = "Almoço e janter (Custo, receita e pax)" });
                dataSource.Add(new Language() { Name = "Almoço e janter (Custo e pax)", Value = "Almoço e janter (Custo e pax)" });
                dataSource.Add(new Language() { Name = "Dia", Value = "Dia" });

                //Setup data binding
                this.cbTipo.DataSource = dataSource;
                this.cbTipo.DisplayMember = "Name";
                this.cbTipo.ValueMember = "Value";
                this.cbTipo.Text = "";

                gbDados.Enabled = false;
                gbPax.Enabled = false;
                gbReceita.Enabled = false;
                cbTipo.Enabled = true;
                btEditaConfig.Enabled = false;
            }

            else
            { 
                
                cbTipo.DataSource = bllconfig.LocalizarConfig(tipoConfig, unidade);
                cbTipo.DisplayMember = "config";
                cbTipo.ValueMember = "config";
                cbTipo.Enabled = false;
                btEditaConfig.Enabled = true;
                gbDados.Enabled = true;
                gbPax.Enabled = true;
                gbReceita.Enabled = true;
            }


            #endregion

            cbTurno.Enabled = true;
            cbTurnoReceita.Enabled = true;

            if (cbTipo.SelectedValue.ToString() == "Dia")
            {
                cbTurno.Enabled = false;
                gbPax.Enabled = false;
                

            }
            if (cbTipo.SelectedValue.ToString() != "Almoço e janter (Custo, receita e pax)")
            {
                
                cbTurnoReceita.Enabled = false;

            }

            CarregaCbContas();
        }
        
        private void LimparDados()
        {
            cbContaGerencial.Text = "";
            txtNome.Clear();
            txtDivisao.Text = "100%";
            txtMetaValor.Text = "0,00";            
            txtMetaPercent.Clear();
            cbTurno.Text = "";
            dgvReceita.Rows.Clear();
            txtCodAdmin.Value = 0;
            cbCorrespConta.Text = "";
            cbGrupo.Text = "";
            cbTurnoReceita.Text = "";
            dgvCusto.Rows.Clear();
            txtNomeReceita.Clear();
            CarregaCbDias();
            CarregaDgvCusto();
            CarregaReceita();
            CarregaImpostos();


        }

        private void CarregarCG()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLContasGerenciais bllcg = new BLLContasGerenciais(cx);
            cbContaGerencial.DataSource = bllcg.Localizar("select (cod_setor + ' - ' + nome_setor) as setor, cod_setor, nome_setor from conta_gerencial;");
            cbContaGerencial.DisplayMember = "setor";
            cbContaGerencial.Text = "";
            cbContaGerencial.ValueMember = string.Format("cod_setor");
            
        }

        private void txtDivisao_Validating(object sender, CancelEventArgs e)
        {
            double doubleValue;

            string txt = txtDivisao.Text.Replace("%", "");
            
            if (Double.TryParse(txt, out doubleValue) && Convert.ToDouble(txt) <= 100 && Convert.ToDouble(txt) >= 1)
            {
                txtDivisao.Text = (doubleValue/100).ToString("0%");
            
            }
            
            else if (txtDivisao.Text == "")
            {
            }
            else
            {
                e.Cancel = true;
                MessageBox.Show("Digite um valor numérico inteiro entre 1% e 100%.");
            }
        }

        private void txtMetaPercent_Validating(object sender, CancelEventArgs e)
        {
            double doubleValue;

            string txt = txtMetaPercent.Text.Replace("%", "");

            if (Double.TryParse(txt, out doubleValue) && Convert.ToDouble(txt) <= 100 && Convert.ToDouble(txt) >= 0.01)
            {
                txtMetaPercent.Text = (doubleValue / 100).ToString("00.00%");
               
            }

            else if (txtMetaPercent.Text == "")
            {
            }
            else
            {
                e.Cancel = true;
                MessageBox.Show("Digite um valor numérico, com até duas casas decimais, entre 0,01% e 100%.");
            }
        }

        private void txtMetaValor_Validating(object sender, CancelEventArgs e)
        {
            double doubleValue;

            if (Double.TryParse(txtMetaValor.Text, out doubleValue))
            {
                txtMetaValor.Text = doubleValue.ToString("#,0.00");

            }

            else if (txtMetaValor.Text == "")
            {
            }
            else
            {
                e.Cancel = true;
                MessageBox.Show("Digite um valor numérico, com até duas casas decimais.");
            }
        }

        private void btEditaConfig_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show($"Deseja realmente alterar a configuração de tipo de acompanhamento do CMV?\n"+
                "Ao realizar esta alteração todas as configurações do quadro abaixo terão de ser refeitas. Continuar?", "Aviso", MessageBoxButtons.YesNo);
            if (d.ToString() == "Yes")
            {
                int unidade = Convert.ToInt32(cbUnidade.SelectedValue);
                string tipoConfig = "TURNOS_VENDA";


                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

                DTOConfigUnidade ven = new DTOConfigUnidade();
                BLLConfigUnidade bllconfig = new BLLConfigUnidade(cx);

                bllconfig.Excluir(tipoConfig, unidade);

                BLLConfigCusto bllconfigcusto = new BLLConfigCusto(cx);

                bllconfigcusto.ExcluirUnidade(unidade);

                BLLConfigReceita bllconfigreceita = new BLLConfigReceita(cx);

                bllconfigreceita.ExcluirTudo(unidade);

                // excluir config_custo
                LimparDados();

                LimparTela();
                
            }
            
        }

        private void cbTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {

                int unidade = Convert.ToInt32(cbUnidade.SelectedValue);
                string tipoConfig = "TURNOS_VENDA";
                cbTurno.Enabled = true;

                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

                DTOConfigUnidade config = new DTOConfigUnidade();
                BLLConfigUnidade bllconfig = new BLLConfigUnidade(cx);

                config.TipoConfig = tipoConfig;
                config.IdUnidade = unidade;
                config.Config = cbTipo.SelectedValue.ToString();

                bllconfig.Incluir(config);

                LimparDados();
                LimparTela();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }
        
        private void cbContaGerencial_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

                BLLContasGerenciais bllcontas = new BLLContasGerenciais(cx);

                DTOContasGerenciais modelocontas = bllcontas.CarregaModeloContaCodigo(cbContaGerencial.SelectedValue.ToString());

                txtNome.Text = modelocontas.NomeSetor;
            }
            catch
            {

            }
        }

        private void txtNome_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () {
                txtNome.SelectAll();
            });
        }

        private void txtDivisao_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () {
                txtDivisao.SelectAll();
            });
        }

        private void txtMetaValor_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () {
                txtMetaValor.SelectAll();
            });
        }

        private void txtMetaPercent_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () {
                txtMetaPercent.SelectAll();
            });
        }
        
        private void btAddConta_Click(object sender, EventArgs e)
        {

            //Validações
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLContasGerenciais bllconta = new BLLContasGerenciais(con);
                        
            DTOContasGerenciais modeloconta = bllconta.CarregaModeloContaCodigo(cbContaGerencial.SelectedValue.ToString());
            
            
            if (!string.IsNullOrEmpty(modeloconta.NomeSetor.ToString()))
            {

                if ((((modeloconta.TipoSetor == "A" || modeloconta.TipoSetor == "B") && (cbTurno.Text == "Almoço" || cbTurno.Text == "Jantar")) || (modeloconta.TipoSetor == "O" || modeloconta.TipoSetor == "F" || modeloconta.TipoSetor == "C" || modeloconta.TipoSetor == "E")) || cbTipo.Text == "Dia")
                {

                    if (txtNome.Text != "")
                    {

                        AddConta();
                    }
                    else
                    {
                        MessageBox.Show("Escolha um nome para identificar esta conta.");
                    }
                }

                else
                {
                    MessageBox.Show("Escolha um turno para atribuir esta conta.");
                    
                }
               
            }
            else
            {

                MessageBox.Show("Conta gerencial inválida.");
                cbContaGerencial.Focus();

            }
            
        }

        private void AddConta()
        {
            //Validações
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLContasGerenciais bllconta = new BLLContasGerenciais(con);

            DTOContasGerenciais modeloconta = bllconta.CarregaModeloContaCodigo(cbContaGerencial.SelectedValue.ToString());

            #region Formatações
            string codSetor = cbContaGerencial.SelectedValue.ToString();
            string nomeSetor = txtNome.Text.ToUpper();
            
            double divisaoCusto = 1;

            if (txtDivisao.Text != "")
            {
                divisaoCusto = Math.Round((Convert.ToDouble(txtDivisao.Text.Replace("%", "")) / 100), 2);
            }
            

            double metaPercapta = 0;

            if(txtMetaValor.Text != "")
            {
                metaPercapta = Math.Round(Convert.ToDouble(txtMetaValor.Text), 2);
            }

            double metaPercentual = 0;

            if (txtMetaPercent.Text != "")
            {
                metaPercentual = Math.Round((Convert.ToDouble(txtMetaPercent.Text.Replace("%", "")) / 100), 4);
            }
           
            
            string turno;

            string turnoSelecionado = cbTurno.Text;

            if(modeloconta.TipoSetor.ToString() != "A" && modeloconta.TipoSetor.ToString() != "B")
            {
                turnoSelecionado = "Outros";
            }

            switch (turnoSelecionado)
            {
                case "Almoço":
                    turno = "A";
                    break;
                case "Jantar":
                    turno = "J";
                    break;
                case "Outros":
                    turno = "O";
                    break;

                default:
                    turno = "";
                    break;
            }
            #endregion
            //Add Banco

            DTOConfigCusto modelo = new DTOConfigCusto();

            modelo.CodSetor = codSetor;
            modelo.NomeSetor = nomeSetor;
            if(modelo.DivisaoCustoSetor.ToString() == "")
            {
                modelo.DivisaoCustoSetor = 0;
            }else
            {

            modelo.DivisaoCustoSetor = divisaoCusto;

            }
            modelo.MetaPercapta = metaPercapta;

            if (modelo.MetaPercentual.ToString() == "")
            {
                modelo.MetaPercentual = 0;
            }
            else
            {
                modelo.MetaPercentual = metaPercentual;
            }
            
            modelo.Turno = turno;
            modelo.IdUnidade = Convert.ToInt32(cbUnidade.SelectedValue);

            //conexão
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLConfigCusto bll = new BLLConfigCusto(cx);
            bll.Incluir(modelo);

            CarregaCbContas();


            //Limpar dados
            LimparDados();
            
            cbContaGerencial.Focus();

            //Atiualiza Data Grid View
        }

        private void CarregaDgvCusto()
        {

            dgvCusto.Rows.Clear();
            SqlConnection con = new SqlConnection(DadosDaConexao.StringDaConexao.ToString()); // making connection   
            SqlDataAdapter conUni = new SqlDataAdapter("select c.id_config_custo, c.cod_setor, c.nome_setor, c.divisao_custo_setor, c.meta_percapta, " +
                "c.meta_percentual, c.turno, g.tipo_setor from config_custo c inner join conta_gerencial g on c.cod_setor = g.cod_setor " +
                $"where id_unidade = {Convert.ToInt32(cbUnidade.SelectedValue)} order by c.turno, g.tipo_setor;", con);

            DataTable contable = new DataTable(); //this is creating a virtual table  

            conUni.Fill(contable);
            
            if (contable.Rows.Count > 0)
            {
                string turno;
                string turnoAnterior = "";
                string tipoAnterior = "";
                string nomeTipo;


                Image bco = new Bitmap(1, 1);


                for (int i = 0; i < contable.Rows.Count; i++)
                {

                    #region Lê e formata os dados

                    //Obtem e formata os dados da tabela

                    string idConficCusto = Convert.ToString(contable.Rows[i][0]);
                    string codSetor = Convert.ToString(contable.Rows[i][1]);
                    string nomeSetor = Convert.ToString(contable.Rows[i][2]);
                    string divisaoCusto = Convert.ToString(Convert.ToDouble(contable.Rows[i][3]) * 100) + "%";
                    string metaPercapta = Convert.ToDouble(contable.Rows[i][4]).ToString("0.00");
                    string metaPercentual = Convert.ToString(Convert.ToDouble(contable.Rows[i][5]) * 100) + "%";
                    string tipo = Convert.ToString(contable.Rows[i][7]);
                    switch (Convert.ToString(contable.Rows[i][6]))
                    {
                        case "A":
                            turno = "Almoço";
                            break;
                        case "J":
                            turno = "Jantar";
                            break;
                        case "O":
                            turno = "Outros";
                            break;
                        default:
                            turno = "";
                            break;
                    }

                    #endregion

                    if (turnoAnterior != turno)
                    {
                        if (i > 0)
                        {
                            String[] E = new string[] { "0", "", "", "", "", "", "" };
                            this.dgvCusto.Rows.Add(E);
                            tipoAnterior = "";
                        }


                        String[] T = new string[] { "-2", "", turno.ToUpper(), "", "", "", "" };
                        this.dgvCusto.Rows.Add(T);
                    }

                    if (cbTipo.Text == "Dia" && i == 0 && (tipo == "A" || tipo == "B"))
                    {

                        String[] T = new string[] { "-2", "", "BUFFET", "", "", "", "" };
                        this.dgvCusto.Rows.Add(T);

                    }


                    if (tipoAnterior != tipo)
                    {

                        switch (tipo)
                        {
                            case "A":
                                nomeTipo = "ALIMENTOS";
                                break;
                            case "B":
                                nomeTipo = "BEBIDAS";
                                break;
                            case "C":
                                nomeTipo = "AJUSTES E PERDAS DE ESTOQUE";
                                break;
                            case "F":
                                nomeTipo = "ALIMENTAÇÃO DE FUNCIONÁRIOS";
                                break;
                            case "E":
                                nomeTipo = "EVENTOS";
                                break;

                            default:
                                nomeTipo = "DIVERSOS";
                                break;
                        }


                        String[] S = new string[] { "-1", "COD", nomeTipo, "DIV. CUSTO", "META $", "META %", "" };
                        this.dgvCusto.Rows.Add(S);
                    }


                    

                    String[] P = new string[] { idConficCusto, codSetor, nomeSetor, divisaoCusto, metaPercapta, metaPercentual, turno };
                    this.dgvCusto.Rows.Add(P);
                    FormataDados();
                    turnoAnterior = turno;
                    tipoAnterior = tipo;

                }

                for (int i = 0; i < dgvCusto.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dgvCusto.Rows[i].Cells[0].Value) <= 0)
                    {
                        dgvCusto.Rows[i].Cells[7].Value = new System.Drawing.Bitmap(1, 1);
                    }
                }

            }

        }

        private void FormataDados()
        {

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(dgvCusto.Font, FontStyle.Bold);

            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            style2.Font = new Font(dgvCusto.Font, FontStyle.Bold);

            dgvCusto.Rows[1].DataGridView.GridColor = Color.Black;
            for (int i = 0; i < dgvCusto.Rows.Count; i++)
            {

               
                if (dgvCusto.Rows[i].Cells[0].Value.ToString() == "-2")
                {
                    
                    dgvCusto.Rows[i].DefaultCellStyle = style;                                        
                    dgvCusto.Rows[i].DefaultCellStyle.BackColor = Color.Black;
                    dgvCusto.Rows[i].DataGridView.ForeColor = Color.White;
                }


                if (dgvCusto.Rows[i].Cells[0].Value.ToString() == "-1")
                {
                    dgvCusto.Rows[i].DefaultCellStyle = style2;                   
                    dgvCusto.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                    dgvCusto.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }


                if (dgvCusto.Rows[i].Cells[0].Value.ToString() == "0")
                {
                    dgvCusto.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    dgvCusto.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                }


                if (Convert.ToInt32(dgvCusto.Rows[i].Cells[0].Value) > 0)
                {

                    dgvCusto.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    this.dgvCusto.RowsDefaultCellStyle.BackColor = Color.White;
                    
                      
                }
            }



        }

        private void dgvCusto_SelectionChanged(object sender, EventArgs e)
        {
            dgvCusto.ClearSelection();
        }

        private void cbUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializado)
            {
                LimparTela();
                LimparDados();
                CarregaReceita();
                CarregaImpostos();
                CarregaCbDias();
                CarregaDgvCusto();
            }
        }

        #endregion

        #region Receita/Pax

        private void CarregaCbContas()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLConfigCusto bllconfigcusto = new BLLConfigCusto(cx);
            
            cbCorrespConta.DataSource = bllconfigcusto.ListarContas(Convert.ToInt32(cbUnidade.SelectedValue));

            cbCorrespConta.DisplayMember = "setor";
            cbCorrespConta.ValueMember = "id_config_custo";
            cbCorrespConta.SelectedValue = 0;
            cbCorrespConta.Text = "";
        }

        private void CarregaCbDias()
        {

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLConfigPax bllpax = new BLLConfigPax(cx);

            DataTable dt = bllpax.Localizar(Convert.ToInt32(cbUnidade.SelectedValue));


            if(dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string dia = Convert.ToString(dt.Rows[i][0]);
                    bool valor = Convert.ToBoolean(dt.Rows[i][1]);

                    if (dia == "2.1")
                    {
                        cbSegD.Text = ValorSelecionado(valor);
                    }
                    if (dia == "2.2")
                    {
                        cbSegN.Text = ValorSelecionado(valor);
                    }
                    if (dia == "3.1")
                    {
                        cbTerD.Text = ValorSelecionado(valor);
                    }
                    if (dia == "3.2")
                    {
                        cbTerN.Text = ValorSelecionado(valor);
                    }
                    if (dia == "4.1")
                    {
                        cbQuaD.Text = ValorSelecionado(valor);
                    }
                    if (dia == "4.2")
                    {
                        cbQuaN.Text = ValorSelecionado(valor);
                    }
                    if (dia == "5.1")
                    {
                        cbQuiD.Text = ValorSelecionado(valor);
                    }
                    if (dia == "5.2")
                    {
                        cbQuiN.Text = ValorSelecionado(valor);
                    }
                    if (dia == "6.1")
                    {
                        cbSexD.Text = ValorSelecionado(valor);
                    }
                    if (dia == "6.2")
                    {
                        cbSexN.Text = ValorSelecionado(valor);
                    }
                    if (dia == "7.1")
                    {
                        cbSabD.Text = ValorSelecionado(valor);
                    }
                    if (dia == "7.2")
                    {
                        cbSabN.Text = ValorSelecionado(valor);
                    }
                    if (dia == "1.1")
                    {
                        cbDomD.Text = ValorSelecionado(valor);
                    }
                    if (dia == "1.2")
                    {
                        cbDomN.Text = ValorSelecionado(valor);
                    }
                }



            }
               
        }

        private void SalvaCbDias()
        {

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

            BLLConfigPax bllpax = new BLLConfigPax(cx);

            DTOConfigPax dto = new DTOConfigPax();

            DataTable dt;

            dto.IdUnidade = Convert.ToInt32(cbUnidade.SelectedValue);
            
            //SEG - D
            dto.ConfigDiaPax = "2.1";
            if(cbSegD.Text == "Almoço") { dto.ConfigDiaValor = true; }else{ dto.ConfigDiaValor = false; }
            dt = bllpax.LocalizarDia(dto.IdUnidade, dto.ConfigDiaPax);
            if (dt.Rows.Count > 0){ bllpax.Alterar(dto); }else{  bllpax.Incluir(dto); }

            //SEG - N
            dto.ConfigDiaPax = "2.2";
            if (cbSegN.Text == "Almoço") { dto.ConfigDiaValor = true; } else { dto.ConfigDiaValor = false; }
            dt = bllpax.LocalizarDia(dto.IdUnidade, dto.ConfigDiaPax);
            if (dt.Rows.Count > 0) { bllpax.Alterar(dto); } else { bllpax.Incluir(dto); }

            //TER - D
            dto.ConfigDiaPax = "3.1";
            if (cbTerD.Text == "Almoço") { dto.ConfigDiaValor = true; } else { dto.ConfigDiaValor = false; }
            dt = bllpax.LocalizarDia(dto.IdUnidade, dto.ConfigDiaPax);
            if (dt.Rows.Count > 0) { bllpax.Alterar(dto); } else { bllpax.Incluir(dto); }

            //TER - N
            dto.ConfigDiaPax = "3.2";
            if (cbTerN.Text == "Almoço") { dto.ConfigDiaValor = true; } else { dto.ConfigDiaValor = false; }
            dt = bllpax.LocalizarDia(dto.IdUnidade, dto.ConfigDiaPax);
            if (dt.Rows.Count > 0) { bllpax.Alterar(dto); } else { bllpax.Incluir(dto); }

            //QUA - D
            dto.ConfigDiaPax = "4.1";
            if (cbQuaD.Text == "Almoço") { dto.ConfigDiaValor = true; } else { dto.ConfigDiaValor = false; }
            dt = bllpax.LocalizarDia(dto.IdUnidade, dto.ConfigDiaPax);
            if (dt.Rows.Count > 0) { bllpax.Alterar(dto); } else { bllpax.Incluir(dto); }

            //QUA - N
            dto.ConfigDiaPax = "4.2";
            if (cbQuaN.Text == "Almoço") { dto.ConfigDiaValor = true; } else { dto.ConfigDiaValor = false; }
            dt = bllpax.LocalizarDia(dto.IdUnidade, dto.ConfigDiaPax);
            if (dt.Rows.Count > 0) { bllpax.Alterar(dto); } else { bllpax.Incluir(dto); }

            //QUI - D
            dto.ConfigDiaPax = "5.1";
            if (cbQuiD.Text == "Almoço") { dto.ConfigDiaValor = true; } else { dto.ConfigDiaValor = false; }
            dt = bllpax.LocalizarDia(dto.IdUnidade, dto.ConfigDiaPax);
            if (dt.Rows.Count > 0) { bllpax.Alterar(dto); } else { bllpax.Incluir(dto); }

            //QUI - N
            dto.ConfigDiaPax = "5.2";
            if (cbQuiN.Text == "Almoço") { dto.ConfigDiaValor = true; } else { dto.ConfigDiaValor = false; }
            dt = bllpax.LocalizarDia(dto.IdUnidade, dto.ConfigDiaPax);
            if (dt.Rows.Count > 0) { bllpax.Alterar(dto); } else { bllpax.Incluir(dto); }

            //SEX - D
            dto.ConfigDiaPax = "6.1";
            if (cbSexD.Text == "Almoço") { dto.ConfigDiaValor = true; } else { dto.ConfigDiaValor = false; }
            dt = bllpax.LocalizarDia(dto.IdUnidade, dto.ConfigDiaPax);
            if (dt.Rows.Count > 0) { bllpax.Alterar(dto); } else { bllpax.Incluir(dto); }

            //SEX - N
            dto.ConfigDiaPax = "6.2";
            if (cbSexN.Text == "Almoço") { dto.ConfigDiaValor = true; } else { dto.ConfigDiaValor = false; }
            dt = bllpax.LocalizarDia(dto.IdUnidade, dto.ConfigDiaPax);
            if (dt.Rows.Count > 0) { bllpax.Alterar(dto); } else { bllpax.Incluir(dto); }

            //SAB - D
            dto.ConfigDiaPax = "7.1";
            if (cbSabD.Text == "Almoço") { dto.ConfigDiaValor = true; } else { dto.ConfigDiaValor = false; }
            dt = bllpax.LocalizarDia(dto.IdUnidade, dto.ConfigDiaPax);
            if (dt.Rows.Count > 0) { bllpax.Alterar(dto); } else { bllpax.Incluir(dto); }

            //SAB - N
            dto.ConfigDiaPax = "7.2";
            if (cbSabN.Text == "Almoço") { dto.ConfigDiaValor = true; } else { dto.ConfigDiaValor = false; }
            dt = bllpax.LocalizarDia(dto.IdUnidade, dto.ConfigDiaPax);
            if (dt.Rows.Count > 0) { bllpax.Alterar(dto); } else { bllpax.Incluir(dto); }

            //DOM - D
            dto.ConfigDiaPax = "1.1";
            if (cbDomD.Text == "Almoço") { dto.ConfigDiaValor = true; } else { dto.ConfigDiaValor = false; }
            dt = bllpax.LocalizarDia(dto.IdUnidade, dto.ConfigDiaPax);
            if (dt.Rows.Count > 0) { bllpax.Alterar(dto); } else { bllpax.Incluir(dto); }

            //DOM - N
            dto.ConfigDiaPax = "1.2";
            if (cbDomN.Text == "Almoço") { dto.ConfigDiaValor = true; } else { dto.ConfigDiaValor = false; }
            dt = bllpax.LocalizarDia(dto.IdUnidade, dto.ConfigDiaPax);
            if (dt.Rows.Count > 0) { bllpax.Alterar(dto); } else { bllpax.Incluir(dto); }
            
            MessageBox.Show("Configuração de Pax/Dia salva com sucesso.");
            
        }

        private string ValorSelecionado(bool condicao)
        {
            string retorno;

            if (condicao)
            {
                retorno = "Almoço";
            }
            else
            {
                retorno = "jantar";
            }
            
            return retorno;
        }

        private void CarregaReceita()
        {
            dgvReceita.Rows.Clear();

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

            BLLConfigReceita bllcr = new BLLConfigReceita(cx);

            BLLConfigCusto bllcus = new BLLConfigCusto(cx);

            DataTable tabelaconta;

            DataTable tabelareceita = bllcr.LocalizarConfig(Convert.ToInt32(cbUnidade.SelectedValue));
            

            if (tabelareceita.Rows.Count > 0)
            {
               
                string turnoAnterior = "";
                string tipoAnterior = "";
                string nomeTipo;
                string contaGerencial = "";

                Image bco = new Bitmap(1, 1);


                for (int i = 0; i < tabelareceita.Rows.Count; i++)
                {

                    #region Lê e formata os dados

                    //Obtem e formata os dados da tabela

                    string idConfigReceita = Convert.ToString(tabelareceita.Rows[i][0]);
                    string codReceita = Convert.ToString(tabelareceita.Rows[i][1]);
                    string nomeReceita = Convert.ToString(tabelareceita.Rows[i][2]);
                    tabelaconta = bllcus.BuscaContaMaisNomePeloId(Convert.ToInt32(tabelareceita.Rows[i][3]));

                    try
                    {
                       contaGerencial = Convert.ToString(tabelaconta.Rows[0][0]);
                    }
                    catch { contaGerencial = ""; }
                    BLLConfigCusto bllcusto = new BLLConfigCusto(cx);

                    DataTable tabelaContas = bllcusto.BuscaContaMaisNome(Convert.ToInt32(cbUnidade.SelectedValue), contaGerencial);
                    if(tabelaContas.Rows.Count > 0)
                    {
                        contaGerencial = Convert.ToString(tabelaContas.Rows[0][0]);
                    }
                    
                    string tipo = Convert.ToString(tabelareceita.Rows[i][4]);

                    string turno = "";

                    switch (Convert.ToString(tabelareceita.Rows[i][5]))
                    {
                        case "A":
                            turno = "ALMOÇO";
                            break;
                        case "J":
                            turno = "JANTAR";
                            break;
                        case "D":
                            turno = "DIVERSOS";
                            break;                        
                        default:
                            turno = "BUFFET";
                            break;
                    }



                    #endregion

                    if (turnoAnterior != turno)
                    {
                        if (i > 0)
                        {
                            String[] E = new string[] { "0", "", "", "" };
                            this.dgvReceita.Rows.Add(E);
                            tipoAnterior = "";
                        }


                        String[] T = new string[] { "-2", "", turno.ToUpper(), "" };
                        this.dgvReceita.Rows.Add(T);
                    }
                    

                    if (tipoAnterior != tipo)
                    {

                        switch (tipo)
                        {
                            case "A":
                                nomeTipo = "ALIMENTOS";
                                break;
                            case "B":
                                nomeTipo = "BEBIDAS";
                                break;
                            case "C":
                                nomeTipo = "AJUSTES E PERDAS DE ESTOQUE";
                                break;
                            case "F":
                                nomeTipo = "ALIMENTAÇÃO DE FUNCIONÁRIOS";
                                break;
                            case "E":
                                nomeTipo = "EVENTOS";
                                break;

                            default:
                                nomeTipo = "DIVERSOS";
                                break;
                        }


                        String[] S = new string[] { "-1", "ADMIN", nomeTipo, "CONTA REFERÊNCIA" };
                        this.dgvReceita.Rows.Add(S);
                    }
                    

                    String[] P = new string[] { idConfigReceita, codReceita, nomeReceita, contaGerencial, tipo, Convert.ToString(tabelareceita.Rows[i][5]) };
                    this.dgvReceita.Rows.Add(P);
                    turnoAnterior = turno;
                    tipoAnterior = tipo;
                    FormataReceita();

                }
            }

        }

        private void FormataReceita()
        {

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(dgvReceita.Font, FontStyle.Bold);

            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            style2.Font = new Font(dgvReceita.Font, FontStyle.Bold);

            dgvReceita.Rows[1].DataGridView.GridColor = Color.Black;
            for (int i = 0; i < dgvReceita.Rows.Count; i++)
            {


                if (dgvReceita.Rows[i].Cells[0].Value.ToString() == "-2")
                {

                    dgvReceita.Rows[i].DefaultCellStyle = style;
                    dgvReceita.Rows[i].DefaultCellStyle.BackColor = Color.Black;
                    dgvReceita.Rows[i].DataGridView.ForeColor = Color.White;
                }


                if (dgvReceita.Rows[i].Cells[0].Value.ToString() == "-1")
                {
                    dgvReceita.Rows[i].DefaultCellStyle = style2;
                    dgvReceita.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                    dgvReceita.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }


                if (dgvReceita.Rows[i].Cells[0].Value.ToString() == "0")
                {
                    dgvReceita.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    dgvReceita.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                }


                if (Convert.ToInt32(dgvReceita.Rows[i].Cells[0].Value) > 0)
                {

                    dgvReceita.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    this.dgvReceita.RowsDefaultCellStyle.BackColor = Color.White;
                    
                }
                
            }

            for (int i = 0; i < dgvReceita.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvReceita.Rows[i].Cells[0].Value) <= 0)
                {
                    dgvReceita.Rows[i].Cells[6].Value = new System.Drawing.Bitmap(1, 1);
                }
            }

        }
                
        private void dgvReceita_SelectionChanged(object sender, EventArgs e)
        {
            dgvReceita.ClearSelection();
        }

        private void btAddReceita_Click(object sender, EventArgs e)
        {
            //Ler dados

            DTOConfigReceita dtoReceita = new DTOConfigReceita();

            dtoReceita.IdUnidade = Convert.ToInt32(cbUnidade.SelectedValue);
            dtoReceita.CodVenda = Convert.ToInt32(txtCodAdmin.Text);
            dtoReceita.NomeCodVenda = txtNomeReceita.Text;
            dtoReceita.IdUnidade = Convert.ToInt32(cbUnidade.Text);

            try
            {
                dtoReceita.ContaGerencial = Convert.ToInt32(cbCorrespConta.SelectedValue);
            }catch
            {
                dtoReceita.ContaGerencial = 0;
            }
            switch (cbTurnoReceita.Text)
            {
                case "Almoço":
                    dtoReceita.TurnoCodVenda = "A";
                    break;
                case "Jantar":
                    dtoReceita.TurnoCodVenda = "JANTAR";
                    break;
                default:
                    dtoReceita.TurnoCodVenda = "";
                    break;
            }

            switch (cbGrupo.Text)
            {
                case "Alimentos":
                    dtoReceita.TipoCodVenda = "A";
                    break;
                case "Bebidas":
                    dtoReceita.TipoCodVenda = "B";
                    break;
                case "Eventos":
                    dtoReceita.TipoCodVenda = "E";
                    break;
                case "Diversos":
                    dtoReceita.TipoCodVenda = "D";
                    break;               
            }

            //Validações

            if (txtCodAdmin.Value == 0)
            {
                MessageBox.Show("Selecione um código Admin para referenciar esta receita.");
                txtCodAdmin.Focus();
            }
            else if (txtNomeReceita.Text == "")
            {
                MessageBox.Show("Defina um nome para referenciar esta receita.");
                txtNomeReceita.Focus();
            }
            else if (cbGrupo.Text == "")
            {
                MessageBox.Show("Defina um grupo para esta receita.");
                cbGrupo.Focus();
            }
            else if (cbTurno.Text == "" && cbTipo.SelectedValue.ToString() == "Almoço e janter (Custo, receita e pax)" && (cbGrupo.SelectedValue.ToString() == "A" || cbGrupo.SelectedValue.ToString() == "B"))
            {
                MessageBox.Show("Defina um turno para esta receita.");
                cbTurno.Focus();

            }
            else
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

                BLLConfigReceita bllr = new BLLConfigReceita(cx);

                bllr.Incluir(dtoReceita);

                LimparDados();
                
            }
        }

        private void dgvCusto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 7)
            {
                if (e.RowIndex >= 0)
                {

                    cbContaGerencial.SelectedValue = dgvCusto.Rows[e.RowIndex].Cells[1].Value.ToString();
                    
                    txtNome.Text = dgvCusto.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtDivisao.Text = dgvCusto.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtMetaValor.Text = dgvCusto.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtMetaPercent.Text = dgvCusto.Rows[e.RowIndex].Cells[5].Value.ToString();

                    string turno = "";
                    switch (dgvCusto.Rows[e.RowIndex].Cells[6].Value.ToString())
                    {
                        case "Almoço":
                            turno = "Almoço";
                            break;
                        case "Jantar":
                            turno = "Jantar";
                            break;                        
                        default:
                            turno = "";
                            break;
                    }

                    cbTurno.Text = turno;

                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

                    BLLConfigCusto bllconfig = new BLLConfigCusto(cx);

                    BLLCmvGrupo bll = new BLLCmvGrupo(cx);

                    bll.ExcluirGrupoCustoPorId(Convert.ToInt32(dgvCusto.Rows[e.RowIndex].Cells[0].Value));

                    bllconfig.Excluir(Convert.ToInt32(dgvCusto.Rows[e.RowIndex].Cells[0].Value));
                    
                    CarregaDgvCusto();


                }
            }
        }
        private void dgvReceita_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (e.RowIndex >= 0)
                {

                    txtCodAdmin.Text = dgvReceita.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtNomeReceita.Text = dgvReceita.Rows[e.RowIndex].Cells[2].Value.ToString();
                    
                   
                    cbCorrespConta.Text = dgvReceita.Rows[e.RowIndex].Cells[3].Value.ToString();

                    switch (dgvReceita.Rows[e.RowIndex].Cells[4].Value.ToString())
                    {
                        case "A":
                            cbGrupo.Text = "Alimentos";
                            break;
                        case "B":
                            cbGrupo.Text = "Bebidas";
                            break;
                        case "E":
                            cbGrupo.Text = "Eventos";
                            break;
                        case "D":
                            cbGrupo.Text = "Diversos";
                            break;
                    }

                    switch (dgvReceita.Rows[e.RowIndex].Cells[5].Value.ToString())
                    {
                        case "A":
                            cbTurnoReceita.Text = "Almoço";
                            break;
                        case "J":
                        default:
                            cbTurnoReceita.Text = "";
                            break;
                    }
                    
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    
                    BLLConfigReceita bllconfig = new BLLConfigReceita(cx);

                    bllconfig.Excluir(Convert.ToInt32(dgvReceita.Rows[e.RowIndex].Cells[0].Value));

                    CarregaReceita();

                }
            }
        }

        private void btSalvarDias_Click(object sender, EventArgs e)
        {
            if (cbSegD.Text == "")
            {
                MessageBox.Show("Todos os campos de dia devem ser preenchidos.");
                cbSegD.Focus();
            }
            else if (cbSegN.Text == "")
            {
                MessageBox.Show("Todos os campos de dia devem ser preenchidos.");
                cbSegN.Focus();
            }
            else if (cbTerD.Text == "")
            {
                MessageBox.Show("Todos os campos de dia devem ser preenchidos.");
                cbTerD.Focus();
            }
            else if (cbTerN.Text == "")
            {
                MessageBox.Show("Todos os campos de dia devem ser preenchidos.");
                cbTerN.Focus();
            }
            else if (cbQuaD.Text == "")
            {
                MessageBox.Show("Todos os campos de dia devem ser preenchidos.");
                cbQuaD.Focus();
            }
            else if (cbQuaN.Text == "")
            {
                MessageBox.Show("Todos os campos de dia devem ser preenchidos.");
                cbQuaN.Focus();
            }
            else if (cbQuiD.Text == "")
            {
                MessageBox.Show("Todos os campos de dia devem ser preenchidos.");
                cbQuiD.Focus();
            }
            else if (cbQuiN.Text == "")
            {
                MessageBox.Show("Todos os campos de dia devem ser preenchidos.");
                cbQuiN.Focus();
            }
            else if (cbSexD.Text == "")
            {
                MessageBox.Show("Todos os campos de dia devem ser preenchidos.");
                cbSexD.Focus();
            }
            else if (cbSexN.Text == "")
            {
                MessageBox.Show("Todos os campos de dia devem ser preenchidos.");
                cbSexN.Focus();
            }
            else if (cbSabD.Text == "")
            {
                MessageBox.Show("Todos os campos de dia devem ser preenchidos.");
                cbSabD.Focus();
            }
            else if (cbSabN.Text == "")
            {
                MessageBox.Show("Todos os campos de dia devem ser preenchidos.");
                cbSabN.Focus();
            }
            else if (cbDomD.Text == "")
            {
                MessageBox.Show("Todos os campos de dia devem ser preenchidos.");
                cbDomD.Focus();
            }
            else if (cbDomN.Text == "")
            {
                MessageBox.Show("Todos os campos de dia devem ser preenchidos.");
                cbDomN.Focus();
            }
            else
            {

                SalvaCbDias();

            }
        }


        #endregion

        #region Imposto

        string totala, totalb;
        
        private void RecalcularA()
        {
            txtTotalA.Text = (Convert.ToDouble(txtIcmsA.Text) + Convert.ToDouble(txtPisA.Text) + Convert.ToDouble(txtCofinsA.Text)).ToString("0.00");
        }

        private void RecalcularB()
        {
            txtTotalB.Text = (Convert.ToDouble(txtIcmsB.Text) + Convert.ToDouble(txtPisB.Text) + Convert.ToDouble(txtCofinsB.Text)).ToString("0.00");
        }

        private void CarregaImpostos()
        {

            txtIcmsA.Text = 0.ToString("0.00");
            txtPisA.Text = 0.ToString("0.00");
            txtCofinsA.Text = 0.ToString("0.00");
            txtTotalA.Text = 0.ToString("0.00");

            txtIcmsB.Text = 0.ToString("0.00");
            txtPisB.Text = 0.ToString("0.00");
            txtCofinsB.Text = 0.ToString("0.00");
            txtTotalB.Text = 0.ToString("0.00");


            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLConfigImposto blli = new BLLConfigImposto(cx);
            DataTable impostos = blli.Localizar(Convert.ToInt32(cbUnidade.SelectedValue.ToString()));

            if(impostos.Rows.Count > 0)
            {

                txtIcmsA.Text = Convert.ToDouble(impostos.Rows[0][0]).ToString("0.00");
                txtPisA.Text = Convert.ToDouble(impostos.Rows[0][1]).ToString("0.00");
                txtCofinsA.Text = Convert.ToDouble(impostos.Rows[0][2]).ToString("0.00");
                txtTotalA.Text = Convert.ToDouble(impostos.Rows[0][3]).ToString("0.00");

                txtIcmsB.Text = Convert.ToDouble(impostos.Rows[0][4]).ToString("0.00");
                txtPisB.Text = Convert.ToDouble(impostos.Rows[0][5]).ToString("0.00");
                txtCofinsB.Text = Convert.ToDouble(impostos.Rows[0][6]).ToString("0.00");
                txtTotalB.Text = Convert.ToDouble(impostos.Rows[0][7]).ToString("0.00");
                
            }
            else
            {

            }

        }

        private void txtIcmsA_Validating(object sender, CancelEventArgs e)
        {
            double doubleValue;

            if (Double.TryParse(txtIcmsA.Text, out doubleValue))
            {
                txtIcmsA.Text = doubleValue.ToString("0.00");
                RecalcularA();
            }
            else
            {
                MessageBox.Show("O valor deste campo deve ser do dipo decimal.\nSe não souber o valor deste imposto, deixe zero.");
                txtIcmsA.Focus();
            }
        }

        private void txtPisA_Validating(object sender, CancelEventArgs e)
        {
            double doubleValue;

            if (Double.TryParse(txtPisA.Text, out doubleValue))
            {
                txtPisA.Text = doubleValue.ToString("0.00");
                RecalcularA();
            }
            else
            {
                MessageBox.Show("O valor deste campo deve ser do dipo decimal.\nSe não souber o valor deste imposto, deixe zero.");
                txtPisA.Focus();
            }
        }

        private void txtCofinsA_Validating(object sender, CancelEventArgs e)
        {
            double doubleValue;

            if (Double.TryParse(txtCofinsA.Text, out doubleValue))
            {
                txtCofinsA.Text = doubleValue.ToString("0.00");
                RecalcularA();
            }
            else
            {
                MessageBox.Show("O valor deste campo deve ser do dipo decimal.\nSe não souber o valor deste imposto, deixe zero.");
                txtCofinsA.Focus();
            }
        }

        private void txtTotalA_Validating(object sender, CancelEventArgs e)
        {
            double doubleValue;

            if (Double.TryParse(txtTotalA.Text, out doubleValue) && doubleValue.ToString("0.00") != totala)
            {
                txtTotalA.Text = doubleValue.ToString("0.00");
                txtIcmsA.Text = "0,00";
                txtPisA.Text = "0,00";
                txtCofinsA.Text = "0,00";
            }
            else if (doubleValue.ToString("0.00") == totala)
            {
            }
            else
            {
                MessageBox.Show("O valor deste campo deve ser do dipo decimal.\nSe não souber o valor deste imposto, deixe zero.");
                txtTotalA.Focus();
            }
        }

        private void txtIcmsB_Validating(object sender, CancelEventArgs e)
        {
            double doubleValue;

            if (Double.TryParse(txtIcmsB.Text, out doubleValue))
            {
                txtIcmsB.Text = doubleValue.ToString("0.00");
                RecalcularB();
            }
            else
            {
                MessageBox.Show("O valor deste campo deve ser do dipo decimal.\nSe não souber o valor deste imposto, deixe zero.");
                txtIcmsB.Focus();
            }
        }

        private void txtPisB_Validating(object sender, CancelEventArgs e)
        {
            double doubleValue;

            if (Double.TryParse(txtPisB.Text, out doubleValue))
            {
                txtPisB.Text = doubleValue.ToString("0.00");
                RecalcularB();
            }
            else
            {
                MessageBox.Show("O valor deste campo deve ser do dipo decimal.\nSe não souber o valor deste imposto, deixe zero.");
                txtPisB.Focus();
            }
        }

        private void txtCofinsB_Validating(object sender, CancelEventArgs e)
        {
            double doubleValue;

            if (Double.TryParse(txtCofinsB.Text, out doubleValue))
            {
                txtCofinsB.Text = doubleValue.ToString("0.00");
                RecalcularB();
            }
            else
            {
                MessageBox.Show("O valor deste campo deve ser do dipo decimal.\nSe não souber o valor deste imposto, deixe zero.");
                txtCofinsB.Focus();
            }
        }

        private void txtTotalB_Validating(object sender, CancelEventArgs e)
        {
            double doubleValue;

            if (Double.TryParse(txtTotalB.Text, out doubleValue) && doubleValue.ToString("0.00") != totalb)
            {
                txtTotalB.Text = doubleValue.ToString("0.00");
                txtIcmsB.Text = "0,00";
                txtPisB.Text = "0,00";
                txtCofinsB.Text = "0,00";
            }
            else if (doubleValue.ToString("0.00") == totalb)
            {
            }
            else
            {
                MessageBox.Show("O valor deste campo deve ser do dipo decimal.\nSe não souber o valor deste imposto, deixe zero.");
                txtTotalB.Focus();
            }
        }

        private void txtTotalA_Enter(object sender, EventArgs e)
        {
            totala = txtTotalA.Text;

            this.BeginInvoke((MethodInvoker)delegate () {
                txtTotalA.SelectAll();
            });


        }

        private void txtTotalB_Enter(object sender, EventArgs e)
        {
            totalb = txtTotalB.Text;

            this.BeginInvoke((MethodInvoker)delegate () {
                txtTotalB.SelectAll();
            });
        }

        private void txtIcmsA_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () {
                txtIcmsA.SelectAll();
            });
        }

        private void txtPisA_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () {
                txtPisA.SelectAll();
            });
        }

        private void txtCofinsA_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () {
                txtCofinsA.SelectAll();
            });
        }

        private void txtIcmsB_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () {
                txtIcmsB.SelectAll();
            });
        }

        private void txtPisB_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () {
                txtPisB.SelectAll();
            });
        }

        private void txtCofinsB_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () {
                txtCofinsB.SelectAll();
            });
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btSalvarImpostos_Click(object sender, EventArgs e)
        {

            DTOConfigImposto dto = new DTOConfigImposto();

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLConfigImposto blli = new BLLConfigImposto(cx);

            //Ler dados
            dto.IcmsA = Convert.ToDouble(txtIcmsA.Text);
            dto.IcmsB = Convert.ToDouble(txtIcmsB.Text);
            dto.PisA = Convert.ToDouble(txtPisA.Text);
            dto.PisB = Convert.ToDouble(txtPisB.Text);
            dto.CofinsA = Convert.ToDouble(txtCofinsA.Text);
            dto.CofinsB = Convert.ToDouble(txtCofinsB.Text);
            dto.TotalA = Convert.ToDouble(txtTotalA.Text);
            dto.TotalB = Convert.ToDouble(txtTotalB.Text);
            dto.IdUnidade = Convert.ToInt32(cbUnidade.SelectedValue.ToString());

            try
            {
                try
                {
                    blli.Excluir(Convert.ToInt32(cbUnidade.SelectedValue));
                }
                catch
                {

                }

                blli.Incluir(dto);
                MessageBox.Show("Impostos salvos com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar os impostos. Erro tipo: " + ex);
            }
            

            //Salvar
        }

        #endregion

    }
}
