namespace GUI
{
    partial class frmCadastroFornecedores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroFornecedores));
            this.lbFantasia = new System.Windows.Forms.Label();
            this.txtFantasia = new System.Windows.Forms.TextBox();
            this.lbRazao = new System.Windows.Forms.Label();
            this.txtRazao = new System.Windows.Forms.TextBox();
            this.lbTelefone1 = new System.Windows.Forms.Label();
            this.txtFone1 = new System.Windows.Forms.MaskedTextBox();
            this.lbTelefone2 = new System.Windows.Forms.Label();
            this.txtFone2 = new System.Windows.Forms.MaskedTextBox();
            this.txtEmail1 = new System.Windows.Forms.TextBox();
            this.lbEmail1 = new System.Windows.Forms.Label();
            this.lbEmail2 = new System.Windows.Forms.Label();
            this.txtEmail2 = new System.Windows.Forms.TextBox();
            this.txtCep = new System.Windows.Forms.MaskedTextBox();
            this.lbCep = new System.Windows.Forms.Label();
            this.txtContato = new System.Windows.Forms.TextBox();
            this.lbContato = new System.Windows.Forms.Label();
            this.lbLogradouro = new System.Windows.Forms.Label();
            this.txtLogradouro = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lbNumero = new System.Windows.Forms.Label();
            this.lbComplemento = new System.Windows.Forms.Label();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.lbBairro = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.lbCidade = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.lbEstado = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.lbCnpj = new System.Windows.Forms.Label();
            this.txtCnpj = new System.Windows.Forms.MaskedTextBox();
            this.btCep = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.pnDados.SuspendLayout();
            this.pnBotoes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnDados
            // 
            this.pnDados.Controls.Add(this.txtcodigo);
            this.pnDados.Controls.Add(this.groupBox1);
            this.pnDados.Size = new System.Drawing.Size(496, 388);
            // 
            // pnBotoes
            // 
            this.pnBotoes.Size = new System.Drawing.Size(496, 77);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(413, 3);
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Enabled = false;
            this.btSalvar.Location = new System.Drawing.Point(332, 3);
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Enabled = false;
            this.btExcluir.Location = new System.Drawing.Point(251, 3);
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btAlterar
            // 
            this.btAlterar.Enabled = false;
            this.btAlterar.Location = new System.Drawing.Point(170, 3);
            this.btAlterar.Click += new System.EventHandler(this.btAlterar_Click);
            // 
            // btLocalizar
            // 
            this.btLocalizar.Location = new System.Drawing.Point(89, 3);
            this.btLocalizar.Click += new System.EventHandler(this.btLocalizar_Click);
            // 
            // btInserir
            // 
            this.btInserir.Location = new System.Drawing.Point(8, 3);
            this.btInserir.Click += new System.EventHandler(this.btInserir_Click);
            // 
            // lbFantasia
            // 
            this.lbFantasia.AutoSize = true;
            this.lbFantasia.Location = new System.Drawing.Point(6, 26);
            this.lbFantasia.Name = "lbFantasia";
            this.lbFantasia.Size = new System.Drawing.Size(50, 13);
            this.lbFantasia.TabIndex = 0;
            this.lbFantasia.Text = "Fantasia:";
            // 
            // txtFantasia
            // 
            this.txtFantasia.Location = new System.Drawing.Point(81, 19);
            this.txtFantasia.Name = "txtFantasia";
            this.txtFantasia.Size = new System.Drawing.Size(393, 20);
            this.txtFantasia.TabIndex = 1;
            // 
            // lbRazao
            // 
            this.lbRazao.AutoSize = true;
            this.lbRazao.Location = new System.Drawing.Point(6, 62);
            this.lbRazao.Name = "lbRazao";
            this.lbRazao.Size = new System.Drawing.Size(73, 13);
            this.lbRazao.TabIndex = 0;
            this.lbRazao.Text = "Razão Social:";
            // 
            // txtRazao
            // 
            this.txtRazao.Location = new System.Drawing.Point(81, 55);
            this.txtRazao.Name = "txtRazao";
            this.txtRazao.Size = new System.Drawing.Size(393, 20);
            this.txtRazao.TabIndex = 2;
            // 
            // lbTelefone1
            // 
            this.lbTelefone1.AutoSize = true;
            this.lbTelefone1.Location = new System.Drawing.Point(6, 98);
            this.lbTelefone1.Name = "lbTelefone1";
            this.lbTelefone1.Size = new System.Drawing.Size(61, 13);
            this.lbTelefone1.TabIndex = 2;
            this.lbTelefone1.Text = "Telefone 1:";
            // 
            // txtFone1
            // 
            this.txtFone1.Location = new System.Drawing.Point(81, 91);
            this.txtFone1.Mask = "(99) 0000-00000";
            this.txtFone1.Name = "txtFone1";
            this.txtFone1.PromptChar = ' ';
            this.txtFone1.Size = new System.Drawing.Size(100, 20);
            this.txtFone1.TabIndex = 3;
            // 
            // lbTelefone2
            // 
            this.lbTelefone2.AutoSize = true;
            this.lbTelefone2.Location = new System.Drawing.Point(187, 95);
            this.lbTelefone2.Name = "lbTelefone2";
            this.lbTelefone2.Size = new System.Drawing.Size(61, 13);
            this.lbTelefone2.TabIndex = 2;
            this.lbTelefone2.Text = "Telefone 2:";
            // 
            // txtFone2
            // 
            this.txtFone2.Location = new System.Drawing.Point(254, 91);
            this.txtFone2.Mask = "(99) 0000-00000";
            this.txtFone2.Name = "txtFone2";
            this.txtFone2.PromptChar = ' ';
            this.txtFone2.Size = new System.Drawing.Size(100, 20);
            this.txtFone2.TabIndex = 4;
            // 
            // txtEmail1
            // 
            this.txtEmail1.Location = new System.Drawing.Point(81, 127);
            this.txtEmail1.Name = "txtEmail1";
            this.txtEmail1.Size = new System.Drawing.Size(134, 20);
            this.txtEmail1.TabIndex = 5;
            // 
            // lbEmail1
            // 
            this.lbEmail1.AutoSize = true;
            this.lbEmail1.Location = new System.Drawing.Point(6, 134);
            this.lbEmail1.Name = "lbEmail1";
            this.lbEmail1.Size = new System.Drawing.Size(74, 13);
            this.lbEmail1.TabIndex = 0;
            this.lbEmail1.Text = "Email Compra:";
            // 
            // lbEmail2
            // 
            this.lbEmail2.AutoSize = true;
            this.lbEmail2.Location = new System.Drawing.Point(226, 134);
            this.lbEmail2.Name = "lbEmail2";
            this.lbEmail2.Size = new System.Drawing.Size(75, 13);
            this.lbEmail2.TabIndex = 0;
            this.lbEmail2.Text = "Email Contato:";
            // 
            // txtEmail2
            // 
            this.txtEmail2.Location = new System.Drawing.Point(307, 127);
            this.txtEmail2.Name = "txtEmail2";
            this.txtEmail2.Size = new System.Drawing.Size(131, 20);
            this.txtEmail2.TabIndex = 6;
            // 
            // txtCep
            // 
            this.txtCep.Location = new System.Drawing.Point(81, 199);
            this.txtCep.Mask = "00000-000";
            this.txtCep.Name = "txtCep";
            this.txtCep.PromptChar = ' ';
            this.txtCep.Size = new System.Drawing.Size(59, 20);
            this.txtCep.TabIndex = 9;
            // 
            // lbCep
            // 
            this.lbCep.AutoSize = true;
            this.lbCep.Location = new System.Drawing.Point(6, 206);
            this.lbCep.Name = "lbCep";
            this.lbCep.Size = new System.Drawing.Size(31, 13);
            this.lbCep.TabIndex = 0;
            this.lbCep.Text = "CEP:";
            // 
            // txtContato
            // 
            this.txtContato.Location = new System.Drawing.Point(81, 163);
            this.txtContato.Name = "txtContato";
            this.txtContato.Size = new System.Drawing.Size(158, 20);
            this.txtContato.TabIndex = 7;
            // 
            // lbContato
            // 
            this.lbContato.AutoSize = true;
            this.lbContato.Location = new System.Drawing.Point(6, 170);
            this.lbContato.Name = "lbContato";
            this.lbContato.Size = new System.Drawing.Size(47, 13);
            this.lbContato.TabIndex = 0;
            this.lbContato.Text = "Contato:";
            // 
            // lbLogradouro
            // 
            this.lbLogradouro.AutoSize = true;
            this.lbLogradouro.Location = new System.Drawing.Point(181, 206);
            this.lbLogradouro.Name = "lbLogradouro";
            this.lbLogradouro.Size = new System.Drawing.Size(64, 13);
            this.lbLogradouro.TabIndex = 0;
            this.lbLogradouro.Text = "Logradouro:";
            // 
            // txtLogradouro
            // 
            this.txtLogradouro.Location = new System.Drawing.Point(248, 199);
            this.txtLogradouro.Name = "txtLogradouro";
            this.txtLogradouro.Size = new System.Drawing.Size(213, 20);
            this.txtLogradouro.TabIndex = 11;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(81, 235);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(59, 20);
            this.txtNumero.TabIndex = 12;
            // 
            // lbNumero
            // 
            this.lbNumero.AutoSize = true;
            this.lbNumero.Location = new System.Drawing.Point(6, 242);
            this.lbNumero.Name = "lbNumero";
            this.lbNumero.Size = new System.Drawing.Size(47, 13);
            this.lbNumero.TabIndex = 0;
            this.lbNumero.Text = "Numero:";
            // 
            // lbComplemento
            // 
            this.lbComplemento.AutoSize = true;
            this.lbComplemento.Location = new System.Drawing.Point(146, 242);
            this.lbComplemento.Name = "lbComplemento";
            this.lbComplemento.Size = new System.Drawing.Size(74, 13);
            this.lbComplemento.TabIndex = 0;
            this.lbComplemento.Text = "Complemento:";
            // 
            // txtComplemento
            // 
            this.txtComplemento.Location = new System.Drawing.Point(226, 235);
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(235, 20);
            this.txtComplemento.TabIndex = 13;
            // 
            // lbBairro
            // 
            this.lbBairro.AutoSize = true;
            this.lbBairro.Location = new System.Drawing.Point(6, 278);
            this.lbBairro.Name = "lbBairro";
            this.lbBairro.Size = new System.Drawing.Size(37, 13);
            this.lbBairro.TabIndex = 0;
            this.lbBairro.Text = "Bairro:";
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(81, 271);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(119, 20);
            this.txtBairro.TabIndex = 14;
            // 
            // lbCidade
            // 
            this.lbCidade.AutoSize = true;
            this.lbCidade.Location = new System.Drawing.Point(208, 278);
            this.lbCidade.Name = "lbCidade";
            this.lbCidade.Size = new System.Drawing.Size(43, 13);
            this.lbCidade.TabIndex = 0;
            this.lbCidade.Text = "Cidade:";
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(257, 271);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(105, 20);
            this.txtCidade.TabIndex = 15;
            // 
            // lbEstado
            // 
            this.lbEstado.AutoSize = true;
            this.lbEstado.Location = new System.Drawing.Point(368, 278);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(43, 13);
            this.lbEstado.TabIndex = 0;
            this.lbEstado.Text = "Estado:";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(417, 271);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(44, 20);
            this.txtEstado.TabIndex = 16;
            // 
            // lbCnpj
            // 
            this.lbCnpj.AutoSize = true;
            this.lbCnpj.Location = new System.Drawing.Point(245, 170);
            this.lbCnpj.Name = "lbCnpj";
            this.lbCnpj.Size = new System.Drawing.Size(31, 13);
            this.lbCnpj.TabIndex = 0;
            this.lbCnpj.Text = "Cnpj:";
            // 
            // txtCnpj
            // 
            this.txtCnpj.Location = new System.Drawing.Point(282, 163);
            this.txtCnpj.Mask = "00.000.000/0000-00";
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.PromptChar = ' ';
            this.txtCnpj.Size = new System.Drawing.Size(126, 20);
            this.txtCnpj.TabIndex = 8;
            // 
            // btCep
            // 
            this.btCep.Image = global::GUI.Properties.Resources.magnifying_glass_2x;
            this.btCep.Location = new System.Drawing.Point(146, 196);
            this.btCep.Name = "btCep";
            this.btCep.Size = new System.Drawing.Size(29, 23);
            this.btCep.TabIndex = 10;
            this.btCep.UseVisualStyleBackColor = true;
            this.btCep.Click += new System.EventHandler(this.btCep_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbFantasia);
            this.groupBox1.Controls.Add(this.txtEstado);
            this.groupBox1.Controls.Add(this.btCep);
            this.groupBox1.Controls.Add(this.lbEstado);
            this.groupBox1.Controls.Add(this.txtCidade);
            this.groupBox1.Controls.Add(this.lbCidade);
            this.groupBox1.Controls.Add(this.txtFantasia);
            this.groupBox1.Controls.Add(this.txtBairro);
            this.groupBox1.Controls.Add(this.txtCep);
            this.groupBox1.Controls.Add(this.txtComplemento);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.lbBairro);
            this.groupBox1.Controls.Add(this.txtCnpj);
            this.groupBox1.Controls.Add(this.lbRazao);
            this.groupBox1.Controls.Add(this.txtLogradouro);
            this.groupBox1.Controls.Add(this.lbComplemento);
            this.groupBox1.Controls.Add(this.lbNumero);
            this.groupBox1.Controls.Add(this.txtFone2);
            this.groupBox1.Controls.Add(this.txtContato);
            this.groupBox1.Controls.Add(this.txtEmail2);
            this.groupBox1.Controls.Add(this.lbCep);
            this.groupBox1.Controls.Add(this.lbLogradouro);
            this.groupBox1.Controls.Add(this.txtRazao);
            this.groupBox1.Controls.Add(this.lbTelefone1);
            this.groupBox1.Controls.Add(this.txtEmail1);
            this.groupBox1.Controls.Add(this.lbTelefone2);
            this.groupBox1.Controls.Add(this.txtFone1);
            this.groupBox1.Controls.Add(this.lbCnpj);
            this.groupBox1.Controls.Add(this.lbEmail1);
            this.groupBox1.Controls.Add(this.lbContato);
            this.groupBox1.Controls.Add(this.lbEmail2);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 307);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados do fornecedor";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtcodigo
            // 
            this.txtcodigo.Location = new System.Drawing.Point(8, 317);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.ReadOnly = true;
            this.txtcodigo.Size = new System.Drawing.Size(100, 20);
            this.txtcodigo.TabIndex = 18;
            this.txtcodigo.Visible = false;
            // 
            // frmCadastroFornecedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(519, 561);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCadastroFornecedores";
            this.Text = "Cadastro de Fornecedores";
            this.Load += new System.EventHandler(this.frmCadastroFornecedores_Load);
            this.pnDados.ResumeLayout(false);
            this.pnDados.PerformLayout();
            this.pnBotoes.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtRazao;
        private System.Windows.Forms.TextBox txtFantasia;
        private System.Windows.Forms.Label lbRazao;
        private System.Windows.Forms.Label lbFantasia;
        private System.Windows.Forms.MaskedTextBox txtFone1;
        private System.Windows.Forms.Label lbTelefone1;
        private System.Windows.Forms.MaskedTextBox txtFone2;
        private System.Windows.Forms.MaskedTextBox txtCep;
        private System.Windows.Forms.Label lbTelefone2;
        private System.Windows.Forms.TextBox txtEmail2;
        private System.Windows.Forms.TextBox txtContato;
        private System.Windows.Forms.TextBox txtEmail1;
        private System.Windows.Forms.Label lbEmail2;
        private System.Windows.Forms.Label lbCep;
        private System.Windows.Forms.Label lbContato;
        private System.Windows.Forms.Label lbEmail1;
        private System.Windows.Forms.TextBox txtLogradouro;
        private System.Windows.Forms.Label lbLogradouro;
        private System.Windows.Forms.MaskedTextBox txtCnpj;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtComplemento;
        private System.Windows.Forms.Label lbCnpj;
        private System.Windows.Forms.Label lbEstado;
        private System.Windows.Forms.Label lbCidade;
        private System.Windows.Forms.Label lbBairro;
        private System.Windows.Forms.Label lbNumero;
        private System.Windows.Forms.Label lbComplemento;
        private System.Windows.Forms.Button btCep;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtcodigo;
    }
}
