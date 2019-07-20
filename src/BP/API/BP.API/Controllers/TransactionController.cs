using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BP.API.Shared;
using BP.Domain.Shared.Attributes;
using BP.Domain.Shared.Notification;
using BP.Interface.Application.Core.Transaction;
using BP.Models.ViewModels.Core.Transaction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BP.API.Controllers
{
    [ValidateNotation(Order = 0)]
    [Route("transaction")]
    [Produces("application/json")]
    //[TypeFilter(typeof(ValidateNotationAttribute), Order = 1)]
    public class TransactionController : SharedController
    //public class TransactionController : ControllerBase
    {
        ITransactionService _transactionService;

        public TransactionController(INotificationDomainService notifications,
                                    ITransactionService transactionService) : base (notifications)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TransactionPostRequestModel body)
        {
            var transactionTax = await _transactionService.Perform(body);

            return ResponseData(body, HttpReturn.Created);
        }

    }
}