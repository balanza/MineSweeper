using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Model
{
    class HintCell : AbstractCell
    {
        public int AdjacentMinesCount { get; set; } = 0;

        public HintCell() : base() { }


    }
}
