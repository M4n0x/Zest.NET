using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Zest.Net.Entities.Interfaces
{
    public interface IGenericHttpRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> GetById();
        Task Insert(TEntity entity);
        Task Update(int id, TEntity entity);
        Task Delete(TEntity entity);
        Task Delete(int id);
    }
}
