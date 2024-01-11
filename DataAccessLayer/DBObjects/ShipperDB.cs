using DataAccessLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.DBObjects
{
	/// <summary>
	/// Provides Database Access to the Shipper table
	/// </summary>
	public static class ShipperDB
	{
		/// <summary>
		/// Retrieves all information from the Shipper table
		/// </summary>
		/// <returns>List of Shipper objects representing all data in the table</returns>
		public static List<Shipper> GetAll()
		{
			List<Shipper> shipperList = new List<Shipper>();
			string sqlStatement = @"
				SELECT shipper_id, shipping_desc, shipping_flat_rate 
				FROM shipper 
				ORDER BY shipping_desc";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				Shipper shipper = new Shipper
				{
					ShipperId = (int)dr["shipper_id"],
					ShippingDesc = dr["shipping_desc"].ToString(),
					ShippingFlatRate = (decimal)dr["shipping_flat_rate"]
				};
				shipperList.Add(shipper);
			}

			return shipperList;
		}

		/// <summary>
		/// Retrieve the specific shipper record based on the primary key to table
		/// </summary>
		/// <param name="shipperId">Shipper Id - unique table primary key</param>
		/// <returns>Shipper Record as an object</returns>
		public static Shipper GetById(int shipperId)
		{
			Shipper shipper = null;
			string sqlStatement = @"
				SELECT shipper_id, shipping_desc, shipping_flat_rate
				FROM shipper 
				WHERE shipper_id = @1";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, shipperId);

			if (dt.Rows.Count > 0)
			{
				shipper = new Shipper
				{
					ShipperId = (int)dt.Rows[0]["shipper_id"],
					ShippingDesc = dt.Rows[0]["shipping_desc"].ToString(),
					ShippingFlatRate = (decimal)dt.Rows[0]["shipping_flat_rate"]
				};

			}

			return shipper;
		}

		/// <summary>
		/// Adds a Shipper record to the database
		/// </summary>
		/// <param name="shipper">Shipper Object</param>
		/// <returns>Updated object with the Unique Primary Key ID</returns>
		public static Shipper Add(Shipper shipper)
		{
			string sqlStatement = @"
				INSERT INTO shipper (shipping_desc, shipping_flat_rate)
				VALUES(@1, @2)";
			if (DALExec.ExecuteNonQuery(sqlStatement, shipper.ShippingDesc, shipper.ShippingFlatRate) > 0)
			{
				sqlStatement = @"
                    SELECT IDENT_CURRENT('shipper') AS RESULT";
				int shipperID = Convert.ToInt32(DALExec.ExecuteScalar(sqlStatement));
				shipper.ShipperId = shipperID;
			}
			return shipper;
		}

		/// <summary>
		/// Deletes the specified Shipper record from the Table
		/// </summary>
		/// <param name="shipper"></param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Delete(Shipper shipper)
		{
			string sqlStatement = @"
                DELETE FROM shipper
                WHERE shipper_id = @1";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement, shipper.ShipperId);
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
		/// Updates the shipper description
		/// </summary>
		/// <param name="shipper">Shipper object to update</param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Update(Shipper shipper)
		{
			string sqlStatement = @"
                UPDATE shipper
                    SET shipping_desc = @1,
					shipping_flat_rate = @2
                WHERE shipper_id = @3";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement,
					shipper.ShippingDesc, shipper.ShippingFlatRate, shipper.ShipperId);
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