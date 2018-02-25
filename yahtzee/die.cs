using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yahtzee
{
    public class die
    {
        public int value { get; set; }
        public bool locked { get; set; }
        private static Random r;

        public die()
        {
            r = new Random();
            value = 0;
            locked = false;
        }

        public void roll()
        {
            if(!locked)
            {
                value = r.Next(1, 7);
            }
        }

        public void reset()
        {
            value = 1;
            unlock();
        }

        public void set_lock()
        {
            locked = true;
        }

        public void unlock()
        {
            locked = false;
        }

    }
}
