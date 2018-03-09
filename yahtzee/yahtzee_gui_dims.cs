using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yahtzee
{
    class yahtzee_gui_dims
    {
        public control_dimension window;
        public control_dimension score_card;
        public control_dimension score_btn;
        public control_dimension roll_btn;
        public control_dimension roll_nmbr;
        public List<control_dimension> dice;
        public List<control_dimension> score_sels;
        public List<control_dimension> score_vals;
        public List<control_dimension> score_totals;
        public control_dimension menu;

        public yahtzee_gui_dims(int width, int height)
        {
            window = new control_dimension();
            score_card = new control_dimension();
            score_btn = new control_dimension();
            roll_btn = new control_dimension();
            dice = new List<control_dimension>();
            roll_nmbr = new control_dimension();
            score_sels = new List<control_dimension>();
            score_vals = new List<control_dimension>();
            score_totals = new List<control_dimension>();
            menu = new control_dimension();

            menu.point = new Point(0, 0);
            menu.size = new Size(width, 24);

            window.size = new Size(width, height);
            score_card.size = new Size(265, 554);
            score_card.point = new Point(12, (window.size.Height - score_card.size.Height - menu.size.Height) / 2 + menu.size.Height);

            score_btn.size = new Size(60, 30);
            roll_btn.size = new Size(60, 30);

            roll_btn.point = new Point(score_card.point.X + score_card.size.Width + (window.size.Width - (score_card.point.X + score_card.size.Width)) / 2 - 5*roll_btn.size.Width/4, window.size.Height * 8 / 9 + roll_btn.size.Height/2);
            score_btn.point = new Point(roll_btn.point.X + 3*roll_btn.size.Width/2, roll_btn.point.Y);

            for(int i = 0; i < 5; i++)
            {
                control_dimension d = new control_dimension();
                d.size = new Size(64, 64);
                d.point = new Point(score_card.point.X + score_card.size.Width + (window.size.Width - (score_card.point.X + score_card.size.Width)) / 2 - d.size.Width/2, window.size.Height * (i) / 7 + 3*d.size.Height/2);
                dice.Add(d);
            }

            roll_nmbr.size = new Size(80, 30);
            roll_nmbr.point = new Point(score_card.point.X + score_card.size.Width + (window.size.Width - (score_card.point.X + score_card.size.Width)) / 2 - roll_nmbr.size.Width / 2, score_card.point.Y - (score_card.point.Y - dice[0].point.Y)/2 - roll_nmbr.size.Height/2);

            for(int i = 0; i < 6; i++)
            {
                control_dimension chk = new control_dimension();
                chk.size = new Size(15, 14);
                chk.point = new Point(score_card.point.X + 13, 61 + score_card.point.Y + i * 25);
                score_sels.Add(chk);
            }

            for (int i = 0; i < 7; i++)
            {
                control_dimension chk = new control_dimension();
                chk.size = new Size(15, 14);
                chk.point = new Point(score_card.point.X + 13, 307 + score_card.point.Y + i * 25 - (i / 3));
                score_sels.Add(chk);
            }

            for(int i = 0; i < 6; i++)
            {
                control_dimension scr = new control_dimension();
                scr.size = new Size(49, 20);
                scr.point = new Point(score_card.point.X + 209, score_card.point.Y + 59 + i * 25 - i/2);
                score_vals.Add(scr);
            }

            for (int i = 0; i < 7; i++)
            {
                control_dimension scr = new control_dimension();
                scr.size = new Size(49, 20);
                scr.point = new Point(score_card.point.X + 209, score_card.point.Y + 305 + i * 25 - i / 2);
                score_vals.Add(scr);
            }

            for (int i = 0; i < 6; i++)
            {
                control_dimension scr = new control_dimension();
                scr.size = new Size(49, 20);
                score_totals.Add(scr);
            }

            score_totals[0].point = new Point(score_card.point.X + 209, score_card.point.Y + 207);
            score_totals[1].size = new Size(49, 14);
            score_totals[1].point = new Point(score_card.point.X + 209, score_card.point.Y + 231);
            score_totals[2].point = new Point(score_card.point.X + 209, score_card.point.Y + 250);
            score_totals[3].point = new Point(score_card.point.X + 209, score_card.point.Y + 476);
            score_totals[4].point = new Point(score_card.point.X + 209, score_card.point.Y + 501);
            score_totals[5].point = new Point(score_card.point.X + 209, score_card.point.Y + 525);
        }

    }
}
