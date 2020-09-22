using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RulesMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RulesController : ControllerBase
    {
        public static List<Account> accountList = new List<Account>
        {
            new Account{AccountId=1,Balance=1000},
            new Account{AccountId=2,Balance=400}
        };
        // GET: api/<RulesController>
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return accountList;
        }

        // GET api/<RulesController>/5
        [HttpGet]
        [Route("evaluateMinBal")]
        public string evaluateMinBal([FromBody] Account value)
        {
            Account account = accountList.Find(a => a.AccountId == value.AccountId);
            account.Balance = account.Balance - value.Balance;
            if (account.Balance < 500)
            {
                account.Balance = account.Balance + value.Balance;
                return "Denied";
            }
            return "Allowed";
        }
        [HttpGet]
        [Route("getServiceCharges")]
        public float getServiceCharges()
        {
            return 100.05F;
        }

        // POST api/<RulesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RulesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RulesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
