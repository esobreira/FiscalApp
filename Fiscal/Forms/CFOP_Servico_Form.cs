using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiscalApp
{
    public partial class CFOP_Servico_Form : Form
    {
        public CFOP_Servico_Form()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CFOP.Text) || string.IsNullOrEmpty(CodigoServico.Text) || string.IsNullOrEmpty(QtdeRepeat.Text))
            {
                MessageBox.Show("É necessário preencher os 3 campos.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                return;
            }
        }

        private void CFOP_Servico_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            global::FiscalApp.Properties.Settings.Default.Save();
        }

        private void CFOP_Servico_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void MultiplePagesCheck_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = MultiplePagesCheck.Checked;
        }
    }
}
