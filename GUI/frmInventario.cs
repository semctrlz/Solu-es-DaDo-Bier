using GUI.Code.BLL;
using GUI.Code.DAL;
using GUI.Code.DTO;
using System;
using System.Collections;
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
    public partial class frmInventario : Form
    {

        #region Variáveis
        //Imprimir página
        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height



        int idUsuario;
        int unidade;
        string busca;
        string operacao;
        int nrInventario;
        #endregion

        #region Inicialização

        public frmInventario(int id)
        {
            idUsuario = id;
            InitializeComponent();
            
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {

            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(idUsuario);

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";

            txtDataInventario.GotFocus += txtDataInventario_GotFocus;
            txtDataMovimento.GotFocus += txtDataMovimento_GotFocus;
            txtCodProdAdd.GotFocus += txtCodProdAdd_GotFocus;
            txtNomeProdutoAdd.GotFocus += txtNomeProdutoAdd_GotFocus;
            txtMarcaProdutoAdd.GotFocus += txtMarcaProdutoAdd_GotFocus;
            txtModeloProdutoAdd.GotFocus += txtModeloProdutoAdd_GotFocus;
            txtQuantProdutoAdd.GotFocus += txtQuantProdutoAdd_GotFocus;

            dgvInventario.Columns.Add(new DeleteColumn());

            this.LimpaCampos();

            this.AlteraBotoes(1);
            
        }

        #endregion

        #region Leave / Enter / Keys

        private void txtDataInventario_Leave(object sender, EventArgs e)
        {
            DateTime resultado = DateTime.MinValue;
            if (DateTime.TryParse(this.txtDataInventario.Text.Trim(), out resultado))
            {

                txtDataInventario.Text = resultado.ToString("d");
                txtDataMovimento.Text = resultado.ToString("d");
            }

            else
            {
                if (txtDataInventario.Text.Trim() != "/  /")
                {
                    MessageBox.Show("Data inválida.");
                    txtDataInventario.Focus();
                }
            }
        }

        private void txtDataMovimento_Leave(object sender, EventArgs e)
        {
            DateTime resultado = DateTime.MinValue;
            if (DateTime.TryParse(this.txtDataMovimento.Text.Trim(), out resultado))
            {

                txtDataMovimento.Text = resultado.ToString("d");

                if (Convert.ToDateTime(txtDataMovimento.Text) < Convert.ToDateTime(txtDataInventario.Text))
                {
                    MessageBox.Show("A data de movimento deve ser igual ou posterior a data de inventário.");
                    txtDataMovimento.Focus();
                }


            }
            else
            {
                if (txtDataMovimento.Text.Trim() != "/  /")
                {
                    MessageBox.Show("Data inválida.");
                    txtDataMovimento.Focus();
                }
            }
        }

        private void txtDataInventario_Enter(object sender, EventArgs e)
        {
            MaskedTextBox MTB2 = (MaskedTextBox)sender;
            int VisibleTime = 2000;  //in milliseconds

            ToolTip tt2 = new ToolTip();
            tt2.Show("dd/mm/aaaa", MTB2, 0, 20, VisibleTime);

        }

        private void txtDataMovimento_Enter(object sender, EventArgs e)
        {
            MaskedTextBox MTB2 = (MaskedTextBox)sender;
            int VisibleTime = 2000;  //in milliseconds

            ToolTip tt2 = new ToolTip();
            tt2.Show("dd/mm/aaaa", MTB2, 0, 20, VisibleTime);

        }

        private void cbTipoInv_Leave(object sender, EventArgs e)
        {
            if(cbTipoInv.Text != "Estoque Inicial")
            {
                cbTipoInv.Text = "Inventário";
            }
        }

        private void cbUnidade_Leave(object sender, EventArgs e)
        {

            if (cbUnidade.SelectedValue == null)
            {
                cbUnidade.Text = unidade.ToString("00");
            }


        }

        private void txtCodProdAdd_KeyDown(object sender, KeyEventArgs e)
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

                    txtCodProdAdd.Text = modelo.CodProduto.ToString();
                    txtNomeProdutoAdd.Text = modelo.NomeProduto.ToString();
                    txtMarcaProdutoAdd.Text = modelo.MarcaProduto.ToString();
                    txtModeloProdutoAdd.Text = modelo.ModelodoProduto.ToString();
                    
                    txtCodProdAdd.Focus();

                }
                else
                {

                }

                f.Dispose();
            }
        }

        private void txtCodProdAdd_Leave(object sender, EventArgs e)
        {
            if (txtCodProdAdd.Text.Trim() != ".")
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLProduto bll = new BLLProduto(cx);
                DataTable tabela = bll.LocalizarCod(txtCodProdAdd.Text.Trim().ToString());

                if (tabela.Rows.Count > 0)
                {

                    txtCodProdAdd.Text = tabela.Rows[0]["cod_produto"].ToString();
                    txtNomeProdutoAdd.Text = tabela.Rows[0]["nome_produto"].ToString();
                    txtMarcaProdutoAdd.Text = tabela.Rows[0]["marca_produto"].ToString();
                    txtModeloProdutoAdd.Text = tabela.Rows[0]["modelo_produto"].ToString();

                }
                else
                {
                    MessageBox.Show("Código de produto inválido.");

                    txtCodProdAdd.Focus();
                    txtNomeProdutoAdd.Text = "";
                    txtMarcaProdutoAdd.Text = "";
                    txtModeloProdutoAdd.Text = "";
                }
            }
        }
        
        #endregion

        #region Focus

        void txtDataInventario_GotFocus(object sender, EventArgs e)
        {
            txtDataInventario.SelectAll();
        }

        void txtDataMovimento_GotFocus(object sender, EventArgs e)
        {
            txtDataMovimento.SelectAll();
        }

        void txtCodProdAdd_GotFocus(object sender, EventArgs e)
        {
            txtCodProdAdd.SelectAll();
        }

        void txtNomeProdutoAdd_GotFocus(object sender, EventArgs e)
        {
            txtNomeProdutoAdd.SelectAll();
        }

        void txtMarcaProdutoAdd_GotFocus(object sender, EventArgs e)
        {
            txtMarcaProdutoAdd.SelectAll();
        }

        void txtModeloProdutoAdd_GotFocus(object sender, EventArgs e)
        {
            txtModeloProdutoAdd.SelectAll();
        }

        void txtQuantProdutoAdd_GotFocus(object sender, EventArgs e)
        {
            txtQuantProdutoAdd.SelectAll();
        }


        #endregion

        #region Clique

        private void btGerar_Click(object sender, EventArgs e)
        {
            this.operacao = "incluir";

            if (cbItensAContar.Text == "Total")
            {
                //  Caso quisermos contar todos os itens cadastrados

                busca = "select p.id_produto, p.cod_produto, p.nome_produto, p.marca_produto, p.modelo_produto " +
                " from produto p inner join grupo g on p.id_grupo = g.id_grupo where ";

                string prefix = "";
                int quantFiltros = 0;

                foreach (object element in lbGrupo.SelectedItems)
                {
                    if (quantFiltros > 0)
                    {
                        prefix = " or ";
                    }
                    DataRowView row = (DataRowView)element;
                    busca = busca + prefix + " p.id_grupo = " + row[0].ToString();

                    quantFiltros++;
                }

                busca = busca + " group by id_produto, p.cod_produto, p.nome_produto, p.marca_produto, p.modelo_produto;";

                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLMixUnidade bll = new BLLMixUnidade(cx);
                DataTable tabela = bll.LocalizarValor(busca);


                dgvInventario.Rows.Clear();

                for (int i = 0; i < tabela.Rows.Count; i++)
                {
                    try
                    {
                        string IdProduto = tabela.Rows[i]["id_produto"].ToString();
                        string CodProduto = tabela.Rows[i]["cod_produto"].ToString();
                        string Produto = tabela.Rows[i]["nome_produto"].ToString();
                        string Marca = tabela.Rows[i]["marca_produto"].ToString();
                        string Modelo = tabela.Rows[i]["modelo_produto"].ToString();


                        String[] P = new string[] { IdProduto, CodProduto, Produto, Marca, Modelo, "", "" };
                        this.dgvInventario.Rows.Add(P);
                    }
                    catch
                    {

                    }
                }

            }
            else if (cbItensAContar.Text == "Somente Mix")
            {
                // caso quisermos contar somente o que consta em nosso mix

                busca = "select m.id_produto, p.cod_produto, p.nome_produto, p.marca_produto, p.modelo_produto " +
                    "from mix_unidade m inner join produto p on m.id_produto = p.id_produto " +
                    "where";

                string prefix = "";
                int quantFiltros = 0;

                foreach (object element in lbGrupo.SelectedItems)
                {
                    if (quantFiltros > 0)
                    {
                        prefix = " or ";
                    }

                    DataRowView row = (DataRowView)element;
                    busca = busca + prefix + " p.id_grupo = " + row[0].ToString();

                    quantFiltros++;

                }

                busca = busca + "and  m.id_unidade = " + cbUnidade.SelectedValue.ToString() + " group by m.id_produto, p.cod_produto, p.nome_produto, p.marca_produto, p.modelo_produto;";

                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLMixUnidade bll = new BLLMixUnidade(cx);
                DataTable tabela = bll.LocalizarValor(busca);

                dgvInventario.Rows.Clear();

                for (int i = 0; i < tabela.Rows.Count; i++)
                {
                    try
                    {
                        string IdProduto = tabela.Rows[i]["id_produto"].ToString();
                        string CodProduto = tabela.Rows[i]["cod_produto"].ToString();
                        string Produto = tabela.Rows[i]["nome_produto"].ToString();
                        string Marca = tabela.Rows[i]["marca_produto"].ToString();
                        string Modelo = tabela.Rows[i]["modelo_produto"].ToString();


                        String[] P = new string[] { IdProduto, CodProduto, Produto, Marca, Modelo, "", "" };
                        this.dgvInventario.Rows.Add(P);
                    }
                    catch
                    {

                    }
                }

            }
            else
            {

                MessageBox.Show("Selecione uma opção de contagem.");
                cbItensAContar.Focus();
            }


            this.AlteraBotoes(2);
            txtCodProdAdd.Focus();

        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            //Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Págnina de inventário.";
                printDocument1.Print();
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {

            if(dgvInventario.RowCount > 0)
            {

                if(operacao == "Editar")
                {
                    this.Excluir(Convert.ToInt32(txtNumeroInventario.Text));
                    this.LimpaCamposAdd();
                    this.AlteraBotoes(3);
                }
                else
                {

                    this.Salvar();

                    MessageBox.Show("Inventário salvo com sucesso. Número " + txtNumeroInventario.Text);
                    this.LimpaCamposAdd();
                    this.AlteraBotoes(3);
                }

            }
            else
            {
                MessageBox.Show("Não existem itens para salvar.");
            }

        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaInventario f = new frmConsultaInventario(idUsuario);
            f.ShowDialog();
            f.Dispose();

            if (f.numeroInv > 0)
            {

                string retornaInv = "select i.inventario, i.id_unidade, i.data_criacao_inv, i.data_mov_inv, i.tipo, " +
                                    "i.id_produto, p.cod_produto, p.nome_produto, p.marca_produto, p.modelo_produto, " +
                                    "i.quant_inv, i.id_usuario, i.concluido from inventario i " +
                                    "inner join produto p on i.id_produto = p.id_produto "+
                                    "WHERE i.inventario = " + f.numeroInv;

                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLInventario bll = new BLLInventario(cx);
                DataTable tabela = bll.Localizar(retornaInv);

                dgvInventario.Rows.Clear();



                txtNumeroInventario.Text = Convert.ToInt32(tabela.Rows[0]["inventario"]).ToString("00000000");
                txtDataInventario.Text = Convert.ToDateTime(tabela.Rows[0]["data_criacao_inv"]).ToString("d");
                txtDataMovimento.Text = Convert.ToDateTime(tabela.Rows[0]["data_mov_inv"]).ToString("d");
                cbUnidade.Text = Convert.ToInt32(tabela.Rows[0]["id_unidade"]).ToString("00");

                txtAberto.Text = tabela.Rows[0]["concluido"].ToString();

                if (tabela.Rows[0]["tipo"].ToString() == "C")
                {
                    cbTipoInv.Text = "Inventário";
                }
                else
                {
                    cbTipoInv.Text = "Estoque inicial";
                }




                for (int i = 0; i < tabela.Rows.Count; i++)
                {

                    string idProd = Convert.ToInt32(tabela.Rows[i]["id_produto"]).ToString();
                    string codProduto = tabela.Rows[i]["cod_produto"].ToString();
                    string nomeProd = tabela.Rows[i]["nome_produto"].ToString();
                    string marcaProd = tabela.Rows[i]["marca_produto"].ToString();
                    string modeloProd = tabela.Rows[i]["modelo_produto"].ToString();
                    
                    string quantInventario = tabela.Rows[i]["quant_inv"].ToString();
                                       

                    String[] P = new string[] { idProd, codProduto, nomeProd, marcaProd, modeloProd, quantInventario };
                    this.dgvInventario.Rows.Add(P);

                }
                this.AlteraBotoes(3);

            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            if (txtAberto.Text != "C")
            {

                this.AlteraBotoes(2);
                this.operacao = "Editar";
            }
            else
            {
                MessageBox.Show("Impossível editar um inventário que já foi concluído.");
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {

            if (dgvInventario.RowCount > 0)
            {

                DialogResult d = MessageBox.Show("Deseja realmente cancelar esta esta operação?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    this.LimpaCampos();
                    this.AlteraBotoes(1);
                }
            }
            else
            {
                this.Close();
            }

        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (txtAberto.Text == "A")
            {
                DialogResult d = MessageBox.Show("Deseja realmente excluir o inventário - " + txtNumeroInventario.Text + "?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    this.Excluir(Convert.ToInt32(txtNumeroInventario.Text));
                    this.LimpaCampos();
                    this.AlteraBotoes(1);
                }
            }
            else
            {
                DialogResult d = MessageBox.Show("Deseja realmente excluir o inventário - " + txtNumeroInventario.Text + "? \n " +
                    "Como trata-se de um inventário concluído, esta operação pode gerar inconsistências na quantidade de materiais.", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {

                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLMovimento bll = new BLLMovimento(cx);
                    bll.ExcluirInv(Convert.ToInt32(txtNumeroInventario.Text), unidade);

                    this.Excluir(Convert.ToInt32(txtNumeroInventario.Text));

                    this.LimpaCampos();
                    this.AlteraBotoes(1);

                }
            }
        }

        private void btRodar_Click(object sender, EventArgs e)
        {
            int quantInv;
            DialogResult d = MessageBox.Show("Deseja rodar o inventário " + txtNumeroInventario.Text + " e gerar os movimentos relativos a ele?", "Aviso", MessageBoxButtons.YesNo);
            if (d.ToString() == "Yes")
            {

                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

                DTOInventario inv = new DTOInventario();
                BLLInventario bllinv = new BLLInventario(cx);
                bllinv.Concluir(Convert.ToInt32(txtNumeroInventario.Text));

                // gerar movimentações de estoque

                DTOMovimento mov = new DTOMovimento();
                BLLMovimento bllmov = new BLLMovimento(cx);

                for (int i = 0; i < dgvInventario.RowCount; i++)
                {

                    mov.Lancamento = 0;
                    mov.NfMov = Convert.ToInt32(txtNumeroInventario.Text);
                    mov.DataNfMov = Convert.ToDateTime(txtDataInventario.Text);
                    mov.DataCriacaoMov = DateTime.Now;
                    mov.DataMov = Convert.ToDateTime(txtDataMovimento.Text);
                    mov.IdUnidade = Convert.ToInt32(cbUnidade.SelectedValue);
                    mov.IdFornecedor = Convert.ToInt32(cbUnidade.SelectedValue);
                    mov.IdUsuario = idUsuario;
                    mov.TipoMov = "Inventario";


                    mov.IdProduto = Convert.ToInt32(dgvInventario.Rows[i].Cells[0].Value);


                    //buscar quantidade de diferença
                    try
                    {
                        quantInv = Convert.ToInt32(dgvInventario.Rows[i].Cells[5].Value);
                    }
                    catch
                    {
                        quantInv = 0;
                    }

                    int ultimoInv = 0;
                    int ultimosMovs = 0;
                    DateTime dataUltimoInv;


                    //Localiza quantidade do último inventario concluído.

                    string buscaUltimoInv = "select inventario, data_mov_inv, id_produto, quant_inv from inventario " +
                        " where concluido = 'c' and id_produto = " + mov.IdProduto +
                        " and data_mov_inv < '" + Convert.ToDateTime(txtDataMovimento.Text).ToString("d") + "' order by data_mov_inv asc;";

                    BLLInventario bll = new BLLInventario(cx);
                    DataTable tabela = bll.Localizar(buscaUltimoInv);

                    try
                    {
                        ultimoInv = Convert.ToInt32(tabela.Rows[0]["quant_inv"]);
                    }
                    catch
                    {
                        ultimoInv = 0;
                    }

                    try
                    {
                        dataUltimoInv = Convert.ToDateTime(tabela.Rows[0]["data_mov_inv"]);
                    }
                    catch
                    {
                        DateTime data = new DateTime(1900, 1, 1);
                        dataUltimoInv = data;
                    }


                    //Soma movimentos de um período de tempo.
                    //select sum(quant_mov) as quantidade, id_produto from movimentacao where data_mov between '2016-05-10' and '2016-05-24' and id_produto = 38 group by id_produto, quant_mov;

                    string buscaQuantMovimentacoes = "select sum(quant_mov) as quantidade, id_produto from movimentacao " +
                        "where data_mov > '" + dataUltimoInv.ToString("d") + "' and data_mov <= '" + Convert.ToDateTime(txtDataMovimento.Text).ToString("d") +
                        "' and id_produto = " + mov.IdProduto + " group by id_produto;";


                    BLLMovimento bllquantmov = new BLLMovimento(cx);
                    DataTable tabelamov = bllquantmov.LocalizarValor(buscaQuantMovimentacoes);

                    try
                    {
                        ultimosMovs = Convert.ToInt32(tabelamov.Rows[0]["quantidade"]);
                    }
                    catch
                    {
                        ultimosMovs = 0;
                    }

                    mov.QuantMov = quantInv - (ultimoInv + ultimosMovs);


                    //Buscar custo unitario da ultima movimentacao de entrada

                    string buscacusto = "select * from movimentacao " +
                        "where id_produto = " + mov.IdProduto + " order by data_mov desc;";

                    BLLMovimento bllCustotmov = new BLLMovimento(cx);
                    DataTable tabelacusto = bllCustotmov.LocalizarValor(buscacusto);
                    try
                    {
                        mov.CustoUnitMov = Convert.ToDouble(tabelacusto.Rows[0]["custo_unitario_mov"]);
                    }
                    catch
                    {
                        mov.CustoUnitMov = 0.00;
                    }
                    bllmov.Incluir(mov);

                }

                MessageBox.Show("Inventário processado com sucesso.");
                LimpaCampos();

                AlteraBotoes(1);

            }
        }

        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 6)
            {
                if (e.RowIndex >= 0)
                {

                    txtCodProdAdd.Text = dgvInventario.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtNomeProdutoAdd.Text = dgvInventario.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtMarcaProdutoAdd.Text = dgvInventario.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtModeloProdutoAdd.Text = dgvInventario.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtQuantProdutoAdd.Text = dgvInventario.Rows[e.RowIndex].Cells[5].Value.ToString();

                    dgvInventario.Rows.RemoveAt(e.RowIndex);

                }
            }

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            string IdProduto = "";
            string CodProduto = "";
            string NomeProduto = "";
            string MarcaProduto = "";
            string ModeloProduto = "";
            string QuantProduto = "";

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLProduto bll = new BLLProduto(cx);
            DataTable tabela = bll.LocalizarCod(txtCodProdAdd.Text.Trim().ToString());

            if (tabela.Rows.Count > 0)
            {

                IdProduto = Convert.ToInt32(tabela.Rows[0]["id_produto"]).ToString();
                CodProduto = tabela.Rows[0]["cod_produto"].ToString();
                NomeProduto = tabela.Rows[0]["nome_produto"].ToString();
                MarcaProduto = tabela.Rows[0]["marca_produto"].ToString();
                ModeloProduto = tabela.Rows[0]["modelo_produto"].ToString();
                QuantProduto = txtQuantProdutoAdd.Text;


                //verifica se já existe este produto no datagrid

                bool repetido = false;
                for (int i = 0; i < dgvInventario.RowCount; i++)
                {
                    if (dgvInventario.Rows[i].Cells[1].Value.ToString() == CodProduto)
                    {
                        repetido = true;
                    }

                }

                if (repetido == false)
                {

                    String[] P = new string[] { IdProduto, CodProduto, NomeProduto, MarcaProduto, ModeloProduto, QuantProduto, "" };
                    this.dgvInventario.Rows.Add(P);

                    this.LimpaCamposAdd();

                }
                else
                {
                    MessageBox.Show("Já existe um registro deste produto nesta tabela.");
                }

            }
            else
            {
                MessageBox.Show("Produto não encontrado;");
            }
        }


        #endregion

        #region Comandos

        private void Salvar()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

            DTOInventario rodainv = new DTOInventario();
            BLLInventario bllinv = new BLLInventario(cx);


            if (this.operacao != "Editar")
            {
                try
                {
                    SqlConnection con = new SqlConnection(DadosDaConexao.StringDaConexao.ToString()); // making connection   
                    SqlDataAdapter sda = new SqlDataAdapter("select max(inventario) from inventario", con);

                    DataTable dt = new DataTable(); //this is creating a virtual table  
                    sda.Fill(dt);

                    nrInventario = Convert.ToInt32(dt.Rows[0][0]);
                    nrInventario = nrInventario + 1;
                    txtNumeroInventario.Text = nrInventario.ToString("00000000");

                }
                catch
                {
                    txtNumeroInventario.Text = "00000001";
                }
            }

            for (int i = 0; i < dgvInventario.RowCount; i++)
            {

                rodainv.Inventario = Convert.ToInt32(txtNumeroInventario.Text);
                rodainv.DataCriacaoInventario = Convert.ToDateTime(txtDataInventario.Text);
                rodainv.DataMovInventario = Convert.ToDateTime(txtDataMovimento.Text);
                rodainv.IdUnidade = Convert.ToInt32(cbUnidade.SelectedValue);
                rodainv.IdProduto = Convert.ToInt32(dgvInventario.Rows[i].Cells[0].Value);

               try
                {
                    rodainv.QuantInv = Convert.ToInt32(dgvInventario.Rows[i].Cells[5].Value);
                }
                catch
                {
                    rodainv.QuantInv = 0;
                }


                if (cbTipoInv.Text == "Inventário")
                {
                    rodainv.Tipo = "C";
                }
                else
                {
                    rodainv.Tipo = "I";
                }



                rodainv.IdUsuario = Convert.ToInt32(idUsuario);
                rodainv.concluido = "A";

                    bllinv.Incluir(rodainv);
               
                }



            
        }

        private void Excluir(int inv)
        {


            if (this.operacao == "Editar")
            {

                try
                {
                        DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                        BLLInventario bll = new BLLInventario(cx);
                        bll.Excluir(Convert.ToInt32(txtNumeroInventario.Text));

                        this.Salvar();

                        MessageBox.Show("Inventário alterado com sucesso!");
                    
                }
                catch
                {
                    MessageBox.Show("Impossível editar o registro " + txtNumeroInventario.Text + ". \n Ele está sendo utilizado em outro local.");

                }

            }
            else
            {

                try
                {
                    

                        DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                        BLLInventario bll = new BLLInventario(cx);
                        bll.Excluir(Convert.ToInt32(txtNumeroInventario.Text));

                   
                }
                catch
                {
                    MessageBox.Show("Impossível excluir o registro " + txtNumeroInventario.Text + ". \n Ele está sendo utilizado em outro local.");

                }
            }

        }

        private void AlteraBotoes(int op)
        {
            btGerar.Enabled = false;
            btSalvar.Enabled = false;
            btRodar.Enabled = false;
            btImprimir.Enabled = false;
            btEditar.Enabled = false;
            btLocalizar.Enabled = false;
            btExcluir.Enabled = false;
            gbDadosInventario.Enabled = false;
            pnDados.Enabled = false;

            //Quando entrar no Inventário ou cancelar
            if(op == 1)
            {
                btGerar.Enabled = true;
                btLocalizar.Enabled = true;
                gbDadosInventario.Enabled = true;
                lbGrupo.Focus();
            }
            //Quando gerar um novo inventario
            else if (op == 2)
            {
                btGerar.Enabled = true;
                btImprimir.Enabled = true;
                btSalvar.Enabled = true;
                gbDadosInventario.Enabled = true;
                pnDados.Enabled = true;
                txtCodProdAdd.Focus();
            }
            //Quando salvar o inventario (ou voltar de uma consulta)
            else if(op == 3)
            {
                btRodar.Enabled = true;
                btLocalizar.Enabled = true;
                btEditar.Enabled = true;
                btExcluir.Enabled = true;
                    
            }
        }

        private void LimpaCampos()
        {
            txtNumeroInventario.Clear();

            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(idUsuario);

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUnidade bllun = new BLLUnidade(cx);
            cbUnidade.DataSource = bllun.Localizar("");
            cbUnidade.DisplayMember = "cod_unidade";
            cbUnidade.ValueMember = "id_unidade";
cbUnidade.Text = modelou.IdUnidade.ToString("00");

            unidade = modelou.IdUnidade;

            cbTipoInv.Text = "Inventário";

            if (modelou.PermissaoUsuario < 4)
            {

                cbUnidade.Enabled = false;
            }

            if (modelou.PermissaoUsuario < 3)
            {
                cbTipoInv.Enabled = false;

            }


            BLLGrupo bllg = new BLLGrupo(cx);
            lbGrupo.DataSource = bllg.LocalizarGrupo();
            lbGrupo.DisplayMember = "nome_grupo";

            DateTime Hoje = DateTime.Today;

            cbItensAContar.Text = "Somente Mix";

            txtDataInventario.Text = Hoje.ToString("d");
            txtDataMovimento.Text = Hoje.ToString("d");
            lbGrupo.ClearSelected();

            dgvInventario.Rows.Clear();
            

            txtAberto.Clear();
            this.operacao = "Incluir";

        }

        private void LimpaCamposAdd()
        {
            txtCodProdAdd.Clear();
            txtNomeProdutoAdd.Clear();
            txtMarcaProdutoAdd.Clear();
            txtModeloProdutoAdd.Clear();
            txtQuantProdutoAdd.Clear();
            txtCodProdAdd.Focus();
        }

        public class DeleteCell : DataGridViewButtonCell
        {
            Image del = Image.FromFile("Imagens\\Icones\\minus-3x.png");
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


        #endregion

        #region Imprimir

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            { 
    
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dgvInventario.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                            (double)iTotalWidth * (double)iTotalWidth *
                            ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                            GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headers
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dgvInventario.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dgvInventario.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allows more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString("Relatório de inventário",
                                new Font(dgvInventario.Font, FontStyle.Bold),
                                Brushes.Black, e.MarginBounds.Left,
                                e.MarginBounds.Top - e.Graphics.MeasureString("Relatório de inventário",
                                new Font(dgvInventario.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " +
                                DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate,
                                new Font(dgvInventario.Font, FontStyle.Bold), Brushes.Black,
                                e.MarginBounds.Left +
                                (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                                new Font(dgvInventario.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Width),
                                e.MarginBounds.Top - e.Graphics.MeasureString("Relatório de inventário",
                                new Font(new Font(dgvInventario.Font, FontStyle.Bold),
                                FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dgvInventario.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(),
                                    Cel.InheritedStyle.Font,
                                    new SolidBrush(Cel.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount],
                                    (float)iTopMargin,
                                    (int)arrColumnWidths[iCount], (float)iCellHeight),
                                    strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                (int)arrColumnWidths[iCount], iCellHeight));
                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }
                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
    catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
                try
                {
                    strFormat = new StringFormat();
                    strFormat.Alignment = StringAlignment.Near;
                    strFormat.LineAlignment = StringAlignment.Center;
                    strFormat.Trimming = StringTrimming.EllipsisCharacter;

                    arrColumnLefts.Clear();
                    arrColumnWidths.Clear();
                    iCellHeight = 0;
                    bFirstPage = true;
                    bNewPage = true;

                    // Calculating Total Widths
                    iTotalWidth = 0;
                    foreach (DataGridViewColumn dgvGridCol in dgvInventario.Columns)
                    {
                        iTotalWidth += dgvGridCol.Width;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        #endregion


    }
}
