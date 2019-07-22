using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BP.API.Shared;
using BP.Domain.Shared.Attributes;
using BP.Domain.Shared.Notification;
using BP.Interface.Application.Core.Transaction;
using BP.Models.ViewModelExamples.Core.Transaction;
using BP.Models.ViewModels.Core.MDR;
using BP.Models.ViewModels.Core.Transaction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Examples;

namespace BP.API.Controllers
{
    [ValidateNotation(Order = 0)]
    [Route("transaction")]
    [Produces("application/json")]
    public class TransactionController : SharedController
    {
        ITransactionService _transactionService;

        public TransactionController(INotificationDomainService notifications,
                                    ITransactionService transactionService) : base (notifications)
        {
            _transactionService = transactionService;
        }

        /// <summary>
        /// Cria uma transaction para uma Adquirente
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerRequestExample(typeof(TransactionPostRequestModel), typeof(TransactionPostRequestModelExample))]
        [SwaggerResponseExample((int) HttpStatusCode.Created, typeof(TransactionTaxaGetResponseModelExample))]
        public async Task<IActionResult> Post([FromBody] TransactionPostRequestModel body)
        {
            var transaction = await _transactionService.Create(body);

            return ResponseData(transaction, HttpReturn.Created);
        }

    }
}