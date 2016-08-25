namespace GUI
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.btBeckup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btBeckup
            // 
            this.btBeckup.Image = global::GUI.Properties.Resources.cloud_6x;
            this.btBeckup.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btBeckup.Location = new System.Drawing.Point(12, 12);
            this.btBeckup.Name = "btBeckup";
            this.btBeckup.Size = new System.Drawing.Size(94, 90);
            this.btBeckup.TabIndex = 1;
            this.btBeckup.Text = "Beckup banco de dados";
            this.btBeckup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btBeckup.UseVisualStyleBackColor = true;
            this.btBeckup.Click += new System.EventHandler(this.btBeckup_Click);
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 237);
            this.Controls.Add(this.btBeckup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btBeckup;
    }
}