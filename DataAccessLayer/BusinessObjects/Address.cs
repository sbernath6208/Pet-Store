using System;
using System.ComponentModel;

namespace DataAccessLayer.BusinessObjects
{
	/// <summary>
	/// Address
	/// </summary>
	public class Address
	{
		[DisplayName("Address ID")]
		/// <summary>
		/// Address ID - unique identifier for the Address table
		/// </summary>
		public int AddressId { get; set; }

		[DisplayName("Address Line 1")]
		/// <summary>
		/// Address Line 1
		/// </summary>
		public string AddressLine1 { get; set; }

		[DisplayName("Address Line 2")]
		/// <summary>
		/// Address Line 2
		/// </summary>
		public string AddressLine2 { get; set; }

		[DisplayName("City")]
		/// <summary>
		/// City Name
		/// </summary>
		public string City { get; set; }

		[DisplayName("State Abbr")]
		/// <summary>
		/// State Abbreviation
		/// </summary>
		public string StateAbbr { get; set; }

		[DisplayName("Postal Code")]
		/// <summary>
		/// Postal (Zip) Code
		/// </summary>
		public string PostalCode { get; set; }


		/// <summary>
		/// No argument constructor
		/// </summary>
		public Address()
		{
		}

		/// <summary>
		/// All parameter constructor
		/// </summary>
		/// <param name="addressId">Address ID</param>
		/// <param name="addressLine1">Address Line 1</param>
		/// <param name="addressLine2">Address Line 2</param>
		/// <param name="city">City Name</param>
		/// <param name="stateAbbr">State Abbreviation</param>
		/// <param name="postalCode">Postal (Zip) Code</param>
		public Address(int addressId, string addressLine1, string addressLine2,
			string city, string stateAbbr, string postalCode)
		{
			this.AddressId = addressId;
			this.AddressLine1 = addressLine1;
			this.AddressLine2 = addressLine2;
			this.City = city;
			this.StateAbbr = stateAbbr;
			this.PostalCode = postalCode;
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
			if (obj.GetType() != typeof(Address))
				return false;

			// Now it is safe to cast the generic object that was passed in
			// as a Address
			Address address = (Address)obj;

			// In order to see if this instance of an object is equal to the object
			// passed in, we need to check the values.
			if (this.AddressId == address.AddressId &&
				this.AddressLine1 == address.AddressLine1 &&
				this.AddressLine2 == address.AddressLine2 &&
				this.City == address.City &&
				this.StateAbbr == address.StateAbbr &&
				this.PostalCode == address.PostalCode)
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
		public override int GetHashCode() => (AddressId, AddressLine1, AddressLine2, City, StateAbbr, PostalCode).GetHashCode();

		/// <summary>
		/// Compares to Address objects for equivalence in a logical comparison
		/// </summary>
		/// <param name="address1">Address object instance 1</param>
		/// <param name="address2">Address object instance 2</param>
		/// <returns>Boolean indicating if the two types are equivalent</returns>
		public static bool operator ==(Address address1, Address address2)
		{
			if (Object.Equals(address1, null))
				if (Object.Equals(address2, null))
					return true;
				else
					return false;
			else
				return address1.Equals(address2);
		}

		/// <summary>
		/// Compares to Address objects to determine if they are not equivalent 
		/// in a logical comparison
		/// </summary>
		/// <param name="address1">Address object instance 1</param>
		/// <param name="address2">Address object instance 2</param>
		/// <returns>Boolean indicating if the two Addresss are equivalent</returns>
		public static bool operator !=(Address address1, Address address2)
		{
			// Dependent on the prior implementation of the == operator
			return !(address1 == address2);
		}

		/// <summary>
		/// Provides a String representation of an Object
		/// </summary>
		/// <returns>Returns a String representation of the object</returns>
		public override string ToString()
		{
			return $"Address ID: {AddressId}, Address Line 1: {AddressLine1}, Address Line 2: {AddressLine2}, " +
				$"City: {City}, State Abbr: {StateAbbr}, Postal Code: {PostalCode}";
		}
	}
}