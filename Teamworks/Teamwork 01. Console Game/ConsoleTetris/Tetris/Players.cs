using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Players
    {
        public string Name { get; set; }
        public long Score { get;  set; }
        public string Time { get; set; }
         
            public Players(string name, long score,string time)
            {
                 Name = name;
                 Score = score;
                 Time = time;
            }    

    }
}
