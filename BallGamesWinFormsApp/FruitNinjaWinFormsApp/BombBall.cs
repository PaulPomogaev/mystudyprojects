using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitNinjaWinFormsApp
{
    public class BombBall : FruitBall
    {
        public BombBall(Form form, Brush brush) : base(form, brush)
        {

        }

        public BombBall(Form form) : base(form, Brushes.Black)
        {

        }

    }
}
