using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicSurveyRestService.Common
{
    public class DBContext
    {


        #region Properties

        public string ConnectionString { get; }


        #endregion

        #region Constructor

        public DBContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        #endregion


        #region Methods

        public async Task<SqlConnection> OpenConnectionAsync()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            await connection.OpenAsync();
            return connection;
        }


        #endregion

    }
}
