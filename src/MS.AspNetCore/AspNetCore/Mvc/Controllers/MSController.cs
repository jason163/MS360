using Microsoft.AspNetCore.Mvc;
using MS.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.AspNetCore.Mvc.Controllers
{
    /// <summary>
    /// 基类
    /// </summary>
    public abstract class MSController : Controller,ITransientDependency
    {

    }
}
