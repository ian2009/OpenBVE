using OpenBveApi.Math;

namespace Plugin
{
	internal struct Transponder
	{
		internal double TrackPosition;
		internal int Type;
		internal bool ShowDefaultObject;
		internal int BeaconStructureIndex;
		internal int Data;
		internal int SectionIndex;
		internal bool ClipToFirstRedSection;
		internal Vector2 Position;
		internal double Yaw;
		internal double Pitch;
		internal double Roll;
	}
}
