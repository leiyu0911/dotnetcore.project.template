using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rex.Temp.EF.Entity;
using Rex.Temp.IService;

namespace Rex.Temp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUserService _userService;

        public ValuesController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public ActionResult<string> AddUser()
        {
            var user = new User()
            {
                UserName = "test",
                PassWord = "123456",
                CreatedBy = "test",
                LastModifiedBy = "test",
                EMailAddress = "test@test.com",
                PhoneNumber = "12345678901"
            };
            var result = _userService.Add(user);
            return result.Id > 0 ? "sucessful" : "failed";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
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
