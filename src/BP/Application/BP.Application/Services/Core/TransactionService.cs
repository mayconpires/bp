using AutoMapper;
using BP.Domain.Core.TransactionAgg.Commands;
using BP.Interface.Application.Core.Transaction;
using BP.Models.ViewModels.Core.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.Application.Services.Core
{
    public class TransactionService : ITransactionService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _bus;

        public TransactionService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _bus = mediator;
        }

        async Task<TransactionTaxaGetResponseModel> ITransactionService.Perform(TransactionPostRequestModel transactionModel)
        {
            var createTransactionCommand = _mapper.Map<CreateTransactionCommand>(transactionModel);

            var newTransaction = await _bus.Send(createTransactionCommand);
            
            var response = _mapper.Map<TransactionTaxaGetResponseModel>(newTransaction);

            return response;
        }

    }
}
