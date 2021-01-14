using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EnglishAssistantTelegramBot.Console.Entities;

namespace EnglishAssistantTelegramBot.Console.Repository.Abstract.BaseRepository
{
    /// <summary>
    /// Generic repository interface. It provides same methods to other repositories.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Get TEntity by specified id.
        /// </summary>
        /// <param name="id">Unique id.</param>
        /// <returns></returns>
        TEntity GetById(int id);

        /// <summary>
        /// Get TEntity list.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetList();

        /// <summary>
        /// Insert new entity to data source.
        /// </summary>
        /// <param name="entity">TEntity instance.</param>
        /// <returns></returns>
        int Insert(TEntity entity);

        /// <summary>
        /// Update TEntity from data source.
        /// </summary>
        /// <param name="entity">TEntity instance.</param>
        /// <returns></returns>
        bool Update(TEntity entity);

        /// <summary>
        /// Remove TEntity from data source.
        /// </summary>
        /// <param name="entity">TEntity instance.</param>
        /// <returns></returns>
        bool Delete(TEntity entity);

        /// <summary>
        /// Get TEntity by specified id.
        /// </summary>
        /// <param name="id">Unique id.</param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// Get TEntity list.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetListAsync();

        /// <summary>
        /// Insert new entity to data source.
        /// </summary>
        /// <param name="entity">TEntity instance.</param>
        /// <returns></returns>
        Task<int> InsertAsync(TEntity entity);

        /// <summary>
        /// Update TEntity from data source.
        /// </summary>
        /// <param name="entity">TEntity instance.</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(TEntity entity);

        /// <summary>
        /// Remove TEntity from data source.
        /// </summary>
        /// <param name="entity">TEntity instance.</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TEntity entity);
    }
}
