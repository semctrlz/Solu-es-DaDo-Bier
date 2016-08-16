using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GUI.Code.DTO;
using GUI.Code.DAL;
using GUI.Code.BLL;

namespace GUI
{
    public partial class frmCadastroFornecedores : GUI.frmModeloFormularioDeCadastro
    {
        int idUsuario;
        public frmCadastroFornecedores(int usuario)
        {
            idUsuario = usuario;
            InitializeComponent();
           
        }

        private void frmCadastroFornecedores_Load(object sender, EventArgs e)
        {


            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(idUsuario);

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";
            

            this.alteraBotoes(1);
            txtFantasia.GotFocus += txtFantasia_GotFocus;
            txtRazao.GotFocus += txtRazao_GotFocus;
            txtFone1.GotFocus += txtFone1_GotFocus;
            txtFone2.GotFocus += txtFone2_GotFocus;
            txtEmail1.GotFocus += txtEmail1_GotFocus;
            txtEmail2.GotFocus += txtEmail2_GotFocus;
            txtContato.GotFocus += txtContato_GotFocus;
            txtCnpj.GotFocus += txtCnpj_GotFocus;
            txtCep.GotFocus += txtCep_GotFocus;
            txtLogradouro.GotFocus += txtLogradouro_GotFocus;
            txtNumero.GotFocus += txtNumero_GotFocus;
            txtComplemento.GotFocus += txtComplemento_GotFocus;
            txtBairro.GotFocus += txtBairro_GotFocus;
            txtCidade.GotFocus += txtCidade_GotFocus;
            txtEstado.GotFocus += txtEstado_GotFocus;


        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            this.operacao = "inserir";
            this.alteraBotoes(2);
            txtFantasia.Select();
        }

        private void btCep_Click(object sender, EventArgs e)
        {


            string urlconsulta = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml";
            DataSet dsRetornoEndereco = new DataSet();
            dsRetornoEndereco.ReadXml(urlconsulta.Replace("@cep", txtCep.Text.Replace("-", "")));
            string retorno = dsRetornoEndereco.Tables[0].Rows[0]["resultado"].ToString();

            if (retorno == "0")
            {
                MessageBox.Show("CEP inválido.");
                txtLogradouro.Text = "";
                txtBairro.Text = "";
                txtCidade.Text = "";
                txtEstado.Text = "";
                txtCep.Text = "";
            }

            else
            {
                txtLogradouro.Text = dsRetornoEndereco.Tables[0].Rows[0]["tipo_logradouro"].ToString().ToUpper() + " " + dsRetornoEndereco.Tables[0].Rows[0]["logradouro"].ToString().ToUpper();
                txtBairro.Text = dsRetornoEndereco.Tables[0].Rows[0]["bairro"].ToString().ToUpper();
                txtCidade.Text = dsRetornoEndereco.Tables[0].Rows[0]["cidade"].ToString().ToUpper();
                txtEstado.Text = dsRetornoEndereco.Tables[0].Rows[0]["uf"].ToString().ToUpper();

            }



        }

        void txtFantasia_GotFocus(object sender, EventArgs e)
        {
            txtFantasia.SelectAll();
        }
        void txtRazao_GotFocus(object sender, EventArgs e)
        {
            txtRazao.SelectAll();
        }
        void txtFone1_GotFocus(object sender, EventArgs e)
        {
            txtFone1.SelectAll();
        }
        void txtFone2_GotFocus(object sender, EventArgs e)
        {
            txtFone2.SelectAll();
        }
        void txtEmail1_GotFocus(object sender, EventArgs e)
        {
            txtEmail1.SelectAll();
        }
        void txtEmail2_GotFocus(object sender, EventArgs e)
        {
            txtEmail2.SelectAll();
        }
        void txtContato_GotFocus(object sender, EventArgs e)
        {
            txtContato.SelectAll();
        }
        void txtCnpj_GotFocus(object sender, EventArgs e)
        {
            txtCnpj.SelectAll();
        }
        void txtCep_GotFocus(object sender, EventArgs e)
        {
            txtCep.SelectAll();
        }
        void txtLogradouro_GotFocus(object sender, EventArgs e)
        {
            txtLogradouro.SelectAll();
        }
        void txtNumero_GotFocus(object sender, EventArgs e)
        {
            txtNumero.SelectAll();
        }
        void txtComplemento_GotFocus(object sender, EventArgs e)
        {
            txtComplemento.SelectAll();
        }
        void txtBairro_GotFocus(object sender, EventArgs e)
        {
            txtBairro.SelectAll();
        }
        void txtCidade_GotFocus(object sender, EventArgs e)
        {
            txtCidade.SelectAll();
        }
        void txtEstado_GotFocus(object sender, EventArgs e)
        {
            txtEstado.SelectAll();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            if (!(txtRazao.Enabled) && txtRazao.Text == "")
            {
                this.Close();
            }
            else {
                this.LimpaCampos();
                this.alteraBotoes(1);
            }
        }

        public void LimpaCampos()
        {
            txtFantasia.Clear();
            txtRazao.Clear();
            txtFone1.Clear();
            txtFone2.Clear();
            txtEmail1.Clear();
            txtEmail2.Clear();
            txtContato.Clear();
            txtCnpj.Clear();
            txtCep.Clear();
            txtLogradouro.Clear();
            txtNumero.Clear();
            txtComplemento.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {

            try
            {
                //leitura dos dados
                DTOFornecedor modelo = new DTOFornecedor();
                modelo.FantasiaFornecedor = txtFantasia.Text;
                modelo.RazaoFornecedor = txtRazao.Text;
                modelo.Fone1Fornecedor = txtFone1.Text;
                modelo.Fone2Fornecedor = txtFone2.Text;
                modelo.Email1Fornecedor = txtEmail1.Text;
                modelo.Email2Fornecedor = txtEmail2.Text;
                modelo.ContatoFornecedor = txtContato.Text;
                modelo.CnpjFornecedor = txtCnpj.Text;
                modelo.EnderecoCepFornecedor = txtCep.Text;
                modelo.EnderecoLogradouroFornecedor = txtLogradouro.Text;
                modelo.EnderecoNumeroFornecedor = txtNumero.Text;
                modelo.EnderecoComplementoFornecedor = txtComplemento.Text;
                modelo.EnderecoBairroFornecedor = txtBairro.Text;
                modelo.EnderecoCidadeFornecedor = txtCidade.Text;
                modelo.EnderecoEstadoFornecedor = txtEstado.Text;
                //conexão
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLFornecedor bll = new BLLFornecedor(cx);

                if (this.operacao == "inserir")
                {
                    // cadastra fornecedor
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado com sucesso. Razão Social: " + modelo.RazaoFornecedor.ToString()+".");
                    this.LimpaCampos();
                    this.alteraBotoes(1);
                }
                else
                {
                    // altera fornecedor
                    modelo.IdFornecedor = Convert.ToInt32(txtcodigo.Text);
                    bll.Alterar(modelo);
                    MessageBox.Show("Cadastro alterado com sucesso. Razão Social: " + modelo.RazaoFornecedor.ToString() + ".");
                    this.LimpaCampos();
                    this.alteraBotoes(1);
                }

            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

            }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            frmConsultaFornecedor fc = new frmConsultaFornecedor(idUsuario);
            fc.ShowDialog();

            if (fc.codigo != 0)
            {
                this.alteraBotoes(3);
                this.operacao = "alterar";

                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLFornecedor bll = new BLLFornecedor(cx);

                DTOFornecedor modelo = bll.CarregaModeloFornecedor(fc.codigo);
                txtcodigo.Text = modelo.IdFornecedor.ToString();
                txtFantasia.Text = modelo.FantasiaFornecedor.ToString();
                txtRazao.Text = modelo.RazaoFornecedor.ToString();
                txtFone1.Text = modelo.Fone1Fornecedor.ToString();
                txtFone2.Text = modelo.Fone2Fornecedor.ToString();
                txtEmail1.Text = modelo.Email1Fornecedor.ToString();
                txtEmail2.Text = modelo.Email2Fornecedor.ToString();
                txtContato.Text = modelo.ContatoFornecedor.ToString();
                txtCnpj.Text = modelo.CnpjFornecedor.ToString();
                txtCep.Text = modelo.EnderecoCepFornecedor.ToString();
                txtLogradouro.Text = modelo.EnderecoLogradouroFornecedor.ToString();
                txtNumero.Text = modelo.EnderecoNumeroFornecedor.ToString();
                txtComplemento.Text = modelo.EnderecoComplementoFornecedor.ToString();
                txtBairro.Text = modelo.EnderecoBairroFornecedor.ToString();
                txtCidade.Text = modelo.EnderecoCidadeFornecedor.ToString();
                txtEstado.Text = modelo.EnderecoEstadoFornecedor.ToString();

            }
            else {
                this.LimpaCampos();
                this.alteraBotoes(1);
            }

            fc.Dispose();

        }
        
        private void btAlterar_Click(object sender, EventArgs e)
        {
            this.alteraBotoes(2);

        }

        private void btExcluir_Click(object sender, EventArgs e)
        {



            try
            {
                DialogResult d = MessageBox.Show("Deseja realmente excluir o registo - " + txtFantasia.Text + "?", "Aviso", MessageBoxButtons.YesNo);
                if(d.ToString() == "Yes")
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLFornecedor bll = new BLLFornecedor(cx);
                    bll.Excluir(Convert.ToInt32(txtcodigo.Text));
                    this.LimpaCampos();
                    this.alteraBotoes(1);
                }
            }
            catch
            {
                MessageBox.Show("Impossível excluir o registro. \n O registro está sendo utilizado em outro local.");
                this.alteraBotoes(3);
            }

        }
    }

}
