using OpenBveApi.Math;

namespace Plugin
{
	internal struct DestinationEvent
	{
		internal double TrackPosition;
		internal int Type;
		internal bool TriggerOnce;
		internal int BeaconStructureIndex;
		internal int NextDestination;
		internal int PreviousDestination;
		internal Vector2 Position;
		internal double Yaw;
		internal double Pitch;
		internal double Roll;
	}
}
