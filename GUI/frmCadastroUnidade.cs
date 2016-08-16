using GUI.Code.DAL;
using GUI.Code.BLL;
using GUI.Code.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCadastroUnidade : GUI.frmModeloFormularioDeCadastro
    {
        public string foto = "";
        string folder = @"Imagens\Unidades\";
        public frmCadastroUnidade()
        {
            InitializeComponent();
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            alteraBotoes(2);
            this.operacao = "inserir";
            txtNomeUnidade.Select();

        }

        private void frmCadastroUnidade_Load(object sender, EventArgs e)
        {
            alteraBotoes(1);
            txtNomeUnidade.GotFocus += TxtNome_GotFocus;
            txtCodUnidade.GotFocus += TxtCod_GotFocus;

            

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            if (!(txtNomeUnidade.Enabled) && txtNomeUnidade.Text == "")
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
            txtNomeUnidade.Clear();
            txtCodUnidade.Clear();
            foto = "";
            pbLogo.Image = null;
            
        }
       
        void TxtNome_GotFocus(object sender, EventArgs e)
        {
            txtNomeUnidade.SelectAll();
        }

        void TxtCod_GotFocus(object sender, EventArgs e)
        {
            txtCodUnidade.SelectAll();
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            alteraBotoes(2);
            this.operacao = "alterar";
        }

        private void btCarrega_Click(object sender, EventArgs e)
        {
            OpenFileDialog odg = new OpenFileDialog();


            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            OpenFileDialog saveFileDialog1 = new OpenFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg";
            saveFileDialog1.Title = "Salvar uma imagem.";
            saveFileDialog1.ShowDialog();

            foto = saveFileDialog1.FileName;
            pbLogo.Load(foto);
            // If the file name is not an empty string open it for saving.


        }

        private void BtDeleta_Click(object sender, EventArgs e)
        {

            pbLogo.Load(folder + "0.jpg");
            foto = "";
            
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                //leitura dos dados
                DTOUnidade modelo = new DTOUnidade();
                modelo.NomeUnidade = txtNomeUnidade.Text;
                modelo.CodUnidade = Convert.ToString(txtCodUnidade.Text);

                //conexão
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLUnidade bll = new BLLUnidade(cx);

                if (this.operacao == "inserir")
                {
                    // cadastra fornecedor
                    bll.Incluir(modelo, foto);
                    MessageBox.Show("Cadastro efetuado com sucesso. Unidade: " + modelo.NomeUnidade.ToString() + ".");
                    this.LimpaCampos();
                    this.alteraBotoes(1);
                }
                else
                {
                    // altera fornecedor
                    modelo.IdUnidade = Convert.ToInt32(txtIdUnidade.Text);
                    bll.Alterar(modelo, foto);
                    MessageBox.Show("Cadastro alterado com sucesso. Unidade: " + modelo.NomeUnidade.ToString() + ".");
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
            frmConsultaUnidade fc = new frmConsultaUnidade();
            fc.ShowDialog();
                       

            if (fc.codigo != 0)
            {
                this.alteraBotoes(3);
                this.operacao = "alterar";

                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLUnidade bll = new BLLUnidade(cx);

                DTOUnidade modelo = bll.CarregaModeloUnidade(fc.codigo);
                txtIdUnidade.Text = modelo.IdUnidade.ToString();
                txtNomeUnidade.Text = modelo.NomeUnidade.ToString();
                txtCodUnidade.Text = modelo.CodUnidade.ToString();
                try
                {
                    pbLogo.Load(folder + modelo.IdUnidade.ToString() + ".jpg");
                }
                catch
                {
                    pbLogo.Load(folder+"0.jpg");

                }

            }
            else {
                this.LimpaCampos();
                this.alteraBotoes(1);
            }


            fc.Dispose();

        }

        private void btExcluir_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult d = MessageBox.Show("Deseja realmente excluir o registo - " + txtNomeUnidade.Text + "?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLUnidade bll = new BLLUnidade(cx);
                    bll.Excluir(Convert.ToInt32(txtIdUnidade.Text));
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
