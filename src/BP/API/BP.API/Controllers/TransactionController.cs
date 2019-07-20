using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BP.Interface.Application.Core.Transaction;
using BP.Models.ViewModels.Core.Transaction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TransactionController : ControllerBase
    {
        ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> PerformTransaction([FromBody] TransactionPostRequestModel body)
        {
            var transactionTax = await _transactionService.Perform(body);

            return Ok(transactionTax);
        }

    }
}