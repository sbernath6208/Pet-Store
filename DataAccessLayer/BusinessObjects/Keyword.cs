using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataAccessLayer.BusinessObjects
{
	/// <summary>
	/// Keyword
	/// </summary>
	public class Keyword
	{
		[DisplayName("Keyword Id")]
		/// <summary>
		/// Keyword ID - unique identifier for the Keyword table
		/// </summary>
		public int KeywordId { get; set; }

		[DisplayName("Keyword Desc")]
		/// <summary>
		/// Keyword Description
		/// </summary>
		public string KeywordDesc { get; set; }

		/// <summary>
		/// No argument constructor
		/// </summary>
		public Keyword()
		{
		}

		/// <summary>
		/// All parameter constructor
		/// </summary>
		/// <param name="keywordId">Keyword Unique Identifier</param>
		/// <param name="keywordDesc">Keyword Description</param>
		public Keyword(int keywordId, string keywordDesc)
		{
			this.KeywordId = keywordId;
			this.KeywordDesc = keywordDesc;
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
			if (obj.GetType() != typeof(Keyword))
				return false;

			// Now it is safe to cast the generic object that was passed in
			// as a Keyword
			Keyword keyword = (Keyword)obj;

			// In order to see if this instance of an object is equal to the object
			// passed in, we need to check the values.
			if (this.KeywordId == keyword.KeywordId &&
				this.KeywordDesc == keyword.KeywordDesc)
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
		public override int GetHashCode() => (KeywordId, KeywordDesc).GetHashCode();

		/// <summary>
		/// Compares to Keyword objects for equivalence in a logical comparison
		/// </summary>
		/// <param name="keyword1">Keyword object instance 1</param>
		/// <param name="keyword2">Keyword object instance 2</param>
		/// <returns>Boolean indicating if the two types are equivalent</returns>
		public static bool operator ==(Keyword keyword1, Keyword keyword2)
		{
			if (Object.Equals(keyword1, null))
				if (Object.Equals(keyword2, null))
					return true;
				else
					return false;
			else
				return keyword1.Equals(keyword2);
		}

		/// <summary>
		/// Compares to Keyword objects to determine if they are not equivalent 
		/// in a logical comparison
		/// </summary>
		/// <param name="keyword1">Keyword object instance 1</param>
		/// <param name="keyword2">Keyword object instance 2</param>
		/// <returns>Boolean indicating if the two Keywords are equivalent</returns>
		public static bool operator !=(Keyword keyword1, Keyword keyword2)
		{
			// Dependent on the prior implementation of the == operator
			return !(keyword1 == keyword2);
		}

		/// <summary>
		/// Provides a String representation of an Object
		/// </summary>
		/// <returns>Returns a String representation of the object</returns>
		public override string ToString()
		{
			return $"Keyword ID: {KeywordId}, Keyword Desc: {KeywordDesc}";
		}
	}
}