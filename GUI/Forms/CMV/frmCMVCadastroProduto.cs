using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Code.DAL;
using GUI.Code.BLL;
using System.Text.RegularExpressions;
using GUI.Code.DTO;

namespace GUI
{
    public partial class frmCMVCadastroProduto : Form
    {
        int idUsuario;
        public frmCMVCadastroProduto(int id)
        {
            idUsuario = id;

            InitializeComponent();
        }

        private void txtCod_Validating(object sender, CancelEventArgs e)
        {

            try
            {
                int testenumero = Convert.ToInt32(txtCod.Text);

                string cod = txtCod.Text;

                txtCod.Text = $"{cod.Substring(0, 2)}.{cod.Substring(2, 2)}.{cod.Substring(4, 4)}";
            } catch
            {
                txtCod.Focus();
                MessageBox.Show("O valor do código deve ser composto apenas por números, sem letras ou caracteres especiais.");
            }
        }


        private void frmCMVCadastroProduto_Load(object sender, EventArgs e)
        {
            RecarregadgvLista();
        }

        private void RecarregadgvLista()
        {
            dgvLista.Rows.Clear();
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

            BLLDados bll = new BLLDados(cx);

            DataTable tabela = bll.LocalizarCodigosAcadastrar();

            String[] V;

            if (tabela.Rows.Count > 0)
            {
                for (int i = 0; tabela.Rows.Count > i; i++)
                {

                    if (tabela.Rows[i][3].ToString() == "0")
                    {
                        V = new string[] { tabela.Rows[i][0].ToString(), tabela.Rows[i][1].ToString() };
                        this.dgvLista.Rows.Add(V);
                    }
                }
            }

        }

        private void btColarDados_Click(object sender, EventArgs e)
        {
            btColarDados.Enabled = false;
            
            DataObject o = (DataObject)Clipboard.GetDataObject();
            if (o.GetDataPresent(DataFormats.Text))
            {
                if (dgvExcel.RowCount > 0)
                    dgvExcel.Rows.Clear();

                if (dgvExcel.ColumnCount > 0)
                    dgvExcel.Columns.Clear();

                bool columnsAdded = false;
                string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                foreach (string pastedRow in pastedRows)
                {
                    string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });

                    if (!columnsAdded)
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            dgvExcel.Columns.Add("col" + i, pastedRowCells[i]);

                        columnsAdded = true;
                        continue;
                    }

                    dgvExcel.Rows.Add();
                    int myRowIndex = dgvExcel.Rows.Count - 1;

                    using (DataGridViewRow myDataGridViewRow = dgvExcel.Rows[myRowIndex])
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            myDataGridViewRow.Cells[i].Value = pastedRowCells[i].Replace("R$", "").Trim();
                    }
                }
            }


            btColarDados.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {


            DALConexao conn = new DALConexao(DadosDaConexao.StringDaConexao);

            DTOAeB dto = new DTOAeB();
            BLLAeB bll = new BLLAeB(conn);

            DataTable tabela;

            if (dgvExcel.Rows.Count > 0)
            {
                for (int i = 0; i < dgvExcel.RowCount; i++)
                {

                    tabela = bll.Localizar(dgvExcel.Rows[i].Cells[0].Value.ToString());

                    if (Convert.ToInt32(tabela.Rows[0][0].ToString()) == 0)
                    {
                        dto.CodAeb = dgvExcel.Rows[i].Cells[0].Value.ToString();

                        dto.NomeAeb = dgvExcel.Rows[i].Cells[1].Value.ToString();

                        dto.UmAeb = dgvExcel.Rows[i].Cells[2].Value.ToString();

                        bll.Incluir(dto);
                        
                    }
                }



            }
            RecarregadgvLista();
            dgvExcel.Rows.Clear();
            MessageBox.Show("Dados salvos com sucesso!");
            panel1.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible= true;
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

            DTOAeB dto = new DTOAeB();
            BLLAeB bll = new BLLAeB(cx);

            dto.CodAeb = txtCod.Text;
            dto.NomeAeb = txtNome.Text;
            dto.UmAeb = cbUm.Text;

            try
            {
                bll.Incluir(dto);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao salvar o produto. Erro\n" + ex);
            }

            txtCod.Clear();
            txtNome.Clear();
            cbUm.Text = "";

            
            RecarregadgvLista();


        }
    }
}
