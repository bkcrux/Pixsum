using AutoMapper;
using Pixsum.API.Models;
using Pixsum.Data;
using Pixsum.Entities;
using Pixsum.Logic;
using Pixsum.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pixsum.API.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            var db = new DbFactory();
            var uow = new UnitOfWork(db);
            var repo = new GenericRepository<Account>(db);
            var al = new AccountLogic<Account>(uow, repo);
            var acctService = new AccountService(al);
            var acct = acctService.GetAccount(id);

            return Ok(WebApiConfig.mapo.Map<Account, AccountModel>(acct));

            //TODO: Hook up AutoMapper here
            //return Ok(new AccountModel
            //{
            //    Id = acct.Id,
            //    AccountName = acct.AccountName,
            //    SubDomain = acct.SubDomain,
            //    CreatedUserId = acct.CreatedUserId,
            //    CreatedDate = acct.CreatedDate,
            //    UpdatedUserId = acct.UpdatedUserId,
            //    UpdatedDate = acct.UpdatedDate,
            //});

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
