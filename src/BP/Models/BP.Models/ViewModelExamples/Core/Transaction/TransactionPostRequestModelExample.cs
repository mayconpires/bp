using Bogus;
using BP.Models.ViewModels.Core.MDR;
using BP.Models.ViewModels.Core.Transaction;
using Swashbuckle.AspNetCore.Examples;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Models.ViewModelExamples.Core.Transaction
{
    /// <summary>
    /// Exemplo de Retorno da MdrGetResposeModel
    /// </summary>
    public class TransactionPostRequestModelExample : IExamplesProvider
    {

        /// <summary>
        /// Pega os exemplos
        /// </summary>
        /// <returns></returns>
        public object GetExamples()
        {
            var execucao = new Faker<TransactionPostRequestModel>()
                .RuleFor(h => h.Adquirente, fh => "A")
                .RuleFor(h => h.Valor, fh => 100m)
                .RuleFor(h => h.Bandeira, fh => BandeiraTipoModel.Visa)
                .RuleFor(h => h.Tipo, fh => TipoTransactionModel.Debito);

            return (TransactionPostRequestModel)execucao;
        }

    }
}
