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
    public partial class VisualizaFichaTecnica : Form
    {
        int unidade, idUsuario;
        string codFicha;

        public VisualizaFichaTecnica(int u, int i, string c)
        {
            unidade = u;
            idUsuario = i;
            codFicha = c;
            InitializeComponent();
        }

        private void VisualizaFichaTecnica_Load(object sender, EventArgs e)
        {
            pnImagem.Location = new Point(5 , 70);
            pbImagem.Visible = false;

            CarregaFicha(codFicha);
            CarregarIngredientesPorCodigo(codFicha);


        }

        private void CarregaFicha(string cod)
        {

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLPratos bllp = new BLLPratos(cx);
            DataTable tabela = bllp.LocalizarPorCod(cod);

            DTOCaminhos dto = new DTOCaminhos();

            string nomePrato, codigo, desc, preparo;
            double rendimento, peso;
            int setor, cat, subcat;

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

            lbTitulo.Text = $"{nomePrato} ({cod})";


            if (string.IsNullOrEmpty(preparo))
            {
                lbPreparo.Text = "";
            }
            else
            {
                lbPreparo.Text = preparo;
            }

            if (string.IsNullOrEmpty(peso.ToString()))
            {
                lbPeso.Text = "0,0000";
            }
            else
            {
                lbPeso.Text = peso.ToString("#,0.0000");
            }

            lbRendimento.Text = rendimento.ToString("#,0.00");

            //Carrega setor, categoria e subcategoria

            BLLBuffet bllsetor = new BLLBuffet(cx);
            DataTable tabelasetor = bllsetor.localizarPorId(setor);

            lbSetor.Text = tabelasetor.Rows[0][0].ToString();

            BLLCategoria bllcat = new BLLCategoria(cx);
            DataTable tabelacat = bllcat.localizarPorId(cat);

            if (tabelacat.Rows.Count > 0)
            {
                lbCategoria.Text = tabelacat.Rows[0][0].ToString();
            }else
            {
                lbCategoria.Text = "";
            }

            BLLSubCategoria bllscat = new BLLSubCategoria(cx);
            DataTable tabelascat = bllscat.localizarPorId(cat);

            if (tabelascat.Rows.Count > 0)
            {
                lbSubcategoria.Text = tabelascat.Rows[0][0].ToString();
            }else
            {
                lbSubcategoria.Text = "";
            }

            //Verifica se existe foto

            if (File.Exists(dto.FT + cod + ".jpg"))
            {
                pbImagem.Visible = true;
                pbimagem1.Load(dto.FT + cod + ".jpg");
            }
            else
            {
                pbImagem.Visible = false;
            }
        }

        private void dgvDados_SelectionChanged(object sender, EventArgs e)
        {
            dgvDados.ClearSelection();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pnImagem.Visible = false;
        }

        private void pbImagem_Click(object sender, EventArgs e)
        {
            if (pnImagem.Visible)
            {
                pnImagem.Visible = false;
            }
            else
            {
                pnImagem.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnImagem.Visible = false;
        }

        private void CarregarIngredientesPorCodigo(string cod)
        {
            dgvDados.Rows.Clear();

            //Linha por linha busca ingrediente com custo
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLPratos bll = new BLLPratos(cx);
            DataTable tabelaIngredientes = bll.ListarIngredientes(cod);

            BLLAeB bllaeb = new BLLAeB(cx);
            DataTable tabelaAeb;

            Augoritmos a = new Augoritmos();

            double TotalFicha = 0;

            if (tabelaIngredientes.Rows.Count > 0)
            {
                for (int i = 0; i < tabelaIngredientes.Rows.Count; i++)
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

                    custoUnit = a.CustoIngrediente(codIngrediente, unidade);
                    custoTotal = custoUnit * quant;


                    String[] V = new string[] { codIngrediente, nomeingrediente, um, fc.ToString("#,0.0000"), quant.ToString("#,0.0000"),  custoUnit.ToString("#,0.00"), custoTotal.ToString("#,0.00") };
                    dgvDados.Rows.Add(V);

                    TotalFicha += custoTotal;
                }

                lbTotal.Text = TotalFicha.ToString("#,0.00");

                if (Convert.ToDouble(lbPeso.Text) > 0)
                {
                    lbTotalKg.Text = (TotalFicha / Convert.ToDouble(lbPeso.Text)).ToString("#,0.00");
                }
                else
                {
                    lbTotalKg.Text = "0,00";
                }

                lbcustoPorcao.Text = (TotalFicha / Convert.ToDouble(lbRendimento.Text)).ToString("#,0.00");
            }


        }
    }
}
