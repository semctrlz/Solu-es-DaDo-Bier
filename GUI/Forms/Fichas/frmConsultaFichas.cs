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
        int idUsuario, permissao;
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

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bll = new BLLUsuario(cx);
            DataTable tabela = bll.LocalizarPorId(idUsuario);
            permissao = Convert.ToInt32(tabela.Rows[0][3].ToString());
            
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
            cbUnidade.Text = modelou.IdUnidade.ToString("00");

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

            List<Language> dataSource1 = NewMethod();
            dataSource1.Add(new Language() { setor = "", Value = "0" });

            for (int i = 0; i < tabelaSetor.Rows.Count; i++)
            {
                dataSource1.Add(new Language() { setor = tabelaSetor.Rows[i][1].ToString(), Value = Convert.ToInt32(tabelaSetor.Rows[i][0]).ToString() });
            }
            var dataSource2 = new List<Language>();
            dataSource2.Add(new Language() { cat = "", Value1 = "0" });

            for (int i = 0; i < tabelaCat.Rows.Count; i++)
            {
                dataSource2.Add(new Language() { cat = tabelaCat.Rows[i][1].ToString(), Value1 = Convert.ToInt32(tabelaCat.Rows[i][0]).ToString() });
            }
            var dataSource3 = new List<Language>();
            dataSource3.Add(new Language() { scat = "", Value2 = "0" });
            for (int i = 0; i < tabelaSCat.Rows.Count; i++)
            {
                dataSource3.Add(new Language() { scat = tabelaSCat.Rows[i][1].ToString(), Value2 = Convert.ToInt32(tabelaSCat.Rows[i][0]).ToString() });
            }

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

        private static List<Language> NewMethod()
        {
            return new List<Language>();
        }

        private void CarregaDgv()
        {

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

            busca += "order by p.cod_prato;";

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLPratos bll = new BLLPratos(cx);
            DataTable tabela = bll.BuscaFichas(busca);
            DTOCaminhos caminho = new DTOCaminhos();


            //this.dgvFichas.Columns[9].ValueType = typeof(double);

            DataTable dados = new DataTable();

            Image ver = Image.FromFile(caminho.Icones+"document.png");
            Image edit = Image.FromFile(caminho.Icones + "pencil.png");
            Image del = Image.FromFile(caminho.Icones + "trash.png");
            
            dados.Clear();
            dados.Columns.Add("CODIGO");
            dados.Columns.Add("NOME");
            dados.Columns.Add("SETOR");
            dados.Columns.Add("CAT");
            dados.Columns.Add("SCAT");
            dados.Columns.Add("PESO", typeof(double));
            dados.Columns.Add("RENDIMENTO", typeof(double));
            dados.Columns.Add("CUSTO/KG", typeof(double));
            dados.Columns.Add("CUSTO/PORCAO", typeof(double));
            dados.Columns.Add("TOTAL", typeof(double));
            dados.Columns.Add("VER", typeof(System.Drawing.Bitmap));
            dados.Columns.Add("EDT", typeof(System.Drawing.Bitmap));
            dados.Columns.Add("DEL", typeof(System.Drawing.Bitmap));



            DataRow _ravi = dados.NewRow();
            dgvFichas.Visible = false;
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

                dados.Rows.Add(new object[] { tabela.Rows[i][0].ToString(), tabela.Rows[i][1].ToString(), tabela.Rows[i][2].ToString(), categoria, subcategoria, Convert.ToDouble(Math.Round(peso,4)), Convert.ToDouble(Math.Round(rendimento,2)), Convert.ToDouble(Math.Round(custoPorKg,2)) , Convert.ToDouble(Math.Round(custoPorPorcao,2)), Convert.ToDouble(Math.Round(custo,2)), ver, edit, del });
               


            }

            dgvFichas.DataSource = dados;
            dgvFichas.Visible = true;
            FormatarDGV();
            
        }

        private void btConsulta_Click(object sender, EventArgs e)
        {
            CarregaDgv();
        }

        private void FormatarDGV()
        {
            dgvFichas.AutoResizeColumns();
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

        private void btPdf_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Deseja exportar TODAS as fichas técnicas listadas abaixo?", "ATENÇÃO!", MessageBoxButtons.YesNo);
            if (d.ToString() == "Yes")
            {
                DialogResult c = MessageBox.Show("Caso alguma ficha contenha imagem deseja exportá-la também?", "ATENÇÃO!", MessageBoxButtons.YesNo);
                if (c.ToString() == "Yes")
                {
                    exportarPdf(true);
                }
                else
                {
                    exportarPdf(false);
                }
            }
        }

        private void exportarPdf(bool img)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();


            Comuns.loading ld = new Comuns.loading();

            
            try
            {


                if (fd.ShowDialog() == DialogResult.OK)
                {

                    if (dgvFichas.Rows.Count == 1)
                    {
                        ld.SetMessage("Exportando a ficha técnica...\n Por favor, aguarde."); // "Loading data. Please wait..."
                    }
                    else
                    {
                        ld.SetMessage("Exportando as fichas técnicas...\n Por favor, aguarde."); // "Loading data. Please wait..."
                    }

                    ld.TopMost = true;
                    ld.StartPosition = FormStartPosition.CenterScreen;

                    ld.Show();
                    ld.Refresh();

                    Augoritmos au = new Augoritmos();

                    for (int i = 0; i < dgvFichas.Rows.Count; i++)
                    {
                        au.paraPDF(img, dgvFichas.Rows[i].Cells[0].Value.ToString(), fd.SelectedPath.ToString()+ "\\" +dgvFichas.Rows[i].Cells[1].Value.ToString()+".pdf", Convert.ToInt32(cbUnidade.SelectedValue));

                    }
                    if (dgvFichas.Rows.Count == 1)
                    {
                        ld.Close();
                        MessageBox.Show("Ficha técnica exportada com sucesso.");
                    }
                    else
                    {
                        ld.Close();
                        MessageBox.Show("Fichas técnicas exportada com sucesso.");
                    }

                }
            }
            catch
            {
                ld.Close();
                MessageBox.Show($"Erro ao exportar as fichas técnicas.\nVerifique se não tem algum documento de PDF Aberto ou se a pasta selecionada não está protegida.");

            }


        }

        private void dgvFichas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Augoritmos au = new Augoritmos();
            if (e.ColumnIndex == 12)
            {
                if (e.RowIndex >= 0)
                {
                    if (permissao >= 3)
                    {
                        DialogResult d = MessageBox.Show("Deseja realmente excluir a ficha técnica de " + dgvFichas.Rows[e.RowIndex].Cells[1].Value.ToString() + "?", "ATENÇÃO!", MessageBoxButtons.YesNo);
                        if (d.ToString() == "Yes")
                        {
                            au.ExcluirPrato(dgvFichas.Rows[e.RowIndex].Cells[0].Value.ToString());
                            CarregaDgv();
                        }
                    }else
                    {
                        MessageBox.Show("Você não tem permissões necessárias para deletar esta ficha técnica.");
                    }
                }
            }


            if (e.ColumnIndex == 11)
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
                        if (permissao >= 3)
                        {
                            CadastroFichas cf = new CadastroFichas(idUsuario, dgvFichas.Rows[e.RowIndex].Cells[0].Value.ToString(), true);
                            cf.ShowDialog();
                            cf.Dispose();
                            CarregaDgv();
                        }else
                        {
                            MessageBox.Show("Você não tem permissões necessárias para editar esta ficha técnica.");

                        }

                    }
                }
            }

            if (e.ColumnIndex == 10)
            {
                if (e.RowIndex >= 0)
                {

                    VisualizaFichaTecnica vf = new VisualizaFichaTecnica(Convert.ToInt32(cbUnidade.SelectedValue), idUsuario, dgvFichas.Rows[e.RowIndex].Cells[0].Value.ToString());
                    vf.ShowDialog();
                    vf.Dispose();

                }
            }
        }
    }
}
