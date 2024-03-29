﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Zest.Net.Entities.Interfaces
{
    /// <summary>
    /// Generic repository
    /// </summary>
    /// <typeparam name="TEntity">Generic Entity type</typeparam>
    public interface IGenericHttpRepository<TEntity>
    {
        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>entities</returns>
        Task<IEnumerable<TEntity>> Get();

        /// <summary>
        /// Get Entity by id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>entity with given id</returns>
        Task<TEntity> GetById(int id);

        /// <summary>
        /// Insert an entity in database
        /// </summary>
        /// <param name="entity">entity to save in database</param>
        /// <returns>Task</returns>
        Task Insert(TEntity entity);

        /// <summary>
        /// Update an entity with a given id
        /// </summary>
        /// <param name="id">Entity id to update</param>
        /// <param name="entity">New data for entity</param>
        /// <returns>Task</returns>
        Task Update(int id, TEntity entity);

        /// <summary>
        /// Delete an entity with given id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Task</returns>
        Task Delete(int id);

        /// <summary>
        /// Patch an entity with given id
        /// </summary>
        /// <param name="id">Entity id to patch</param>
        /// <param name="data">Data to patch</param>
        /// <returns>Task</returns>
        Task Patch(int id, object data);
    }
}
