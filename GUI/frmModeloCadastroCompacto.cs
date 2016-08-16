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
    public partial class frmModeloCadastroCompacto : Form
    {
        public String operacao;
        public frmModeloCadastroCompacto()
        {
            InitializeComponent();
        }

        private void frmModeloCadastroCompacto_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
        }

        private void alteraBotoes(int op)
        {
            btSalvar.Enabled = false;
            btExcluir.Enabled = false;
            btEditar.Enabled = false;
            pnCadastro.Enabled = true;


            if (op == 1)
            {
                btSalvar.Enabled = true;

            }

            if (op == 2)
            {

                btSalvar.Enabled = true;

            }

            if (op == 3)
            {
                btEditar.Enabled = true;
                btExcluir.Enabled = true;
                pnCadastro.Enabled = false;
            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {

        }
    }
}
