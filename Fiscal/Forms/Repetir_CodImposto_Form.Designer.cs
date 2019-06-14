namespace FiscalApp
{
    partial class Repetir_CodImposto_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Repetir_CodImposto_Form));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MultiplePagesCheck = new System.Windows.Forms.CheckBox();
            this.QtdeRepeat = new System.Windows.Forms.NumericUpDown();
            this.QtdeItens = new System.Windows.Forms.NumericUpDown();
            this.QtdePaginas = new System.Windows.Forms.NumericUpDown();
            this.CodigoImpostoIVA = new System.Windows.Forms.TextBox();
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
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código Imposto IVA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Repetir Nx";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(270, 22);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.QtdeItens);
            this.groupBox1.Controls.Add(this.QtdePaginas);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(15, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 61);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Qtde. Itens";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Qtde. Páginas";
            // 
            // MultiplePagesCheck
            // 
            this.MultiplePagesCheck.AutoSize = true;
            this.MultiplePagesCheck.Location = new System.Drawing.Point(15, 60);
            this.MultiplePagesCheck.Name = "MultiplePagesCheck";
            this.MultiplePagesCheck.Size = new System.Drawing.Size(107, 17);
            this.MultiplePagesCheck.TabIndex = 2;
            this.MultiplePagesCheck.Text = "Múltiplas páginas";
            this.MultiplePagesCheck.UseVisualStyleBackColor = true;
            this.MultiplePagesCheck.Click += new System.EventHandler(this.MultiplePagesCheck_Click);
            // 
            // QtdeRepeat
            // 
            this.QtdeRepeat.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::FiscalApp.Properties.Settings.Default, "lastQtdeRepeatTaxTyped", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.QtdeRepeat.Location = new System.Drawing.Point(142, 26);
            this.QtdeRepeat.Name = "QtdeRepeat";
            this.QtdeRepeat.Size = new System.Drawing.Size(61, 20);
            this.QtdeRepeat.TabIndex = 1;
            this.QtdeRepeat.Value = global::FiscalApp.Properties.Settings.Default.lastQtdeRepeatTaxTyped;
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
            // CodigoImpostoIVA
            // 
            this.CodigoImpostoIVA.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::FiscalApp.Properties.Settings.Default, "lastCodImpostoIVAtyped", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CodigoImpostoIVA.Location = new System.Drawing.Point(15, 25);
            this.CodigoImpostoIVA.Name = "CodigoImpostoIVA";
            this.CodigoImpostoIVA.Size = new System.Drawing.Size(121, 20);
            this.CodigoImpostoIVA.TabIndex = 0;
            this.CodigoImpostoIVA.Text = global::FiscalApp.Properties.Settings.Default.lastCodImpostoIVAtyped;
            // 
            // Repetir_CodImposto_Form
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 145);
            this.Controls.Add(this.QtdeRepeat);
            this.Controls.Add(this.MultiplePagesCheck);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CodigoImpostoIVA);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Repetir_CodImposto_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Repetir Código Imposto";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Repetir_CodImposto_FormClosed);
            this.Shown += new System.EventHandler(this.Repetir_CodImposto_Form_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Repetir_CodImposto_Form_KeyDown);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.TextBox CodigoImpostoIVA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown QtdeItens;
        public System.Windows.Forms.NumericUpDown QtdePaginas;
        public System.Windows.Forms.CheckBox MultiplePagesCheck;
        public System.Windows.Forms.NumericUpDown QtdeRepeat;
    }
}