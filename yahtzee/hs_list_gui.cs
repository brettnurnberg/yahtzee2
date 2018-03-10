using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yahtzee
{
    class hs_list_gui : Form
    {
        private System.ComponentModel.IContainer components = null;
        private Form owner;
        private List<Label> header;
        private List<Label> ranks;
        private List<Label> names;
        private List<Label> scores;
        private Button ok;
        private hs_data data;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public hs_list_gui(Form owner_, hs_data data_)
        {
            data = data_;
            owner = owner_;

            InitializeComponent();
        }

        public void run()
        {
            /* set label values */
            for(int i = 0; i < 10; i++)
            {
                if(data.highscores[i].score != 0)
                {
                    names[i].Text = data.highscores[i].name;
                    scores[i].Text = data.highscores[i].score.ToString();
                }
                else
                {
                    names[i].Text = string.Empty;
                    scores[i].Text = string.Empty;
                }
            }

            /* show dialog */
            this.ShowDialog(owner);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "High Scores";
            this.ClientSize = new Size(400, 500);
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            header = new List<Label>();
            ranks = new List<Label>();
            names = new List<Label>();
            scores = new List<Label>();

            for(int i = 0; i < 3; i++)
            {
                Label l = new Label();
                l.Font = new Font(l.Font.FontFamily, 12);
                l.TextAlign = ContentAlignment.MiddleLeft;
                header.Add(l);
                this.Controls.Add(l);
            }

            header[0].Size = new Size(60, 18);
            header[0].Location = new Point(40, this.Size.Height / 16);
            header[0].Text = "Rank";

            header[1].Size = new Size(150, 18);
            header[1].Location = new Point(15 + header[0].Location.X + header[0].Size.Width, this.Size.Height / 16);
            header[1].Text = "Name";

            header[2].Size = new Size(60, 18);
            header[2].Location = new Point(15 + header[1].Location.X + header[1].Size.Width, this.Size.Height / 16);
            header[2].Text = "Score";

            for(int i = 0; i < 10; i++)
            {
                Label r = new Label();
                Label n = new Label();
                Label s = new Label();

                r.Font = n.Font = s.Font = new Font(r.Font.FontFamily, 10);
                r.TextAlign = n.TextAlign = s.TextAlign = ContentAlignment.TopLeft;

                r.Text = (i + 1).ToString();
                n.Text = "";
                s.Text = "";

                r.Size = header[0].Size;
                n.Size = header[1].Size;
                s.Size = header[2].Size;

                r.Location = new Point(header[0].Location.X + 3, (i + 2) * this.Size.Height / 16);
                n.Location = new Point(header[1].Location.X, (i + 2) * this.Size.Height / 16);
                s.Location = new Point(header[2].Location.X, (i + 2) * this.Size.Height / 16);

                ranks.Add(r);
                scores.Add(s);
                names.Add(n);
                this.Controls.Add(r);
                this.Controls.Add(s);
                this.Controls.Add(n);
            }

            ok = new Button();
            ok.Size = new Size(60, 30);
            ok.Location = new Point((this.Size.Width - ok.Size.Width) / 2, 13 * this.Size.Height / 16);
            ok.BackColor = Color.LightGray;
            ok.FlatStyle = FlatStyle.Flat;
            ok.FlatAppearance.BorderSize = 0;
            ok.Text = "OK";
            ok.Font = new Font(ok.Font.FontFamily, 12);
            ok.Click += new EventHandler(exit_eh);
            this.Controls.Add(ok);

        }

        private void exit_eh(Object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
