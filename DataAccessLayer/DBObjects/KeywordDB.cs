using DataAccessLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.DBObjects
{
	/// <summary>
	/// Provides Database Access to the Keyword table
	/// </summary>
	public static class KeywordDB
	{
		/// <summary>
		/// Retrieves all information from the Keyword table
		/// </summary>
		/// <returns>List of Keyword objects representing all data in the table</returns>
		public static List<Keyword> GetAll()
		{
			List<Keyword> keywordList = new List<Keyword>();
			string sqlStatement = @"
				SELECT keyword_id, keyword_desc 
				FROM keyword 
				ORDER BY keyword_desc";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				Keyword keyword = new Keyword();
				keyword.KeywordId = (int)dr["keyword_id"];
				keyword.KeywordDesc = dr["keyword_desc"].ToString();
			}

			return keywordList;
		}

		/// <summary>
		/// Retrieve the specific keyword record based on the primary key to table
		/// </summary>
		/// <param name="keywordId">Keyword Id - unique table primary key</param>
		/// <returns>Keyword Record as an object</returns>
		public static Keyword GetById(int keywordId)
		{
			Keyword keyword = null;
			string sqlStatement = @"
				SELECT keyword_id, keyword_desc 
				FROM keyword 
				WHERE keyword_id = @1";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, keywordId);

			if (dt.Rows.Count > 0)
			{
				keyword = new Keyword();
				keyword.KeywordId = (int)dt.Rows[0]["keyword_id"];
				keyword.KeywordDesc = dt.Rows[0]["keyword_desc"].ToString();

			}

			return keyword;
		}

		/// <summary>
		/// Adds a Keyword record to the database
		/// </summary>
		/// <param name="keyword">Keyword Object</param>
		/// <returns>Updated object with the Unique Primary Key ID</returns>
		public static Keyword Add(Keyword keyword)
		{
			string sqlStatement = @"
				INSERT INTO keyword (keyword_desc)
				VALUES(@1)";
			if (DALExec.ExecuteNonQuery(sqlStatement, keyword.KeywordDesc) > 0)
			{
				sqlStatement = @"
                    SELECT IDENT_CURRENT('keyword') AS RESULT";
				int keywordID = Convert.ToInt32(DALExec.ExecuteScalar(sqlStatement));
				keyword.KeywordId = keywordID;
			}
			return keyword;
		}

		/// <summary>
		/// Deletes the specified Keyword record from the Table
		/// </summary>
		/// <param name="keyword"></param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Delete(Keyword keyword)
		{
			string sqlStatement = @"
                DELETE FROM keyword
                WHERE keyword_id = @1";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement, keyword.KeywordId);
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
		/// Updates the keyword description
		/// </summary>
		/// <param name="keyword">Keyword object to update</param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Update(Keyword keyword)
		{
			string sqlStatement = @"
                UPDATE keyword
                    SET keyword_desc = @1
                WHERE keyword_id = @2";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement,
					keyword.KeywordDesc, keyword.KeywordId);
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