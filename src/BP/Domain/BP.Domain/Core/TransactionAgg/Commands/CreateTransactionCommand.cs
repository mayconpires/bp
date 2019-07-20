using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Domain.Core.TransactionAgg.Commands
{
    public class CreateTransactionCommand : IRequest<Transaction>
    {
        public decimal Valor { get; set; }

    }
}
