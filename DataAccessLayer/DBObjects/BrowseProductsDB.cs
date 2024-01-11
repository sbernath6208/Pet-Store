using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using DataAccessLayer;
using DataAccessLayer.BusinessObjects;
using Final_Pet_Store_Bernath.DataAccessLayer.BussinessObjects;

namespace DataAccessLayer.DBObjects
{
    public static class BrowseProductsDB
    {
		/// <summary>
		/// Retrieves all information from the browseProducts table
		/// </summary>
		/// <returns>List of browseProducts objects representing all data in the table</returns>
		public static List<BrowseProducts> GetAll()
		{
			List<BrowseProducts> productsList = new List<BrowseProducts>();
			string sqlStatement = @"
				SELECT product_id, category_id, status_id, name, description,
					price, image
				FROM browseProduct 
				ORDER BY product_id";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				BrowseProducts browseProduct = ConvertRowToBrowseProductsObj(dr);
				productsList.Add(browseProduct);
			}

			return productsList;
		}

		public static List<BrowseProducts> GetAllAlphaAsc()
		{
			List<BrowseProducts> productsList = new List<BrowseProducts>();
			string sqlStatement = @"
				SELECT product_id, category_id, status_id, name, description,
					price, image
				FROM browseProduct 
				ORDER BY name";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				BrowseProducts browseProduct = ConvertRowToBrowseProductsObj(dr);
				productsList.Add(browseProduct);
			}

			return productsList;
		}

		public static List<BrowseProducts> GetAllAlphaDesc()
		{
			List<BrowseProducts> productsList = new List<BrowseProducts>();
			string sqlStatement = @"
				SELECT product_id, category_id, status_id, name, description,
					price, image
				FROM browseProduct 
				ORDER BY name DESC";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				BrowseProducts browseProduct = ConvertRowToBrowseProductsObj(dr);
				productsList.Add(browseProduct);
			}

			return productsList;
		}

		public static List<BrowseProducts> GetAllPriceAsc()
		{
			List<BrowseProducts> productsList = new List<BrowseProducts>();
			string sqlStatement = @"
				SELECT product_id, category_id, status_id, name, description,
					price, image
				FROM browseProduct 
				ORDER BY price";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				BrowseProducts browseProduct = ConvertRowToBrowseProductsObj(dr);
				productsList.Add(browseProduct);
			}

			return productsList;
		}

		public static List<BrowseProducts> GetAllPriceDesc()
		{
			List<BrowseProducts> productsList = new List<BrowseProducts>();
			string sqlStatement = @"
				SELECT product_id, category_id, status_id, name, description,
					price, image
				FROM browseProduct 
				ORDER BY price DESC";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				BrowseProducts browseProduct = ConvertRowToBrowseProductsObj(dr);
				productsList.Add(browseProduct);
			}

			return productsList;
		}

		/// <summary>
		/// Create browseProducts Object from DataRow
		/// </summary>
		/// <param name="dr">DataRow</param>
		/// <returns>browseProducts Object Instance</returns>
		private static BrowseProducts ConvertRowToBrowseProductsObj(DataRow dr)
		{
			BrowseProducts browseProduct = new BrowseProducts
			{
				ProductId = (int)dr["product_id"],
				CategoryId = (int)dr["category_id"],
				StatusId = (int)dr["status_id"],

				Name = dr["name"].ToString(),
				Description = dr["description"].ToString(),
				Price = (decimal)dr["price"],
				Image = (string)dr["image"].ToString()
			};

			return browseProduct;
		}

		/// <summary>
		/// Retrieve the specific browseProducts record based on the primary key to table
		/// </summary>
		/// <param name="productId">browseProducts Id - unique table primary key</param>
		/// <returns>browseProducts Record as an object</returns>
		public static BrowseProducts GetById(int productId)
		{
			BrowseProducts browseProduct = null;
			string sqlStatement = @"
				SELECT product_id, category_id, status_id, name, description,
					price, image
				FROM browseProduct 
				WHERE product_id = @1";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, productId);

			if (dt.Rows.Count > 0)
			{
				browseProduct = ConvertRowToBrowseProductsObj(dt.Rows[0]);
			}

			return browseProduct;
		}

		public static BrowseProducts GetByName(string name)
		{
			BrowseProducts browseProduct = null;
			string sqlStatement = @"
				SELECT product_id, category_id, status_id, name, description,
					price, image
				FROM browseProduct 
				WHERE name = @1";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, name);

			if (dt.Rows.Count > 0)
			{
				browseProduct = ConvertRowToBrowseProductsObj(dt.Rows[0]);
			}

			return browseProduct;
		}

		/// <summary>
		/// Adds a browseProducts record to the database
		/// </summary>
		/// <param name="browseProduct">browseProducts Object</param>
		/// <returns>Updated object with the Unique Primary Key ID</returns>
		public static BrowseProducts Add(BrowseProducts browseProduct)
		{
			string sqlStatement = @"
				INSERT INTO browseProduct (category_id, status_id, name, 
					description, price, image)
				VALUES(@1, @2, @3, @4, @5, @6, @7, @8)";
			if (DALExec.ExecuteNonQuery(sqlStatement, browseProduct.CategoryId, browseProduct.StatusId,
				browseProduct.Name, browseProduct.Description, browseProduct.Price,
				browseProduct.Image) > 0)
			{
				sqlStatement = @"
                    SELECT IDENT_CURRENT('browseProduct') AS RESULT";
				int productID = Convert.ToInt32(DALExec.ExecuteScalar(sqlStatement));
				browseProduct.ProductId = productID;
			}
			return browseProduct;
		}

		/// <summary>
		/// Deletes the specified browseProducts record from the Table
		/// </summary>
		/// <param name="browseProduct"></param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Delete(BrowseProducts browseProduct)
		{
			string sqlStatement = @"
                DELETE FROM browseProduct
                WHERE product_id = @1";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement, browseProduct.ProductId);
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
		/// Updates the browseProducts information
		/// </summary>
		/// <param name="browseProduct">browseProducts object to update</param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Update(BrowseProducts browseProduct)
		{
			string sqlStatement = @"
                UPDATE browseProduct
                    SET category_id = @1,
					status_id = @2,
					
					name = @3,
					description = @4,
					price = @5,
					image = @6
                WHERE product_id = @7";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement,
					browseProduct.CategoryId, browseProduct.StatusId, browseProduct.Name,
					browseProduct.Description, browseProduct.Price, browseProduct.Image, browseProduct.ProductId);
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
