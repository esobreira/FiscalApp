using System.Drawing;
using System.Windows.Forms;

namespace FiscalApp
{
    public class Acao : AcaoBaseClass
    {
        public Point Local { get; set; }
        public string Nome { get; set; } = "";
        public string Texto { get; set; } = "";
        public MouseButton BotaoMouse { get; set; } = MouseButton.LEFT;

        public Acao()
        {
            //this.AcaoPredefinida = AcoesPredefinidas.Nenhum;
        }

        //public Acao(AcoesPredefinidas acaoPredefinida) : this()
        //{
        //    this.AcaoPredefinida = acaoPredefinida;
        //}

        //public Acao(AcoesPredefinidas acaoPredefinida, ref string destinoVariavel) : this(acaoPredefinida)
        //{
        //    switch (acaoPredefinida)
        //    {
        //        case AcoesPredefinidas.SelecionarERetornarTodoTextoDoCampo:

        //            string retorno = Teclado.returnEntireTextSelected();
        //            destinoVariavel = retorno;

        //            break;

        //        default:
        //            break;
        //    }
        //}

        public Acao(int x, int y) : this()
        {
            Local = new Point(x, y);
        }

        public Acao(int x, int y, string Nome) : this(x, y)
        {
            this.Nome = Nome;
        }

        public Acao(int x, int y, string Nome, string Texto) : this(x, y, Nome)
        {
            this.Texto = Texto;
        }

        public Acao(Point local) : this(local.X, local.Y)
        {
            Local = local;
        }

        public Acao(Point local, string Nome) : this(local)
        {
            this.Nome = Nome;
        }

        public Acao(Point local, string Nome, string Texto) : this(local, Nome)
        {
            this.Texto = Texto;
        }

        public override void Clicar()
        {
            base.Clicar(this.Local.X, this.Local.Y, this.BotaoMouse);

            if (Texto.Length > 0)
            {
                AutoIt.AutoItX.Send(Texto);
            }
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
