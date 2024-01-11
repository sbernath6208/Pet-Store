using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
	public sealed class DALExec
	{

		private static string connectionString;
		//connectionString = ConfigurationManager.ConnectionStrings["PetCoDB"].ConnectionString;
		
		private DALExec(String connectStringKey)
		{
			connectionString = ConfigurationManager.ConnectionStrings[connectStringKey].ConnectionString;
		}
		

		public static DALExec GetInstance(String connectStringKey) // DALExec.GetInstance("PetCoDB"); maybe?
		{
			return new DALExec(connectStringKey);
		}

		public static DataTable ExecuteQuery(string sqlStatement, params object[] parameterArgs)
		{
			DataTable dt = new DataTable();
			int parmNo = 0;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				if (connection.State != ConnectionState.Open)
                    connection.Open();
				if (connection.State != ConnectionState.Open)
					connection.Open();
				SqlCommand cmd = new SqlCommand(sqlStatement, connection);
				cmd = AddParameters(parameterArgs, parmNo, cmd);

				using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
				{
					adapter.Fill(dt);
				}
			}

			return dt;
		}

		public static int ExecuteNonQuery(string sqlStatement, params object[] parameterArgs)
		{
			int rowsAffected = 0;
			int parmNo = 0;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				if (connection.State != ConnectionState.Open)
					connection.Open();
				SqlCommand cmd = new SqlCommand(sqlStatement, connection);
				cmd = AddParameters(parameterArgs, parmNo, cmd);
				rowsAffected = cmd.ExecuteNonQuery();
			}

			return rowsAffected;
		}

		public static Object ExecuteScalar(string sqlStatement, params object[] parameterArgs)
		{
			Object scalarObject = null;
			int parmNo = 0;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				if (connection.State != ConnectionState.Open)
					connection.Open();

				SqlCommand cmd = new SqlCommand(sqlStatement, connection);
				cmd = AddParameters(parameterArgs, parmNo, cmd);
				scalarObject = cmd.ExecuteScalar();
			}

			return scalarObject;
		}

		private static SqlCommand AddParameters(object[] parameterArgs, int parmNo, SqlCommand cmd)
		{
			for (int i = 0; i < parameterArgs.Length; i++)
			{
				parmNo = i + 1;
				cmd.Parameters.AddWithValue(String.Format("@{0}", parmNo), parameterArgs[i]);
			}
			return cmd;
		}

	}

}