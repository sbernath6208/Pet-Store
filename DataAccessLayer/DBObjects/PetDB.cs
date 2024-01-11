using DataAccessLayer.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer.DBObjects
{
	/// <summary>
	/// Provides Database Access to the Pet table
	/// </summary>
	public static class PetDB
	{
		
		public static List<Pet> GetAllAlphaAsc()
		{
			List<Pet> petList = new List<Pet>();
			string sqlStatement = @"
				SELECT pet_id, category_id, status_id, breed_id, name, description,
					price, image
				FROM pet 
				ORDER BY name";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				Pet pet = ConvertRowToPetObj(dr);
				petList.Add(pet);
			}

			return petList;
		}

		public static List<Pet> GetAllAlphaDesc()
		{
			List<Pet> petList = new List<Pet>();
			string sqlStatement = @"
				SELECT pet_id, category_id, status_id, breed_id, name, description,
					price, image
				FROM pet 
				ORDER BY name DESC";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				Pet pet = ConvertRowToPetObj(dr);
				petList.Add(pet);
			}

			return petList;
		}

		public static List<Pet> GetAllCostAsc()
		{
			List<Pet> petList = new List<Pet>();
			string sqlStatement = @"
				SELECT pet_id, category_id, status_id, breed_id, name, description,
					price, image
				FROM pet 
				ORDER BY price";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				Pet pet = ConvertRowToPetObj(dr);
				petList.Add(pet);
			}

			return petList;
		}

		public static List<Pet> GetAllCostDesc()
		{
			List<Pet> petList = new List<Pet>();
			string sqlStatement = @"
				SELECT pet_id, category_id, status_id, breed_id, name, description,
					price, image
				FROM pet 
				ORDER BY price DESC";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				Pet pet = ConvertRowToPetObj(dr);
				petList.Add(pet);
			}

			return petList;
		}

		/// <summary>
		/// Retrieves all information from the Pet table
		/// </summary>
		/// <returns>List of Pet objects representing all data in the table</returns>
		public static List<Pet> GetAll()
		{
			List<Pet> petList = new List<Pet>();
			string sqlStatement = @"
				SELECT pet_id, category_id, status_id, breed_id, name, description,
					price, image
				FROM pet 
				ORDER BY pet_id";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement);

			foreach (DataRow dr in dt.Rows)
			{
				Pet pet = ConvertRowToPetObj(dr);
				petList.Add(pet);
			}

			return petList;
		}

		/// <summary>
		/// Retrieves the data from the database to populate the list
		/// </summary>
		/*
		private static void Fill()
		{
			petList = this.GetAll();
		}
		*/

		/// <summary>
		/// Create Pet Object from DataRow
		/// </summary>
		/// <param name="dr">DataRow</param>
		/// <returns>Pet Object Instance</returns>
		private static Pet ConvertRowToPetObj(DataRow dr)
		{
			Pet pet = new Pet
			{
				PetId = (int)dr["pet_id"],
				CategoryId = (int)dr["category_id"],
				StatusId = (int)dr["status_id"],
				BreedId = (int)dr["breed_id"],
				Name = dr["name"].ToString(),
				Description = dr["description"].ToString(),
				Price = (decimal)dr["price"],
				Image = (string)dr["image"]
			};

			return pet;
		}

		/// <summary>
		/// Create Pet Object from DataRow
		/// </summary>
		/// <param name="dr">DataRow</param>
		/// <returns>Pet Object Instance</returns>
		private static Pet FormConvertRowToPetObj(DataRow dr)
		{
			Pet pet = new Pet
			{
				//PetId = (int)dr["pet_id"],
				//CategoryId = (int)dr["category_id"],
				//StatusId = (int)dr["status_id"],
				//BreedId = (int)dr["breed_id"],
				Name = dr["name"].ToString(),
				Description = dr["description"].ToString(),
				Price = (decimal)dr["price"],
				//Image = (string)dr["image"]
			};

			return pet;
		}

		/// <summary>
		/// Retrieve the specific pet record based on the primary key to table
		/// </summary>
		/// <param name="petId">Pet Id - unique table primary key</param>
		/// <returns>Pet Record as an object</returns>
		public static Pet GetById(int petId) // Pet.GetyById(2); 
		{
			Pet pet = null;
			string sqlStatement = @"
				SELECT pet_id, category_id, status_id, breed_id, name, description,
					price, image
				FROM pet 
				WHERE pet_id = @1";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, petId);

			if (dt.Rows.Count > 0)
			{
				pet = ConvertRowToPetObj(dt.Rows[0]);
			}

			return pet;
		}

		

		public static Pet FormGetById(int petId) // Pet.GetyById(2); 
		{
			Pet pet = null;
			string sqlStatement = @"
				SELECT name, description,
					price
				FROM pet 
				WHERE pet_id = @1";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, petId);

			if (dt.Rows.Count > 0)
			{
				pet = FormConvertRowToPetObj(dt.Rows[0]);
			}

			return pet;
		}

		public static Pet GetByName(string name) // Pet.GetyById(2); 
		{
			Pet pet = null;
			string sqlStatement = @"
				SELECT pet_id, category_id, status_id, breed_id, name, description,
					price, image
				FROM pet 
				WHERE name = @1";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, name);

			if (dt.Rows.Count > 0)
			{
				pet = ConvertRowToPetObj(dt.Rows[0]);
			}

			return pet;
		}

		public static Pet GetByBreedId(int breedId) // Pet.GetyById(2); 
		{
			Pet pet = null;
			string sqlStatement = @"
				SELECT pet_id, category_id, status_id, breed_id, name, description,
					price, image
				FROM pet 
				WHERE breed_id = @1";

			DataTable dt = DALExec.ExecuteQuery(sqlStatement, breedId);

			if (dt.Rows.Count > 0)
			{
				pet = ConvertRowToPetObj(dt.Rows[0]);
			}

			return pet;
		}

		/// <summary>
		/// Adds a Pet record to the database
		/// </summary>
		/// <param name="pet">Pet Object</param>
		/// <returns>Updated object with the Unique Primary Key ID</returns>
		public static Pet Add(Pet pet)
		{
			string sqlStatement = @"
				INSERT INTO pet (category_id, status_id, breed_id, name, 
					description, price, image)
				VALUES(@1, @2, @3, @4, @5, @6, @7)";
			if (DALExec.ExecuteNonQuery(sqlStatement, pet.CategoryId, pet.StatusId,
				pet.BreedId, pet.Name, pet.Description, pet.Price, pet.Image) > 0)
			{
				sqlStatement = @"
                    SELECT IDENT_CURRENT('pet') AS RESULT";
				int petID = Convert.ToInt32(DALExec.ExecuteScalar(sqlStatement));
				pet.PetId = petID;
			}
			return pet;
		}

		/// <summary>
		/// Deletes the specified Pet record from the Table
		/// </summary>
		/// <param name="pet"></param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Delete(Pet pet)
		{
			string sqlStatement = @"
                DELETE FROM pet
                WHERE pet_id = @1";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement, pet.PetId);
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
		/// Updates the pet information
		/// </summary>
		/// <param name="pet">Pet object to update</param>
		/// <returns>Boolean indicating whether update was successful or not</returns>
		public static bool Update(Pet pet)
		{
			string sqlStatement = @"
                UPDATE pet
                    SET category_id = @1,
					status_id = @2,
					breed_id = @3,
					name = @4,
					description = @5,
					price = @6,
					image = @7
                WHERE pet_id = @8";

			try
			{
				int count = DALExec.ExecuteNonQuery(sqlStatement,
					pet.CategoryId, pet.StatusId, pet.BreedId, pet.Name,
					pet.Description, pet.Price, pet.Image, pet.PetId);
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