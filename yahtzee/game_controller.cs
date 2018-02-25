using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yahtzee
{
    class game_controller
    {
        private IntGetter get_sel_cat;
        private BoolListGetter get_locked_dice;
        private Updater update;
        private game_data data;

        public game_controller(game_data d)
        {
            data = d;
        }

        public void new_game()
        {
            data.reset();
            update();
        }

        public void score_roll(Object sender, EventArgs e)
        {
            int cat = get_sel_cat();
            if(cat == -1)
            {
                return;
            }
            data.scores[cat].value = calc_score(cat);
            data.scores[cat].used = true;
            foreach(die d in data.dice)
            {
                d.locked = false;
            }
            data.calculate_totals();
            data.roll_nmbr = 0;
            update();
        }

        public void roll_dice(Object sender, EventArgs e)
        {
            data.set_locks(get_locked_dice());
            data.roll_dice();
            update();
        }

        public void register_sel_cat_getter(IntGetter del)
        {
            get_sel_cat = del;
        }

        public void register_lock_dice_getter(BoolListGetter del)
        {
            get_locked_dice = del;
        }

        public void register_updater(Updater del)
        {
            update = del;
        }

        private int calc_score(int cat)
        {
            int[] num = new int[7];

            int score = 0;
            int dice_total = 0;

            for(int i = 0; i < 7; i++)
            {
                num[i] = 0;
            }

            foreach(die d in data.dice)
            {
                num[d.value]++;
                dice_total += d.value;
            }

            switch(cat)
            {
                case (int)score_cat.ACES:
                case (int)score_cat.TWOS:
                case (int)score_cat.THREES:
                case (int)score_cat.FOURS:
                case (int)score_cat.FIVES:
                case (int)score_cat.SIXES:
                    score = num[cat+1] * (cat+1);
                    break;
                case (int)score_cat.THREE_OF_A_KIND:
                    for(int i = 1; i < 7; i++)
                    {
                        if(num[i] >=3)
                        {
                            score = dice_total;
                        }
                    }
                    break;
                case (int)score_cat.FOUR_OF_A_KIND:
                    for (int i = 1; i < 7; i++)
                    {
                        if (num[i] >= 4)
                        {
                            score = dice_total;
                        }
                    }
                    break;
                case (int)score_cat.FULL_HOUSE:
                    for (int i = 1; i < 7; i++)
                    {
                        if (num[i] == 3)
                        {
                            for(int j = 1; j < 7; j++)
                            {
                                if(num[j] == 2)
                                {
                                    score = 25;
                                }
                            }
                        }
                    }
                    break;
                case (int)score_cat.SMALL_STRAIGHT:
                    if(num[3] >= 1 && num[4] >= 1
                  && ((num[2] >= 1 && (num[1] >= 1 || num[5] >= 1))
                  ||  (num[5] >= 1 && num[6] >= 1)))
                    {
                        score = 30;
                    }
                    break;
                case (int)score_cat.LARGE_STRAIGHT:
                    if ((num[2] >= 1 && num[3] >= 1 && num[4] >= 1 && num[5] >= 1)
                     && (num[1] >= 1 || num[6] >= 1))
                    {
                        score = 40;
                    }
                    break;
                case (int)score_cat.YAHTZEE:
                    for (int i = 1; i < 7; i++)
                    {
                        if (num[i] == 5)
                        {
                            score = 50;
                        }
                    }
                    break;
                case (int)score_cat.CHANCE:
                    score = dice_total;
                    break;

            }

            return score;
        }





    }
}
