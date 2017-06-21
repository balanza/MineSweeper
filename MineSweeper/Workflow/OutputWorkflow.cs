using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Workflow
{
    /// <summary>
    /// Workflow that encapsualtes the operations occurring during the output retrieving stage
    /// </summary>
    internal class OutputWorkflow
    {
        List<Model.Field> Fields { get; set; }

        public OutputWorkflow(List<Model.Field> fields)
        {
            this.Fields = fields;
        }
        public void DrawInConsole()
        {

            for (var i = 0; i < Fields.Count(); i++)
            {
                try
                {
                    var field = Fields.ElementAt(i);
                    Console.WriteLine("Field #" + i);
                    Console.WriteLine(Helpers.DrawHelper.Draw(field));
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    throw new Exceptions.FieldException(ex.Message) { FieldNumber = i + 1 };
                }

            }
        }
    }
}
