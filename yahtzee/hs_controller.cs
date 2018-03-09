using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yahtzee
{
    class hs_controller
    {
        private hs_data data;

        public hs_controller(hs_data data_)
        {
            data = data_;
            read_hs_file();
        }

        public bool is_high_score(int score)
        {
            return score > data.highscores[9].score;
        }

        public void add_entry(string name, int score)
        {
            hs_entry e = new hs_entry(name, score);
            int idx = 9;
            while(idx >= 0 && score > data.highscores[idx].score)
            {
                idx--;
            }
            idx++;

            data.highscores.Insert(idx, e);
            data.highscores.RemoveAt(10);
            write_hs_file();
        }

        private void read_hs_file()
        {
            if(File.Exists(data.filename))
            {
                int idx = 0;
                foreach(string line in File.ReadLines(data.filename))
                {
                    if(line != string.Empty)
                    {
                        string[] record = line.Split('\u001f');
                        data.highscores[idx].name = record[0];
                        data.highscores[idx].score = Int32.Parse(record[1]);
                        idx++;
                    }
                }
            }
            else
            {
                File.Create(data.filename);
            }
        }

        private void write_hs_file()
        {
            using (StreamWriter sw = File.CreateText(data.filename))
            {
                foreach(hs_entry e in data.highscores)
                {
                    sw.WriteLine(e.name + '\u001f' + e.score);
                }
            }
        }


    }

}
