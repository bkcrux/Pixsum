using AutoMapper;
using Newtonsoft.Json;
using Pixsum.API.Models;
using Pixsum.Data;
using Pixsum.Entities;
using Pixsum.Logic;
using Pixsum.Services;
using Pixsum.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pixsum.API.Controllers
{
    public class AccountController : ApiController
    {
        private IMapper mapper;
        private IAccountService accountService;

        public AccountController(IMapper mapper, IAccountService acctService)
        {
            this.mapper = mapper;
            accountService = acctService;
        }


        // GET api/account
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/account/5
        public IHttpActionResult Get(int id)
        {
            var acct = accountService.GetAccount(id);
            return Ok(mapper.Map<Account, AccountModel>(acct));
        }

        // POST api/account
        public IHttpActionResult Post([FromBody] AccountModel model)
        {
            return Ok(accountService.CreateNewAccountForBrandNewUser(
                mapper.Map<AccountModel, Account>(model)));
        }

        // PUT api/account/5
        public IHttpActionResult Put(int id, [FromBody]AccountModel model)
        {
            return Ok(accountService.UpdateAccount(
                mapper.Map<AccountModel, Account>(model)));

        }

        // DELETE api/account/5
        public void Delete(int id)
        {
        }
    }
}
