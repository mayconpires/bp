using BP.Domain.Core.MdrAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Domain.Tests.Core.MdrAgg.Arrange
{
    public class ArrangeMdr : Mdr
    {
       
        public static decimal AplicarTaxaSobreValor(decimal valor, decimal percentualTaxa)
        {
            return aplicarTaxaSobreValor(valor, percentualTaxa);
        }

    }
}
