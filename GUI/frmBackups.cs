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
    public partial class frmBackups : Form
    {
        private int idUsuario = 0;
        private int permissaoUsuario = 0;
        private int idUnidade = 0;
       
        public frmBackups(int id)
        {
            idUsuario = id;
            InitializeComponent();
        }

        private void frmBackups_Load(object sender, EventArgs e)
        {

            DALConexao con = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUsuario bllu = new BLLUsuario(con);

            DTOUsuario modelou = bllu.CarregaModeloUsuario(idUsuario);

            idUnidade = modelou.IdUnidade;
            permissaoUsuario = modelou.PermissaoUsuario;
            this.Text = this.Text + " - " + modelou.LoginUsuario.ToString() + " (" + modelou.IniciaisUsuario.ToString() + ")";

            DALConexao cx = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLUnidade bllun = new BLLUnidade(cx);
            cbUnidade.DataSource = bllun.Localizar("");
            cbUnidade.DisplayMember = "cod_unidade";
            cbUnidade.ValueMember = "id_unidade";
cbUnidade.Text = modelou.IdUnidade.ToString("00");
            if (modelou.PermissaoUsuario < 4)
            {

                cbUnidade.Enabled = false;
            }


            DALConexao cxg = new DALConexao(DadosDaConexao.StringDaConexao);
            BLLGrupo bllg = new BLLGrupo(cxg);
            cbGrupos.DataSource = bllg.Localizar("");
            cbGrupos.DisplayMember = "nome_grupo";
            cbGrupos.ValueMember = "id_grupo";
            cbGrupos.Text = "";

            lbTituloHelp.Text = "Ajuda";
            lbTextHelp.Text = "O Backup de produtos é uma solução que define qual produto é usado na falta de um produto principal.  " + Environment.NewLine + "Por exemplo:" + Environment.NewLine +
                "Na falta do produto 'Garfo de buffet Continental' usamos o 'Garfo de bufet Cosmos'.";




        }

        private void btHelp_Click(object sender, EventArgs e)
        {
            if(pnHelp.Visible == true)
            {
                pnHelp.Visible = false;
            }
            else
            {
                pnHelp.Visible = true;
            }
        }

        private void btHelp_MouseHover(object sender, EventArgs e)
        {

            ToolTip Help = new ToolTip();
            Help.Show("Tooltip text goes here", btHelp);
        }
    }



}

