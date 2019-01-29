using System;
using System.Collections.Generic;
using System.Text;

namespace MS
{
    /// <summary>
    /// MS Exception
    /// </summary>
    [Serializable]
    public class MSException : System.Exception
    {
        public MSException()
        {
        }

        public MSException(string msg) : base(msg) { }

        public MSException(string msg, System.Exception innerException)
            : base(msg, innerException) { }

    }
}
