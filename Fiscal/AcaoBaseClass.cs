using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FiscalApp.Acao;

namespace FiscalApp
{
    public abstract class AcaoBaseClass
    {
        public int TempoEsperaAntesAcao { get; set; }
        public int TempoEsperaAposAcao { get; set; }
        public string Tag { get; set; }
        public AcoesPredefinidas AcaoPredefinida { get; set; }

        public abstract bool IsTecla { get; }
        public abstract void EnviarTecla();
        public abstract void Clicar();

        protected void EnviarTecla(string key)
        {
            AutoIt.AutoItX.Send(key);
        }

        protected void Clicar(int x, int y)
        {
            if (TempoEsperaAntesAcao > 0)
            {
                System.Threading.Thread.Sleep(TempoEsperaAntesAcao);
            }
            if (TempoEsperaAposAcao > 0)
            {
                MainForm.clickEditingControl(x, y, noWait: false, mouseSpeed: 1, waitTime: TempoEsperaAposAcao);
            }
            else
            {
                MainForm.clickEditingControl(x, y, noWait: true, mouseSpeed: 1);
            }
        }

        public bool IsAcaoPredefinida()
        {
            if (this.AcaoPredefinida != AcoesPredefinidas.Nenhum)
            {
                return true;
            }
            return false;
        }
    }
}
