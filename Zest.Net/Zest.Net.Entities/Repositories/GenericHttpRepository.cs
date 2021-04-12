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
    /// <summary>
    /// Generic Repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public class GenericHttpRepository<TEntity> : IGenericHttpRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Zest client
        /// </summary>
        private readonly ZestClient _client;

        /// <summary>
        /// Api path for used entity (TEntity)
        /// </summary>
        public string ApiPath => typeof(TEntity).GetCustomAttribute<ApiPathAttribute>().Path;

        /// <summary>
        /// Generic Repository constructor
        /// </summary>
        /// <param name="client">Zest client</param>
        public GenericHttpRepository(ZestClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Get entities
        /// </summary>
        /// <returns>Api response</returns>
        public virtual async Task<IEnumerable<TEntity>> Get()
        {
            return await _client.Get<TEntity>(ApiPath);
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">Entity id to get</param>
        /// <returns>Api response</returns>
        public Task<TEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Insert entity in database
        /// </summary>
        /// <param name="entity">entity to insert</param>
        /// <returns>Api response</returns>
        public Task Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update an entity by id
        /// </summary>
        /// <param name="id">Entity id to update</param>
        /// <param name="entity">Entity data</param>
        /// <returns>Api response</returns>
        public Task Update(int id, TEntity entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <returns>Api response</returns>
        public Task Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete an entity by id
        /// </summary>
        /// <param name="id">Entity id to delete</param>
        /// <returns>Api response</returns>
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
