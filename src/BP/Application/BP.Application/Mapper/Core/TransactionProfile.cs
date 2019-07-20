using AutoMapper;
using BP.Domain.Core.TransactionAgg;
using BP.Domain.Core.TransactionAgg.Commands;
using BP.Models.ViewModels.Core.Transaction;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Application.Mapper.Core
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<TransactionPostRequestModel, CreateTransactionCommand>();
            CreateMap<Transaction, TransactionTaxaGetResponseModel>();
        }

    }
}
