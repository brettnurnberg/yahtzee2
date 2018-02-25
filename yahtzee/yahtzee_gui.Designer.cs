using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yahtzee
{
    partial class yahtzee_gui
    {
        private gui_dimensions dims;
        private Button score;
        private Button roll;
        private List<PictureBox> dice;
        private PictureBox score_card;
        private Label roll_nmbr;
        private List<CheckBox> score_sels;
        private List<Label> score_vals;
        private List<Label> score_totals;

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dims = new gui_dimensions(500, 600);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Yahtzee";
            this.ClientSize = dims.window.size;
            this.BackColor = Color.FromName("SeaGreen");
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            score = new Button();
            score.Size = dims.score_btn.size;
            score.Location = dims.score_btn.point;
            score.BackColor = Color.LightGray;
            score.FlatStyle = FlatStyle.Flat;
            score.FlatAppearance.BorderSize = 0;
            score.Text = "Score";
            score.Font = new Font(score.Font.FontFamily, 12);
            score.Click += new EventHandler(score_roll);
            this.Controls.Add(score);

            roll = new Button();
            roll.Size = dims.roll_btn.size;
            roll.Location = dims.roll_btn.point;
            roll.BackColor = Color.LightGray;
            roll.FlatStyle = FlatStyle.Flat;
            roll.FlatAppearance.BorderSize = 0;
            roll.Text = "Roll";
            roll.Font = new Font(roll.Font.FontFamily, 12);
            roll.Click += new EventHandler(roll_dice);
            this.Controls.Add(roll);

            

            dice = new List<PictureBox>();
            foreach(control_dimension d in dims.dice)
            {
                PictureBox pic = new PictureBox();
                pic.Size = d.size;
                pic.Location = d.point;
                pic.ImageLocation = "res/1_pip.png";
                pic.Click += new EventHandler(on_die_click);
                dice.Add(pic);
                this.Controls.Add(pic);
            }

            roll_nmbr = new Label();
            roll_nmbr.Font = new Font(roll_nmbr.Font.FontFamily, 16);
            roll_nmbr.Location = dims.roll_nmbr.point;
            roll_nmbr.Size = dims.roll_nmbr.size;
            roll_nmbr.Text = "Roll 1";
            roll_nmbr.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(roll_nmbr);

            score_sels = new List<CheckBox>();
            for(int i = 0; i < 13; i++ )
            {
                CheckBox b = new CheckBox();
                b.Size = dims.score_sels[i].size;
                b.Location = dims.score_sels[i].point;
                b.AutoSize = true;
                b.BackColor = SystemColors.Window;
                b.UseVisualStyleBackColor = false;
                b.BringToFront();
                b.Click += new EventHandler(on_box_click);
                score_sels.Add(b);
                this.Controls.Add(b);
            }

            score_vals = new List<Label>();
            for(int i = 0; i < 13; i++)
            {
                Label s = new Label();
                s.Size = dims.score_vals[i].size;
                s.Location = dims.score_vals[i].point;
                s.Font = new Font(s.Font.FontFamily, 9);
                s.Text = "0";
                s.TextAlign = ContentAlignment.MiddleCenter;
                s.BackColor = Color.White;
                score_vals.Add(s);
                this.Controls.Add(s);
            }

            score_totals = new List<Label>();
            for(int i = 0; i < 6; i++)
            {
                Label s = new Label();
                s.Size = dims.score_totals[i].size;
                s.Location = dims.score_totals[i].point;
                s.Font = new Font(s.Font.FontFamily, 9);
                s.Text = "0";
                s.TextAlign = ContentAlignment.MiddleCenter;
                s.BackColor = Color.White;
                score_totals.Add(s);
                this.Controls.Add(s);
            }

            score_card = new PictureBox();
            score_card.Size = dims.score_card.size;
            score_card.Location = dims.score_card.point;
            score_card.SendToBack();
            score_card.ImageLocation = "res/score_card.jpg";
            this.Controls.Add(score_card);

        }

    }
}

