using DataAccessLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.DBObjects
{
	/// <summary>
	/// Provides Database Access to the Category table
	/// </summary>
	public static class CategoryDB
	{
		/// <summary>
		/// Retrieves all information from the Category table
		/// </summary>
		/// <returns>List of Category objects representing all data in the table</returns>
		public static List<Category> GetAll()
		{
			List<Category> categoryList = new List<Category>();
			string sqlStatement = @"
				SELECT category_id, category_desc 
				FROM category 
				ORDER BY category_desc";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				Category category = new Category();
				category.CategoryId = (int)dr["category_id"];
				category.CategoryDesc = dr["category_desc"].ToString();
			}

			return categoryList;
		}

		/// <summary>
		/// Retrieve the specific category record based on the primary key to table
		/// </summary>
		/// <param name="categoryId">Category Id - unique table primary key</param>
		/// <returns>Breed Record as an object</returns>
		public static Category GetById(int categoryId)
		{
			Category category = null;
			string sqlStatement = @"
				SELECT category_id, category_desc 
				FROM category 
				WHERE category_id = @1";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, categoryId);

			if (dt.Rows.Count > 0)
			{
				category = new Category();
				category.CategoryId = (int)dt.Rows[0]["category_id"];
				category.CategoryDesc = dt.Rows[0]["category_desc"].ToString();

			}

			return category;
		}

		/// <summary>
		/// Adds a Category record to the database
		/// </summary>
		/// <param name="category">Category Object</param>
		/// <returns>Updated object with the Unique Primary Key ID</returns>
		public static Category Add(Category category)
		{
			string sqlStatement = @"
				INSERT INTO category (category_desc)
				VALUES(@1)";
			if (DALExec.ExecuteNonQuery(sqlStatement, category.CategoryDesc) > 0)
			{
				sqlStatement = @"
                    SELECT IDENT_CURRENT('category') AS RESULT";
				int breedID = Convert.ToInt32(DALExec.ExecuteScalar(sqlStatement));
				category.CategoryId = breedID;
			}
			return category;
		}

		/// <summary>
		/// Deletes the specified Category record from the Table
		/// </summary>
		/// <param name="category"></param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Delete(Category category)
		{
			string sqlStatement = @"
                DELETE FROM category
                WHERE category_id = @1";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement, category.CategoryId);
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
		/// Updates the category description
		/// </summary>
		/// <param name="category">Category object to update</param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Update(Category category)
		{
			string sqlStatement = @"
                UPDATE category
                    SET category_desc = @1
                WHERE category_id = @2";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement,
					category.CategoryDesc, category.CategoryId);
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