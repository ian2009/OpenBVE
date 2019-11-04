using OpenBveApi.Math;

namespace Plugin
{
	internal struct Signal
	{
		internal double TrackPosition;
		internal int SectionIndex;
		internal int SignalCompatibilityObjectIndex;
		internal int SignalObjectIndex;
		internal Vector2 Position;
		internal double Yaw;
		internal double Pitch;
		internal double Roll;
		internal bool ShowObject;
		internal bool ShowPost;
	}
}
