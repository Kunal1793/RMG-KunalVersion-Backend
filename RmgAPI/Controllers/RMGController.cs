using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RmgAPI.Models;

namespace RmgAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RMGController : ControllerBase
    {
        private RMGdbContext db;

        public RMGController(RMGdbContext dbContext)
        {
            this.db = dbContext;
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpGet("requests")]
        public ActionResult<IEnumerable<ListOfRequests>> GetRequests() 
        {
            return db.listOfRequests.ToList(); 
           // Displays the List of Requests 
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpGet("requests/{id}")]
        public ActionResult<IEnumerable<ListOfRequests>> GetRequestsByID(int id)
        {
            List<ListOfRequests> AccountsList = new List<ListOfRequests>();
            AccountsList = db.listOfRequests.Where(R => R.AccountID == id).ToList();
            return AccountsList;
            // Displays the List of Requests By ID
        }

        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpGet("accounts")]
        public ActionResult<IEnumerable<Account>> GetAccounts() 
        {
            return db.accounts.ToList();
            // Displays the List of Accounts
        }


        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [HttpPost("accounts")]
        public async Task<ActionResult<Account>> AddAccountAsync([FromBody] Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await db.accounts.AddAsync(account);
            await db.SaveChangesAsync();
            return Created("Account Created", account);
        }


        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [HttpPost("NewRequest")]
        public async Task<ActionResult<ListOfRequests>> AddRequestAsync([FromBody] ListOfRequests requests) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await db.listOfRequests.AddAsync(requests);
            await db.SaveChangesAsync();
            return Created("Request Succesfully Added", requests);
        }


    }
}