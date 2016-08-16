using GUI.Code.BLL;
using GUI.Code.DAL;
using GUI.Code.DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace GUI
{
    public partial class frmPosicaoDeEstoqueDados : Form
    {

        string consulta = "";
        int unidade = 0;
        int quant = 0;
        DateTime data;
        string produto = "";
        string grupo = "";
        int idUsuario = 0;
                
        public frmPosicaoDeEstoqueDados(int Unidade, DateTime Data, int Quant, string Produto, string Grupo, int usuario)
        {
            unidade = Unidade;
            data = Data;
            quant = Quant;
            produto = Produto.Trim();
            grupo = Grupo;
            idUsuario = usuario;

            InitializeComponent();
        }

        private void frmPosicaoDeEstoqueDados_Load(object sender, EventArgs e)
        {
            string idproduto;
            string codprod;
            string nomeprod;
            string quantprod;
            string nomegrupo;
            string codgrupo = "00";
            string busca = "";

            DALConexao connect = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(connect);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(idUsuario);

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";

            SqlConnection con = new SqlConnection(DadosDaConexao.StringDaConexao.ToString()); // making connection   
            SqlDataAdapter conUni = new SqlDataAdapter("select nome_unidade from unidade where cod_unidade = " + unidade, con);

            DataTable dtu = new DataTable(); //this is creating a virtual table  

            conUni.Fill(dtu);

            lbPosicaoDia.Text = lbPosicaoDia.Text + data.ToString("d") + " da unidade " + dtu.Rows[0][0].ToString();


            if (produto != ".")
            {
                busca = "select p.id_produto, p.cod_produto, p.nome_produto, g.nome_grupo from produto p  " +
                "inner join grupo g on p.id_grupo = g.id_grupo where p.cod_produto = " + produto + " order by cod_produto";
                
            }
            else
            {

                busca = "select p.id_produto, p.cod_produto, p.nome_produto, g.nome_grupo from produto p  " +
                "inner join grupo g on p.id_grupo = g.id_grupo where " + grupo + " order by cod_produto";

            }
            SqlDataAdapter sda = new SqlDataAdapter(busca, con);

            DataTable dt = new DataTable(); //this is creating a virtual table  
            
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

                //posição do item

                

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    idproduto = dt.Rows[i][0].ToString();
                    codprod = dt.Rows[i][1].ToString();
                    nomeprod = dt.Rows[i][2].ToString();
                    nomegrupo = dt.Rows[i][3].ToString();
                    quantprod = "0";



                    #region busca quant

                
               
                    int ultimoInv = 0;
                    int ultimosMovs = 0;
                    
                    DateTime dataUltimoInv;


                    //Localiza quantidade do último inventario concluído.
                    
                    string buscaUltimoInv = "select inventario, data_mov_inv, id_produto, quant_inv from inventario " +
                    " where concluido = 'c' and id_produto = " + idproduto + " and id_unidade = "+ unidade +
                    " and data_mov_inv < '" + data.ToString("d") + "' order by data_mov_inv asc;";



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
                        "where data_mov > '" + dataUltimoInv.ToString("d") + "' and data_mov <= '" + data.ToString("d") +
                        "' and id_produto = " + idproduto + " and id_unidade = "+ unidade +" group by id_produto;";


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

                    quantprod = (ultimoInv + ultimosMovs).ToString();


                    #endregion

                   
                    if (Convert.ToInt32(quantprod) >= quant)
                    {

                        if (codgrupo != codprod.Substring(0, 2))
                        {
                            String[] P = new string[] { "", nomegrupo, "" };
                            this.dgvPosicao.Rows.Add(P);

                            String[] P1 = new string[] { codprod, nomeprod, quantprod };
                            this.dgvPosicao.Rows.Add(P1);

                        }
                        else
                        {

                            String[] P = new string[] { codprod, nomeprod, quantprod };
                            this.dgvPosicao.Rows.Add(P);
                        }

                        codgrupo = codprod.Substring(0, 2);
                    }
                }
            }

            this.FormataDados();

        }

        private void FormataDados()
        {

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(dgvPosicao.Font, FontStyle.Bold);

            for (int i = 0; i < dgvPosicao.Rows.Count; i++)
            {

                if (dgvPosicao.Rows[i].Cells[0].Value.ToString() == "")
                {

                    dgvPosicao.Rows[i].DefaultCellStyle = style;
                    dgvPosicao.Rows[i].DefaultCellStyle.BackColor = Color.DimGray;
                    dgvPosicao.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    this.dgvPosicao.RowsDefaultCellStyle.BackColor = Color.White;
                    this.dgvPosicao.AlternatingRowsDefaultCellStyle.BackColor =
                        Color.LightGray;

                }
            }
        }

        private void btExportar_Click(object sender, EventArgs e)
        {


            //Exportar para o excel


            ExportToExcel();

        }

        private void ExportToExcel()
        {
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "Posição de estoque";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < dgvPosicao.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvPosicao.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvPosicao.Columns[j].HeaderText;
                            
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dgvPosicao.Rows[i-1].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Dados exportados com sucesso.");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
