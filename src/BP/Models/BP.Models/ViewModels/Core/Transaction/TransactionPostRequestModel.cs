using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Models.ViewModels.Core.Transaction
{
    public class TransactionPostRequestModel
    {

        public decimal Valor{ get; set; }

        public string Adquirente { get; set; }

        public string Bandeira { get; set; }

        public string Tipo { get; set; }

    }
}
