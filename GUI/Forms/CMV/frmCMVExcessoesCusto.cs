using GUI.Code.DAL;
using GUI.Code.BLL;
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
    public partial class frmCMVExcessoesCusto : Form
    {
        int idUsuario;
        public frmCMVExcessoesCusto(int id)
        {
            idUsuario = id;
            InitializeComponent();
        }

        private void frmCMVExcessoesCusto_Load(object sender, EventArgs e)
        {
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(Convert.ToInt32(idUsuario));

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";

            LimpaTela();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            
            //Ler dados

            DTOExcessoesCusto dto = new DTOExcessoesCusto();

            dto.TipoOperacao = txtTipoOp.Text;
            
            if(txtTipoOp.Text.Trim() == ".")
            {
                MessageBox.Show("Campo \"Tipo de operação\" não pode ficar vazio.");
            }
            else if (cbAcao.Text != "Ignorar" && cbAcao.Text != "Alterar sinal")
            {
                MessageBox.Show("Escolha uma ação válida no campo \"Ação\".");

            }
            else
            {

                switch (cbAcao.Text)
                {
                    case "Ignorar":
                        dto.Acao = 0;
                        break;
                    case "Alterar sinal":
                        dto.Acao = -1;
                        break;
                }

                dto.TipoOperacao = txtTipoOp.Text;
                dto.Obs = txtObs.Text;
                
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLExcessoesCusto bll = new BLLExcessoesCusto(cx);
                bll.Incluir(dto);
                LimpaTela();
                txtTipoOp.Focus();

            }
            
        }

        private void LimpaTela()
        {
            txtTipoOp.Clear();
            cbAcao.Text = "";
            txtObs.Clear();

            RecarregardgvExcessoes();

        }

        private void RecarregardgvExcessoes()
        {
            dgvExcessoes.Rows.Clear();

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLExcessoesCusto bll = new BLLExcessoesCusto(cx);
            
            DataTable tabela = bll.Localizar();

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                string acao = "";
                string operacao;
                string id;
                string obs;
                String[] E;

                switch (Convert.ToInt32(tabela.Rows[i][2]))
                {
                    case -1:
                        acao = "Alterar sinal";
                        break;
                    case 0:
                        acao = "ignorar";
                        break;
                }

                id = tabela.Rows[i][0].ToString();
                operacao = tabela.Rows[i][1].ToString();
                obs = tabela.Rows[i][3].ToString();

                E = new string[] { id, operacao, acao, obs };
                this.dgvExcessoes.Rows.Add(E);

            }


            
        }

        private void dgvExcessoes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (e.RowIndex >= 0)
                {

                    txtTipoOp.Text = dgvExcessoes.Rows[e.RowIndex].Cells[1].Value.ToString();
                    cbAcao.Text = dgvExcessoes.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtObs.Text = dgvExcessoes.Rows[e.RowIndex].Cells[3].Value.ToString();


                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);

                    DTOExcessoesCusto ven = new DTOExcessoesCusto();
                    BLLExcessoesCusto bll = new BLLExcessoesCusto(cx);

                    bll.Excluir(Convert.ToInt32(dgvExcessoes.Rows[e.RowIndex].Cells[0].Value));

                    RecarregardgvExcessoes();
                    txtTipoOp.Focus();

                }
            }
        }

        private void txtObs_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () {
                txtObs.SelectAll();
            });
        }

        private void txtTipoOp_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate () {
                txtTipoOp.SelectAll();
            });
        }

        private void cbAcao_Enter(object sender, EventArgs e)
        {
            ((ComboBox)sender).SelectAll();
        }
    }
}
