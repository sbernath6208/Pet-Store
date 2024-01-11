using DataAccessLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.DBObjects
{
	/// <summary>
	/// Provides Database Access to the Address table
	/// </summary>
	public static class AddressDB
	{
		/// <summary>
		/// Retrieves all information from the Address table
		/// </summary>
		/// <returns>List of Address objects representing all data in the table</returns>
		public static List<Address> GetAll()
		{
			List<Address> addressList = new List<Address>();
			string sqlStatement = @"
				SELECT address_id, address_line_1, address_line_2, city, state_abbr, postal_code 
				FROM address 
				ORDER BY address_id";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				Address address = new Address
				{
					AddressId = (int)dr["address_id"],
					AddressLine1 = dr["address_line_1"].ToString(),
					AddressLine2 = dr["address_line_2"].ToString(),
					City = dr["city"].ToString(),
					StateAbbr = dr["state_abbr"].ToString(),
					PostalCode = dr["postal_code"].ToString()
				};

				addressList.Add(address);
			}

			return addressList;
		}

		/// <summary>
		/// Retrieve the specific address record based on the primary key to table
		/// </summary>
		/// <param name="addressId">Address Id - unique table primary key</param>
		/// <returns>Address Record as an object</returns>
		public static Address GetById(int addressId) // Address.GetById(...); 
		{
			Address address = null;
			string sqlStatement = @"
				SELECT address_id, address_line_1, address_line_2, city, state_abbr, postal_code 
				FROM address 
				WHERE address_id = @1";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, addressId);

			if (dt.Rows.Count > 0)
			{
				address = new Address
				{
					AddressId = (int)dt.Rows[0]["address_id"],
					AddressLine1 = dt.Rows[0]["address_line_1"].ToString(),
					AddressLine2 = dt.Rows[0]["address_line_2"].ToString(),
					City = dt.Rows[0]["city"].ToString(),
					StateAbbr = dt.Rows[0]["state_abbr"].ToString(),
					PostalCode = dt.Rows[0]["postal_code"].ToString()
				};
			}

			return address;
		}

		

		/// <summary>
		/// Adds a Address record to the database
		/// </summary>
		/// <param name="address">Address Object</param>
		/// <returns>Updated object with the Unique Primary Key ID</returns>
		public static Address Add(Address address)
		{
			string sqlStatement = @"
				INSERT INTO address (address_line_1, address_line_2, city, state_abbr, postal_code)
				VALUES(@1, @2, @3, @4, @5)";
			if (DALExec.ExecuteNonQuery(sqlStatement, address.AddressLine1, address.AddressLine2,
				address.City, address.StateAbbr, address.PostalCode) > 0)
			{
				sqlStatement = @"
                    SELECT IDENT_CURRENT('address') AS RESULT";
				int addressID = Convert.ToInt32(DALExec.ExecuteScalar(sqlStatement));
				address.AddressId = addressID;
			}
			return address;
		}

		/// <summary>
		/// Deletes the specified Address record from the Table
		/// </summary>
		/// <param name="address"></param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Delete(Address address)
		{
			string sqlStatement = @"
                DELETE FROM address
                WHERE address_id = @1";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement, address.AddressId);
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
		/// Updates the address information
		/// </summary>
		/// <param name="address">Address object to update</param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Update(Address address)
		{
			string sqlStatement = @"
                UPDATE address
                    SET address_line_1 = @1,
					address_line_2 = @2,
					city = @3,
					state_abbr = @4,
					postal_code = @5
                WHERE address_id = @6";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement,
					address.AddressLine1, address.AddressLine2, address.City, address.StateAbbr,
					address.PostalCode, address.AddressId);
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