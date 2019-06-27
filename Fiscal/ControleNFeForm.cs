using ExcelDataReader;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FiscalApp.FiscalDataSet;

namespace FiscalApp
{
    public partial class ControleNFeForm : Form
    {
        private const int idx_col_mandante = 0;
        private const int idx_col_Chave_Acesso_Nfe = 1;
        private const int idx_col_NFe = 2;
        private const int idx_col_Data_Emissao = 3;
        private const int idx_col_Fornecedor = 4;
        private const int idx_col_Nome1 = 5;
        private const int idx_col_Local_negocios = 6;
        private const int idx_col_Tipo_Operacao_NFe = 7;
        private const int idx_col_Situacao_NFe = 8;
        private const int idx_col_Situacao_Manif_Destinatario = 9;
        private const int idx_col_NumDoc = 10;
        private const int idx_col_Origem_Lancamento = 11;
        private const int idx_col_Chave_Acesso_Ref = 12;
        private const int idx_col_Tipo_Parceiro = 13;
        private const int idx_col_Finalidade_NFe = 14;
        private const int idx_col_Cancel_XML = 15;

        public ControleNFeForm()
        {
            InitializeComponent();
        }

        private void controleNFEBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.Validate();
            this.controleNFEBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.fiscalDataSet);

            this.Cursor = Cursors.Default;
            MessageBox.Show("Gravado com sucesso.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ControleNFe_Load(object sender, EventArgs e)
        {
#if DEBUG
            this.controleNFETableAdapter.Connection = DatabaseConnection.DEBUGConnection;
            this.manifestacoes_NFeTableAdapter.Connection = DatabaseConnection.DEBUGConnection;
            this.finalidade_NFeTableAdapter.Connection = DatabaseConnection.DEBUGConnection;
#endif

            this.controleNFETableAdapter.Fill(this.fiscalDataSet.ControleNFE);
            this.manifestacoes_NFeTableAdapter.Fill(this.fiscalDataSet.Manifestacoes_NFe);
            this.finalidade_NFeTableAdapter.Fill(this.fiscalDataSet.Finalidade_NFe);

            #region "SITUACAO NFE"
            Situacao_NFeRow row1 = this.fiscalDataSet.Situacao_NFe.NewSituacao_NFeRow();
            row1.Id = 1;
            row1.descricao = "1 - AUT MOMENTO CONSULTA";
            this.fiscalDataSet.Situacao_NFe.Rows.Add(row1);

            row1 = this.fiscalDataSet.Situacao_NFe.NewSituacao_NFeRow();
            row1.Id = 2;
            row1.descricao = "2 -USO DENEGADO";
            this.fiscalDataSet.Situacao_NFe.Rows.Add(row1);

            row1 = this.fiscalDataSet.Situacao_NFe.NewSituacao_NFeRow();
            row1.Id = 3;
            row1.descricao = "3 - DOC CANCELADO";
            this.fiscalDataSet.Situacao_NFe.Rows.Add(row1);
            #endregion

            #region "TIPO OPERACAO NFE"
            TipoOperacao_NFeRow row2 = this.fiscalDataSet.TipoOperacao_NFe.NewTipoOperacao_NFeRow();
            row2.Id = 0;
            row2.descricao = "0 - Entrada";
            this.fiscalDataSet.TipoOperacao_NFe.Rows.Add(row2);

            row2 = this.fiscalDataSet.TipoOperacao_NFe.NewTipoOperacao_NFeRow();
            row2.Id = 1;
            row2.descricao = "1 - Saída";
            this.fiscalDataSet.TipoOperacao_NFe.Rows.Add(row2);
            #endregion

            #region "ORIGEM LCTO NFE"
            Origem_Lcto_NFeRow row3 = this.fiscalDataSet.Origem_Lcto_NFe.NewOrigem_Lcto_NFeRow();
            row3.Id = -1;
            row3.descricao = "";
            this.fiscalDataSet.Origem_Lcto_NFe.Rows.Add(row3);

            row3 = this.fiscalDataSet.Origem_Lcto_NFe.NewOrigem_Lcto_NFeRow();
            row3.Id = 1;
            row3.descricao = "1 - EGR";
            this.fiscalDataSet.Origem_Lcto_NFe.Rows.Add(row3);

            row3 = this.fiscalDataSet.Origem_Lcto_NFe.NewOrigem_Lcto_NFeRow();
            row3.Id = 2;
            row3.descricao = "2 - FORA EGR";
            this.fiscalDataSet.Origem_Lcto_NFe.Rows.Add(row3);
            #endregion

            #region "TIPOS PARCEIRO"
            Tipos_ParceiroRow row4 = this.fiscalDataSet.Tipos_Parceiro.NewTipos_ParceiroRow();
            row4.Id = 1;
            row4.codigo = "";
            row4.descricao = "";
            this.fiscalDataSet.Tipos_Parceiro.Rows.Add(row4);

            row4 = this.fiscalDataSet.Tipos_Parceiro.NewTipos_ParceiroRow();
            row4.Id = 2;
            row4.codigo = "C";
            row4.descricao = "C - Cliente";
            this.fiscalDataSet.Tipos_Parceiro.Rows.Add(row4);

            row4 = this.fiscalDataSet.Tipos_Parceiro.NewTipos_ParceiroRow();
            row4.Id = 3;
            row4.codigo = "V";
            row4.descricao = "V - Fornecedor";
            this.fiscalDataSet.Tipos_Parceiro.Rows.Add(row4);
            #endregion

        }

        private void controleNFEDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (NoNullAllowedException noNull)
            {
                string nulo = noNull.Message;
            }
            catch (Exception ex)
            {
                string geral = ex.Message;
            }
        }

        private void tsbImportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = SpecialDirectories.MyDocuments;
                ofd.Multiselect = false;
                ofd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                ofd.DefaultExt = "xlsx";
                ofd.Title = "Selecione o arquivo...";

                if (ofd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                {
                    IExcelDataReader excelReader = null;
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                    DataSet result = excelReader.AsDataSet();

                    if (result.Tables[0].Rows.Count == 0)
                    {
                        return;
                    }

                    result.Tables[0].Rows.RemoveAt(0);

                    Cursor = Cursors.WaitCursor;

                    foreach (DataRow xls in result.Tables[0].Rows)
                    {
                        ControleNFERow row = this.fiscalDataSet.ControleNFE.NewControleNFERow();
                        row.chaveAcesso = xls[idx_col_Chave_Acesso_Nfe].ToString();
                        row.NFe = xls[idx_col_NFe].ToString();
                        row.dataEmissao = (DateTime)xls[idx_col_Data_Emissao];

                        if (!string.IsNullOrEmpty(xls[idx_col_Fornecedor].ToString()))
                        {
                            row.codigoEmitente = Convert.ToInt32(xls[idx_col_Fornecedor].ToString());
                        }

                        row.razaoSocial = xls[idx_col_Nome1].ToString();
                        row.filial = xls[idx_col_Local_negocios].ToString();
                        row.tipoOperacaoNF = Convert.ToInt32(xls[idx_col_Tipo_Operacao_NFe].ToString());

                        if (!string.IsNullOrEmpty(xls[idx_col_Situacao_NFe].ToString()))
                        {
                            row.situacaoNFe = Convert.ToInt32(xls[idx_col_Situacao_NFe].ToString());
                        }

                        row.situacaoManifestacao = -1;
                        if (!string.IsNullOrEmpty(xls[idx_col_Situacao_Manif_Destinatario].ToString()))
                        {
                            row.situacaoManifestacao = Convert.ToInt32(xls[idx_col_Situacao_Manif_Destinatario].ToString());
                        }

                        row.DOCNUM = Convert.ToInt32(xls[idx_col_NumDoc].ToString());

                        if (!string.IsNullOrEmpty(xls[idx_col_Origem_Lancamento].ToString()))
                        {
                            row.origemLancamento = Convert.ToInt32(xls[idx_col_Origem_Lancamento].ToString());
                        }
                        if (!string.IsNullOrEmpty(xls[idx_col_Chave_Acesso_Ref].ToString()))
                        {
                            row.chaveAcessoRef = xls[idx_col_Chave_Acesso_Ref].ToString();
                        }
                        if (!string.IsNullOrEmpty(xls[idx_col_Tipo_Parceiro].ToString()))
                        {
                            row.tipoParceiro = xls[idx_col_Tipo_Parceiro].ToString();
                        }
                        if (!string.IsNullOrEmpty(xls[idx_col_Finalidade_NFe].ToString()))
                        {
                            row.finalidadeNFe = Convert.ToInt32(xls[idx_col_Finalidade_NFe].ToString());
                        }
                        if (!string.IsNullOrEmpty(xls[idx_col_Cancel_XML].ToString()))
                        {
                            row.cancelXML = xls[idx_col_Cancel_XML].ToString();
                        }
                        this.fiscalDataSet.ControleNFE.Rows.Add(row);
                    }

                    Cursor = Cursors.Default;

                    MessageBox.Show("Dados carregados com sucesso.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbExportarExcel_Click(object sender, EventArgs e)
        {

        }

        private string currFilter
        {
            get
            {
                if (controleNFEBindingSource.Filter == null)
                {
                    return "";
                }
                return controleNFEBindingSource.Filter;
            }
            set
            {
                controleNFEBindingSource.Filter = value;
            }
        }

        private string tratarFiltro()
        {
            string filtro = "";
            if (controleNFEBindingSource.Filter == null)
            {
                filtro = "";
            }
            else
            {
                filtro = controleNFEBindingSource.Filter;
            }
            if (filtro.Length == 0)
            {
                return filtro;
            }
            if (filtro.ToLower().IndexOf(" and ") > 0)
            {
                return filtro;
            }
            else
            {
                return filtro + " and ";
            }
        }

        private void radEntrada_Click(object sender, EventArgs e)
        {
            controleNFEBindingSource.Filter = tratarFiltro() + " tipoOperacaoNF = " + radEntrada.Tag.ToString();
        }

        private void radSaida_Click(object sender, EventArgs e)
        {
            controleNFEBindingSource.Filter = tratarFiltro() + " tipoOperacaoNF = " + radSaida.Tag.ToString();
        }

        private void radTpOperacaoAmbos_Click(object sender, EventArgs e)
        {
            controleNFEBindingSource.Filter = tratarFiltro() + " (tipoOperacaoNF = 0 OR tipoOperacaoNF = 1) ";
        }

        private void btnLimparFiltro_Click(object sender, EventArgs e)
        {
            controleNFEBindingSource.Filter = "";
            radEntrada.Checked = false;
            radSaida.Checked = false;
            radTpOperacaoAmbos.Checked = false;
        }

        private void cboSituacaoNFE_SelectedIndexChanged(object sender, EventArgs e)
        {
            controleNFEBindingSource.Filter = tratarFiltro() + " situacaoNFe = " + cboSituacaoNFE.SelectedValue.ToString();
        }

        private void cboSituacaoManifestacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            controleNFEBindingSource.Filter = tratarFiltro() + " situacaoManifestacao = " + cboSituacaoManifestacao.SelectedValue.ToString();
        }

        private void cboFinalidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            controleNFEBindingSource.Filter = tratarFiltro() + " finalidadeNFe = " + cboFinalidade.SelectedValue.ToString();
        }

        private void radCliente_Click(object sender, EventArgs e)
        {
            controleNFEBindingSource.Filter = tratarFiltro() + " tipoParceiro = '" + radCliente.Tag.ToString() + "' ";
        }

        private void radFornecedor_Click(object sender, EventArgs e)
        {
            controleNFEBindingSource.Filter = tratarFiltro() + " tipoParceiro = '" + radFornecedor.Tag.ToString() + "' ";
        }

        private void radTipoParceiroAmbos_Click(object sender, EventArgs e)
        {
            controleNFEBindingSource.Filter = tratarFiltro() + " tipoParceiro <> 'X' ";
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }
    }
}
