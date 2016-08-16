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
    public partial class frmModeloFormularioDeCadastro : Form
    {

        public String operacao;

        public frmModeloFormularioDeCadastro()
        {
            InitializeComponent();
        }

        public void alteraBotoes(int op)
        {
            // op = operações feitas com os botões
            // 1 - inserir/localizar
            // 2 - inserir/alterar
            // 2 - excluir/alterar

            pnDados.Enabled = false;
            btInserir.Enabled = false;
            btAlterar.Enabled = false;
            btLocalizar.Enabled = false;
            btExcluir.Enabled = false;
            btSalvar.Enabled = false;

            if(op == 1)
            {
                btInserir.Enabled = true;
                btLocalizar.Enabled = true;
            }

            if (op == 2)
            {
                pnDados.Enabled = true;
                btSalvar.Enabled = true;

            }

            if (op == 3)
            {
                btAlterar.Enabled = true;
                btExcluir.Enabled = true;

            }


        }

        private void frmModeloFormularioDeCadastro_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
