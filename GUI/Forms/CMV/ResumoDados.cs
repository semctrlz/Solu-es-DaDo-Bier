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

namespace GUI.Forms.CMV
{
    public partial class ResumoDados : Form
    {

        int idUnidade, idUsuario, AnoAtual, mesAtual;

        bool liberado = false;  

        public ResumoDados(int id, int unidade)
        {
            idUsuario = id;
            idUnidade = unidade;

            InitializeComponent();
        }

        private void ResumoDados_Load(object sender, EventArgs e)
        {
            DefaultValues();
        }

        private void DefaultValues()
        {
            liberado = false;       

            numAno.Value = DateTime.Now.Year;
            AnoAtual = DateTime.Now.Year; 
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(Convert.ToInt32(idUsuario));

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";

            BLLUnidade bllun = new BLLUnidade(con);
            cbUnidade.DataSource = bllun.Localizar("");
            cbUnidade.DisplayMember = "cod_unidade";
            cbUnidade.ValueMember = "id_unidade";
cbUnidade.Text = modelou.IdUnidade.ToString("00");

            if (modelou.PermissaoUsuario < 4)
            {

                cbUnidade.Enabled = false;
            }


            mesAtual = Convert.ToInt32(DateTime.Now.Month);

            string selected = IntToMes(mesAtual);
            
            cbMes.Text = selected;

            liberado = true;
            carregaGrupo();
            CarregaDGVs();

        }

        private int MesToInt(string mes)
        {
            int mesSelecionado = 0;

            switch (mes)
            {
                case "Janeiro":
                    mesSelecionado = 1;
                    break;
                case "Fevereiro":
                    mesSelecionado = 2;
                    break;
                case "Março":
                    mesSelecionado = 3;
                    break;
                case "Abril":
                    mesSelecionado = 4;
                    break;
                case "Maio":
                    mesSelecionado = 5;
                    break;
                case "Junho":
                    mesSelecionado = 6;
                    break;
                case "Julho":
                    mesSelecionado = 7;
                    break;
                case "Agosto":
                    mesSelecionado = 8;
                    break;
                case "Setembro":
                    mesSelecionado = 9;
                    break;
                case "Outubro":
                    mesSelecionado = 10;
                    break;
                case "Novembro":
                    mesSelecionado = 11;
                    break;
                case "Dezembro":
                    mesSelecionado = 12;
                    break;
                default:
                    mesSelecionado = 0;
                    break;
            }

            return mesSelecionado;
        }

        private string IntToMes(int mes)
        {
            string mesSelecionado = "";

            switch (mes)
            {
                case 1:
                    mesSelecionado = "Janeiro";
                    break;
                case 2:
                    mesSelecionado = "Fevereiro";
                    break;
                case 3:
                    mesSelecionado = "Março";
                    break;
                case 4:
                    mesSelecionado = "Abril";
                    break;
                case 5:
                    mesSelecionado = "Maio";
                    break;
                case 6:
                    mesSelecionado = "Junho";
                    break;
                case 7:
                    mesSelecionado = "Julho";
                    break;
                case 8:
                    mesSelecionado = "Agosto";
                    break;
                case 9:
                    mesSelecionado = "Setembro";
                    break;
                case 10:
                    mesSelecionado = "Outubro";
                    break;
                case 11:
                    mesSelecionado = "Novembro";
                    break;
                case 12:
                    mesSelecionado = "Dezembro";
                    break;
                default:
                    mesSelecionado = "";
                    break;
            }

            return mesSelecionado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Forms.CMV.frmExcelToDB f = new frmExcelToDB(Convert.ToUInt32(idUsuario));
            this.Hide();
            f.ShowDialog();
            this.Show();
            CarregaDGVs();

        }

        private void cbUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (liberado)
            {
                idUnidade = Convert.ToInt32(cbUnidade.SelectedValue.ToString());
                carregaGrupo();
                CarregaDGVs();
            }
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            //Verifica preenchimento dos dados necessários
            if(txtValor.Text.Trim() != "")
            {

                if(cbConta.Text != "")
                {
                    adicionaBanco();
                }
                else
                {
                    MessageBox.Show("O campo local deve ser preenchido.");
                }

            }
            else
            {
                MessageBox.Show("O valor de acréscimo deve ser preenchido.");
            }
        }

        private void adicionaBanco()
        {
            DTOAcrescimos dto = new DTOAcrescimos();
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLAcrescimos bll = new BLLAcrescimos(cx);

            //Preenche dados

            dto.Conta_acrescimo = "";
            dto.Obs_acrescimo = "";
            dto.Tipo_acrescimo = "";
            dto.Valor_acrescimo = 0;

            dto.Data_acrescimo = dpData.Value;
            dto.Valor_acrescimo = Convert.ToDouble(txtValor.Text);
            dto.Id_usuario = idUsuario;
            dto.Id_unidade = idUnidade;

            if(txtObs.Text != "")
            {
                dto.Obs_acrescimo = txtObs.Text.Trim();
            }

            if (cbConta.SelectedValue.ToString() == "-1") 
            {
                dto.Tipo_acrescimo = "p";
            }
            else if (cbConta.SelectedValue.ToString() == "-2")
            {
                dto.Tipo_acrescimo = "r";
            }
            else
            {
                dto.Tipo_acrescimo = "c";
                dto.Valor_acrescimo *= -1;
                dto.Conta_acrescimo = cbConta.Text.ToString().Substring(0,10);
            }

            dto.Descricao_acrescimo = cbConta.Text;


            bll.Incluir(dto);


            txtValor.Clear();
            txtObs.Clear();
            cbConta.Text = "";            
            dpData.Value = DateTime.Now;

            MessageBox.Show("Valor incluído com sucesso!");

            CarregaDGVs();

        }

        public class Language
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        private void carregaGrupo()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLConfigCusto bll = new BLLConfigCusto(cx);

            DataTable tabela = bll.LocalizarConfig(idUnidade);

            var dataSource = new List<Language>();

            dataSource.Add(new Language() { Name = "", Value = "0" });

            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                dataSource.Add(new Language() { Name = tabela.Rows[i][1].ToString() + " - " + tabela.Rows[i][2].ToString(), Value = tabela.Rows[i][0].ToString() });
            }

            dataSource.Add(new Language() { Name = "ACRÉSCIMO AO PAX", Value = "-1" });
            dataSource.Add(new Language() { Name = "ACRÉSCIMO À RECEITA", Value = "-2" });

            //Setup data binding
            this.cbConta.DataSource = dataSource;
            this.cbConta.DisplayMember = "Name";
            this.cbConta.ValueMember = "Value";
            this.cbConta.Text = "";
        }

        private void txtValor_Validating(object sender, CancelEventArgs e)
        {
            double doubleValue;

            string txt = txtValor.Text;

            if (Double.TryParse(txt, out doubleValue) && txtValor.Text != "")
            {
                txtValor.Text = doubleValue.ToString("#,0.00");

            }

            else
            {
                e.Cancel = true;
                MessageBox.Show("Digite um valor numérico com até duas casas decimais.");
            }
        }

        private void dgvCusto_SelectionChanged(object sender, EventArgs e)
        {
            dgvCusto.ClearSelection();
        }

        private void dgvAcrescimos_SelectionChanged(object sender, EventArgs e)
        {
            dgvAcrescimos.ClearSelection();
        }

        private void dgvAcrescimos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (e.RowIndex >= 0)
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                    BLLUsuario bllu = new BLLUsuario(cx);
                    DTOUsuario dto = new DTOUsuario();

                    dto = bllu.CarregaModeloUsuario(Convert.ToInt32(dgvAcrescimos.Rows[e.RowIndex].Cells[5].Value));

                    if (dto.PermissaoUsuario >= 3)
                    {
                        if (idUsuario != Convert.ToInt32(dgvAcrescimos.Rows[e.RowIndex].Cells[5].Value))
                        {
                            
                            DialogResult d = MessageBox.Show("Deseja realmente excluir o acrescimo feito por " + dto.NomeUsuario + "?", "ATENÇÃO!", MessageBoxButtons.YesNo);
                            if (d.ToString() == "Yes")
                            {
                                ExcluiAcrescimo(Convert.ToInt32(dgvAcrescimos.Rows[e.RowIndex].Cells[0].Value), e.RowIndex);
                            }
                        }
                        else
                        {
                            DialogResult d = MessageBox.Show("Deseja realmente excluir este acréscimo?", "ATENÇÃO!", MessageBoxButtons.YesNo);
                            if (d.ToString() == "Yes")
                            {
                                ExcluiAcrescimo(Convert.ToInt32(dgvAcrescimos.Rows[e.RowIndex].Cells[0].Value), e.RowIndex);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Você não tem permissões suficientes para excluir esse acréscimo.");
                    }                    
                }
            }
        }

        private void ExcluiAcrescimo(int id, int linha)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLAcrescimos bll = new BLLAcrescimos(cx);

            if (dgvAcrescimos.Rows[linha].Cells[3].Value.ToString().Substring(1,1) == ".")
            {
                txtValor.Text = (Convert.ToDouble(dgvAcrescimos.Rows[linha].Cells[2].Value)*-1).ToString("#,0.00");

            }else
            {
                txtValor.Text = (Convert.ToDouble(dgvAcrescimos.Rows[linha].Cells[2].Value)).ToString("#,0.00");

            }
            dpData.Value = Convert.ToDateTime(dgvAcrescimos.Rows[linha].Cells[1].Value);
            cbConta.Text = dgvAcrescimos.Rows[linha].Cells[3].Value.ToString();
            txtObs.Text = dgvAcrescimos.Rows[linha].Cells[4].Value.ToString();

            bll.Excluir(id);
            CarregaDGVs();

        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liberado)
            {
                mesAtual = MesToInt(cbMes.Text);
                CarregaDGVs();
            }
        }

        private void numAno_ValueChanged(object sender, EventArgs e)
        {
            if (liberado)
            {
                AnoAtual = Convert.ToInt32(numAno.Value);
                CarregaDGVs();
            }
        }

        private void CarregaDGVs()
        {
            DateTime Data = new DateTime(AnoAtual, mesAtual, 1);
            
            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLConsultaCMV bll = new BLLConsultaCMV(cx);

            DataTable table = bll.ListarCustoReceitaPaxAcrescimos(idUnidade, Data);

            dgvCusto.DataSource = table;

            dgvCusto.Columns[0].Width = 70;
            dgvCusto.Columns[0].HeaderText = "DATA";

            dgvCusto.Columns[1].Width = 70;
            dgvCusto.Columns[1].HeaderText = "CUSTO";

            dgvCusto.Columns[2].Width = 70;
            dgvCusto.Columns[2].HeaderText = "+CUSTO";

            dgvCusto.Columns[3].Width = 70;
            dgvCusto.Columns[3].HeaderText = "RECEITA_B";
            
            dgvCusto.Columns[4].Width = 70;
            dgvCusto.Columns[4].HeaderText = "RECEITA_L";

            dgvCusto.Columns[5].Width = 70;
            dgvCusto.Columns[5].HeaderText = "+RECEITA";

            dgvCusto.Columns[6].Width = 50;
            dgvCusto.Columns[6].HeaderText = "PAX";


            dgvCusto.Columns[7].Width = 50;
            dgvCusto.Columns[7].HeaderText = "+PAX";


            //carrega dgvAcrescimos
            dgvAcrescimos.Rows.Clear();
            BLLAcrescimos blla = new BLLAcrescimos(cx);
            DataTable acrescimos = blla.LocalizarAcrescimos(idUnidade, Data);
            string data;
            String[] S;
            for (int i = 0; i<acrescimos.Rows.Count; i++)
            {
                data = Convert.ToDateTime(acrescimos.Rows[i][1]).ToShortDateString();
                S = new string[] { acrescimos.Rows[i][0].ToString(), data, acrescimos.Rows[i][2].ToString(), acrescimos.Rows[i][3].ToString(), acrescimos.Rows[i][4].ToString(), acrescimos.Rows[i][5].ToString() };
                dgvAcrescimos.Rows.Add(S);
            }

        }

    }
}
