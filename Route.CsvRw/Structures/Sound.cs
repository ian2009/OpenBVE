using OpenBveApi.Math;
using OpenBveApi.Sounds;

namespace Plugin
{
	internal struct Sound
	{
		internal double TrackPosition;
		internal SoundHandle SoundBuffer;
		internal SoundType Type;
		internal Vector2 Position;
		//TODO:
		//This is always set to a constant 15.0 on loading a sound, and never touched again
		//I presume Michelle intended to have sounds with different radii available
		//This would require a custom or extended command which allowed the radius value to be set
#pragma warning disable 414
		internal double Radius;
#pragma warning restore 414
		internal double Speed;
		internal bool IsMicSound;
		internal double ForwardTolerance;
		internal double BackwardTolerance;
	}
}
