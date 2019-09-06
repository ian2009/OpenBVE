namespace OpenBve.TrainManagement
{
	/// <summary>Describes a delayed handle change</summary>
	public struct HandleChange
	{
		/// <summary>The number of notches to move</summary>
		public int Value;
		/// <summary>The time delay in seconds</summary>
		public double Time;
	}
}
