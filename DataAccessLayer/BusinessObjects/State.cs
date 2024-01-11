using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataAccessLayer.BusinessObjects
{
	/// <summary>
	/// State
	/// </summary>
	public class State
	{
		[DisplayName("State Abbr")]
		/// <summary>
		/// State Abbr - unique identifier for the State table
		/// </summary>
		public string StateAbbr { get; set; }

		[DisplayName("State Name")]
		/// <summary>
		/// State Name
		/// </summary>
		public string StateName { get; set; }

		[DisplayName("SalesForm Tax")]
		/// <summary>
		/// SalesForm Tax
		/// </summary>
		public decimal SalesTax { get; set; }

		/// <summary>
		/// No argument constructor
		/// </summary>
		public State()
		{
		}

		/// <summary>
		/// All parameter constructor
		/// </summary>
		/// <param name="stateAbbr">State Abbreviation</param>
		/// <param name="stateName">State Name</param>
		/// <param name="salesTax">SalesForm Tax</param>
		public State(string stateAbbr, string stateName, decimal salesTax)
		{
			this.StateAbbr = stateAbbr;
			this.StateName = stateName;
			this.SalesTax = salesTax;
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
			if (obj.GetType() != typeof(State))
				return false;

			// Now it is safe to cast the generic object that was passed in
			// as a State
			State state = (State)obj;

			// In order to see if this instance of an object is equal to the object
			// passed in, we need to check the values.
			if (this.StateAbbr == state.StateAbbr &&
				this.StateName == state.StateName &&
				this.SalesTax == state.SalesTax)
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
		public override int GetHashCode() => (StateAbbr, StateName, SalesTax).GetHashCode();

		/// <summary>
		/// Compares to State objects for equivalence in a logical comparison
		/// </summary>
		/// <param name="state1">State object instance 1</param>
		/// <param name="state2">State object instance 2</param>
		/// <returns>Boolean indicating if the two types are equivalent</returns>
		public static bool operator ==(State state1, State state2)
		{
			if (Object.Equals(state1, null))
				if (Object.Equals(state2, null))
					return true;
				else
					return false;
			else
				return state1.Equals(state2);
		}

		/// <summary>
		/// Compares to State objects to determine if they are not equivalent 
		/// in a logical comparison
		/// </summary>
		/// <param name="state1">State object instance 1</param>
		/// <param name="state2">State object instance 2</param>
		/// <returns>Boolean indicating if the two States are equivalent</returns>
		public static bool operator !=(State state1, State state2)
		{
			// Dependent on the prior implementation of the == operator
			return !(state1 == state2);
		}

		/// <summary>
		/// Provides a String representation of an Object
		/// </summary>
		/// <returns>Returns a String representation of the object</returns>
		public override string ToString()
		{
			return $"State Abbr: {StateAbbr}, State Name: {StateName}, SalesForm Tax: {SalesTax}";
		}
	}
}