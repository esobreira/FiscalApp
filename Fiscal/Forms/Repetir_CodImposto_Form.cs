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
    public partial class Repetir_CodImposto_Form : Form
    {
        public Repetir_CodImposto_Form()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CodigoImpostoIVA.Text) || string.IsNullOrEmpty(QtdeRepeat.Text))
            {
                MessageBox.Show("É necessário a informação.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void Repetir_CodImposto_Form_Shown(object sender, EventArgs e)
        {
            this.CodigoImpostoIVA.Text = global::FiscalApp.Properties.Settings.Default.lastCodImpostoIVAtyped;
        }

        private void Repetir_CodImposto_FormClosed(object sender, FormClosedEventArgs e)
        {
            global::FiscalApp.Properties.Settings.Default.lastCodImpostoIVAtyped = this.CodigoImpostoIVA.Text;
            global::FiscalApp.Properties.Settings.Default.Save();
        }

        private void Repetir_CodImposto_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void MultiplePagesCheck_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void MultiplePagesCheck_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = MultiplePagesCheck.Checked;
        }
    }
}
