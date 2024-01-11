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
	/// Provides Database Access to the Order table
	/// </summary>
	public static class OrderDB
	{
		/// <summary>
		/// Retrieves all information from the Order table
		/// </summary>
		/// <returns>List of Order objects representing all data in the table</returns>
		public static List<Order> GetAll()
		{
			List<Order> orderList = new List<Order>();
			string sqlStatement = @"
				SELECT order_no, status_id, username, billing_first_name, billing_last_name,
					credit_card_no, bill_address_id, shipper_id, ship_to_first_name,
					ship_to_last_name, ship_to_address_id, sales_tax, shipping_cost, total_cost
				FROM orders 
				ORDER BY order_no";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				Order order = ConvertRowToOrderObj(dr);
				orderList.Add(order);
			}

			return orderList;
		}

		/// <summary>
		/// Create Order Object from DataRow
		/// </summary>
		/// <param name="dr">DataRow</param>
		/// <returns>Order Object Instance</returns>
		private static Order ConvertRowToOrderObj(DataRow dr)
		{
			Order order = new Order
			{
				OrderNo = (int)dr["order_no"],
				StatusId = (int)dr["status_id"],
				BillingFirstName = dr["billing_first_name"].ToString(),
				BillingLastName = dr["billing_last_name"].ToString(),
				CreditCardNo = dr["credit_card_no"].ToString(),
				BillAddressId = (int)dr["bill_address_id"],
				ShipperId = (int)dr["shipper_id"],
				ShipToFirstName = dr["ship_to_first_name"].ToString(),
				ShipToLastName = dr["ship_to_last_name"].ToString(),
				ShipToAddressId = (int)dr["ship_to_address_id"],
				SalesTax = (decimal)dr["sales_tax"],
				ShippingCost = (decimal)dr["shipping_cost"],
				TotalCost = (decimal)dr["total_cost"]
			};

			return order;
		}

		/// <summary>
		/// Retrieve the specific order record based on the primary key to table
		/// </summary>
		/// <param name="orderNo">Order No - unique table primary key</param>
		/// <returns>Order Record as an object</returns>
		public static Order GetById(int orderNo)
		{
			Order order = null;
			string sqlStatement = @"
				SELECT order_no, status_id, username, billing_first_name, billing_last_name,
					credit_card_no, bill_address_id, shipper_id, ship_to_first_name,
					ship_to_last_name, ship_to_address_id, sales_tax, shipping_cost, total_cost
				FROM orders 
				WHERE order_no = @1";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, orderNo);

			if (dt.Rows.Count > 0)
			{
				order = ConvertRowToOrderObj(dt.Rows[0]);
			}

			return order;
		}

		public static List<Order> GetByUserName(string userName)
		{
			List<Order> orderList = new List<Order>();
			//Order order = null;
			string sqlStatement = @"
				SELECT order_no, status_id, username, billing_first_name, billing_last_name,
					credit_card_no, bill_address_id, shipper_id, ship_to_first_name,
					ship_to_last_name, ship_to_address_id, sales_tax, shipping_cost, total_cost
				FROM orders 
				WHERE username = @1
				ORDER BY order_no";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, userName);

			foreach (DataRow dr in dt.Rows)
			{
				Order order = ConvertRowToOrderObj(dr);
				orderList.Add(order);
			}

			return orderList;	
		}

		public static Order GetByAddress(int bill_address_id)
		{
			Order order = null;
			string sqlStatement = @"
				SELECT order_no, status_id, username, billing_first_name, billing_last_name,
					credit_card_no, bill_address_id, shipper_id, ship_to_first_name,
					ship_to_last_name, ship_to_address_id, sales_tax, shipping_cost, total_cost
				FROM orders 
				WHERE order_no = @1";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, bill_address_id);

			if (dt.Rows.Count > 0)
			{
				order = ConvertRowToOrderObj(dt.Rows[0]);
			}

			return order;
		}

		/// <summary>
		/// Adds a Order record to the database
		/// </summary>
		/// <param name="order">Order Object</param>
		/// <returns>Updated object with the Unique Primary Key ID</returns>
		public static Order Add(Order order)
		{
			string sqlStatement = @"
				INSERT INTO orders (status_id, username, billing_first_name, billing_last_name, 
					credit_card_no, bill_address_id, shipper_id, ship_to_first_name,
					ship_to_last_name, ship_to_address_id, sales_tax, shipping_cost, total_cost)
				VALUES(@1, @2, @3, @4, @5, @6, @7, @8, @9, @10, @11, @12, @13)";
			if (DALExec.ExecuteNonQuery(sqlStatement, order.StatusId, order.UserName,
				order.BillingFirstName, order.BillingLastName, order.CreditCardNo, order.BillAddressId,
				order.ShipperId, order.ShipToFirstName, order.ShipToLastName, 
				order.ShipToAddressId, order.SalesTax, order.ShippingCost, order.TotalCost) > 0)
			{
				sqlStatement = @"
                    SELECT IDENT_CURRENT('orders') AS RESULT";
				int orderNo = Convert.ToInt32(DALExec.ExecuteScalar(sqlStatement));
				order.OrderNo = orderNo;
			}
			return order;
		}

		/// <summary>
		/// Deletes the specified Order record from the Table
		/// </summary>
		/// <param name="order"></param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Delete(Order order)
		{
			string sqlStatement = @"
                DELETE FROM orders
                WHERE order_no = @1";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement, order.OrderNo);
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
		/// Updates the order information
		/// </summary>
		/// <param name="order">Order object to update</param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Update(Order order)
		{
			string sqlStatement = @"
                UPDATE orders
                    SET status_id = @1,
					username = @2,
					billing_first_name = @3,
					billing_last_name = @4,
					credit_card_no = @5,
					bill_address_id = @6,
					shipper_id = @7,
					ship_to_first_name = @8,
					ship_to_last_name = @9,
					ship_to_address_id = @10,
					sales_tax = @11,
					shipping_cost = @12,
					total_cost = @13
                WHERE order_no = @14";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement,
					order.StatusId, order.UserName, order.BillingFirstName,
					order.BillingLastName, order.CreditCardNo, order.BillAddressId, 
					order.ShippingCost, order.ShipToFirstName, order.ShipToLastName,
					order.ShipToAddressId, order.SalesTax, order.ShippingCost,
					order.TotalCost, order.OrderNo);
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