using BLL;
using DAL;
using Modelo;
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
    public partial class frmInventarioFiltrar : Form
    {
        public string busca;

        int idUnidade;
        public frmInventarioFiltrar(int id)
        {

            idUnidade = id;
            InitializeComponent();
        }

        private void frmInventarioFiltrar_Load(object sender, EventArgs e)
        {

            try
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
                BLLGrupo bll = new BLLGrupo(cx);

                DataTable tabelag = bll.LocalizarGrupo();
                

                // Preenche grupos
                for (int i = 0; i < tabelag.Rows.Count; i++)
                {

                    string IdGrupo = tabelag.Rows[i]["id_grupo"].ToString();
                    string CodGrupo = tabelag.Rows[i]["codigo_grupo"].ToString();
                    string NomeGrupo = tabelag.Rows[i]["nome_grupo"].ToString();
                    

                    String[] P = new string[] { false.ToString(), CodGrupo, NomeGrupo, IdGrupo };
                    this.dataGridView1.Rows.Add(P);
                    
                }
                               
            }
            catch
            {
                MessageBox.Show("Sem grupos cadastrados.");
            }

        }


        private void btSalvar_Click(object sender, EventArgs e)
        {
            busca = "select p.cod_produto, p.nome_produto, p.marca_produto, p.modelo_produto " +
                " from produto p inner join grupo g on p.id_grupo = g.id_grupo where ";


            string prefix = "";
            int quantFiltros = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {

                if(quantFiltros >0 )
                {
                    prefix = " or ";
                }

                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value) == true)
                {
                    busca = busca + prefix+ " p.id_grupo = " + dataGridView1.Rows[i].Cells[3].Value.ToString();
                    quantFiltros++;
                }

            }


            busca = busca + " group by p.cod_produto, p.nome_produto, p.marca_produto, p.modelo_produto;";

            this.Close();

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {

                    dataGridView1.Rows[i].Cells[0].Value = true;
                    
                }

            }
            else
            {

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {

                    dataGridView1.Rows[i].Cells[0].Value = false;

                }


            }



        }
    }
}
