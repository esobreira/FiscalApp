using AutoIt;

namespace FiscalApp
{
    public class Tecla : AcaoBaseClass
    {
        public override bool IsTecla
        {
            get
            {
                return true;
            }
        }

        public string Key { get; set; }

        public Tecla()
        {
            //this.AcaoPredefinida = AcoesPredefinidas.Nenhum;
        }

        public Tecla(string Tecla)
        {
            Key = Tecla;
        }

        public override void EnviarTecla()
        {
            base.EnviarTecla(this.Key);
        }

        public override void Clicar()
        {
            throw new System.NotImplementedException();
        }
    }
}
