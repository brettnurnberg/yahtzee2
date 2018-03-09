using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yahtzee
{
    class hs_data
    {
        public string filename { get; set; }
        public List<hs_entry> highscores { get; set; }
        public FileStream fs { get; set; }

        public hs_data()
        {
            filename = "hs";
            highscores = new List<hs_entry>();
            for(int i = 0; i < 10; i++)
            {
                hs_entry e = new hs_entry("", 0);
                highscores.Add(e);
            }
        }
    }
}
