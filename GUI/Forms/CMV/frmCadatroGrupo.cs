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

namespace GUI.CMV
{
    public partial class frmCadatroGrupo : Form
    {
        int idUsuario;
        int unidade;
        bool liberado = false;
        public frmCadatroGrupo(int id)
        {
            idUsuario = id;
            InitializeComponent();
        }

        private void frmCadatroGrupo_Load(object sender, EventArgs e)
        {

            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(Convert.ToInt32(idUsuario));

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";
            
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUnidade bllun = new BLLUnidade(cx);
            

            if (!liberado)
            {
                cbUnidade.DataSource = bllun.ListarUnidades();
                cbUnidade.DisplayMember = "cod_unidade";
                cbUnidade.ValueMember = "id_unidade";
                cbUnidade.Text = modelou.IdUnidade.ToString("00");

                if (modelou.PermissaoUsuario < 4)
                {
                    cbUnidade.Enabled = false;
                }

                unidade = Convert.ToInt32(cbUnidade.SelectedValue);
            }

            pnCadastroGrupo.Location = new Point(15, 72);

            btExcluirGrupo.Enabled = false;
            cbConta.Enabled = false;
            cbGrupoAdmin.Enabled = false;
            gbConta.Enabled = false;
            gbAdmin.Enabled = false;
            btAddConta.Enabled = false;
            btAddAdmin.Enabled = false;

            carregaGrupo();
            carregarContasGerenciais();
            carregarAdmin();
            liberado = true;

        }

        public class Language
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public string Name2 { get; set; }
            public string Value2 { get; set; }
        }

        private void carregaGrupo()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLCmvGrupo bll = new BLLCmvGrupo(cx);

            DataTable tabela = bll.LocalizarGrupo(unidade);

            var dataSource = new List<Language>();

            dataSource.Add(new Language() { Name = "", Value = "" });

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                dataSource.Add(new Language() { Name = tabela.Rows[i][1].ToString(), Value = Convert.ToInt32(tabela.Rows[i][0]).ToString() });
            }

            dataSource.Add(new Language() { Name = "**Adicionar Grupo**", Value = "-1" });
            
            //Setup data binding
            this.cbGrupos.DataSource = dataSource;
            this.cbGrupos.DisplayMember = "Name";
            this.cbGrupos.ValueMember = "Value";
            this.cbGrupos.Text = "";

            dgvAdmin.Rows.Clear();
            dgvContas.Rows.Clear();
            txtMEtaPercentual1.Clear();
            txtmetaValor1.Clear();
            cbGrupoAdmin.Text = ""; 
            cbConta.Text = "";


        }

        private void carregarContasGerenciais()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLConfigCusto bll = new BLLConfigCusto(cx);

            DataTable tabela = bll.LocalizarConfig(unidade);

            var dataSource = new List<Language>();


            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                dataSource.Add(new Language() { Name = tabela.Rows[i][1].ToString()+" - "+tabela.Rows[i][2].ToString(), Value = tabela.Rows[i][0].ToString() });
            }       



            //Setup data binding
            this.cbConta.DataSource = dataSource;
            this.cbConta.DisplayMember = "Name";
            this.cbConta.ValueMember = "Value";
            this.cbConta.Text = "";


        }

        private void carregarAdmin()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLConfigReceita bll = new BLLConfigReceita(cx);

            DataTable tabela = bll.LocalizarConfig(unidade);

            var dataSource = new List<Language>();


            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                dataSource.Add(new Language() { Name2 = tabela.Rows[i][1].ToString() + " - " + tabela.Rows[i][2].ToString(), Value2 = tabela.Rows[i][1].ToString() });
            }

            //Setup data binding
            this.cbGrupoAdmin.DataSource = dataSource;
            this.cbGrupoAdmin.DisplayMember = "Name2";
            this.cbGrupoAdmin.ValueMember = "Value2";
            this.cbGrupoAdmin.Text = "";


        }

        private void cbGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (liberado)
            {

                if (cbGrupos.SelectedValue.ToString() == "-1")
                {
                    pnCadastroGrupo.Visible = true;
                    txtNomeGrupo.Focus();
                }
                else if (cbGrupos.Text.ToString() != "")
                {
                    btExcluirGrupo.Enabled = true;
                    cbConta.Enabled = true;
                    cbGrupoAdmin.Enabled = true;
                    gbConta.Enabled = true;
                    gbAdmin.Enabled = true;
                    btAddConta.Enabled = true;
                    btAddAdmin.Enabled = true;

                    CarregaDgvContas();
                    CarregaDgvAdmin();
                    CarregaMetas();
                }
                else
                {

                    btExcluirGrupo.Enabled = false;
                    cbConta.Enabled = false;
                    cbGrupoAdmin.Enabled = false;
                    gbConta.Enabled = false;
                    gbAdmin.Enabled = false;
                    btAddConta.Enabled = false;
                    btAddAdmin.Enabled = false;

                }
            }
        }            

        private void btExcluirGrupo_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("ATENÇÃO! Ao excluir este grupo todos os itens contidos nele serão deletados. Continuar?", "Aviso", MessageBoxButtons.YesNo);
            if (d.ToString() == "Yes")
            {
                if (cbGrupos.SelectedValue.ToString() != "-1" && cbGrupos.SelectedValue.ToString() != "")
                {
                    liberado = false;
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLCmvGrupo bll = new BLLCmvGrupo(cx);
                    bll.ExcluirGrupo(Convert.ToInt32(cbGrupos.SelectedValue.ToString()));
                    carregaGrupo();
                    CarregaDgvAdmin();
                    CarregaDgvContas();
                    liberado = true;
                }
                else
                {
                    liberado = false;
                    cbGrupos.Text = "";
                    liberado = true;                    
                }
                    btExcluirGrupo.Enabled = false;

            }
        }

        private void btAdicionarGrupo_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLCmvGrupo bll = new BLLCmvGrupo(cx);
            DTOCmvGrupo dto = new DTOCmvGrupo();

            dto.cmvGrupoNome = txtNomeGrupo.Text;
            dto.idUnidade = unidade;

            double metaPercapta = 0;

            if (txtMetaValor.Text != "")
            {
                metaPercapta = Math.Round(Convert.ToDouble(txtMetaValor.Text), 2);
            }

            double metaPercentual = 0;

            if (txtMetaPercent.Text != "")
            {
                metaPercentual = Math.Round((Convert.ToDouble(txtMetaPercent.Text.Replace("%", "")) / 100), 4);
            }

            dto.cmvGrupoMetaPercentual = metaPercentual;
            dto.cmvGrupoMetaValor = metaPercapta;

            txtMetaValor.Clear();
            txtMetaPercent.Clear();
            bll.IncluirGrupo(dto);
            txtNomeGrupo.Clear();

            pnCadastroGrupo.Visible = false;
            liberado = false;
            carregaGrupo();
            liberado = true;
            cbGrupos.Text = dto.cmvGrupoNome;

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            txtNomeGrupo.Clear();
            liberado = false;
            cbGrupos.Text = "";
            liberado = true;
            pnCadastroGrupo.Visible = false;
        }

        private void btAddConta_Click(object sender, EventArgs e)
        {
           

            if (cbGrupos.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Por favor escolha um grupo válido.");
                cbConta.Text = "";
                cbGrupos.Focus();
            }
            else if (cbConta.Text != "")
            {

                bool repetido = false;

                if (dgvContas.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvContas.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(cbConta.SelectedValue.ToString()) == Convert.ToInt32(dgvContas.Rows[i].Cells[1].Value))
                        {
                            repetido = true;
                        }
                    }
                }

                if (repetido)
                {
                    MessageBox.Show("Já existe cadastro para esta conta gerencial neste grupo.", "AVISO!");

                }else
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLCmvGrupo bll = new BLLCmvGrupo(cx);
                    DTOCmvGrupo dto = new DTOCmvGrupo();

                    dto.idCmvGrupo = Convert.ToInt32(cbGrupos.SelectedValue);
                    dto.IdConfigCusto = Convert.ToInt32(cbConta.SelectedValue);

                    bll.IncluirGrupoCusto(dto);
                    cbConta.Text = "";
                    CarregaDgvContas();
                }
            }
            else
            {
                MessageBox.Show("Por favor escolha um grupo válido.");
                cbConta.Text = "";
                cbGrupos.Focus();
            }
            

        }

        private void btAddAdmin_Click(object sender, EventArgs e)
        {
            if (cbGrupos.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Por favor escolha um grupo válido.");
                cbGrupoAdmin.Text = "";
                cbGrupos.Focus();
            }
            else if(cbGrupoAdmin.Text == "")
            {
                MessageBox.Show("selecione uma conta do cbGrupoAdmin para continuar");
            }
            else if (cbGrupos.SelectedValue.ToString() != "-1")
            {

                bool repetido = false;
                for(int i = 0; i < dgvAdmin.Rows.Count; i++)
                {
                    if (Convert.ToInt32(cbGrupoAdmin.SelectedValue) == Convert.ToInt32(dgvAdmin.Rows[i].Cells[0].Value))
                    {
                        repetido = true;
                    }
                }

                if (repetido)
                {
                    MessageBox.Show("Já existe cadastro para este códido do Admin neste grupo.", "AVISO!");
                }
                else
                {

                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLCmvGrupo bll = new BLLCmvGrupo(cx);
                    DTOCmvGrupo dto = new DTOCmvGrupo()
                    {
                        idCmvGrupo = Convert.ToInt32(cbGrupos.SelectedValue),
                        CodReceita = Convert.ToInt32(cbGrupoAdmin.SelectedValue),
                        idUnidade = unidade
                    };

                    bll.IncluirGrupoReceita(dto);
                    cbGrupoAdmin.Text = "";
                    CarregaDgvAdmin();

                }

            }else
            {
                MessageBox.Show("Por favor escolha um grupo válido.");
                cbGrupoAdmin.Text = "";
                cbGrupos.Focus();
            }
        }

        private void CarregaDgvContas()
        {
            try
            {
                dgvContas.Rows.Clear();

                if (cbGrupos.Text != "")
                {

                    String[] C = { "", "", "", "" };

                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLCmvGrupo bll = new BLLCmvGrupo(cx);

                    DataTable tabela = bll.LocalizarGrupoCusto(Convert.ToInt32(cbGrupos.SelectedValue.ToString()));

                    BLLConfigCusto bllconfig = new BLLConfigCusto(cx);

                    DataTable tabela1;

                    for (int i = 0; i < tabela.Rows.Count; i++)
                    {
                        tabela1 = bllconfig.LocalizarConfigPorId(Convert.ToInt32(tabela.Rows[i][2]));

                        C = new string[] { tabela.Rows[i][0].ToString(), tabela.Rows[i][2].ToString(), tabela1.Rows[0][1].ToString() + " - " + tabela1.Rows[0][2].ToString() };
                        this.dgvContas.Rows.Add(C);
                    }
                }else
                {

                }
            }
            catch { }
        }

        private void CarregaDgvAdmin()
        {

            try
            {
                dgvAdmin.Rows.Clear();

                if (cbGrupos.Text != "")
                {

                    String[] C = { "", "" };

                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLCmvGrupo bll = new BLLCmvGrupo(cx);

                    //Lista todas as receitas do grupo selecionado
                    DataTable tabela = bll.LocalizarGrupoReceita(Convert.ToInt32(cbGrupos.SelectedValue.ToString()));

                    BLLConfigReceita bllconfig = new BLLConfigReceita(cx);

                    DataTable tabela1;

                    for (int i = 0; i < tabela.Rows.Count; i++)
                    {
                        //descreve receita por id
                        tabela1 = bllconfig.LocalizarConfigReceitaPorCodEUnidade(Convert.ToInt32(tabela.Rows[i][1]), Convert.ToInt32(cbUnidade.Text));

                        C = new string[] { tabela.Rows[i][1].ToString(), tabela.Rows[i][0].ToString(), Convert.ToInt32(tabela1.Rows[0][1]).ToString("00")+" - "+ tabela1.Rows[0][2].ToString()};
                        this.dgvAdmin.Rows.Add(C);
                    }
                }
            }
            catch { }

        }

        private void CarregaMetas()
        {
            txtMEtaPercentual1.Clear();
            txtmetaValor1.Clear();

            double MetaValor = 0;
            double MetaPercentual = 0;

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLCmvGrupo bll = new BLLCmvGrupo(cx);

            DataTable tabela = bll.LocalizarGrupoPorId(Convert.ToInt32(cbGrupos.SelectedValue.ToString()));
            try
            {
                MetaValor = Convert.ToDouble(tabela.Rows[0][2].ToString());
            }
            catch
            {}

                txtmetaValor1.Text = MetaValor.ToString("#,0.00");

          try
            {
                MetaPercentual = Convert.ToDouble(tabela.Rows[0][3]) * 100;
            }
            catch
            {}

            txtMEtaPercentual1.Text = MetaPercentual.ToString()+"%";

            btEditar.Enabled = true;            

        }

        private void dgvContas_SelectionChanged(object sender, EventArgs e)
        {
            dgvContas.ClearSelection();
        }

        private void dgvContas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (e.RowIndex >= 0)
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

                    BLLConfigCusto bll = new BLLConfigCusto(cx);

                    DataTable tabela = bll.LocalizarConfigPorId(Convert.ToInt32(dgvContas.Rows[e.RowIndex].Cells[1].Value));
                    
                    cbConta.Text = tabela.Rows[0][1].ToString() + " - " + tabela.Rows[0][2].ToString();

                    BLLCmvGrupo bllg = new BLLCmvGrupo(cx);

                    bllg.ExcluirGrupoCusto(Convert.ToInt32(dgvContas.Rows[e.RowIndex].Cells[0].Value));
                                       
                    CarregaDgvContas();

                }
            }
        }

        private void dgvAdmin_SelectionChanged(object sender, EventArgs e)
        {
            dgvAdmin.ClearSelection();
        }

        private void dgvAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (e.RowIndex >= 0)
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

                    BLLConfigCusto bll = new BLLConfigCusto(cx);

                    DataTable tabela = bll.LocalizarConfigPorId(Convert.ToInt32(dgvAdmin.Rows[e.RowIndex].Cells[0].Value));

                    cbGrupoAdmin.Text = dgvAdmin.Rows[e.RowIndex].Cells[2].Value.ToString();

                    BLLCmvGrupo bllg = new BLLCmvGrupo(cx);

                    bllg.ExcluirGrupoReceita(Convert.ToInt32(dgvAdmin.Rows[e.RowIndex].Cells[1].Value));
                    
                    CarregaDgvAdmin();

                }
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
        
        private void btEditar_Click(object sender, EventArgs e)
        {
            if (!txtMEtaPercentual1.Enabled)
            {

                txtMEtaPercentual1.Enabled = true;
                txtmetaValor1.Enabled = true;
                btSalvar.Enabled = true;
                btEditar.Enabled = false;
                gbConta.Enabled = false;
                gbAdmin.Enabled = false;
                txtNome.Visible = true;
                cbConta.Enabled = false;
                cbGrupoAdmin.Enabled = false;
                btAddAdmin.Enabled = false;
                btAddConta.Enabled = false;
                dgvAdmin.Enabled = false;
                dgvContas.Enabled = false;
                txtNome.Text = cbGrupos.Text;
                cbGrupos.Visible = false;

            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            double metaValor = 0;
            double metaPercentual = 0;
            

            if(txtmetaValor1.Text != "")
            {
                metaValor = Convert.ToDouble(txtmetaValor1.Text);
            }
            if (txtMEtaPercentual1.Text != "")
            {
                metaPercentual = Convert.ToDouble(txtMEtaPercentual1.Text.Replace("%", ""))/100;
            }

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLCmvGrupo bll = new BLLCmvGrupo(cx);
            DTOCmvGrupo dto = new DTOCmvGrupo();

            dto.cmvGrupoMetaValor = metaValor;
            dto.cmvGrupoMetaPercentual = metaPercentual;
            dto.idCmvGrupo = Convert.ToInt32(cbGrupos.SelectedValue.ToString()); ;
            dto.cmvGrupoNome = txtNome.Text;

            bll.Alterar(dto);

            txtMEtaPercentual1.Enabled = false;
            txtmetaValor1.Enabled = false;
            btSalvar.Enabled = false;
            btEditar.Enabled = true;
            gbConta.Enabled = true;
            gbAdmin.Enabled = true;
            txtNome.Clear();
            txtNome.Visible = false;
            cbGrupos.Visible = true;
            cbConta.Enabled = true;
            cbGrupoAdmin.Enabled = true;
            btAddAdmin.Enabled = true;
            btAddConta.Enabled = true;
            dgvAdmin.Enabled = true;
            dgvContas.Enabled = true;
            

            carregaGrupo();
            cbGrupos.Text = dto.cmvGrupoNome;

        }

        private void txtmetaValor1_Validating(object sender, CancelEventArgs e)
        {
            double doubleValue;

            if (Double.TryParse(txtmetaValor1.Text, out doubleValue))
            {
                txtmetaValor1.Text = doubleValue.ToString("#,0.00");

            }

            else if (txtmetaValor1.Text == "")
            {
            }
            else
            {
                e.Cancel = true;
                MessageBox.Show("Digite um valor numérico, com até duas casas decimais.");
            }
        }

        private void txtMEtaPercentual1_Validating(object sender, CancelEventArgs e)
        {
            double doubleValue;

            string txt = txtMEtaPercentual1.Text.Replace("%", "");

            if (Double.TryParse(txt, out doubleValue) && Convert.ToDouble(txt) <= 100 && Convert.ToDouble(txt) >= 0.01)
            {
                txtMEtaPercentual1.Text = (doubleValue / 100).ToString("00.00%");

            }

            else if (txtMEtaPercentual1.Text == "")
            {
            }
            else
            {
                e.Cancel = true;
                MessageBox.Show("Digite um valor numérico, com até duas casas decimais, entre 0,01% e 100%.");
            }
        }

        private void cbUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liberado)
            {
                unidade = Convert.ToInt32(cbUnidade.SelectedValue.ToString());
                carregaGrupo();
                carregarAdmin();
                carregarContasGerenciais();
            }
        }
                
    }
}
