using GUI.Code.BLL;
using GUI.Code.DAL;
using GUI.Code.DTO;
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

namespace GUI
{
    public partial class frmEntrada : Form
    {
        #region(Variáveis)

        private string operacao = "";
        private int idUsuario = 0;
        int idLancamento = 0;
        private int permissaoUsuario = 0;
        private int idUnidade = 0;
        int maiorValor = 1;
        double totalLancamento = 0.00;

        #endregion

        #region(Inicialização)

        public frmEntrada( int id)
        {
           idUsuario = id;

            InitializeComponent();
        }

        private void frmEntrada_Load(object sender, EventArgs e)
        {
            
            dgvProdutos.Columns.Add(new DeleteColumn());


            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(idUsuario);

            idUnidade = modelou.IdUnidade;
            permissaoUsuario = modelou.PermissaoUsuario;
            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUnidade bllun = new BLLUnidade(cx);
            cbUnidade.DataSource = bllun.Localizar("");
            cbUnidade.DisplayMember = "cod_unidade";
            cbUnidade.ValueMember = "id_unidade";
            cbUnidade.Text = modelou.IdUnidade.ToString();
            if (modelou.PermissaoUsuario < 4)
            {

                cbUnidade.Enabled = false;
            }


            this.AlteraBotoes(1);
        }
        #endregion

        #region(Comandos LEAVE, ENTER E GOT_FOCUS)

        private void txtDataEmissao_Leave(object sender, EventArgs e)
        {

            DateTime resultado = DateTime.MinValue;
            if (DateTime.TryParse(this.txtDataEmissao.Text.Trim(), out resultado))
            {
                String.Format("{0:MM/dd/yyyy}", resultado);

                txtDataEmissao.Text = resultado.ToString();

                txtDataEntrada.Text = resultado.ToString();

            }
            else
            {
                if (txtDataEmissao.Text.Trim() != "/  /")
                {
                    MessageBox.Show("Data inválida.");
                    txtDataEmissao.Focus();
                }


            }

        }

        private void txtDataEntrada_Leave(object sender, EventArgs e)
        {

            DateTime resultado = DateTime.MinValue;
            if (DateTime.TryParse(this.txtDataEntrada.Text.Trim(), out resultado))
            {

                txtDataEntrada.Text = resultado.ToString("d");

                if (Convert.ToDateTime(txtDataEntrada.Text) < Convert.ToDateTime(txtDataEmissao.Text))
                {
                    MessageBox.Show("A data de entrada deve ser igual ou posterior a data de emissão.");
                    txtDataEntrada.Focus();
                }


            }
            else
            {
                if (txtDataEntrada.Text.Trim() != "/  /")
                {
                    MessageBox.Show("Data inválida.");
                    txtDataEntrada.Focus();
                }
            }
        }

        private void txtCustoUnit_Leave(object sender, EventArgs e)
        {

            if (txtCustoUnit.Text != "")
            {
                txtCustoUnit.Text = Convert.ToDouble(txtCustoUnit.Text).ToString("0,0.00");
            }
            if (txtQuant.Text != "" && txtCustoUnit.Text != "")
            {
                txtCustoTotal.Text = (Convert.ToDouble(txtCustoUnit.Text) * Convert.ToInt32(txtQuant.Text)).ToString("0,0.00");
            }
        }

        private void txtCustoTotal_Leave(object sender, EventArgs e)
        {

            if (txtCustoTotal.Text != "")
            {
                txtCustoTotal.Text = Convert.ToDouble(txtCustoTotal.Text).ToString("0,0.00");
            }
            if (txtQuant.Text != "" && txtCustoTotal.Text != "")
            {
                txtCustoUnit.Text = (Convert.ToDouble(txtCustoTotal.Text) / Convert.ToInt32(txtQuant.Text)).ToString("0,0.00");
            }
        }

        private void txtFornecedor_Leave(object sender, EventArgs e)
        {
            if (txtFornecedor.Text != "")
            {


                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLFornecedor bll = new BLLFornecedor(cx);

                DTOFornecedor modelo = bll.CarregaModeloFornecedor(Convert.ToInt32(txtFornecedor.Text));

                if (modelo.RazaoFornecedor == null)
                {
                    MessageBox.Show("Código de fornecedor inválido.");
                    lbForn.Text = "";
                    txtFornecedor.Clear();
                    txtFornecedor.Select();
                }

                if (txtFornecedor.Text != "")
                {
                    lbForn.Text = modelo.FantasiaFornecedor;
                    txtFornecedor.Text = Convert.ToInt32(txtFornecedor.Text).ToString("000000");
                }




            }
        }

        private void txtQuant_Leave(object sender, EventArgs e)
        {

            int quant = 0;
            double unit = 0.00;
            double total = 0.00;

            if (txtQuant.Text != "")
            {
                quant = Convert.ToInt32(txtQuant.Text);
            }
            else
            {

            }
            if (txtCustoUnit.Text != "")
            {
                unit = Convert.ToDouble(txtCustoUnit.Text);
            }

            if (txtCustoTotal.Text != "")
            {
                total = Convert.ToDouble(txtCustoTotal.Text);
            }


            if (txtCustoUnit.Text != "" && txtCustoTotal.Text == "")
            {
                txtCustoTotal.Text = Convert.ToDouble(unit * quant).ToString("0,0.00");
            }
            if (txtCustoUnit.Text == "" && txtCustoTotal.Text != "")
            {
                txtCustoUnit.Text = Convert.ToDouble(total / quant).ToString("0,0.00");
            }

            if (txtCustoUnit.Text != "" && txtCustoTotal.Text != "")
            {
                txtCustoTotal.Text = Convert.ToDouble(unit * quant).ToString("0,0.00");
            }

        }

        private void txtDataEmissao_Enter(object sender, EventArgs e)
        {

            this.BeginInvoke((MethodInvoker)delegate () {
                txtDataEmissao.SelectAll();
            });

            MaskedTextBox MTB1 = (MaskedTextBox)sender;
            int VisibleTime = 2000;  //in milliseconds

            ToolTip tt1 = new ToolTip();
            tt1.Show("dd/mm/aaaa", MTB1, 0, 20, VisibleTime);


            txtDataEmissao.SelectionLength = txtDataEmissao.Text.Length;
        }

        private void txtDataEntrada_Enter(object sender, EventArgs e)
        {

            this.BeginInvoke((MethodInvoker)delegate () {
                txtDataEntrada.SelectAll();
            });

            MaskedTextBox MTB2 = (MaskedTextBox)sender;
            int VisibleTime = 2000;  //in milliseconds

            ToolTip tt2 = new ToolTip();
            tt2.Show("dd/mm/aaaa", MTB2, 0, 20, VisibleTime);

        }

        private void cbUnidade_Enter(object sender, EventArgs e)
        {
            ((ComboBox)sender).SelectAll();
        }

        private void txtFornecedor_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void txtNf_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void txtCodProduto_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () {
                txtCodProduto.SelectAll();
            });
        }

        private void txtQuant_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void txtCustoUnit_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void txtCustoTotal_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void txtCodProduto_Leave(object sender, EventArgs e)
        {
            if (txtCodProduto.Text.Trim() != ".")
            {
               
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLProduto bll = new BLLProduto(cx);
                DataTable tabela = bll.LocalizarCod(txtCodProduto.Text.Trim().ToString());

                if (tabela.Rows.Count > 0)
                {

                    txtCodProduto.Text = tabela.Rows[0]["cod_produto"].ToString();
                    txtProdutoNome.Text = tabela.Rows[0]["nome_produto"].ToString();
                    txtProdId.Text = tabela.Rows[0]["id_produto"].ToString();

                }
                else
                {
                    MessageBox.Show("Código de produto inválido.");

                    txtCodProduto.Focus();

                }
                    
                
            }
        }

        #endregion

        #region(Comandos CLICK, KEYDOWN E KEYPRESS)

        private void btEditar_Click(object sender, EventArgs e)
        {

            if (permissaoUsuario < 3 && idLancamento != idUsuario)
            {
                MessageBox.Show("Desculpe, mas você não tem permissão para editar um lançamento que não foi feito por você");
            }
            else
            {
                this.operacao = "editar";
                this.AlteraBotoes(1);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.RowCount == 0)
            {

                if (txtFornecedor.Enabled == false)
                {

                   
                    this.LimpaCampos();
                    AlteraBotoes(1);

                }
                else {

                    this.Close();
                }
            }
            else
            {

                DialogResult d = MessageBox.Show("Deseja realmente cancelar este lançamento?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    this.LimpaCampos();
                }
            }
        }

        private void btProdutos_Click(object sender, EventArgs e)
        {
            DateTime resultado = DateTime.MinValue;

            if (txtFornecedor.Text != "" && lbForn.Text != "")
            {

                if(txtNf.Text != "")
                {


                    if ((DateTime.TryParse(this.txtDataEmissao.Text.Trim(), out resultado)))
                    {

                        DALConexao cxnf = new DALConexao(DadosDaConexao.StringDaConexao);
                        BLLMovimento bllnf = new BLLMovimento(cxnf);

                        DTOMovimento modelo = bllnf.ConsultaNf(Convert.ToInt32(txtNf.Text), Convert.ToInt32(txtFornecedor.Text));

                        if (modelo.IdFornecedor == 0 || this.operacao == "editar")
                        {


                            if ((DateTime.TryParse(this.txtDataEntrada.Text.Trim(), out resultado)))
                            {

                                this.LançaProdutos();

                            }

                            else
                            {

                                MessageBox.Show("Data de entrada inválida.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Já existe a nota " + txtNf.Text + " para o fornecedor " + lbForn.Text + ".");
                        }

                    }
                    else
                    {

                        MessageBox.Show("Data de emissão inválida.");

                    }

                }
                else
                {
                    MessageBox.Show("O número da nota não pode ficar em branco.");
                }

            }
            else
            {

                MessageBox.Show("Código de fornecedor inválido.");

            }
            
            //Valida os dados da nota e passa para os produtos
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            this.operacao = "consulta";

            if (cbUnidade.Text != "" || txtFornecedor.Text != "" || txtNf.Text != "" || txtDataEmissao.Text.Trim() != "/  /" || txtDataEntrada.Text.Trim() != "/  /")
            {
                int unidadeC;
                int FornecedorC;
                int NfC;
                DateTime EmissaoC;
                DateTime EntradaC;

                if (cbUnidade.Text != "")
                {
                    unidadeC = Convert.ToInt32(cbUnidade.SelectedValue);

                }
                else
                {
                    unidadeC = 0;
                }

                if (txtFornecedor.Text != "")
                {
                    FornecedorC = Convert.ToInt32(txtFornecedor.Text);
                }
                else
                {
                    FornecedorC = 0;
                }

                if (txtNf.Text != "")
                {
                    NfC = Convert.ToInt32(txtNf.Text);
                }
                else
                {
                    NfC = 0;
                }

                if (txtDataEmissao.Text.Trim() != "/  /")
                {
                    EmissaoC = Convert.ToDateTime(txtDataEmissao.Text);
                }
                else
                {
                    EmissaoC = DateTime.MinValue;
                }

                if (txtDataEntrada.Text.Trim() != "/  /")
                {
                    EntradaC = Convert.ToDateTime(txtDataEntrada.Text);
                }
                else
                {
                    EntradaC = DateTime.MinValue;
                }


                frmConsultaNf nf = new frmConsultaNf(unidadeC, FornecedorC, NfC, EmissaoC, EntradaC);
                nf.ShowDialog();
                nf.Dispose();

                if (nf.lancamento != 0)
                {
                    if (nf.lancamento == -1)
                    {
                        MessageBox.Show("Não foi encontrado nenhum registro que corresponda à pesquisa.");
                    }
                    else
                    {
                        int nflancamento = nf.lancamento;
                        txtLancamento.Text = nflancamento.ToString("00000000");
                        this.CarregarDados(nf.lancamento);


                        this.AlteraBotoes(3);
                    }
                }
                else
                {
                    MessageBox.Show("Defina algum parâmetro para a pesquisa.");
                }

            }

        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.RowCount <= 0)
            {
                MessageBox.Show("Insira algum produto para salvar.");
            }
            else
            {
                

                if (this.operacao == "incluir")
                {

                    this.Salvar();

                }
                else
                {
                        this.Excluir(Convert.ToInt32(txtLancamento.Text));
                        this.Salvar();

                }
            }
        }

        private void btNf_Click(object sender, EventArgs e)
        {
            this.AlteraBotoes(1);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {


            if(txtProdId.Text != "" && txtQuant.Text != "" && txtCustoUnit.Text != "")
            {

                if(Convert.ToInt32(txtQuant.Text) > 0 && Convert.ToDouble(txtCustoUnit.Text) > 0)
                {

                                          
                        double totalItem = Convert.ToDouble(txtCustoUnit.Text) * Convert.ToInt32(txtQuant.Text);


                        String[] P = new string[] { maiorValor.ToString(), txtProdId.Text, txtProdutoNome.Text, Convert.ToInt32(txtQuant.Text).ToString(), Convert.ToDouble(txtCustoUnit.Text).ToString("0,0.00"), totalItem.ToString("0,0.00") };

                        this.dgvProdutos.Rows.Add(P);

                        totalLancamento = totalLancamento + totalItem;
                        lbTotalLancamento.Text = totalLancamento.ToString("0,0.00");
                        txtProdId.Clear();
                        txtProdutoNome.Clear();
                        txtQuant.Clear();
                        txtCustoUnit.Clear();
                        txtCustoTotal.Clear();
                        txtCodProduto.Clear();
                        txtCodProduto.Focus();
                        maiorValor = maiorValor + 1;
                        
                   

                }
                else
                {
                    MessageBox.Show("Os campos quantidade e custo não podem ficar zerados.");
                    txtQuant.Focus();
                }

            }
            else
            {
                MessageBox.Show("Campo inválido. Verifique se existe um produto selecionado, uma quantidade e um valor atribuído a ele.");
                txtProdutoNome.Focus();
            }


        }

        private void btExcluir_Click(object sender, EventArgs e)
        {

            if (permissaoUsuario < 3 && idLancamento != idUsuario)
            {
                MessageBox.Show("Desculpe, mas você não tem permissão para editar um lançamento que não foi feito por você");
            }
            else
            {

                DialogResult d = MessageBox.Show("Deseja realmente excluir este lançamento? Após esta operação não há volta.", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    this.Excluir(Convert.ToInt32(txtLancamento.Text));
                }
            }
        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (e.RowIndex >= 0)
                {
                    txtProdId.Text = dgvProdutos.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtProdutoNome.Text = Convert.ToString(dgvProdutos.Rows[e.RowIndex].Cells[2].Value);
                    txtQuant.Text = Convert.ToInt32(dgvProdutos.Rows[e.RowIndex].Cells[3].Value).ToString();
                    txtCustoUnit.Text = Convert.ToDouble(dgvProdutos.Rows[e.RowIndex].Cells[4].Value).ToString("0,0.00");
                    txtCustoTotal.Text = Convert.ToDouble(dgvProdutos.Rows[e.RowIndex].Cells[5].Value).ToString("0,0.00");


                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLProduto bll = new BLLProduto(cx);

                    DTOProduto modelo = bll.CarregaModeloProduto(Convert.ToInt32(txtProdId.Text));

                    
                    txtCodProduto.Text = modelo.CodProduto.ToString();
                    

                    totalLancamento = totalLancamento - Convert.ToDouble(dgvProdutos.Rows[e.RowIndex].Cells[5].Value);

                    lbTotalLancamento.Text = totalLancamento.ToString("0,0.00");

                    dgvProdutos.Rows.RemoveAt(e.RowIndex);

                }
            }
        }

        private void txtFornecedor_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F5)
            {
                frmConsultaFornecedor f = new frmConsultaFornecedor(idUsuario);
                f.ShowDialog();


                if (f.codigo != 0)
                {
                   
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLFornecedor bll = new BLLFornecedor(cx);

                    DTOFornecedor modelo = bll.CarregaModeloFornecedor(f.codigo);
                    txtFornecedor.Text = modelo.IdFornecedor.ToString();
                    lbForn.Text = modelo.RazaoFornecedor.ToString();
                    txtNf.Select();
                }
                else
                {
                
                }

                f.Dispose();
            }
        }

        private void txtCustoUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCustoUnit.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
        }

        private void txtCustoTotal_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (txtCustoTotal.Text.Contains(",") && e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
        }

        private void txtQuant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
        }

        private void txtCodProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmConsultaBasica_Produto f = new frmConsultaBasica_Produto(1, idUsuario);
                f.ShowDialog();


                if (f.codigo != 0)
                {

                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLProduto bll = new BLLProduto(cx);

                    DTOProduto modelo = bll.CarregaModeloProduto(f.codigo);

                    txtProdutoNome.Text = modelo.NomeProduto.ToString();
                    txtProdId.Text = modelo.IdProduto.ToString();
                    txtCodProduto.Text = modelo.CodProduto.ToString();
                    txtQuant.Select();

                }
                else
                {

                }

                f.Dispose();
            }
        }

        #endregion

        #region(DEMAIS VOIDS)

        private void AlteraBotoes(int valor)
        {

            gbNf.Enabled = false;
            gbItens.Enabled = false;
            btLocalizar.Enabled = false;
            btProdutos.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btSalvar.Enabled = false;
            
            btNf.Visible = false;

            //Padrão
            if (valor == 1)
            {
                gbNf.Enabled = true;
                if (this.operacao == "")
                {
                    btLocalizar.Enabled = true;
                }
                btProdutos.Enabled = true;
               
            }
            //Inserir
            else if (valor == 2)
            {
                
                gbItens.Enabled = true;
                btSalvar.Enabled = true;
                txtCodProduto.Focus();
                
                btNf.Visible = true;
            }
            //Localizar
            else if (valor == 3)
            {
                
                btEditar.Enabled = true;
                btExcluir.Enabled = true;
            }

            else
            {
                gbNf.Enabled = true;
                if (this.operacao != "incluir")
                {
                    btLocalizar.Enabled = true;
                }
                btProdutos.Enabled = true;

            }
        }

        private void LimpaCampos()
        {
            txtLancamento.Clear();
            txtFornecedor.Clear();
            txtNf.Clear();
            txtDataEmissao.Clear();
            txtDataEntrada.Clear();
            dgvProdutos.ClearSelection();
            operacao = "";
            lbForn.Text = "";
            this.AlteraBotoes(1);
            dgvProdutos.Rows.Clear();
            txtCodProduto.Clear();
            maiorValor = 1;
            totalLancamento = 0.00;
            lbTotalLancamento.Text = totalLancamento.ToString("0,0.00");
        }

        private void LançaProdutos()
        {
            int lancamento;

            if(txtLancamento.Text == "")
            {

                try {
                    SqlConnection con = new SqlConnection(DadosDaConexao.StringDaConexao.ToString()); // making connection   
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT max(lancamento) FROM movimentacao", con);

                    DataTable dt = new DataTable(); //this is creating a virtual table  
                    sda.Fill(dt);
                    
                    lancamento = Convert.ToInt32(dt.Rows[0][0]);
                    lancamento = lancamento+1;
                    txtLancamento.Text = lancamento.ToString("00000000");

                }
                catch
                {
                    txtLancamento.Text = "00000001";
                }
            }

            if(this.operacao == "")
            {
                this.operacao = "incluir";
            }
            this.AlteraBotoes(2);
            
        }

        public class DeleteCell : DataGridViewButtonCell
        {
            Image del = Image.FromFile("Imagens\\Icones\\circle-x-3x.png");
            protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
                graphics.DrawImage(del, cellBounds);
            }
        }

        public class DeleteColumn : DataGridViewButtonColumn
        {
            public DeleteColumn()
            {
                this.CellTemplate = new DeleteCell();
                this.Width = 24;
                //set other options here 
            }
        }

        private void Salvar()
        {

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

            DTOMovimento mov = new DTOMovimento();
            BLLMovimento bllmov = new BLLMovimento(cx);


            for (int i = 0; i < dgvProdutos.RowCount; i++)
            {

                mov.Lancamento = Convert.ToInt32(txtLancamento.Text);
                mov.NfMov = Convert.ToInt32(txtNf.Text);
                mov.DataNfMov = Convert.ToDateTime(txtDataEmissao.Text);
                mov.DataCriacaoMov = DateTime.Now;
                mov.DataMov = Convert.ToDateTime(txtDataEntrada.Text);
                mov.IdUnidade = Convert.ToInt32(cbUnidade.SelectedValue);
                mov.IdFornecedor = Convert.ToInt32(txtFornecedor.Text);
                mov.IdUsuario = idUsuario;


                mov.IdProduto = Convert.ToInt32(dgvProdutos.Rows[i].Cells[1].Value);
                mov.QuantMov = Convert.ToInt32(dgvProdutos.Rows[i].Cells[3].Value);
                mov.CustoUnitMov = Convert.ToDouble(dgvProdutos.Rows[i].Cells[4].Value);
                mov.TipoMov = "Entrada";

                bllmov.Incluir(mov);

            }

            this.LimpaCampos();
            this.AlteraBotoes(1);

        }

        private void Excluir(int lancamento)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLMovimento bll = new BLLMovimento(cx);
            bll.Excluir(lancamento);

        }

        private void CarregarDados(int lancamento)
        {
            try
            {
                DALConexao cxnf = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLMovimento bllnf = new BLLMovimento(cxnf);

                DataTable tabela = bllnf.Localizar(lancamento.ToString());


                //Preenche dados da nota
                cbUnidade.Text = tabela.Rows[0]["cod_unidade"].ToString();
                txtFornecedor.Text = Convert.ToInt32(tabela.Rows[0]["id_fornecedor"]).ToString("000000");
                txtNf.Text = Convert.ToInt32(tabela.Rows[0]["nf_mov"]).ToString();
                txtDataEmissao.Text = Convert.ToDateTime(tabela.Rows[0]["data_nf_mov"]).ToString("d");
                txtDataEntrada.Text = Convert.ToDateTime(tabela.Rows[0]["data_mov"]).ToString("d");
                lbForn.Text = tabela.Rows[0]["fantasia_fornecedor"].ToString();

                idLancamento = Convert.ToInt32(tabela.Rows[0]["id_usuario"]);

                double totalNF = 0;
                maiorValor = 1;
                

                // Preenche produtos
                for (int i = 0; i < tabela.Rows.Count; i++)
                {

                    string idProdutoMov = tabela.Rows[i]["id_produto"].ToString();
                    string nomeProdutoMov = tabela.Rows[i]["nome_produto"].ToString();
                    string quantMov = tabela.Rows[i]["quant_mov"].ToString();
                    string custoMov = Convert.ToDouble(tabela.Rows[i]["custo_unitario_mov"]).ToString("0,0.00");
                    string custoTotalMov = (Convert.ToInt32(quantMov) * Convert.ToDouble(custoMov)).ToString("0,0.00");

                    totalNF += Convert.ToDouble(custoTotalMov);


                    String[] P = new string[] { maiorValor.ToString(), idProdutoMov, nomeProdutoMov, quantMov, custoMov, custoTotalMov };
                    this.dgvProdutos.Rows.Add(P);
                    maiorValor++;
                }

                lbTotalLancamento.Text = totalNF.ToString("0,0.00");

            }
            catch
            {
                MessageBox.Show("Erro.");
            }

        }

        #endregion
    }
}
