namespace FiscalApp
{
    partial class MainForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabPageConjunto = new System.Windows.Forms.TabPage();
            this.dgvConjunto = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsConjunto = new System.Windows.Forms.BindingSource(this.components);
            this.fiscalDataSet = new FiscalApp.FiscalDataSet();
            this.tabPageCampos = new System.Windows.Forms.TabPage();
            this.dgvCampos = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCampos = new System.Windows.Forms.BindingSource(this.components);
            this.tabPageConjuntoCampos = new System.Windows.Forms.TabPage();
            this.dgvConjuntoCampos = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idConjuntoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCamposDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdeRepeticoesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsConjuntoCampos = new System.Windows.Forms.BindingSource(this.components);
            this.tabPageListagemConjuntos = new System.Windows.Forms.TabPage();
            this.dgvListarConjuntos = new System.Windows.Forms.DataGridView();
            this.idConjuntoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeconjuntoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomecampoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textocampoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationXDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationYDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsListarDadosConjunto = new System.Windows.Forms.BindingSource(this.components);
            this.tabPageChavesAcesso = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtResultadoConsulta = new System.Windows.Forms.TextBox();
            this.txtChavesDeAcesso = new System.Windows.Forms.TextBox();
            this.cntxLinkLabel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.adicionarParaHotWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.repetir5xECopiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repetir10xECopiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repetir15xECopiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repetir20xECopiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repetir25xECopiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aplicativoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reiniciarTextosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.sempreNoTopoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.obterLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posicionarEmCoordenadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarÚltimaPalavraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.repetirCFOPEServiçoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repetirCódigoImpostoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.calcularVlrUnitarioDePedido100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.entrarDadosTelefoniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotWordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eGRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entrarEGREPrepararConsultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisarChavesDeAcessoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopiarChvOrigemeRefToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.controleDeNFeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.consultarProtocoloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarNaturezaOperaçãoNFsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.confirmarOperaçãoEmMassaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.downloadXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDaInstalaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbGravar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRunSet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsbQtdeRepeticoes = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRepeatCFOPServico = new System.Windows.Forms.ToolStripButton();
            this.tsbRepetirCodImposto = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnPesqChvAcessoEGR = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.taConjunto = new FiscalApp.FiscalDataSetTableAdapters.ConjuntoTableAdapter();
            this.tableAdapterManager = new FiscalApp.FiscalDataSetTableAdapters.TableAdapterManager();
            this.taCampos = new FiscalApp.FiscalDataSetTableAdapters.CamposTableAdapter();
            this.taConjuntoCampos = new FiscalApp.FiscalDataSetTableAdapters.ConjuntoCamposTableAdapter();
            this.taListarDadosConjunto = new FiscalApp.FiscalDataSetTableAdapters.ListarDadosConjuntoTableAdapter();
            this.bsObterConfigConjunto = new System.Windows.Forms.BindingSource(this.components);
            this.taObterConfigConjunto = new FiscalApp.FiscalDataSetTableAdapters.ObterConfigConjuntoTableAdapter();
            this.chavesDeAcessoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.copiarChageOrigemEReferênciaParaOperNãoRealizadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.mainTabControl.SuspendLayout();
            this.tabPageConjunto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConjunto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsConjunto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fiscalDataSet)).BeginInit();
            this.tabPageCampos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCampos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCampos)).BeginInit();
            this.tabPageConjuntoCampos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConjuntoCampos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsConjuntoCampos)).BeginInit();
            this.tabPageListagemConjuntos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarConjuntos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListarDadosConjunto)).BeginInit();
            this.tabPageChavesAcesso.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.cntxLinkLabel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsObterConfigConjunto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chavesDeAcessoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.Controls.Add(this.tabPageConjunto);
            this.mainTabControl.Controls.Add(this.tabPageCampos);
            this.mainTabControl.Controls.Add(this.tabPageConjuntoCampos);
            this.mainTabControl.Controls.Add(this.tabPageListagemConjuntos);
            this.mainTabControl.Controls.Add(this.tabPageChavesAcesso);
            this.mainTabControl.Location = new System.Drawing.Point(8, 60);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(785, 424);
            this.mainTabControl.TabIndex = 6;
            this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged);
            // 
            // tabPageConjunto
            // 
            this.tabPageConjunto.Controls.Add(this.dgvConjunto);
            this.tabPageConjunto.Location = new System.Drawing.Point(4, 22);
            this.tabPageConjunto.Name = "tabPageConjunto";
            this.tabPageConjunto.Size = new System.Drawing.Size(777, 398);
            this.tabPageConjunto.TabIndex = 1;
            this.tabPageConjunto.Text = "Conjunto de Campos";
            this.tabPageConjunto.UseVisualStyleBackColor = true;
            // 
            // dgvConjunto
            // 
            this.dgvConjunto.AutoGenerateColumns = false;
            this.dgvConjunto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConjunto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nomeDataGridViewTextBoxColumn});
            this.dgvConjunto.DataSource = this.bsConjunto;
            this.dgvConjunto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConjunto.Location = new System.Drawing.Point(0, 0);
            this.dgvConjunto.MultiSelect = false;
            this.dgvConjunto.Name = "dgvConjunto";
            this.dgvConjunto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConjunto.Size = new System.Drawing.Size(777, 398);
            this.dgvConjunto.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Código";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.Width = 350;
            // 
            // bsConjunto
            // 
            this.bsConjunto.DataMember = "Conjunto";
            this.bsConjunto.DataSource = this.fiscalDataSet;
            // 
            // fiscalDataSet
            // 
            this.fiscalDataSet.DataSetName = "FiscalDataSet";
            this.fiscalDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPageCampos
            // 
            this.tabPageCampos.Controls.Add(this.dgvCampos);
            this.tabPageCampos.Location = new System.Drawing.Point(4, 22);
            this.tabPageCampos.Name = "tabPageCampos";
            this.tabPageCampos.Size = new System.Drawing.Size(777, 398);
            this.tabPageCampos.TabIndex = 2;
            this.tabPageCampos.Text = "Campos";
            this.tabPageCampos.UseVisualStyleBackColor = true;
            // 
            // dgvCampos
            // 
            this.dgvCampos.AutoGenerateColumns = false;
            this.dgvCampos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCampos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.nomeDataGridViewTextBoxColumn1,
            this.locationXDataGridViewTextBoxColumn,
            this.locationYDataGridViewTextBoxColumn});
            this.dgvCampos.DataSource = this.bsCampos;
            this.dgvCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCampos.Location = new System.Drawing.Point(0, 0);
            this.dgvCampos.MultiSelect = false;
            this.dgvCampos.Name = "dgvCampos";
            this.dgvCampos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCampos.Size = new System.Drawing.Size(777, 398);
            this.dgvCampos.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Código";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn1
            // 
            this.nomeDataGridViewTextBoxColumn1.DataPropertyName = "nome";
            this.nomeDataGridViewTextBoxColumn1.HeaderText = "Nome do Campo";
            this.nomeDataGridViewTextBoxColumn1.Name = "nomeDataGridViewTextBoxColumn1";
            this.nomeDataGridViewTextBoxColumn1.Width = 350;
            // 
            // locationXDataGridViewTextBoxColumn
            // 
            this.locationXDataGridViewTextBoxColumn.DataPropertyName = "locationX";
            this.locationXDataGridViewTextBoxColumn.HeaderText = "Coordenada X";
            this.locationXDataGridViewTextBoxColumn.Name = "locationXDataGridViewTextBoxColumn";
            this.locationXDataGridViewTextBoxColumn.Width = 130;
            // 
            // locationYDataGridViewTextBoxColumn
            // 
            this.locationYDataGridViewTextBoxColumn.DataPropertyName = "locationY";
            this.locationYDataGridViewTextBoxColumn.HeaderText = "Coordenada Y";
            this.locationYDataGridViewTextBoxColumn.Name = "locationYDataGridViewTextBoxColumn";
            this.locationYDataGridViewTextBoxColumn.Width = 130;
            // 
            // bsCampos
            // 
            this.bsCampos.DataMember = "Campos";
            this.bsCampos.DataSource = this.fiscalDataSet;
            // 
            // tabPageConjuntoCampos
            // 
            this.tabPageConjuntoCampos.Controls.Add(this.dgvConjuntoCampos);
            this.tabPageConjuntoCampos.Location = new System.Drawing.Point(4, 22);
            this.tabPageConjuntoCampos.Name = "tabPageConjuntoCampos";
            this.tabPageConjuntoCampos.Size = new System.Drawing.Size(777, 398);
            this.tabPageConjuntoCampos.TabIndex = 3;
            this.tabPageConjuntoCampos.Text = "Conjunto X Campos";
            this.tabPageConjuntoCampos.UseVisualStyleBackColor = true;
            // 
            // dgvConjuntoCampos
            // 
            this.dgvConjuntoCampos.AutoGenerateColumns = false;
            this.dgvConjuntoCampos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConjuntoCampos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn2,
            this.idConjuntoDataGridViewTextBoxColumn,
            this.idCamposDataGridViewTextBoxColumn,
            this.qtdeRepeticoesDataGridViewTextBoxColumn,
            this.valorDataGridViewTextBoxColumn});
            this.dgvConjuntoCampos.DataSource = this.bsConjuntoCampos;
            this.dgvConjuntoCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConjuntoCampos.Location = new System.Drawing.Point(0, 0);
            this.dgvConjuntoCampos.MultiSelect = false;
            this.dgvConjuntoCampos.Name = "dgvConjuntoCampos";
            this.dgvConjuntoCampos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConjuntoCampos.Size = new System.Drawing.Size(777, 398);
            this.dgvConjuntoCampos.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn2
            // 
            this.idDataGridViewTextBoxColumn2.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn2.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn2.Name = "idDataGridViewTextBoxColumn2";
            this.idDataGridViewTextBoxColumn2.ReadOnly = true;
            this.idDataGridViewTextBoxColumn2.Visible = false;
            // 
            // idConjuntoDataGridViewTextBoxColumn
            // 
            this.idConjuntoDataGridViewTextBoxColumn.DataPropertyName = "Id_Conjunto";
            this.idConjuntoDataGridViewTextBoxColumn.HeaderText = "Código Conjunto";
            this.idConjuntoDataGridViewTextBoxColumn.Name = "idConjuntoDataGridViewTextBoxColumn";
            this.idConjuntoDataGridViewTextBoxColumn.Width = 120;
            // 
            // idCamposDataGridViewTextBoxColumn
            // 
            this.idCamposDataGridViewTextBoxColumn.DataPropertyName = "Id_Campos";
            this.idCamposDataGridViewTextBoxColumn.HeaderText = "Código Campo";
            this.idCamposDataGridViewTextBoxColumn.Name = "idCamposDataGridViewTextBoxColumn";
            this.idCamposDataGridViewTextBoxColumn.Width = 120;
            // 
            // qtdeRepeticoesDataGridViewTextBoxColumn
            // 
            this.qtdeRepeticoesDataGridViewTextBoxColumn.DataPropertyName = "QtdeRepeticoes";
            dataGridViewCellStyle4.NullValue = "0";
            this.qtdeRepeticoesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.qtdeRepeticoesDataGridViewTextBoxColumn.HeaderText = "Qtde. Repetições";
            this.qtdeRepeticoesDataGridViewTextBoxColumn.Name = "qtdeRepeticoesDataGridViewTextBoxColumn";
            this.qtdeRepeticoesDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtdeRepeticoesDataGridViewTextBoxColumn.Visible = false;
            this.qtdeRepeticoesDataGridViewTextBoxColumn.Width = 140;
            // 
            // valorDataGridViewTextBoxColumn
            // 
            this.valorDataGridViewTextBoxColumn.DataPropertyName = "Valor";
            this.valorDataGridViewTextBoxColumn.HeaderText = "Valor";
            this.valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            this.valorDataGridViewTextBoxColumn.Width = 140;
            // 
            // bsConjuntoCampos
            // 
            this.bsConjuntoCampos.DataMember = "ConjuntoCampos";
            this.bsConjuntoCampos.DataSource = this.fiscalDataSet;
            // 
            // tabPageListagemConjuntos
            // 
            this.tabPageListagemConjuntos.Controls.Add(this.dgvListarConjuntos);
            this.tabPageListagemConjuntos.Location = new System.Drawing.Point(4, 22);
            this.tabPageListagemConjuntos.Name = "tabPageListagemConjuntos";
            this.tabPageListagemConjuntos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageListagemConjuntos.Size = new System.Drawing.Size(777, 398);
            this.tabPageListagemConjuntos.TabIndex = 4;
            this.tabPageListagemConjuntos.Text = "Lista dos Conjuntos";
            this.tabPageListagemConjuntos.UseVisualStyleBackColor = true;
            // 
            // dgvListarConjuntos
            // 
            this.dgvListarConjuntos.AllowUserToAddRows = false;
            this.dgvListarConjuntos.AllowUserToDeleteRows = false;
            this.dgvListarConjuntos.AutoGenerateColumns = false;
            this.dgvListarConjuntos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvListarConjuntos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListarConjuntos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idConjuntoDataGridViewTextBoxColumn1,
            this.nomeconjuntoDataGridViewTextBoxColumn,
            this.nomecampoDataGridViewTextBoxColumn,
            this.textocampoDataGridViewTextBoxColumn,
            this.locationXDataGridViewTextBoxColumn1,
            this.locationYDataGridViewTextBoxColumn1});
            this.dgvListarConjuntos.DataSource = this.bsListarDadosConjunto;
            this.dgvListarConjuntos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListarConjuntos.Location = new System.Drawing.Point(3, 3);
            this.dgvListarConjuntos.Name = "dgvListarConjuntos";
            this.dgvListarConjuntos.ReadOnly = true;
            this.dgvListarConjuntos.Size = new System.Drawing.Size(771, 392);
            this.dgvListarConjuntos.TabIndex = 0;
            // 
            // idConjuntoDataGridViewTextBoxColumn1
            // 
            this.idConjuntoDataGridViewTextBoxColumn1.DataPropertyName = "Id_Conjunto";
            this.idConjuntoDataGridViewTextBoxColumn1.HeaderText = "Cód. Conjunto";
            this.idConjuntoDataGridViewTextBoxColumn1.Name = "idConjuntoDataGridViewTextBoxColumn1";
            this.idConjuntoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idConjuntoDataGridViewTextBoxColumn1.Width = 91;
            // 
            // nomeconjuntoDataGridViewTextBoxColumn
            // 
            this.nomeconjuntoDataGridViewTextBoxColumn.DataPropertyName = "nome_conjunto";
            this.nomeconjuntoDataGridViewTextBoxColumn.HeaderText = "Nome Conjunto";
            this.nomeconjuntoDataGridViewTextBoxColumn.Name = "nomeconjuntoDataGridViewTextBoxColumn";
            this.nomeconjuntoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomeconjuntoDataGridViewTextBoxColumn.Width = 96;
            // 
            // nomecampoDataGridViewTextBoxColumn
            // 
            this.nomecampoDataGridViewTextBoxColumn.DataPropertyName = "nome_campo";
            this.nomecampoDataGridViewTextBoxColumn.HeaderText = "Nome do Campo";
            this.nomecampoDataGridViewTextBoxColumn.Name = "nomecampoDataGridViewTextBoxColumn";
            this.nomecampoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomecampoDataGridViewTextBoxColumn.Width = 102;
            // 
            // textocampoDataGridViewTextBoxColumn
            // 
            this.textocampoDataGridViewTextBoxColumn.DataPropertyName = "texto_campo";
            this.textocampoDataGridViewTextBoxColumn.HeaderText = "Texto do Campo";
            this.textocampoDataGridViewTextBoxColumn.Name = "textocampoDataGridViewTextBoxColumn";
            this.textocampoDataGridViewTextBoxColumn.ReadOnly = true;
            this.textocampoDataGridViewTextBoxColumn.Width = 101;
            // 
            // locationXDataGridViewTextBoxColumn1
            // 
            this.locationXDataGridViewTextBoxColumn1.DataPropertyName = "locationX";
            this.locationXDataGridViewTextBoxColumn1.HeaderText = "X";
            this.locationXDataGridViewTextBoxColumn1.Name = "locationXDataGridViewTextBoxColumn1";
            this.locationXDataGridViewTextBoxColumn1.ReadOnly = true;
            this.locationXDataGridViewTextBoxColumn1.Width = 39;
            // 
            // locationYDataGridViewTextBoxColumn1
            // 
            this.locationYDataGridViewTextBoxColumn1.DataPropertyName = "locationY";
            this.locationYDataGridViewTextBoxColumn1.HeaderText = "Y";
            this.locationYDataGridViewTextBoxColumn1.Name = "locationYDataGridViewTextBoxColumn1";
            this.locationYDataGridViewTextBoxColumn1.ReadOnly = true;
            this.locationYDataGridViewTextBoxColumn1.Width = 39;
            // 
            // bsListarDadosConjunto
            // 
            this.bsListarDadosConjunto.DataMember = "ListarDadosConjunto";
            this.bsListarDadosConjunto.DataSource = this.fiscalDataSet;
            // 
            // tabPageChavesAcesso
            // 
            this.tabPageChavesAcesso.Controls.Add(this.tableLayoutPanel1);
            this.tabPageChavesAcesso.Location = new System.Drawing.Point(4, 22);
            this.tabPageChavesAcesso.Name = "tabPageChavesAcesso";
            this.tabPageChavesAcesso.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChavesAcesso.Size = new System.Drawing.Size(777, 398);
            this.tabPageChavesAcesso.TabIndex = 5;
            this.tabPageChavesAcesso.Text = "Chaves de Acesso";
            this.tabPageChavesAcesso.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtResultadoConsulta, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtChavesDeAcesso, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(771, 392);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // txtResultadoConsulta
            // 
            this.txtResultadoConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResultadoConsulta.Location = new System.Drawing.Point(388, 3);
            this.txtResultadoConsulta.Multiline = true;
            this.txtResultadoConsulta.Name = "txtResultadoConsulta";
            this.txtResultadoConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResultadoConsulta.Size = new System.Drawing.Size(380, 386);
            this.txtResultadoConsulta.TabIndex = 2;
            // 
            // txtChavesDeAcesso
            // 
            this.txtChavesDeAcesso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChavesDeAcesso.Location = new System.Drawing.Point(3, 3);
            this.txtChavesDeAcesso.Multiline = true;
            this.txtChavesDeAcesso.Name = "txtChavesDeAcesso";
            this.txtChavesDeAcesso.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtChavesDeAcesso.Size = new System.Drawing.Size(379, 386);
            this.txtChavesDeAcesso.TabIndex = 1;
            // 
            // cntxLinkLabel
            // 
            this.cntxLinkLabel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarParaHotWordToolStripMenuItem,
            this.toolStripSeparator5,
            this.copiarToolStripMenuItem,
            this.toolStripSeparator2,
            this.repetir5xECopiarToolStripMenuItem,
            this.repetir10xECopiarToolStripMenuItem,
            this.repetir15xECopiarToolStripMenuItem,
            this.repetir20xECopiarToolStripMenuItem,
            this.repetir25xECopiarToolStripMenuItem});
            this.cntxLinkLabel.Name = "cntxLinkLabel";
            this.cntxLinkLabel.Size = new System.Drawing.Size(215, 170);
            // 
            // adicionarParaHotWordToolStripMenuItem
            // 
            this.adicionarParaHotWordToolStripMenuItem.Name = "adicionarParaHotWordToolStripMenuItem";
            this.adicionarParaHotWordToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.adicionarParaHotWordToolStripMenuItem.Text = "Adicionar como Hot Word";
            this.adicionarParaHotWordToolStripMenuItem.Click += new System.EventHandler(this.adicionarParaHotWordToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(211, 6);
            // 
            // copiarToolStripMenuItem
            // 
            this.copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
            this.copiarToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.copiarToolStripMenuItem.Text = "Copiar";
            this.copiarToolStripMenuItem.Click += new System.EventHandler(this.copiarToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(211, 6);
            // 
            // repetir5xECopiarToolStripMenuItem
            // 
            this.repetir5xECopiarToolStripMenuItem.Name = "repetir5xECopiarToolStripMenuItem";
            this.repetir5xECopiarToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.repetir5xECopiarToolStripMenuItem.Text = "Repetir 5x e Copiar";
            this.repetir5xECopiarToolStripMenuItem.Click += new System.EventHandler(this.repetir5xECopiarToolStripMenuItem_Click);
            // 
            // repetir10xECopiarToolStripMenuItem
            // 
            this.repetir10xECopiarToolStripMenuItem.Name = "repetir10xECopiarToolStripMenuItem";
            this.repetir10xECopiarToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.repetir10xECopiarToolStripMenuItem.Text = "Repetir 10x e Copiar";
            this.repetir10xECopiarToolStripMenuItem.Click += new System.EventHandler(this.repetir10xECopiarToolStripMenuItem_Click);
            // 
            // repetir15xECopiarToolStripMenuItem
            // 
            this.repetir15xECopiarToolStripMenuItem.Name = "repetir15xECopiarToolStripMenuItem";
            this.repetir15xECopiarToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.repetir15xECopiarToolStripMenuItem.Text = "Repetir 15x e Copiar";
            this.repetir15xECopiarToolStripMenuItem.Click += new System.EventHandler(this.repetir15xECopiarToolStripMenuItem_Click);
            // 
            // repetir20xECopiarToolStripMenuItem
            // 
            this.repetir20xECopiarToolStripMenuItem.Name = "repetir20xECopiarToolStripMenuItem";
            this.repetir20xECopiarToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.repetir20xECopiarToolStripMenuItem.Text = "Repetir 20x e Copiar";
            this.repetir20xECopiarToolStripMenuItem.Click += new System.EventHandler(this.repetir20xECopiarToolStripMenuItem_Click);
            // 
            // repetir25xECopiarToolStripMenuItem
            // 
            this.repetir25xECopiarToolStripMenuItem.Name = "repetir25xECopiarToolStripMenuItem";
            this.repetir25xECopiarToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.repetir25xECopiarToolStripMenuItem.Text = "Repetir 25x e Copiar";
            this.repetir25xECopiarToolStripMenuItem.Click += new System.EventHandler(this.repetir25xECopiarToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aplicativoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.hotWordsToolStripMenuItem,
            this.eGRToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(801, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aplicativoToolStripMenuItem
            // 
            this.aplicativoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reiniciarTextosToolStripMenuItem,
            this.toolStripSeparator4,
            this.sempreNoTopoToolStripMenuItem,
            this.toolStripSeparator3,
            this.obterLocationToolStripMenuItem,
            this.posicionarEmCoordenadasToolStripMenuItem,
            this.toolStripSeparator1,
            this.sairToolStripMenuItem});
            this.aplicativoToolStripMenuItem.Name = "aplicativoToolStripMenuItem";
            this.aplicativoToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.aplicativoToolStripMenuItem.Text = "Aplicativo";
            // 
            // reiniciarTextosToolStripMenuItem
            // 
            this.reiniciarTextosToolStripMenuItem.Name = "reiniciarTextosToolStripMenuItem";
            this.reiniciarTextosToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.reiniciarTextosToolStripMenuItem.Text = "Reiniciar Textos";
            this.reiniciarTextosToolStripMenuItem.Visible = false;
            this.reiniciarTextosToolStripMenuItem.Click += new System.EventHandler(this.reiniciarTextosToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(291, 6);
            this.toolStripSeparator4.Visible = false;
            // 
            // sempreNoTopoToolStripMenuItem
            // 
            this.sempreNoTopoToolStripMenuItem.CheckOnClick = true;
            this.sempreNoTopoToolStripMenuItem.Name = "sempreNoTopoToolStripMenuItem";
            this.sempreNoTopoToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.sempreNoTopoToolStripMenuItem.Text = "Sempre no Topo";
            this.sempreNoTopoToolStripMenuItem.CheckedChanged += new System.EventHandler(this.sempreNoTopoToolStripMenuItem_CheckedChanged);
            this.sempreNoTopoToolStripMenuItem.Click += new System.EventHandler(this.sempreNoTopoToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(291, 6);
            // 
            // obterLocationToolStripMenuItem
            // 
            this.obterLocationToolStripMenuItem.Name = "obterLocationToolStripMenuItem";
            this.obterLocationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F12)));
            this.obterLocationToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.obterLocationToolStripMenuItem.Text = "Obter Mouse Coordinates";
            this.obterLocationToolStripMenuItem.Click += new System.EventHandler(this.obterLocationToolStripMenuItem_Click);
            // 
            // posicionarEmCoordenadasToolStripMenuItem
            // 
            this.posicionarEmCoordenadasToolStripMenuItem.Name = "posicionarEmCoordenadasToolStripMenuItem";
            this.posicionarEmCoordenadasToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.posicionarEmCoordenadasToolStripMenuItem.Text = "Posicionar em Coordenadas";
            this.posicionarEmCoordenadasToolStripMenuItem.Click += new System.EventHandler(this.posicionarEmCoordenadasToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(291, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(294, 22);
            this.sairToolStripMenuItem.Text = "&Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copiarÚltimaPalavraToolStripMenuItem,
            this.toolStripSeparator6,
            this.repetirCFOPEServiçoToolStripMenuItem,
            this.repetirCódigoImpostoToolStripMenuItem,
            this.toolStripSeparator13,
            this.calcularVlrUnitarioDePedido100ToolStripMenuItem,
            this.toolStripSeparator14,
            this.entrarDadosTelefoniaToolStripMenuItem});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // copiarÚltimaPalavraToolStripMenuItem
            // 
            this.copiarÚltimaPalavraToolStripMenuItem.Name = "copiarÚltimaPalavraToolStripMenuItem";
            this.copiarÚltimaPalavraToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.copiarÚltimaPalavraToolStripMenuItem.Text = "Copiar Última Palavra";
            this.copiarÚltimaPalavraToolStripMenuItem.Visible = false;
            this.copiarÚltimaPalavraToolStripMenuItem.Click += new System.EventHandler(this.copiarÚltimaPalavraToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(309, 6);
            this.toolStripSeparator6.Visible = false;
            // 
            // repetirCFOPEServiçoToolStripMenuItem
            // 
            this.repetirCFOPEServiçoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("repetirCFOPEServiçoToolStripMenuItem.Image")));
            this.repetirCFOPEServiçoToolStripMenuItem.Name = "repetirCFOPEServiçoToolStripMenuItem";
            this.repetirCFOPEServiçoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
            this.repetirCFOPEServiçoToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.repetirCFOPEServiçoToolStripMenuItem.Text = "Repetir CFOP e Serviço";
            this.repetirCFOPEServiçoToolStripMenuItem.Click += new System.EventHandler(this.repetirCFOPEServiçoToolStripMenuItem_Click);
            // 
            // repetirCódigoImpostoToolStripMenuItem
            // 
            this.repetirCódigoImpostoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("repetirCódigoImpostoToolStripMenuItem.Image")));
            this.repetirCódigoImpostoToolStripMenuItem.Name = "repetirCódigoImpostoToolStripMenuItem";
            this.repetirCódigoImpostoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
            this.repetirCódigoImpostoToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.repetirCódigoImpostoToolStripMenuItem.Text = "Repetir Código Imposto";
            this.repetirCódigoImpostoToolStripMenuItem.Click += new System.EventHandler(this.repetirCódigoImpostoToolStripMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(309, 6);
            // 
            // calcularVlrUnitarioDePedido100ToolStripMenuItem
            // 
            this.calcularVlrUnitarioDePedido100ToolStripMenuItem.Name = "calcularVlrUnitarioDePedido100ToolStripMenuItem";
            this.calcularVlrUnitarioDePedido100ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.calcularVlrUnitarioDePedido100ToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.calcularVlrUnitarioDePedido100ToolStripMenuItem.Text = "Calcular Vlr Unitario de Pedido 100%";
            this.calcularVlrUnitarioDePedido100ToolStripMenuItem.Click += new System.EventHandler(this.calcularVlrUnitarioDePedido100ToolStripMenuItem_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(309, 6);
            // 
            // entrarDadosTelefoniaToolStripMenuItem
            // 
            this.entrarDadosTelefoniaToolStripMenuItem.Name = "entrarDadosTelefoniaToolStripMenuItem";
            this.entrarDadosTelefoniaToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.entrarDadosTelefoniaToolStripMenuItem.Text = "Entrar Dados Telefonia";
            this.entrarDadosTelefoniaToolStripMenuItem.Click += new System.EventHandler(this.entrarDadosTelefoniaToolStripMenuItem_Click);
            // 
            // hotWordsToolStripMenuItem
            // 
            this.hotWordsToolStripMenuItem.Enabled = false;
            this.hotWordsToolStripMenuItem.Name = "hotWordsToolStripMenuItem";
            this.hotWordsToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.hotWordsToolStripMenuItem.Text = "Hot Words";
            // 
            // eGRToolStripMenuItem
            // 
            this.eGRToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entrarEGREPrepararConsultaToolStripMenuItem,
            this.pesquisarChavesDeAcessoToolStripMenuItem,
            this.toolStripSeparator16,
            this.CopiarChvOrigemeRefToolStripMenuItem,
            this.copiarChageOrigemEReferênciaParaOperNãoRealizadaToolStripMenuItem,
            this.toolStripSeparator12,
            this.controleDeNFeToolStripMenuItem,
            this.toolStripSeparator10,
            this.consultarProtocoloToolStripMenuItem,
            this.consultarNaturezaOperaçãoNFsToolStripMenuItem,
            this.confirmarOperaçãoEmMassaToolStripMenuItem,
            this.toolStripSeparator11,
            this.downloadXMLToolStripMenuItem});
            this.eGRToolStripMenuItem.Name = "eGRToolStripMenuItem";
            this.eGRToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.eGRToolStripMenuItem.Text = "EGR";
            // 
            // entrarEGREPrepararConsultaToolStripMenuItem
            // 
            this.entrarEGREPrepararConsultaToolStripMenuItem.Name = "entrarEGREPrepararConsultaToolStripMenuItem";
            this.entrarEGREPrepararConsultaToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.entrarEGREPrepararConsultaToolStripMenuItem.Text = "Entrar EGR e Consultar Chaves na Clipboard";
            this.entrarEGREPrepararConsultaToolStripMenuItem.Click += new System.EventHandler(this.entrarEGREPrepararConsultaToolStripMenuItem_Click);
            // 
            // pesquisarChavesDeAcessoToolStripMenuItem
            // 
            this.pesquisarChavesDeAcessoToolStripMenuItem.Name = "pesquisarChavesDeAcessoToolStripMenuItem";
            this.pesquisarChavesDeAcessoToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.pesquisarChavesDeAcessoToolStripMenuItem.Text = "Pesquisar Chave(s) de Acesso";
            this.pesquisarChavesDeAcessoToolStripMenuItem.Click += new System.EventHandler(this.pesquisarChavesDeAcessoToolStripMenuItem_Click);
            // 
            // CopiarChvOrigemeRefToolStripMenuItem
            // 
            this.CopiarChvOrigemeRefToolStripMenuItem.Name = "CopiarChvOrigemeRefToolStripMenuItem";
            this.CopiarChvOrigemeRefToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.CopiarChvOrigemeRefToolStripMenuItem.Text = "Copiar Chave Origem e Referência";
            this.CopiarChvOrigemeRefToolStripMenuItem.Click += new System.EventHandler(this.CopiarChvOrigemeRefToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(301, 6);
            // 
            // controleDeNFeToolStripMenuItem
            // 
            this.controleDeNFeToolStripMenuItem.Name = "controleDeNFeToolStripMenuItem";
            this.controleDeNFeToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.controleDeNFeToolStripMenuItem.Text = "Controle de NFe";
            this.controleDeNFeToolStripMenuItem.Click += new System.EventHandler(this.controleDeNFeToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(301, 6);
            // 
            // consultarProtocoloToolStripMenuItem
            // 
            this.consultarProtocoloToolStripMenuItem.Enabled = false;
            this.consultarProtocoloToolStripMenuItem.Name = "consultarProtocoloToolStripMenuItem";
            this.consultarProtocoloToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.consultarProtocoloToolStripMenuItem.Text = "Consultar Protocolo";
            this.consultarProtocoloToolStripMenuItem.Click += new System.EventHandler(this.consultarProtocoloToolStripMenuItem_Click);
            // 
            // consultarNaturezaOperaçãoNFsToolStripMenuItem
            // 
            this.consultarNaturezaOperaçãoNFsToolStripMenuItem.Enabled = false;
            this.consultarNaturezaOperaçãoNFsToolStripMenuItem.Name = "consultarNaturezaOperaçãoNFsToolStripMenuItem";
            this.consultarNaturezaOperaçãoNFsToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.consultarNaturezaOperaçãoNFsToolStripMenuItem.Text = "Consultar Natureza Operação NFs";
            this.consultarNaturezaOperaçãoNFsToolStripMenuItem.Click += new System.EventHandler(this.consultarNaturezaOperaçãoNFsToolStripMenuItem_Click);
            // 
            // confirmarOperaçãoEmMassaToolStripMenuItem
            // 
            this.confirmarOperaçãoEmMassaToolStripMenuItem.Name = "confirmarOperaçãoEmMassaToolStripMenuItem";
            this.confirmarOperaçãoEmMassaToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.confirmarOperaçãoEmMassaToolStripMenuItem.Text = "Confirmar Operação Em Massa";
            this.confirmarOperaçãoEmMassaToolStripMenuItem.Click += new System.EventHandler(this.confirmarOperaçãoEmMassaToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(301, 6);
            // 
            // downloadXMLToolStripMenuItem
            // 
            this.downloadXMLToolStripMenuItem.Name = "downloadXMLToolStripMenuItem";
            this.downloadXMLToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.downloadXMLToolStripMenuItem.Text = "Download XML";
            this.downloadXMLToolStripMenuItem.Click += new System.EventHandler(this.downloadXMLToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDaInstalaçãoToolStripMenuItem});
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sobreToolStripMenuItem.Text = "Sobre";
            // 
            // localDaInstalaçãoToolStripMenuItem
            // 
            this.localDaInstalaçãoToolStripMenuItem.Name = "localDaInstalaçãoToolStripMenuItem";
            this.localDaInstalaçãoToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.localDaInstalaçãoToolStripMenuItem.Text = "Local da Instalação";
            this.localDaInstalaçãoToolStripMenuItem.Click += new System.EventHandler(this.localDaInstalaçãoToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGravar,
            this.toolStripSeparator7,
            this.tsbRunSet,
            this.toolStripSeparator8,
            this.toolStripLabel1,
            this.tsbQtdeRepeticoes,
            this.toolStripSeparator9,
            this.tsbRepeatCFOPServico,
            this.tsbRepetirCodImposto,
            this.toolStripSeparator15,
            this.tsbtnPesqChvAcessoEGR});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(801, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbGravar
            // 
            this.tsbGravar.Image = ((System.Drawing.Image)(resources.GetObject("tsbGravar.Image")));
            this.tsbGravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGravar.Name = "tsbGravar";
            this.tsbGravar.Size = new System.Drawing.Size(61, 22);
            this.tsbGravar.Text = "Gravar";
            this.tsbGravar.ToolTipText = "Gravar alterações";
            this.tsbGravar.Click += new System.EventHandler(this.tsbGravar_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbRunSet
            // 
            this.tsbRunSet.Image = ((System.Drawing.Image)(resources.GetObject("tsbRunSet.Image")));
            this.tsbRunSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRunSet.Name = "tsbRunSet";
            this.tsbRunSet.Size = new System.Drawing.Size(71, 22);
            this.tsbRunSet.Text = "Executar";
            this.tsbRunSet.ToolTipText = "Executar conjunto de campos";
            this.tsbRunSet.Click += new System.EventHandler(this.tsbRunSet_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(61, 22);
            this.toolStripLabel1.Text = "Repetir Nx";
            // 
            // tsbQtdeRepeticoes
            // 
            this.tsbQtdeRepeticoes.Name = "tsbQtdeRepeticoes";
            this.tsbQtdeRepeticoes.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbRepeatCFOPServico
            // 
            this.tsbRepeatCFOPServico.Image = ((System.Drawing.Image)(resources.GetObject("tsbRepeatCFOPServico.Image")));
            this.tsbRepeatCFOPServico.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRepeatCFOPServico.Name = "tsbRepeatCFOPServico";
            this.tsbRepeatCFOPServico.Size = new System.Drawing.Size(107, 22);
            this.tsbRepeatCFOPServico.Text = "CFOP e Serviço";
            this.tsbRepeatCFOPServico.Click += new System.EventHandler(this.tsbRepeatCFOPServico_Click);
            // 
            // tsbRepetirCodImposto
            // 
            this.tsbRepetirCodImposto.Image = ((System.Drawing.Image)(resources.GetObject("tsbRepetirCodImposto.Image")));
            this.tsbRepetirCodImposto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRepetirCodImposto.Name = "tsbRepetirCodImposto";
            this.tsbRepetirCodImposto.Size = new System.Drawing.Size(113, 22);
            this.tsbRepetirCodImposto.Text = "Código Imposto";
            this.tsbRepetirCodImposto.Click += new System.EventHandler(this.tsbRepetirCodImposto_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnPesqChvAcessoEGR
            // 
            this.tsbtnPesqChvAcessoEGR.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPesqChvAcessoEGR.Image")));
            this.tsbtnPesqChvAcessoEGR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPesqChvAcessoEGR.Name = "tsbtnPesqChvAcessoEGR";
            this.tsbtnPesqChvAcessoEGR.Size = new System.Drawing.Size(182, 22);
            this.tsbtnPesqChvAcessoEGR.Text = "Pesquisar Chave(s) de Acesso";
            this.tsbtnPesqChvAcessoEGR.Click += new System.EventHandler(this.tsbtnPesqChvAcessoEGR_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // taConjunto
            // 
            this.taConjunto.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CamposTableAdapter = this.taCampos;
            this.tableAdapterManager.ConjuntoCamposTableAdapter = this.taConjuntoCampos;
            this.tableAdapterManager.ConjuntoTableAdapter = this.taConjunto;
            this.tableAdapterManager.ControleNFETableAdapter = null;
            this.tableAdapterManager.Finalidade_NFeTableAdapter = null;
            this.tableAdapterManager.Manifestacoes_NFeTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = FiscalApp.FiscalDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // taCampos
            // 
            this.taCampos.ClearBeforeFill = true;
            // 
            // taConjuntoCampos
            // 
            this.taConjuntoCampos.ClearBeforeFill = true;
            // 
            // taListarDadosConjunto
            // 
            this.taListarDadosConjunto.ClearBeforeFill = true;
            // 
            // bsObterConfigConjunto
            // 
            this.bsObterConfigConjunto.DataMember = "ObterConfigConjunto";
            this.bsObterConfigConjunto.DataSource = this.fiscalDataSet;
            // 
            // taObterConfigConjunto
            // 
            this.taObterConfigConjunto.ClearBeforeFill = true;
            // 
            // chavesDeAcessoBindingSource
            // 
            this.chavesDeAcessoBindingSource.DataMember = "ChavesDeAcesso";
            this.chavesDeAcessoBindingSource.DataSource = this.fiscalDataSet;
            // 
            // copiarChageOrigemEReferênciaParaOperNãoRealizadaToolStripMenuItem
            // 
            this.copiarChageOrigemEReferênciaParaOperNãoRealizadaToolStripMenuItem.Name = "copiarChageOrigemEReferênciaParaOperNãoRealizadaToolStripMenuItem";
            this.copiarChageOrigemEReferênciaParaOperNãoRealizadaToolStripMenuItem.Size = new System.Drawing.Size(390, 22);
            this.copiarChageOrigemEReferênciaParaOperNãoRealizadaToolStripMenuItem.Text = "Copiar Chave Origem e Referência para Oper. Não Realizada";
            this.copiarChageOrigemEReferênciaParaOperNãoRealizadaToolStripMenuItem.Click += new System.EventHandler(this.copiarChageOrigemEReferênciaParaOperNãoRealizadaToolStripMenuItem_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(388, 6);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 492);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(331, 490);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fiscal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.mainTabControl.ResumeLayout(false);
            this.tabPageConjunto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConjunto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsConjunto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fiscalDataSet)).EndInit();
            this.tabPageCampos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCampos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCampos)).EndInit();
            this.tabPageConjuntoCampos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConjuntoCampos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsConjuntoCampos)).EndInit();
            this.tabPageListagemConjuntos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarConjuntos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListarDadosConjunto)).EndInit();
            this.tabPageChavesAcesso.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.cntxLinkLabel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsObterConfigConjunto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chavesDeAcessoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aplicativoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reiniciarTextosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copiarÚltimaPalavraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repetir5xECopiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repetir10xECopiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repetir15xECopiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repetir20xECopiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repetir25xECopiarToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip cntxLinkLabel;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem hotWordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adicionarParaHotWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem sempreNoTopoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem obterLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem repetirCFOPEServiçoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TabPage tabPageConjunto;
        private System.Windows.Forms.DataGridView dgvConjunto;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbGravar;
        private System.Windows.Forms.TabPage tabPageCampos;
        private System.Windows.Forms.DataGridView dgvCampos;
        private System.Windows.Forms.TabPage tabPageConjuntoCampos;
        private System.Windows.Forms.DataGridView dgvConjuntoCampos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tsbRunSet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tsbQtdeRepeticoes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.TabPage tabPageListagemConjuntos;
        private System.Windows.Forms.DataGridView dgvListarConjuntos;
        private System.Windows.Forms.ToolStripMenuItem repetirCódigoImpostoToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton tsbRepeatCFOPServico;
        private System.Windows.Forms.ToolStripButton tsbRepetirCodImposto;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.BindingSource bsConjunto;
        private FiscalDataSetTableAdapters.ConjuntoTableAdapter taConjunto;
        private FiscalDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource bsCampos;
        private FiscalDataSetTableAdapters.CamposTableAdapter taCampos;
        private System.Windows.Forms.BindingSource bsConjuntoCampos;
        private FiscalDataSetTableAdapters.ConjuntoCamposTableAdapter taConjuntoCampos;
        private System.Windows.Forms.BindingSource bsListarDadosConjunto;
        private FiscalDataSetTableAdapters.ListarDadosConjuntoTableAdapter taListarDadosConjunto;
        private System.Windows.Forms.BindingSource bsObterConfigConjunto;
        private FiscalDataSetTableAdapters.ObterConfigConjuntoTableAdapter taObterConfigConjunto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idConjuntoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCamposDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdeRepeticoesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idConjuntoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeconjuntoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomecampoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn textocampoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationXDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationYDataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDaInstalaçãoToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageChavesAcesso;
        private System.Windows.Forms.ToolStripMenuItem eGRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarProtocoloToolStripMenuItem;
        private System.Windows.Forms.BindingSource chavesDeAcessoBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtResultadoConsulta;
        private System.Windows.Forms.TextBox txtChavesDeAcesso;
        private System.Windows.Forms.ToolStripMenuItem consultarNaturezaOperaçãoNFsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem confirmarOperaçãoEmMassaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controleDeNFeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem entrarEGREPrepararConsultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem calcularVlrUnitarioDePedido100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posicionarEmCoordenadasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripMenuItem entrarDadosTelefoniaToolStripMenuItem;
        public FiscalDataSet fiscalDataSet;
        private System.Windows.Forms.ToolStripMenuItem pesquisarChavesDeAcessoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripButton tsbtnPesqChvAcessoEGR;
        private System.Windows.Forms.ToolStripMenuItem CopiarChvOrigemeRefToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripMenuItem copiarChageOrigemEReferênciaParaOperNãoRealizadaToolStripMenuItem;
    }
}

