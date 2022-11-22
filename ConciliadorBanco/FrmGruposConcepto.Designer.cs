namespace ConciliadorBanco
{
    partial class FrmGruposConcepto
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
            this.dgvGruposConcepto = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGruposConcepto)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGruposConcepto
            // 
            this.dgvGruposConcepto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGruposConcepto.Location = new System.Drawing.Point(12, 12);
            this.dgvGruposConcepto.Name = "dgvGruposConcepto";
            this.dgvGruposConcepto.Size = new System.Drawing.Size(426, 133);
            this.dgvGruposConcepto.TabIndex = 11;
            this.dgvGruposConcepto.DoubleClick += new System.EventHandler(this.dgvGruposConcepto_DoubleClick);
            // 
            // FrmGruposConcepto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvGruposConcepto);
            this.Name = "FrmGruposConcepto";
            this.Text = "FrmGruposConcepto";
            this.Load += new System.EventHandler(this.FrmGruposConcepto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGruposConcepto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvGruposConcepto;
    }
}