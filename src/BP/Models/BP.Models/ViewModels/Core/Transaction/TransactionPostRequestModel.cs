using BP.Models.ViewModels.Core.MDR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Models.ViewModels.Core.Transaction
{
    public class TransactionPostRequestModel
    {

        public decimal Valor{ get; set; }

        public string Adquirente { get; set; }

        public BandeiraTipoModel Bandeira { get; set; }

        public TipoTransactionModel Tipo { get; set; }

    }
}
