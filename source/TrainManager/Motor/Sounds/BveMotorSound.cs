using OpenBveApi.Math;

namespace OpenBve.TrainManagement
{
	/// <summary>Represents a motor sound set in BVE2 / BVE4 / openBVE format</summary>
	public struct BveMotorSound
	{
		/// <summary>The motor sound tables for MotorP1, MotorP2 etc.</summary>
		public MotorSoundTable[] Tables;
		/// <summary>The sound position within the motor car</summary>
		public Vector3 Position;
		/// <summary>The speed conversion factor being applied</summary>
		public double SpeedConversionFactor;
		/// <summary>The current acceleration direction</summary>
		public int CurrentAccelerationDirection;
		public const int MotorP1 = 0;
		public const int MotorP2 = 1;
		public const int MotorB1 = 2;
		public const int MotorB2 = 3;
	}
}
