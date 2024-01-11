using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using DataAccessLayer;
using DataAccessLayer.BusinessObjects;
using Final_Pet_Store_Bernath.DataAccessLayer.DBObjects;

namespace DataAccessLayer.BusinessObjects
{
	/// <summary>
	/// OrderLines
	/// </summary>
	public class OrderLine
	{
		[DisplayName("Order Number")]
		/// <summary>
		/// OrderLine Number - key to the OrderLine table
		/// </summary>
		public int OrderNo { get; set; }

		[DisplayName("Line Number")]
		/// <summary>
		/// OrderLine Line Number
		/// </summary>
		public int LineNo { get; set; }

		[DisplayName("Status Id")]
		/// <summary>
		/// Status Id
		/// </summary>
		public int StatusId { get; set; }

		[DisplayName("Pet Id")]
		/// <summary>
		/// Pet Id
		/// </summary>
		public int PetId { get; set; }

		[DisplayName("Product Id")]
		public int ProductId { get; set; }
		
		[DisplayName("Sales Id")]
		/// <summary>
		/// Product Id
		/// </summary>
		public int SalesId { get; set; }

		[DisplayName("Qty")]
		/// <summary>
		/// Sales Id
		/// </summary>
		public decimal Qty { get; set; }

		[DisplayName("Price")]
		/// <summary>
		/// Price Per Item
		/// </summary>
		public decimal Price { get; set; }

		[DisplayName("Extended Price")]
		/// <summary>
		/// Total OrderLine Cost
		/// </summary>
		public decimal ExtendedPrice { get; set; }

		[DisplayName("Ship Date")]
		/// <summary>
		/// Ship Date
		/// </summary>
		public DateTime? ShipDate { get; set; }

		/// <summary>
		/// No argument constructor
		/// </summary>
		public OrderLine()
		{
		}

		/// <summary>
		/// All parameter constructor
		/// </summary>
		/// <param name="orderNo">OrderLine Number</param>
		/// <param name="lineNo">Line Number</param>
		public OrderLine(int orderNo, int lineNo, int statusId,
			int petId, int productId, int salesId, int qty, decimal price, decimal extendedPrice,
			DateTime? shipDate)
		{
			this.OrderNo = orderNo;
			this.LineNo = lineNo;
			this.StatusId = statusId;
			this.PetId = petId;
			this.ProductId = productId;
			this.SalesId = salesId; 
			this.Qty = qty;
			this.Price = price;
			this.ExtendedPrice = extendedPrice;
			this.ShipDate = shipDate;
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
			if (obj.GetType() != typeof(OrderLine))
				return false;

			// Now it is safe to cast the generic object that was passed in
			// as a OrderLine
			OrderLine orderLine = (OrderLine)obj;

			// In order to see if this instance of an object is equal to the object
			// passed in, we need to check the values.
			if (this.OrderNo == orderLine.OrderNo &&
				this.LineNo == orderLine.LineNo &&
				this.StatusId == orderLine.StatusId &&
				this.PetId == orderLine.PetId &&
				this.ProductId == orderLine.ProductId &&
				this.SalesId == orderLine.SalesId &&
				this.Qty == orderLine.Qty &&
				this.Price == orderLine.Price &&
				this.ExtendedPrice == orderLine.ExtendedPrice &&
				this.ShipDate == orderLine.ShipDate)
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
		public override int GetHashCode() => (OrderNo, LineNo, StatusId, PetId, ProductId, SalesId, Qty,
			Price, ExtendedPrice, ShipDate).GetHashCode();

		/// <summary>
		/// Compares to OrderLine objects for equivalence in a logical comparison
		/// </summary>
		/// <param name="orderLine1">OrderLine object instance 1</param>
		/// <param name="orderLine2">OrderLine object instance 2</param>
		/// <returns>Boolean indicating if the two types are equivalent</returns>
		public static bool operator ==(OrderLine orderLine1, OrderLine orderLine2)
		{
			if (Object.Equals(orderLine1, null))
				if (Object.Equals(orderLine2, null))
					return true;
				else
					return false;
			else
				return orderLine1.Equals(orderLine2);
		}

		/// <summary>
		/// Compares to OrderLine objects to determine if they are not equivalent 
		/// in a logical comparison
		/// </summary>
		/// <param name="orderLine1">OrderLine object instance 1</param>
		/// <param name="orderLine2">OrderLine object instance 2</param>
		/// <returns>Boolean indicating if the two OrderLines are equivalent</returns>
		public static bool operator !=(OrderLine orderLine1, OrderLine orderLine2)
		{
			// Dependent on the prior implementation of the == operator
			return !(orderLine1 == orderLine2);
		}

		/// <summary>
		/// Provides a String representation of an Object
		/// </summary>
		/// <returns>Returns a String representation of the object</returns>
		public override string ToString()
		{
			return $"Order No: {OrderNo}, Line No: {LineNo}, Status ID: {StatusId}, " +
				$"Pet Id: {PetId}, Product Id: {ProductId}, Sales Id: {SalesId}, Qty: {Qty}, Price: {Price}, " +
				$"Extended Price: {ExtendedPrice}, Ship Date: {ShipDate}";
		}
	}
}