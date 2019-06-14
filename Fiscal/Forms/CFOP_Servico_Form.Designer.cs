namespace FiscalApp
{
    partial class CFOP_Servico_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFOP_Servico_Form));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MultiplePagesCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PIS = new System.Windows.Forms.TextBox();
            this.COFINS = new System.Windows.Forms.TextBox();
            this.QtdeRepeat = new System.Windows.Forms.NumericUpDown();
            this.QtdeItens = new System.Windows.Forms.NumericUpDown();
            this.QtdePaginas = new System.Windows.Forms.NumericUpDown();
            this.IPI = new System.Windows.Forms.TextBox();
            this.ICMS = new System.Windows.Forms.TextBox();
            this.CodigoServico = new System.Windows.Forms.TextBox();
            this.CFOP = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QtdeRepeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QtdeItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QtdePaginas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CFOP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Serviço";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(474, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Repetir Nx";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(463, 115);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "ICMS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "IPI";
            // 
            // MultiplePagesCheck
            // 
            this.MultiplePagesCheck.AutoSize = true;
            this.MultiplePagesCheck.Location = new System.Drawing.Point(15, 62);
            this.MultiplePagesCheck.Name = "MultiplePagesCheck";
            this.MultiplePagesCheck.Size = new System.Drawing.Size(107, 17);
            this.MultiplePagesCheck.TabIndex = 5;
            this.MultiplePagesCheck.Text = "Múltiplas páginas";
            this.MultiplePagesCheck.UseVisualStyleBackColor = true;
            this.MultiplePagesCheck.Click += new System.EventHandler(this.MultiplePagesCheck_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.QtdeItens);
            this.groupBox1.Controls.Add(this.QtdePaginas);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(15, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 61);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(124, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Qtde. Itens";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Qtde. Páginas";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(340, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "COFINS";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(398, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "PIS";
            // 
            // PIS
            // 
            this.PIS.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "lastPISTyped", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PIS.Location = new System.Drawing.Point(401, 25);
            this.PIS.Name = "PIS";
            this.PIS.Size = new System.Drawing.Size(52, 20);
            this.PIS.TabIndex = 5;
            this.PIS.Text = global::FiscalApp.Properties.Settings.Default.lastPISTyped;
            // 
            // COFINS
            // 
            this.COFINS.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "lastCOFINSTyped", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.COFINS.Location = new System.Drawing.Point(343, 25);
            this.COFINS.Name = "COFINS";
            this.COFINS.Size = new System.Drawing.Size(52, 20);
            this.COFINS.TabIndex = 4;
            this.COFINS.Text = global::FiscalApp.Properties.Settings.Default.lastCOFINSTyped;
            // 
            // QtdeRepeat
            // 
            this.QtdeRepeat.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::FiscalApp.Properties.Settings.Default, "lastCFOPServicoScreenTyped", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.QtdeRepeat.Location = new System.Drawing.Point(477, 26);
            this.QtdeRepeat.Name = "QtdeRepeat";
            this.QtdeRepeat.Size = new System.Drawing.Size(61, 20);
            this.QtdeRepeat.TabIndex = 6;
            this.QtdeRepeat.Value = global::FiscalApp.Properties.Settings.Default.lastCFOPServicoScreenTyped;
            // 
            // QtdeItens
            // 
            this.QtdeItens.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::FiscalApp.Properties.Settings.Default, "lastQtdeItensNFTyped", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.QtdeItens.Location = new System.Drawing.Point(127, 31);
            this.QtdeItens.Name = "QtdeItens";
            this.QtdeItens.Size = new System.Drawing.Size(84, 20);
            this.QtdeItens.TabIndex = 1;
            this.QtdeItens.Value = global::FiscalApp.Properties.Settings.Default.lastQtdeItensNFTyped;
            // 
            // QtdePaginas
            // 
            this.QtdePaginas.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::FiscalApp.Properties.Settings.Default, "lastQtdePaginasTyped", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.QtdePaginas.Location = new System.Drawing.Point(15, 31);
            this.QtdePaginas.Name = "QtdePaginas";
            this.QtdePaginas.Size = new System.Drawing.Size(84, 20);
            this.QtdePaginas.TabIndex = 0;
            this.QtdePaginas.Value = global::FiscalApp.Properties.Settings.Default.lastQtdePaginasTyped;
            // 
            // IPI
            // 
            this.IPI.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "lastIPITyped", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.IPI.Location = new System.Drawing.Point(179, 25);
            this.IPI.Name = "IPI";
            this.IPI.Size = new System.Drawing.Size(52, 20);
            this.IPI.TabIndex = 2;
            this.IPI.Text = global::FiscalApp.Properties.Settings.Default.lastIPITyped;
            // 
            // ICMS
            // 
            this.ICMS.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "lastICMSTyped", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ICMS.Location = new System.Drawing.Point(121, 25);
            this.ICMS.Name = "ICMS";
            this.ICMS.Size = new System.Drawing.Size(52, 20);
            this.ICMS.TabIndex = 1;
            this.ICMS.Text = global::FiscalApp.Properties.Settings.Default.lastICMSTyped;
            // 
            // CodigoServico
            // 
            this.CodigoServico.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "lastCodServicotyped", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CodigoServico.Location = new System.Drawing.Point(237, 25);
            this.CodigoServico.Name = "CodigoServico";
            this.CodigoServico.Size = new System.Drawing.Size(100, 20);
            this.CodigoServico.TabIndex = 3;
            this.CodigoServico.Text = global::FiscalApp.Properties.Settings.Default.lastCodServicotyped;
            // 
            // CFOP
            // 
            this.CFOP.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "lastCFOPtyped", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CFOP.Location = new System.Drawing.Point(15, 25);
            this.CFOP.Name = "CFOP";
            this.CFOP.Size = new System.Drawing.Size(100, 20);
            this.CFOP.TabIndex = 0;
            this.CFOP.Text = global::FiscalApp.Properties.Settings.Default.lastCFOPtyped;
            // 
            // CFOP_Servico_Form
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 150);
            this.Controls.Add(this.PIS);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.COFINS);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.QtdeRepeat);
            this.Controls.Add(this.MultiplePagesCheck);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.IPI);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ICMS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CodigoServico);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CFOP);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CFOP_Servico_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Repetir CFOP Serviço";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CFOP_Servico_Form_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CFOP_Servico_Form_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QtdeRepeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QtdeItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QtdePaginas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.TextBox CFOP;
        public System.Windows.Forms.TextBox CodigoServico;
        public System.Windows.Forms.TextBox ICMS;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox IPI;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.CheckBox MultiplePagesCheck;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.NumericUpDown QtdeItens;
        public System.Windows.Forms.NumericUpDown QtdePaginas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.NumericUpDown QtdeRepeat;
        public System.Windows.Forms.TextBox PIS;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox COFINS;
        private System.Windows.Forms.Label label9;
    }
}