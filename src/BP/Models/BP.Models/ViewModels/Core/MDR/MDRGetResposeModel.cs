using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Models.ViewModels.Core.MDR
{
    public class MdrGetResposeModel
    {

        public string Adquirente { get; set; }

        public IEnumerable<TaxaGetResponseModel> Taxas {get; set; }

}
}
