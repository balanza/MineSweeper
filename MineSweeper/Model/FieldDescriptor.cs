using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Model
{
    class FieldDescriptor
    {
        public Tuple<int, int> Size { get; private set; }
        public char[,] Cells { get; private set; }

        public FieldDescriptor(int numberOfRows, int numberOfColumns, char[,] cells) {
            this.Size = new Tuple<int, int>(numberOfRows, numberOfColumns);
            this.Cells = cells;  
        }
    }
}
