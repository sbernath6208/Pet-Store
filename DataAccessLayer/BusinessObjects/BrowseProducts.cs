using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace DataAccessLayer.BusinessObjects
{
    public class BrowseProducts
    {
		[DisplayName("Product Name")]
		/// <summary>
		/// browseProducts Name
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

		[DisplayName("Image")]
		/// <summary>
		/// Image 
		/// </summary>
		public string Image { get; set; }

		[DisplayName("Product ID")]
		/// <summary>
		/// browseProducts ID - unique identifier for the browseProducts table
		/// </summary>
		public int ProductId { get; set; }

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
		public BrowseProducts()
		{
		}

		/// <summary>
		/// All parameter constructor
		/// </summary>
		/// <param name="productId">Product ID</param>
		/// <param name="statusId">statusId Name</param>
		/// <param name="categoryId">Category Id</param>
		/// <param name="name">Pproduct Name</param>
		/// <param name="description">Pproduct Description</param>
		/// <param name="price">Purchase Price</param>
		/// <param name="image">Image Number</param>
		///  <param name="quantity">Image Number</param>
		public BrowseProducts(int productId, int statusId, int categoryId,
			string name, string description, decimal price,
			string image)
		{
			this.ProductId = productId;
			this.Name = name;
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
			if (obj.GetType() != typeof(BrowseProducts))
				return false;

			// Now it is safe to cast the generic object that was passed in
			// as a browseProducts
			BrowseProducts BrowseProducts = (BrowseProducts)obj;

			// In order to see if this instance of an object is equal to the object
			// passed in, we need to check the values.
			if (this.ProductId == BrowseProducts.ProductId &&
				this.StatusId == BrowseProducts.StatusId &&
				this.CategoryId == BrowseProducts.CategoryId &&
				
				this.Name == BrowseProducts.Name &&
				this.Description == BrowseProducts.Description &&
				this.Price == BrowseProducts.Price &&
				this.Image == BrowseProducts.Image)
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
		public override int GetHashCode() => (ProductId, StatusId, CategoryId, Name, Description,
			Price, Image).GetHashCode();

		/// <summary>
		/// Compares to browseProducts objects for equivalence in a logical comparison
		/// </summary>
		/// <param name="BrowseProducts1">BrowseProducts object instance 1</param>
		/// <param name="BrowseProducts2">BrowseProducts object instance 2</param>
		/// <returns>Boolean indicating if the two types are equivalent</returns>
		public static bool operator ==(BrowseProducts BrowseProducts1, BrowseProducts BrowseProducts2)
		{
			if (Object.Equals(BrowseProducts1, null))
				if (Object.Equals(BrowseProducts2, null))
					return true;
				else
					return false;
			else
				return BrowseProducts1.Equals(BrowseProducts2);
		}

		/// <summary>
		/// Compares to browseProducts objects to determine if they are not equivalent 
		/// in a logical comparison
		/// </summary>
		/// <param name="BrowseProducts1">BrowseProductst object instance 1</param>
		/// <param name="BrowseProducts2">BrowseProducts object instance 2</param>
		/// <returns>Boolean indicating if the two browseProductss are equivalent</returns>
		public static bool operator !=(BrowseProducts BrowseProducts1, BrowseProducts BrowseProducts2)
		{
			// Dependent on the prior implementation of the == operator
			return !(BrowseProducts1 == BrowseProducts2);
		}

		/// <summary>
		/// Provides a String representation of an Object
		/// </summary>
		/// <returns>Returns a String representation of the object</returns>
		public override string ToString()
		{
			return $"Product ID: {ProductId}, StatusId: {StatusId}, Category Id: {CategoryId}, " +
				$" Name: {Name}, Description: {Description}, Price: {Price}";
		}
	}
}
