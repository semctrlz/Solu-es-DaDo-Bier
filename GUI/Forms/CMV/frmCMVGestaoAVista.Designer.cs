namespace GUI
{
    partial class frmCMVGestaoAVista
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCMVGestaoAVista));
            this.graficoComparativo1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUnidade = new System.Windows.Forms.ComboBox();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numAno = new System.Windows.Forms.NumericUpDown();
            this.lbAno = new System.Windows.Forms.Label();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbComparativo = new System.Windows.Forms.ComboBox();
            this.pngraficos = new System.Windows.Forms.Panel();
            this.ComparativoCusto = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.graficoComparativo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).BeginInit();
            this.panel1.SuspendLayout();
            this.pngraficos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComparativoCusto)).BeginInit();
            this.SuspendLayout();
            // 
            // graficoComparativo1
            // 
            chartArea1.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.LabelAutoFitMaxFontSize = 8;
            chartArea1.AxisY.LabelStyle.Angle = -90;
            chartArea1.AxisY.MajorGrid.Interval = 0D;
            chartArea1.AxisY.MaximumAutoSize = 50F;
            chartArea1.AxisY.ScrollBar.Size = 10D;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 85F;
            chartArea1.InnerPlotPosition.Width = 95F;
            chartArea1.InnerPlotPosition.X = 4F;
            chartArea1.InnerPlotPosition.Y = 5F;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 94F;
            chartArea1.Position.Width = 98F;
            this.graficoComparativo1.ChartAreas.Add(chartArea1);
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.Name = "Legend1";
            this.graficoComparativo1.Legends.Add(legend1);
            this.graficoComparativo1.Location = new System.Drawing.Point(10, 41);
            this.graficoComparativo1.Name = "graficoComparativo1";
            series1.BorderColor = System.Drawing.Color.Black;
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.IsXValueIndexed = true;
            series1.LabelAngle = -90;
            series1.LabelBackColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.MarkerSize = 1;
            series1.Name = "Dia";
            series1.SmartLabelStyle.Enabled = false;
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.BorderColor = System.Drawing.Color.Black;
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.Gray;
            series2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            series2.IsValueShownAsLabel = true;
            series2.IsXValueIndexed = true;
            series2.LabelAngle = -90;
            series2.LabelBackColor = System.Drawing.Color.White;
            series2.Legend = "Legend1";
            series2.MarkerBorderColor = System.Drawing.Color.White;
            series2.Name = "Noite";
            series2.SmartLabelStyle.Enabled = false;
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.graficoComparativo1.Series.Add(series1);
            this.graficoComparativo1.Series.Add(series2);
            this.graficoComparativo1.Size = new System.Drawing.Size(958, 259);
            this.graficoComparativo1.TabIndex = 1;
            this.graficoComparativo1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graficoComparativo1_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Unidade";
            // 
            // cbUnidade
            // 
            this.cbUnidade.FormattingEnabled = true;
            this.cbUnidade.Location = new System.Drawing.Point(6, 35);
            this.cbUnidade.Name = "cbUnidade";
            this.cbUnidade.Size = new System.Drawing.Size(67, 21);
            this.cbUnidade.TabIndex = 3;
            this.cbUnidade.SelectedIndexChanged += new System.EventHandler(this.cbUnidade_SelectedIndexChanged);
            // 
            // cbMes
            // 
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Location = new System.Drawing.Point(80, 34);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(103, 21);
            this.cbMes.TabIndex = 4;
            this.cbMes.SelectedIndexChanged += new System.EventHandler(this.cbMes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mês";
            // 
            // numAno
            // 
            this.numAno.Location = new System.Drawing.Point(189, 34);
            this.numAno.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numAno.Minimum = new decimal(new int[] {
            1995,
            0,
            0,
            0});
            this.numAno.Name = "numAno";
            this.numAno.Size = new System.Drawing.Size(72, 20);
            this.numAno.TabIndex = 7;
            this.numAno.Value = new decimal(new int[] {
            1995,
            0,
            0,
            0});
            this.numAno.ValueChanged += new System.EventHandler(this.numAno_ValueChanged);
            // 
            // lbAno
            // 
            this.lbAno.AutoSize = true;
            this.lbAno.Location = new System.Drawing.Point(188, 17);
            this.lbAno.Name = "lbAno";
            this.lbAno.Size = new System.Drawing.Size(26, 13);
            this.lbAno.TabIndex = 6;
            this.lbAno.Text = "Ano";
            // 
            // lbTitulo
            // 
            this.lbTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(267, 9);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(703, 63);
            this.lbTitulo.TabIndex = 8;
            this.lbTitulo.Text = "CMV - Seival - Maio/2016";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbTitulo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbUnidade);
            this.panel1.Controls.Add(this.numAno);
            this.panel1.Controls.Add(this.cbMes);
            this.panel1.Controls.Add(this.lbAno);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 72);
            this.panel1.TabIndex = 9;
            // 
            // cbComparativo
            // 
            this.cbComparativo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComparativo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbComparativo.FormattingEnabled = true;
            this.cbComparativo.Location = new System.Drawing.Point(6, 6);
            this.cbComparativo.Name = "cbComparativo";
            this.cbComparativo.Size = new System.Drawing.Size(249, 29);
            this.cbComparativo.TabIndex = 4;
            this.cbComparativo.SelectedIndexChanged += new System.EventHandler(this.cbMes_SelectedIndexChanged);
            // 
            // pngraficos
            // 
            this.pngraficos.Controls.Add(this.graficoComparativo1);
            this.pngraficos.Controls.Add(this.ComparativoCusto);
            this.pngraficos.Controls.Add(this.cbComparativo);
            this.pngraficos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pngraficos.Location = new System.Drawing.Point(0, 72);
            this.pngraficos.Name = "pngraficos";
            this.pngraficos.Size = new System.Drawing.Size(982, 577);
            this.pngraficos.TabIndex = 10;
            // 
            // ComparativoCusto
            // 
            chartArea2.Name = "ChartArea1";
            this.ComparativoCusto.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ComparativoCusto.Legends.Add(legend2);
            this.ComparativoCusto.Location = new System.Drawing.Point(3, 322);
            this.ComparativoCusto.Name = "ComparativoCusto";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.ComparativoCusto.Series.Add(series3);
            this.ComparativoCusto.Size = new System.Drawing.Size(394, 269);
            this.ComparativoCusto.TabIndex = 3;
            this.ComparativoCusto.Text = "ComparativoCusto";
            // 
            // frmCMVGestaoAVista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 649);
            this.Controls.Add(this.pngraficos);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCMVGestaoAVista";
            this.Text = "Gestão à Vista";
            this.Load += new System.EventHandler(this.frmCMVGestaoAVista_Load);
            this.SizeChanged += new System.EventHandler(this.frmCMVGestaoAVista_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.graficoComparativo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pngraficos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ComparativoCusto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart graficoComparativo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbUnidade;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numAno;
        private System.Windows.Forms.Label lbAno;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbComparativo;
        private System.Windows.Forms.Panel pngraficos;
        private System.Windows.Forms.DataVisualization.Charting.Chart ComparativoCusto;
    }
}