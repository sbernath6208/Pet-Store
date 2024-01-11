using DataAccessLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.DBObjects
{
	/// <summary>
	/// Provides Database Access to the Status table
	/// </summary>
	public static class StatusDB
	{
		/// <summary>
		/// Retrieves all information from the Status table
		/// </summary>
		/// <returns>List of Status objects representing all data in the table</returns>
		public static List<Status> GetAll()
		{
			List<Status> statusList = new List<Status>();
			string sqlStatement = @"
				SELECT status_id, status_desc 
				FROM status 
				ORDER BY status_desc";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				Status status = new Status
				{
					StatusId = (int)dr["status_id"],
					StatusDesc = dr["status_desc"].ToString()
				};
			}

			return statusList;
		}

		/// <summary>
		/// Retrieve the specific status record based on the primary key to table
		/// </summary>
		/// <param name="statusId">Status Id - unique table primary key</param>
		/// <returns>Status Record as an object</returns>
		public static Status GetById(int statusId)
		{
			Status status = null;
			string sqlStatement = @"
				SELECT status_id, status_desc 
				FROM status 
				WHERE status_id = @1";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, statusId);

			if (dt.Rows.Count > 0)
			{
				status = new Status
				{
					StatusId = (int)dt.Rows[0]["status_id"],
					StatusDesc = dt.Rows[0]["status_desc"].ToString()
				};

			}

			return status;
		}

		/// <summary>
		/// Adds a Status record to the database
		/// </summary>
		/// <param name="status">Status Object</param>
		/// <returns>Updated object with the Unique Primary Key ID</returns>
		public static Status Add(Status status)
		{
			string sqlStatement = @"
				INSERT INTO status (status_desc)
				VALUES(@1)";
			if (DALExec.ExecuteNonQuery(sqlStatement, status.StatusDesc) > 0)
			{
				sqlStatement = @"
                    SELECT IDENT_CURRENT('status') AS RESULT";
				int statusID = Convert.ToInt32(DALExec.ExecuteScalar(sqlStatement));
				status.StatusId = statusID;
			}
			return status;
		}

		/// <summary>
		/// Deletes the specified Status record from the Table
		/// </summary>
		/// <param name="status"></param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Delete(Status status)
		{
			string sqlStatement = @"
                DELETE FROM status
                WHERE status_id = @1";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement, status.StatusId);
				if (count > 0)
					return true;
				else
					return false;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Updates the status description
		/// </summary>
		/// <param name="status">Status object to update</param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Update(Status status)
		{
			string sqlStatement = @"
                UPDATE status
                    SET status_desc = @1
                WHERE status_id = @2";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement,
					status.StatusDesc, status.StatusId);
				if (count > 0)
					return true;
				else
					return false;
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}
	}
}