namespace GUI.Forms.Comuns
{
    partial class Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.lb = new System.Windows.Forms.Label();
            this.tbGraficos = new System.Windows.Forms.TableLayoutPanel();
            this.lbAparencia = new System.Windows.Forms.Label();
            this.lbPaginaInicial = new System.Windows.Forms.Label();
            this.Gerais = new System.Windows.Forms.Label();
            this.tbAtalhos = new System.Windows.Forms.TableLayoutPanel();
            this.tbInicial = new System.Windows.Forms.TableLayoutPanel();
            this.pnAparencia = new System.Windows.Forms.Panel();
            this.DivTitulo = new System.Windows.Forms.Panel();
            this.btDeletaFoto = new System.Windows.Forms.Button();
            this.btCarregaFoto = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pbWallpaper = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tbPrincipal.SuspendLayout();
            this.tbGraficos.SuspendLayout();
            this.tbAtalhos.SuspendLayout();
            this.pnAparencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWallpaper)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbPrincipal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 561);
            this.panel1.TabIndex = 0;
            // 
            // tbPrincipal
            // 
            this.tbPrincipal.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tbPrincipal.ColumnCount = 1;
            this.tbPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbPrincipal.Controls.Add(this.lb, 0, 0);
            this.tbPrincipal.Controls.Add(this.tbGraficos, 0, 1);
            this.tbPrincipal.Controls.Add(this.lbPaginaInicial, 0, 4);
            this.tbPrincipal.Controls.Add(this.Gerais, 0, 2);
            this.tbPrincipal.Controls.Add(this.tbAtalhos, 0, 3);
            this.tbPrincipal.Controls.Add(this.tbInicial, 0, 5);
            this.tbPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tbPrincipal.Margin = new System.Windows.Forms.Padding(0);
            this.tbPrincipal.Name = "tbPrincipal";
            this.tbPrincipal.RowCount = 7;
            this.tbPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tbPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tbPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tbPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tbPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tbPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tbPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbPrincipal.Size = new System.Drawing.Size(250, 561);
            this.tbPrincipal.TabIndex = 0;
            // 
            // lb
            // 
            this.lb.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb.Location = new System.Drawing.Point(1, 1);
            this.lb.Margin = new System.Windows.Forms.Padding(0);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(248, 30);
            this.lb.TabIndex = 0;
            this.lb.Text = "GRAFICOS";
            this.lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb.Click += new System.EventHandler(this.lb_Click);
            // 
            // tbGraficos
            // 
            this.tbGraficos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbGraficos.ColumnCount = 1;
            this.tbGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbGraficos.Controls.Add(this.lbAparencia, 0, 0);
            this.tbGraficos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbGraficos.Location = new System.Drawing.Point(1, 32);
            this.tbGraficos.Margin = new System.Windows.Forms.Padding(0);
            this.tbGraficos.Name = "tbGraficos";
            this.tbGraficos.RowCount = 2;
            this.tbGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbGraficos.Size = new System.Drawing.Size(248, 150);
            this.tbGraficos.TabIndex = 1;
            // 
            // lbAparencia
            // 
            this.lbAparencia.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbAparencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAparencia.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAparencia.Location = new System.Drawing.Point(0, 0);
            this.lbAparencia.Margin = new System.Windows.Forms.Padding(0);
            this.lbAparencia.Name = "lbAparencia";
            this.lbAparencia.Size = new System.Drawing.Size(248, 20);
            this.lbAparencia.TabIndex = 0;
            this.lbAparencia.Text = "Aparência das janelas";
            this.lbAparencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbAparencia.Click += new System.EventHandler(this.lbAparencia_Click);
            this.lbAparencia.MouseEnter += new System.EventHandler(this.lbAparencia_MouseEnter);
            this.lbAparencia.MouseLeave += new System.EventHandler(this.lbAparencia_MouseLeave);
            // 
            // lbPaginaInicial
            // 
            this.lbPaginaInicial.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbPaginaInicial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPaginaInicial.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPaginaInicial.Location = new System.Drawing.Point(1, 365);
            this.lbPaginaInicial.Margin = new System.Windows.Forms.Padding(0);
            this.lbPaginaInicial.Name = "lbPaginaInicial";
            this.lbPaginaInicial.Size = new System.Drawing.Size(248, 30);
            this.lbPaginaInicial.TabIndex = 2;
            this.lbPaginaInicial.Text = "PAGINA INICIAL";
            this.lbPaginaInicial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPaginaInicial.Click += new System.EventHandler(this.lbPaginaInicial_Click);
            // 
            // Gerais
            // 
            this.Gerais.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Gerais.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gerais.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gerais.Location = new System.Drawing.Point(1, 183);
            this.Gerais.Margin = new System.Windows.Forms.Padding(0);
            this.Gerais.Name = "Gerais";
            this.Gerais.Size = new System.Drawing.Size(248, 30);
            this.Gerais.TabIndex = 2;
            this.Gerais.Text = "CONFIGURAÇÕES GERAIS";
            this.Gerais.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Gerais.Click += new System.EventHandler(this.Atalhos_Click);
            // 
            // tbAtalhos
            // 
            this.tbAtalhos.ColumnCount = 1;
            this.tbAtalhos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbAtalhos.Controls.Add(this.label4, 0, 0);
            this.tbAtalhos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAtalhos.Location = new System.Drawing.Point(1, 214);
            this.tbAtalhos.Margin = new System.Windows.Forms.Padding(0);
            this.tbAtalhos.Name = "tbAtalhos";
            this.tbAtalhos.RowCount = 5;
            this.tbAtalhos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbAtalhos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbAtalhos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbAtalhos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbAtalhos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbAtalhos.Size = new System.Drawing.Size(248, 150);
            this.tbAtalhos.TabIndex = 3;
            // 
            // tbInicial
            // 
            this.tbInicial.ColumnCount = 1;
            this.tbInicial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbInicial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInicial.Location = new System.Drawing.Point(1, 396);
            this.tbInicial.Margin = new System.Windows.Forms.Padding(0);
            this.tbInicial.Name = "tbInicial";
            this.tbInicial.RowCount = 5;
            this.tbInicial.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbInicial.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbInicial.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbInicial.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbInicial.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbInicial.Size = new System.Drawing.Size(248, 150);
            this.tbInicial.TabIndex = 3;
            // 
            // pnAparencia
            // 
            this.pnAparencia.Controls.Add(this.DivTitulo);
            this.pnAparencia.Controls.Add(this.btDeletaFoto);
            this.pnAparencia.Controls.Add(this.btCarregaFoto);
            this.pnAparencia.Controls.Add(this.label3);
            this.pnAparencia.Controls.Add(this.pbWallpaper);
            this.pnAparencia.Controls.Add(this.label2);
            this.pnAparencia.Controls.Add(this.label1);
            this.pnAparencia.Location = new System.Drawing.Point(252, 1);
            this.pnAparencia.Name = "pnAparencia";
            this.pnAparencia.Size = new System.Drawing.Size(569, 560);
            this.pnAparencia.TabIndex = 1;
            // 
            // DivTitulo
            // 
            this.DivTitulo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.DivTitulo.Location = new System.Drawing.Point(28, 52);
            this.DivTitulo.Name = "DivTitulo";
            this.DivTitulo.Size = new System.Drawing.Size(522, 4);
            this.DivTitulo.TabIndex = 23;
            // 
            // btDeletaFoto
            // 
            this.btDeletaFoto.Image = global::GUI.Properties.Resources.trash_2x;
            this.btDeletaFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDeletaFoto.Location = new System.Drawing.Point(337, 321);
            this.btDeletaFoto.Name = "btDeletaFoto";
            this.btDeletaFoto.Size = new System.Drawing.Size(75, 24);
            this.btDeletaFoto.TabIndex = 22;
            this.btDeletaFoto.Text = "Deletar";
            this.btDeletaFoto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDeletaFoto.UseVisualStyleBackColor = true;
            this.btDeletaFoto.Click += new System.EventHandler(this.btDeletaFoto_Click);
            // 
            // btCarregaFoto
            // 
            this.btCarregaFoto.Image = global::GUI.Properties.Resources.camera_slr_2x;
            this.btCarregaFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCarregaFoto.Location = new System.Drawing.Point(256, 321);
            this.btCarregaFoto.Name = "btCarregaFoto";
            this.btCarregaFoto.Size = new System.Drawing.Size(75, 24);
            this.btCarregaFoto.TabIndex = 21;
            this.btCarregaFoto.Text = "Carregar";
            this.btCarregaFoto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCarregaFoto.UseVisualStyleBackColor = true;
            this.btCarregaFoto.Click += new System.EventHandler(this.btCarregaFoto_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semilight", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(296, 34);
            this.label3.TabIndex = 3;
            this.label3.Text = "OBS: O papel de parede deve ter, ao menos 1350 x 633 px para total resolução.";
            // 
            // pbWallpaper
            // 
            this.pbWallpaper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbWallpaper.Location = new System.Drawing.Point(28, 135);
            this.pbWallpaper.Name = "pbWallpaper";
            this.pbWallpaper.Size = new System.Drawing.Size(384, 180);
            this.pbWallpaper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbWallpaper.TabIndex = 2;
            this.pbWallpaper.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Papel de parede";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aparência das janelas";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(248, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Notificações";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 561);
            this.Controls.Add(this.pnAparencia);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Config";
            this.Text = "Configurações gerais";
            this.Load += new System.EventHandler(this.Config_Load);
            this.panel1.ResumeLayout(false);
            this.tbPrincipal.ResumeLayout(false);
            this.tbGraficos.ResumeLayout(false);
            this.tbAtalhos.ResumeLayout(false);
            this.pnAparencia.ResumeLayout(false);
            this.pnAparencia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWallpaper)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tbPrincipal;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.TableLayoutPanel tbGraficos;
        private System.Windows.Forms.Label lbPaginaInicial;
        private System.Windows.Forms.Label Gerais;
        private System.Windows.Forms.TableLayoutPanel tbAtalhos;
        private System.Windows.Forms.TableLayoutPanel tbInicial;
        private System.Windows.Forms.Label lbAparencia;
        private System.Windows.Forms.Panel pnAparencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbWallpaper;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btDeletaFoto;
        private System.Windows.Forms.Button btCarregaFoto;
        private System.Windows.Forms.Panel DivTitulo;
        private System.Windows.Forms.Label label4;
    }
}