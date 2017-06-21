using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Workflow
{
    /// <summary>
    /// Workflow that encapsualtes the operations occurring during the input request stage
    /// </summary>
    internal class InputWorkflow
    {
        /// <summary>
        /// Starts the input-retrieving process. It handles the correct incoming-sequence and validation of input data
        /// </summary>
        /// <returns>List of FieldDescriptor as they are described from the input</returns>
        public List<Model.FieldDescriptor> GetInput() {
            var fields = new List<Model.FieldDescriptor>();

            try
            {
                while (true)
                {
                    var fieldSize = ReadFieldSize();
                    if (isInputEndCommand(fieldSize))
                    {
                        break;
                    }
                    else
                    {
                        var numberOfRows = fieldSize.Item1;
                        var numberOfColumns = fieldSize.Item2;
                        char[,] cells = new char[numberOfRows, numberOfColumns];
                        for (var i = 0; i < numberOfRows; i++)
                        {
                            var fieldRow = ReadFieldRow(numberOfColumns);
                            for (var j = 0; j < numberOfColumns; j++)
                            {
                                cells[i, j] = fieldRow[j];
                            }
                        }

                        fields.Add(new Model.FieldDescriptor(numberOfRows, numberOfColumns, cells));
                    }

                }

            }
            catch (Exception ex) {
                var fieldNumber = fields.Count() + 1;
                throw new Exceptions.FieldException(ex.Message) { FieldNumber = fieldNumber };
            }

            return fields;
          
        }
        private Tuple<int, int> ReadFieldSize()
        {
            var input = Console.ReadLine();
            var fieldSize = ParseFieldSizeInput(input);
            return fieldSize;
        }

        private Tuple<int, int> ParseFieldSizeInput(string rawTestInput)
        {
            var a = rawTestInput.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (a.Length == 2)
            {
                int x=-1, y=-1;
                var isValidArguments = int.TryParse(a[0], out x) && int.TryParse(a[1], out y);

                if (isValidArguments) return new Tuple<int, int>(x, y);
                else throw new Exception("Cannot convert input to integer");
            }
            else throw new Exception("Field size must be 2 positive integers");

        }

        private Boolean isValidFieldSize(Tuple<int, int> fieldSize)
        {
            return fieldSize.Item1 > 0 && fieldSize.Item2 > 0;
        }
        private Boolean isInputEndCommand(Tuple<int, int> fieldSize)
        {
            return fieldSize.Item1 == 0 && fieldSize.Item2 == 0;
        }


        private char[] ReadFieldRow(int expectedLength)
        {
            var rowInput = Console.ReadLine();
            var cells = rowInput.ToCharArray();
            if (cells.All(isValidCellInput))
            {
                return cells;
            }
            else {
                throw new Exception("Invalid character for a cell");
            }
        }

        private bool isValidCellInput(char cell) {
            return cell == '*' || cell == '.';
        }
    }
}
