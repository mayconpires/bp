using Bogus;
using BP.Models.ViewModels.Core.MDR;
using System;
using System.Collections.Generic;
using System.Text;
using Swashbuckle.AspNetCore.Examples;

namespace BP.Models.ViewModelExamples.Core.MDR
{
    /// <summary>
    /// Exemplo de Retorno da MdrGetResposeModel
    /// </summary>
    public class MdrGetResposeModelExample : IExamplesProvider
    {

        /// <summary>
        /// Pega os exemplos
        /// </summary>
        /// <returns></returns>
        public object GetExamples()
        {
            var execucao = new Faker<MdrGetResposeModel>()
                .RuleFor(h => h.Adquirente, fh => "A")
                .RuleFor(h => h.Taxas, fh => new List<TaxaGetResponseModel> { GetTaxaGetResponseModel() });

            return (MdrGetResposeModel)execucao;
        }

        /// <summary>
        /// Pega os exemplos
        /// </summary>
        /// <returns></returns>
        public TaxaGetResponseModel GetTaxaGetResponseModel()
        {
            var execucao = new Faker<TaxaGetResponseModel>()
                .RuleFor(h => h.Bandeira, fh => BandeiraTipoModel.Visa)
                .RuleFor(h => h.Debito, fh => 2.00m)
                .RuleFor(h => h.Credito, fh => 2.25m);

            return execucao;
        }

    }
}
