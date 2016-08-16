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

namespace GUI
{
    public partial class frmDadosProduto : Form
    {

        int idProd = 0;
        public frmDadosProduto(int codigo)
        {
            InitializeComponent();
            idProd = codigo;
        }

        private void frmDadosProduto_Load(object sender, EventArgs e)
        {
            try
            {

                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLProduto bll = new BLLProduto(cx);

                DTOProduto modelo = bll.CarregaModeloProduto(idProd);

                lbNome2.Text = modelo.NomeProduto.ToString();

                DALConexao cxg = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLGrupo bllg = new BLLGrupo(cxg);

                DTOGrupo modelog = bllg.CarregaModeloGrupo(modelo.GrupoProduto);

                lbGrupo2.Text = modelog.NomeGrupo.ToString();
                lbMarca2.Text = modelo.MarcaProduto.ToString();
                lbModelo2.Text = modelo.ModelodoProduto.ToString();
                lbDesc2.Text = modelo.DescProduto.ToString();
                lbDataCadastro2.Text = modelo.DataCriacaoProduto.ToString("dd/MM/yyyy");

                DALConexao cxu = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLUsuario bllu = new BLLUsuario(cxg);

                DTOUsuario modelou = bllu.CarregaModeloUsuario(modelo.UsuarioCriacaoProduto);

                lbUsuario2.Text = modelou.LoginUsuario.ToString() + " ("+modelou.IniciaisUsuario.ToString()+")";

                DTOCaminhos mc = new DTOCaminhos();

                try
                {
                    pbFoto.Load(mc.Produtos + modelo.IdProduto.ToString() + ".jpg");

                }
                catch
                {
                    pbFoto.Load(mc.Produtos+"0.jpg");

                }

                if (modelo.AtivoProduto)
                {
                    lbAtivo.Text = "Ativo";
                }
                else
                {
                    lbAtivo.Text = "Inativo";
                }
            }
            catch { }
           
        }
    }
}
