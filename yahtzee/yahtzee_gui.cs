using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yahtzee
{
    public partial class yahtzee_gui : Form
    {
        private InputHandler score_roll;
        private InputHandler roll_dice;
        private InputHandler new_game;
        private game_data data;

        public yahtzee_gui(InputHandler roll_dice_, InputHandler score_roll_, InputHandler new_game_, game_data data_)
        {
            roll_dice = roll_dice_;
            score_roll = score_roll_;
            new_game = new_game_;
            data = data_;

            InitializeComponent();
        }

        public void run()
        {
            new_game(null, null);
            Application.Run(this);
        }

        public void update()
        {
            /* update roll number */
            if(data.roll_nmbr != 0)
            {
                roll_nmbr.Text = String.Format("Roll {0}", data.roll_nmbr);
            }
            else
            {
                roll_nmbr.Text = "";
            }

            /* update button accessibility */
            if(data.roll_nmbr == 0)
            {
                score.Enabled = false;
            }
            else
            {
                score.Enabled = true;
            }

            if(data.roll_nmbr == 3 || data.is_game_over)
            {
                roll.Enabled = false;
            }
            else
            {
                roll.Enabled = true;
            }

            /* update check boxes */
            int i = 0;
            foreach(CheckBox b in score_sels)
            {
                b.Checked = false;
                if (data.scores[i].used)
                {
                    b.Enabled = false;
                }
                else
                {
                    b.Enabled = true;
                }
                i++;
            }

            /* update all scores */
            i = 0;
            foreach(Label l in score_vals)
            {
                l.Text = data.scores[i].value.ToString();
                i++;
            }

            score_totals[0].Text = data.upper_total.ToString();
            score_totals[1].Text = data.bonus.ToString();
            score_totals[2].Text = (data.upper_total + data.bonus).ToString();
            score_totals[3].Text = data.lower_total.ToString();
            score_totals[4].Text = (data.upper_total + data.bonus).ToString();
            score_totals[5].Text = data.total.ToString();

            /* update dice images */
            i = 0;
            foreach(PictureBox p in dice)
            {
                string s = "res/" + data.dice[i].value + "_pip";
                if(data.dice[i].locked)
                {
                    s += "_sel";
                }
                s += ".png";
                p.ImageLocation = s;
                i++;
                if (data.roll_nmbr == 0)
                {
                    p.Enabled = false;
                }
                else
                {
                    p.Enabled = true;
                }
            }
        }

        public int get_sel_cat()
        {
            foreach(CheckBox c in score_sels)
            {
                if(c.Checked)
                {
                    return score_sels.IndexOf(c);
                }
            }
            return -1;
        }

        public List<bool> get_lock_dice()
        {
            List<bool> locked_dice = new List<bool>();
            for(int i = 0; i < 5; i++)
            {
                bool locked = false;
                if(dice[i].ImageLocation.Contains("sel"))
                {
                    locked = true;
                }
                locked_dice.Add(locked);
            }

            return locked_dice;
        }

        private void uncheck_boxes()
        {
            foreach(CheckBox b in score_sels)
            {
                b.Checked = false;
            }
        }

        private void on_box_click(Object sender, EventArgs e)
        {
            CheckBox b = (CheckBox)sender;
            uncheck_boxes();
            int idx = score_sels.FindIndex(u => u == b);
            if(data.roll_nmbr != 0)
            {
                score_sels[idx].Checked = true;
            }
        }

        private void on_die_click(Object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            int idx = dice.FindIndex(u => u == p);
            if(p.ImageLocation.Contains("sel"))
            {
                p.ImageLocation = String.Format("res/{0}_pip.png", data.dice[idx].value);
            }
            else
            {
                p.ImageLocation = String.Format("res/{0}_pip_sel.png", data.dice[idx].value);
            }
        }

        private void exit_game(Object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
