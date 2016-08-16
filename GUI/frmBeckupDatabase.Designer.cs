namespace GUI
{
    partial class frmBeckupDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBeckupDatabase));
            this.btRestaura = new System.Windows.Forms.Button();
            this.btBeckup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btRestaura
            // 
            this.btRestaura.Image = global::GUI.Properties.Resources.cloud_download_8x;
            this.btRestaura.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btRestaura.Location = new System.Drawing.Point(122, 12);
            this.btRestaura.Name = "btRestaura";
            this.btRestaura.Size = new System.Drawing.Size(83, 87);
            this.btRestaura.TabIndex = 3;
            this.btRestaura.Text = "Restaura";
            this.btRestaura.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btRestaura.UseVisualStyleBackColor = true;
            this.btRestaura.Click += new System.EventHandler(this.btRestaura_Click);
            // 
            // btBeckup
            // 
            this.btBeckup.Image = global::GUI.Properties.Resources.cloud_upload_8x;
            this.btBeckup.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btBeckup.Location = new System.Drawing.Point(15, 12);
            this.btBeckup.Name = "btBeckup";
            this.btBeckup.Size = new System.Drawing.Size(83, 87);
            this.btBeckup.TabIndex = 0;
            this.btBeckup.Text = "Beckup";
            this.btBeckup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btBeckup.UseVisualStyleBackColor = true;
            this.btBeckup.Click += new System.EventHandler(this.btBeckup_Click);
            // 
            // frmBeckupDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 121);
            this.Controls.Add(this.btRestaura);
            this.Controls.Add(this.btBeckup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBeckupDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Beckup do banco de dados";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btBeckup;
        private System.Windows.Forms.Button btRestaura;
    }
}