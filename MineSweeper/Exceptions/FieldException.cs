using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Exceptions
{
    /// <summary>
    /// Extends Exception class to deliver additional information about the field on which an error occurred
    /// </summary>
    class FieldException : Exception
    {
        public int FieldNumber { get; set;  }

        public FieldException(string message) : base(message) {}
    }
}
