using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Workflow
{
    class ExecutionContext
    {
        /// <summary>
        /// Starts the execution of the program in the context of the current object
        /// </summary>
        public void Run() {
            // get input
            var inputWF = new InputWorkflow();
            var fieldDescriptors = inputWF.GetInput();

            //elaborate
            var computationWF = new ComputationWorkflow(fieldDescriptors);
            var fields = computationWF.Elaborate();

            //  render output
            var outputWF = new OutputWorkflow(fields);
            outputWF.DrawInConsole();
        }



    }
}
