using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
	[Serializable]
	class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException() { }

        public NegativesNotAllowedException(string message)
            : base(message) { }

        public NegativesNotAllowedException(string message, Exception inner)
            : base(message, inner) { }
    }
}
