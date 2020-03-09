using AutoIt;
using System.Drawing;

namespace FiscalApp
{
    public class Semaforo
    {
        public System.Drawing.Color Cor { get; set; }
        public bool SemaforoVerde { get; set; }
        public bool SemaforoAmarelo { get; set; }

        public void VerificaSemaforo()
        {
            // verifica se o semáforo está verde.
            MainForm.clickEditingControl(534, 24);
            Point pos = AutoItX.MouseGetPos();
            this.Cor = GetColorAt(pos.X, pos.Y);
            this.SemaforoVerde = this.Cor.Name.Equals("ff00ff00");
            // "{Name=ff00ff00, ARGB=(255, 0, 255, 0)}" -- VERDE

            // verifica se o semáforo está amarelo.
            MainForm.clickEditingControl(523, 24);
            pos = AutoItX.MouseGetPos();
            this.Cor = GetColorAt(pos.X, pos.Y);
            this.SemaforoAmarelo = this.Cor.Name.Equals("ffffff00");
            //"{Name=ffffff00, ARGB=(255, 255, 255, 0)}"
        }

        private static Color GetColorAt(int x, int y)
        {
            Bitmap bmp = new Bitmap(1, 1);
            Rectangle bounds = new Rectangle(x, y, 1, 1);
            using (Graphics g = Graphics.FromImage(bmp))
                g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
            return bmp.GetPixel(0, 0);
        }

    }
}
