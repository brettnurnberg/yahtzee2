using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yahtzee
{
    public class game_data
    {
        public int roll_nmbr { get; set; }
        public List<die> dice { get; set; }
        public List<score> scores { get; set; }
        public int lower_total { get; set; }
        public int upper_total { get; set; }
        public int total { get; set; }
        public int bonus { get; set; }

        public game_data()
        {
            dice = new List<die>();
            for(int i = 0; i < 5; i++)
            {
                die d = new die();
                dice.Add(d);
            }
            scores = new List<score>();
            for (int i = 0; i < 13; i++)
            {
                score s = new score();
                scores.Add(s);
            }
            reset();
        }

        public void reset()
        {
            foreach(die d in dice)
            {
                d.reset();
            }
            foreach(score s in scores)
            {
                s.reset();
            }
            lower_total = 0;
            upper_total = 0;
            bonus = 0;
            total = 0;
            roll_nmbr = 0;
        }

        public void roll_dice()
        {
            foreach(die d in dice)
            {
                d.roll();
            }
            roll_nmbr++;
        }

        public void calculate_totals()
        {
            lower_total = 0;
            upper_total = 0;
            bonus = 0;
            total = 0;
            for(int i = 0; i < 6; i++)
            {
                upper_total += scores[i].value;
            }
            if(upper_total >= 63)
            {
                bonus = 35;
            }
            for(int i = 6; i < 13; i++)
            {
                lower_total += scores[i].value;
            }
            total = upper_total + bonus + lower_total;
        }

        public void set_locks(List<bool> locks)
        {
            for(int i = 0; i < 5; i++)
            {
                if(locks[i])
                {
                    dice[i].set_lock();
                }
                else
                {
                    dice[i].unlock();
                }
            }
        }

    }
}
