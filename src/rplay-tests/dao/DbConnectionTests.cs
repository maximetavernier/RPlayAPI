using System;
using System.Linq;
using RPlay.Core.Extensions;
using RPlay.DAO.DB;
using RPlay.DTO.DB;
using RPlay.DTO.Options;
using RPlay.Tests.Helpers;
using Xunit;

namespace RPlay.Tests.DAO
{
    public sealed class DbConnectionTests
    {
        private DbConnection connection;

        public DbConnectionTests() {
            var options = new DBOptions{
                UserId = "root",
                Password = "'root'",
                Host = "localhost",
                Port = 5432,
                Database = "rplay_db",
                Pooling = true
            };
            connection = DbConnection.GetInstance(options);
        }

        [Fact]
        public void ClientExists() {
            try
            {
                connection.GetAll<PlatformUser>();
            }
            catch (Exception ex) {
                ex.PrintStackTrace();
                AssertHelper.Fail();
            }
        }

        [Fact]
        public void GetModelFromDb() {
            var model = connection.GetAll<PlatformUser>().FirstOrDefault(u => u.Firstname == "Maxime" && u.Lastname == "Tavernier");
            Assert.NotNull(model);
        }
    }
}