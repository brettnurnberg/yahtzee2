using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yahtzee
{
    class enter_hs_gui : Form
    {
        private System.ComponentModel.IContainer components = null;
        private Button ok;
        private Label name;
        private Label prompt;
        private TextBox entry;
        private hs_data data;
        private TextIntSetter add_entry;
        private int score;
        private Form owner;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public enter_hs_gui(hs_data data_, TextIntSetter add_entry_, Form owner_)
        {
            this.data = data_;
            this.add_entry = add_entry_;
            this.owner = owner_;
            InitializeComponent();
        }

        public void run(int score_)
        {
            score = score_;
            this.ShowDialog(owner);
        }

        private void on_ok_click(Object sender, EventArgs e)
        {
            add_entry(entry.Text, score);
            this.Close();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "High Score";
            this.ClientSize = new Size(250, 150);
            this.Location = new Point((owner.Location.X + owner.Size.Width - this.Size.Width) / 2, (owner.Location.Y + owner.Size.Height - this.Size.Height) / 2);
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            ok = new Button();
            ok.Size = new Size(60, 30);
            ok.Location = new Point(this.ClientSize.Width / 2 - ok.Size.Width / 2, 3 * this.ClientSize.Height / 4 - ok.Height/2);
            ok.BackColor = Color.LightGray;
            ok.FlatStyle = FlatStyle.Flat;
            ok.FlatAppearance.BorderSize = 0;
            ok.Text = "OK";
            ok.Font = new Font(ok.Font.FontFamily, 11);
            ok.Click += new EventHandler(on_ok_click);
            this.Controls.Add(ok);

            prompt = new Label();
            prompt.Font = new Font(prompt.Font.FontFamily, 11);
            prompt.Size = new Size(120, 30);
            prompt.Location = new Point(this.ClientSize.Width / 2 - prompt.Size.Width / 2, this.ClientSize.Height / 4 - 3*prompt.Size.Height/4);
            prompt.Text = "New High Score!";
            prompt.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(prompt);

            name = new Label();
            name.Font = new Font(prompt.Font.FontFamily, 11);
            name.Location = new Point(15, this.ClientSize.Height / 2 - name.Size.Height / 2 - 9);
            name.Size = new Size(100, 30);
            name.Text = "Enter Name: ";
            name.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(name);

            entry = new TextBox();
            entry.Size = new Size(110, 15);
            entry.Location = new Point(name.Location.X + name.Size.Width, this.ClientSize.Height / 2 - entry.Height / 2 - 4);
            this.Controls.Add(entry);

        }
    }
}
