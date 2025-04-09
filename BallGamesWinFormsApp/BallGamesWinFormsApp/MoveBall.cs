using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;


namespace BallGamesWinFormsApp
{
    public class MoveBall : RandomPointBall
    {
        private Timer timer;

        public MoveBall(MainForm form) : base(form)
        {
            timer = new Timer();
            timer.Interval = 20;
            timer.Tick += Timer_Tick;

            vx = random.Next(-5, 6);
            if (vx == 0) vx = 1;
            vy = random.Next(-5, 6);
            if (vy == 0) vy = 1;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Move();
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            //timer.Stop(); // если использовать его, то выходит только одно нажатие, больше запустить шары не получится
            timer.Enabled = !timer.Enabled; // при использовании этого инструмента можно несколько раз останавливать и запускать, что удобнее
        }

        public bool IsCaught()
        {
            return x >= 0 && y >= 0 && x + size <= form.ClientSize.Width && y + size <= form.ClientSize.Height;
        }
    }
}
