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
            Program.LOG = new System.Text.StringBuilder();

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

            // Verifica se é pedido rateado %
            MainForm.clickEditingControl(263, 422);     // LINHA 1 ITEM - COLUNA PERCENTUAL
            retornoClip = MainForm.copyEntireTextFromControl();
            if (retornoClip.Trim().Equals("%"))
            {
                CalcularVlrUnitarioDePedido100();
            }

            MainForm.AguardarResposta();
            if (MainForm.STOP_CURRENT_PROCESS) { return; }

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
                    MessageBox.Show("Irregularidade encontrada ao buscar o pedido. Verifique o pedido. Processo cancelado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return;
                }
            }

            MainForm.AguardarResposta();
            if (MainForm.STOP_CURRENT_PROCESS) { return; }

            // Verifica o saldo.
            MainForm.clickEditingControl(VERIFICA_SALDO);
            retornoClip = MainForm.copyEntireTextFromControl();
            if (retornoClip.Length == 0)
            {
                MessageBox.Show("Erro ao verificar o saldo. Processo cancelado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal saldo = decimal.Parse(retornoClip);

            if (!saldo.Equals(0))
            {
                var continua = MessageBox.Show("Confime SOMENTE após Semáforo Verde.", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                if (continua == DialogResult.Cancel) { return; }
            }

            if (CategoriaNF.Text.Length == 0)
            {
                return;
            }

            MainForm.clickEditingControl(CLK_DETALHES);
            System.Threading.Thread.Sleep(1000);
            send("{ENTER}");        // Para confirmar msg de data de vencimento.

            MainForm.AguardarResposta();
            if (MainForm.STOP_CURRENT_PROCESS) { return; }

            MainForm.clickEditingControl(CTG_NF);
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

            MainForm.clickEditingControl(COL_CFOP_GRID);
            Teclado.selectTextAndClear();
            send(CFOP.Text);

            MainForm.clickEditingControl(CODIGO_CONTROLE);
            Teclado.selectTextAndClear();
            send(CodigoServico.Text);

            send("{F3}");
            MainForm.AguardarResposta();
            if (MainForm.STOP_CURRENT_PROCESS) { return; }

            MainForm.clickEditingControl(SIMULAR);
            //MainForm.AguardarResposta();
            //if (MainForm.STOP_CURRENT_PROCESS) { return; }

            //MessageBox.Show("Finalizado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

            lblLOG.Text = Program.LOG.ToString();
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

        private void frmEntraDadosMIRO_Load(object sender, EventArgs e)
        {
            
        }
    }
}
