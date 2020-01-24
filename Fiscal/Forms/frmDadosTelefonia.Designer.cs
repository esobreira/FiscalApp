namespace FiscalApp
{
    partial class frmDadosTelefonia
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPreencher = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ValorIsentasNF = new System.Windows.Forms.TextBox();
            this.BaseCalculoNF = new System.Windows.Forms.TextBox();
            this.ValorNF = new System.Windows.Forms.TextBox();
            this.CFOPTelefonia = new System.Windows.Forms.TextBox();
            this.DataLancamento = new System.Windows.Forms.TextBox();
            this.DataFatura = new System.Windows.Forms.TextBox();
            this.NumeroNF = new System.Windows.Forms.TextBox();
            this.Pedido = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pedido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numero NF";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(182, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Valor NF";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(351, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Base Cálculo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(521, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Valor Isentas";
            // 
            // btnPreencher
            // 
            this.btnPreencher.Location = new System.Drawing.Point(601, 175);
            this.btnPreencher.Name = "btnPreencher";
            this.btnPreencher.Size = new System.Drawing.Size(75, 23);
            this.btnPreencher.TabIndex = 8;
            this.btnPreencher.Text = "Preencher";
            this.btnPreencher.UseVisualStyleBackColor = true;
            this.btnPreencher.Click += new System.EventHandler(this.btnPreencher_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(514, 175);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 9;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(185, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Data Fatura";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(354, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Data Lançamento";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "CFOP";
            // 
            // ValorIsentasNF
            // 
            this.ValorIsentasNF.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "ValorIsentasTelefonia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ValorIsentasNF.Location = new System.Drawing.Point(524, 71);
            this.ValorIsentasNF.Name = "ValorIsentasNF";
            this.ValorIsentasNF.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ValorIsentasNF.Size = new System.Drawing.Size(152, 20);
            this.ValorIsentasNF.TabIndex = 6;
            this.ValorIsentasNF.Text = global::FiscalApp.Properties.Settings.Default.ValorIsentasTelefonia;
            // 
            // BaseCalculoNF
            // 
            this.BaseCalculoNF.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "BaseCalculoTelefonia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.BaseCalculoNF.Location = new System.Drawing.Point(354, 71);
            this.BaseCalculoNF.Name = "BaseCalculoNF";
            this.BaseCalculoNF.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BaseCalculoNF.Size = new System.Drawing.Size(152, 20);
            this.BaseCalculoNF.TabIndex = 5;
            this.BaseCalculoNF.Text = global::FiscalApp.Properties.Settings.Default.BaseCalculoTelefonia;
            this.BaseCalculoNF.Enter += new System.EventHandler(this.BaseCalculoNF_Enter);
            this.BaseCalculoNF.Leave += new System.EventHandler(this.BaseCalculoNF_Leave);
            // 
            // ValorNF
            // 
            this.ValorNF.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "ValorNFTelefonia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ValorNF.Location = new System.Drawing.Point(185, 71);
            this.ValorNF.Name = "ValorNF";
            this.ValorNF.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ValorNF.Size = new System.Drawing.Size(152, 20);
            this.ValorNF.TabIndex = 4;
            this.ValorNF.Text = global::FiscalApp.Properties.Settings.Default.ValorNFTelefonia;
            this.ValorNF.Enter += new System.EventHandler(this.ValorNF_Enter);
            // 
            // CFOPTelefonia
            // 
            this.CFOPTelefonia.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "CFOPTelefonia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CFOPTelefonia.Location = new System.Drawing.Point(12, 120);
            this.CFOPTelefonia.Name = "CFOPTelefonia";
            this.CFOPTelefonia.Size = new System.Drawing.Size(152, 20);
            this.CFOPTelefonia.TabIndex = 7;
            this.CFOPTelefonia.Text = global::FiscalApp.Properties.Settings.Default.CFOPTelefonia;
            // 
            // DataLancamento
            // 
            this.DataLancamento.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "DataLancamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataLancamento.Location = new System.Drawing.Point(354, 25);
            this.DataLancamento.Name = "DataLancamento";
            this.DataLancamento.Size = new System.Drawing.Size(152, 20);
            this.DataLancamento.TabIndex = 2;
            this.DataLancamento.Text = global::FiscalApp.Properties.Settings.Default.DataLancamento;
            // 
            // DataFatura
            // 
            this.DataFatura.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "DataFatura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataFatura.Location = new System.Drawing.Point(185, 25);
            this.DataFatura.Name = "DataFatura";
            this.DataFatura.Size = new System.Drawing.Size(152, 20);
            this.DataFatura.TabIndex = 1;
            this.DataFatura.Text = global::FiscalApp.Properties.Settings.Default.DataFatura;
            // 
            // NumeroNF
            // 
            this.NumeroNF.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "NumeroNF", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NumeroNF.Location = new System.Drawing.Point(12, 71);
            this.NumeroNF.Name = "NumeroNF";
            this.NumeroNF.Size = new System.Drawing.Size(152, 20);
            this.NumeroNF.TabIndex = 3;
            this.NumeroNF.Text = global::FiscalApp.Properties.Settings.Default.NumeroNF;
            this.NumeroNF.Leave += new System.EventHandler(this.NumeroNF_Leave);
            // 
            // Pedido
            // 
            this.Pedido.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "NumeroPedido", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Pedido.Location = new System.Drawing.Point(12, 25);
            this.Pedido.Name = "Pedido";
            this.Pedido.Size = new System.Drawing.Size(152, 20);
            this.Pedido.TabIndex = 0;
            this.Pedido.Text = global::FiscalApp.Properties.Settings.Default.NumeroPedido;
            // 
            // frmDadosTelefonia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 210);
            this.Controls.Add(this.ValorIsentasNF);
            this.Controls.Add(this.BaseCalculoNF);
            this.Controls.Add(this.ValorNF);
            this.Controls.Add(this.CFOPTelefonia);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DataLancamento);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DataFatura);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnPreencher);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NumeroNF);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Pedido);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDadosTelefonia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dados Telefonia";
            this.Load += new System.EventHandler(this.frmDadosTelefonia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox Pedido;
        public System.Windows.Forms.TextBox NumeroNF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPreencher;
        private System.Windows.Forms.Button btnFechar;
        public System.Windows.Forms.TextBox DataFatura;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox DataLancamento;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox CFOPTelefonia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ValorNF;
        private System.Windows.Forms.TextBox BaseCalculoNF;
        private System.Windows.Forms.TextBox ValorIsentasNF;
    }
}