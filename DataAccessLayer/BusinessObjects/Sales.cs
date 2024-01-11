using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace Final_Pet_Store_Bernath.DataAccessLayer.BussinessObjects
{
    public class Sales
    {

		[DisplayName("SalesForm Name")]
		/// <summary>
		/// sales Name
		/// </summary>
		public string SalesName { get; set; }

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

		[DisplayName("Image")]
		/// <summary>
		/// Image 
		/// </summary>
		public string Image { get; set; }


		[DisplayName("SalesForm ID")]
		/// <summary>
		/// sales ID - unique identifier for the sales table
		/// </summary>
		public int SalesId { get; set; }

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
		public Sales()
		{
		}

		/// <summary>
		/// All parameter constructor
		/// </summary>
		/// <param name="salesId">sales ID</param>
		/// <param name="statusId">statusId Name</param>
		/// <param name="categoryId">Category Id</param>

		/// <param name="name">sales Name</param>
		/// <param name="description">sales Description</param>
		/// <param name="price">Purchase Price</param>
		/// <param name="image">Image Number</param>
		/// <param name="quantity">Image Number</param>
		public Sales(int salesId, int statusId, int categoryId,
			int breedId, string Salesname, string description, decimal price,
			string image)
		{
			this.SalesId = salesId;
			this.SalesName = Salesname;
			this.StatusId = statusId;
			this.CategoryId = categoryId;
			
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
			if (obj.GetType() != typeof(Final_Pet_Store_Bernath.SalesForm))
				return false;

			// Now it is safe to cast the generic object that was passed in
			// as a sales
			Sales Sales = (Sales)obj;

			// In order to see if this instance of an object is equal to the object
			// passed in, we need to check the values.
			if (this.SalesId == Sales.SalesId &&
				this.StatusId == Sales.StatusId &&
				this.CategoryId == Sales.CategoryId &&
				
				this.SalesName == Sales.SalesName &&
				this.Description == Sales.Description &&
				this.Price == Sales.Price &&
				this.Image == Sales.Image)
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
		public override int GetHashCode() => (SalesId, StatusId, CategoryId, SalesName, Description,
			Price, Image).GetHashCode();

		/// <summary>
		/// Compares to sales objects for equivalence in a logical comparison
		/// </summary>
		/// <param name="Sales1">sales object instance 1</param>
		/// <param name="Sales2">sales object instance 2</param>
		/// <returns>Boolean indicating if the two types are equivalent</returns>
		public static bool operator ==(Sales Sales1, Sales Sales2)
		{
			if (Object.Equals(Sales1, null))
				if (Object.Equals(Sales2, null))
					return true;
				else
					return false;
			else
				return Sales1.Equals(Sales2);
		}

		/// <summary>
		/// Compares to sales objects to determine if they are not equivalent 
		/// in a logical comparison
		/// </summary>
		/// <param name="Sales1">sales object instance 1</param>
		/// <param name="Sales2">sales object instance 2</param>
		/// <returns>Boolean indicating if the two saless are equivalent</returns>
		public static bool operator !=(Sales Sales1, Sales Sales2)
		{
			// Dependent on the prior implementation of the == operator
			return !(Sales1 == Sales2);
		}

		/// <summary>
		/// Provides a String representation of an Object
		/// </summary>
		/// <returns>Returns a String representation of the object</returns>
		public override string ToString()
		{
			return $"SalesForm ID: {SalesId}, StatusId: {StatusId}, Category Id: {CategoryId}, " +
				$"  Name: {SalesName}, Description: {Description}, Price: {Price}";
		}
	}
}
