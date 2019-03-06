using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Npgsql;
using RPlay.DTO;
using RPlay.DTO.Options;

namespace RPlay.DAO.DB
{
    public sealed class DbConnection
    {
        #region Client Singleton
        /// <summary>
        /// Singleton instance
        /// </summary>
        private static Lazy<DbConnection> _instance;
        /// <summary>
        /// Get DbConnection instance
        /// </summary>
        public static DbConnection GetInstance(DBOptions options)
        {
            if (_instance == null || !_instance.IsValueCreated)
                _instance = new Lazy<DbConnection>(() => new DbConnection(options));
            return _instance.Value;
        }
        private DbConnection(DBOptions options) {
            ConnectionString = $"Provider=PostgreSQL OLE DB Provider;User ID={options.UserId};Password={options.Password};Server={options.Host};Database={options.Database};Pooling={options.Pooling}";
            //ConnectionString = $"User ID=root;Password=article_pipeline_root;Server=articlepipeline-dev.ctbylaryg8r9.eu-west-1.rds.amazonaws.com;Database=postgres;Pooling=false";
        }
        #endregion

        #region Properties
        private string ConnectionString { get; }
        #endregion

        #region Dapper Wrapper
        public List<T> GetAll<T>() where T : DBModel {
            var tableName = (typeof(T).GetCustomAttributes(false).FirstOrDefault(a => a.GetType().Equals(typeof(TableAttribute))) as TableAttribute).Name;
            using (IDbConnection db = new SqlConnection(ConnectionString))
                return db.Query<T>($"select * from {tableName}").ToList();
        }

        public bool Post<T>(params T[] ts) where T : DBModel {
            return PostAsync(ts).Result;
        }

        public async Task<bool> PostAsync<T>(params T[] ts) where T : DBModel {
            using (IDbConnection db = new SqlConnection(ConnectionString))
                return await db.InsertAsync(ts) > 0;
        }

        public bool Put<T>(params T[] ts) where T : DBModel {
            return PutAsync(ts).Result;
        }

        public async Task<bool> PutAsync<T>(params T[] ts) where T : DBModel {
            using (IDbConnection db = new SqlConnection(ConnectionString))
                return await db.UpdateAsync(ts);
        }

        public bool Delete<T>(params T[] ts) where T : DBModel {
            return DeleteAsync(ts).Result;
        }

        public async Task<bool> DeleteAsync<T>(params T[] ts) where T : DBModel {
            using (IDbConnection db = new SqlConnection(ConnectionString))
                return await db.DeleteAsync(ts);
        }

        public List<T> Query<T>(string request) where T : DBModel {
            using (IDbConnection db = new SqlConnection(ConnectionString))
                return db.Query<T>(request).ToList();
        }
        #endregion
    }
}