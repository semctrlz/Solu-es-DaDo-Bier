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

namespace GUI.Forms.Fichas
{
    public partial class frmConsultaFichas : Form
    {
        int idUsuario;
        bool herdada;
        public string fichaSelecionada;

        public frmConsultaFichas(int id, bool h)
        {
            idUsuario = id;
            herdada = h;
            InitializeComponent();
        }

        private void frmConsultaFichas_Load(object sender, EventArgs e)
        {
            DefaultValues();
            CarregaDgv();

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
            cbUnidade.Text = modelou.IdUnidade.ToString();

            if (modelou.PermissaoUsuario < 4)
            {
                cbUnidade.Enabled = false;
            }

            CarregaCat();
        }

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

        private void CarregaDgv()
        {
            dgvFichas.Rows.Clear();

            string busca = $"select p.cod_prato, p.nome_prato,  b.nome_buffet, c.nome_cat, s.nome_scat," +
                "p.peso_prato, p.rendimento_prato, p.desc_prato from prato p join buffet b on p.id_setor = b.id_buffet " +
                $"left join categoria c on p.cat = c.id_cat left join subcategoria s on p.subcat = s.id_scat where nome_prato like '%{txtNome.Text}%'";

            if (cbSetor.Text != "")
            {
                busca += $" and id_setor = {Convert.ToInt32(cbSetor.SelectedValue)}";
            }

            if (cbCategoria.Text != "")
            {
                busca += $" and cat = {Convert.ToInt32(cbCategoria.SelectedValue)}";
            }

            if (cbSubCategoria.Text != "")
            {
                busca += $" and subcat = {Convert.ToInt32(cbSubCategoria.SelectedValue)}";
            }

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLPratos bll = new BLLPratos(cx);
            DataTable tabela = bll.BuscaFichas(busca);

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                string categoria = "";
                string subcategoria = "";
                double peso = 0;
                double rendimento = 0;
                double custo = 0;
                double custoPorKg = 0;
                double custoPorPorcao = 0;

                peso = Convert.ToDouble(tabela.Rows[i][5]);
                rendimento = Convert.ToDouble(tabela.Rows[i][6]);

                try
                {
                    Augoritmos au = new Augoritmos();
                    custo = au.CalculaCustoFicha(tabela.Rows[i][0].ToString(), Convert.ToInt32(cbUnidade.SelectedValue));

                }

                catch
                {

                }

                if (peso > 0)
                {
                    custoPorKg = custo / peso;
                }

                if (rendimento > 0)
                {
                    custoPorPorcao = custo / rendimento;
                }

                if (!(string.IsNullOrEmpty(tabela.Rows[i][3].ToString())))
                {
                    categoria = tabela.Rows[i][3].ToString();
                }

                if (!(string.IsNullOrEmpty(tabela.Rows[i][4].ToString())))
                {
                    subcategoria = tabela.Rows[i][4].ToString();
                }

                String[] V = new string[] { tabela.Rows[i][0].ToString(), tabela.Rows[i][1].ToString(), tabela.Rows[i][2].ToString(), categoria, subcategoria, peso.ToString("#,0.0000"), rendimento.ToString("#,0.0000"), custoPorKg.ToString("#,0.00"), custoPorPorcao.ToString("#,0.00"), custo.ToString("#,0.00"), tabela.Rows[i][7].ToString() };
                dgvFichas.Rows.Add(V);

            }


        }

        private void btConsulta_Click(object sender, EventArgs e)
        {
            CarregaDgv();
        }

        private double CalculaCustoFicha(string codigo)
        {
            double CustoTotal = 0;

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLPratos bll = new BLLPratos(cx);

            DataTable tabela = new DataTable();
            DataTable Tabela2 = new DataTable();

            tabela = bll.ListarIngredientes(codigo);

            for (int i = 0; i < tabela.Rows.Count; i++)
            {

                Tabela2 = bll.CustoIngrediente(tabela.Rows[i][0].ToString(), Convert.ToInt32(cbUnidade.SelectedValue));

                CustoTotal += Convert.ToDouble(Tabela2.Rows[0][0]) * Convert.ToDouble(tabela.Rows[i][1]);

            }

            return CustoTotal;

        }

        private void dgvFichas_SelectionChanged(object sender, EventArgs e)
        {
            dgvFichas.ClearSelection();
        }


        private void dgvFichas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Augoritmos au = new Augoritmos();
            if (e.ColumnIndex == 13)
            {
                if (e.RowIndex >= 0)
                {
                    DialogResult d = MessageBox.Show("Deseja realmente excluir a ficha técnica de " + dgvFichas.Rows[e.RowIndex].Cells[1].Value.ToString() + "?", "ATENÇÃO!", MessageBoxButtons.YesNo);
                    if (d.ToString() == "Yes")
                    {
                        au.ExcluirPrato(dgvFichas.Rows[e.RowIndex].Cells[0].Value.ToString());
                        CarregaDgv();
                    }
                }
            }


            if (e.ColumnIndex == 12)
            {
                if (e.RowIndex >= 0)
                {
                    if (herdada)
                    {
                        this.fichaSelecionada = dgvFichas.Rows[e.RowIndex].Cells[0].Value.ToString();
                        this.Close();
                    }
                    else
                    {
                        CadastroFichas cf = new CadastroFichas(idUsuario, dgvFichas.Rows[e.RowIndex].Cells[0].Value.ToString(), true);
                        cf.ShowDialog();
                        CarregaDgv();
                    }
                }
            }
        }
    }
}
