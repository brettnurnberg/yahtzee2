using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yahtzee
{
    public class score
    {
        public int value { get; set; }
        public bool used { get; set; }

        public score()
        {
            reset();
        }

        public void reset()
        {
            value = 0;
            used = false;
        }
    }
}
