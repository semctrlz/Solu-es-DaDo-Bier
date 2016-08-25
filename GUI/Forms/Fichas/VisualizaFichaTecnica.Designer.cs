namespace GUI.Forms.Fichas
{
    partial class VisualizaFichaTecnica
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualizaFichaTecnica));
            this.lbTitulo = new System.Windows.Forms.Label();
            this.pn1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbPreparo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbcustoPorcao = new System.Windows.Forms.Label();
            this.lbTotalKg = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ingrediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.um = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SETORcATsCAT = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbSetor = new System.Windows.Forms.Label();
            this.lbSubcategoria = new System.Windows.Forms.Label();
            this.lbCategoria = new System.Windows.Forms.Label();
            this.lbRendimento = new System.Windows.Forms.Label();
            this.lbPeso = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.pnImagem = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pbimagem1 = new System.Windows.Forms.PictureBox();
            this.pbImagem = new System.Windows.Forms.PictureBox();
            this.pbPrint = new System.Windows.Forms.PictureBox();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.pn1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SETORcATsCAT.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnImagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbimagem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Segoe UI Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(644, 70);
            this.lbTitulo.TabIndex = 0;
            this.lbTitulo.Text = "NomeFicha";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pn1
            // 
            this.pn1.Controls.Add(this.panel4);
            this.pn1.Controls.Add(this.dgvDados);
            this.pn1.Controls.Add(this.SETORcATsCAT);
            this.pn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn1.Location = new System.Drawing.Point(0, 70);
            this.pn1.Name = "pn1";
            this.pn1.Size = new System.Drawing.Size(644, 621);
            this.pn1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 339);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(644, 282);
            this.panel4.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.lbPreparo);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 48);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(644, 234);
            this.panel6.TabIndex = 5;
            // 
            // lbPreparo
            // 
            this.lbPreparo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPreparo.Location = new System.Drawing.Point(0, 22);
            this.lbPreparo.Multiline = true;
            this.lbPreparo.Name = "lbPreparo";
            this.lbPreparo.ReadOnly = true;
            this.lbPreparo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lbPreparo.Size = new System.Drawing.Size(642, 210);
            this.lbPreparo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(642, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "MODO DE PREPARO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.tableLayoutPanel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(644, 48);
            this.panel5.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.lbTotal, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbcustoPorcao, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbTotalKg, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(642, 46);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbTotal
            // 
            this.lbTotal.BackColor = System.Drawing.SystemColors.Control;
            this.lbTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTotal.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.Location = new System.Drawing.Point(427, 19);
            this.lbTotal.Margin = new System.Windows.Forms.Padding(0);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(215, 27);
            this.lbTotal.TabIndex = 7;
            this.lbTotal.Text = "0,00";
            this.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbcustoPorcao
            // 
            this.lbcustoPorcao.BackColor = System.Drawing.SystemColors.Control;
            this.lbcustoPorcao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbcustoPorcao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbcustoPorcao.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcustoPorcao.Location = new System.Drawing.Point(213, 19);
            this.lbcustoPorcao.Margin = new System.Windows.Forms.Padding(0);
            this.lbcustoPorcao.Name = "lbcustoPorcao";
            this.lbcustoPorcao.Size = new System.Drawing.Size(214, 27);
            this.lbcustoPorcao.TabIndex = 6;
            this.lbcustoPorcao.Text = "0,00";
            this.lbcustoPorcao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTotalKg
            // 
            this.lbTotalKg.BackColor = System.Drawing.SystemColors.Control;
            this.lbTotalKg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTotalKg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTotalKg.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalKg.Location = new System.Drawing.Point(0, 19);
            this.lbTotalKg.Margin = new System.Windows.Forms.Padding(0);
            this.lbTotalKg.Name = "lbTotalKg";
            this.lbTotalKg.Size = new System.Drawing.Size(213, 27);
            this.lbTotalKg.TabIndex = 5;
            this.lbTotalKg.Text = "0,00";
            this.lbTotalKg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Gray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(427, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "CUSTO TOTAL";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(213, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "CUSTO/PORÇÃO";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "CUSTO/KG";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.AllowUserToResizeColumns = false;
            this.dgvDados.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Beige;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod,
            this.ingrediente,
            this.um,
            this.fc,
            this.quant,
            this.unit,
            this.total});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDados.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDados.Location = new System.Drawing.Point(0, 49);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(644, 290);
            this.dgvDados.TabIndex = 3;
            this.dgvDados.SelectionChanged += new System.EventHandler(this.dgvDados_SelectionChanged);
            // 
            // cod
            // 
            this.cod.HeaderText = "CODIGO";
            this.cod.Name = "cod";
            this.cod.ReadOnly = true;
            this.cod.Width = 70;
            // 
            // ingrediente
            // 
            this.ingrediente.HeaderText = "INGREDIENTE";
            this.ingrediente.Name = "ingrediente";
            this.ingrediente.ReadOnly = true;
            this.ingrediente.Width = 234;
            // 
            // um
            // 
            this.um.HeaderText = "U.M.";
            this.um.Name = "um";
            this.um.ReadOnly = true;
            this.um.Width = 50;
            // 
            // fc
            // 
            this.fc.HeaderText = "F.C.";
            this.fc.Name = "fc";
            this.fc.ReadOnly = true;
            this.fc.Width = 60;
            // 
            // quant
            // 
            this.quant.HeaderText = "QUANT.";
            this.quant.Name = "quant";
            this.quant.ReadOnly = true;
            this.quant.Width = 60;
            // 
            // unit
            // 
            this.unit.HeaderText = "$ UNIT";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            this.unit.Width = 75;
            // 
            // total
            // 
            this.total.HeaderText = "$ TOTAL";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 75;
            // 
            // SETORcATsCAT
            // 
            this.SETORcATsCAT.Controls.Add(this.tableLayoutPanel2);
            this.SETORcATsCAT.Dock = System.Windows.Forms.DockStyle.Top;
            this.SETORcATsCAT.Location = new System.Drawing.Point(0, 0);
            this.SETORcATsCAT.Name = "SETORcATsCAT";
            this.SETORcATsCAT.Size = new System.Drawing.Size(644, 49);
            this.SETORcATsCAT.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.lbSetor, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbSubcategoria, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbCategoria, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbRendimento, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbPeso, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label15, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label16, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label17, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label18, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(644, 49);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lbSetor
            // 
            this.lbSetor.BackColor = System.Drawing.SystemColors.Control;
            this.lbSetor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSetor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSetor.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSetor.Location = new System.Drawing.Point(0, 21);
            this.lbSetor.Margin = new System.Windows.Forms.Padding(0);
            this.lbSetor.Name = "lbSetor";
            this.lbSetor.Size = new System.Drawing.Size(128, 28);
            this.lbSetor.TabIndex = 10;
            this.lbSetor.Text = "0,00";
            this.lbSetor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSubcategoria
            // 
            this.lbSubcategoria.BackColor = System.Drawing.SystemColors.Control;
            this.lbSubcategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSubcategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSubcategoria.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSubcategoria.Location = new System.Drawing.Point(256, 21);
            this.lbSubcategoria.Margin = new System.Windows.Forms.Padding(0);
            this.lbSubcategoria.Name = "lbSubcategoria";
            this.lbSubcategoria.Size = new System.Drawing.Size(128, 28);
            this.lbSubcategoria.TabIndex = 9;
            this.lbSubcategoria.Text = "0,00";
            this.lbSubcategoria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCategoria
            // 
            this.lbCategoria.BackColor = System.Drawing.SystemColors.Control;
            this.lbCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCategoria.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategoria.Location = new System.Drawing.Point(128, 21);
            this.lbCategoria.Margin = new System.Windows.Forms.Padding(0);
            this.lbCategoria.Name = "lbCategoria";
            this.lbCategoria.Size = new System.Drawing.Size(128, 28);
            this.lbCategoria.TabIndex = 8;
            this.lbCategoria.Text = "0,00";
            this.lbCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbRendimento
            // 
            this.lbRendimento.BackColor = System.Drawing.SystemColors.Control;
            this.lbRendimento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbRendimento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRendimento.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRendimento.Location = new System.Drawing.Point(512, 21);
            this.lbRendimento.Margin = new System.Windows.Forms.Padding(0);
            this.lbRendimento.Name = "lbRendimento";
            this.lbRendimento.Size = new System.Drawing.Size(132, 28);
            this.lbRendimento.TabIndex = 7;
            this.lbRendimento.Text = "0,00";
            this.lbRendimento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPeso
            // 
            this.lbPeso.BackColor = System.Drawing.SystemColors.Control;
            this.lbPeso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPeso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPeso.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPeso.Location = new System.Drawing.Point(384, 21);
            this.lbPeso.Margin = new System.Windows.Forms.Padding(0);
            this.lbPeso.Name = "lbPeso";
            this.lbPeso.Size = new System.Drawing.Size(128, 28);
            this.lbPeso.TabIndex = 6;
            this.lbPeso.Text = "0,00";
            this.lbPeso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Gray;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 21);
            this.label9.TabIndex = 3;
            this.label9.Text = "SETOR";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Gray;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(128, 0);
            this.label15.Margin = new System.Windows.Forms.Padding(0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(128, 21);
            this.label15.TabIndex = 3;
            this.label15.Text = "CATEGORIA";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Gray;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(256, 0);
            this.label16.Margin = new System.Windows.Forms.Padding(0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(128, 21);
            this.label16.TabIndex = 3;
            this.label16.Text = "SUBCATEGORIA";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Gray;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(384, 0);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(128, 21);
            this.label17.TabIndex = 3;
            this.label17.Text = "PESO TOTAL";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Gray;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(512, 0);
            this.label18.Margin = new System.Windows.Forms.Padding(0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(132, 21);
            this.label18.TabIndex = 3;
            this.label18.Text = "RENDIMENTO";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnImagem
            // 
            this.pnImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnImagem.Controls.Add(this.button1);
            this.pnImagem.Controls.Add(this.pbimagem1);
            this.pnImagem.Location = new System.Drawing.Point(650, 70);
            this.pnImagem.Name = "pnImagem";
            this.pnImagem.Size = new System.Drawing.Size(634, 357);
            this.pnImagem.TabIndex = 3;
            this.pnImagem.Visible = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::GUI.Properties.Resources.x_2x;
            this.button1.Location = new System.Drawing.Point(597, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbimagem1
            // 
            this.pbimagem1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbimagem1.Location = new System.Drawing.Point(0, 0);
            this.pbimagem1.Margin = new System.Windows.Forms.Padding(0);
            this.pbimagem1.Name = "pbimagem1";
            this.pbimagem1.Size = new System.Drawing.Size(632, 355);
            this.pbimagem1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbimagem1.TabIndex = 4;
            this.pbimagem1.TabStop = false;
            // 
            // pbImagem
            // 
            this.pbImagem.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pbImagem.Image = global::GUI.Properties.Resources.camera_slr_4x;
            this.pbImagem.InitialImage = global::GUI.Properties.Resources.camera_slr_4x;
            this.pbImagem.Location = new System.Drawing.Point(603, 19);
            this.pbImagem.Margin = new System.Windows.Forms.Padding(0);
            this.pbImagem.Name = "pbImagem";
            this.pbImagem.Size = new System.Drawing.Size(32, 32);
            this.pbImagem.TabIndex = 2;
            this.pbImagem.TabStop = false;
            this.pbImagem.Click += new System.EventHandler(this.pbImagem_Click);
            // 
            // pbPrint
            // 
            this.pbPrint.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pbPrint.Image = global::GUI.Properties.Resources.print_4x;
            this.pbPrint.InitialImage = global::GUI.Properties.Resources.camera_slr_4x;
            this.pbPrint.Location = new System.Drawing.Point(7, 19);
            this.pbPrint.Margin = new System.Windows.Forms.Padding(0);
            this.pbPrint.Name = "pbPrint";
            this.pbPrint.Size = new System.Drawing.Size(32, 32);
            this.pbPrint.TabIndex = 4;
            this.pbPrint.TabStop = false;
            // 
            // VisualizaFichaTecnica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 691);
            this.Controls.Add(this.pbPrint);
            this.Controls.Add(this.pnImagem);
            this.Controls.Add(this.pbImagem);
            this.Controls.Add(this.pn1);
            this.Controls.Add(this.lbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VisualizaFichaTecnica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ficha técnica";
            this.Load += new System.EventHandler(this.VisualizaFichaTecnica_Load);
            this.pn1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.SETORcATsCAT.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.pnImagem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbimagem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Panel pn1;
        private System.Windows.Forms.Panel SETORcATsCAT;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label lbcustoPorcao;
        private System.Windows.Forms.Label lbTotalKg;
        private System.Windows.Forms.PictureBox pbImagem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbSetor;
        private System.Windows.Forms.Label lbSubcategoria;
        private System.Windows.Forms.Label lbCategoria;
        private System.Windows.Forms.Label lbRendimento;
        private System.Windows.Forms.Label lbPeso;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel pnImagem;
        private System.Windows.Forms.PictureBox pbimagem1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox lbPreparo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ingrediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn um;
        private System.Windows.Forms.DataGridViewTextBoxColumn fc;
        private System.Windows.Forms.DataGridViewTextBoxColumn quant;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.PictureBox pbPrint;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
    }
}