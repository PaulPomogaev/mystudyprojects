using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace BallGamesWinFormsLibrary
{
    public class MoveBall : RandomPointBall
    {
        
        public MoveBall(Form form) : base(form)
        {
            vx = random.Next(-5, 6);
            if (vx == 0)
            {
                vx = 1;
            }

            vy = random.Next(-5, 6);
            if (vy == 0)
            {
                vy = 1;
            }
        }
                      
    }
}
