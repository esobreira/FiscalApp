using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FiscalApp.Acao;

namespace FiscalApp
{
    public abstract class AcaoBaseClass
    {
        public int TempoEsperaAntesAcao { get; set; }
        public int TempoEsperaAposAcao { get; set; }
        public string Tag { get; set; }
        public bool PausarAposAcao { get; set; }
        //public AcoesPredefinidas AcaoPredefinida { get; set; }

        public abstract bool IsTecla { get; }
        public abstract void EnviarTecla();
        public abstract void Clicar();

        protected void EnviarTecla(string key)
        {
            if (TempoEsperaAntesAcao > 0)
            {
                System.Threading.Thread.Sleep(TempoEsperaAntesAcao);
            }

            AutoIt.AutoItX.Send(key);

            if (TempoEsperaAposAcao > 0)
            {
                System.Threading.Thread.Sleep(TempoEsperaAposAcao);
            }
        }

        protected void Clicar(int x, int y, MouseButton button)
        {
            if (TempoEsperaAntesAcao > 0)
            {
                System.Threading.Thread.Sleep(TempoEsperaAntesAcao);
            }
            if (TempoEsperaAposAcao > 0)
            {
                MainForm.clickEditingControl(x, y, noWait: false, mouseSpeed: 1, waitTime: TempoEsperaAposAcao, button: button);
            }
            else
            {
                MainForm.clickEditingControl(x, y, noWait: true, mouseSpeed: 1);
            }
            
        }

        //public bool IsAcaoPredefinida
        //{
        //    get
        //    {
        //        if (this.AcaoPredefinida != AcoesPredefinidas.Nenhum)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //}

        public enum MouseButton
        {
            RIGHT = 1,
            LEFT = 2
        }

        //public enum AcoesPredefinidas
        //{
        //    Nenhum = 0,
        //    SelecionarERetornarTodoTextoDoCampo = 1
        //}
    }
}
