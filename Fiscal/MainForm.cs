using AutoIt;
using FiscalApp.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static FiscalApp.FiscalDataSet;

namespace FiscalApp
{
    public partial class MainForm : Form
    {
        IntPtr whnd;
        SortedDictionary<string, string> hotwords = new SortedDictionary<string, string>();

        public static bool STOP_CURRENT_PROCESS = false;
        public static int WAIT_TIME = 1000;

        public const int SAP_Y_COORD_OFFSET = 120;
        public const int ARROW_CURSOR = 2;

        const int MAX_ITENS_PER_PAGE = 18;
        const int WAIT_TIME_QUERY_NF = 7500;

        //private CamposTableAdapter camposTableAdapter = new CamposTableAdapter();
        //private ConjuntoTableAdapter conjuntoTableAdapter = new ConjuntoTableAdapter();
        //private ConjuntoCamposTableAdapter conjuntoCamposTableAdapter = new ConjuntoCamposTableAdapter();
        //private ListarDadosConjuntoTableAdapter listarDadosConjuntoTableAdapter = new ListarDadosConjuntoTableAdapter();

        public MainForm()
        {
            InitializeComponent();

        }

        public static Point dummyPlace()
        {
            var p = new Point(430, MainForm.SAP_Y_COORD_OFFSET - 42);
            return p;
        }

        private static void moveToDummyPlace()
        {
            //AutoItX.MouseMove(430, MainForm.SAP_Y_COORD_OFFSET - 42);

            // BARRA DE TÍTULO DO SAP
            var dummy = dummyPlace();

            AutoItX.MouseMove(dummy.X, dummy.Y);
        }

        /// <summary>
        /// Aguarda 1s e repete até que o Cursor esteja com o símbolo de Ponteiro.
        /// </summary>
        /// <param name="dummyMove">Se true, move o cursor para um local que certamente ficará com símbolo de ponteiro (aguardando).</param>
        public static void AguardarResposta(bool dummyMove = true)
        {
            if (dummyMove)
            {
                moveToDummyPlace();
            }

            do
            {
                System.Threading.Thread.Sleep(WAIT_TIME);

                // Verifica se o usuário mexeu o mouse.
                var pos = AutoItX.MouseGetPos();

                if (pos.X != dummyPlace().X)
                {
                    if (MessageBox.Show("Detectado mudança de posição do mouse. Deseja parar o processo?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification) == DialogResult.Yes)
                    {
                        STOP_CURRENT_PROCESS = true;
                        return;
                    }
                }

                //if (STOP_CURRENT_PROCESS)
                //{
                //    return;
                //}

            } while (AutoItX.MouseGetCursor() != MainForm.ARROW_CURSOR);
        }

        private void CalcularVlrUnitarioDePedido100()
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
            Teclado.selecEntireTextFromControl();

            // Copia valor montante.
            sendCONTROLCandRELEASE();

            string valorMontanteClip = Clipboard.GetText();

            // posiciona no valor do item 1.
            clickEditingControl(posicionaValorItem1Pedido.locationX, posicionaValorItem1Pedido.locationY, "", false);

            // Seleciona texto.
            Teclado.selecEntireTextFromControl();

            // Apaga.
            Teclado.clearTextSelected();

            // Cola valor da clip.
            sendCONTROLVandRELEASE();

            // Move barra de rolagem p/ exibir Preço Líquido do Pedido.
            clickEditingControl(mostrarVlrLiquido.locationX, mostrarVlrLiquido.locationY, "", false);

            // clica no campo de Vlr Líquido.
            clickEditingControl(clicaCampoVlrLiquido.locationX, clicaCampoVlrLiquido.locationY, "", false);

            // Seleciona texto.
            Teclado.selecEntireTextFromControl();

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
            Teclado.selecEntireTextFromControl();

            // Apaga.
            Teclado.clearTextSelected();

            // manda percentual p/ clip.
            Clipboard.SetText(percentual.ToString());

            // Cola valor da clip.
            sendCONTROLVandRELEASE();

            // Envia enter
            sendText("{ENTER}");
            sendText("{ENTER}");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            //if (!string.IsNullOrEmpty(FiscalApp.Properties.Settings.Default.HotWords))
            //{
            //    string[] words = FiscalApp.Properties.Settings.Default.HotWords.Split(new char[] { '|' });

            //    if (words.Length > 0)
            //    {
            //        foreach (string word in words)
            //        {
            //            if (!string.IsNullOrEmpty(word))
            //            {
            //                hotwords.Add(word, word);
            //            }
            //        }

            //        // creates ordered menu items
            //        foreach (KeyValuePair<string, string> item in hotwords)
            //        {
            //            criarHotWordMenu(item.Value);
            //        }
            //    }
            //}
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //throw new NotImplementedException();
            MessageBox.Show(e.Exception.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            e.Cancel = true;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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

        //private void criarHotWordMenu(string texto)
        //{
        //    ToolStripMenuItem menu = new ToolStripMenuItem()
        //    {
        //        Text = texto,
        //        Tag = "copiarx"
        //    };

        //    menu.Click += copiarToolStripMenuItem_Click;

        //    #region "Cria os sub-menus para os hotwords"
        //    ToolStripMenuItem copiar = new ToolStripMenuItem()
        //    {
        //        Text = copiarToolStripMenuItem.Text,
        //        Tag = "copiarx"
        //    };
        //    copiar.Click += copiarToolStripMenuItem_Click;
        //    menu.DropDownItems.Add(copiar);

        //    menu.DropDownItems.Add(new ToolStripSeparator());

        //    //ToolStripMenuItem inserirNoSAP = new ToolStripMenuItem()
        //    //{
        //    //    Text = inserirNoSAPToolStripMenuItem.Text,
        //    //    Tag = "inserirNoSAP"
        //    //};
        //    //inserirNoSAP.Click += adicionarNoSAPToolStripMenuItem_Click;
        //    //menu.DropDownItems.Add(inserirNoSAP);

        //    //menu.DropDownItems.Add(new ToolStripSeparator());

        //    ToolStripMenuItem repetir5x = new ToolStripMenuItem()
        //    {
        //        Text = repetir5xECopiarToolStripMenuItem.Text,
        //        Tag = "copiarx"
        //    };
        //    repetir5x.Click += repetir5xECopiarToolStripMenuItem_Click;
        //    menu.DropDownItems.Add(repetir5x);

        //    ToolStripMenuItem repetir10x = new ToolStripMenuItem()
        //    {
        //        Text = repetir10xECopiarToolStripMenuItem.Text,
        //        Tag = "copiarx"
        //    };
        //    repetir10x.Click += repetir10xECopiarToolStripMenuItem_Click;
        //    menu.DropDownItems.Add(repetir10x);

        //    ToolStripMenuItem repetir15x = new ToolStripMenuItem()
        //    {
        //        Text = repetir15xECopiarToolStripMenuItem.Text,
        //        Tag = "copiarx"
        //    };
        //    repetir15x.Click += repetir15xECopiarToolStripMenuItem_Click;
        //    menu.DropDownItems.Add(repetir15x);

        //    ToolStripMenuItem repetir20x = new ToolStripMenuItem()
        //    {
        //        Text = repetir20xECopiarToolStripMenuItem.Text,
        //        Tag = "copiarx"
        //    };
        //    repetir20x.Click += repetir20xECopiarToolStripMenuItem_Click;
        //    menu.DropDownItems.Add(repetir20x);

        //    ToolStripMenuItem repetir25x = new ToolStripMenuItem()
        //    {
        //        Text = repetir25xECopiarToolStripMenuItem.Text,
        //        Tag = "copiarx"
        //    };
        //    repetir25x.Click += repetir25xECopiarToolStripMenuItem_Click;
        //    menu.DropDownItems.Add(repetir25x);

        //    #endregion

        //    //inserirNoSAP.DropDownItems.AddRange(new ToolStripItem[]
        //    //{
        //    //    repetir5x,
        //    //    repetir10x,
        //    //    repetir15x,
        //    //    repetir20x,
        //    //    repetir25x
        //    //});
        //}

        //private void adicionarParaHotWordToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    string texto = getSourceControlString(sender);
        //    if (hotwords.ContainsValue(texto))
        //    {
        //        MessageBox.Show("HotWord já existe.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //    else
        //    {
        //        criarHotWordMenu(texto);
        //    }
        //}

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
        public static void clickEditingControl(int x, int y, string toolTip = "", bool noWait = true, int waitTime = 1000, int mouseSpeed = 5, AcaoBaseClass.MouseButton button = AcaoBaseClass.MouseButton.LEFT, int numClicks = 1)
        {
            // points mouse
            AutoItX.MouseMove(x, y + SAP_Y_COORD_OFFSET, mouseSpeed);

            //AutoItX.MouseClick("LEFT", x, y - SAP_Y_COORD_OFFSET, 1, 5);

            string _button = "LEFT";
            if (button == AcaoBaseClass.MouseButton.RIGHT)
            {
                _button = "RIGHT";
            }

            //AutoItX.MouseClick(_button, numClicks: 1, speed: 5);
            AutoItX.MouseClick(_button, numClicks: numClicks);

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

        public static void clickEditingControl(CamposRow campo, string toolTip = "", int numClicks = 1)
        {
            //int mouseSpeed = 10;
            //int waitTime = 500;

            int mouseSpeed = 5;
            int waitTime = 250;

            clickEditingControl(campo.locationX, campo.locationY, toolTip: "", noWait: false, waitTime: waitTime, mouseSpeed: mouseSpeed, numClicks: numClicks);
        }

        public static string copyEntireTextFromControl()
        {
            string texto = "";
            int times = 0;

            Clipboard.Clear();

            try
            {
                AutoItX.Send("{HOME}");
                AutoItX.Send("{SHIFTDOWN}");
                AutoItX.Send("+{END}");
                AutoItX.Send("{SHIFTUP}");
                AutoItX.Send("^c");

                //Cursor = Cursors.WaitCursor;

                while (texto.Length == 0 && times < 10)
                {
                    try
                    {
                        times++;
                        // get pode falhar as vezes.
                        texto = Clipboard.GetText(TextDataFormat.Text);
                    }
                    catch (Exception)
                    {
                        System.Threading.Thread.Sleep(400);
                        //AguardarResposta();
                    }
                }

                Program.LOG.AppendLine("TIMES: " + times);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return string.Empty;
            }
            finally
            {
                //Cursor = Cursors.Default;
            }

            return texto.ToString();
        }

        private string selectAndGetTextFromCursor()
        {
            AutoItX.Send("+{END}");
            AutoItX.Send("^c");
            return Clipboard.GetText();
        }

        private void sendTextFromClipboard()
        {
            AutoItX.Send(Clipboard.GetText());
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

        public static void sendText(string text)
        {
            AutoItX.Send(text);
        }

        public static void sendCONTROLVandRELEASE()
        {
            Teclado.selecEntireTextFromControl();
            Teclado.clearTextSelected();
            sendText("{CTRLDOWN}");
            sendText("v");
            sendText("{CTRLUP}");
        }

        public static void sendCONTROLCandRELEASE()
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
                        clickEditingControl(clickRolagem.locationX, clickRolagem.locationY, noWait: false, waitTime: 4000);

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
                    //clickEditingControl((int)campo.locationX, (int)campo.locationY, campo.nome_campo, noWait: true);
                    clickEditingControl((int)campo.locationX, (int)campo.locationY, campo.nome_campo);

                    string _texto = repeatXTimes(qtdeRepeticao, campo.texto_campo);
                    Clipboard.SetText(_texto);

                    Teclado.selecEntireTextFromControl();
                    Teclado.clearTextSelected();

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

            // Posiciona na coluna Item, do Item 1 do Pedido.
            const int POSICIONAR_ITEM_UM_PEDIDO = 12;
            const int CLICK_ROLAGEM_TELA_ITENS_PEDIDO = 13;

            CamposRow item1Pedido = (CamposRow)fiscalDataSet.Campos.Select("id = " + POSICIONAR_ITEM_UM_PEDIDO)[0];
            CamposRow clickRolagem = (CamposRow)fiscalDataSet.Campos.Select("id = " + CLICK_ROLAGEM_TELA_ITENS_PEDIDO)[0];

            if (frm.ShowDialog() == DialogResult.OK)
            {
                bringSAPUI_ToFront();

                string char1 = frm.CodigoImpostoIVA.Text.ToCharArray()[0].ToString();
                string char2 = frm.CodigoImpostoIVA.Text.ToCharArray()[1].ToString();

                // dá um tab 
                //sendText("{TAB}");

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
                            clickEditingControl(item1Pedido.locationX, item1Pedido.locationY/*, noWait: false, waitTime: 2000*/);

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
                                // BARRA DE ROLAGEM ITENS DO PEDIDO
                                clickEditingControl(clickRolagem.locationX, clickRolagem.locationY, noWait: false, waitTime: 3000);
                            }
                        }

                    }
                }
                else
                {
                    // posiciona o cursor um pouco ao lado esquerdo.
                    clickEditingControl(item1Pedido.locationX, item1Pedido.locationY);

                    // dá um tab
                    sendText("{TAB}");

                    for (int i = 0; i < Convert.ToInt32(frm.QtdeRepeat.Text); i++)
                    {
                        // Envia caractere por caractere
                        sendText("{" + char1 + "}");
                        sendText("{" + char2 + "}");
                        sendText("{DOWN}");
                    }
                }
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

            // Reinicia o flag de processo.
            STOP_CURRENT_PROCESS = false;
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

        private void confirmarOperaçãoEmMassaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtChavesDeAcesso.Text))
            {
                MessageBox.Show("Informe as chaves de acesso.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            #region "Antigo"

            //const int EGR_CLK_BTN_DIREITO_NF = 14;
            //const int EGR_CLK_OPER_CONFIRMADA = 15;
            //const int EGR_CLK_GRID_1ST_LIN_OP_CONF = 16;
            //const int EGR_OP_CONF_FECHA_TELA_RETORNO = 17;

            //CamposRow btnDireitoNF = (CamposRow)fiscalDataSet.Campos.Select("id = " + EGR_CLK_BTN_DIREITO_NF)[0];
            //CamposRow clickOperConfirmada = (CamposRow)fiscalDataSet.Campos.Select("id = " + EGR_CLK_OPER_CONFIRMADA)[0];
            //CamposRow clickLinhaOpConf = (CamposRow)fiscalDataSet.Campos.Select("id = " + EGR_CLK_GRID_1ST_LIN_OP_CONF)[0];
            //CamposRow opConfirmadaFechaTelaRetorno = (CamposRow)fiscalDataSet.Campos.Select("id = " + EGR_OP_CONF_FECHA_TELA_RETORNO)[0];

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
            //        clickEditingControl(402, 44);

            //        sendText("{SHIFTDOWN}{F4}");
            //        sendText("{SHIFTUP}");

            //        System.Threading.Thread.Sleep(3500);

            //        Clipboard.SetText(chave);

            //        sendCONTROLVandRELEASE();

            //        sendText("{CTRLDOWN}");
            //        sendText("s");
            //        sendText("{CTRLUP}");

            //        System.Threading.Thread.Sleep(1500);
            //        // 2500

            //        sendText("{F8}");

            //        System.Threading.Thread.Sleep(WAIT_TIME_QUERY_NF + 1800);    // aguarda retorno da consulta da nf
            //        //2500

            //        // CLICK BOTÃO DIREITO NF
            //        //clickEditingControl(btnDireitoNF.locationX, btnDireitoNF.locationY, button: MouseButton.RIGHT);   // CLICK BOTÃO DIREITO NF
            //        clickEditingControl(btnDireitoNF.locationX, btnDireitoNF.locationY, noWait: false, waitTime: WAIT_TIME_QUERY_NF - 4000, button: AcaoBaseClass.MouseButton.RIGHT);   // CLICK BOTÃO DIREITO NF

            //        sendText("{DOWN}");
            //        System.Threading.Thread.Sleep(1000);
            //        sendText("{ENTER}");

            //        //3500
            //        System.Threading.Thread.Sleep(WAIT_TIME_QUERY_NF + 2500);      // Aguarda concluir a Confirmação da Operação. == 10s

            //        //4000
            //        clickEditingControl(clickLinhaOpConf.locationX, clickLinhaOpConf.locationY, noWait: false, waitTime: WAIT_TIME_QUERY_NF - 2500);      // Clica no grid na primeira linha de retorno do EDX, tem que aguardar um pouco.

            //        sendCONTROLCandRELEASE();

            //        resultadoConsulta = Clipboard.GetText();

            //        sendText("{ESC}");

            //        // Se confirmado, consultará a nf novamente. 
            //        //if (resultado.ToString().ToLower().IndexOf("registrado e vinculado") > 0)
            //        //{
            //        // aguarda refresh do grid quando confirmado com sucesso, valor pode variar.
            //        System.Threading.Thread.Sleep(WAIT_TIME_QUERY_NF + 2500);
            //        //}

            //        resultado.AppendLine(chave + ";" + resultadoConsulta);

            //        count++;
            //    }

            //}

            //txtResultadoConsulta.Text = resultado.ToString();

            //MessageBox.Show("Processo terminado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion

            // O usuário informa as chaves de acesso
            // Percorre o array de chaves
            // Para cada chave...
            //      1. Pesquisa a chave
            //      2. Botão direito e confirma a operação.

            string[] sep = new string[] { Environment.NewLine };
            string[] chaves = txtChavesDeAcesso.Text.Split(separator: sep, options: StringSplitOptions.None);
            //int count = 1;

            Actions acoes = null;

            bringSAPUI_ToFront();

            // Diminui o tempo de espera.
            WAIT_TIME = 500;

            foreach (string chave in chaves)
            {
                // Copia para Clibboard a chave.
                Clipboard.SetText(chave);

                acoes = new Actions(new List<AcaoBaseClass>()
                {
                    new Acao() {
                            Local = new Point(114,-12),
                            Nome = "seleção dinâmica",
                            TempoEsperaAntesAcao = 1000,
                    },
                    new Acao(781, 123, "entra no matchcode de chaves de acesso"),
                    new Acao(164,371, "limpa os itens existentes"),
                    new Acao(352, 372, "upload clipboard"),
                    new Acao(42,371, "executar F8 na  de chv de acesso"),
                    new Acao(53,413, "Control S"),
                    new Acao(84,-11, "F8 na  principal"),

                    new Acao()
                    {
                        Local = new Point(292,287),
                        BotaoMouse = AcaoBaseClass.MouseButton.RIGHT,
                        Nome = "botão direito na nf",
                        //TempoEsperaAntesAcao = 1000,
                        TempoEsperaAposAcao = 1000, //mantenha isso, o menu do SAP em si é lento.
                    },

                    new Tecla()
                    {
                        Key = "O"
                    },

                    new Tecla()
                    {
                        Key = "{ENTER}"
                    },

                    new Acao() {
                        Local = new Point(1152,221),
                        Nome = "fecha a tela de confirmação",
                        TempoEsperaAposAcao = 1000,
                    }

                });

                foreach (var a in acoes.Lista)
                {
                    if (a.IsTecla)
                    {
                        a.EnviarTecla();
                    }
                    else
                    {
                        a.Clicar();
                    }

                    MainForm.AguardarResposta();

                    if (STOP_CURRENT_PROCESS)
                    {
                        return;
                    }
                }

            }

            //MessageBox.Show("Processo terminado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void efetuarDownloadDeXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void calcularVlrUnitarioDePedido100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalcularVlrUnitarioDePedido100();
        }

        private void posicionarEmCoordenadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmPosicionarCoordenadas();

            frm.Show();
        }

        private void downloadXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIteracoes frm = new frmIteracoes();

            if (frm.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }

            #region "ANTIGO COM BD"

            //const int EGR_CLK_BTN_DIREITO_NF = 14;

            //CamposRow btnDireitoNF = (CamposRow)fiscalDataSet.Campos.Select("id = " + EGR_CLK_BTN_DIREITO_NF)[0];

            //bringSAPUI_ToFront();

            //for (int i = 1; i <= frm.QtdeIteracoes.Value; i++)
            //{
            //    // Tem que aguardar uns segundos para o Menu de Contexto aparecer.
            //    clickEditingControl(btnDireitoNF.locationX, btnDireitoNF.locationY, noWait: false, waitTime: 1000, button: AcaoBaseClass.MouseButton.RIGHT);   // CLICK BOTÃO DIREITO NF

            //    sendText("d");

            //    MainForm.AguardarResposta();

            //    if (STOP_CURRENT_PROCESS)
            //    {
            //        return;
            //    }
            //}

            #endregion

            Actions acoes = new Actions(new List<AcaoBaseClass>()
            {
                new Acao()
                {
                    Local = new Point(292,287),
                    BotaoMouse = AcaoBaseClass.MouseButton.RIGHT,
                    Nome = "botão direito na nf",
                    //TempoEsperaAntesAcao = 1000,
                    TempoEsperaAposAcao = 1000, //mantenha isso, o menu do SAP em si é lento.
                },

                new Tecla()
                {
                    Key = "D"
                },
            });

            bringSAPUI_ToFront();

            // Diminui o tempo de espera.
            //WAIT_TIME = 500;

            StringBuilder chaves = new StringBuilder();

            for (int i = 1; i <= frm.QtdeIteracoes.Value; i++)
            {

                foreach (var a in acoes.Lista)
                {
                    if (a.IsTecla)
                    {
                        a.EnviarTecla();
                    }
                    else
                    {
                        a.Clicar();
                    }

                    MainForm.AguardarResposta();

                    if (STOP_CURRENT_PROCESS)
                    {
                        return;
                    }
                }

            }

            MessageBox.Show("Processo terminado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }

        private void entrarDadosTelefoniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmDadosTelefonia(fiscalDataSet);
            frm.ShowDialog(this);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)
            //{
            //    if (MessageBox.Show("Deseja parar o processo?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, 
            //        MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification) == DialogResult.Yes)
            //    {
            //        STOP_CURRENT_PROCESS = true;
            //    }
            //}
        }

        private void entrarEGREPrepararConsultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actions acoes = new Actions();

            acoes.Adicionar(new List<AcaoBaseClass>()
            {
                new Acao(86, 134, "btn"),
                new Acao(114, 134, "monitor"),

                new Acao() {
                     Local = new Point(114,-12),
                     Nome = "seleção dinâmica",
                     TempoEsperaAntesAcao = 1000,
                },

                //new Acao("{SHIFTDOWN}{F4}"),
                //new Acao("{SHIFTUP}"),
                new Acao(25, 69, "exp header"),
                new Acao(127, 88, "seleciona param chv acesso"),
                new Acao(155, 417, "transfere marcado"),
                new Acao(781, 123, "matchcode de chaves de acesso"),      
                //new Acao("SHIFT+F12"),
                new Acao(352, 372, "upload clipboard"),
                new Acao(42,371, "executar F8 na  de chv de acesso"),
                //new Acao("F8"),
                new Acao(53,413, "Control S"),
                new Acao(84,-11, "F8 na  principal"),
            });

            bringSAPUI_ToFront();

            // Diminui o tempo de espera.
            WAIT_TIME = 500;

            foreach (AcaoBaseClass a in acoes.Lista)
            {
                if (a.IsTecla)
                {
                    a.EnviarTecla();
                }
                else
                {
                    a.Clicar();
                }

                MainForm.AguardarResposta();

                if (STOP_CURRENT_PROCESS)
                {
                    return;
                }
            }
        }

        private void pesquisarChavesDeAcessoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actions acoes = new Actions(new List<AcaoBaseClass>()
            {
                new Acao() {
                     Local = new Point(114,-12),
                     Nome = "seleção dinâmica",
                     TempoEsperaAntesAcao = 1000,
                },
                new Acao(781, 123, "entra no matchcode de chaves de acesso"),
                new Acao(164,371, "limpa os itens existentes"),
                new Acao(352, 372, "upload clipboard"),
                new Acao(42,371, "executar F8 na  de chv de acesso"),
                new Acao(53,413, "Control S"),
                new Acao(84,-11, "F8 na  principal"),
            });

            bringSAPUI_ToFront();

            // Diminui o tempo de espera.
            WAIT_TIME = 500;

            foreach (var a in acoes.Lista)
            {
                if (a.IsTecla)
                {
                    a.EnviarTecla();
                }
                else
                {
                    a.Clicar();
                }

                MainForm.AguardarResposta();

                if (STOP_CURRENT_PROCESS)
                {
                    return;
                }
            }
        }

        private void tsbtnPesqChvAcessoEGR_Click(object sender, EventArgs e)
        {
            pesquisarChavesDeAcessoToolStripMenuItem.PerformClick();
        }

        private void CopiarChvOrigemeRefToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actions acoes = new Actions(new List<AcaoBaseClass>()
            {
                new Acao(531,68, "clica em chave de acesso"),
                new Acao() { Tag = "copiarconteúdo" },

                new Acao(517, 115, "clica em chave de acesso referencia"),
                new Acao() { Tag = "copiarconteúdo" },

                new Tecla()
                {
                    Key = "{F3}",
                    TempoEsperaAposAcao = 1000,
                },

                new Tecla()
                {
                    Key = "{F3}",
                    TempoEsperaAposAcao = 1000,
                },

                new Acao()
                {
                    Local = new Point(114, -12),
                    Nome = "seleção dinâmica",
                    TempoEsperaAntesAcao = 1000,
                },

                new Acao(781, 123, "entra no matchcode de chaves de acesso"),
                new Acao(164, 371, "limpa os itens existentes"),

                new Acao() { Tag = "savetoclipboard" },

                new Acao(352, 372, "upload clipboard"),
                new Acao(42, 371, "executar F8 na  de chv de acesso"),
                new Acao(53, 413, "Control S"),
                new Acao(84, -11, "F8 na  principal"),
            });

            bringSAPUI_ToFront();

            // Diminui o tempo de espera.
            WAIT_TIME = 500;

            StringBuilder chaves = new StringBuilder();

            foreach (var a in acoes.Lista)
            {
                switch (a.Tag)
                {
                    case "copiarconteúdo":
                        chaves.AppendLine(MainForm.copyEntireTextFromControl());
                        break;

                    case "savetoclipboard":
                        Clipboard.SetText(chaves.ToString());
                        break;

                    default:
                        break;
                }

                if (a.IsTecla)
                {
                    a.EnviarTecla();
                }
                else
                {
                    a.Clicar();
                }

                MainForm.AguardarResposta();

                if (STOP_CURRENT_PROCESS)
                {
                    return;
                }
            }
        }

        private void copiarChageOrigemEReferênciaParaOperNãoRealizadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Precisa estar com as 2 notas (Origem e a de Entrada--Referência) no grid.

            #region "SELECIONA AS 2 NOTAS, DE ORIGEM E REF NO GRID"

            CopiarChvOrigemeRefToolStripMenuItem.PerformClick();

            DialogResult resB = MessageBox.Show("Abra a NF de Origem(Saída) e de dentro dela abra a NF de Entrada(Referência).\n\nConfirme para continuar.",
                    Application.ProductName,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

            if (resB == DialogResult.Cancel)
            {
                return;
            }

            #endregion

            WAIT_TIME = 300;
            int wait_antes = 50;
            int wait_depois = 50;

            #region "COLETA DADOS DA NOTA DE REFERENCIA -- QUE ESTÁ ABERTA"

            string nfref_chave = "";
            string nfref_dtemi = "";
            string nfref_numero = "";
            string nfref_emissor = "";
            string nfref_serie = "";
            string nfref_tpOper = "";

            Actions acoes = new Actions(new List<AcaoBaseClass>()
            {
                // Estando dentro da NF de Referência, a NF de Entrada.
                // Supõe-se que parte da Nota Fiscal de Entrada.

                new Acao()
                {
                    Local = new Point(531,68),
                    Nome = "clica em chave de acesso da NF de Entrada",
                    TempoEsperaAntesAcao = wait_antes,
                    TempoEsperaAposAcao = wait_depois
                },
                new Acao()
                {
                    Local = new Point(574,134),
                    Tag = "clica Tp Operacao da NF de Entrada",
                    TempoEsperaAntesAcao = wait_antes,
                    TempoEsperaAposAcao = wait_depois
                },
                new Acao()
                {
                    Local = new Point(899,122),
                    Tag = "clica Data Emissão da NF de Entrada",
                    TempoEsperaAntesAcao = wait_antes,
                    TempoEsperaAposAcao = wait_depois
                },
                new Acao()
                {
                    Local = new Point(1108,70),
                    Tag = "clica no Emissor da NF de Entrada",
                    TempoEsperaAntesAcao = wait_antes,
                    TempoEsperaAposAcao = wait_depois
                },
                new Acao()
                {
                    Local = new Point(887,66),
                    Tag = "clica no Número da NF de Entrada",
                    TempoEsperaAntesAcao = wait_antes,
                    TempoEsperaAposAcao = wait_depois
                },
                new Acao()
                {
                    Local = new Point(865,89),
                    Tag = "clica na Série da NF de Entrada",
                    TempoEsperaAntesAcao = wait_antes,
                    TempoEsperaAposAcao = wait_depois
                },
                new Tecla()
                {
                    Key = "{F3}",
                    TempoEsperaAposAcao = 1000,
                },
            });

            bringSAPUI_ToFront();

            int count = 1;

            Clipboard.Clear();

            foreach (var a in acoes.Lista)
            {
                if (a.IsTecla)
                {
                    a.EnviarTecla();
                }
                else
                {
                    a.Clicar();
                }

                MainForm.AguardarResposta();

                if (STOP_CURRENT_PROCESS)
                {
                    return;
                }

                Teclado.sendToClipboardEntireTextSelected();

                switch (count)
                {
                    case 1:
                        nfref_chave = Clipboard.GetText();
                        break;

                    case 2:
                        nfref_tpOper = Clipboard.GetText();
                        break;

                    case 3:
                        nfref_dtemi = Clipboard.GetText();
                        break;

                    case 4:
                        nfref_emissor = Clipboard.GetText();
                        break;

                    case 5:
                        nfref_numero = Clipboard.GetText();
                        break;

                    case 6:
                        nfref_serie = Clipboard.GetText();
                        break;

                    default:
                        break;
                }

                count++;
            }

            #endregion

            if (int.Parse(nfref_tpOper) != 0)
            {
                MessageBox.Show("NF de Referência não é uma Nota Fiscal de Entrada.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #region "COLETA DADOS DA NOTA DE ORIGEM -- QUE ESTÁ ABERTA"

            string nf_chave = "";
            string nf_dtemi = "";
            string nf_numero = "";
            string nf_emissor = "";
            string nf_tpOper = "";
            string nf_serie = "";

            acoes = new Actions(new List<AcaoBaseClass>()
            {
                new Acao()
                {
                    Local = new Point(531,68),
                    Nome = "clica em chave de acesso",
                    TempoEsperaAntesAcao = wait_antes,
                    TempoEsperaAposAcao = wait_depois
                },
                new Acao()
                {
                    Local = new Point(574,134),
                    Tag = "clica Tp Operacao",
                    TempoEsperaAntesAcao = wait_antes,
                    TempoEsperaAposAcao = wait_depois
                },
                new Acao()
                {
                    Local = new Point(899,122),
                    Tag = "clica Data Emissão",
                    TempoEsperaAntesAcao = wait_antes,
                    TempoEsperaAposAcao = wait_depois
                },
                new Acao()
                {
                    Local = new Point(1108,70),
                    Tag = "clica no Emissor",
                    TempoEsperaAntesAcao = wait_antes,
                    TempoEsperaAposAcao = wait_depois
                },
                new Acao()
                {
                    Local = new Point(887,66),
                    Tag = "clica no Número da NF",
                    TempoEsperaAntesAcao = wait_antes,
                    TempoEsperaAposAcao = wait_depois
                },
                new Acao()
                {
                    Local = new Point(865,89),
                    Tag = "clica na Série",
                    TempoEsperaAntesAcao = wait_antes,
                    TempoEsperaAposAcao = wait_depois
                },
                new Tecla()
                {
                    Key = "{F3}",
                    TempoEsperaAposAcao = 1000,
                },
            });

            count = 1;

            Clipboard.Clear();

            foreach (var a in acoes.Lista)
            {
                if (a.IsTecla)
                {
                    a.EnviarTecla();
                }
                else
                {
                    a.Clicar();
                }

                MainForm.AguardarResposta();

                if (STOP_CURRENT_PROCESS)
                {
                    return;
                }

                Teclado.sendToClipboardEntireTextSelected();

                switch (count)
                {
                    case 1:
                        nf_chave = Clipboard.GetText();
                        break;

                    case 2:
                        nf_tpOper = Clipboard.GetText();
                        break;

                    case 3:
                        nf_dtemi = Clipboard.GetText();
                        break;

                    case 4:
                        nf_emissor = Clipboard.GetText();
                        break;

                    case 5:
                        nf_numero = Clipboard.GetText();
                        break;

                    case 6:
                        nf_serie = Clipboard.GetText();
                        break;

                    default:
                        break;
                }

                count++;
            }

            #endregion

            #region "FAZ A OPERAÇÃO NÃO REALIZADA"

            acoes = new Actions(new List<AcaoBaseClass>()
            {
                // Carrega a nota fiscal de origem
                // Botão Direito nela e chama a Operação Não Realizada
                // Cola o Texto
                // Clica no botão de gravar
                // Clica para sair
                // Popup avisando pra marcar "NF Recusada com Emissão de NF de Entrada"

                // Carrega a nota fiscal de origem

                new Acao()
                {
                    Local = new Point(435,111),
                    Nome = "preenche o numero da NF de Origem",
                    TempoEsperaAntesAcao = 500,
                    TempoEsperaAposAcao = 500,
                    Texto = nf_numero
                    //PausarAposAcao = true
                },

                new Acao(84, -11, "F8 na Tela Principal"),

                //new Acao()
                //{
                //    Local = new Point(415,68),
                //    Nome = "preenche o fornecedor",
                //    TempoEsperaAntesAcao = wait_antes,
                //    TempoEsperaAposAcao = wait_depois,
                //    Texto = nfref_emissor
                //},

                //new Acao()
                //{
                //    Local = new Point(406,158),
                //    Nome = "preenche a data emissao",
                //    TempoEsperaAntesAcao = wait_antes,
                //    TempoEsperaAposAcao = wait_depois,
                //    Texto = nfref_dtemi
                //},
                //new Acao(84, -11, "F8 na  principal"),

                new Acao()
                {
                    Local = new Point(292,287),
                    BotaoMouse = AcaoBaseClass.MouseButton.RIGHT,
                    Nome = "botão direito na nf",
                    TempoEsperaAntesAcao = 500,
                    TempoEsperaAposAcao = 500,
                },

                new Tecla()
                {
                    Key = "{DOWN}",
                    TempoEsperaAntesAcao = wait_antes,
                    TempoEsperaAposAcao = wait_depois
                },
                new Tecla()
                {
                    Key = "{DOWN}",
                    TempoEsperaAntesAcao = wait_antes,
                    TempoEsperaAposAcao = wait_depois
                },
                new Tecla()
                {
                    Key = "{DOWN}",
                    TempoEsperaAntesAcao = wait_antes,
                    TempoEsperaAposAcao = wait_depois
                },

                new Tecla("{ENTER}"),

                new Acao()
                {
                    Local = new Point(513,201),
                    Nome = "clica no texto da operação não realizada",
                    TempoEsperaAntesAcao = 1000,
                },

                new Tecla("{HOME}"),

                new Tecla("{SHIFTDOWN}"),
                new Tecla()
                {
                    Key = "{DOWN}",
                    TempoEsperaAntesAcao = wait_antes,
                    TempoEsperaAposAcao = wait_depois
                },
                new Tecla()
                {
                    Key = "{DOWN}",
                    TempoEsperaAntesAcao = wait_antes,
                    TempoEsperaAposAcao = wait_depois
                },
                new Tecla()
                {
                    Key = "{DOWN}",
                    TempoEsperaAntesAcao = wait_antes,
                    TempoEsperaAposAcao = wait_depois
                },
                new Tecla()
                {
                    Key = "{DOWN}",
                    TempoEsperaAntesAcao = wait_antes,
                    TempoEsperaAposAcao = wait_depois
                },
                new Tecla("{DELETE}"),
                new Tecla("{SHIFTUP}"),

                new Tecla()
                {
                    Key = "NF CANCELADA PELA NF DE ENTRADA " + nfref_numero + "-" + nfref_serie + " DE " + nfref_dtemi,
                    TempoEsperaAntesAcao = wait_antes,
                    TempoEsperaAposAcao = wait_depois
                },

                new Tecla("{ENTER}"),
                new Tecla("{ENTER}"),

            });

            foreach (var a in acoes.Lista)
            {
                if (a.IsTecla)
                {
                    a.EnviarTecla();
                }
                else
                {
                    a.Clicar();
                }

                MainForm.AguardarResposta();

                if (STOP_CURRENT_PROCESS)
                {
                    return;
                }

                if (a.PausarAposAcao)
                {
                    DialogResult res = MessageBox.Show("Pausa após ação. Continua?", Application.ProductName,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (res == DialogResult.No)
                    {
                        return;
                    }
                }
            }

            #endregion


        }

        private void conectarDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
//#if DEBUG
//            var sqlConnection = DatabaseConnection.DEBUGConnection;
//            taConjunto.Connection = sqlConnection;
//            taCampos.Connection = sqlConnection;
//            taConjuntoCampos.Connection = sqlConnection;
//            taListarDadosConjunto.Connection = sqlConnection;
//            //#else
//            //            sb.AppendLine(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=");
//            //            sb.Append(System.IO.Path.GetDirectoryName(Application.UserAppDataPath) + @"\Data\App_Data\Database.mdf");
//            //            sb.Append(";Integrated Security=True");

//            //            global::FiscalApp.Properties.Settings.Default.dbProgram = sb.ToString();
//#endif

            Cursor = Cursors.WaitCursor;

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
            finally
            {
                Cursor = Cursors.Default;
            }

            whnd = AutoItX.WinGetHandle(Text);

            dgvConjunto.DataError += dataGridView_DataError;
            dgvCampos.DataError += dataGridView_DataError;
            dgvConjuntoCampos.DataError += dataGridView_DataError;

        }

        private void entrarDadosMIROToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmEntraDadosMIRO(fiscalDataSet);
            frm.ShowDialog(this);
        }
    }
}