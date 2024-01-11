using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataAccessLayer.BusinessObjects
{
	/// <summary>
	/// Pet PetKeyword
	/// </summary>
	public class PetKeyword
	{
		[DisplayName("Pet Id")]
		/// <summary>
		/// Pet ID - part of composite key for the PetKeyword table
		/// </summary>
		public int PetId { get; set; }

		[DisplayName("Keyword ID")]
		/// <summary>
		/// Keyword ID - part of composite key for the PetKeyword table
		/// </summary>
		public int KeywordId { get; set; }

		/// <summary>
		/// No argument constructor
		/// </summary>
		public PetKeyword()
		{
		}

		/// <summary>
		/// All parameter constructor
		/// </summary>
		/// <param name="petId">Pet Unique Identifier</param>
		/// <param name="keywordId">Keyword Unique Identifier</param>
		public PetKeyword(int petId, int keywordId)
		{
			this.PetId = petId;
			this.KeywordId = keywordId;
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
			if (obj.GetType() != typeof(PetKeyword))
				return false;

			// Now it is safe to cast the generic object that was passed in
			// as a PetKeyword
			PetKeyword petKeyword = (PetKeyword)obj;

			// In order to see if this instance of an object is equal to the object
			// passed in, we need to check the values.
			if (this.PetId == petKeyword.PetId &&
				this.KeywordId == petKeyword.KeywordId)
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
		public override int GetHashCode() => (PetId, KeywordId).GetHashCode();

		/// <summary>
		/// Compares to PetKeyword objects for equivalence in a logical comparison
		/// </summary>
		/// <param name="petKeyword1">PetKeyword object instance 1</param>
		/// <param name="petKeyword2">PetKeyword object instance 2</param>
		/// <returns>Boolean indicating if the two types are equivalent</returns>
		public static bool operator ==(PetKeyword petKeyword1, PetKeyword petKeyword2)
		{
			if (Object.Equals(petKeyword1, null))
				if (Object.Equals(petKeyword2, null))
					return true;
				else
					return false;
			else
				return petKeyword1.Equals(petKeyword2);
		}

		/// <summary>
		/// Compares to PetKeyword objects to determine if they are not equivalent 
		/// in a logical comparison
		/// </summary>
		/// <param name="petKeyword1">PetKeyword object instance 1</param>
		/// <param name="petKeyword2">PetKeyword object instance 2</param>
		/// <returns>Boolean indicating if the two PetKeywords are equivalent</returns>
		public static bool operator !=(PetKeyword petKeyword1, PetKeyword petKeyword2)
		{
			// Dependent on the prior implementation of the == operator
			return !(petKeyword1 == petKeyword2);
		}

		/// <summary>
		/// Provides a String representation of an Object
		/// </summary>
		/// <returns>Returns a String representation of the object</returns>
		public override string ToString()
		{
			return $"Pet ID: {PetId}, Keyword ID: {KeywordId}";
		}
	}
}