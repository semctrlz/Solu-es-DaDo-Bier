namespace GUI
{
    partial class frmConsultaMovimento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaMovimento));
            this.lbNumeroMov = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtData = new System.Windows.Forms.MaskedTextBox();
            this.lbDataMov = new System.Windows.Forms.Label();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.btCancelar = new System.Windows.Forms.Button();
            this.cbUnidade = new System.Windows.Forms.ComboBox();
            this.btConsulta = new System.Windows.Forms.Button();
            this.txtRegistro = new System.Windows.Forms.TextBox();
            this.lbUnidade = new System.Windows.Forms.Label();
            this.lbCodProduto = new System.Windows.Forms.Label();
            this.txtQuant = new System.Windows.Forms.TextBox();
            this.lbQuant = new System.Windows.Forms.Label();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.txtCustoUnitario = new System.Windows.Forms.TextBox();
            this.lbCustoUnit = new System.Windows.Forms.Label();
            this.txtCustoTotal = new System.Windows.Forms.TextBox();
            this.lbCustoTotal = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataCriacao = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataDoc = new System.Windows.Forms.MaskedTextBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTipoMov = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNumeroMov
            // 
            this.lbNumeroMov.AutoSize = true;
            this.lbNumeroMov.Location = new System.Drawing.Point(82, 25);
            this.lbNumeroMov.Name = "lbNumeroMov";
            this.lbNumeroMov.Size = new System.Drawing.Size(44, 13);
            this.lbNumeroMov.TabIndex = 0;
            this.lbNumeroMov.Text = "Número";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(81, 41);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(68, 20);
            this.txtNumero.TabIndex = 1;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(155, 41);
            this.txtData.Mask = "00/00/0000";
            this.txtData.Name = "txtData";
            this.txtData.PromptChar = ' ';
            this.txtData.Size = new System.Drawing.Size(68, 20);
            this.txtData.TabIndex = 2;
            this.txtData.ValidatingType = typeof(System.DateTime);
            // 
            // lbDataMov
            // 
            this.lbDataMov.AutoSize = true;
            this.lbDataMov.Location = new System.Drawing.Point(152, 25);
            this.lbDataMov.Name = "lbDataMov";
            this.lbDataMov.Size = new System.Drawing.Size(84, 13);
            this.lbDataMov.TabIndex = 0;
            this.lbDataMov.Text = "Data movimento";
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.maskedTextBox1);
            this.gbFiltros.Controls.Add(this.btCancelar);
            this.gbFiltros.Controls.Add(this.cbUnidade);
            this.gbFiltros.Controls.Add(this.btConsulta);
            this.gbFiltros.Controls.Add(this.txtRegistro);
            this.gbFiltros.Controls.Add(this.lbUnidade);
            this.gbFiltros.Controls.Add(this.lbNumeroMov);
            this.gbFiltros.Controls.Add(this.txtData);
            this.gbFiltros.Controls.Add(this.lbDataMov);
            this.gbFiltros.Controls.Add(this.txtNumero);
            this.gbFiltros.Controls.Add(this.lbCodProduto);
            this.gbFiltros.Controls.Add(this.txtNomeProduto);
            this.gbFiltros.Location = new System.Drawing.Point(12, 12);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(345, 111);
            this.gbFiltros.TabIndex = 3;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Image = global::GUI.Properties.Resources.x_2x;
            this.btCancelar.Location = new System.Drawing.Point(303, 37);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(24, 24);
            this.btCancelar.TabIndex = 5;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // cbUnidade
            // 
            this.cbUnidade.FormattingEnabled = true;
            this.cbUnidade.Location = new System.Drawing.Point(9, 40);
            this.cbUnidade.Name = "cbUnidade";
            this.cbUnidade.Size = new System.Drawing.Size(66, 21);
            this.cbUnidade.TabIndex = 4;
            // 
            // btConsulta
            // 
            this.btConsulta.Image = global::GUI.Properties.Resources.magnifying_glass_2x;
            this.btConsulta.Location = new System.Drawing.Point(273, 37);
            this.btConsulta.Name = "btConsulta";
            this.btConsulta.Size = new System.Drawing.Size(24, 24);
            this.btConsulta.TabIndex = 6;
            this.btConsulta.UseVisualStyleBackColor = true;
            // 
            // txtRegistro
            // 
            this.txtRegistro.Location = new System.Drawing.Point(242, 11);
            this.txtRegistro.Name = "txtRegistro";
            this.txtRegistro.Size = new System.Drawing.Size(32, 20);
            this.txtRegistro.TabIndex = 3;
            // 
            // lbUnidade
            // 
            this.lbUnidade.AutoSize = true;
            this.lbUnidade.Location = new System.Drawing.Point(6, 24);
            this.lbUnidade.Name = "lbUnidade";
            this.lbUnidade.Size = new System.Drawing.Size(47, 13);
            this.lbUnidade.TabIndex = 0;
            this.lbUnidade.Text = "Unidade";
            // 
            // lbCodProduto
            // 
            this.lbCodProduto.AutoSize = true;
            this.lbCodProduto.Location = new System.Drawing.Point(6, 69);
            this.lbCodProduto.Name = "lbCodProduto";
            this.lbCodProduto.Size = new System.Drawing.Size(44, 13);
            this.lbCodProduto.TabIndex = 0;
            this.lbCodProduto.Text = "Produto";
            // 
            // txtQuant
            // 
            this.txtQuant.Location = new System.Drawing.Point(17, 188);
            this.txtQuant.Name = "txtQuant";
            this.txtQuant.Size = new System.Drawing.Size(68, 20);
            this.txtQuant.TabIndex = 1;
            this.txtQuant.TabStop = false;
            // 
            // lbQuant
            // 
            this.lbQuant.AutoSize = true;
            this.lbQuant.Location = new System.Drawing.Point(18, 172);
            this.lbQuant.Name = "lbQuant";
            this.lbQuant.Size = new System.Drawing.Size(62, 13);
            this.lbQuant.TabIndex = 0;
            this.lbQuant.Text = "Quantidade";
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Location = new System.Drawing.Point(79, 85);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(260, 20);
            this.txtNomeProduto.TabIndex = 1;
            this.txtNomeProduto.TabStop = false;
            // 
            // txtCustoUnitario
            // 
            this.txtCustoUnitario.Location = new System.Drawing.Point(91, 188);
            this.txtCustoUnitario.Name = "txtCustoUnitario";
            this.txtCustoUnitario.Size = new System.Drawing.Size(68, 20);
            this.txtCustoUnitario.TabIndex = 1;
            this.txtCustoUnitario.TabStop = false;
            // 
            // lbCustoUnit
            // 
            this.lbCustoUnit.AutoSize = true;
            this.lbCustoUnit.Location = new System.Drawing.Point(92, 172);
            this.lbCustoUnit.Name = "lbCustoUnit";
            this.lbCustoUnit.Size = new System.Drawing.Size(73, 13);
            this.lbCustoUnit.TabIndex = 0;
            this.lbCustoUnit.Text = "Custo Unitário";
            // 
            // txtCustoTotal
            // 
            this.txtCustoTotal.Location = new System.Drawing.Point(165, 188);
            this.txtCustoTotal.Name = "txtCustoTotal";
            this.txtCustoTotal.Size = new System.Drawing.Size(68, 20);
            this.txtCustoTotal.TabIndex = 1;
            this.txtCustoTotal.TabStop = false;
            // 
            // lbCustoTotal
            // 
            this.lbCustoTotal.AutoSize = true;
            this.lbCustoTotal.Location = new System.Drawing.Point(166, 172);
            this.lbCustoTotal.Name = "lbCustoTotal";
            this.lbCustoTotal.Size = new System.Drawing.Size(61, 13);
            this.lbCustoTotal.TabIndex = 0;
            this.lbCustoTotal.Text = "Custo Total";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(239, 188);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(117, 20);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.TabStop = false;
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Location = new System.Drawing.Point(236, 172);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(43, 13);
            this.lbUsuario.TabIndex = 0;
            this.lbUsuario.Text = "Usuário";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 220);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(345, 194);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(9, 85);
            this.maskedTextBox1.Mask = "00,0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.PromptChar = ' ';
            this.maskedTextBox1.Size = new System.Drawing.Size(64, 20);
            this.maskedTextBox1.TabIndex = 5;
            this.maskedTextBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data criação";
            // 
            // txtDataCriacao
            // 
            this.txtDataCriacao.Location = new System.Drawing.Point(17, 149);
            this.txtDataCriacao.Mask = "00/00/0000";
            this.txtDataCriacao.Name = "txtDataCriacao";
            this.txtDataCriacao.PromptChar = ' ';
            this.txtDataCriacao.Size = new System.Drawing.Size(68, 20);
            this.txtDataCriacao.TabIndex = 2;
            this.txtDataCriacao.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Data doc.";
            // 
            // txtDataDoc
            // 
            this.txtDataDoc.Location = new System.Drawing.Point(91, 149);
            this.txtDataDoc.Mask = "00/00/0000";
            this.txtDataDoc.Name = "txtDataDoc";
            this.txtDataDoc.PromptChar = ' ';
            this.txtDataDoc.Size = new System.Drawing.Size(68, 20);
            this.txtDataDoc.TabIndex = 2;
            this.txtDataDoc.ValidatingType = typeof(System.DateTime);
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(165, 149);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(68, 20);
            this.txtDocumento.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Documento";
            // 
            // txtTipoMov
            // 
            this.txtTipoMov.Location = new System.Drawing.Point(239, 149);
            this.txtTipoMov.Name = "txtTipoMov";
            this.txtTipoMov.Size = new System.Drawing.Size(117, 20);
            this.txtTipoMov.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tipo de mov.";
            // 
            // frmConsultaMovimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 426);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gbFiltros);
            this.Controls.Add(this.lbUsuario);
            this.Controls.Add(this.lbCustoTotal);
            this.Controls.Add(this.lbCustoUnit);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbQuant);
            this.Controls.Add(this.txtDataDoc);
            this.Controls.Add(this.txtTipoMov);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.txtDataCriacao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCustoTotal);
            this.Controls.Add(this.txtCustoUnitario);
            this.Controls.Add(this.txtQuant);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsultaMovimento";
            this.Text = "Consulta movimentos";
            this.Load += new System.EventHandler(this.frmConsultaMovimento_Load);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNumeroMov;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.MaskedTextBox txtData;
        private System.Windows.Forms.Label lbDataMov;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.ComboBox cbUnidade;
        private System.Windows.Forms.TextBox txtRegistro;
        private System.Windows.Forms.Label lbUnidade;
        private System.Windows.Forms.Label lbCodProduto;
        private System.Windows.Forms.TextBox txtQuant;
        private System.Windows.Forms.Label lbQuant;
        private System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.TextBox txtCustoUnitario;
        private System.Windows.Forms.Label lbCustoUnit;
        private System.Windows.Forms.TextBox txtCustoTotal;
        private System.Windows.Forms.Label lbCustoTotal;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btConsulta;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtDataCriacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtDataDoc;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTipoMov;
        private System.Windows.Forms.Label label4;
    }
}