using OpenBveApi.Math;

namespace Plugin
{
	internal struct Rail
	{
		internal bool RailStarted;
		internal bool RailStartRefreshed;
		internal Vector2 RailStart;
		internal bool RailEnded;
		internal Vector2 RailEnd;
		internal double CurveCant;
	}
}
