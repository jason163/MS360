using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Exception
{
    /// <summary>
    /// MS 初始化时抛出此异常
    /// </summary>
    public class MSInitException : MSException
    {
        public MSInitException() { }

        public MSInitException(string msg) : base(msg) { }

        public MSInitException(string msg, System.Exception innerException)
            : base(msg, innerException) { }
    }
}
