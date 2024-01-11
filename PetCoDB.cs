using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Final_Pet_Store_Bernath
{
    public static class PetCoDB
    {
        /// <summary>
        /// Represents the database connection
        /// </summary>
        public static SqlConnection DBConnection { get; private set; }

       

        /// <summary>
        /// Establishes and returns a database connection.  If the connection is already established,
        /// then the current connection is returned.
        /// </summary>
        /// <returns>Database Connection</returns>
        public static SqlConnection GetConnection()
        {
            if (DBConnection == null)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["PetCoDB"].ConnectionString;
                DBConnection = new SqlConnection(connectionString);
                DBConnection.Open();
            }
            return DBConnection;
        }



    }
}
