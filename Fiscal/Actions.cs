using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalApp
{
    public class Actions 
    {
        public List<AcaoBaseClass> Lista { get; set; } = new List<AcaoBaseClass>();

        public AcaoBaseClass this[AcaoBaseClass acao]
        {
            get
            {
                return this.Lista.Single(a => a == acao);
            }
        }

        public Actions()
        {

        }

        public Actions(List<AcaoBaseClass> acoes)
        {
            this.Lista = acoes;
        }

        public void Adicionar(AcaoBaseClass acao)
        {
            this.Lista.Add(acao);
        }

        public void Adicionar(List<AcaoBaseClass> actions)
        {
            this.Lista = actions;
        }

    }
}
