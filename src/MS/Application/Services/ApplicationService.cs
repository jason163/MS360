﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Application.Services
{
    public abstract class ApplicationService : IApplicationService
    {
        public static string[] CommonPostfixes = { "AppService", "ApplicationService" };

    }
}
