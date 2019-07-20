using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BP.Domain.Core.TransactionAgg.Commands.Handlers
{
    public class TransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Transaction>
    {

        async Task<Transaction> IRequestHandler<CreateTransactionCommand, Transaction>.Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {

            return await Task.Run( () => Transaction.Create(0, "", "", "") );

            //throw new NotImplementedException();
        }

    }

}
