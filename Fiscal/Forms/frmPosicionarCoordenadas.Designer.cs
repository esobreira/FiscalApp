namespace FiscalApp
{
    partial class frmPosicionarCoordenadas
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
            this.btnPosicionar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.txtX = new System.Windows.Forms.NumericUpDown();
            this.txtY = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.txtX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtY)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPosicionar
            // 
            this.btnPosicionar.Location = new System.Drawing.Point(55, 113);
            this.btnPosicionar.Name = "btnPosicionar";
            this.btnPosicionar.Size = new System.Drawing.Size(75, 23);
            this.btnPosicionar.TabIndex = 4;
            this.btnPosicionar.Text = "Posicionar";
            this.btnPosicionar.UseVisualStyleBackColor = true;
            this.btnPosicionar.Click += new System.EventHandler(this.btnPosicionar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Coordenada X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Coordenada Y";
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(147, 113);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 5;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(118, 18);
            this.txtX.Maximum = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(120, 20);
            this.txtX.TabIndex = 1;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(118, 46);
            this.txtY.Maximum = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(120, 20);
            this.txtY.TabIndex = 3;
            // 
            // frmPosicionarCoordenadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 152);
            this.ControlBox = false;
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPosicionar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPosicionarCoordenadas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Posicionar em Coordenadas";
            ((System.ComponentModel.ISupportInitialize)(this.txtX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPosicionar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.NumericUpDown txtX;
        private System.Windows.Forms.NumericUpDown txtY;
    }
}