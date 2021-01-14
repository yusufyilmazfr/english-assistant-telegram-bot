using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using EnglishAssistantTelegramBot.Console.Entities;
using EnglishAssistantTelegramBot.Console.Repository.Abstract.BaseRepository;
using MySql.Data.MySqlClient;

namespace EnglishAssistantTelegramBot.Console.Repository.Concrete.Dapper.BaseRepository
{
    public class DapperBaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        // I will move base from here to app settings or in another file.
        private string connectionString = "Server=localhost; Database=englishreaderassistanttelegrambot; Uid=root; Pwd=12345;";

        public TEntity GetById(int id)
        {
            using var connection = new MySqlConnection(connectionString);

            return connection.Get<TEntity>(id);
        }

        public IEnumerable<TEntity> GetList()
        {
            using var connection = new MySqlConnection(connectionString);

            return connection.GetAll<TEntity>();
        }

        public int Insert(TEntity entity)
        {
            using var connection = new MySqlConnection(connectionString);

            return (int)connection.Insert<TEntity>(entity);
        }

        public bool Update(TEntity entity)
        {
            using var connection = new MySqlConnection(connectionString);

            return connection.Update<TEntity>(entity);
        }

        public bool Delete(TEntity entity)
        {
            using var connection = new MySqlConnection(connectionString);

            return connection.Delete<TEntity>(entity);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            await using var connection = new MySqlConnection(connectionString);

            return await connection.GetAsync<TEntity>(id);
        }

        public async Task<IEnumerable<TEntity>> GetListAsync()
        {
            await using var connection = new MySqlConnection(connectionString);

            return await connection.GetAllAsync<TEntity>();
        }

        public async Task<int> InsertAsync(TEntity entity)
        {
            await using var connection = new MySqlConnection(connectionString);

            return await connection.InsertAsync<TEntity>(entity);
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            await using var connection = new MySqlConnection(connectionString);

            return await connection.UpdateAsync<TEntity>(entity);
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            await using var connection = new MySqlConnection(connectionString);

            return await connection.DeleteAsync<TEntity>(entity);
        }
    }
}
