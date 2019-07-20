using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.Domain.Shared.Repository
{
    public interface IRepository<TEntity>
    {
        TEntity Add(TEntity entity);
        TEntity Get();
        Task<List<TEntity>> GetAll();
    }
}
