using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Data.User> Get()
        {
            IEnumerable<Data.User> result;
            using (var dbContext = new Data.UserContext())
            {
                result = dbContext.Users.ToList();
            }
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Data.User Get(int id)
        {
            Data.User result;
            using (var dbContext = new Data.UserContext())
            {
                result = dbContext.Users.Find(id);
            }
            return result;
        }

        // POST api/values
        [HttpPost]
        public Data.User Post([FromBody]Data.User value)
        {
            using (var dbContext = new Data.UserContext())
            {
                dbContext.Users.Add(value);
                dbContext.SaveChanges();
            }

            return value;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Data.User Put(int id, [FromBody]Data.User value)
        {
            Data.User result;
            using (var dbContext = new Data.UserContext())
            {
                result = dbContext.Users.Find(id);
                if (result != null)
                {
                    result.firstName = value.firstName;
                    result.lastName = value.lastName;
                    result.updatedAt = DateTimeOffset.Now;
                    dbContext.SaveChanges();
                }
            }
            return result;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var dbContext = new Data.UserContext())
            {
                var result = dbContext.Users.Find(id);
                if (result != null)
                {
                    dbContext.Remove(result);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
