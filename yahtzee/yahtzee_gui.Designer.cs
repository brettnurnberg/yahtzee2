﻿using System;
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
        private yahtzee_gui_dims dims;
        private Button score;
        private Button roll;
        private List<PictureBox> dice;
        private PictureBox score_card;
        private Label roll_nmbr;
        private List<CheckBox> score_sels;
        private List<Label> score_vals;
        private List<Label> score_totals;
        private MenuStrip menu;
        private ToolStripMenuItem file_menu;
        private ToolStripMenuItem new_game_item;
        private ToolStripMenuItem hs_list_item;
        private ToolStripMenuItem exit_item;

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
            dims = new yahtzee_gui_dims(500, 600);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Yahtzee";
            this.ClientSize = dims.window.size;
            this.BackColor = Color.FromName("SeaGreen");
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Icon = new Icon("res/die_3d.ico");

            new_game_item = new ToolStripMenuItem();
            new_game_item.Text = "New Game";
            new_game_item.Click += new EventHandler(new_game);

            hs_list_item = new ToolStripMenuItem();
            hs_list_item.Text = "High Scores";
            hs_list_item.Click += new EventHandler(show_hs_handler);

            exit_item = new ToolStripMenuItem();
            exit_item.Text = "Exit";
            exit_item.Click += new EventHandler(exit_game);

            file_menu = new ToolStripMenuItem();
            file_menu.Text = "File";
            file_menu.DropDownItems.Add(new_game_item);
            file_menu.DropDownItems.Add(hs_list_item);
            file_menu.DropDownItems.Add(exit_item);

            menu = new MenuStrip();
            menu.Location = dims.menu.point;
            menu.Size = dims.menu.size;
            menu.Items.Add(file_menu);
            this.Controls.Add(menu);

            this.MainMenuStrip = menu;

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

