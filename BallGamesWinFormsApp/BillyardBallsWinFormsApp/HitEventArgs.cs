using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillyardBallsWinFormsApp
{
    public class HitEventArgs
    {
        public Side Side;

        public  HitEventArgs(Side side)
        {
            Side = side;
        }
    }
}
