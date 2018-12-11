﻿namespace OpenBve
{
    internal static partial class Game
    {
	    /// <summary>The current plugin debug message to be displayed</summary>
	    public static string InfoDebugString = "";

	    /// <summary>The game's current interface type</summary>
        internal enum InterfaceType
        {
            /// <summary>The game is currently showing a normal display</summary>
            Normal,
            /// <summary>The game is currently showing the pause display</summary>
            Pause,
            /// <summary>The game is currently showing a menu</summary>
            Menu,
        }
        /// <summary>Holds a reference to the current interface type of the game (Used by the renderer)</summary>
        internal static InterfaceType CurrentInterface = InterfaceType.Normal;
		/// <summary>Holds a reference to the previous interface type of the game</summary>
		internal static InterfaceType PreviousInterface = InterfaceType.Normal;
		/// <summary>The in-game menu system</summary>
		internal static Menu				Menu				= Menu.Instance;
		/// <summary>The in-game overlay with route info drawings</summary>
		internal static RouteInfoOverlay	routeInfoOverlay	= new RouteInfoOverlay();
    }
}
