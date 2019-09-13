using SoundManager;

namespace OpenBve.TrainManagement
{
	/// <summary>An entry in a BVE / openBVE MotorSoundTable</summary>
	public struct MotorSoundTableEntry
	{
		/// <summary>The playing sound buffer</summary>
		public SoundBuffer Buffer;
		/// <summary>The motor sound index for this table entry</summary>
		public int SoundIndex;
		/// <summary>The pitch for this table entry</summary>
		public float Pitch;
		/// <summary>The gain for this table entry</summary>
		public float Gain;
	}
}
