using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yahtzee
{
    class end_game_gui : Form
    {
        private System.ComponentModel.IContainer components = null;
        private Button ok;
        private Button new_game;
        private Label score_text;
        private Form owner;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public end_game_gui(Form owner_)
        {
            owner = owner_;
            InitializeComponent();
        }

        public void run(int score)
        {
            score_text.Text = "Score: " + score;
            this.ShowDialog(owner);
        }

        private void on_ok_click(Object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Game Over";
            this.ClientSize = new Size(250, 120);
            this.Location = new Point((owner.Location.X + owner.Size.Width - this.Size.Width) / 2, (owner.Location.Y + owner.Size.Height - this.Size.Height) / 2);
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            ok = new Button();
            ok.Size = new Size(60, 30);
            ok.Location = new Point(this.ClientSize.Width / 3 - ok.Width / 2, 2*this.ClientSize.Height / 3);
            ok.BackColor = Color.LightGray;
            ok.FlatStyle = FlatStyle.Flat;
            ok.FlatAppearance.BorderSize = 0;
            ok.Text = "OK";
            ok.Font = new Font(ok.Font.FontFamily, 10);
            ok.Click += new EventHandler(on_ok_click);
            this.Controls.Add(ok);

            new_game = new Button();
            new_game.Size = new Size(100, 30);
            new_game.Location = new Point(2*this.ClientSize.Width / 3 - new_game.Width / 2, 2 * this.ClientSize.Height / 3);
            new_game.BackColor = Color.LightGray;
            new_game.FlatStyle = FlatStyle.Flat;
            new_game.FlatAppearance.BorderSize = 0;
            new_game.Text = "New Game";
            new_game.Font = new Font(new_game.Font.FontFamily, 10);
            new_game.Click += new EventHandler(on_ok_click);
            this.Controls.Add(new_game);

            score_text = new Label();
            score_text.Font = new Font(score_text.Font.FontFamily, 12);
            score_text.Location = new Point(this.ClientSize.Width / 2 - score_text.Width / 2, this.ClientSize.Height / 4 - score_text.Size.Height/2);
            score_text.Size = new Size(100, 30);
            score_text.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(score_text);

        }
    }
}
