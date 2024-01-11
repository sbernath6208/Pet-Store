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
	/// Orders
	/// </summary>
	public class Order
	{
		[DisplayName("Order Number")]
		/// <summary>
		/// Order Number - key to the Order table
		/// </summary>
		public int OrderNo { get; set; }

		[DisplayName("Status Id")]
		/// <summary>
		/// Status Id
		/// </summary>
		public int StatusId { get; set; }

		[DisplayName("User Name")]
		/// <summary>
		/// User Name of the purchaser
		/// </summary>
		public string UserName { get; set; }

		[DisplayName("Billing First Name")]
		/// <summary>
		/// First Name on the Billing Account
		/// </summary>
		public string BillingFirstName { get; set; }

		[DisplayName("Billing Last Name")]
		/// <summary>
		/// Last Name on the Billing Account
		/// </summary>
		public string BillingLastName { get; set; }

		[DisplayName("Credit Card Number")]
		/// <summary>
		/// Credit Card Number
		/// </summary>
		public string CreditCardNo { get; set; } // order.CreditCardNo.ToString()

		[DisplayName("Billing Address ID")]
		/// <summary>
		/// Billing Address ID
		/// </summary>
		public int BillAddressId { get; set; }

		[DisplayName("Shipper Id")]
		/// <summary>
		/// Shipper Id
		/// </summary>
		public int ShipperId { get; set; }

		[DisplayName("Ship To First Name")]
		/// <summary>
		/// First Name of person to Ship Order To
		/// </summary>
		public string ShipToFirstName { get; set; }

		[DisplayName("Ship To Last Name")]
		/// <summary>
		/// Last Name of person to Ship Order To
		/// </summary>
		public string ShipToLastName { get; set; }

		[DisplayName("Ship To Address Id")]
		/// <summary>
		/// Shipping Location Address ID
		/// </summary>
		public int ShipToAddressId { get; set; }

		[DisplayName("SalesForm Tax")]
		/// <summary>
		/// Calculated SalesForm Tax on Order
		/// </summary>
		public decimal SalesTax { get; set; }

		[DisplayName("Shipping Cost")]
		/// <summary>
		/// Shipping Cost on Order
		/// </summary>
		public decimal ShippingCost { get; set; }

		[DisplayName("Total Cost")]
		/// <summary>
		/// Total Order Cost
		/// </summary>
		public decimal TotalCost { get; set; }

		/// <summary>
		/// No argument constructor
		/// </summary>
		public Order()
		{
		}

		/// <summary>
		/// All parameter constructor
		/// </summary>
		/// <param name="orderNo">Order Number</param>
		/// <param name="statusId">Status Id</param>
		public Order(int orderNo, int statusId, string username,
			string billingFirstName, string billingLastName, string creditCardNo,
			int billAddressId, int shipperId, string shipToFirstName,
			string shipToLastName, int shipToAddressId, decimal salesTax,
			decimal shippingCost, decimal totalCost) 
		{
			this.OrderNo = orderNo;
			this.StatusId = statusId;
			this.UserName = username;
			this.BillingFirstName = billingFirstName;
			this.BillingLastName = billingLastName;
			this.CreditCardNo = creditCardNo;
			this.BillAddressId = billAddressId;
			this.ShipperId = shipperId;
			this.ShipToFirstName = shipToFirstName;
			this.ShipToLastName = shipToLastName;
			this.ShipToAddressId = shipToAddressId;
			this.SalesTax = salesTax;
			this.ShippingCost = shippingCost;
			this.TotalCost = totalCost;
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
			if (obj.GetType() != typeof(Order))
				return false;

			// Now it is safe to cast the generic object that was passed in
			// as a Order
			Order Order = (Order)obj;

			// In order to see if this instance of an object is equal to the object
			// passed in, we need to check the values.
			if (this.OrderNo == Order.OrderNo &&
				this.StatusId == Order.StatusId &&
				this.BillingFirstName == Order.BillingFirstName &&
				this.BillingLastName == Order.BillingLastName &&
				this.CreditCardNo == Order.CreditCardNo &&
				this.BillAddressId == Order.BillAddressId &&
				this.ShipperId == Order.ShipperId &&
				this.ShipToFirstName == Order.ShipToFirstName &&
				this.ShipToLastName == Order.ShipToLastName &&
				this.ShipToAddressId == Order.ShipToAddressId &&
				this.SalesTax == Order.SalesTax &&
				this.ShippingCost == Order.ShippingCost &&
				this.TotalCost == Order.TotalCost)
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
		public override int GetHashCode() => (OrderNo, StatusId, UserName, BillingFirstName,
			BillingLastName, CreditCardNo, BillAddressId, ShipperId, ShipToFirstName,
			ShipToLastName, ShipToAddressId, SalesTax, ShippingCost, TotalCost).GetHashCode();

		/// <summary>
		/// Compares to Order objects for equivalence in a logical comparison
		/// </summary>
		/// <param name="order1">Order object instance 1</param>
		/// <param name="order2">Order object instance 2</param>
		/// <returns>Boolean indicating if the two types are equivalent</returns>
		public static bool operator ==(Order order1, Order order2)
		{
			if (Object.Equals(order1, null))
				if (Object.Equals(order2, null))
					return true;
				else
					return false;
			else
				return order1.Equals(order2);
		}

		/// <summary>
		/// Compares to Order objects to determine if they are not equivalent 
		/// in a logical comparison
		/// </summary>
		/// <param name="order1">Order object instance 1</param>
		/// <param name="order2">Order object instance 2</param>
		/// <returns>Boolean indicating if the two Orders are equivalent</returns>
		public static bool operator !=(Order order1, Order order2)
		{
			// Dependent on the prior implementation of the == operator
			return !(order1 == order2);
		}

		/// <summary>
		/// Provides a String representation of an Object
		/// </summary>
		/// <returns>Returns a String representation of the object</returns>
		public override string ToString()
		{
			return $"Order No: {OrderNo}, Status ID: {StatusId}, UserName: {UserName}, " +
				$"Billing First Name: {BillingFirstName}, Billing Last Name: {BillingLastName}, " +
				$"Credit Card No: {CreditCardNo}, Billing Address Id: {BillAddressId}, " +
				$"Shipper ID: {ShipperId}, Ship To First Name: {ShipToFirstName}, " +
				$"Ship To Last Name: {ShipToLastName}, Ship To Address Id: {ShipToAddressId}, " +
				$"SalesForm Tax: {SalesTax}, Shipping Cost: {ShippingCost}, Total Cost: {TotalCost}";
		}

	}
}