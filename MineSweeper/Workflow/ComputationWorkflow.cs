using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Workflow
{
    /// <summary>
    /// Workflow that encapsualtes the operations occurring during the computation stage
    /// </summary>
    internal class ComputationWorkflow
    {
        List<Model.FieldDescriptor> FieldsInput { get; set; }

        /// <summary>
        /// Initialize the workflow with the list of FieldDescriptor coming from the input stage
        /// </summary>
        /// <param name="fieldsInput">list of FieldDescriptor coming from the input stage</param>
        public ComputationWorkflow(List<Model.FieldDescriptor> fieldsInput)
        {
            this.FieldsInput = fieldsInput;
        }

        /// <summary>
        /// Performs the computation stage that gets Field entities from the input
        /// </summary>
        /// <returns>List of Field based on the input provided</returns>
        public List<Model.Field> Elaborate()
        {
            List<Model.Field> fields = new List<Model.Field>();
            for (var i = 0; i < FieldsInput.Count(); i++)
            {
                try
                {
                    var field = new Helpers.FieldFactory(FieldsInput[i]).CreateField();
                    fields.Add(field);
                }
                catch (Exception ex)
                {
                    throw new Exceptions.FieldException(ex.Message) { FieldNumber = i + 1 };
                }

            }

            return fields;
        }
    }
}
