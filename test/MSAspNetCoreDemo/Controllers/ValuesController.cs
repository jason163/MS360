using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MS.AspNetCore.Mvc.Controllers;
using MS.DataAccess;
using MS.Dependency;

namespace MSAspNetCoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : MSController
    {
        private IDataCommand cmd;

        public ValuesController(IDataCommand dataCommand)
        {
            this.cmd = dataCommand;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            //IDataCommand command = IocManager.Instance.Resolve<IDataCommand>();
            cmd.CreateCommand("GetAllChannelList");
            var list = cmd.ExecuteEntityList<Channel>();

            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
