using GUI.Code.BLL;
using GUI.Code.DAL;
using GUI.Code.DTO;
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
    public partial class frmConsultaInventario : Form
    {
        #region Variáveis

        int idUsuario;
        string busca;
        public int numeroInv;

        #endregion

        #region Inicialização

        public frmConsultaInventario(int id)
        {
            idUsuario = id;

            InitializeComponent();
        }

        private void frmConsultaInventario_Load(object sender, EventArgs e)
        {

            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(idUsuario);


            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUnidade bllun = new BLLUnidade(cx);
            cbUnidade.DataSource = bllun.Localizar("");
            cbUnidade.DisplayMember = "cod_unidade";
            cbUnidade.ValueMember = "id_unidade";
            cbUnidade.Text = modelou.IdUnidade.ToString();

            if (modelou.PermissaoUsuario < 4)
            {

                cbUnidade.Enabled = false;
            }

            DateTime Hoje = DateTime.Today;
            
            cbAbertos.Checked = true;


            txtDataDe.GotFocus += txtDataDe_GotFocus;
            txtDataA.GotFocus += txtDataA_GotFocus;
            txtNumero.GotFocus += txttxtNumero_GotFocus;
            dgvInventario.Columns.Add(new DeleteColumn());
        }

        #endregion

        void txtDataDe_GotFocus(object sender, EventArgs e)
        {
            txtDataDe.SelectAll();
        }

        void txtDataA_GotFocus(object sender, EventArgs e)
        {
            txtDataA.SelectAll();
        }

        void txttxtNumero_GotFocus(object sender, EventArgs e)
        {
            txtNumero.SelectAll();
        }


        #region Clicks

        private void btCancelar_Click(object sender, EventArgs e)
        {

            if (dgvInventario.RowCount > 0)
            {
                DialogResult d = MessageBox.Show("Deseja realmente cancelar esta consulta?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    this.LimpaCampos();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            this.Consulta();
        }

        #endregion

        #region Keydowns

        private void frmConsultaInventario_KeyDown(object sender, KeyEventArgs e)
            {

            if (e.KeyCode == Keys.Escape)
            {
                this.btCancelar_Click(sender, e);

            }

            if (e.KeyCode == Keys.Enter)
            {
                this.btLocalizar_Click(sender, e);

            }

        }

        #endregion

        #region Voids

        private void Consulta()
        {

               busca = "select i.concluido, i.inventario, i.data_criacao_inv, COUNT(i.inventario) as quant_inventario, " +
                "u.iniciais_usuario from inventario i inner join usuario u on i.id_usuario = u.id_usuario " +
                "where i.id_unidade = " + cbUnidade.SelectedValue;

            //Leitura dos filtros

            string prefix = "";
            int quantFiltros = 1;

            if (txtDataDe.Text.Trim() != "/  /" && txtDataA.Text == txtDataDe.Text)
            {
                if (quantFiltros > 0)
                {
                    prefix = " and ";
                }

                busca = busca + " i.data_criacao_inv = '" + Convert.ToDateTime(txtDataDe.Text).ToString("d")+"'";
                quantFiltros++;
            }

            if (txtDataDe.Text.Trim() != "/  /" && txtDataA.Text != txtDataDe.Text)
            {

                if (quantFiltros > 0)
                {
                    prefix = " and ";
                }

                busca = busca + prefix + " i.data_criacao_inv >= '" + Convert.ToDateTime(txtDataDe.Text).ToString("d") + "' and " +
                "i.data_criacao_inv <= '" + Convert.ToDateTime(txtDataA.Text).ToString("d")+"'";

                quantFiltros++;
            }

            if(txtNumero.Text.Trim() != "")
            {
                if (quantFiltros > 0)
                {
                    prefix = " and ";
                }

                busca = busca + prefix + "i.inventario = "+ txtNumero.Text;
                quantFiltros++;

            }

            if(cbAbertos.Checked == true)
            {
                if (quantFiltros > 0)
                {
                    prefix = " and ";
                }

                busca = busca + prefix + " i.concluido = 'A'";
                
            }


            busca = busca + " group by i.inventario, i.concluido, i.data_criacao_inv, u.iniciais_usuario;";

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLInventario bll = new BLLInventario(cx);
            DataTable tabela = bll.Localizar(busca);

            dgvInventario.Rows.Clear();

            bool Aberto;
            
            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                try
                {
                    if (quantFiltros > 0)
                    {
                        prefix = " and ";
                    }

                    if (tabela.Rows[i]["concluido"].ToString() == "A")
                    {
                        Aberto = true;
                    }
                    else
                    {
                        Aberto = false;
                    }
                    
                    string nrInv = Convert.ToInt32(tabela.Rows[i]["inventario"]).ToString("00000000");
                    string data = Convert.ToDateTime(tabela.Rows[i]["data_criacao_inv"]).ToString("d");
                    string quant = tabela.Rows[i]["quant_inventario"].ToString();
                    string usuario = tabela.Rows[i]["iniciais_usuario"].ToString();
                   
                    String[] P = new string[] { Aberto.ToString(), nrInv, data, quant, usuario };
                    this.dgvInventario.Rows.Add(P);
                }
                catch
                {

                }



            }

            #endregion

        }

        private void txtDataDe_Leave(object sender, EventArgs e)
        {
            DateTime resultado = DateTime.MinValue;
            if (DateTime.TryParse(this.txtDataDe.Text.Trim(), out resultado))
            {

                txtDataDe.Text = resultado.ToString("d");

                //Acha o último dia do mês que está no Data De.
                DateTime ultimoDia = new DateTime(Convert.ToDateTime(txtDataDe.Text).Year, Convert.ToDateTime(txtDataDe.Text).Month, DateTime.DaysInMonth(Convert.ToDateTime(txtDataDe.Text).Year, Convert.ToDateTime(txtDataDe.Text).Month));


                txtDataA.Text = ultimoDia.ToString("d");
            }

            else
            {
                if (txtDataDe.Text.Trim() != "/  /")
                {
                    MessageBox.Show("Data inválida.");
                    txtDataDe.Focus();
                }
            }
        }

        private void txtDataA_Leave(object sender, EventArgs e)
        {
            DateTime resultado = DateTime.MinValue;
            if (DateTime.TryParse(this.txtDataA.Text.Trim(), out resultado))
            {

                txtDataA.Text = resultado.ToString("d");

                if (Convert.ToDateTime(txtDataA.Text) < Convert.ToDateTime(txtDataDe.Text))
                {
                    MessageBox.Show("A data de movimento deve ser igual ou posterior a data de inventário.");
                    txtDataA.Focus();
                }


            }
            else
            {
                if (txtDataA.Text.Trim() != "/  /")
                {
                    MessageBox.Show("Data inválida.");
                    txtDataA.Focus();
                }
            }
        }

        private void LimpaCampos()
        {

            txtNumero.Clear();
            txtDataA.Clear();
            txtDataDe.Clear();
            cbAbertos.Checked = true;
            dgvInventario.Rows.Clear();


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

        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (e.RowIndex >= 0)
                {

                    this.numeroInv = Convert.ToInt32(dgvInventario.Rows[e.RowIndex].Cells[1].Value);
                    this.Close();

                }
            }
        }
    }
}
