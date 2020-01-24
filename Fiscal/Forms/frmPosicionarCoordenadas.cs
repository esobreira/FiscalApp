using System;
using System.Windows.Forms;

namespace FiscalApp
{
    public partial class frmPosicionarCoordenadas : Form
    {
        public frmPosicionarCoordenadas()
        {
            InitializeComponent();
        }

        private void btnPosicionar_Click(object sender, EventArgs e)
        {
            MainForm.bringSAPUI_ToFront();

            MainForm.clickEditingControl((int)txtX.Value, (int)txtY.Value, mouseSpeed: 30);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
