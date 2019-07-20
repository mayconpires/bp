using BP.Domain.Core.MdrAgg.Enums;
using BP.Domain.Core.TransactionAgg.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Domain.Core.TransactionAgg.Commands
{
    public class CreateTransactionCommand : IRequest<Transaction>
    {
        public decimal Valor { get; set; }

        public string Adquirente { get; set; }

        public BandeiraTipo Bandeira { get; set; }

        public TipoTransaction Tipo { get; set; }

    }
}
