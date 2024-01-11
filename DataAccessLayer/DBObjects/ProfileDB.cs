using DataAccessLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.DBObjects
{
	/// <summary>
	/// Provides Database Access to the Profile table
	/// </summary>
	public static class ProfileDB
	{
		/// <summary>
		/// Retrieves all information from the Profile table
		/// </summary>
		/// <returns>List of Profile objects representing all data in the table</returns>
		public static List<Profile> GetAll()
		{
			List<Profile> profileList = new List<Profile>();
			string sqlStatement = @"
				SELECT profile_id, first_name, last_name, status_id, address_id,
					email, phone, username, password
				FROM profile 
				ORDER BY profile_id";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				Profile profile = ConvertRowToProfileObj(dr);

				profileList.Add(profile);
			}

			return profileList;
		}

		/// <summary>
		/// Create Profile Object from DataRow
		/// </summary>
		/// <param name="dr"></param>
		/// <returns></returns>
		private static Profile ConvertRowToProfileObj(DataRow dr)
		{
			Profile profile = new Profile
			{
				ProfileId = (int)dr["profile_id"],
				FirstName = dr["first_name"].ToString(),
				LastName = dr["last_name"].ToString(),
				StatusId = (int)dr["status_id"],
				AddressId = (int)dr["address_id"],
				Email = dr["email"].ToString(),
				Phone = dr["phone"].ToString(),
				UserName = dr["username"].ToString(),
				Password = dr["password"].ToString()
			};
			return profile;
		}

		/// <summary>
		/// Retrieve the specific profile record based on the primary key to table
		/// </summary>
		/// <param name="profileId">Profile Id - unique table primary key</param>
		/// <returns>Profile Record as an object</returns>
		public static Profile GetById(int profileId)
		{
			Profile profile = null;
			string sqlStatement = @"
				SELECT profile_id, first_name, last_name, status_id, address_id,
					email, phone, username, password
				FROM profile 
				WHERE profile_id = @1";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, profileId);

			if (dt.Rows.Count > 0)
			{
				profile = ConvertRowToProfileObj(dt.Rows[0]);
			}

			return profile;
		}

		/// <summary>
		/// Retrieve the specific profile record based on the unique key Username
		/// </summary>
		/// <param name="userName">Username - unique key</param>
		/// <returns>Profile Record as an object</returns>
		public static Profile GetByUserName(string userName)
		{
			Profile profile = null;
			string sqlStatement = @"
				SELECT profile_id, first_name, last_name, status_id, address_id,
					email, phone, username, password
				FROM profile 
				WHERE username = @1";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, userName);

			if (dt.Rows.Count > 0)
			{
				profile = ConvertRowToProfileObj(dt.Rows[0]);
			}

			return profile;
		}

		/// <summary>
		/// Retrieve the specific profile record based on the unique key Email
		/// </summary>
		/// <param name="email">Email - unique key</param>
		/// <returns>Profile Record as an object</returns>
		public static Profile GetByEmail(string email)
		{
			Profile profile = null;
			string sqlStatement = @"
				SELECT profile_id, first_name, last_name, status_id, address_id,
					email, phone, username, password
				FROM profile 
				WHERE email = @1";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, email);

			if (dt.Rows.Count > 0)
			{
				profile = ConvertRowToProfileObj(dt.Rows[0]);
			}

			return profile;
		}

		/// <summary>
		/// Adds a Profile record to the database
		/// </summary>
		/// <param name="profile">Profile Object</param>
		/// <returns>Updated object with the Unique Primary Key ID</returns>
		public static Profile Add(Profile profile)
		{
			string sqlStatement = @"
				INSERT INTO profile (first_name, last_name, status_id, address_id, email,
					phone, username, password)
				VALUES(@1, @2, @3, @4, @5, @6, @7, @8)";
			if (DALExec.ExecuteNonQuery(sqlStatement, profile.FirstName, profile.LastName,
				profile.StatusId, profile.AddressId, profile.Email, profile.Phone,
				profile.UserName, profile.Password) > 0)
			{
				sqlStatement = @"
                    SELECT IDENT_CURRENT('profile') AS RESULT";
				int profileID = Convert.ToInt32(DALExec.ExecuteScalar(sqlStatement));
				profile.ProfileId = profileID;
			}
			return profile;
		}

		/// <summary>
		/// Deletes the specified Profile record from the Table
		/// </summary>
		/// <param name="profile"></param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Delete(Profile profile)
		{
			string sqlStatement = @"
                DELETE FROM profile
                WHERE profile_id = @1";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement, profile.ProfileId);
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
		/// Updates the profile information
		/// </summary>
		/// <param name="profile">Profile object to update</param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Update(Profile profile)
		{
			string sqlStatement = @"
                UPDATE profile
                    SET first_name = @1,
					last_name = @2,
					status_id = @3,
					address_id = @4,
					email = @5,
					phone = @6,
					username = @7,
					password = @8
                WHERE profile_id = @9";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement,
					profile.FirstName, profile.LastName, profile.StatusId, profile.AddressId,
					profile.Email, profile.Phone, profile.UserName, profile.Password, profile.ProfileId);
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