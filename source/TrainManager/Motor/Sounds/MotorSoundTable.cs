using SoundManager;

namespace OpenBve.TrainManagement
{
	/// <summary>A table of motor sounds to be played</summary>
	public struct MotorSoundTable
	{
		/// <summary>The table entries</summary>
		public MotorSoundTableEntry[] Entries;
		/// <summary>The sound buffer</summary>
		public SoundBuffer Buffer;
		/// <summary>The sound source to emit</summary>
		public SoundSource Source;
	}
}
