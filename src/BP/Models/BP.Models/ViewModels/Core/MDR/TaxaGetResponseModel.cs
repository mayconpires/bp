using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Models.ViewModels.Core.MDR
{
    public class TaxaGetResponseModel
    {
        /// <summary>
        /// Bandeira que a Taxa é aplicada
        /// </summary>
        public BandeiraTipoModel Bandeira { get; private set; }

        /// <summary>
        /// Percentual de Taxa da Transcation do tipo Crédito
        /// </summary>
        public decimal Credito { get; private set; }

        /// <summary>
        /// Percentual de Taxa da Transcation do tipo Débito
        /// </summary>
        public decimal Debito { get; private set; }
    }
}
