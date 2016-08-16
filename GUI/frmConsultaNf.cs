using GUI.Code.BLL;
using GUI.Code.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmConsultaNf : Form
    {
        public int lancamento = 0;
        private int unidadeV = 0;
        private int fornecedorV = 0;
        private int nfV = 0;
        private DateTime emissaoV = DateTime.MinValue;
        private DateTime entradaV = DateTime.MinValue;


        public frmConsultaNf(int unidade, int fornecedor, int nf, DateTime emissao, DateTime entrada)
        {

            if(unidade != 0)
            {
                unidadeV = Convert.ToInt32(unidade);
            }

            if (fornecedor != 0)
            {
                fornecedorV = Convert.ToInt32(fornecedor);
            }

            if (nf != 0)
            {
                nfV = Convert.ToInt32(nf);
            }

            if (emissao != DateTime.MinValue)
            {
                emissaoV = Convert.ToDateTime(emissao);
            }

            if (entrada != DateTime.MinValue)
            {
                entradaV = Convert.ToDateTime(entrada);
            }


            InitializeComponent();
        }

        private void frmConsultaNf_Load(object sender, EventArgs e)
        {

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLMovimento bll = new BLLMovimento(cx);

            dgvConsultaNf.DataSource = bll.LocalizarNf(unidadeV, fornecedorV, nfV, emissaoV, entradaV);

            if(dgvConsultaNf.RowCount == 0)
            {
                this.lancamento = -1;
                this.Close();
            }

            dgvConsultaNf.Columns.Add(new DeleteColumn());

            dgvConsultaNf.Columns[0].Visible = false;

            dgvConsultaNf.Columns[1].HeaderText = "NF";
            dgvConsultaNf.Columns[1].Width = 80;

            dgvConsultaNf.Columns[2].HeaderText = "FORNECEDOR";
            dgvConsultaNf.Columns[2].Width = 150;

            dgvConsultaNf.Columns[3].HeaderText = "EMISSÃO";
            dgvConsultaNf.Columns[3].Width = 100;

            dgvConsultaNf.Columns[4].HeaderText = "ENTRADA";
            dgvConsultaNf.Columns[4].Width = 100;

            dgvConsultaNf.Columns[5].HeaderText = "USER";
            dgvConsultaNf.Columns[5].Width = 85;

        }

        private void dgvConsultaNf_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.lancamento = Convert.ToInt32(dgvConsultaNf.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }

        public class DeleteCell : DataGridViewButtonCell
        {
            Image del = Image.FromFile("Imagens\\Icones\\pencil-3x.png");
            protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
                graphics.DrawImage(del, cellBounds);
            }
        }

        public class DeleteColumn : DataGridViewButtonColumn
        {
            public DeleteColumn()
            {
                this.CellTemplate = new DeleteCell();
                this.Width = 24;
                //set other options here 
            }
        }

        private void dgvConsultaNf_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (e.RowIndex >= 0)
                {

                    this.lancamento = Convert.ToInt32(dgvConsultaNf.Rows[e.RowIndex].Cells[0].Value);
                    this.Close();

                }
            }
        }
    }
}
