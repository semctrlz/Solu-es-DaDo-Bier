namespace GUI
{
    partial class frmCMVExcessoesCusto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCMVExcessoesCusto));
            this.lbExplicações = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAcao = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.dgvExcessoes = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_op = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.del = new System.Windows.Forms.DataGridViewImageColumn();
            this.btAdd = new System.Windows.Forms.Button();
            this.txtTipoOp = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcessoes)).BeginInit();
            this.SuspendLayout();
            // 
            // lbExplicações
            // 
            this.lbExplicações.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbExplicações.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExplicações.Location = new System.Drawing.Point(12, 9);
            this.lbExplicações.Name = "lbExplicações";
            this.lbExplicações.Size = new System.Drawing.Size(356, 56);
            this.lbExplicações.TabIndex = 0;
            this.lbExplicações.Text = "O que não considerar na hora de inserir os custos e o que considerar com sinal in" +
    "vertido.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo Op.";
            // 
            // cbAcao
            // 
            this.cbAcao.FormattingEnabled = true;
            this.cbAcao.Items.AddRange(new object[] {
            "Ignorar",
            "Alterar sinal"});
            this.cbAcao.Location = new System.Drawing.Point(69, 91);
            this.cbAcao.Name = "cbAcao";
            this.cbAcao.Size = new System.Drawing.Size(95, 21);
            this.cbAcao.TabIndex = 1;
            this.cbAcao.Enter += new System.EventHandler(this.cbAcao_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ação";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Obs.";
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(171, 91);
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(167, 20);
            this.txtObs.TabIndex = 2;
            this.txtObs.Enter += new System.EventHandler(this.txtObs_Enter);
            // 
            // dgvExcessoes
            // 
            this.dgvExcessoes.AllowUserToAddRows = false;
            this.dgvExcessoes.AllowUserToDeleteRows = false;
            this.dgvExcessoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcessoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.tipo_op,
            this.acao,
            this.obs,
            this.del});
            this.dgvExcessoes.Location = new System.Drawing.Point(12, 119);
            this.dgvExcessoes.Name = "dgvExcessoes";
            this.dgvExcessoes.ReadOnly = true;
            this.dgvExcessoes.RowHeadersVisible = false;
            this.dgvExcessoes.Size = new System.Drawing.Size(356, 184);
            this.dgvExcessoes.TabIndex = 8;
            this.dgvExcessoes.TabStop = false;
            this.dgvExcessoes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExcessoes_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // tipo_op
            // 
            this.tipo_op.HeaderText = "Tipo Op.";
            this.tipo_op.Name = "tipo_op";
            this.tipo_op.ReadOnly = true;
            this.tipo_op.Width = 75;
            // 
            // acao
            // 
            this.acao.HeaderText = "Ação";
            this.acao.Name = "acao";
            this.acao.ReadOnly = true;
            // 
            // obs
            // 
            this.obs.HeaderText = "Obs.";
            this.obs.Name = "obs";
            this.obs.ReadOnly = true;
            this.obs.Width = 135;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::GUI.Properties.Resources.trash_2x;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 26;
            // 
            // del
            // 
            this.del.HeaderText = "";
            this.del.Image = global::GUI.Properties.Resources.trash_2x;
            this.del.Name = "del";
            this.del.ReadOnly = true;
            this.del.Width = 26;
            // 
            // btAdd
            // 
            this.btAdd.Image = global::GUI.Properties.Resources.arrow_circle_bottom_2x;
            this.btAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAdd.Location = new System.Drawing.Point(344, 89);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(24, 24);
            this.btAdd.TabIndex = 3;
            this.btAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // txtTipoOp
            // 
            this.txtTipoOp.Location = new System.Drawing.Point(12, 91);
            this.txtTipoOp.Mask = "aaa\\.aa";
            this.txtTipoOp.Name = "txtTipoOp";
            this.txtTipoOp.PromptChar = ' ';
            this.txtTipoOp.Size = new System.Drawing.Size(51, 20);
            this.txtTipoOp.TabIndex = 0;
            this.txtTipoOp.Enter += new System.EventHandler(this.txtTipoOp_Enter);
            // 
            // frmCMVExcessoesCusto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 315);
            this.Controls.Add(this.txtTipoOp);
            this.Controls.Add(this.dgvExcessoes);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbAcao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbExplicações);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCMVExcessoesCusto";
            this.Text = "Excessões de custo";
            this.Load += new System.EventHandler(this.frmCMVExcessoesCusto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcessoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbExplicações;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAcao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.DataGridView dgvExcessoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_op;
        private System.Windows.Forms.DataGridViewTextBoxColumn acao;
        private System.Windows.Forms.DataGridViewTextBoxColumn obs;
        private System.Windows.Forms.DataGridViewImageColumn del;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.MaskedTextBox txtTipoOp;
    }
}