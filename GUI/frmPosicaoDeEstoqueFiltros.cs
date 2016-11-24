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
    public partial class frmPosicaoDeEstoqueFiltros : Form
    {

        #region Variáveis
        int idUsuario = 0;
        bool initial = true;
        bool liberado = false;
        #endregion

        #region Inicialização

        public frmPosicaoDeEstoqueFiltros(int id)
        {
            idUsuario = id;
            
            InitializeComponent();
        }

        private void frmPosicaoDeEstoqueFiltros_Load(object sender, EventArgs e)
        {
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(idUsuario);

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";

            this.LimparTela();


        }

        #endregion

        #region Voids/Class

        private void LimparTela()
        {
            this.liberado = false;

            DateTime Hoje = DateTime.Today;
            
            txtData.Text = Hoje.ToString("d");

            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(idUsuario);

            BLLUnidade bllun = new BLLUnidade(con);
            cbUnidade.DataSource = bllun.Localizar("");
            cbUnidade.DisplayMember = "cod_unidade";
            cbUnidade.ValueMember = "id_unidade";
            lbNomeProduto.Text = "";
cbUnidade.Text = modelou.IdUnidade.ToString("00");
            
            BLLGrupo bllg = new BLLGrupo(con);
            listGrupo.DataSource = bllg.LocalizarGrupo();
            listGrupo.DisplayMember = "nome_grupo";
            listGrupo.ClearSelected();

            numQuant.Value = 1;
            txtCodProdAdd.Clear();

            
            //limpa

            this.initial = true;

            this.liberado = true;
            
        }


        #endregion

        #region Leave/Enter/Focus

        private void cbUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.liberado)
            {
                this.initial = false;
               
            }
        }

        private void txtCodProdAdd_Leave(object sender, EventArgs e)
        {
            if(txtCodProdAdd.Text.Trim() != ".")
            {
                if (this.liberado)
                {

                    //Busca nome do produto no Bd

                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLProduto bll = new BLLProduto(cx);
                    DataTable tabela = bll.LocalizarCod(txtCodProdAdd.Text.Trim().ToString());

                    if (tabela.Rows.Count > 0)
                    {

                        txtCodProdAdd.Text = tabela.Rows[0]["cod_produto"].ToString();
                        lbNomeProduto.Text = tabela.Rows[0]["nome_produto"].ToString();
                        this.initial = false;

                    }
                    else
                    {
                        MessageBox.Show("Código de produto inválido.");

                        txtCodProdAdd.Focus();
                        
                    }




                    
                                        
                }
            }
        }

        private void txtData_Leave(object sender, EventArgs e)
        {
            if (txtData.Text.Trim() != "/  /")
            {
                if (this.liberado)
                {
                    this.initial = false;
                    
                    DateTime resultado = DateTime.MinValue;
                    if (DateTime.TryParse(this.txtData.Text.Trim(), out resultado))
                    {

                        txtData.Text = resultado.ToString("d");
                        
                    }

                    else
                    {
                        if (txtData.Text.Trim() != "/  /")
                        {
                            MessageBox.Show("Data inválida.");
                            txtData.Focus();
                        }
                    }

                }
            }
        }

        private void listGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.initial = false;
        }

        private void numQuant_ValueChanged(object sender, EventArgs e)
        {
            this.initial = false;
        }

        private void cbUnidade_Enter(object sender, EventArgs e)
        {
            ((ComboBox)sender).SelectAll();
        }

        private void txtCodProdAdd_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () {
                txtCodProdAdd.SelectAll();
            });
        }

        private void txtData_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () {
                txtData.SelectAll();
            });
        }

        private void numQuant_Enter(object sender, EventArgs e)
        {
            numQuant.Select(0, numQuant.Text.Length);
        }

        private void cbGrupos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGrupos.Checked)
            {
                for (int i = 0; i < listGrupo.Items.Count; i++)
                {
                    listGrupo.SetSelected(i, true);
                }
            }
            else
            {
                listGrupo.ClearSelected();
            }
        }


        #endregion

        #region Click
        
        private void btCancelar_Click(object sender, EventArgs e)
        {
            if (this.initial)
            {
                this.Close();
            }
            else
            {
                this.LimparTela();
            }
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            String grupo = "";

            if (listGrupo.SelectedItems.Count > 0 || txtCodProdAdd.Text.Trim() != ".")
            {
                // gera consulta e abre página do relatório


                string prefix = "";
                int quantFiltros = 0;

                foreach (object element in listGrupo.SelectedItems)
                {
                    if (quantFiltros > 0)
                    {
                        prefix = " or ";
                    }
                    DataRowView row = (DataRowView)element;
                    grupo = grupo + prefix + " p.id_grupo = " + row[0].ToString();

                    quantFiltros++;
                }


                int unidade = Convert.ToInt32(cbUnidade.SelectedValue);
                DateTime Data = Convert.ToDateTime(txtData.Text);
                int Quant = Convert.ToInt32(numQuant.Value);
                string Produto = txtCodProdAdd.Text;


                frmPosicaoDeEstoqueDados f = new frmPosicaoDeEstoqueDados(unidade, Data, Quant, Produto, grupo, idUsuario);
                f.ShowDialog();
                f.Dispose();
            }else
            {

            MessageBox.Show("Para realizar esta consulta selecione ao menos um grupo ou digite um código de produto válido.", "Aviso");

            }
            
        }

        #endregion

        #region Key Press/Key Down

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
                    lbNomeProduto.Text = modelo.NomeProduto.ToString();
                    
                    txtCodProdAdd.Focus();

                }
                else
                {

                }

                f.Dispose();
            }
        }

        #endregion

    }
}
