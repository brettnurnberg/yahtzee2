using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yahtzee
{
    class hs_entry
    {
        public string name { get; set; }
        public int score { get; set; }

        public hs_entry(string name_, int score_)
        {
            name = name_;
            score = score_;
        }
    }
}
