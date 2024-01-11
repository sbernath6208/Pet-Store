using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataAccessLayer.BusinessObjects
{
	/// <summary>
	/// Shipper
	/// </summary>
	public class Shipper
	{
		[DisplayName("Shipper Id")]
		/// <summary>
		/// Shipper ID - unique identifier for the Shipper table
		/// </summary>
		public int ShipperId { get; set; }

		[DisplayName("Shipping Desc")]
		/// <summary>
		/// Shipping Description
		/// </summary>
		public string ShippingDesc { get; set; }

		[DisplayName("Shipping Flat Rate")]
		/// <summary>
		/// Shipping Flat Rate
		/// </summary>
		public decimal ShippingFlatRate { get; set; }

		/// <summary>
		/// No argument constructor
		/// </summary>
		public Shipper()
		{
		}

		/// <summary>
		/// All parameter constructor
		/// </summary>
		/// <param name="shipperId">Shipper Unique Identifier</param>
		/// <param name="shippingDesc">Shipping Description</param>
		/// <param name="shippingFlatRate">Shipping Flat Rate</param>
		public Shipper(int shipperId, string shippingDesc, decimal shippingFlatRate)
		{
			this.ShipperId = shipperId;
			this.ShippingDesc = shippingDesc;
			this.ShippingFlatRate = shippingFlatRate;
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
			if (obj.GetType() != typeof(Shipper))
				return false;

			// Now it is safe to cast the generic object that was passed in
			// as a Shipper
			Shipper shipper = (Shipper)obj;

			// In order to see if this instance of an object is equal to the object
			// passed in, we need to check the values.
			if (this.ShipperId == shipper.ShipperId &&
				this.ShippingDesc == shipper.ShippingDesc &&
				this.ShippingFlatRate == shipper.ShippingFlatRate)
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
		public override int GetHashCode() => (ShipperId, ShippingDesc, ShippingFlatRate).GetHashCode();

		/// <summary>
		/// Compares to Shipper objects for equivalence in a logical comparison
		/// </summary>
		/// <param name="shipper1">Shipper object instance 1</param>
		/// <param name="shipper2">Shipper object instance 2</param>
		/// <returns>Boolean indicating if the two types are equivalent</returns>
		public static bool operator ==(Shipper shipper1, Shipper shipper2)
		{
			if (Object.Equals(shipper1, null))
				if (Object.Equals(shipper2, null))
					return true;
				else
					return false;
			else
				return shipper1.Equals(shipper2);
		}

		/// <summary>
		/// Compares to Shipper objects to determine if they are not equivalent 
		/// in a logical comparison
		/// </summary>
		/// <param name="shipper1">Shipper object instance 1</param>
		/// <param name="shipper2">Shipper object instance 2</param>
		/// <returns>Boolean indicating if the two Shippers are equivalent</returns>
		public static bool operator !=(Shipper shipper1, Shipper shipper2)
		{
			// Dependent on the prior implementation of the == operator
			return !(shipper1 == shipper2);
		}

		/// <summary>
		/// Provides a String representation of an Object
		/// </summary>
		/// <returns>Returns a String representation of the object</returns>
		public override string ToString()
		{
			return $"Shipper ID: {ShipperId}, Shipping Desc: {ShippingDesc}, Shipping Flat Rate: {ShippingFlatRate}";
		}
	}
}