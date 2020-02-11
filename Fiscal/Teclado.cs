using AutoIt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiscalApp
{
    public class Teclado
    {

        /// <summary>
        /// Seleciona Todo o Texto do Controle Atualmente com Foco e não faz mais nada, apenas Seleciona.
        /// </summary>
        public static void selecEntireTextFromControl()
        {
            AutoItX.Send("{HOME}");
            AutoItX.Send("{SHIFTDOWN}");
            AutoItX.Send("+{END}");
            AutoItX.Send("{SHIFTUP}");
        }

        /// <summary>
        /// Envia a tecla DELETE.
        /// </summary>
        public static void clearTextSelected()
        {
            AutoItX.Send("{DELETE}");
        }

        /// <summary>
        /// Seleciona Todo o Texto do Controle Atualmente com Foco e o *APAGA*.
        /// </summary>
        public static void selectTextAndClear()
        {
            AutoItX.Send("{HOME}");
            AutoItX.Send("{SHIFTDOWN}");
            AutoItX.Send("+{END}");
            AutoItX.Send("{SHIFTUP}");
            AutoItX.Send("{DELETE}");
        }

        /// <summary>
        /// Vai ao início do campo Selecionado na Tela, Seleciona Tudo e Copia pra Clipboard.
        /// </summary>
        /// <returns></returns>
        public static void sendToClipboardEntireTextSelected()
        {
            selecEntireTextFromControl();
            AutoItX.Send("^c");
        }

    }
}
