using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalApp
{
    public class NotaFiscal
    {
        public string Numero { get; set; }
        public string ChaveAcesso { get; set; }
        public string DataEmissao { get; set; }
        public int TipoEmissao { get; set; }

        public NotaFiscal()
        {

        }
    }
}
