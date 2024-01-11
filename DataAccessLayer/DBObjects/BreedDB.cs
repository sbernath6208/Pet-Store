using DataAccessLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.DBObjects
{
	/// <summary>
	/// Provides Database Access to the Breed table
	/// </summary>
	public static class BreedDB
	{
		/// <summary>
		/// Retrieves all information from the Breed table
		/// </summary>
		/// <returns>List of Breed objects representing all data in the table</returns>
		public static List<Breed> GetAll()
		{
			List<Breed> breedList = new List<Breed>();
			string sqlStatement = @"
				SELECT breed_id, breed_desc 
				FROM breed 
				ORDER BY breed_desc";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				Breed breed = new Breed
				{
					BreedId = (int)dr["breed_id"],
					BreedDesc = dr["breed_desc"].ToString()
				};
			}

			return breedList;
		}

		/// <summary>
		/// Retrieve the specific breed record based on the primary key to table
		/// </summary>
		/// <param name="breedId">Breed Id - unique table primary key</param>
		/// <returns>Breed Record as an object</returns>
		public static Breed GetById(int breedId)
		{
			Breed breed = null;
			string sqlStatement = @"
				SELECT breed_id, breed_desc 
				FROM breed 
				WHERE breed_id = @1";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, breedId);

			if (dt.Rows.Count > 0)
			{
				breed = new Breed
				{
					BreedId = (int)dt.Rows[0]["breed_id"],
					BreedDesc = dt.Rows[0]["breed_desc"].ToString()
				};

			}

			return breed;
		}

		public static Breed GetByDesc(string desc)
		{
			Breed breed = null;
			string sqlStatement = @"
				SELECT breed_id, breed_desc 
				FROM breed 
				WHERE breed_desc = @1";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, desc);

			if (dt.Rows.Count > 0)
			{
				breed = new Breed
				{
					BreedId = (int)dt.Rows[0]["breed_id"],
					BreedDesc = dt.Rows[0]["breed_desc"].ToString()
				};

			}

			return breed;
		}

		/// <summary>
		/// Adds a Breed record to the database
		/// </summary>
		/// <param name="breed">Breed Object</param>
		/// <returns>Updated object with the Unique Primary Key ID</returns>
		public static Breed Add(Breed breed)
		{
			string sqlStatement = @"
				INSERT INTO breed (breed_desc)
				VALUES(@1)";
			if (DALExec.ExecuteNonQuery(sqlStatement, breed.BreedDesc) > 0)
			{
				sqlStatement = @"
                    SELECT IDENT_CURRENT('breed') AS RESULT";
				int breedID = Convert.ToInt32(DALExec.ExecuteScalar(sqlStatement));
				breed.BreedId = breedID;
			}
			return breed;
		}

		/// <summary>
		/// Deletes the specified Breed record from the Table
		/// </summary>
		/// <param name="breed"></param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Delete(Breed breed)
		{
			string sqlStatement = @"
                DELETE FROM breed
                WHERE breed_id = @1";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement, breed.BreedId);
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
		/// Updates the breed description
		/// </summary>
		/// <param name="breed">Breed object to update</param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Update(Breed breed)
		{
			string sqlStatement = @"
                UPDATE breed
                    SET breed_desc = @1
                WHERE breed_id = @2";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement, 
					breed.BreedDesc, breed.BreedId);
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