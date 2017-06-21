using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Helpers
{
    /// <summary>
    /// Factory class for a Field entity.
    /// </summary>
    class FieldFactory
    {
        private Model.FieldDescriptor FieldInput { get; set; }

        private int NumberOfRows { get; set; }
        private int NumberOfColumns { get; set; }
        private char[,] CellGridInput { get; set; }

        /// <summary>
        /// Initialize the factory based on a FieldDescriptor object
        /// </summary>
        /// <param name="fieldDescriptor"></param>
        public FieldFactory(Model.FieldDescriptor fieldDescriptor) {
            this.NumberOfRows = fieldDescriptor.Size.Item1;
            this.NumberOfColumns = fieldDescriptor.Size.Item2;
            this.CellGridInput = fieldDescriptor.Cells;
        }

        /// <summary>
        /// Creates a Field entity. It calculates the hints as well.
        /// </summary>
        /// <returns></returns>
        public Model.Field CreateField() {

            return new Model.Field() {
                Cells = CreateCellGrid()
            };
        }

        private  Model.AbstractCell[,] CreateCellGrid() {

            var cellGrid = new Model.AbstractCell[NumberOfRows, NumberOfColumns];

            InitGrid(cellGrid);
            CalculateHints(cellGrid);

            return cellGrid;
        }

        private  void InitGrid(Model.AbstractCell[,] cellGrid) {
            for (var i = 0; i < NumberOfRows; i++)
            {
                for (var j = 0; j < NumberOfColumns; j++)
                {
                    var cellInput = CellGridInput[i, j];
                   
                    cellGrid[i, j] = new CellFactory().CreateCell(i, j, cellInput);
                }
            }
        }

        private  void CalculateHints(Model.AbstractCell[,] cellGrid) {
            for (var i = 0; i < NumberOfRows; i++)
            {
                for (var j = 0; j < cellGrid.GetLength(1); j++)
                {
                    var cell = cellGrid[i, j];
                    if (cell is Model.HintCell) {
                        ((Model.HintCell)cell).AdjacentMinesCount = CountAdjacentCells(cell, cellGrid);
                    }
                }
            }
        }

        private  int CountAdjacentCells(Model.AbstractCell cell, Model.AbstractCell[,] cellGrid) {
            int count = 0;
            int prevRow = Math.Max(0, cell.Row - 1);
            int nextRow = Math.Min(NumberOfRows-1, cell.Row + 1);
            int prevColumn = Math.Max(0, cell.Column - 1);
            int nextColumn = Math.Min(NumberOfColumns-1, cell.Column + 1);

            for (var i =prevRow; i <= nextRow; i++)
            {
                for (var j = prevColumn; j <= nextColumn; j++)
                {
                    var isSameCell = i == cell.Row && j == cell.Column;
                    if (!isSameCell && cellGrid[i,j] is Model.MineCell)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

 

    }
}
