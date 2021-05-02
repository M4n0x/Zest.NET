using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zest.Net.Entities.Client;
using Zest.Net.Entities.Interfaces;
using Zest.Net.Entities.Attributes;
using System.Reflection;

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
        protected readonly ZestClient _client;

        /// <summary>
        /// Api path for used entity (TEntity)
        /// </summary>
        public virtual string ApiPath => typeof(TEntity).GetCustomAttribute<ApiPathAttribute>().Path;

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
        /// Get entities
        /// </summary>
        /// <returns>Api response</returns>
        public virtual async Task<TEntity> GetSingle()
        {
            return await _client.GetSingle<TEntity>(ApiPath);
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">Entity id to get</param>
        /// <returns>Api response</returns>
        public async Task<TEntity> GetById(int id)
        {
            return await _client.GetById<TEntity>(ApiPath, id);
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">Entity id to get</param>
        /// <returns>Api response</returns>
        public async Task<TEntity> GetById(string id)
        {
            return await _client.GetById<TEntity>(ApiPath, id);
        }

        /// <summary>
        /// Insert entity in database
        /// </summary>
        /// <param name="entity">entity to insert</param>
        /// <returns>Api response</returns>
        public async Task<TEntity> Insert(TEntity entity)
        {
            return await _client.Insert(ApiPath, entity);
        }

        /// <summary>
        /// Update an entity by id
        /// </summary>
        /// <param name="id">Entity id to update</param>
        /// <param name="entity">Entity data</param>
        /// <returns>Api response</returns>
        public async Task<TEntity> Update(int id, TEntity entity)
        {
            return await _client.Update(ApiPath, id, entity);
        }

        public async Task Update(string id, TEntity entity)
        {
            await _client.Update(ApiPath, id, entity);
        }

        /// <summary>
        /// Delete an entity by id
        /// </summary>
        /// <param name="id">Entity id to delete</param>
        /// <returns>Api response</returns>
        
        public async Task Delete(int id)
        {
            await _client.Delete(ApiPath, id);
        }

        public async Task Delete(string id)
        {
            await _client.Delete<TEntity>(ApiPath, id);
        }

        /// <summary>
        /// Patch an entity by id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <param name="data">Data to update for Entity</param>
        /// <returns>Api response</returns>
        public async Task Patch(int id, object data)
        {
            await _client.Patch(ApiPath, id, data);
        }
    }
}
