using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Model
{
    abstract class AbstractCell
    {
        public int Row { get;  set; }
        public int Column { get;  set; }

        public AbstractCell() { }
        
    }
}
