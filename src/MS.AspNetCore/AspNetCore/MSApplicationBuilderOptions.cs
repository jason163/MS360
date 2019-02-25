using System;
using System.Collections.Generic;
using System.Text;

namespace MS.AspNetCore
{
    public class MSApplicationBuilderOptions
    {
        public bool UseCastleLoggerFactory { get; set; }

        public bool UseSecurityHeaders { get; set; }

        public MSApplicationBuilderOptions()
        {
            UseCastleLoggerFactory = true;
            UseSecurityHeaders = true;
        }


        
    }
}
