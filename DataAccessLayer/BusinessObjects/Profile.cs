using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataAccessLayer.BusinessObjects
{
	/// <summary>
	/// Profile
	/// </summary>
	public class Profile
	{
		[DisplayName("Profile ID")]
		/// <summary>
		/// Profile ID - unique identifier for the Profile table
		/// </summary>
		public int ProfileId { get; set; }

		[DisplayName("First Name")]
		/// <summary>
		/// First Name
		/// </summary>
		public string FirstName { get; set; }

		[DisplayName("Last Name")]
		/// <summary>
		/// Last Name
		/// </summary>
		public string LastName { get; set; }

		[DisplayName("Status Id")]
		/// <summary>
		/// Status ID
		/// </summary>
		public int StatusId { get; set; }

		[DisplayName("Address Id")]
		/// <summary>
		/// Address Id
		/// </summary>
		public int AddressId { get; set; }

		[DisplayName("Email")]
		/// <summary>
		/// Email Address
		/// </summary>
		public string Email { get; set; }

		[DisplayName("Phone")]
		/// <summary>
		/// Phone Number
		/// </summary>
		public string Phone { get; set; }

		[DisplayName("User Name")]
		/// <summary>
		/// User Name
		/// </summary>
		public string UserName { get; set; }

		[DisplayName("Password")]
		/// <summary>
		/// Password
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// No argument constructor
		/// </summary>
		public Profile()
		{
		}

		/// <summary>
		/// All parameter constructor
		/// </summary>
		/// <param name="profileId">Profile ID</param>
		/// <param name="firstName">First Name</param>
		/// <param name="lastName">Last Name</param>
		/// <param name="statusId">statusId Name</param>
		/// <param name="addressId">Address Id</param>
		/// <param name="email">Postal (Zip) Code</param>
		/// <param name="phone">Phone Number</param>
		/// <param name="username">User Name</param>
		/// <param name="password">Password</param>
		public Profile(int profileId, string firstName, string lastName,
			int statusId, int addressId, string email, string phone,
			string userName, string password)
		{
			this.ProfileId = profileId;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.StatusId = statusId;
			this.AddressId = addressId;
			this.Email = email;
			this.Phone = phone;
			this.UserName = userName;
			this.Password = password;
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
			if (obj.GetType() != typeof(Profile))
				return false;

			// Now it is safe to cast the generic object that was passed in
			// as a Profile
			Profile Profile = (Profile)obj;

			// In order to see if this instance of an object is equal to the object
			// passed in, we need to check the values.
			if (this.ProfileId == Profile.ProfileId &&
				this.FirstName == Profile.FirstName &&
				this.LastName == Profile.LastName &&
				this.StatusId == Profile.StatusId &&
				this.AddressId == Profile.AddressId &&
				this.Email == Profile.Email &&
				this.Phone == Profile.Phone &&
				this.UserName == Profile.UserName &&
				this.Password == Profile.Password)
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
		public override int GetHashCode() => (ProfileId, FirstName, LastName, StatusId, AddressId,
			Email, Phone, UserName, Password).GetHashCode();

		/// <summary>
		/// Compares to Profile objects for equivalence in a logical comparison
		/// </summary>
		/// <param name="Profile1">Profile object instance 1</param>
		/// <param name="Profile2">Profile object instance 2</param>
		/// <returns>Boolean indicating if the two types are equivalent</returns>
		public static bool operator ==(Profile Profile1, Profile Profile2)
		{
			if (Object.Equals(Profile1, null))
				if (Object.Equals(Profile2, null))
					return true;
				else
					return false;
			else
				return Profile1.Equals(Profile2);
		}

		/// <summary>
		/// Compares to Profile objects to determine if they are not equivalent 
		/// in a logical comparison
		/// </summary>
		/// <param name="Profile1">Profile object instance 1</param>
		/// <param name="Profile2">Profile object instance 2</param>
		/// <returns>Boolean indicating if the two Profiles are equivalent</returns>
		public static bool operator !=(Profile Profile1, Profile Profile2)
		{
			// Dependent on the prior implementation of the == operator
			return !(Profile1 == Profile2);
		}

		/// <summary>
		/// Provides a String representation of an Object
		/// </summary>
		/// <returns>Returns a String representation of the object</returns>
		public override string ToString()
		{
			return $"Profile ID: {ProfileId}, First Name: {FirstName}, Last Name: {LastName}, " +
				$"StatusId: {StatusId}, Address Id: {AddressId}, Email: {Email}, Phone: {Phone}, " +
				$"Username: {UserName}, Password: {Password}";
		}
	}
}