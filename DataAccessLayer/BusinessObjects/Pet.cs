using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataAccessLayer.BusinessObjects
{
	/// <summary>
	/// Pet
	/// </summary>
	public class Pet
	{
		[DisplayName("Name")]
		/// <summary>
		/// Pet Name
		/// </summary>
		public string Name { get; set; }

		[DisplayName("Description")]
		/// <summary>
		/// Description
		/// </summary>
		public string Description { get; set; }

		[DisplayName("Price")]
		/// <summary>
		/// Purchase Price 
		/// </summary>
		public decimal Price { get; set; }

		[DisplayName("Breed Id")]
		/// <summary>
		/// Breed Id
		/// </summary>
		public int BreedId { get; set; }

		[DisplayName("Image")]
		/// <summary>
		/// Image 
		/// </summary>
		public string Image { get; set; }

		[DisplayName("Pet ID")]
		/// <summary>
		/// Pet ID - unique identifier for the Pet table
		/// </summary>
		public int PetId { get; set; }

		[DisplayName("Status Id")]
		/// <summary>
		/// Status ID
		/// </summary>
		public int StatusId { get; set; }

		[DisplayName("Category Id")]
		/// <summary>
		/// Category Id
		/// </summary>
		public int CategoryId { get; set; }

		

		

		/// <summary>
		/// No argument constructor
		/// </summary>
		public Pet()
		{
		}

		/// <summary>
		/// All parameter constructor
		/// </summary>
		/// <param name="petId">Pet ID</param>
		/// <param name="statusId">statusId Name</param>
		/// <param name="categoryId">Category Id</param>
		/// <param name="breedId">Breed Id</param>
		/// <param name="name">Pet Name</param>
		/// <param name="description">Pet Description</param>
		/// <param name="price">Purchase Price</param>
		/// <param name="image">Image Number</param>
		public Pet(int petId, int statusId, int categoryId,
			int breedId, string name, string description, decimal price,
			string image)
		{
			this.PetId = petId;
			this.Name = name;
			this.StatusId = statusId;
			this.CategoryId = categoryId;
			this.BreedId = breedId;
			this.Description = description;
			this.Price = price;
			this.Image = image;
		}

		/// <summary>
		/// Determines if an object that is passed in is equal to the current
		/// instance based on this current instance's properties
		/// </summary>
		/// <param name="obj">The object to check to see if it is equal</param>
		/// <returns>Returns a boolean value indicating if they are equal</returns>
		public override bool Equals(object obj)
		{
			// Is the object passed in null?  If so, it cannot be equal
			if (obj == null)
				return false;

			// Is the object passed in the same type as this class?  If not,
			// then it cannot be equal
			if (obj.GetType() != typeof(Pet))
				return false;

			// Now it is safe to cast the generic object that was passed in
			// as a Pet
			Pet Pet = (Pet)obj;

			// In order to see if this instance of an object is equal to the object
			// passed in, we need to check the values.
			if (this.PetId == Pet.PetId &&
				this.StatusId == Pet.StatusId &&
				this.CategoryId == Pet.CategoryId &&
				this.BreedId == Pet.BreedId &&
				this.Name == Pet.Name &&
				this.Description == Pet.Description &&
				this.Price == Pet.Price &&
				this.Image == Pet.Image)
				return true;
			else
				return false;
		}

		/// <summary>
		/// When the Equals method is overridden the practice is to override the GetHashCode
		/// as well.  Here since we made the equals dependent on the fields, we consistently 
		/// apply the same principle and return a HashCode value based on the objects values
		/// </summary>
		/// <returns>The generated hashcode value as an integer</returns>
		public override int GetHashCode() => (PetId, StatusId, CategoryId, BreedId, Name, Description,
			Price, Image).GetHashCode();

		/// <summary>
		/// Compares to Pet objects for equivalence in a logical comparison
		/// </summary>
		/// <param name="Pet1">Pet object instance 1</param>
		/// <param name="Pet2">Pet object instance 2</param>
		/// <returns>Boolean indicating if the two types are equivalent</returns>
		public static bool operator ==(Pet Pet1, Pet Pet2)
		{
			if (Object.Equals(Pet1, null))
				if (Object.Equals(Pet2, null))
					return true;
				else
					return false;
			else
				return Pet1.Equals(Pet2);
		}

		/// <summary>
		/// Compares to Pet objects to determine if they are not equivalent 
		/// in a logical comparison
		/// </summary>
		/// <param name="Pet1">Pet object instance 1</param>
		/// <param name="Pet2">Pet object instance 2</param>
		/// <returns>Boolean indicating if the two Pets are equivalent</returns>
		public static bool operator !=(Pet Pet1, Pet Pet2)
		{
			// Dependent on the prior implementation of the == operator
			return !(Pet1 == Pet2);
		}

		/// <summary>
		/// Provides a String representation of an Object
		/// </summary>
		/// <returns>Returns a String representation of the object</returns>
		public override string ToString()
		{
			return $"Pet ID: {PetId}, StatusId: {StatusId}, Category Id: {CategoryId}, " +
				$" Breed: {BreedId}, Name: {Name}, Description: {Description}, Price: {Price}";
		}

		

	}
}