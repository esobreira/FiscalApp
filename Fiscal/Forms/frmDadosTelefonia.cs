using AutoIt;
using System;
using System.Data;
using System.Windows.Forms;
using static FiscalApp.FiscalDataSet;

namespace FiscalApp
{
    public partial class frmDadosTelefonia : Form
    {
        private DataSet dataSet;

        public frmDadosTelefonia(DataSet dataSet)
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
            MainForm.bringSAPUI_ToFront();

            FiscalApp.Properties.Settings.Default.Save();

            string fmt = @"^(\$)?((\d+)|(\d{1,3})(\,\d{3})*)(\,\d{2,})?$";

            if (System.Text.RegularExpressions.Regex.IsMatch(ValorNF.Text, fmt) && System.Text.RegularExpressions.Regex.IsMatch(BaseCalculoNF.Text, fmt))
            {
            }
            else
            {
                MessageBox.Show("Valores digitados estão com formato inválido.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            const int DTFATURA = 27;
            const int NRNF = 28;
            const int DTLANC = 29;
            const int VLRNF = 30;
            //const int LINHA1_ITENS_PEDIDO = 12;
            const int CLICK_DETALHE_MIRO = 31;
            const int CATEGORIANF = 32;
            const int CLICK_NF = 33;
            const int CLICK_DETALHE_ITEM = 34;
            const int LINHA1_ITEM_CFOP = 44;
            const int CLK_IMPOSTOS = 39;
            const int ENTRA_VLR_ISENTAS = 41;
            const int ENTRA_VLR_OUTRA_BASE = 42;
            const int NUMERO_PEDIDO = 43;
            const int VERIF_SALDO = 45;

            calculaIsentas();

            FiscalDataSet fiscal = (FiscalDataSet)dataSet;

            CamposRow DATA_FATURA = (CamposRow)fiscal.Campos.Select("id = " + DTFATURA)[0];
            CamposRow NUMERO_NF = (CamposRow)fiscal.Campos.Select("id = " + NRNF)[0];
            CamposRow DATA_LANCAMENTO = (CamposRow)fiscal.Campos.Select("id = " + DTLANC)[0];
            CamposRow VLR_NF = (CamposRow)fiscal.Campos.Select("id = " + VLRNF)[0];
            //CamposRow LINHA1_PEDIDO = (CamposRow)fiscal.Campos.Select("id = " + LINHA1_ITENS_PEDIDO)[0];
            CamposRow CLK_DETALHES = (CamposRow)fiscal.Campos.Select("id = " + CLICK_DETALHE_MIRO)[0];
            CamposRow CTG_NF = (CamposRow)fiscal.Campos.Select("id = " + CATEGORIANF)[0];
            CamposRow CLK_NF = (CamposRow)fiscal.Campos.Select("id = " + CLICK_NF)[0];
            CamposRow COL_CFOP_GRID = (CamposRow)fiscal.Campos.Select("id = " + LINHA1_ITEM_CFOP)[0];
            //CamposRow DBL_CLICK_LINHA1 = (CamposRow)fiscal.Campos.Select("id = " + DPL_CLK_LINHA1)[0];
            CamposRow CLICA_DETALHE_ITEM = (CamposRow)fiscal.Campos.Select("id = " + CLICK_DETALHE_ITEM)[0];
            CamposRow CLICK_IMPOSTOS = (CamposRow)fiscal.Campos.Select("id = " + CLK_IMPOSTOS)[0];
            CamposRow VLR_ISENTAS = (CamposRow)fiscal.Campos.Select("id = " + ENTRA_VLR_ISENTAS)[0];
            CamposRow VLR_OUTRA_BASE = (CamposRow)fiscal.Campos.Select("id = " + ENTRA_VLR_OUTRA_BASE)[0];
            CamposRow NR_PEDIDO = (CamposRow)fiscal.Campos.Select("id = " + NUMERO_PEDIDO)[0];
            CamposRow VERIFICA_SALDO = (CamposRow)fiscal.Campos.Select("id = " + VERIF_SALDO)[0];

            MainForm.clickEditingControl(DATA_FATURA);
            send(DataFatura.Text);

            MainForm.clickEditingControl(NUMERO_NF);
            send(NumeroNF.Text);

            MainForm.clickEditingControl(DATA_LANCAMENTO);
            Teclado.selectTextAndClear();
            send(DataLancamento.Text);

            MainForm.clickEditingControl(VLR_NF);
            send(ValorNF.Text);

            MainForm.clickEditingControl(NR_PEDIDO);
            send(Pedido.Text);
            send("{ENTER}");

            MainForm.AguardarResposta();
            if (MainForm.STOP_CURRENT_PROCESS) { return; }

            MainForm.clickEditingControl(VERIFICA_SALDO);
            decimal saldo = decimal.Parse(MainForm.copyEntireTextFromControl());

            if (!saldo.Equals(0))
            {
                var continua = MessageBox.Show("Confime SOMENTE após Semáforo Verde.", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                if (continua == DialogResult.Cancel) { return; }
            }

            MainForm.clickEditingControl(CLK_DETALHES);
            System.Threading.Thread.Sleep(1000);
            send("{ENTER}");        // Para confirmar msg de data de vencimento.

            MainForm.AguardarResposta();
            if (MainForm.STOP_CURRENT_PROCESS) { return; }

            MainForm.clickEditingControl(CTG_NF);
            send("T1");
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
            send(CFOPTelefonia.Text);
            send("{ENTER}");

            MainForm.AguardarResposta();
            if (MainForm.STOP_CURRENT_PROCESS) { return; }

            MainForm.clickEditingControl(CLICA_DETALHE_ITEM);

            MainForm.clickEditingControl(CLICK_IMPOSTOS);

            MainForm.clickEditingControl(VLR_OUTRA_BASE);
            Teclado.selectTextAndClear();
            send(BaseCalculoNF.Text);

            MainForm.clickEditingControl(VLR_ISENTAS);
            send(ValorIsentasNF.Text);

            send("{ENTER}");
            send("{ENTER}");

            MessageBox.Show("Finalizado.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }

        private void calculaIsentas()
        {
            decimal valorIsentas = decimal.Parse(ValorNF.Text) - decimal.Parse(BaseCalculoNF.Text);
            ValorIsentasNF.Text = valorIsentas.ToString("n");
        }

        private void BaseCalculoNF_Leave(object sender, EventArgs e)
        {
            calculaIsentas();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            FiscalApp.Properties.Settings.Default.Save();
            Close();
        }

        private void ValorNF_Enter(object sender, EventArgs e)
        {
            //ValorNF.Value = 0;
        }

        private void BaseCalculoNF_Enter(object sender, EventArgs e)
        {
            //BaseCalculoNF.Value = 0;
        }

        private void NumeroNF_Leave(object sender, EventArgs e)
        {
            if (NumeroNF.Text.IndexOf("-") > 0)
            {
                return;
            }
            if (NumeroNF.Text.Length > 6)
            {
                NumeroNF.Text = NumeroNF.Text.Insert(6, "-");
            }
        }

        private void frmDadosTelefonia_Load(object sender, EventArgs e)
        {

        }
    }
}
