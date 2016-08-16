namespace GUI
{
    partial class frmCMVCadastroProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCMVCadastroProduto));
            this.lbCod = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.cbUm = new System.Windows.Forms.ComboBox();
            this.lbUnMed = new System.Windows.Forms.Label();
            this.lbLista = new System.Windows.Forms.Label();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvExcel = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.btColarDados = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCod
            // 
            this.lbCod.AutoSize = true;
            this.lbCod.Location = new System.Drawing.Point(9, 70);
            this.lbCod.Name = "lbCod";
            this.lbCod.Size = new System.Drawing.Size(103, 13);
            this.lbCod.TabIndex = 0;
            this.lbCod.Text = "Código (sem pontos)";
            // 
            // txtCod
            // 
            this.txtCod.Location = new System.Drawing.Point(12, 87);
            this.txtCod.MaxLength = 8;
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(115, 20);
            this.txtCod.TabIndex = 1;
            this.txtCod.Validating += new System.ComponentModel.CancelEventHandler(this.txtCod_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(12, 37);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(264, 20);
            this.txtNome.TabIndex = 1;
            // 
            // cbUm
            // 
            this.cbUm.FormattingEnabled = true;
            this.cbUm.Items.AddRange(new object[] {
            "KG",
            "L",
            "UN",
            "PC",
            "CX"});
            this.cbUm.Location = new System.Drawing.Point(133, 86);
            this.cbUm.Name = "cbUm";
            this.cbUm.Size = new System.Drawing.Size(71, 21);
            this.cbUm.TabIndex = 2;
            // 
            // lbUnMed
            // 
            this.lbUnMed.AutoSize = true;
            this.lbUnMed.Location = new System.Drawing.Point(130, 70);
            this.lbUnMed.Name = "lbUnMed";
            this.lbUnMed.Size = new System.Drawing.Size(30, 13);
            this.lbUnMed.TabIndex = 0;
            this.lbUnMed.Text = "U.M.";
            // 
            // lbLista
            // 
            this.lbLista.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLista.Location = new System.Drawing.Point(12, 117);
            this.lbLista.Name = "lbLista";
            this.lbLista.Size = new System.Drawing.Size(264, 23);
            this.lbLista.TabIndex = 3;
            this.lbLista.Text = "LISTA DE PRODUTOS A CADASTRAR";
            this.lbLista.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod,
            this.unidade});
            this.dgvLista.Location = new System.Drawing.Point(12, 143);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.RowHeadersVisible = false;
            this.dgvLista.Size = new System.Drawing.Size(264, 183);
            this.dgvLista.TabIndex = 4;
            // 
            // cod
            // 
            this.cod.HeaderText = "Cod";
            this.cod.Name = "cod";
            this.cod.ReadOnly = true;
            this.cod.Width = 150;
            // 
            // unidade
            // 
            this.unidade.HeaderText = "Uni.";
            this.unidade.Name = "unidade";
            this.unidade.ReadOnly = true;
            this.unidade.Width = 90;
            // 
            // button1
            // 
            this.button1.Image = global::GUI.Properties.Resources.flash_2x;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(165, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 24);
            this.button1.TabIndex = 7;
            this.button1.Text = "Importar do excel";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Image = global::GUI.Properties.Resources.circle_check_2x;
            this.btSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSalvar.Location = new System.Drawing.Point(210, 84);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(66, 24);
            this.btSalvar.TabIndex = 7;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btColarDados);
            this.panel1.Controls.Add(this.dgvExcel);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 319);
            this.panel1.TabIndex = 8;
            this.panel1.Visible = false;
            // 
            // dgvExcel
            // 
            this.dgvExcel.AllowUserToAddRows = false;
            this.dgvExcel.AllowUserToDeleteRows = false;
            this.dgvExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcel.Location = new System.Drawing.Point(4, 63);
            this.dgvExcel.Name = "dgvExcel";
            this.dgvExcel.ReadOnly = true;
            this.dgvExcel.RowHeadersVisible = false;
            this.dgvExcel.Size = new System.Drawing.Size(263, 253);
            this.dgvExcel.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Image = global::GUI.Properties.Resources.circle_check_2x;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(201, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 24);
            this.button2.TabIndex = 7;
            this.button2.Text = "Salvar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btColarDados
            // 
            this.btColarDados.Location = new System.Drawing.Point(4, 13);
            this.btColarDados.Name = "btColarDados";
            this.btColarDados.Size = new System.Drawing.Size(75, 23);
            this.btColarDados.TabIndex = 8;
            this.btColarDados.Text = "Colar dados";
            this.btColarDados.UseVisualStyleBackColor = true;
            this.btColarDados.Click += new System.EventHandler(this.btColarDados_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "COD CIGAM     |                NOME                  |     U.M.";
            // 
            // frmCMVCadastroProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 338);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.lbLista);
            this.Controls.Add(this.cbUm);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtCod);
            this.Controls.Add(this.lbUnMed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbCod);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCMVCadastroProduto";
            this.Text = "Cadastro de produtos";
            this.Load += new System.EventHandler(this.frmCMVCadastroProduto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCod;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.ComboBox cbUm;
        private System.Windows.Forms.Label lbUnMed;
        private System.Windows.Forms.Label lbLista;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidade;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvExcel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btColarDados;
        private System.Windows.Forms.Label label1;
    }
}