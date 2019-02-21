using System;
using System.Collections.Generic;
using System.Text;

namespace MS.AspNetCore
{
    public class MSApplicationBuilderOptions
    {
        public bool UseCastleLoggerFactory { get; set; }

        public MSApplicationBuilderOptions()
        {
            UseCastleLoggerFactory = true;
        }


        
    }
}
