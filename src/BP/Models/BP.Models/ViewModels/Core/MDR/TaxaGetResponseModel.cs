using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Models.ViewModels.Core.MDR
{
    public class TaxaGetResponseModel
    {
        public BandeiraTipoModel Bandeira { get; private set; }
        public decimal Credito { get; private set; }
        public decimal Debito { get; private set; }
    }
}
