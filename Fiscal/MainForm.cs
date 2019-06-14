using AutoIt;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static FiscalApp.FiscalDataSet;

namespace FiscalApp
{
    public partial class MainForm : Form
    {
        IntPtr whnd;
        SortedDictionary<string, string> hotwords = new SortedDictionary<string, string>();
        const int SAP_Y_COORD_OFFSET = 120;
        const int MAX_ITENS_PER_PAGE = 18;
        const int WAIT_TIME_QUERY_NF = 7500;

        public enum MouseButton
        {
            RIGHT = 1,
            LEFT = 2
        }

        //private CamposTableAdapter camposTableAdapter = new CamposTableAdapter();
        //private ConjuntoTableAdapter conjuntoTableAdapter = new ConjuntoTableAdapter();
        //private ConjuntoCamposTableAdapter conjuntoCamposTableAdapter = new ConjuntoCamposTableAdapter();
        //private ListarDadosConjuntoTableAdapter listarDadosConjuntoTableAdapter = new ListarDadosConjuntoTableAdapter();

        public MainForm()
        {
            InitializeComponent();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
#if DEBUG
            var sqlConnection = DatabaseConnection.DEBUGConnection;
            taConjunto.Connection = sqlConnection;
            taCampos.Connection = sqlConnection;
            taConjuntoCampos.Connection = sqlConnection;
            taListarDadosConjunto.Connection = sqlConnection;
            //#else
            //            sb.AppendLine(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=");
            //            sb.Append(System.IO.Path.GetDirectoryName(Application.UserAppDataPath) + @"\Data\App_Data\Database.mdf");
            //            sb.Append(";Integrated Security=True");

            //            global::FiscalApp.Properties.Settings.Default.dbProgram = sb.ToString();
#endif

            try
            {
                taConjunto.Fill(fiscalDataSet.Conjunto);
                taCampos.Fill(fiscalDataSet.Campos);
                taConjuntoCampos.Fill(fiscalDataSet.ConjuntoCampos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            whnd = AutoItX.WinGetHandle(Text);

            dgvConjunto.DataError += dataGridView_DataError;
            dgvCampos.DataError += dataGridView_DataError;
            dgvConjuntoCampos.DataError += dataGridView_DataError;

            if (!string.IsNullOrEmpty(FiscalApp.Properties.Settings.Default.HotWords))
            {
                string[] words = FiscalApp.Properties.Settings.Default.HotWords.Split(new char[] { '|' });

                if (words.Length > 0)
                {
                    foreach (string word in words)
                    {
                        if (!string.IsNullOrEmpty(word))
                        {
                            hotwords.Add(word, word);
                        }
                    }

                    // creates ordered menu items
                    foreach (KeyValuePair<string, string> item in hotwords)
                    {
                        criarHotWordMenu(item.Value);
                    }
                }
            }
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //throw new NotImplementedException();
            MessageBox.Show(e.Exception.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            e.Cancel = true;
        }

        private void reiniciarTextosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void copiarÚltimaPalavraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Program._lastWord);
        }

        private string repeatXTimes(int times, string value)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < times; i++)
            {
                sb.AppendLine(value);
            }

            return sb.ToString();
        }

        private string getSourceControlString(object sender)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            // se chamado pelo menu
            if (item.Owner.GetType() == typeof(ToolStripDropDownMenu))
            {

                if (item.OwnerItem.Tag != null)
                {
                    if (item.OwnerItem.Tag.ToString().Equals("copiarx"))
                    {
                        return item.OwnerItem.Text;
                    }
                }

                return item.Text;
            }

            // gets the owner menuitem
            ContextMenuStrip owner = item.Owner as ContextMenuStrip;

            // gets source of context menu.
            LinkLabel source = owner.SourceControl as LinkLabel;

            return source.Text;
        }

        private void repetir5xECopiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string texto = repeatXTimes(5, getSourceControlString(sender));
            Clipboard.SetText(texto);
            //tryToInsertTextOnSAP(texto);
        }

        private void repetir10xECopiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string texto = repeatXTimes(10, getSourceControlString(sender));
            Clipboard.SetText(texto);
            //tryToInsertTextOnSAP(texto);
        }

        private void repetir15xECopiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string texto = repeatXTimes(15, getSourceControlString(sender));
            Clipboard.SetText(texto);
            //tryToInsertTextOnSAP(texto);
        }

        private void repetir20xECopiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string texto = repeatXTimes(20, getSourceControlString(sender));
            Clipboard.SetText(texto);
            //tryToInsertTextOnSAP(texto);
        }

        private void repetir25xECopiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string texto = repeatXTimes(25, getSourceControlString(sender));
            Clipboard.SetText(texto);
            //tryToInsertTextOnSAP(texto);
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(getSourceControlString(sender));
            //tryToInsertTextOnSAP();
        }

        private void criarHotWordMenu(string texto)
        {
            ToolStripMenuItem menu = new ToolStripMenuItem()
            {
                Text = texto,
                Tag = "copiarx"
            };

            menu.Click += copiarToolStripMenuItem_Click;

            #region "Cria os sub-menus para os hotwords"
            ToolStripMenuItem copiar = new ToolStripMenuItem()
            {
                Text = copiarToolStripMenuItem.Text,
                Tag = "copiarx"
            };
            copiar.Click += copiarToolStripMenuItem_Click;
            menu.DropDownItems.Add(copiar);

            menu.DropDownItems.Add(new ToolStripSeparator());

            //ToolStripMenuItem inserirNoSAP = new ToolStripMenuItem()
            //{
            //    Text = inserirNoSAPToolStripMenuItem.Text,
            //    Tag = "inserirNoSAP"
            //};
            //inserirNoSAP.Click += adicionarNoSAPToolStripMenuItem_Click;
            //menu.DropDownItems.Add(inserirNoSAP);

            //menu.DropDownItems.Add(new ToolStripSeparator());

            ToolStripMenuItem repetir5x = new ToolStripMenuItem()
            {
                Text = repetir5xECopiarToolStripMenuItem.Text,
                Tag = "copiarx"
            };
            repetir5x.Click += repetir5xECopiarToolStripMenuItem_Click;
            menu.DropDownItems.Add(repetir5x);

            ToolStripMenuItem repetir10x = new ToolStripMenuItem()
            {
                Text = repetir10xECopiarToolStripMenuItem.Text,
                Tag = "copiarx"
            };
            repetir10x.Click += repetir10xECopiarToolStripMenuItem_Click;
            menu.DropDownItems.Add(repetir10x);

            ToolStripMenuItem repetir15x = new ToolStripMenuItem()
            {
                Text = repetir15xECopiarToolStripMenuItem.Text,
                Tag = "copiarx"
            };
            repetir15x.Click += repetir15xECopiarToolStripMenuItem_Click;
            menu.DropDownItems.Add(repetir15x);

            ToolStripMenuItem repetir20x = new ToolStripMenuItem()
            {
                Text = repetir20xECopiarToolStripMenuItem.Text,
                Tag = "copiarx"
            };
            repetir20x.Click += repetir20xECopiarToolStripMenuItem_Click;
            menu.DropDownItems.Add(repetir20x);

            ToolStripMenuItem repetir25x = new ToolStripMenuItem()
            {
                Text = repetir25xECopiarToolStripMenuItem.Text,
                Tag = "copiarx"
            };
            repetir25x.Click += repetir25xECopiarToolStripMenuItem_Click;
            menu.DropDownItems.Add(repetir25x);

            #endregion

            //inserirNoSAP.DropDownItems.AddRange(new ToolStripItem[]
            //{
            //    repetir5x,
            //    repetir10x,
            //    repetir15x,
            //    repetir20x,
            //    repetir25x
            //});

            hotWordsToolStripMenuItem.DropDownItems.Add(menu);
        }

        private void adicionarParaHotWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string texto = getSourceControlString(sender);
            if (hotwords.ContainsValue(texto))
            {
                MessageBox.Show("HotWord já existe.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                criarHotWordMenu(texto);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //StringBuilder sb = new StringBuilder();

            //foreach (ToolStripMenuItem item in hotWordsToolStripMenuItem.DropDownItems)
            //{
            //    sb.Append(item.Text + "|");
            //}

            //FiscalApp.Properties.Settings.Default.HotWords = sb.ToString();
            FiscalApp.Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Executa o mouse move e o click e após executa um tempo de espera. 
        /// </summary>
        /// <param name="x">Coordenada X</param>
        /// <param name="y">Coordenada X</param>
        /// <param name="toolTip">ToolTip</param>
        /// <param name="noWait">Não aguardar</param>
        /// <param name="waitTime">Tempo de espera em milisegundos antes do click</param>
        public static void clickEditingControl(int x, int y, string toolTip = "", bool noWait = true, int waitTime = 1000, int mouseSpeed = 5, MouseButton button = MouseButton.LEFT)
        {
            // points mouse
            AutoItX.MouseMove(x, y + SAP_Y_COORD_OFFSET, mouseSpeed);

            //AutoItX.MouseClick("LEFT", x, y - SAP_Y_COORD_OFFSET, 1, 5);

            string _button = "LEFT";
            if (button == MouseButton.RIGHT)
            {
                _button = "RIGHT";
            }

            //AutoItX.MouseClick(_button, numClicks: 1, speed: 5);
            AutoItX.MouseClick(_button, numClicks: 1);

            // sets tootip for visual localization
            //if (!string.IsNullOrEmpty(toolTip))
            //{
            //    AutoItX.ToolTip(toolTip);
            //}

            if (noWait)
            {
                // sem esperar
            }
            else
            {
                //AutoItX.Sleep(waitTime);
                System.Threading.Thread.Sleep(waitTime);
            }
        }

        private string selectAndGetTextFromCursor()
        {
            AutoItX.Send("+{END}");
            AutoItX.Send("^c");
            return Clipboard.GetText();
        }

        private void selectTextFromApplication()
        {
            AutoItX.Send("{HOME}");
            AutoItX.Send("{SHIFTDOWN}");
            AutoItX.Send("+{END}");
            AutoItX.Send("{SHIFTUP}");
        }

        private void clearTextSelected()
        {
            AutoItX.Send("{DELETE}");
        }

        private void sendTextFromClipboard()
        {
            AutoItX.Send(Clipboard.GetText());
        }

        private void sendText(string text)
        {
            AutoItX.Send(text);
        }

        private void sempreNoTopoToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            // activates
            var x = AutoItX.WinActivate(whnd);

            if (sempreNoTopoToolStripMenuItem.Checked)
            {
                // top on
                x = AutoItX.WinSetOnTop(whnd, 1);
            }
            else
            {
                // top off
                x = AutoItX.WinSetOnTop(whnd, 0);
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            sempreNoTopoToolStripMenuItem.Checked = global::FiscalApp.Properties.Settings.Default.SempreNoTopo;
        }

        private void sempreNoTopoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            global::FiscalApp.Properties.Settings.Default.SempreNoTopo = sempreNoTopoToolStripMenuItem.Checked;
        }

        private void obterLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder log = new StringBuilder();

            Point cursor = AutoIt.AutoItX.MouseGetPos();

            log.AppendLine("horizontal X: " + cursor.X);
            //log.AppendLine("vertical Y: " + cursor.Y);
            log.AppendLine("vertical Y (SAP offset): " + (cursor.Y - SAP_Y_COORD_OFFSET));

            MessageBox.Show(log.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void sendCONTROLVandRELEASE()
        {
            selectTextFromApplication();
            clearTextSelected();
            sendText("{CTRLDOWN}");
            sendText("v");
            sendText("{CTRLUP}");
        }

        private void sendCONTROLCandRELEASE()
        {
            sendText("{CTRLDOWN}");
            sendText("c");
            sendText("{CTRLUP}");
        }

        private void repetirCFOPEServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CFOP_Servico_Form frm = new CFOP_Servico_Form();

            //const int Y_COORDINATE = 264;
            const int CFOP_ID = 1;
            const int SERVICO_ID = 2;
            const int ICMS_ID = 7;
            const int IPI_ID = 8;
            const int COFINS_ID = 11;
            const int PIS_ID = 10;
            const int CLICK_ROLAGEM_TELA_CFOP = 9;

            CamposRow cfop = (CamposRow)fiscalDataSet.Campos.Select("id = " + CFOP_ID)[0];
            CamposRow servico = (CamposRow)fiscalDataSet.Campos.Select("id = " + SERVICO_ID)[0];
            CamposRow icms = (CamposRow)fiscalDataSet.Campos.Select("id = " + ICMS_ID)[0];
            CamposRow ipi = (CamposRow)fiscalDataSet.Campos.Select("id = " + IPI_ID)[0];
            CamposRow cofins = (CamposRow)fiscalDataSet.Campos.Select("id = " + COFINS_ID)[0];
            CamposRow pis = (CamposRow)fiscalDataSet.Campos.Select("id = " + PIS_ID)[0];
            CamposRow clickRolagem = (CamposRow)fiscalDataSet.Campos.Select("id = " + CLICK_ROLAGEM_TELA_CFOP)[0];

            if (frm.ShowDialog() == DialogResult.OK)
            {
                bringSAPUI_ToFront();

                if (frm.MultiplePagesCheck.Checked)
                {
                    for (decimal page = 1; page <= frm.QtdePaginas.Value; page++)
                    {
                        #region "Preencher"
                        if (frm.CFOP.Text.Length > 0)
                        {
                            clickEditingControl(cfop.locationX, cfop.locationY);      // CFOP

                            string _cfop = repeatXTimes(Convert.ToInt32(frm.QtdeRepeat.Text), frm.CFOP.Text);
                            Clipboard.SetText(_cfop);
                            sendCONTROLVandRELEASE();
                        }

                        if (frm.ICMS.Text.Length > 0)
                        {
                            clickEditingControl(icms.locationX, icms.locationY); // ICMS

                            string _icms = repeatXTimes(Convert.ToInt32(frm.QtdeRepeat.Text), frm.ICMS.Text);
                            Clipboard.SetText(_icms);
                            sendCONTROLVandRELEASE();
                        }

                        if (frm.IPI.Text.Length > 0)
                        {
                            clickEditingControl(ipi.locationX, ipi.locationY); // IPI

                            string _ipi = repeatXTimes(Convert.ToInt32(frm.QtdeRepeat.Text), frm.IPI.Text);
                            Clipboard.SetText(_ipi);
                            sendCONTROLVandRELEASE();
                        }

                        if (frm.CodigoServico.Text.Length > 0)
                        {
                            clickEditingControl(servico.locationX, servico.locationY); // Serviço

                            string _servicos = repeatXTimes(Convert.ToInt32(frm.QtdeRepeat.Text), frm.CodigoServico.Text);
                            Clipboard.SetText(_servicos);
                            sendCONTROLVandRELEASE();
                        }

                        if (frm.COFINS.Text.Length > 0)
                        {
                            clickEditingControl(cofins.locationX, cofins.locationY); // COFINS

                            string _cofins = repeatXTimes(Convert.ToInt32(frm.QtdeRepeat.Text), frm.COFINS.Text);
                            Clipboard.SetText(_cofins);
                            sendCONTROLVandRELEASE();
                        }

                        if (frm.PIS.Text.Length > 0)
                        {
                            clickEditingControl(pis.locationX, pis.locationY); // PIS

                            string _pis = repeatXTimes(Convert.ToInt32(frm.QtdeRepeat.Text), frm.PIS.Text);
                            Clipboard.SetText(_pis);
                            sendCONTROLVandRELEASE();
                        }

                        System.Threading.Thread.Sleep(1000);

                        // clica na barra de rolagem.
                        //clickEditingControl(1672, 700);
                        clickEditingControl(clickRolagem.locationX, clickRolagem.locationY);

                        #endregion
                    }
                }
                else
                {
                    #region "Preencher"
                    if (frm.CFOP.Text.Length > 0)
                    {
                        clickEditingControl(cfop.locationX, cfop.locationY);      // CFOP

                        string _cfop = repeatXTimes(Convert.ToInt32(frm.QtdeRepeat.Text), frm.CFOP.Text);
                        Clipboard.SetText(_cfop);
                        sendCONTROLVandRELEASE();
                    }

                    if (frm.ICMS.Text.Length > 0)
                    {
                        clickEditingControl(icms.locationX, icms.locationY); // ICMS

                        string _icms = repeatXTimes(Convert.ToInt32(frm.QtdeRepeat.Text), frm.ICMS.Text);
                        Clipboard.SetText(_icms);
                        sendCONTROLVandRELEASE();
                    }

                    if (frm.IPI.Text.Length > 0)
                    {
                        clickEditingControl(ipi.locationX, ipi.locationY); // IPI

                        string _ipi = repeatXTimes(Convert.ToInt32(frm.QtdeRepeat.Text), frm.IPI.Text);
                        Clipboard.SetText(_ipi);
                        sendCONTROLVandRELEASE();
                    }

                    if (frm.CodigoServico.Text.Length > 0)
                    {
                        clickEditingControl(servico.locationX, servico.locationY); // Serviço

                        string _servicos = repeatXTimes(Convert.ToInt32(frm.QtdeRepeat.Text), frm.CodigoServico.Text);
                        Clipboard.SetText(_servicos);
                        sendCONTROLVandRELEASE();
                    }

                    if (frm.COFINS.Text.Length > 0)
                    {
                        clickEditingControl(cofins.locationX, cofins.locationY); // COFINS

                        string _cofins = repeatXTimes(Convert.ToInt32(frm.QtdeRepeat.Text), frm.COFINS.Text);
                        Clipboard.SetText(_cofins);
                        sendCONTROLVandRELEASE();
                    }

                    if (frm.PIS.Text.Length > 0)
                    {
                        clickEditingControl(pis.locationX, pis.locationY); // PIS

                        string _pis = repeatXTimes(Convert.ToInt32(frm.QtdeRepeat.Text), frm.PIS.Text);
                        Clipboard.SetText(_pis);
                        sendCONTROLVandRELEASE();
                    }

                    //System.Threading.Thread.Sleep(1000);

                    // clica na barra de rolagem.
                    //clickEditingControl(1672, 700);
                    //clickEditingControl(clickRolagem.locationX, clickRolagem.locationY);

                    #endregion
                }
            }
        }

        private void tsbGravar_Click(object sender, EventArgs e)
        {
            try
            {
                Validate();
                bsConjunto.EndEdit();
                bsCampos.EndEdit();
                bsConjuntoCampos.EndEdit();
                tableAdapterManager.UpdateAll(fiscalDataSet);

                MessageBox.Show("Dados atualizados com sucesso.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tsbRunSet_Click(object sender, EventArgs e)
        {
            if (mainTabControl.SelectedTab != tabPageConjunto)
            {
                return;
            }

            int qtdeRepeticao = 0;
            try
            {
                qtdeRepeticao = Convert.ToInt32(tsbQtdeRepeticoes.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Quantidade de repetições deve ser um número.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgvConjunto.Rows.Count > 0)
            {
                int idConjunto = (int)dgvConjunto.CurrentRow.Cells[0].Value;

                bringSAPUI_ToFront();

                ObterConfigConjuntoDataTable table = taObterConfigConjunto.GetData(idConjunto);

                foreach (FiscalDataSet.ObterConfigConjuntoRow campo in table.Rows)
                {
                    clickEditingControl((int)campo.locationX, (int)campo.locationY, campo.nome_campo, noWait: true);

                    string _texto = repeatXTimes(qtdeRepeticao, campo.texto_campo);
                    Clipboard.SetText(_texto);

                    selectTextFromApplication();
                    clearTextSelected();

                    sendText("{CTRLDOWN}");
                    sendText("v");
                    sendText("{CTRLUP}");
                }
            }
        }

        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainTabControl.SelectedTab == tabPageListagemConjuntos)
            {
                taListarDadosConjunto.Fill(fiscalDataSet.ListarDadosConjunto);
            }
        }

        private void repetirCódigoImpostoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Repetir_CodImposto_Form frm = new Repetir_CodImposto_Form();

            const int POSICIONAR_ITEM_UM_PEDIDO = 12;
            const int CLICK_ROLAGEM_TELA_ITENS_PEDIDO = 13;

            CamposRow item1Pedido = (CamposRow)fiscalDataSet.Campos.Select("id = " + POSICIONAR_ITEM_UM_PEDIDO)[0];
            CamposRow clickRolagem = (CamposRow)fiscalDataSet.Campos.Select("id = " + CLICK_ROLAGEM_TELA_ITENS_PEDIDO)[0];

            if (frm.ShowDialog() == DialogResult.OK)
            {
                bringSAPUI_ToFront();

                string char1 = frm.CodigoImpostoIVA.Text.ToCharArray()[0].ToString();
                string char2 = frm.CodigoImpostoIVA.Text.ToCharArray()[1].ToString();

                // posiciona o cursor um pouco ao lado esquerdo.
                //clickEditingControl(614, 421);      // IVA
                clickEditingControl(item1Pedido.locationX, item1Pedido.locationY);

                // dá um tab
                sendText("{TAB}");

                if (frm.MultiplePagesCheck.Checked)
                {
                    int qtdeFilled = 0;

                    for (decimal page = 1; page <= frm.QtdePaginas.Value; page++)
                    {
                        int qtdeRestante = (int)frm.QtdeItens.Value - qtdeFilled;

                        if (qtdeRestante > MAX_ITENS_PER_PAGE)
                        {
                            qtdeRestante = MAX_ITENS_PER_PAGE;
                        }

                        if (qtdeRestante > 0)
                        {
                            int qtdePaginaAtual = 0;

                            // posiciona o cursor um pouco ao lado esquerdo.
                            clickEditingControl(item1Pedido.locationX, item1Pedido.locationY);

                            // dá um tab
                            sendText("{TAB}");

                            for (int i = 0; i < qtdeRestante; i++)
                            {

                                // Envia caractere por caractere
                                sendText("{" + char1 + "}");
                                sendText("{" + char2 + "}");
                                sendText("{DOWN}");

                                qtdePaginaAtual++;
                                qtdeFilled++;
                            }

                            // se atingiu a qtde max de itens por página, dá um scroll
                            if (qtdePaginaAtual == MAX_ITENS_PER_PAGE)
                            {
                                System.Threading.Thread.Sleep(1000);

                                // clica na barra de rolagem.
                                //clickEditingControl(833, 720);      // BARRA DE ROLAGEM ITENS DO PEDIDO
                                clickEditingControl(clickRolagem.locationX, clickRolagem.locationY);
                            }
                        }

                    }
                }
                else
                {
                    for (int i = 0; i < Convert.ToInt32(frm.QtdeRepeat.Text); i++)
                    {

                        // Envia caractere por caractere
                        sendText("{" + char1 + "}");
                        sendText("{" + char2 + "}");
                        sendText("{DOWN}");

                    }
                }


                //sendText("{" + char1 + "}");
                //sendText("{" + char2 + "}");
                //sendText("{DOWN}");
            }
        }

        public static void bringSAPUI_ToFront()
        {
            IntPtr sap = AutoItX.WinGetHandle("[CLASS:SAP_FRONTEND_SESSION]");

            // activates
            var x = AutoItX.WinActivate(sap);

            // pass ClassnameNN
            IntPtr window = AutoItX.ControlGetHandle(sap, "Afx:5DD90000:10081");
            Rectangle szClient = AutoItX.WinGetClientSize(window);
        }

        private void tsbRepeatCFOPServico_Click(object sender, EventArgs e)
        {
            repetirCFOPEServiçoToolStripMenuItem.PerformClick();
        }

        private void tsbRepetirCodImposto_Click(object sender, EventArgs e)
        {
            repetirCódigoImpostoToolStripMenuItem.PerformClick();
        }

        private void localDaInstalaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder local = new StringBuilder();
            local.AppendLine("LocalUserAppDataPath: " + Application.LocalUserAppDataPath);
            local.AppendLine("ExecutablePath: " + Application.ExecutablePath);
            //local.AppendLine("CommonAppDataPath: " + Application.CommonAppDataPath);
            //local.AppendLine("UserAppDataPath: " + Application.UserAppDataPath);

            MessageBox.Show(local.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void consultarProtocoloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtChavesDeAcesso.Text))
            {
                MessageBox.Show("Informe as chaves de acesso.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            const int EGR_CLK_BTN_DIREITO_NF = 14;
            const int EGR_CLK_1ST_LIN_GRID_RET_CONS_PROTO = 20;

            CamposRow clickRetConsultaProto = (CamposRow)fiscalDataSet.Campos.Select("id = " + EGR_CLK_1ST_LIN_GRID_RET_CONS_PROTO)[0];
            CamposRow btnDireitoNF = (CamposRow)fiscalDataSet.Campos.Select("id = " + EGR_CLK_BTN_DIREITO_NF)[0];

            string[] sep = new string[] { Environment.NewLine };
            string[] chaves = txtChavesDeAcesso.Text.Split(separator: sep, options: StringSplitOptions.None);
            string resultadoConsulta = "";
            StringBuilder resultado = new StringBuilder();

            bringSAPUI_ToFront();

            int count = 1;

            foreach (string chave in chaves)
            {
                //toolTip1.Show("Executando chave de acesso " + count + "...", this, 2000);
                if (chave.Length > 0)
                {
                    clickEditingControl(402, 44);

                    sendText("{SHIFTDOWN}{F4}");
                    sendText("{SHIFTUP}");

                    System.Threading.Thread.Sleep(3500);

                    Clipboard.SetText(chave);

                    sendCONTROLVandRELEASE();

                    sendText("{CTRLDOWN}");
                    sendText("s");
                    sendText("{CTRLUP}");

                    System.Threading.Thread.Sleep(2500);

                    sendText("{F8}");

                    System.Threading.Thread.Sleep(WAIT_TIME_QUERY_NF);    // aguarda retorno da consulta da nf

                    // CLICK BOTÃO DIREITO NF
                    clickEditingControl(btnDireitoNF.locationX, btnDireitoNF.locationY, button: MouseButton.RIGHT, noWait: false, waitTime: 3000);

                    sendText("c");
                    System.Threading.Thread.Sleep(2000);

                    sendText("c");
                    System.Threading.Thread.Sleep(1000);

                    sendText("{ENTER}");

                    System.Threading.Thread.Sleep(WAIT_TIME_QUERY_NF);

                    // Clica 1st linha de retorno da consulta protocolo 
                    clickEditingControl(clickRetConsultaProto.locationX, clickRetConsultaProto.locationY);

                    sendCONTROLCandRELEASE();

                    resultadoConsulta = Clipboard.GetText();

                    // Fecha a tela de retorno da consulta do protocolo
                    //clickEditingControl(1151, 219, waitTime: 6500, mouseSpeed: 30);      
                    sendText("{ESC}");

                    System.Threading.Thread.Sleep(WAIT_TIME_QUERY_NF);

                    resultado.AppendLine(chave + ";" + resultadoConsulta);

                    count++;
                }

            }

            txtResultadoConsulta.Text = resultado.ToString();

            MessageBox.Show("Processo terminado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void consultarNaturezaOperaçãoNFsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtChavesDeAcesso.Text))
            //{
            //    MessageBox.Show("Informe as chaves de acesso.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            //string[] sep = new string[] { Environment.NewLine };
            //string[] chaves = txtChavesDeAcesso.Text.Split(separator: sep, options: StringSplitOptions.None);
            //string resultadoConsulta = "";
            //StringBuilder resultado = new StringBuilder();

            //bringSAPUI_ToFront();

            //int count = 1;

            //foreach (string chave in chaves)
            //{
            //    //toolTip1.Show("Executando chave de acesso " + count + "...", this, 2000);
            //    if (chave.Length > 0)
            //    {
            //        sendText("{SHIFTDOWN}{F4}");
            //        sendText("{SHIFTUP}");

            //        System.Threading.Thread.Sleep(3500);

            //        Clipboard.SetText(chave);

            //        sendCONTROLVandRELEASE();

            //        sendText("{CTRLDOWN}");
            //        sendText("s");
            //        sendText("{CTRLUP}");

            //        System.Threading.Thread.Sleep(2500);

            //        sendText("{F8}");

            //        System.Threading.Thread.Sleep(WAIT_TIME_QUERY_NF );    // aguarda retorno da consulta da nf

            //        clickEditingControl(292, 287, button: MouseButton.RIGHT, mouseSpeed: 60);   // CLICK BOTÃO DIREITO NF

            //        clickEditingControl(344, 414, waitTime: 5500, mouseSpeed: 60);      // CLICK EM CONSULTA PROTOCOLO

            //        clickEditingControl(305, 294, mouseSpeed: 40);      // Clica sob o retorno do EDX

            //        sendCONTROLCandRELEASE();

            //        resultadoConsulta = Clipboard.GetText();

            //        clickEditingControl(1151, 219, waitTime: 6500, mouseSpeed: 30);      // Fecha a tela de consulta

            //        resultado.AppendLine(chave + ";" + resultadoConsulta);

            //        count++;
            //    }

            //}

            //txtResultadoConsulta.Text = resultado.ToString();

            //MessageBox.Show("Processo terminado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void confirmarOperaçãoEmMassaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtChavesDeAcesso.Text))
            {
                MessageBox.Show("Informe as chaves de acesso.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            const int EGR_CLK_BTN_DIREITO_NF = 14;
            const int EGR_CLK_OPER_CONFIRMADA = 15;
            const int EGR_CLK_GRID_1ST_LIN_OP_CONF = 16;
            const int EGR_OP_CONF_FECHA_TELA_RETORNO = 17;

            CamposRow btnDireitoNF = (CamposRow)fiscalDataSet.Campos.Select("id = " + EGR_CLK_BTN_DIREITO_NF)[0];
            CamposRow clickOperConfirmada = (CamposRow)fiscalDataSet.Campos.Select("id = " + EGR_CLK_OPER_CONFIRMADA)[0];
            CamposRow clickLinhaOpConf = (CamposRow)fiscalDataSet.Campos.Select("id = " + EGR_CLK_GRID_1ST_LIN_OP_CONF)[0];
            CamposRow opConfirmadaFechaTelaRetorno = (CamposRow)fiscalDataSet.Campos.Select("id = " + EGR_OP_CONF_FECHA_TELA_RETORNO)[0];

            string[] sep = new string[] { Environment.NewLine };
            string[] chaves = txtChavesDeAcesso.Text.Split(separator: sep, options: StringSplitOptions.None);
            string resultadoConsulta = "";
            StringBuilder resultado = new StringBuilder();

            bringSAPUI_ToFront();

            int count = 1;

            foreach (string chave in chaves)
            {
                //toolTip1.Show("Executando chave de acesso " + count + "...", this, 2000);
                if (chave.Length > 0)
                {
                    clickEditingControl(402, 44);

                    sendText("{SHIFTDOWN}{F4}");
                    sendText("{SHIFTUP}");

                    System.Threading.Thread.Sleep(3500);

                    Clipboard.SetText(chave);

                    sendCONTROLVandRELEASE();

                    sendText("{CTRLDOWN}");
                    sendText("s");
                    sendText("{CTRLUP}");

                    System.Threading.Thread.Sleep(2500);

                    sendText("{F8}");

                    System.Threading.Thread.Sleep(WAIT_TIME_QUERY_NF + 2500);    // aguarda retorno da consulta da nf

                    // CLICK BOTÃO DIREITO NF
                    //clickEditingControl(btnDireitoNF.locationX, btnDireitoNF.locationY, button: MouseButton.RIGHT);   // CLICK BOTÃO DIREITO NF
                    clickEditingControl(btnDireitoNF.locationX, btnDireitoNF.locationY, noWait: false, waitTime: WAIT_TIME_QUERY_NF - 4000, button: MouseButton.RIGHT);   // CLICK BOTÃO DIREITO NF

                    //sendText("O");
                    sendText("{DOWN}");
                    System.Threading.Thread.Sleep(1000);
                    sendText("{ENTER}");

                    System.Threading.Thread.Sleep(WAIT_TIME_QUERY_NF + 3500);      // Aguarda concluir a Confirmação da Operação. == 10s

                    //clickEditingControl(clickOperConfirmada.locationX, clickOperConfirmada.locationY, noWait: false, waitTime: WAIT_TIME_QUERY_NF);      // CLICK EM OPERAÇÃO CONFIRMADA

                    //clickEditingControl(280, 293, mouseSpeed: 30);      // Clica no grid na primeira linha de retorno do EDX
                    clickEditingControl(clickLinhaOpConf.locationX, clickLinhaOpConf.locationY, noWait: false, waitTime: WAIT_TIME_QUERY_NF - 4000);      // Clica no grid na primeira linha de retorno do EDX

                    sendCONTROLCandRELEASE();

                    resultadoConsulta = Clipboard.GetText();

                    sendText("{ESC}");

                    //if (resultado.ToString().ToLower().IndexOf("evento registrado e vinculado") > 0)
                    //{
                    //clickEditingControl(opConfirmadaFechaTelaRetorno.locationX, opConfirmadaFechaTelaRetorno.locationY, noWait: false, waitTime: WAIT_TIME_QUERY_NF);      // Fecha a tela de consulta
                    System.Threading.Thread.Sleep(WAIT_TIME_QUERY_NF + 2500);  // Se confirmado, consultará a nf novamente. 
                    //}

                    resultado.AppendLine(chave + ";" + resultadoConsulta);

                    count++;
                }

            }

            txtResultadoConsulta.Text = resultado.ToString();

            MessageBox.Show("Processo terminado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void controleDeNFeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new ControleNFeForm();
            frm.Show(this);
        }

        private void efetuarDownloadDeXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtChavesDeAcesso.Text))
            {
                MessageBox.Show("Informe as chaves de acesso.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            const int EGR_CLK_BTN_DIREITO_NF = 14;

            CamposRow btnDireitoNF = (CamposRow)fiscalDataSet.Campos.Select("id = " + EGR_CLK_BTN_DIREITO_NF)[0];

            string[] sep = new string[] { Environment.NewLine };
            string[] chaves = txtChavesDeAcesso.Text.Split(separator: sep, options: StringSplitOptions.None);
            //string resultadoConsulta = "";
            StringBuilder resultado = new StringBuilder();

            bringSAPUI_ToFront();

            int count = 1;

            foreach (string chave in chaves)
            {
                if (chave.Length > 0)
                {
                    // clica em local em branco pra não atrapalhar o SHIFT+F4.
                    clickEditingControl(402, 44);

                    sendText("{SHIFTDOWN}");
                    sendText("{F4}");
                    sendText("{SHIFTUP}");

                    System.Threading.Thread.Sleep(3500);

                    Clipboard.SetText(chave);

                    sendCONTROLVandRELEASE();

                    sendText("{CTRLDOWN}");
                    sendText("s");
                    sendText("{CTRLUP}");

                    System.Threading.Thread.Sleep(2500);

                    sendText("{F8}");

                    System.Threading.Thread.Sleep(WAIT_TIME_QUERY_NF);    // aguarda retorno da consulta da nf

                    clickEditingControl(btnDireitoNF.locationX, btnDireitoNF.locationY, noWait: false, waitTime: WAIT_TIME_QUERY_NF - 4000, button: MouseButton.RIGHT);   // CLICK BOTÃO DIREITO NF

                    //clickEditingControl(338, 298, waitTime: 7000, mouseSpeed: 30);      // SendKeys 'D' - Download de XML.
                    sendText("d");
                    System.Threading.Thread.Sleep(1500);

                    // aguarda terminar o download
                    // PROCESSO É DEMORADO.
                    System.Threading.Thread.Sleep(WAIT_TIME_QUERY_NF + 2500);

                    // Clica 1st linha de retorno da consulta protocolo 
                    clickEditingControl(415, 295 /*, noWait: false, waitTime: 2500*/);

                    sendCONTROLCandRELEASE();

                    //resultadoConsulta = Clipboard.GetText();
                    //resultado.AppendLine(chave + ";" + resultadoConsulta);
                    resultado.AppendLine(chave + ";" + Clipboard.GetText());

                    // Fecha a tela de retorno.
                    clickEditingControl(1153, 220, noWait: false, waitTime: WAIT_TIME_QUERY_NF);

                    count++;
                }
            }

            txtResultadoConsulta.Text = resultado.ToString();

            MessageBox.Show("Processo terminado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void calcularVlrUnitarioDePedido100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const int POSICIONAR_ITEM_1_PEDIDO = 26;
            const int POSICIONAR_EM_VALOR_MONTANTE = 21;
            const int MOSTRAR_VLR_LIQUIDO = 22;
            const int FOCAR_CAMPO_VLR_LIQUIDO = 23;
            const int CLICAR_QUANTIDADE_ITEM_1_PED = 24;
            const int VOLTAR_BARRA_AO_INICIO = 25;

            CamposRow posicionaValorItem1Pedido = (CamposRow)fiscalDataSet.Campos.Select("id = " + POSICIONAR_ITEM_1_PEDIDO)[0];
            CamposRow posicionaVlrMontante = (CamposRow)fiscalDataSet.Campos.Select("id = " + POSICIONAR_EM_VALOR_MONTANTE)[0];
            CamposRow mostrarVlrLiquido = (CamposRow)fiscalDataSet.Campos.Select("id = " + MOSTRAR_VLR_LIQUIDO)[0];
            CamposRow clicaCampoVlrLiquido = (CamposRow)fiscalDataSet.Campos.Select("id = " + FOCAR_CAMPO_VLR_LIQUIDO)[0];
            CamposRow clicaQtdeItem1 = (CamposRow)fiscalDataSet.Campos.Select("id = " + CLICAR_QUANTIDADE_ITEM_1_PED)[0];
            CamposRow voltarBarraAoInicio = (CamposRow)fiscalDataSet.Campos.Select("id = " + VOLTAR_BARRA_AO_INICIO)[0];

            bringSAPUI_ToFront();

            // posiciona em Valor Montante
            clickEditingControl(posicionaVlrMontante.locationX, posicionaVlrMontante.locationY, "", false);

            // Seleciona texto.
            selectTextFromApplication();

            // Copia valor montante.
            sendCONTROLCandRELEASE();

            string valorMontanteClip = Clipboard.GetText();

            // posiciona no valor do item 1.
            clickEditingControl(posicionaValorItem1Pedido.locationX, posicionaValorItem1Pedido.locationY, "", false);

            // Seleciona texto.
            selectTextFromApplication();

            // Apaga.
            clearTextSelected();

            // Cola valor da clip.
            sendCONTROLVandRELEASE();

            // Move barra de rolagem p/ exibir Preço Líquido do Pedido.
            clickEditingControl(mostrarVlrLiquido.locationX, mostrarVlrLiquido.locationY, "", false);

            // clica no campo de Vlr Líquido.
            clickEditingControl(clicaCampoVlrLiquido.locationX, clicaCampoVlrLiquido.locationY, "", false);

            // Seleciona texto.
            selectTextFromApplication();

            // Copia valor líquido.
            sendCONTROLCandRELEASE();

            string valorLiquido = Clipboard.GetText();

            // divide vlr nf pelo pedido 
            // resultado * 100, arredonda p/ 3 casas.

            decimal percentual = 0;

            try
            {
                percentual = decimal.Round((decimal.Parse(valorMontanteClip) / decimal.Parse(valorLiquido)) * 100, 3);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao efetuar o cálculo. (" + ex.Message + ")\n\n" + 
                    "Valor Montante: " + valorMontanteClip + "\n" + 
                    "Valor Líquido: " + valorLiquido,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // barra no início
            clickEditingControl(voltarBarraAoInicio.locationX, voltarBarraAoInicio.locationY, "", false);

            // posiciona no campo quantidade.
            clickEditingControl(clicaQtdeItem1.locationX, clicaQtdeItem1.locationY, "", false);

            // Seleciona texto.
            selectTextFromApplication();

            // Apaga.
            clearTextSelected();

            // manda percentual p/ clip.
            Clipboard.SetText(percentual.ToString());

            // Cola valor da clip.
            sendCONTROLVandRELEASE();

            // Envia enter
            sendText("{ENTER}");
            sendText("{ENTER}");
        }

        private void posicionarEmCoordenadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmPosicionarCoordenadas();

            frm.Show();
        }
    }
}
