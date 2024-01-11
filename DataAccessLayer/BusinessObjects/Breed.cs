using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataAccessLayer.BusinessObjects
{
	/// <summary>
	/// Pet Breed
	/// </summary>
	public class Breed
	{
		[DisplayName("Breed Id")]
		/// <summary>
		/// Breed ID - unique identifier for the Breed table
		/// </summary>
		public int BreedId { get; set; }

		[DisplayName("Breed Desc")]
		/// <summary>
		/// Breed Description
		/// </summary>
		public string BreedDesc { get; set; }

		/// <summary>
		/// No argument constructor
		/// </summary>
		public Breed()
		{
		}

		/// <summary>
		/// All parameter constructor
		/// </summary>
		/// <param name="breedId">Breed Unique Identifier</param>
		/// <param name="breedDesc">Breed Description</param>
		public Breed(int breedId, string breedDesc)
		{
			this.BreedId = breedId;
			this.BreedDesc = breedDesc;
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
			if (obj.GetType() != typeof(Breed))
				return false;

			// Now it is safe to cast the generic object that was passed in
			// as a Breed
			Breed breed = (Breed)obj;

			// In order to see if this instance of an object is equal to the object
			// passed in, we need to check the values.
			if (this.BreedId == breed.BreedId &&
				this.BreedDesc == breed.BreedDesc)
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
		public override int GetHashCode() => (BreedId, BreedDesc).GetHashCode();

		/// <summary>
		/// Compares to Breed objects for equivalence in a logical comparison
		/// </summary>
		/// <param name="breed1">Breed object instance 1</param>
		/// <param name="breed2">Breed object instance 2</param>
		/// <returns>Boolean indicating if the two types are equivalent</returns>
		public static bool operator ==(Breed breed1, Breed breed2)
		{
			if (Object.Equals(breed1, null))
				if (Object.Equals(breed2, null))
					return true;
				else
					return false;
			else
				return breed1.Equals(breed2);
		}

		/// <summary>
		/// Compares to Breed objects to determine if they are not equivalent 
		/// in a logical comparison
		/// </summary>
		/// <param name="breed1">Breed object instance 1</param>
		/// <param name="breed2">Breed object instance 2</param>
		/// <returns>Boolean indicating if the two Breeds are equivalent</returns>
		public static bool operator !=(Breed breed1, Breed breed2)
		{
			// Dependent on the prior implementation of the == operator
			return !(breed1 == breed2);
		}

		/// <summary>
		/// Provides a String representation of an Object
		/// </summary>
		/// <returns>Returns a String representation of the object</returns>
		public override string ToString()
		{
			return $"Breed ID: {BreedId}, Breed Desc: {BreedDesc}";
		}
	}
}