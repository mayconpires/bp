using BP.Domain.Core.MdrAgg.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Domain.Core.MdrAgg.EntityChild
{
    public class Taxa
    {
        private Taxa()
        {
        }

        public static Taxa Add(BandeiraTipo bandeira, decimal taxaCredito, decimal taxaDebito)
        {
            var taxa = new Taxa();

            taxa.Bandeira = bandeira;
            taxa.Credito = taxaCredito;
            taxa.Debito = taxaDebito;

            return taxa;
        }

        public BandeiraTipo Bandeira { get; private set; }
        public decimal Credito { get; private set; }
        public decimal Debito { get; private set; }
    }
}
