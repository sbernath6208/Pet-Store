using DataAccessLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.DBObjects
{
	/// <summary>
	/// Provides Database Access to the State table
	/// </summary>
	public static class StateDB
	{
		/// <summary>
		/// Retrieves all information from the State table
		/// </summary>
		/// <returns>List of State objects representing all data in the table</returns>
		public static List<State> GetAll()
		{
			List<State> stateList = new List<State>();
			string sqlStatement = @"
				SELECT state_abbr, state_name, sales_tax  
				FROM state 
				ORDER BY state_abbr";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				State state = new State
				{
					StateAbbr = dr["state_abbr"].ToString(),
					StateName = dr["state_name"].ToString(),
					SalesTax = (decimal)dr["sales_tax"]
				};
				stateList.Add(state);
			}

			return stateList;
		}

		/// <summary>
		/// Retrieve the specific status record based on the primary key to table
		/// </summary>
		/// <param name="statusAbbr">Status Id - unique table primary key</param>
		/// <returns>Status Record as an object</returns>
		public static State GetByAbbr(string stateAbbr)
		{
			State state = null;
			string sqlStatement = @"
				SELECT state_abbr, state_name, sales_tax 
				FROM state 
				WHERE state_abbr = @1";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, stateAbbr);

			if (dt.Rows.Count > 0)
			{
				state = new State
				{
					StateAbbr = dt.Rows[0]["state_abbr"].ToString(),
					StateName = dt.Rows[0]["state_name"].ToString(),
					SalesTax = (Decimal)dt.Rows[0]["sales_tax"]
				};
			}

			return state;
		}
	}
}