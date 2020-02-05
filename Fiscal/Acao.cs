using System.Drawing;

namespace FiscalApp
{
    public class Acao : AcaoBaseClass
    {
        public Point Local { get; set; }
        public string Nome { get; set; }

        public Acao()
        {
            this.AcaoPredefinida = AcoesPredefinidas.Nenhum;
        }

        public Acao(AcoesPredefinidas predefinida) : this()
        {
            this.AcaoPredefinida = predefinida;
        }

        public Acao(int x, int y) : this()
        {
            Local = new Point(x, y);
        }

        public Acao(int x, int y, string Nome) : this(x, y)
        {
            this.Nome = Nome;
        }

        public Acao(Point local) : this(local.X, local.Y)
        {
            Local = local;
        }

        public Acao(Point local, string Nome) : this(local)
        {
            this.Nome = Nome;
        }

        public override void Clicar()
        {
            base.Clicar(this.Local.X, this.Local.Y);
        }

        public override void EnviarTecla()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsTecla
        {
            get
            {
                return false;
            }
        }
    }
}
