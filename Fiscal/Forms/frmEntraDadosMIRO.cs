using AutoIt;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static FiscalApp.FiscalDataSet;

namespace FiscalApp
{
    public partial class frmEntraDadosMIRO : Form
    {
        private DataSet dataSet = null;
        private string[] ufs = new string[] { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };

        public frmEntraDadosMIRO(DataSet dataSet)
        {
            InitializeComponent();

            this.dataSet = dataSet;
        }

        private void send(string text)
        {
            AutoItX.Send(text);
        }

        private void btnPreencher_Click(object sender, EventArgs e)
        {
            FiscalApp.Properties.Settings.Default.Save();

            string fmt = @"^(\$)?((\d+)|(\d{1,3})(\,\d{3})*)(\,\d{2,})?$";

            if (System.Text.RegularExpressions.Regex.IsMatch(Montante.Text, fmt))
            {
            }
            else
            {
                MessageBox.Show("Valores digitados estão com formato inválido.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string retornoClip = "";

            const int DTFATURA = 27;
            const int NRNF = 28;
            const int VLRNF = 30;
            const int idITEM1_PEDIDO = 12;
            const int CLICK_DETALHE_MIRO = 31;
            const int CATEGORIANF = 32;
            const int CLICK_NF = 33;
            const int CLICK_DETALHE_ITEM = 34;
            const int LINHA1_ITEM_CFOP = 44;
            const int CLK_IMPOSTOS = 39;
            const int NUMERO_PEDIDO = 43;
            const int VERIF_SALDO = 45;
            const int idCOD_CONTROLE = 46;
            const int idSIMULAR = 47;
            const int idSEMAFORO = 48;

            CorSemaforo.BackColor = SystemColors.GrayText;

            FiscalDataSet fiscal = (FiscalDataSet)dataSet;

            if (fiscal.Campos.Count.Equals(0))
            {
                MessageBox.Show("Necessário conectar com banco de dados.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            MainForm.bringSAPUI_ToFront();

            CamposRow DATA_FATURA = (CamposRow)fiscal.Campos.Select("id = " + DTFATURA)[0];
            CamposRow NUMERO_NF = (CamposRow)fiscal.Campos.Select("id = " + NRNF)[0];
            CamposRow VLR_NF = (CamposRow)fiscal.Campos.Select("id = " + VLRNF)[0];
            CamposRow CLK_DETALHES = (CamposRow)fiscal.Campos.Select("id = " + CLICK_DETALHE_MIRO)[0];
            CamposRow CTG_NF = (CamposRow)fiscal.Campos.Select("id = " + CATEGORIANF)[0];
            CamposRow CLK_NF = (CamposRow)fiscal.Campos.Select("id = " + CLICK_NF)[0];
            CamposRow COL_CFOP_GRID = (CamposRow)fiscal.Campos.Select("id = " + LINHA1_ITEM_CFOP)[0];
            CamposRow CLICA_DETALHE_ITEM = (CamposRow)fiscal.Campos.Select("id = " + CLICK_DETALHE_ITEM)[0];
            CamposRow CLICK_IMPOSTOS = (CamposRow)fiscal.Campos.Select("id = " + CLK_IMPOSTOS)[0];
            CamposRow NR_PEDIDO = (CamposRow)fiscal.Campos.Select("id = " + NUMERO_PEDIDO)[0];
            CamposRow VERIFICA_SALDO = (CamposRow)fiscal.Campos.Select("id = " + VERIF_SALDO)[0];
            CamposRow CODIGO_CONTROLE = (CamposRow)fiscal.Campos.Select("id = " + idCOD_CONTROLE)[0];
            CamposRow SIMULAR = (CamposRow)fiscal.Campos.Select("id = " + idSIMULAR)[0];
            CamposRow ITEM1PEDIDO = (CamposRow)fiscal.Campos.Select("id = " + idITEM1_PEDIDO)[0];
            CamposRow SEMAFORO = (CamposRow)fiscal.Campos.Select("id = " + idSEMAFORO)[0];

            MainForm.clickEditingControl(DATA_FATURA);
            send(DataFatura.Text);

            MainForm.clickEditingControl(NUMERO_NF);
            send(NumeroNF.Text);

            MainForm.clickEditingControl(VLR_NF);
            send(Montante.Text);

            MainForm.clickEditingControl(NR_PEDIDO);
            send(Pedido.Text);
            send("{ENTER}");

            // Aguarda retorno do pedido.
            MainForm.AguardarResposta();
            if (MainForm.STOP_CURRENT_PROCESS) { return; }

            //System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            //sw.Start();

            #region "Confere a UF"

            //// Abre a tela de fornecedor.
            //MainForm.clickEditingControl(804, 89, toolTip: "Aguarde a leitura da tela...");
            //System.Threading.Thread.Sleep(500);
            //send("{ENTER}");

            //MainForm.AguardarResposta(); // Aguarda carregamento da tela.
            //if (MainForm.STOP_CURRENT_PROCESS) { return; }

            //// Lê a UF da tela.
            //MainForm.clickEditingControl(412, 377);
            //MainForm.copyEntireTextFromControl();
            ////MainForm.AguardarResposta();
            //txtUFFornecedor.Text = Clipboard.GetText();

            //send("{F8}");       // Vai pro CNPJ
            //MainForm.AguardarResposta();

            //MainForm.clickEditingControl(227, 176); // Lê o CNPJ
            //MainForm.copyEntireTextFromControl();
            ////MainForm.AguardarResposta();
            //retornoClip = Clipboard.GetText();      // Copia o CNPJ

            //send("{F3}");       
            //MainForm.AguardarResposta();

            #endregion

            bool ufValida = false;

            if (txtUFFornecedor.Text.Length == 2)
            {
                for (int i = 0; i < ufs.Length; i++)
                {
                    ufValida = txtUFFornecedor.Text.Equals(ufs[i]);
                    if (ufValida)
                    {
                        break;
                    }
                }
            }

            if (!ufValida)
            {
                var continua = MessageBox.Show("Não identificado a UF no local esperado. Continua?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                if (continua == DialogResult.Cancel) { return; }
            }
            else
            {
                AtualizarDadosFornecedor();
            }

            //string strFimCNPJ = "";

            //try
            //{
            //    strFimCNPJ = retornoClip.Substring(retornoClip.Length - 6, 6);
            //}
            //catch (Exception)
            //{

            //}

            //if (!FimCNPJ.Text.Equals(strFimCNPJ))
            //{
            //    var continua = MessageBox.Show("Parece que o final do CNPJ está diferente do pedido. Continua?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            //    if (continua == DialogResult.Cancel) { return; }
            //}

            // Verifica se é pedido rateado %
            MainForm.clickEditingControl(263, 422, "Aguarde a leitura da tela...");     // LINHA 1 ITEM - COLUNA PERCENTUAL
            retornoClip = MainForm.copyEntireTextFromControl();

            if (retornoClip.Trim().Equals("%"))
            {
                CalcularVlrUnitarioDePedido100();
            }

            //// Verifica o saldo.
            //MainForm.clickEditingControl(VERIFICA_SALDO);
            //retornoClip = MainForm.copyEntireTextFromControl();

            //if (retornoClip.Length == 0)
            //{
            //    var continua = MessageBox.Show("Erro ao verificar o saldo. Continue somente após estar OK.\n\nContinua?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            //    if (continua == DialogResult.Cancel) { return; }
            //}

            //decimal saldo = decimal.Parse(retornoClip);

            //if (!saldo.Equals(0))
            //{
            //    var continua = MessageBox.Show("Confime SOMENTE após Semáforo Verde.", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            //    if (continua == DialogResult.Cancel) { return; }
            //}

            var sema = new Semaforo();
            sema.VerificaSemaforo();

            CorSemaforo.BackColor = sema.Cor;

            if (sema.SemaforoVerde)
            {
                // OK
            }
            else
            {
                if (sema.SemaforoAmarelo)
                {
                    var continua = MessageBox.Show("Semáforo AMARELO. Continua?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    if (continua == DialogResult.Cancel) { return; }
                }
                else
                {
                    var continua = MessageBox.Show("Semáforo VERMELHO.\n\nIrregularidade encontrada. Verifique o pedido.\nCorrija e pressione OK para continuar.\n\nContinua?", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    if (continua == DialogResult.Cancel) { return; }
                }
            }

            if (CategoriaNF.Text.Length == 0)
            {
                return;
            }

            MainForm.clickEditingControl(CLK_DETALHES);

            MainForm.AguardarResposta();    // Tem que aguardar, o SAP tem um delay ao clicar na aba de Detalhes.

            if (MainForm.STOP_CURRENT_PROCESS) { return; }

            send("{ENTER}");        // Para confirmar msg de data de vencimento.

            System.Threading.Thread.Sleep(1000); // aguarda um pouco mais pq a aba detalhe tem delay para mudar ao clicar mas nao tem waitcursor.

            MainForm.clickEditingControl(CTG_NF);

            //System.Threading.Thread.Sleep(500);

            send(CategoriaNF.Text);
            send("{ENTER}");
            send("{ENTER}");

            // Aguarda trazer o botão Nota Fiscal após digitar Categoria NF.
            MainForm.AguardarResposta();
            if (MainForm.STOP_CURRENT_PROCESS) { return; }

            MainForm.clickEditingControl(CLK_NF);

            // Aguarda até carregar a tela de nota fiscal.
            MainForm.AguardarResposta();
            if (MainForm.STOP_CURRENT_PROCESS) { return; }

            if (CFOP.Text.Length > 0)
            {
                MainForm.clickEditingControl(COL_CFOP_GRID);
                Teclado.selectTextAndClear();
                send(CFOP.Text);
            }

            if (CodigoServico.Text.Length > 0)
            {
                MainForm.clickEditingControl(CODIGO_CONTROLE);
                Teclado.selectTextAndClear();
                send(CodigoServico.Text);
            }


            string obs = "";

            if (chkSimplesNacional.Checked)
            {
                obs += "SIMPLES=5% ";
            }

            if (chkSimei.Checked)
            {
                obs += "SIMEI";
            }

            if (obs.Length > 0)
            {
                MainForm.clickEditingControl(270, 157);
                send(obs);
            }

            send("{F3}");
            MainForm.AguardarResposta();
            if (MainForm.STOP_CURRENT_PROCESS) { return; }

            MainForm.clickEditingControl(SIMULAR);
            //MainForm.AguardarResposta();
            //if (MainForm.STOP_CURRENT_PROCESS) { return; }

            //MessageBox.Show("Finalizado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }

        public void CalcularVlrUnitarioDePedido100()
        {
            const int POSICIONAR_ITEM_1_PEDIDO = 26;
            const int POSICIONAR_EM_VALOR_MONTANTE = 21;
            const int MOSTRAR_VLR_LIQUIDO = 22;
            const int FOCAR_CAMPO_VLR_LIQUIDO = 23;
            const int CLICAR_QUANTIDADE_ITEM_1_PED = 24;
            const int VOLTAR_BARRA_AO_INICIO = 25;

            FiscalDataSet fiscal = (FiscalDataSet)dataSet;

            CamposRow posicionaValorItem1Pedido = (CamposRow)fiscal.Campos.Select("id = " + POSICIONAR_ITEM_1_PEDIDO)[0];
            CamposRow posicionaVlrMontante = (CamposRow)fiscal.Campos.Select("id = " + POSICIONAR_EM_VALOR_MONTANTE)[0];
            CamposRow mostrarVlrLiquido = (CamposRow)fiscal.Campos.Select("id = " + MOSTRAR_VLR_LIQUIDO)[0];
            CamposRow clicaCampoVlrLiquido = (CamposRow)fiscal.Campos.Select("id = " + FOCAR_CAMPO_VLR_LIQUIDO)[0];
            CamposRow clicaQtdeItem1 = (CamposRow)fiscal.Campos.Select("id = " + CLICAR_QUANTIDADE_ITEM_1_PED)[0];
            CamposRow voltarBarraAoInicio = (CamposRow)fiscal.Campos.Select("id = " + VOLTAR_BARRA_AO_INICIO)[0];

            // posiciona em Valor Montante
            MainForm.clickEditingControl(posicionaVlrMontante.locationX, posicionaVlrMontante.locationY, "", false);

            // Seleciona texto.
            Teclado.selecEntireTextFromControl();

            // Copia valor montante.
            MainForm.sendCONTROLCandRELEASE();

            string valorMontanteClip = Clipboard.GetText();

            // posiciona no valor do item 1.
            MainForm.clickEditingControl(posicionaValorItem1Pedido.locationX, posicionaValorItem1Pedido.locationY, "", false);

            // Seleciona texto.
            Teclado.selecEntireTextFromControl();

            // Apaga.
            Teclado.clearTextSelected();

            // Cola valor da clip.
            MainForm.sendCONTROLVandRELEASE();

            // Move barra de rolagem p/ exibir Preço Líquido do Pedido.
            MainForm.clickEditingControl(mostrarVlrLiquido.locationX, mostrarVlrLiquido.locationY, "", false);

            // clica no campo de Vlr Líquido.
            MainForm.clickEditingControl(clicaCampoVlrLiquido.locationX, clicaCampoVlrLiquido.locationY, "", false);

            // Seleciona texto.
            Teclado.selecEntireTextFromControl();

            // Copia valor líquido.
            MainForm.sendCONTROLCandRELEASE();

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
            MainForm.clickEditingControl(voltarBarraAoInicio.locationX, voltarBarraAoInicio.locationY, "", false);

            // posiciona no campo quantidade.
            MainForm.clickEditingControl(clicaQtdeItem1.locationX, clicaQtdeItem1.locationY, "", false);

            // Seleciona texto.
            Teclado.selecEntireTextFromControl();

            // Apaga.
            Teclado.clearTextSelected();

            // manda percentual p/ clip.
            Clipboard.SetText(percentual.ToString());

            // Cola valor da clip.
            MainForm.sendCONTROLVandRELEASE();

            // Envia enter
            MainForm.sendText("{ENTER}");
            MainForm.sendText("{ENTER}");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            FiscalApp.Properties.Settings.Default.Save();
            Close();
        }

        private void NumeroNF_Leave(object sender, EventArgs e)
        {
            if (NumeroNF.Text.Length > 6)
            {
                CategoriaNF.Text = "ZS";
            }
            else
            {
                CategoriaNF.Text = "ZZ";
            }
        }

        private void txtUFFornecedor_Leave(object sender, EventArgs e)
        {
            AtualizarDadosFornecedor();
        }

        private void AtualizarDadosFornecedor()
        {
            if (txtUFFornecedor.Text.Trim() == "")
            {
                return;
            }
            if (txtUFFornecedor.Text.ToUpper() == "SP")
            {
                CFOP.Text = "1999/XX";
            }
            else
            {
                CFOP.Text = "2999/XX";
            }
        }

        private void chkIncluiAno_CheckedChanged(object sender, EventArgs e)
        {
            string texto = "-" + DateTime.Now.Year.ToString().Substring(2);

            if (chkIncluiAno.Checked)
            {
                NumeroNF.Text = NumeroNF.Text + texto;
            }
            else
            {
                NumeroNF.Text = NumeroNF.Text.Replace(texto, "");
            }
        }

        private void CategoriaNF_Leave(object sender, EventArgs e)
        {
            if (CategoriaNF.Text.Length == 0)
            {
                MessageBox.Show("Dados de Nota Fiscal não serão preenchidos.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
        }

        private void Pedido_Enter(object sender, EventArgs e)
        {
            if (Pedido.Text.Length > 4)
            {
                Pedido.Select(4, 6);
            }
        }

        private void FimCNPJ_Leave(object sender, EventArgs e)
        {
            FimCNPJ.Text = FimCNPJ.Text.Replace("-", "");
        }

        private void CodigoServico_Enter(object sender, EventArgs e)
        {
            if (CodigoServico.Text.Length > 3)
            {
                CodigoServico.Select(3, 4);
            }
        }
    }
}
