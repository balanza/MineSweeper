using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Model
{
    /// <summary>
    /// Data structures for a Field entity
    /// </summary>
    class Field 
    {
        public AbstractCell[,] Cells { get; set; }


        public Field() { }

    }
}
