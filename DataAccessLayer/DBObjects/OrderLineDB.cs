using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataAccessLayer;
using DataAccessLayer.BusinessObjects;


namespace DataAccessLayer.DBObjects
{
	/// <summary>
	/// Provides Database Access to the OrderLine table
	/// </summary>
	public static class OrderLineDB
	{
		/// <summary>
		/// Retrieves all information from the OrderLine table
		/// </summary>
		/// <returns>List of OrderLine objects representing all data in the table</returns>
		public static List<OrderLine> GetAll()
		{
			List<OrderLine> orderLineList = new List<OrderLine>();
			string sqlStatement = @"
				SELECT order_no, line_no, status_id, pet_id, product_id, sales_id, qty, 
					price, extended_price, ship_date
				FROM order_line 
				ORDER BY order_no, line_no";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				OrderLine orderLine = ConvertRowToOrderLineObj(dr);
				orderLineList.Add(orderLine);
			}

			return orderLineList;
		}

		/// <summary>
		/// Create OrderLine Object from DataRow
		/// </summary>
		/// <param name="dr">DataRow</param>
		/// <returns>OrderLine Object Instance</returns>
		private static OrderLine ConvertRowToOrderLineObj(DataRow dr)
		{
			OrderLine orderLine = new OrderLine
			{
				OrderNo = (int)dr["order_no"],
				LineNo = (int)dr["line_no"],
				StatusId = (int)dr["status_id"],
				PetId = (int)dr["pet_id"],
				ProductId = (int)dr["product_id"], 
				SalesId = (int)dr["sales_id"], 
				Qty = (int)dr["qty"],
				Price = (decimal)dr["price"],
				ExtendedPrice = (decimal)dr["extended_price"]
			};
			if (dr["ship_date"] != System.DBNull.Value)
				orderLine.ShipDate = (DateTime)dr["ship_date"];

			return orderLine;
		}

		/// <summary>
		/// Retrieve the specific order record lines
		/// </summary>
		/// <param name="orderNo">Order No - part of the table primary key</param>
		/// <returns>List of Order Line Record</returns>
		public static List<OrderLine> GetByOrderNo(int orderNo)
		{
			List<OrderLine> orderLineList = new List<OrderLine>();
			string sqlStatement = @"
				SELECT order_no, line_no, status_id, pet_id,  product_id, sales_id, qty, 
					price, extended_price, ship_date
				FROM order_line 
				WHERE order_no = @1 
				ORDER BY line_no";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, orderNo);

			foreach (DataRow dr in dt.Rows)
			{
				OrderLine orderLine = ConvertRowToOrderLineObj(dr);
				orderLineList.Add(orderLine);
			}

			return orderLineList;
		}

		/// <summary>
		/// Retrieve the specific order line record based on the primary key to table
		/// </summary>
		/// <param name="orderNo">Order No - part of the composite primary key</param>
		/// <param name="lineNo">Line No - part of the composite primary key</param>
		/// <returns>Order Line Record as an object</returns>
		public static OrderLine GetByOrderAndLine(int orderNo, int lineNo)
		{
			string sqlStatement = @"
				SELECT order_no, line_no, status_id, pet_id,  product_id, sales_id, qty, 
					price, extended_price, ship_date
				FROM order_line 
				WHERE order_no = @1
				AND line_no = @2";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, orderNo, lineNo);

			OrderLine orderLine = null;
			if (dt.Rows.Count > 0)
				orderLine = ConvertRowToOrderLineObj(dt.Rows[0]);

			return orderLine;
		}

		/// <summary>
		/// Adds an OrderLine record to the database
		/// </summary>
		/// <param name="orderLine">OrderLine Object</param>
		/// <returns>Updated OrderLine Object with populated line Number</returns>
		public static OrderLine Add(OrderLine orderLine)
		{
			string sqlStatement = @"
				SELECT COALESCE(MAX(line_no),0) + 1 
				FROM order_line 
				WHERE order_no = @1";

			int lineNo = Convert.ToInt32(DALExec.ExecuteScalar(sqlStatement, orderLine.OrderNo));
			orderLine.LineNo = lineNo;

			// If the date does not have a value, the insert will fail if we specify the parameter to insert
			if (orderLine.ShipDate.HasValue)
			{
				sqlStatement = @"
				INSERT INTO order_line (order_no, line_no, status_id,
					pet_id,  product_id, sales_id, qty, price, extended_price, ship_date) 
				VALUES(@1, @2, @3, @4, @5, @6, @7, @8, @9, @10)";
				int affectedRows = DALExec.ExecuteNonQuery(sqlStatement, orderLine.OrderNo, orderLine.LineNo,
					orderLine.StatusId, orderLine.PetId, orderLine.ProductId, orderLine.SalesId, orderLine.Qty, orderLine.Price,
					orderLine.ExtendedPrice, orderLine.ShipDate);
			}
			else
			{
				sqlStatement = @"
					INSERT INTO order_line (order_no, line_no, status_id,
						pet_id,  product_id, sales_id, qty, price, extended_price) 
					VALUES(@1, @2, @3, @4, @5, @6, @7, @8, @9)";
				int affectedRows = DALExec.ExecuteNonQuery(sqlStatement, orderLine.OrderNo, orderLine.LineNo,
					orderLine.StatusId, orderLine.PetId, orderLine.ProductId, orderLine.SalesId, orderLine.Qty, orderLine.Price,
					orderLine.ExtendedPrice);
			}

			return orderLine;
		}

		/// <summary>
		/// Deletes the specified OrderLine record from the Table
		/// </summary>
		/// <param name="orderLine"></param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Delete(OrderLine orderLine)
		{
			string sqlStatement = @"
                DELETE FROM order_line
                WHERE order_no = @1
				AND line_no = @2";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement, orderLine.OrderNo, orderLine.LineNo);
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
		/// Updates the OrderLine information
		/// </summary>
		/// <param name="orderLine">OrderLine object to update</param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Update(OrderLine orderLine)
		{
			string sqlStatement = "";
			if (orderLine.PetId > 0)
				sqlStatement = @"
					UPDATE order_line
						SET status_id = @1,
						pet_id = @2, 
						qty = @3,
						price = @4,
						extended_price = @5,
						ship_date = @6
					WHERE order_no = @7
					AND line_no = @8";
			else if (orderLine.ProductId > 0)
				sqlStatement = @"
					UPDATE order_line
						SET status_id = @1,
						product_id = @2, 
						qty = @3,
						price = @4,
						extended_price = @5,	
						ship_date = @6
					WHERE order_no = @7
					AND line_no = @8";
			else if(orderLine.SalesId > 0)
				sqlStatement = @"
					UPDATE order_line
						SET status_id = @1,
						sales_id = @2, 
						qty = @3,
						price = @4,
						extended_price = @5,	
						ship_date = @6
					WHERE order_no = @7
					AND line_no = @8";


			try
			{
				int count = 0;
				if (orderLine.PetId > 0)
					count = DALExec.ExecuteNonQuery(sqlStatement,
						orderLine.StatusId, orderLine.PetId, orderLine.Qty,
						orderLine.Price, orderLine.ExtendedPrice, orderLine.ShipDate,
						orderLine.OrderNo, orderLine.LineNo);
				else if (orderLine.ProductId > 0)
					count = DALExec.ExecuteNonQuery(sqlStatement,
						orderLine.StatusId, orderLine.ProductId, orderLine.Qty,
						orderLine.Price, orderLine.ExtendedPrice, orderLine.ShipDate, 
						orderLine.OrderNo, orderLine.LineNo);
				else if (orderLine.SalesId > 0)
					count = DALExec.ExecuteNonQuery(sqlStatement,
						orderLine.StatusId, orderLine.SalesId, orderLine.Qty,
						orderLine.Price, orderLine.ExtendedPrice, orderLine.ShipDate,
						orderLine.OrderNo, orderLine.LineNo);
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