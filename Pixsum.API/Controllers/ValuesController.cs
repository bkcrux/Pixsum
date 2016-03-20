using Pixsum.Data;
using Pixsum.Data.Interfaces;
using Pixsum.Entities;
using Pixsum.Logic;
using Pixsum.Logic.Interfaces;
using Pixsum.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pixsum.API.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
           return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {

            var db = new DbFactory();
            var uow = new UnitOfWork(db);
            var repo = new GenericRepository<Account>(db);
            var al = new AccountLogic<Account>(uow, repo);
            var acctService = new AccountService(al) ;

            return acctService.GetAccount(id).ToString();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
