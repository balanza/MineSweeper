using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                new Workflow.ExecutionContext().Run();
            }
            catch (Exceptions.FieldException ex)
            {
                Console.WriteLine("Invalid input for field #" + ex.FieldNumber + ": " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("A generic error occurred: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("(press Enter to close)");
                Console.ReadLine();
            }
        }

    }
}
