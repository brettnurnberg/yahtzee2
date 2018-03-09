using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yahtzee
{
    public delegate void InputHandler(Object sender, EventArgs e);
    public delegate int IntGetter();
    public delegate void IntSetter(int d);
    public delegate List<bool> BoolListGetter();
    public delegate void Updater();
    public delegate void TextIntSetter(string s, int d);
    public delegate bool IntBool(int d);

    static class Program
    {
        [STAThread]
        static void Main()
        {
            /* Notes for high score handling
             *   Create a new controller for the hs forms
             *   Let this controller control the end game forms and hs list
             *   Give the game controller a handle to running the end game form
             *   Give the yahtzee gui a handle to the hs list form  */

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /* create models */
            game_data gd = new game_data();
            hs_data hsd = new hs_data();

            /* create controllers */
            game_controller c = new game_controller(gd);
            hs_controller hsc = new hs_controller(hsd);

            /* create views */
            yahtzee_gui gui = new yahtzee_gui(c.roll_dice, c.score_roll, c.new_game, gd);
            enter_hs_gui entry_gui = new enter_hs_gui(hsd, hsc.add_entry, gui);
            end_game_gui end_gui = new end_game_gui(gui);

            /* for viewing highscores, we will simply need to create new gui
             * with a list of 10 labels to show the scores. The gui will have a
             * reference to the hsd and will have a handler (run) that will be
             * given to the yahtzee gui so it can start the hs gui from the toolbar. */

            /* register delegates */
            c.register_sel_cat_getter(gui.get_sel_cat);
            c.register_lock_dice_getter(gui.get_lock_dice);
            c.register_updater(gui.update);
            c.register_end_game(end_gui.run);
            c.register_hs_getter(hsc.is_high_score);
            c.register_hs_entry(entry_gui.run);

            /* run application */
            gui.run();

        }
    }
}
