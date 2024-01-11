using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using DataAccessLayer;
using DataAccessLayer.BusinessObjects;
using Final_Pet_Store_Bernath.DataAccessLayer.BussinessObjects;

namespace Final_Pet_Store_Bernath.DataAccessLayer.DBObjects
{
    public static class SalesProductsDB
    {
		/// <summary>
		/// Retrieves all information from the sales table
		/// </summary>
		/// <returns>List of sales objects representing all data in the table</returns>
		public static List<Sales> GetAll()
		{
			List<Sales> salesList = new List<Sales>();
			string sqlStatement = @"
				SELECT sales_id, category_id, status_id, name, description,
					price, image
				FROM sale 
				ORDER BY sales_id";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				Sales sale = ConvertRowToSalesObj(dr);
				salesList.Add(sale);
			}

			return salesList;
		}

		public static List<Sales> GetAllAlphaAsc()
		{
			List<Sales> salesList = new List<Sales>();
			string sqlStatement = @"
				SELECT sales_id, category_id, status_id, name, description,
					price, image
				FROM sale 
				ORDER BY name";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				Sales sale = ConvertRowToSalesObj(dr);
				salesList.Add(sale);
			}

			return salesList;
		}

		public static List<Sales> GetAllAlphaDesc()
		{
			List<Sales> salesList = new List<Sales>();
			string sqlStatement = @"
				SELECT sales_id, category_id, status_id, name, description,
					price, image
				FROM sale 
				ORDER BY name DESC";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				Sales sale = ConvertRowToSalesObj(dr);
				salesList.Add(sale);
			}

			return salesList;
		}

		public static List<Sales> GetAllPriceAsc()
		{
			List<Sales> salesList = new List<Sales>();
			string sqlStatement = @"
				SELECT sales_id, category_id, status_id, name, description,
					price, image
				FROM sale 
				ORDER BY price";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				Sales sale = ConvertRowToSalesObj(dr);
				salesList.Add(sale);
			}

			return salesList;
		}

		public static List<Sales> GetAllPriceDesc()
		{
			List<Sales> salesList = new List<Sales>();
			string sqlStatement = @"
				SELECT sales_id, category_id, status_id, name, description,
					price, image
				FROM sale 
				ORDER BY price DESC";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				Sales sale = ConvertRowToSalesObj(dr);
				salesList.Add(sale);
			}

			return salesList;
		}

		/// <summary>
		/// Create sales Object from DataRow
		/// </summary>
		/// <param name="dr">DataRow</param>
		/// <returns>sales Object Instance</returns>
		private static Sales ConvertRowToSalesObj(DataRow dr)
		{
			Sales sale = new Sales
			{
				SalesId = (int)dr["sales_id"],
				CategoryId = (int)dr["category_id"],
				StatusId = (int)dr["status_id"],
				
				SalesName = dr["name"].ToString(),
				Description = dr["description"].ToString(),
				Price = (decimal)dr["price"],
				Image = (string)dr["image"].ToString()
			};

			return sale;
		}

		/// <summary>
		/// Retrieve the specific sales record based on the primary key to table
		/// </summary>
		/// <param name="saleId">sales Id - unique table primary key</param>
		/// <returns>sales Record as an object</returns>
		public static Sales GetById(int salesId)
		{
			Sales sale = null;
			string sqlStatement = @"
				SELECT sales_id, category_id, status_id, name, description,
					price, image
				FROM sale 
				WHERE sales_id = @1";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, salesId);

			if (dt.Rows.Count > 0)
			{
				sale = ConvertRowToSalesObj(dt.Rows[0]);
			}

			return sale;
		}

		public static Sales GetByName(string name)
		{
			Sales sale = null;
			string sqlStatement = @"
				SELECT sales_id, category_id, status_id, name, description,
					price, image
				FROM sale 
				WHERE name = @1";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, name);

			if (dt.Rows.Count > 0)
			{
				sale = ConvertRowToSalesObj(dt.Rows[0]);
			}

			return sale;
		}

		/// <summary>
		/// Adds a sales record to the database
		/// </summary>
		/// <param name="sale">sales Object</param>
		/// <returns>Updated object with the Unique Primary Key ID</returns>
		public static Sales Add(Sales sale)
		{
			string sqlStatement = @"
				INSERT INTO sale (category_id, status_id, name, 
					description, price, image)
				VALUES(@1, @2, @3, @4, @5, @6, @7, @8)";
			if (DALExec.ExecuteNonQuery(sqlStatement, sale.CategoryId, sale.StatusId,
				sale.SalesName, sale.Description, sale.Price, sale.Image) > 0)
			{
				sqlStatement = @"
                    SELECT IDENT_CURRENT('sale') AS RESULT";
				int salesID = Convert.ToInt32(DALExec.ExecuteScalar(sqlStatement));
				sale.SalesId = salesID;
			}
			return sale;
		}

		/// <summary>
		/// Deletes the specified sales record from the Table
		/// </summary>
		/// <param name="sale"></param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Delete(Sales sale)
		{
			string sqlStatement = @"
                DELETE FROM sale
                WHERE sales_id = @1";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement, sale.SalesId);
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
		/// Updates the sales information
		/// </summary>
		/// <param name="sale">sales object to update</param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Update(Sales sale)
		{
			string sqlStatement = @"
                UPDATE sale
                    SET category_id = @1,
					status_id = @2,
					
					name = @3,
					description = @4,
					price = @5,
					image = @6
					
                WHERE sales_id = @7";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement,
					sale.CategoryId, sale.StatusId, sale.SalesName,
					sale.Description, sale.Price, sale.Image, sale.SalesId);
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
