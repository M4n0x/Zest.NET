using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zest.Net.Entities.Client;
using Zest.Net.Entities.Interfaces;
using Zest.Net.Entities.Attributes;
using System.Reflection;
using Zest.Net.Entities.Models;

namespace Zest.Net.Entities.Repositories
{

    public class GenericHttpRepository<TEntity> : IGenericHttpRepository<TEntity> where TEntity : class
    {
        private readonly ZestClient _client;

        public string ApiPath => typeof(TEntity).GetCustomAttribute<ApiPathAttribute>().Path;

        public GenericHttpRepository(ZestClient client)
        {
            _client = client;
        }

        public virtual async Task<IEnumerable<TEntity>> Get()
        {
            return await _client.Get<TEntity>(ApiPath);
        }

        public Task<TEntity> GetById()
        {
            throw new NotImplementedException();
        }

        public Task Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, TEntity entity)
        {
            throw new NotImplementedException();
        }
        public Task Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
