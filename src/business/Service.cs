using System;
using RPlay.DAO.DB;
using RPlay.DTO.Options;

namespace RPlay.Business
{
    public abstract class Service
    {
        protected readonly DbConnection connection;
        internal Service(DBOptions options)
        {
            connection = DbConnection.GetInstance(options);
        }
    }
}
