using Microsoft.AspNetCore.Mvc;
using MS.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSAspNetCoreDemo.AppService
{
    /// <summary>
    /// FooService
    /// </summary>
    public interface IFooService : IApplicationService
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        string Get();

        /// <summary>
        /// GetString
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        [HttpGet]
        string GetString(int i);
    }

    /// <summary>
    /// FooService
    /// </summary>
    public class FooService : IFooService
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        public string Get()
        {
            return "Hello World";
        }

        /// <summary>
        /// GetString
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string GetString(int i)
        {
            return (i + 1).ToString();
        }
    }
}
