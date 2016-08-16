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
    public partial class frmConsultaMovimento : Form
    {
        int idUsuario;
        string op = "inicial";

        public frmConsultaMovimento(int usuario)
        {
            idUsuario = usuario;
            InitializeComponent();
        }

        private void frmConsultaMovimento_Load(object sender, EventArgs e)
        {
            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(idUsuario);

            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Busca()
        {

            /*
             SELECT m.id_unidade, m.id_mov, m.data_mov, p.cod_produto, p.nome_produto,
            m.data_criacao_mov, m.data_nf_mov, m.nf_mov, m.tipo_mov, m.quant_mov, m.custo_unitario_mov, u.login_usuario, f.razao_fornecedor, (m.quant_mov * m.custo_unitario_mov) as custo_total
            FROM MOVIMENTACAO m inner join produto p on m.id_produto = p.id_produto
            inner join usuario u on m.id_usuario = u.id_usuario
            inner join fornecedor f on m.id_fornecedor = f.id_fornecedor;

            */ 
        }



    }
}
