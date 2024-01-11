using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataAccessLayer.BusinessObjects
{
	/// <summary>
	/// Status
	/// </summary>
	public class Status
	{
		[DisplayName("Status Id")]
		/// <summary>
		/// Status ID - unique identifier for the Status table
		/// </summary>
		public int StatusId { get; set; }

		[DisplayName("Status Desc")]
		/// <summary>
		/// Status Description
		/// </summary>
		public string StatusDesc { get; set; }

		/// <summary>
		/// No argument constructor
		/// </summary>
		public Status()
		{
		}

		/// <summary>
		/// All parameter constructor
		/// </summary>
		/// <param name="statusId">Status Unique Identifier</param>
		/// <param name="statusDesc">Status Description</param>
		public Status(int statusId, string statusDesc)
		{
			this.StatusId = statusId;
			this.StatusDesc = statusDesc;
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
			if (obj.GetType() != typeof(Status))
				return false;

			// Now it is safe to cast the generic object that was passed in
			// as a Status
			Status status = (Status)obj;

			// In order to see if this instance of an object is equal to the object
			// passed in, we need to check the values.
			if (this.StatusId == status.StatusId &&
				this.StatusDesc == status.StatusDesc)
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
		public override int GetHashCode() => (StatusId, StatusDesc).GetHashCode();

		/// <summary>
		/// Compares to Status objects for equivalence in a logical comparison
		/// </summary>
		/// <param name="status1">Status object instance 1</param>
		/// <param name="status2">Status object instance 2</param>
		/// <returns>Boolean indicating if the two types are equivalent</returns>
		public static bool operator ==(Status status1, Status status2)
		{
			if (Object.Equals(status1, null))
				if (Object.Equals(status2, null))
					return true;
				else
					return false;
			else
				return status1.Equals(status2);
		}

		/// <summary>
		/// Compares to Status objects to determine if they are not equivalent 
		/// in a logical comparison
		/// </summary>
		/// <param name="status1">Status object instance 1</param>
		/// <param name="status2">Status object instance 2</param>
		/// <returns>Boolean indicating if the two Statuss are equivalent</returns>
		public static bool operator !=(Status status1, Status status2)
		{
			// Dependent on the prior implementation of the == operator
			return !(status1 == status2);
		}

		/// <summary>
		/// Provides a String representation of an Object
		/// </summary>
		/// <returns>Returns a String representation of the object</returns>
		public override string ToString()
		{
			return $"Status ID: {StatusId}, Status Desc: {StatusDesc}";
		}
	}
}