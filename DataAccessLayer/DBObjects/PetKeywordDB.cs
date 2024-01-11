using DataAccessLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.DBObjects
{
	/// <summary>
	/// Provides Database Access to the PetKeyword table
	/// </summary>
	public static class PetKeywordDB
	{
		/// <summary>
		/// Retrieves all information from the PetKeyword table
		/// </summary>
		/// <returns>List of PetKeyword objects representing all data in the table</returns>
		public static List<PetKeyword> GetAll()
		{
			string sqlStatement = @"
				SELECT pet_id, keyword_id 
				FROM pet_keyword 
				ORDER BY pet_id, keyword_id";

			return GetPetKeywordList(sqlStatement);
		}

		private static List<PetKeyword> GetPetKeywordList(string sqlStatement, params object[] args)
		{
			List<PetKeyword> petKeywordList = new List<PetKeyword>();
			DataTable dt = DALExec.ExecuteQuery(sqlStatement, args);

			foreach (DataRow dr in dt.Rows)
			{
				PetKeyword petKeyword = new PetKeyword
				{
					PetId = (int)dr["pet_id"],
					KeywordId = (int)dr["keyword_id"]
				};
				petKeywordList.Add(petKeyword);
			}
			return petKeywordList;
		}

		/// <summary>
		/// Retrieve the specific pet_keyword record based on the primary key to table
		/// </summary>
		/// <param name="petId">Pet Id</param>
		/// <returns>List of Pet Keywords</returns>
		public static List<PetKeyword> GetByPetId(int petId)
		{
			string sqlStatement = @"
				SELECT pet_id, keyword_id 
				FROM pet_keyword 
				WHERE pet_id = @1
				ORDER BY keyword_id";

			return GetPetKeywordList(sqlStatement, petId);
		}

		/// <summary>
		/// Adds a PetKeyword record to the database
		/// </summary>
		/// <param name="petKeyword">PetKeyword Object</param>
		/// <returns>Returns boolean indicating if successful</returns>
		public static bool Add(PetKeyword petKeyword)
		{
			string sqlStatement = @"
				INSERT INTO pet_keyword (pet_id, keyword_id)
				VALUES(@1, @2)";
			int rowsAffected = DALExec.ExecuteNonQuery(sqlStatement, petKeyword.PetId, petKeyword.KeywordId);
			
			return (rowsAffected > 0);
		}

		/// <summary>
		/// Deletes the specified PetKeyword record from the Table
		/// </summary>
		/// <param name="petKeyword">Pet Keyword Object Instance</param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Delete(PetKeyword petKeyword)
		{
			string sqlStatement = @"
                DELETE FROM pet_keyword
                WHERE pet_id = @1
				AND keyword_id = @2";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement, petKeyword.PetId, petKeyword.KeywordId);
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