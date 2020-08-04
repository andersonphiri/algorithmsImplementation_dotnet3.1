using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms2020.CustomHeap
{

    public class ImpossibleOperationException : Exception
    {
        public ImpossibleOperationException() : base()
        {

        }
        public ImpossibleOperationException(string message) : base(message)
        {

        }
    }
}
