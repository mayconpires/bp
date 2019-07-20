using BP.Models.ViewModels.Core.Transaction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.Interface.Application.Core.Transaction
{
    public interface ITransactionService
    {

        Task<TransactionTaxaGetResponseModel> Create(TransactionPostRequestModel transactionModel);

    }
}
