using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yahtzee
{
    public delegate void InputHandler(Object sender, EventArgs e);
    public delegate int IntGetter();
    public delegate List<bool> BoolListGetter();
    public delegate void Updater();

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            game_data d = new game_data();

            game_controller c = new game_controller(d);
            yahtzee_gui gui = new yahtzee_gui(c.roll_dice, c.score_roll, c.new_game, d);

            c.register_sel_cat_getter(gui.get_sel_cat);
            c.register_lock_dice_getter(gui.get_lock_dice);
            c.register_updater(gui.update);

            c.new_game(null, null);

            Application.Run(gui);
        }
    }
}
