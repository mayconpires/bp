using BP.Domain.Core.MdrAgg;
using BP.Domain.Core.MdrAgg.Enums;
using BP.Domain.Core.MdrAgg.Repository;
using BP.Domain.Core.TransactionAgg;
using BP.Domain.Core.TransactionAgg.Repository;
using BP.Domain.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Infra.Data.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private static List<Transaction> _transactions = new List<Transaction>();

        Transaction IRepository<Transaction>.Add(Transaction entity)
        {
            _transactions.Add(entity);

            return entity;
        }

        Transaction IRepository<Transaction>.Get()
        {
            throw new NotImplementedException();
        }

        Task<List<Transaction>> IRepository<Transaction>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Transaction> IRepository<Transaction>.GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
