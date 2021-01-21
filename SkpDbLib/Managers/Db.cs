using SkpDbLib.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkpDbLib.Managers
{
    public class Db : IDisposable
    {
        private Connection _dbConnection = new Connection();
        private SqlCommands _sqlCommands = new SqlCommands();

        // add sql commands here => stored procedures prefered

        public void SetConnection(string connectionString)
        {
            _dbConnection.SetConnection(connectionString);
        }

        public void Dispose()
        {
            _dbConnection = null;
            _sqlCommands = null;
        }
    }
}
