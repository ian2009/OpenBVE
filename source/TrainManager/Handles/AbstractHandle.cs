using SoundManager;

namespace OpenBve.TrainManagement
{
	public abstract class AbstractHandle
	{
		/// <summary>The notch set by the driver</summary>
		public int Driver;
		/// <summary>The notch set by the safety sytem</summary>
		public int Safety;
		/// <summary>The actual notch, as used by the physics system etc.</summary>
		public int Actual;
		/// <summary>The maximum notch this handle may be advanced to</summary>
		public int MaximumNotch;
		/// <summary>The maximum notch the driver may advance this handle to</summary>
		public int MaximumDriverNotch;

		public HandleChange[] DelayedChanges;
		/// <summary>Whether the current handle motion is a continuous motion</summary>
		public bool ContinuousMovement;
		/// <summary>The sound played when the handle position is increased</summary>
		public CarSound Increase;
		/// <summary>The sound played when the handle position is increased in a fast motion</summary>
		public CarSound IncreaseFast;
		/// <summary>The sound played when the handle position is decreased</summary>
		public CarSound Decrease;
		/// <summary>The sound played when the handle position is decreased in a fast motion</summary>
		public CarSound DecreaseFast;
		/// <summary>The sound played when the handle is moved to the minimum position</summary>
		public CarSound Min;
		/// <summary>The sound played when the handles is moved to the maximum position</summary>
		public CarSound Max;

		public abstract void Update();

		public AbstractHandle()
		{
			Increase = new CarSound();
			IncreaseFast = new CarSound();
			Decrease = new CarSound();
			DecreaseFast = new CarSound();
			Min = new CarSound();
			Max = new CarSound();
		}
	}
}
