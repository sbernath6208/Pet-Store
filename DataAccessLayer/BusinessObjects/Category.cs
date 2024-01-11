using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataAccessLayer.BusinessObjects
{
	public class Category
	{
		[DisplayName("Category Id")]
		/// <summary>
		/// Category ID - unique identifier for the Category table
		/// </summary>
		public int CategoryId { get; set; }

		[DisplayName("Category Desc")]
		/// <summary>
		/// Category Description
		/// </summary>
		public string CategoryDesc { get; set; }

		/// <summary>
		/// No argument constructor
		/// </summary>
		public Category()
		{
		}

		/// <summary>
		/// All parameter constructor
		/// </summary>
		/// <param name="CategoryId">Category Unique Identifier</param>
		/// <param name="CategoryDesc">Category Description</param>
		public Category(int CategoryId, string CategoryDesc)
		{
			this.CategoryId = CategoryId;
			this.CategoryDesc = CategoryDesc;
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
			if (obj.GetType() != typeof(Category))
				return false;

			// Now it is safe to cast the generic object that was passed in
			// as a Breed
			Category category = (Category)obj;

			// In order to see if this instance of an object is equal to the object
			// passed in, we need to check the values.
			if (this.CategoryId == category.CategoryId &&
				this.CategoryDesc == category.CategoryDesc)
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
		public override int GetHashCode() => (CategoryId, CategoryDesc).GetHashCode();

		/// <summary>
		/// Compares to Category objects for equivalence in a logical comparison
		/// </summary>
		/// <param name="category1">Category object instance 1</param>
		/// <param name="category2">Category object instance 2</param>
		/// <returns>Boolean indicating if the two types are equivalent</returns>
		public static bool operator ==(Category category1, Category category2)
		{
			if (Object.Equals(category1, null))
				if (Object.Equals(category2, null))
					return true;
				else
					return false;
			else
				return category1.Equals(category2);
		}

		/// <summary>
		/// Compares to Category objects to determine if they are not equivalent 
		/// in a logical comparison
		/// </summary>
		/// <param name="category1">Category object instance 1</param>
		/// <param name="category2">Category object instance 2</param>
		/// <returns>Boolean indicating if the two Categories are equivalent</returns>
		public static bool operator !=(Category category1, Category category2)
		{
			// Dependent on the prior implementation of the == operator
			return !(category1 == category2);
		}

		/// <summary>
		/// Provides a String representation of an Object
		/// </summary>
		/// <returns>Returns a String representation of the object</returns>
		public override string ToString()
		{
			return $"Category ID: {CategoryId}, Category Desc: {CategoryDesc}";
		}

	}
}