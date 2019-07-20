using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Models.ViewModels.Core.MDR
{
    public class MdrGetResposeModel
    {

        /// <summary>
        /// Nome da Adquirente
        /// </summary>
        public string Adquirente { get; set; }

        /// <summary>
        /// Taxas da Adquirente
        /// </summary>
        public IEnumerable<TaxaGetResponseModel> Taxas {get; set; }

}
}
