using System;

namespace RiverFlowCalculator
{
	public class FloodingException : Exception
	{
		public FloodingException()
		{}

		public FloodingException(string message) : base(message)
		{}

		public FloodingException(string message, Exception inner) : base(message, inner)
		{}
	}
}
