using GUI.Code.BLL;
using GUI.Code.DAL;
using GUI.Code.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCadastroProduto : GUI.frmModeloFormularioDeCadastro
    {


        public string foto = "";
        public string NomeGrupo = "";
        private string NomeProdutoExcluido = "";
        private int IdUsuario = 0;
        private string IniciaisUsuario = "";
        private DateTime DataAtual;
        private string CodigoProdutoN;
        private bool alteraGrupo = false;
        private int grupoAtual;

        public frmCadastroProduto(int idUsuario)
        {

            IdUsuario = idUsuario;
            InitializeComponent();
        }
        DTOCaminhos mc = new DTOCaminhos();
        private void btInserir_Click(object sender, EventArgs e)
        {
            alteraBotoes(2);
            this.operacao = "inserir";
            cbAtivo.Checked = true;
            pbFotoProduto.Load(mc.Produtos+"0.jpg");

            txtNomeProduto.Select();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            {
                if (!(txtNomeProduto.Enabled) && txtNomeProduto.Text == "")
                {
                    this.Close();

                }
                else {
                    this.LimpaCampos();
                    this.alteraBotoes(1);
                }
            }
        }

        public void LimpaCampos()
        {
            txtNomeProduto.Clear();
            cbGrupo.Text = "";
            txtMarca.Clear();
            txtModelo.Clear();
            txtDesc.Clear();
            cbAtivo.Checked = false;
            this.foto = "";
            txtCodigo.Clear();
            
            pbFotoProduto.Image = null;
            
        }

        private void btCarrega_Click(object sender, EventArgs e)
        {
            
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            OpenFileDialog saveFileDialog1 = new OpenFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg";
            saveFileDialog1.Title = "Salvar uma imagem.";
            saveFileDialog1.ShowDialog();

            foto = saveFileDialog1.FileName;
            if (foto != "")
            {
                pbFotoProduto.Load(foto);
            }
            // If the file name is not an empty string open it for saving.
           
    }

        private void btDeleta_Click(object sender, EventArgs e)
        {
            DTOCaminhos mc = new DTOCaminhos();

            pbFotoProduto.Load(mc.Produtos + "0.jpg");
            foto = "del";

        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                //leitura dos dados
                DTOProduto modelo = new DTOProduto();
                modelo.NomeProduto = txtNomeProduto.Text;
                modelo.GrupoProduto = Convert.ToInt32(cbGrupo.SelectedValue);
                modelo.MarcaProduto = txtMarca.Text;
                modelo.ModelodoProduto = txtModelo.Text;
                modelo.UsuarioCriacaoProduto = Convert.ToInt32(IdUsuario);
                modelo.DataCriacaoProduto = DataAtual;


                if (cbAtivo.Checked)
                {
                    modelo.AtivoProduto = true;

                }
                else
                {
                    modelo.AtivoProduto = false;

                }

                modelo.DescProduto = txtDesc.Text;
                                               
               //conexão
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLProduto bll = new BLLProduto(cx);

                DALConexao cxg = new DALConexao(DadosDaConexao.StringDaConexao);

                BLLGrupo bllGCod = new BLLGrupo(cxg);

                DataTable tabela = bllGCod.LocalizarCod(Convert.ToInt32(cbGrupo.SelectedValue));


                string CodGrupo = tabela.Rows[0]["codigo_grupo"].ToString();


                if (this.operacao == "inserir")
                {

                    this.GeraCodigo(CodGrupo);

                    modelo.CodProduto = CodigoProdutoN;

                    bll.Incluir(modelo, foto);
                    
                    MessageBox.Show("Cadastro efetuado com sucesso. Produto: " + modelo.NomeProduto.ToString() + ", código "+CodigoProdutoN+".");
                    this.LimpaCampos();
                    this.alteraBotoes(1);
                }
                else
                {

                    if (alteraGrupo == true && grupoAtual != Convert.ToInt32(cbGrupo.SelectedValue))
                    {
                        this.GeraCodigo(CodGrupo);

                        modelo.CodProduto = CodigoProdutoN;
                    }else
                    {

                        modelo.CodProduto = txtCodigo.Text;

                    }

                    // altera produto
                    modelo.IdProduto = Convert.ToInt32(txtId.Text);
                    bll.Alterar(modelo, foto);
                    MessageBox.Show("Cadastro alterado com sucesso. Produto: " + txtNomeProduto.Text + ", código " + txtCodigo.Text + ".");
                    this.LimpaCampos();
                    this.alteraBotoes(1);
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            
            frmConsultaBasica_Produto f = new frmConsultaBasica_Produto(2, IdUsuario);
            f.ShowDialog();
            
            if (f.codigo != 0)
            {
                this.alteraBotoes(3);
                this.operacao = "alterar";

                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLProduto bll = new BLLProduto(cx);

                DTOProduto modelo = bll.CarregaModeloProduto(f.codigo);
                txtId.Text = modelo.IdProduto.ToString();
                txtNomeProduto.Text = modelo.NomeProduto.ToString();

                DALConexao cxg = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLGrupo bllg = new BLLGrupo(cxg);

                DTOGrupo modelog = bllg.CarregaModeloGrupo(modelo.GrupoProduto);

                grupoAtual = modelo.GrupoProduto;
                cbGrupo.Text = modelog.NomeGrupo.ToString();
                txtMarca.Text = modelo.MarcaProduto.ToString();
                txtModelo.Text = modelo.ModelodoProduto.ToString();
                txtCodigo.Text = modelo.CodProduto.ToString();

                DTOCaminhos mc = new DTOCaminhos();

                try {
                    pbFotoProduto.Load(mc.Produtos + modelo.IdProduto.ToString() + ".jpg");
                }
                catch
                {
                    pbFotoProduto.Load(mc.Produtos+"0.jpg");

                }
                if (modelo.AtivoProduto)
                {
                    cbAtivo.Checked = true;
                }
                else
                {
                    cbAtivo.Checked = false;
                }
                txtDesc.Text = modelo.DescProduto.ToString();

            }
            else {
                this.LimpaCampos();
                this.alteraBotoes(1);
            }

            f.Dispose();

        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja realmente excluir o registo - " + txtNomeProduto.Text + "?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    pbFotoProduto.Dispose();
                    pbFotoProduto.Refresh();
                    NomeProdutoExcluido = txtNomeProduto.Text;
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLProduto bll = new BLLProduto(cx);
                    bll.Excluir(Convert.ToInt32(txtId.Text));

                    MessageBox.Show("Registro "+NomeProdutoExcluido+" excluído com sucesso.");
                    NomeProdutoExcluido = "";
                    this.LimpaCampos();
                    this.alteraBotoes(1);
                }
            }
            catch
            {
                MessageBox.Show("Impossível excluir o registro "+txtNomeProduto.Text+". \n Ele está sendo utilizado em outro local.");
                this.alteraBotoes(3);
            }

        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            alteraBotoes(2);
            this.operacao = "alterar";

        }

        private void frmCadastroProduto_Load(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLGrupo bll = new BLLGrupo(cx);
            cbGrupo.DataSource = bll.Localizar("");
            cbGrupo.DisplayMember = "nome_grupo";
            cbGrupo.ValueMember = "id_grupo";
            cbGrupo.Text = "";
            


            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(IdUsuario);

           
            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";

            IniciaisUsuario = modelou.IniciaisUsuario.ToString();
            DataAtual = DateTime.Today;




        }

        private void GeraCodigo(string CodGrupo)
        {

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLProduto bllCod = new BLLProduto(cx);

            DataTable tabela = bllCod.LocalizarGeraCod(CodGrupo);

            //Prefixo
            string prefixo = Convert.ToInt32(CodGrupo).ToString("00")+".";

            
           // Preenche produtos
           for (int i = 0; i < tabela.Rows.Count+1; i++)
            {

                try
                {

                CodigoProdutoN = prefixo + (i + 1).ToString("0000");
                string CodigoProdutoE = tabela.Rows[i]["cod_produto"].ToString();

                
                    if (CodigoProdutoN != CodigoProdutoE)
                    {
                        i = tabela.Rows.Count + 1;
                    }
                }
                catch
                {
                    
                    i = tabela.Rows.Count + 1;
                }
               
            }

            
        }

        private void cbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.alteraGrupo = true;
        }

        private void cbGrupo_Leave(object sender, EventArgs e)
        {
            cbGrupo.Text = cbGrupo.Text.ToUpper();

            if (alteraGrupo == true)
            {
                
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLGrupo bllgr = new BLLGrupo(cx);

                DTOGrupo modelo = bllgr.CarregaModeloGrupo(Convert.ToInt32(cbGrupo.SelectedValue));

                if (modelo.NomeGrupo == null)
                {
                    MessageBox.Show("Selecione um grupo válido.");
                    cbGrupo.Text = "";

                    cbGrupo.Focus();
                }

                

            }

        }
    }


}
