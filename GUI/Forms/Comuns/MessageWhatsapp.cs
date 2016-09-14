using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsAppApi;

namespace GUI.Forms.Comuns
{
    public partial class MessageWhatsapp : Form
    {
        public MessageWhatsapp()
        {
            InitializeComponent();
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            string from = "919885149767";
            string to = "55" + txtPara.Text;
            string msg = txtMsg.Text;

            WhatsApp wa = new WhatsApp(from, "S2pRzjF5WnVcHCwGFkjJuFI2oCM=", "Vágner", false);

            wa.OnConnectSuccess += () =>
            {
                MessageBox.Show("Conectado...");
                wa.OnLoginSuccess += (phonenumber, data) => {
                    wa.SendMessage(to, msg);
                    MessageBox.Show("Mensagem enviada");
                };
            };
            wa.OnLoginFailed += (data) =>
            {
                MessageBox.Show("Falha ao conectar: {0}", data);
            };

            wa.OnLoginFailed += (ex) =>
            MessageBox.Show("Erro ao conectar");
        }
    }
}
