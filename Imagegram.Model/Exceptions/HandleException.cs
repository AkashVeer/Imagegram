using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Model.Exceptions
{
    public class HandleException : Exception
    {
        public HandleException() : base() { }

        public HandleException(string message) : base(message) { }

        public HandleException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
