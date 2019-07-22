using Bogus;
using BP.Models.ViewModels.Core.Transaction;
using Swashbuckle.AspNetCore.Examples;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Models.ViewModelExamples.Core.Transaction
{
    /// <summary>
    /// Exemplo de Retorno da TransactionTaxaGetResponseModel
    /// </summary>
    public class TransactionTaxaGetResponseModelExample : IExamplesProvider
    {

        /// <summary>
        /// Pega os exemplos
        /// </summary>
        /// <returns></returns>
        public object GetExamples()
        {
            var execucao = new Faker<TransactionTaxaGetResponseModel>()
                .RuleFor(h => h.ValorLiquido, fh => 98m);

            return (TransactionTaxaGetResponseModel)execucao;
        }

    }
}
