using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class OperationFinanceException : Exception
    {

        public OperationFinanceException(string message) : base(message) { }

        public OperationFinanceException(string message, Exception exception) : base(message, exception) { }
    }
}
