using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Helpers
{
    /// <summary>
    /// Factory class for a AbstractCell entity.
    /// </summary>
    class CellFactory
    {
        /// <summary>
        /// Creates a AbstractCell entity. The type of the entity is inferred from the cellInput provided
        /// </summary>
        /// <param name="row">0-based index of the row the cell belongs to</param>
        /// <param name="column">>0-based index of the column the cell belongs to</param>
        /// <param name="cellInput">char provided as input for the cell</param>
        /// <returns></returns>
        public Model.AbstractCell CreateCell(int row, int column, char cellInput)
        {
            if (isInputMineCell(cellInput)) return CreateMineCell(row, column);
            else if (isInputEmptyCell(cellInput)) return CreateHintCell(row, column, 0);
            else throw new Exception("Invalid cell format: " + cellInput);
        }

        private static Model.MineCell CreateMineCell(int row, int column) {
            return new Model.MineCell() { Row = row, Column = column};
        }

        private static Model.HintCell CreateHintCell(int row, int column, int adjacentMinesCount)
        {
            return new Model.HintCell() { Row = row, Column = column, AdjacentMinesCount= adjacentMinesCount };
        }

   
        private static bool isInputMineCell(char cellInput)
        {
            return cellInput == '*';
        }

        private static bool isInputEmptyCell(char cellInput)
        {
            return cellInput == '.';
        }

    }
}
