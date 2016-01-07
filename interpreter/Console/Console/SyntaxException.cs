using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpret
{
	/// <summary>
	/// Thrown when syntax error happens.
	/// </summary>
    class SyntaxException : Exception
    {
        public SyntaxException() : base() { }
        public SyntaxException(String msg) : base(msg) { }
    }
}
