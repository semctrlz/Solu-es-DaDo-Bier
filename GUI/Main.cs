
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Code.BLL;
using GUI.Code.DAL;
using GUI.Code.DTO;
using GUI.CMV;

namespace GUI
{
    public partial class Main : Form
    {
        #region Variáveis
        
        public string Caminho = "Arquivos\\";
        public string CaminhoLog = "Arquivos\\Log.txt";
        
        #endregion

        #region Inicialização

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Verifica se não existe login automático

            try
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

                DALUsuario usuario = new DALUsuario(cx);
                BLLUsuario bllu = new BLLUsuario(cx);

                DataTable dt = bllu.LocalizarIp(bllu.IpLocal());
                
                if (dt.Rows[0][0].ToString() == "1")
                {
                    txtId.Text = Convert.ToString(dt.Rows[0][1]);
                    txtUsuario.Text = Convert.ToString(dt.Rows[0][2]);
                    txtLogin.Text = Convert.ToString(dt.Rows[0][3]);
                    txtSenha.Text = Convert.ToString(dt.Rows[0][4]);
                    txtIniciais.Text = Convert.ToString(dt.Rows[0][5]);
                    txtUnidade.Text = Convert.ToString(dt.Rows[0][6]);
                    txtPermissao.Text = Convert.ToString(dt.Rows[0][7]);
                    txtEmail.Text = Convert.ToString(dt.Rows[0][8]);
                    txtNomeUnidade.Text = Convert.ToString(dt.Rows[0][9]);
                    
                    this.PreencheCampos();                    
                }
            }
            catch
            {
                this.Loga();
            }
        }

        #endregion

        #region Comandos

        private void Loga()
        {

            this.BloqueioTela(Convert.ToInt32(0));
            frmLogin log = new frmLogin();
            log.ShowDialog();
            log.Dispose();


            int idusuario = 0;
            int idunidade = 0;
            int nvusuario = 0;

            try
            {
               idusuario =  Convert.ToInt32(log.IdUsuarioLogado);
            }
            catch { }

            try
            {
                idunidade = Convert.ToInt32(log.UnidadeUsuarioLogado);
            }
            catch { }

            try
            {
                nvusuario = Convert.ToInt32(log.NvUsuarioLogado);
            }
            catch { }

            if (idusuario.ToString() != "")
            {
                #region Se Login Adm
                if (log.IdUsuarioLogado == -1)
                {
                    txtId.Text = idusuario.ToString();
                    txtUsuario.Text = "Administrador";
                    txtLogin.Text = "Admin";
                    txtSenha.Text = "";
                    txtIniciais.Text = "Adm";
                    txtUnidade.Text = "99";
                    txtPermissao.Text = "4";
                    txtEmail.Text = "";
                    txtNomeUnidade.Text = "Admin";

                    this.PreencheCampos();
                    
                }

                #endregion

                #region Se login normal

                else
                {
                    txtId.Text = idusuario.ToString();
                    txtUsuario.Text = log.NomeUsuarioLogado.ToString();
                    txtLogin.Text = log.LoginUsuarioLogado.ToString();
                    txtSenha.Text = log.SenhaUsuarioLogado.ToString();
                    txtIniciais.Text = log.IniciaisUsuarioLogado.ToString();
                    txtUnidade.Text = idunidade.ToString();
                    txtPermissao.Text = nvusuario.ToString();
                    txtEmail.Text = log.EmailUsuarioLogado.ToString();
                    txtNomeUnidade.Text = log.NomeUnidade.ToString();

                    this.PreencheCampos();

                    //Se login automático salva ip
                    DTOLog dtolog = new DTOLog();
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLLog blllog = new BLLLog(cx);
                                        
                    if (log.LembrarSenha != "")
                    {
                        try
                        {

                            try
                            {
                                blllog.excluir(Convert.ToInt32(txtId.Text), log.LembrarSenha);

                            }
                            catch
                            {}
                            finally
                            {

                                dtolog.IdUsuario = Convert.ToInt32(txtId.Text);
                                dtolog.CodLog = log.LembrarSenha;
                                blllog.Incluir(dtolog);

                            }

                        }
                        catch
                        {
                            MessageBox.Show("Erro ao salvar suas credenciais.");
                        }                   
                    }                    
                }
                #endregion

                log = null;
            }
        }
        
        private void PreencheCampos()
        {
            string AcessoUsuario = "";

            //Altera o titulo do Form

            this.Text += $" - {txtLogin.Text} ({txtIniciais.Text})";

            

            this.BloqueioTela(Convert.ToInt32(txtPermissao.Text));

            this.LimpaTela(Convert.ToInt32(txtPermissao.Text));

            if(Convert.ToInt32(txtPermissao.Text) == 1)
            {
                AcessoUsuario = "Visualizador";
            }

            else if(Convert.ToInt32(txtPermissao.Text) == 2)
            {
                AcessoUsuario = "Operador";
            }

            else if (Convert.ToInt32(txtPermissao.Text) == 3)
            {
                AcessoUsuario = "Líder";
            }

            else if (Convert.ToInt32(txtPermissao.Text) >= 4)
            {
                AcessoUsuario = "Administrador";
            }
            
            if(Convert.ToInt32(txtPermissao.Text) == -1)
            {
                lbUsuarioLogado.Text = AcessoUsuario + ": Admin ( 99 ) - ADM";
            }
            else
            {
            lbUsuarioLogado.Text = txtUsuario.Text + " (" + txtIniciais.Text + ") - " + txtNomeUnidade.Text + " - "+ AcessoUsuario.ToUpper();
            }

            DTOCaminhos dt = new DTOCaminhos();

            if (File.Exists(dt.Wallpaper + txtId.Text + ".jpg"))
            {
                pbWallpaper.Load(dt.Wallpaper + txtId.Text + ".jpg");
            }
            else
            {
                try
                {
                    pbWallpaper.Load(dt.Wallpaper + "default.jpg");
                }
                catch
                {

                }

            }

            AcessoUsuario = null;
        }
        
        private void BloqueioTela(int acesso)
        {
            if(acesso == 0)
            {
                this.LimpaTela(0);
                
            }
            if (acesso == 1)
            {
                this.LimpaTela(1);
                //Libera todos os menus
                
                admnistradorToolStripMenuItem.Enabled = true;
                movimentoToolStripMenuItem.Enabled = true;
                arquivoToolStripMenuItem.Enabled = true;
                consultaToolStripMenuItem.Enabled = true;
                relatóriosToolStripMenuItem.Enabled = true;
                ajudaToolStripMenuItem.Enabled = true;
                admnistradorToolStripMenuItem.Enabled = true;

                //Desabilita alguns
                
                admnistradorToolStripMenuItem.Enabled = false;
                movimentoToolStripMenuItem.Enabled = false;
                cadastrosToolStripMenuItem1.Enabled = false;
                suprirDadosToolStripMenuItem.Enabled = false;
                cadastroToolStripMenuItem1.Enabled = false;
                configuraçõesToolStripMenuItem1.Enabled = false;


            }
            else if(acesso == 2)
            {
                this.LimpaTela(1);
                //Libera todos os menus
                
                admnistradorToolStripMenuItem.Enabled = true;
                movimentoToolStripMenuItem.Enabled = true;
                arquivoToolStripMenuItem.Enabled = true;
                consultaToolStripMenuItem.Enabled = true;
                relatóriosToolStripMenuItem.Enabled = true;
                ajudaToolStripMenuItem.Enabled = true;
                admnistradorToolStripMenuItem.Enabled = true;

                //Desabilita alguns
                //cadastroToolStripMenuItem.Enabled = false;
                admnistradorToolStripMenuItem.Enabled = false;
                cadastrosToolStripMenuItem1.Enabled = false;
                suprirDadosToolStripMenuItem.Enabled = false;
                cadastroToolStripMenuItem1.Enabled = false;
                configuraçõesToolStripMenuItem1.Enabled = false;
            }

            else if (acesso == 3)
            {
                this.LimpaTela(1);
                //Libera todos os menus
                //cadastroToolStripMenuItem.Enabled = true;
                admnistradorToolStripMenuItem.Enabled = true;
                movimentoToolStripMenuItem.Enabled = true;
                arquivoToolStripMenuItem.Enabled = true;
                consultaToolStripMenuItem.Enabled = true;
                relatóriosToolStripMenuItem.Enabled = true;
                ajudaToolStripMenuItem.Enabled = true;
                admnistradorToolStripMenuItem.Enabled = true;
                cadastrosToolStripMenuItem1.Enabled = true;
                //Desabilita alguns
                admnistradorToolStripMenuItem.Enabled = false;
            }
            else if (acesso == 4)
            {
                this.LimpaTela(1);
                //Libera todos os menus
                //cadastroToolStripMenuItem.Enabled = true;
                admnistradorToolStripMenuItem.Enabled = true;
                movimentoToolStripMenuItem.Enabled = true;
                arquivoToolStripMenuItem.Enabled = true;
                consultaToolStripMenuItem.Enabled = true;
                relatóriosToolStripMenuItem.Enabled = true;
                ajudaToolStripMenuItem.Enabled = true;
                admnistradorToolStripMenuItem.Enabled = true;
                cadastrosToolStripMenuItem1.Enabled = true;
            }
        }

        private void LimpaTela(int nivel)
        {

            if (nivel == 0)
            {
                
                lbUsuarioLogado.Visible = false;
                //pbLogoUnidade.Visible = false;
                msMain.Visible = false;
            }
            else
            {
                
                lbUsuarioLogado.Visible = true;
                //pbLogoUnidade.Visible = true;
                msMain.Visible = true;

            }

        }

        #endregion

        #region Botões do menu

        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Soluções DaDo Bier";

            this.BloqueioTela(0);

            lbUsuarioLogado.Text = "Usuario";

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(cx);
            BLLLog blllog = new BLLLog(cx);
            blllog.excluir(Convert.ToInt32(txtId.Text), bllu.IpLocal());
            
            this.Loga();

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void unidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroUnidade u = new frmCadastroUnidade();

            u.ShowDialog();
            u.Dispose();
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroUsuario u = new frmCadastroUsuario();

            u.ShowDialog();
            u.Dispose();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroProduto f = new frmCadastroProduto(Convert.ToInt32(txtId.Text));


            f.ShowDialog();
            f.Dispose();
        }

       

        private void alterarSenhaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(txtId.Text) != -1)
            {
                frmAlteraSenha f = new frmAlteraSenha(Convert.ToInt32(txtId.Text), txtUsuario.Text, txtLogin.Text, txtIniciais.Text);

                f.ShowDialog();

                f.Dispose();
            }
            else
            {
                MessageBox.Show("O usuário chave não pode ter a senha alterada.");
            }

        }

        private void grupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroCategoria f = new frmCadastroCategoria();
            f.ShowDialog();
            f.Dispose();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaBasica_Produto f = new frmConsultaBasica_Produto(0, Convert.ToInt32(txtId.Text));
            f.ShowDialog();
            f.Dispose();
        }

        private void referênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroSetor f = new frmCadastroSetor(Convert.ToInt32(txtId.Text));
            f.ShowDialog();
            f.Dispose();
        }

        private void mixDaUnidadeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCadastroMixUnidade f = new frmCadastroMixUnidade(Convert.ToInt32(txtId.Text));
            f.ShowDialog();
            f.Dispose();
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEntrada f = new frmEntrada(Convert.ToInt32(txtId.Text));
            f.ShowDialog();
            f.Dispose();
        }

        private void inventárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventario f = new frmInventario(Convert.ToInt32(txtId.Text));
            f.ShowDialog();
            f.Dispose();
        }

        private void backupsDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackups f = new frmBackups(Convert.ToInt32(txtId.Text));
            f.ShowDialog();
            f.Dispose();
        }

        private void posiçãoDeEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPosicaoDeEstoqueFiltros f = new frmPosicaoDeEstoqueFiltros(Convert.ToInt32(txtId.Text));
            f.ShowDialog();
            f.Dispose();
        }

        #endregion

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaFornecedor f = new frmConsultaFornecedor(Convert.ToInt32(txtId.Text));
            f.ShowDialog();
            f.Dispose();
        }

        private void movimentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmConsultaMovimento f = new frmConsultaMovimento(Convert.ToInt32(txtId.Text));
            f.ShowDialog();
            f.Dispose();
        }

        private void dadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.CMV.frmCMVSecoes fs = new Forms.CMV.frmCMVSecoes(Convert.ToUInt32(Convert.ToInt32(txtId.Text)));
            this.Hide();
            fs.ShowDialog();
            this.Show();
            fs.Dispose();
        }
        
        #region Menu / Materiais / Cadastros

        private void produtoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCadastroProduto f = new frmCadastroProduto(Convert.ToInt32(txtId.Text));


            f.ShowDialog();
            f.Dispose();
        }

        private void fornecedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCadastroFornecedores f = new frmCadastroFornecedores(Convert.ToInt32(txtId.Text));
            
            f.ShowDialog();
            f.Dispose();
        }

        private void setorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroSetor f = new frmCadastroSetor(Convert.ToInt32(txtId.Text));
            f.ShowDialog();
            f.Dispose();
        }

        private void mixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroMixUnidade f = new frmCadastroMixUnidade(Convert.ToInt32(txtId.Text));
            f.ShowDialog();
            f.Dispose();
        }

        private void backupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackups f = new frmBackups(Convert.ToInt32(txtId.Text));
            f.ShowDialog();
            f.Dispose();
        }

        #endregion

        private void configuraçõesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCmvConfig f = new frmCmvConfig(Convert.ToInt32(txtId.Text));
            this.Hide();
            f.ShowDialog();
            this.Show();
            f.Dispose();
        }

        private void pergunteAoVágnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void conexõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConexoes f = new frmConexoes(Convert.ToInt32(txtId.Text));
            this.Hide();
            f.ShowDialog();
            f.Dispose();
            this.Show();
        }

        private void relatóriosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void produtosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCMVCadastroProduto f = new frmCMVCadastroProduto(Convert.ToInt32(txtId.Text));
            this.Hide();
            f.ShowDialog();
            f.Dispose();
            this.Show();
        }

        private void excessõesDeCustoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCMVExcessoesCusto f = new frmCMVExcessoesCusto(Convert.ToInt32(txtId.Text));

            this.Hide();
            f.ShowDialog();
            this.Show();
            f.Dispose();

            
        }

        private void resumoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCMVRelatorio f = new frmCMVRelatorio(Convert.ToInt32(txtId.Text));
            this.Hide();
            f.ShowDialog();
            f.Dispose();
            this.Show();
        }

        private void gestãoÀVistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCMVGestaoAVista f = new frmCMVGestaoAVista(Convert.ToInt32(txtId.Text));
            this.Hide();
            f.ShowDialog();
            f.Dispose();
            this.Show();
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadatroGrupo f = new frmCadatroGrupo(Convert.ToInt32(txtId.Text));
            this.Hide();
            f.ShowDialog();
            f.Dispose();
            this.Show();
        }
                
        private void GestaoAVistaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Forms.CMV.frmSinteticoPorGrupo f = new Forms.CMV.frmSinteticoPorGrupo(Convert.ToInt32(txtId.Text));
            this.Hide();
            f.ShowDialog();
            f.Dispose();
            this.Show();
        }

        private void RelatorioToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Forms.CMV.frmRELSinteticoGrupos f = new Forms.CMV.frmRELSinteticoGrupos(Convert.ToInt32(txtId.Text));
            this.Hide();
            f.ShowDialog();
            f.Dispose();
            this.Show();
        }

        private void relatórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.CMV.frmRELSinteticoGeral f = new Forms.CMV.frmRELSinteticoGeral(Convert.ToInt32(txtId.Text));
            this.Hide();
            f.ShowDialog();
            f.Dispose();
            this.Show();
        }

        private void fichasTécnicasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.Fichas.CadastroFichas f = new Forms.Fichas.CadastroFichas(Convert.ToInt32(txtId.Text), "", false);
            this.Hide();
            f.ShowDialog();
            f.Dispose();
            this.Show();
        }

        private void buffetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Fichas.frmCategoriasFichas f = new Forms.Fichas.frmCategoriasFichas("Setor", false, Convert.ToInt32(txtId.Text));
            this.Hide();
            f.ShowDialog();
            f.Dispose();
            this.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Fichas.frmCategoriasFichas f = new Forms.Fichas.frmCategoriasFichas("Categoria", false, Convert.ToInt32(txtId.Text));
            this.Hide();
            f.ShowDialog();
            f.Dispose();
            this.Show();
        }

        private void subCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Fichas.frmCategoriasFichas f = new Forms.Fichas.frmCategoriasFichas("Subcategoria", false, Convert.ToInt32(txtId.Text));
            this.Hide();
            f.ShowDialog();
            f.Dispose();
            this.Show();
        }

        private void consultaFichasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Fichas.frmConsultaFichas f = new Forms.Fichas.frmConsultaFichas(Convert.ToInt32(txtId.Text), false);
            this.Hide();
            f.ShowDialog();
            f.Dispose();
            this.Show();
        }

        private void backupDoBancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfig f = new frmConfig();
            f.ShowDialog();
            f.Dispose();
        }

        private void configuraçõesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DTOCaminhos dt = new DTOCaminhos();

            Forms.Comuns.Config f = new Forms.Comuns.Config(Convert.ToInt32(txtId.Text));
            this.Hide();
            pbWallpaper.Load(dt.Wallpaper + "default.jpg");
            f.ShowDialog();
            f.Dispose();
            if (File.Exists(dt.Wallpaper + txtId.Text + ".jpg"))
            {
                pbWallpaper.Load(dt.Wallpaper + txtId.Text + ".jpg");
            }
            else
            {
                try
                {
                    pbWallpaper.Load(dt.Wallpaper + "default.jpg");
                }
                catch
                {

                }

            }
            this.Show();
        }

        private void colarDoExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExcelToDB f = new frmExcelToDB(Convert.ToUInt32(txtId.Text));
            this.Hide();
            f.ShowDialog();
            this.Show();
            f.Dispose();
        }
    }
}
