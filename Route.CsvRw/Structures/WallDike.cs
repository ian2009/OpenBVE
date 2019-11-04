namespace Plugin
{
	internal struct WallDike
	{
		/// <summary>Whether the wall/ dike is shown for this block</summary>
		internal bool Exists;
		/// <summary>The routefile index of the object</summary>
		internal int Type;
		/// <summary>The direction the object(s) are placed in: -1 for left, 0 for both, 1 for right</summary>
		internal int Direction;
	}
}
