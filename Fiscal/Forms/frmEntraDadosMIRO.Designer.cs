namespace FiscalApp
{
    partial class frmEntraDadosMIRO
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
            this.btnPreencher = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkIncluiAno = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CorSemaforo = new System.Windows.Forms.Label();
            this.lblLOG = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkSimei = new System.Windows.Forms.CheckBox();
            this.chkSimplesNacional = new System.Windows.Forms.CheckBox();
            this.FimCNPJ = new System.Windows.Forms.TextBox();
            this.CodigoServico = new System.Windows.Forms.TextBox();
            this.txtUFFornecedor = new System.Windows.Forms.TextBox();
            this.CategoriaNF = new System.Windows.Forms.TextBox();
            this.Montante = new System.Windows.Forms.TextBox();
            this.CFOP = new System.Windows.Forms.TextBox();
            this.DataFatura = new System.Windows.Forms.TextBox();
            this.NumeroNF = new System.Windows.Forms.TextBox();
            this.Pedido = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pedido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numero NF";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Montante";
            // 
            // btnPreencher
            // 
            this.btnPreencher.Location = new System.Drawing.Point(601, 175);
            this.btnPreencher.Name = "btnPreencher";
            this.btnPreencher.Size = new System.Drawing.Size(75, 23);
            this.btnPreencher.TabIndex = 10;
            this.btnPreencher.Text = "Preencher";
            this.btnPreencher.UseVisualStyleBackColor = true;
            this.btnPreencher.Click += new System.EventHandler(this.btnPreencher_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(514, 175);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 11;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Data Fatura";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(330, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "CFOP";
            // 
            // chkIncluiAno
            // 
            this.chkIncluiAno.AutoSize = true;
            this.chkIncluiAno.Location = new System.Drawing.Point(327, 26);
            this.chkIncluiAno.Name = "chkIncluiAno";
            this.chkIncluiAno.Size = new System.Drawing.Size(76, 17);
            this.chkIncluiAno.TabIndex = 2;
            this.chkIncluiAno.TabStop = false;
            this.chkIncluiAno.Text = "Incluir Ano";
            this.chkIncluiAno.UseVisualStyleBackColor = true;
            this.chkIncluiAno.CheckedChanged += new System.EventHandler(this.chkIncluiAno_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(330, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Ctg.NF";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(99, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "UF";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(154, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Código Serviço";
            // 
            // CorSemaforo
            // 
            this.CorSemaforo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CorSemaforo.Location = new System.Drawing.Point(394, 67);
            this.CorSemaforo.Name = "CorSemaforo";
            this.CorSemaforo.Size = new System.Drawing.Size(53, 20);
            this.CorSemaforo.TabIndex = 27;
            // 
            // lblLOG
            // 
            this.lblLOG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLOG.Location = new System.Drawing.Point(531, 9);
            this.lblLOG.Name = "lblLOG";
            this.lblLOG.Size = new System.Drawing.Size(145, 123);
            this.lblLOG.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "6 digitos CNPJ";
            // 
            // chkSimei
            // 
            this.chkSimei.AutoSize = true;
            this.chkSimei.Checked = global::FiscalApp.Properties.Settings.Default.MIROSimei;
            this.chkSimei.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::FiscalApp.Properties.Settings.Default, "MIROSimei", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkSimei.Location = new System.Drawing.Point(81, 140);
            this.chkSimei.Name = "chkSimei";
            this.chkSimei.Size = new System.Drawing.Size(51, 17);
            this.chkSimei.TabIndex = 9;
            this.chkSimei.Text = "Simei";
            this.chkSimei.UseVisualStyleBackColor = true;
            // 
            // chkSimplesNacional
            // 
            this.chkSimplesNacional.AutoSize = true;
            this.chkSimplesNacional.Checked = global::FiscalApp.Properties.Settings.Default.MIROSimples;
            this.chkSimplesNacional.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::FiscalApp.Properties.Settings.Default, "MIROSimples", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkSimplesNacional.Location = new System.Drawing.Point(13, 140);
            this.chkSimplesNacional.Name = "chkSimplesNacional";
            this.chkSimplesNacional.Size = new System.Drawing.Size(62, 17);
            this.chkSimplesNacional.TabIndex = 8;
            this.chkSimplesNacional.Text = "Simples";
            this.chkSimplesNacional.UseVisualStyleBackColor = true;
            // 
            // FimCNPJ
            // 
            this.FimCNPJ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.FimCNPJ.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "FimCNPJ", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FimCNPJ.Location = new System.Drawing.Point(12, 112);
            this.FimCNPJ.Name = "FimCNPJ";
            this.FimCNPJ.Size = new System.Drawing.Size(81, 20);
            this.FimCNPJ.TabIndex = 5;
            this.FimCNPJ.TabStop = false;
            this.FimCNPJ.Text = global::FiscalApp.Properties.Settings.Default.FimCNPJ;
            this.FimCNPJ.Leave += new System.EventHandler(this.FimCNPJ_Leave);
            // 
            // CodigoServico
            // 
            this.CodigoServico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CodigoServico.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "CodigoServicoMIRO", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CodigoServico.Location = new System.Drawing.Point(154, 112);
            this.CodigoServico.Name = "CodigoServico";
            this.CodigoServico.Size = new System.Drawing.Size(97, 20);
            this.CodigoServico.TabIndex = 7;
            this.CodigoServico.Text = global::FiscalApp.Properties.Settings.Default.CodigoServicoMIRO;
            this.CodigoServico.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CodigoServico.Enter += new System.EventHandler(this.CodigoServico_Enter);
            // 
            // txtUFFornecedor
            // 
            this.txtUFFornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUFFornecedor.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "UFFornecedor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtUFFornecedor.Location = new System.Drawing.Point(99, 112);
            this.txtUFFornecedor.MaxLength = 2;
            this.txtUFFornecedor.Name = "txtUFFornecedor";
            this.txtUFFornecedor.Size = new System.Drawing.Size(49, 20);
            this.txtUFFornecedor.TabIndex = 6;
            this.txtUFFornecedor.Text = global::FiscalApp.Properties.Settings.Default.UFFornecedor;
            this.txtUFFornecedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUFFornecedor.Leave += new System.EventHandler(this.txtUFFornecedor_Leave);
            // 
            // CategoriaNF
            // 
            this.CategoriaNF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CategoriaNF.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "CategoriaNFMIRO", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CategoriaNF.Location = new System.Drawing.Point(330, 67);
            this.CategoriaNF.Name = "CategoriaNF";
            this.CategoriaNF.Size = new System.Drawing.Size(58, 20);
            this.CategoriaNF.TabIndex = 4;
            this.CategoriaNF.TabStop = false;
            this.CategoriaNF.Text = global::FiscalApp.Properties.Settings.Default.CategoriaNFMIRO;
            this.CategoriaNF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CategoriaNF.Leave += new System.EventHandler(this.CategoriaNF_Leave);
            // 
            // Montante
            // 
            this.Montante.AcceptsReturn = true;
            this.Montante.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "MontanteMIRO", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Montante.Location = new System.Drawing.Point(12, 67);
            this.Montante.Name = "Montante";
            this.Montante.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Montante.Size = new System.Drawing.Size(152, 20);
            this.Montante.TabIndex = 2;
            this.Montante.Text = global::FiscalApp.Properties.Settings.Default.MontanteMIRO;
            // 
            // CFOP
            // 
            this.CFOP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CFOP.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "CFOPNFMiro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CFOP.Location = new System.Drawing.Point(330, 112);
            this.CFOP.Name = "CFOP";
            this.CFOP.Size = new System.Drawing.Size(81, 20);
            this.CFOP.TabIndex = 8;
            this.CFOP.TabStop = false;
            this.CFOP.Text = global::FiscalApp.Properties.Settings.Default.CFOPNFMiro;
            // 
            // DataFatura
            // 
            this.DataFatura.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "DataFaturaMIRO", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataFatura.Location = new System.Drawing.Point(12, 23);
            this.DataFatura.Name = "DataFatura";
            this.DataFatura.Size = new System.Drawing.Size(152, 20);
            this.DataFatura.TabIndex = 0;
            this.DataFatura.Text = global::FiscalApp.Properties.Settings.Default.DataFaturaMIRO;
            // 
            // NumeroNF
            // 
            this.NumeroNF.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "NumeroNFMIRO", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NumeroNF.Location = new System.Drawing.Point(169, 23);
            this.NumeroNF.Name = "NumeroNF";
            this.NumeroNF.Size = new System.Drawing.Size(152, 20);
            this.NumeroNF.TabIndex = 1;
            this.NumeroNF.Text = global::FiscalApp.Properties.Settings.Default.NumeroNFMIRO;
            this.NumeroNF.Leave += new System.EventHandler(this.NumeroNF_Leave);
            // 
            // Pedido
            // 
            this.Pedido.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "NumeroPedidoMIRO", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Pedido.Location = new System.Drawing.Point(172, 67);
            this.Pedido.Name = "Pedido";
            this.Pedido.Size = new System.Drawing.Size(152, 20);
            this.Pedido.TabIndex = 3;
            this.Pedido.Text = global::FiscalApp.Properties.Settings.Default.NumeroPedidoMIRO;
            this.Pedido.Enter += new System.EventHandler(this.Pedido_Enter);
            // 
            // frmEntraDadosMIRO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 210);
            this.Controls.Add(this.chkSimei);
            this.Controls.Add(this.chkSimplesNacional);
            this.Controls.Add(this.FimCNPJ);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblLOG);
            this.Controls.Add(this.CorSemaforo);
            this.Controls.Add(this.CodigoServico);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUFFornecedor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CategoriaNF);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkIncluiAno);
            this.Controls.Add(this.Montante);
            this.Controls.Add(this.CFOP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DataFatura);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnPreencher);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NumeroNF);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Pedido);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEntraDadosMIRO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Entra Dador MIRO";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox Pedido;
        public System.Windows.Forms.TextBox NumeroNF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPreencher;
        private System.Windows.Forms.Button btnFechar;
        public System.Windows.Forms.TextBox DataFatura;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox CFOP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Montante;
        private System.Windows.Forms.CheckBox chkIncluiAno;
        public System.Windows.Forms.TextBox CategoriaNF;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtUFFornecedor;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox CodigoServico;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label CorSemaforo;
        private System.Windows.Forms.Label lblLOG;
        public System.Windows.Forms.TextBox FimCNPJ;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkSimplesNacional;
        private System.Windows.Forms.CheckBox chkSimei;
    }
}