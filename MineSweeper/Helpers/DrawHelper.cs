using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Helpers
{
    /// <summary>
    /// Handles the generation of the output depending on which object has to be draw 
    /// </summary>
    class DrawHelper
    {
        /// <summary>
        /// Draws a graphic representation of a Field entity
        /// </summary>
        /// <param name="field">the Field entity to be drawn</param>
        /// <returns>the representation of the provided Field entity</returns>
        public static string Draw(Model.Field field)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < field.Cells.GetLength(0); i++)
            {
                for (var j = 0; j < field.Cells.GetLength(0); j++)
                {
                    var cell = field.Cells[i, j];
                    sb.Append(Draw(cell));
                }
                sb.Append("\n");
            }

            return sb.ToString();
        }

        private static string Draw(Model.AbstractCell cell)
        {
            if (cell is Model.HintCell) return Draw((Model.HintCell)cell);
            else if (cell is Model.MineCell) return Draw((Model.MineCell)cell);
            else throw new Exception("Unhandled Draw method for type " + cell.GetType());
        }

        private static string Draw(Model.HintCell cell)
        {
            return cell.AdjacentMinesCount.ToString();
        }

        private static string Draw(Model.MineCell cell)
        {
            return "*";
        }
    }
}
