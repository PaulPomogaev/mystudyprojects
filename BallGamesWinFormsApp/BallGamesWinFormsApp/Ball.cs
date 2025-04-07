using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallGamesWinFormsApp
{
    public class Ball
    {
        protected MainForm form;
        protected int x = 150;
        protected int y = 150;
        protected int size = 70;
        public Ball(MainForm form)
        {
            this.form = form;
        }

        public void Show()
        {
            var graphics = form.CreateGraphics();
            var brush = Brushes.Aqua;
            var rectangle = new Rectangle(x, y, size, size);
            graphics.FillEllipse(brush, rectangle);
        }

        public void Go()
        {
            x += 10;
            y += 15;
        }

        public void Clear()
        {
            var graphics = form.CreateGraphics();
            var brush = Brushes.Gray;
            var rectangle = new Rectangle(x, y, size, size);
            graphics.FillEllipse(brush, rectangle);
        }
    }
}
