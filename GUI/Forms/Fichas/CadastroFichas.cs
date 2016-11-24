using GUI.Code.BLL;
using GUI.Code.DAL;
using GUI.Code.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Forms.Fichas
{
    public partial class CadastroFichas : Form
    {

        #region Variáveis
        public string foto = "";
        int unidade, idUsuario;
        bool herdado = false;
        string operacao = "consultar";
        string CodigoEdicaoProduto = "";
        bool liberado = false;

        #endregion

        #region Inicialização

        public CadastroFichas(int id, string cod, bool h)
        {
            idUsuario = id;
            herdado = h;
            if(cod != "")
            {
                CodigoEdicaoProduto = cod;
            }
            InitializeComponent();
        }

        private void CadastroFichas_Load(object sender, EventArgs e)
        {
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(Convert.ToInt32(idUsuario));

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";
            
            if(CodigoEdicaoProduto == "")
            {
            DefaultValues();
                
                
            }
            else
            {
                CarregaFicha(CodigoEdicaoProduto);
                
            }

            AlteraBotoes();
            

            liberado = true;
        }

        #endregion

        #region Voids

        public class Language
        {
            public string setor { get; set; }
            public string Value { get; set; }
            public string cat { get; set; }
            public string Value1 { get; set; }
            public string scat { get; set; }
            public string Value2 { get; set; }

        }

        private void CarregaCat()
        {

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

            BLLBuffet bllsetor = new BLLBuffet(cx);
            DataTable tabelaSetor = bllsetor.Listar();

            BLLCategoria bllCat = new BLLCategoria(cx);
            DataTable tabelaCat = bllCat.Listar();

            BLLSubCategoria bllSCat = new BLLSubCategoria(cx);
            DataTable tabelaSCat = bllSCat.Listar();

            var dataSource1 = new List<Language>();
            dataSource1.Add(new Language() { setor = "", Value = "0" });

            for (int i = 0; i < tabelaSetor.Rows.Count; i++)
            {
                dataSource1.Add(new Language() { setor = tabelaSetor.Rows[i][1].ToString(), Value = Convert.ToInt32(tabelaSetor.Rows[i][0]).ToString() });
            }

            dataSource1.Add(new Language() { setor = "**Cadastrar**", Value = "-1" });

            var dataSource2 = new List<Language>();
            dataSource2.Add(new Language() { cat = "", Value1 = "0" });

            for (int i = 0; i < tabelaCat.Rows.Count; i++)
            {
                dataSource2.Add(new Language() { cat = tabelaCat.Rows[i][1].ToString(), Value1 = Convert.ToInt32(tabelaCat.Rows[i][0]).ToString() });
            }

            dataSource2.Add(new Language() { cat = "**Cadastrar**", Value1 = "-1" });

            var dataSource3 = new List<Language>();
            dataSource3.Add(new Language() { scat = "", Value2 = "0" });
            for (int i = 0; i < tabelaSCat.Rows.Count; i++)
            {
                dataSource3.Add(new Language() { scat = tabelaSCat.Rows[i][1].ToString(), Value2 = Convert.ToInt32(tabelaSCat.Rows[i][0]).ToString() });
            }
            dataSource3.Add(new Language() { scat = "**Cadastrar**", Value2 = "-1" });


            //Atualiza Combobox Setor
            this.cbSetor.DataSource = dataSource1;
            this.cbSetor.DisplayMember = "setor";
            this.cbSetor.ValueMember = "Value";

            //Atualiza Combobox Categoria
            this.cbCategoria.DataSource = dataSource2;
            this.cbCategoria.DisplayMember = "cat";
            this.cbCategoria.ValueMember = "Value1";

            //Atualiza Combobox Subcategoria
            this.cbSubCategoria.DataSource = dataSource3;
            this.cbSubCategoria.DisplayMember = "scat";
            this.cbSubCategoria.ValueMember = "Value2";

        }

        private void zerarPagina()
        {
            DTOCaminhos dto = new DTOCaminhos();


            liberado = false;
            pbFoto.Load(dto.Produtos + "0.jpg");
            txtCodItem.Clear();
            txtNomeItem.Clear();
            txtQuant.Clear();
            txtPreparo.Clear();
            txtUm.Clear();
            txtFc.Clear();
            txtCodItem.Focus();
            txtDescricao.Clear();
            dgvFicha.Rows.Clear();
            lbCustoKg2.Text = "0,00";
            lbCustoPorcao2.Text = "0,00";
            lbCustoTotal2.Text = "0,00";
            txtCodigoPrato.Clear();
            gbFicha.Enabled = true;
            gbIngredientes.Enabled = false;
            DefaultValues();
            txtDescricao.Clear();
            AlteraBotoes();
            liberado = true;
        }

        private void AlteraBotoes()
        {

            liberado = false;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btSalvar.Enabled = false;
            btLocalizar.Enabled = false;
            btExcluir.Enabled = false;
            txtNome.Enabled = false;
            txtPeso.Enabled = false;
            txtRendimento.Enabled = false;
            cbSetor.Enabled = false;
            cbSubCategoria.Enabled = false;
            cbCategoria.Enabled = false;
            txtQuant.Enabled = false;
            txtPreparo.Enabled = false;
            dgvFicha.Enabled = false;
            txtDescricao.Enabled = false;
            gbImagem.Enabled = false;
            

            if (operacao == "inserir")
            {
                btSalvar.Enabled = true;
                btLocalizar.Enabled = true;
                gbFicha.Enabled = true;
                gbIngredientes.Enabled = true;
                txtNome.Enabled = true;
                txtPeso.Enabled = true;
                txtRendimento.Enabled = true;
                cbSetor.Enabled = true;
                cbSubCategoria.Enabled = true;
                cbCategoria.Enabled = true;
                txtPreparo.Enabled = true;
                dgvFicha.Enabled = true;
                txtDescricao.Enabled = true;
                gbImagem.Enabled = true;
            }
            else if(operacao == "editar")
            {
                btSalvar.Enabled = true;
                btExcluir.Enabled = true;
                gbFicha.Enabled = true;
                gbIngredientes.Enabled = true;
                txtNome.Enabled = true;
                txtPeso.Enabled = true;
                txtRendimento.Enabled = true;
                cbSetor.Enabled = true;
                cbSubCategoria.Enabled = true;
                cbCategoria.Enabled = true;
                txtPreparo.Enabled = true;
                dgvFicha.Enabled = true;
                txtDescricao.Enabled = true;
                gbImagem.Enabled = true;
            }
            else if(operacao == "consultar")
            {
                btExcluir.Enabled = true;
                btLocalizar.Enabled = true;
                btEditar.Enabled = true;
                btNovo.Enabled = true;
            }
            else
            {
                
            }

            liberado = true;
        }

        private void VerificarNomePrato()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLPratos bll = new BLLPratos(cx);
            DataTable tabela = bll.LocalizarNome(txtNome.Text);

            if (tabela.Rows.Count > 0 && liberado)
            {
                MessageBox.Show("Já existe um prato chamado \"" + txtNome.Text.Trim().ToUpper() + "\".");
            }

        }

        private void DefaultValues()
        {

            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUnidade bllun = new BLLUnidade(con);
            BLLUsuario bllu = new BLLUsuario(con);
            DTOUsuario modelou = bllu.CarregaModeloUsuario(Convert.ToInt32(idUsuario));

            cbUnidade.DataSource = bllun.ListarUnidades();
            cbUnidade.DisplayMember = "cod_unidade";
            cbUnidade.ValueMember = "id_unidade";
cbUnidade.Text = modelou.IdUnidade.ToString("00");

            if (modelou.PermissaoUsuario < 4)
            {
                cbUnidade.Enabled = false;
            }

            unidade = Convert.ToInt32(cbUnidade.SelectedValue);
            LimpaCampos();
            AlteraBotoes();
            dgvFicha.Rows.Clear();
            CarregaCat();
            
            txtId.Clear();

        }

        private void CarregaFicha(string cod)
        {
            DefaultValues();

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLPratos bllp = new BLLPratos(cx);
            DataTable tabela = bllp.LocalizarPorCod(cod);

            string nomePrato, codigo, desc, preparo;
            double rendimento, peso;
            int setor, cat, subcat;

            if (tabela.Rows.Count == 0)
            {
                MessageBox.Show("Não foi possível Localizar a ficha técnica selecionada.");
            }
            else
            {
                // Preenche dados da Ficha
                codigo = cod;
                nomePrato = tabela.Rows[0][1].ToString();
                desc = tabela.Rows[0][8].ToString();
                preparo = tabela.Rows[0][6].ToString();
                rendimento = Convert.ToDouble(tabela.Rows[0][5]);
                peso = Convert.ToDouble(tabela.Rows[0][7]);
                setor = Convert.ToInt32(tabela.Rows[0][2]);
                cat = Convert.ToInt32(tabela.Rows[0][3]);
                subcat = Convert.ToInt32(tabela.Rows[0][4]);

                txtCodigoPrato.Text = cod;
                txtNome.Text = nomePrato;
                if (string.IsNullOrEmpty(desc))
                {
                    txtDescricao.Text = "";
                }
                else
                {
                    txtDescricao.Text = desc;
                }

                if (string.IsNullOrEmpty(preparo))
                {
                    txtPreparo.Text = "";
                }
                else
                {
                    txtPreparo.Text = preparo;
                }

                if (string.IsNullOrEmpty(peso.ToString()))
                {
                    txtPeso.Text = "0,0000";
                }
                else
                {
                    txtPeso.Text = peso.ToString("#,0.0000");
                }

                txtRendimento.Text = rendimento.ToString("#,0.00");


                //Carrega setor, categoria e subcategoria

                BLLBuffet bllsetor = new BLLBuffet(cx);
                DataTable tabelasetor = bllsetor.localizarPorId(setor);

                cbSetor.Text = tabelasetor.Rows[0][0].ToString();

                BLLCategoria bllcat = new BLLCategoria(cx);
                DataTable tabelacat = bllcat.localizarPorId(cat);

                if(tabelacat.Rows.Count > 0)
                {
                    cbCategoria.Text = tabelacat.Rows[0][0].ToString();
                }

                BLLSubCategoria bllscat = new BLLSubCategoria(cx);
                DataTable tabelascat = bllscat.localizarPorId(cat);

                if (tabelascat.Rows.Count > 0)
                {
                    cbSubCategoria.Text = tabelascat.Rows[0][0].ToString();
                }

                CarregarIngredientesPorCodigo(cod);

                DTOCaminhos dtocaminhos = new DTOCaminhos();

                try
                {
                    pbFoto.Load(dtocaminhos.FT + cod + ".jpg");

                }
                catch
                {
                    pbFoto.Load(dtocaminhos.Produtos + "0.jpg");
                    btDeletaFoto.Enabled = false;
                }
                                

            }
        }        

        private void LimpaCampos()
        {
            txtNome.Clear();
            txtPeso.Clear();
            txtRendimento.Text = "0,00";
            txtPeso.Text = "0,0000";
            cbSetor.Text = "";
            cbCategoria.Text = "";
            cbSubCategoria.Text = "";

        }

        private void txtPeso_Validating(object sender, CancelEventArgs e)
        {
            double doubleValue;
            if (txtRendimento.Text == "")
            {
                txtRendimento.Text = "0,0000";
                RecalcularCusto();
            }
            string txt = txtPeso.Text;

            if (Double.TryParse(txt, out doubleValue))
            {
                txtPeso.Text = doubleValue.ToString("#,0.0000");
                RecalcularCusto();
            }

            else if (txtPeso.Text == "")
            {
            }
            else
            {
                e.Cancel = true;
                MessageBox.Show("Digite um valor numérico com até duas casas decimais.");
            }

        }

        private void AddIngrediente()
        {
            double custoUnit = 0;
            double custoTotal = 0;

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLIngredientes bll = new BLLIngredientes(cx);
            
            Augoritmos a = new Augoritmos();
            
                custoUnit = a.CustoIngrediente(txtCodItem.Text, Convert.ToInt32(cbUnidade.SelectedValue));
            
            custoTotal = custoUnit * Convert.ToDouble(txtQuant.Text);

            String[] V = new string[] { txtCodItem.Text, txtNomeItem.Text, txtQuant.Text, txtUm.Text, txtFc.Text, custoUnit.ToString("#,0.00"), custoTotal.ToString("#,0.00") };
            dgvFicha.Rows.Add(V);

            RecalcularCusto();
            txtCodItem.Clear();
            txtNomeItem.Clear();
            txtQuant.Clear();
            txtUm.Clear();
            txtFc.Clear();
            txtCodItem.Focus();
            btAddIngrediente.Enabled = false;
            txtQuant.Enabled = false;

        }

        private void Salvar()
        {

            // Salvar dados da ficha

            DTOPratos dto = new DTOPratos();
            Augoritmos a = new Augoritmos();
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLPratos bll = new BLLPratos(cx);

            dto.CodPrato = txtCodigoPrato.Text;
            dto.NomePrato = txtNome.Text.Trim().ToUpper();
            dto.IdSetor = Convert.ToInt32(cbSetor.SelectedValue);
            dto.Cat = Convert.ToInt32(cbCategoria.SelectedValue);
            dto.SubCat = Convert.ToInt32(cbSubCategoria.SelectedValue);
            dto.RendimentoPrato = Convert.ToDouble(txtRendimento.Text);
            dto.ModoPreparoPrato = txtPreparo.Text.Trim();
            dto.PesoPrato = Convert.ToDouble(txtPeso.Text);
            dto.IdUsuario = idUsuario;
            dto.DescPrato = txtDescricao.Text.Trim().ToUpper();

            try
            {
                dto.IdPrato = Convert.ToInt32(txtId.Text);
            }
            catch
            {

            }

            //Dados de AEB

            DTOAeB dtoaeb = new DTOAeB();
            BLLAeB bllaeb = new BLLAeB(cx);

            dtoaeb.CodAeb = dto.CodPrato;
            dtoaeb.NomeAeb = dto.NomePrato;
            dtoaeb.UmAeb = "KG";
            dtoaeb.Fc = 0;


            if (operacao == "inserir")
            {
                try
                {
                    bll.Incluir(dto);
                    bllaeb.Incluir(dtoaeb);
                    SalvarIngredientes();
                    
                    a.IncluiFoto(txtCodigoPrato.Text, foto);

                    MessageBox.Show($"Ficha técnica {dto.CodPrato} - {dto.NomePrato} salva com sucesso.");
                    operacao = "consultar";
                    AlteraBotoes();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro ao salvar a ficha.\n" + e.ToString());
                }
            }
            else if(operacao == "editar")
            {
                try
                {
                    bll.Alterar(dto);
                    bllaeb.AlterarPorCod(dtoaeb);
                    SalvarIngredientes();

                    a.IncluiFoto(txtCodigoPrato.Text, foto);

                    MessageBox.Show($"Ficha técnica {dto.CodPrato} - {dto.NomePrato} alterada com sucesso.");
                    operacao = "consultar";
                    AlteraBotoes();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro ao alterar a ficha.\n"+e.ToString());
                }
            }

        }

        private void Alterar()
        {
           
            DTOPratos dto = new DTOPratos();

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLPratos bll = new BLLPratos(cx);
            
            dto.CodPrato = txtCodigoPrato.Text;
            dto.NomePrato = txtNome.Text.Trim().ToUpper();
            dto.IdSetor = Convert.ToInt32(cbSetor.SelectedValue);
            dto.Cat = Convert.ToInt32(cbCategoria.SelectedValue);
            dto.SubCat = Convert.ToInt32(cbSubCategoria.SelectedValue);
            dto.RendimentoPrato = Convert.ToDouble(txtRendimento.Text);
            dto.ModoPreparoPrato = txtPreparo.Text.Trim();
            dto.PesoPrato = Convert.ToDouble(txtPeso.Text);
            dto.IdUsuario = idUsuario;
            dto.DescPrato = txtDescricao.Text.Trim().ToUpper();

            BLLAeB bllaeb = new BLLAeB(cx);
            DTOAeB dtoaeb = new DTOAeB();

            dtoaeb.CodAeb = dto.CodPrato;
            dtoaeb.NomeAeb = dto.NomePrato;
            dtoaeb.UmAeb = "KG";
            dtoaeb.Fc = 0;

            try
            {
                bll.Alterar(dto);
                MessageBox.Show($"Ficha técnica {txtCodigoPrato.Text} - {txtNome.Text} alterada com sucesso.");


                DataTable tabelaAeb;

                tabelaAeb = bllaeb.Localizar(dto.CodPrato);

                if(tabelaAeb.Rows.Count == 0)
                {
                    bllaeb.Incluir(dtoaeb);
                }
                else
                {
                bllaeb.AlterarPorCod(dtoaeb);
                }


                gbFicha.Enabled = false;
                gbIngredientes.Enabled = true;
                txtCodItem.Focus();

            }
            catch
            {
                MessageBox.Show("Erro ao alterar Ficha técnica.");
            }
            
        }        

        private string CodigoNovo()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLPratos bllCod = new BLLPratos(cx);

            DataTable tabela = bllCod.ListarCodigos();

            string codigo = "";
            string prefixo = "20.01.";

            for (int i = 0; i < tabela.Rows.Count + 1; i++)
            {

                try
                {
                    codigo = prefixo + (i + 1).ToString("0000");
                    string CodigoProdutoE = tabela.Rows[i][0].ToString();

                    if (codigo != CodigoProdutoE)
                    {
                        i = tabela.Rows.Count + 1;
                    }
                }
                catch
                {

                    i = tabela.Rows.Count + 1;
                }

            }
            
            return codigo;
        }

        private void SalvarIngredientes()
        {

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            
            if (dgvFicha.Rows.Count > 0)
            {

                DTOIngredientes dto = new DTOIngredientes();

                BLLIngredientes bll = new BLLIngredientes(cx);

                //Excluir ingredientes salvos no prato
                bll.ExcluirPorPrato(txtCodigoPrato.Text);

                for(int i = 0; i < dgvFicha.Rows.Count; i++)
                {
                    dto.CodItem = dgvFicha.Rows[i].Cells[0].Value.ToString();

                    dto.CodPrato = txtCodigoPrato.Text;

                    dto.QuantIngrediente = Convert.ToDouble(dgvFicha.Rows[i].Cells[2].Value);

                    bll.Incluir(dto);
                    
                }
                               

            }

            

        }

        private void CarregarIngredientesPorCodigo(string cod)
        {
            dgvFicha.Rows.Clear();

            //Linha por linha busca ingrediente com custo
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLPratos bll = new BLLPratos(cx);
            DataTable tabelaIngredientes = bll.ListarIngredientes(txtCodigoPrato.Text);

            BLLAeB bllaeb = new BLLAeB(cx);
            DataTable tabelaAeb;

            Augoritmos a = new Augoritmos();


            if (tabelaIngredientes.Rows.Count > 0)
            {
                for(int i = 0; i<tabelaIngredientes.Rows.Count; i++)
                {
                    //cod_item, quant_ingrediente

                    tabelaAeb = bllaeb.localizarPorCod(tabelaIngredientes.Rows[i][0].ToString());
                    
                    string codIngrediente, nomeingrediente, um;
                    double quant, custoUnit, custoTotal, fc;

                    codIngrediente = tabelaIngredientes.Rows[i][0].ToString();
                    nomeingrediente = tabelaAeb.Rows[0][0].ToString();
                    um = tabelaAeb.Rows[0][1].ToString();
                    if (string.IsNullOrEmpty(tabelaAeb.Rows[0][2].ToString()))
                    {
                        fc = 0;
                    }
                    else
                    {
                        fc = Convert.ToDouble(tabelaAeb.Rows[0][2]);
                    }

                    quant = Convert.ToDouble(tabelaIngredientes.Rows[i][1]);

                    custoUnit = a.CustoIngrediente(codIngrediente, Convert.ToInt32(cbUnidade.SelectedValue));
                    custoTotal = custoUnit * quant;


                    String[] V = new string[] { codIngrediente, nomeingrediente, quant.ToString("#,0.0000"), um, fc.ToString("#,0.0000"), custoUnit.ToString("#,0.00"), custoTotal.ToString("#,0.00") };
                    dgvFicha.Rows.Add(V);

                }
                RecalcularCusto();

            }


        }

        private void RecalcularCusto()
        {
            double total = 0;
            double peso = 0;
            double porcao = 0;
            if (dgvFicha.Rows.Count > 0)
            {
                for (int i = 0; i < dgvFicha.Rows.Count; i++)
                {
                    total += Convert.ToDouble(dgvFicha.Rows[i].Cells[6].Value);
                }
            }
            if(txtPeso.Text.Trim() != "")
            {
                peso = Convert.ToDouble(txtPeso.Text);

            }
            if (txtRendimento.Text.Trim() != "")
            {
                porcao = Convert.ToDouble(txtRendimento.Text);
            }

            if (peso > 0)
            {
                lbCustoKg2.Text = (total / peso).ToString("#,0.00");
            }
            else
            {
                lbCustoKg2.Text = 0.ToString("#,0.00");
            }

            if (porcao > 0)
            {
                lbCustoPorcao2.Text = (total / porcao).ToString("#,0.00");
            }
            else
            {
                lbCustoPorcao2.Text = 0.ToString("#,0.00");
            }

            lbCustoTotal2.Text = total.ToString("#,0.00");


        }

        #endregion

        #region Click/Keydowns/Validating

        private void txtRendimento_Validating(object sender, CancelEventArgs e)
        {
            double doubleValue;
            if(txtRendimento.Text == "")
            {
                txtRendimento.Text = "0,00";
                RecalcularCusto();
            }
            string txt = txtRendimento.Text;

            if (Double.TryParse(txt, out doubleValue))
            {
                txtRendimento.Text = doubleValue.ToString("#,0.00");
                RecalcularCusto();
            }

            else if (txtRendimento.Text == "")
            {
            }
            else
            {
                e.Cancel = true;
                MessageBox.Show("Digite um valor numérico com até duas casas decimais.");
            }
        }

        private void txtQuant_Validating(object sender, CancelEventArgs e)
        {
            double doubleValue;

            string txt = txtQuant.Text;

            if (Double.TryParse(txt, out doubleValue))
            {
                txtQuant.Text = doubleValue.ToString("#,0.00000");

            }

            else if (txtQuant.Text == "")
            {
            }
            else
            {
                e.Cancel = true;
                MessageBox.Show("Digite um valor numérico com até quatro casas decimais.");
            }
        }

        private void txtCodItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                Forms.CMV.frmConsultaAeB f = new Forms.CMV.frmConsultaAeB(true);
                f.ShowDialog();

                if (f.codigo != "")
                {
                    try
                    {
                        DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                        BLLAeB bll = new BLLAeB(cx);

                        DTOAeB modelo = bll.CarregaModeloAeB(f.codigo);

                        txtCodItem.Text = modelo.CodAeb.ToString();
                        txtNomeItem.Text = modelo.NomeAeb.ToString();
                        txtFc.Text = modelo.Fc.ToString();
                        txtUm.Text = modelo.UmAeb.ToString();
                        txtQuant.Enabled = true;
                        btAddIngrediente.Enabled = true;

                        txtQuant.Focus();
                    }
                    catch
                    {
                        MessageBox.Show("Código inválido. Por favor selecione um código existente");
                        btAddIngrediente.Enabled = false;
                    }
                }
                else
                {

                }

                f.Dispose();
            }
        }

        private void txtQuant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                double doubleValue;

                string txt = txtQuant.Text;

                if (Double.TryParse(txt, out doubleValue))
                {
                    txtQuant.Text = doubleValue.ToString("#,0.00000");

                }

                else
                {
                    MessageBox.Show("Digite um valor numérico com até quatro casas decimais.");
                }



                btAddIngrediente_Click(sender, e);
            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            operacao = "editar";
            AlteraBotoes();
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            operacao = "consultar";
            frmConsultaFichas cf = new frmConsultaFichas(idUsuario, true);
            cf.ShowDialog();

            if(cf.fichaSelecionada != "" && !string.IsNullOrEmpty(cf.fichaSelecionada))
            {

                CarregaFicha(cf.fichaSelecionada);

            }

            cf.Dispose();
            
            AlteraBotoes();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            if (txtPeso.Text.Trim() == "")
            {
                txtPeso.Text = 0.00.ToString("#,0.00");
            }

            if (txtNome.Text.Trim() != "" && Convert.ToDouble(txtRendimento.Text) > 0 && cbSetor.Text != "" && txtCodigoPrato.Text.Trim() != ".  .")
            {

                if(dgvFicha.Rows.Count > 0)
                {
                    Salvar();
                }
                else
                {
                    MessageBox.Show("Atenção! Insira pelo menos um ingrediente na ficha técnica para salvá-la.");

                }
            }
            else
            {
                MessageBox.Show("Atenção! Todos os campos com asterisco (*) são de preenchimento obrigatório.");
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            SalvarIngredientes();            
            AlteraBotoes();
            gbIngredientes.Enabled = false;
            gbFicha.Enabled = true;

        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            operacao = "inserir";
            zerarPagina();
            txtNome.Focus();
            txtNome.Select();

        }

        private void btAddIngrediente_Click(object sender, EventArgs e)
        {
            if(txtCodItem.Text.Trim() == txtCodigoPrato.Text.Trim())
            {
                MessageBox.Show("Impossível adicinar uma ficha técnica dentro dela mesma.");
                txtNomeItem.Clear();
                txtUm.Clear();
                txtFc.Clear();
                txtQuant.Clear();
                txtCodItem.Clear();
                txtCodItem.Focus();
                txtCodItem.Select();
            }else
            {
                if (txtCodigoPrato.Text.Trim() == ".  .")
                {
                    MessageBox.Show("Antes de acrescentar o ingrediente, determine um nome para o prato.");
                    txtNome.Focus();
                    txtNome.Select();
                }
                else
                {
                    AddIngrediente();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("ATENÇÃO! Ao cancelar esta operação os dados não salvos serão perdidos. Continuar?", "Aviso", MessageBoxButtons.YesNo);
            if (d.ToString() == "Yes")
            {
                operacao = "consultar";
                zerarPagina();
                liberado = true;
                if (herdado)
                {
                    this.Close();
                }

            }
        }

        private void dgvFicha_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 && operacao != "consultar")
            {
                if (e.RowIndex >= 0)
                {

                    txtCodItem.Text = Convert.ToString(dgvFicha.Rows[e.RowIndex].Cells[0].Value);
                    txtQuant.Text = Convert.ToDouble(dgvFicha.Rows[e.RowIndex].Cells[2].Value).ToString("#,0.0000");
                    txtNomeItem.Text = Convert.ToString(dgvFicha.Rows[e.RowIndex].Cells[1].Value);
                    txtUm.Text = Convert.ToString(dgvFicha.Rows[e.RowIndex].Cells[3].Value);
                    txtFc.Text = Convert.ToString(dgvFicha.Rows[e.RowIndex].Cells[4].Value);
                    txtQuant.Enabled = true;
                    btAddIngrediente.Enabled = true;

                    dgvFicha.Rows.RemoveAt(e.RowIndex);

                    RecalcularCusto();

                    txtCodItem.Focus();
                    
                }
            }
        }

        #endregion

        #region Enter/Leave

        private void txtNome_Leave(object sender, EventArgs e)
        {
            if(txtNome.Text.Trim() != "")
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLPratos bll = new BLLPratos(cx);

                DataTable tabela = bll.LocalizarNome(txtNome.Text.Trim());

                if (tabela.Rows.Count == 0)
                {

                    txtNome.Text = txtNome.Text.Trim().ToUpper();
                    if (txtCodigoPrato.Text.Trim() == ".  .")
                    {
                        txtCodigoPrato.Text = CodigoNovo();
                        
                    }
                }
                else
                {
                    if (liberado && tabela.Rows[0][0].ToString() != txtCodigoPrato.Text )
                    {
                        MessageBox.Show($"Já existe um prato chamado {txtNome.Text}.");
                        txtNome.Focus();
                        txtNome.Select();

                    }else
                    {

                    }
                }

            }else
            {
            }

            
        }

        private void txtCodItem_Leave(object sender, EventArgs e)
        {

            if (txtCodItem.Text.Trim() != ".  .")
            {

                try
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLAeB bll = new BLLAeB(cx);

                    DTOAeB modelo = bll.CarregaModeloAeB(txtCodItem.Text);

                    txtCodItem.Text = modelo.CodAeb.ToString();
                    txtNomeItem.Text = modelo.NomeAeb.ToString();
                    txtFc.Text = modelo.Fc.ToString();
                    txtUm.Text = modelo.UmAeb.ToString();

                    btAddIngrediente.Enabled = true;
                    txtQuant.Enabled = true;

                    txtQuant.Focus();
                }
                catch
                {
                    MessageBox.Show("Código inválido. Por favor selecione um código existente");
                    btAddIngrediente.Enabled = false;
                    txtQuant.Enabled = false;
                }
            }
                           
        }

        private void txtCodItem_Enter(object sender, EventArgs e)
        {
            if(txtNome.Text.Trim() == "" && liberado)
            {
                MessageBox.Show("Antes de escolher o ingrediente defina um nome para a ficha técnica!", "IMPORTANTE");
                txtNome.Focus();
                txtNome.Select();
            }
        }

        private void cbSetor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbSetor.Text == "**Cadastrar**")
            {
                Forms.Fichas.frmCategoriasFichas f = new Forms.Fichas.frmCategoriasFichas("Setor", true, idUsuario);
                f.ShowDialog();
                CarregaCat();
                if(f.categoria != "")
                {                    
                    cbSetor.Text = f.categoria;
                }

                f.Dispose();
                                
            }
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategoria.Text == "**Cadastrar**")
            {
                Forms.Fichas.frmCategoriasFichas f = new Forms.Fichas.frmCategoriasFichas("Categoria", true, idUsuario);
                f.ShowDialog();
                CarregaCat();
                if (f.categoria != "")
                {
                    cbCategoria.Text = f.categoria;
                }

                f.Dispose();

            }
        }

        private void cbSubCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSubCategoria.Text == "**Cadastrar**")
            {
                Forms.Fichas.frmCategoriasFichas f = new Forms.Fichas.frmCategoriasFichas("Subcategoria", true, idUsuario);
                f.ShowDialog();
                CarregaCat();
                if (f.categoria != "")
                {
                    cbSubCategoria.Text = f.categoria;
                }

                f.Dispose();

            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show($"Deseja realmente excluir a ficha tédnica {txtNome.Text}?", "ATENÇÃO!", MessageBoxButtons.YesNo);
            if (d.ToString() == "Yes")
            {

                Augoritmos au = new Augoritmos();
                au.ExcluirPrato(txtCodigoPrato.Text);
                zerarPagina();
            }

        }        

        private void btCarregaFoto_Click(object sender, EventArgs e)
        {

            
            // Mostra uma caixa de diálogo para salvar a imagem


            OpenFileDialog saveFileDialog1 = new OpenFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg";
            saveFileDialog1.Title = "Salvar uma imagem.";
            saveFileDialog1.ShowDialog();

            foto = saveFileDialog1.FileName;
            if (foto != "")
            {
                pbFoto.Load(foto);
                
            }
            // If the file name is not an empty string open it for saving.
            btDeletaFoto.Enabled = true;
        }

        private void btDeletaFoto_Click(object sender, EventArgs e)
        {
            
            DTOCaminhos dto = new DTOCaminhos();
            pbFoto.Load(dto.Produtos + "0.jpg");
            foto = "del";
           
            btDeletaFoto.Enabled = false;

        }

        private void dgvFicha_SelectionChanged(object sender, EventArgs e)
        {
            dgvFicha.ClearSelection();
        }

        #endregion
        
    }
}
