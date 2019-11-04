using OpenBveApi.Math;

namespace Plugin
{
	internal struct FreeObj
	{
		/// <summary>The track position of the object</summary>
		internal double TrackPosition;
		/// <summary>The routefile index of the object</summary>
		internal int Type;
		/// <summary>The position of the object</summary>
		internal Vector2 Position;
		/// <summary>The yaw of the object (radians)</summary>
		internal double Yaw;
		/// <summary>The pitch of the object (radians)</summary>
		internal double Pitch;
		/// <summary>The roll of the object (radians)</summary>
		internal double Roll;
	}
}
