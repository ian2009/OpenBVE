﻿using OpenBveApi.Colors;
using OpenBveApi.Math;
using OpenBveShared;

namespace OpenBve
{
	internal static partial class HUD
	{
		internal class Element
		{
			internal string Subject;
			internal Vector2 Position;
			internal Vector2 Alignment;
			internal Image TopLeft;
			internal Image TopMiddle;
			internal Image TopRight;
			internal Image CenterLeft;
			internal Image CenterMiddle;
			internal Image CenterRight;
			internal Image BottomLeft;
			internal Image BottomMiddle;
			internal Image BottomRight;
			internal Color32 BackgroundColor;
			internal Color32 OverlayColor;
			internal Color32 TextColor;
			internal Vector2 TextPosition;
			internal Vector2 TextAlignment;
			internal Fonts.OpenGlFont Font;
			internal bool TextShadow;
			internal string Text;
			internal float Value1;
			internal float Value2;
			internal Transition Transition;
			internal Vector2 TransitionVector;
			internal double TransitionState;
			internal Element()
			{
				this.Subject = null;
				this.Position = new Vector2();
				this.Alignment = new Vector2(-1, -1);
				this.BackgroundColor = new Color32(255, 255, 255, 255);
				this.OverlayColor = new Color32(255, 255, 255, 255);
				this.TextColor = new Color32(255, 255, 255, 255);
				this.TextPosition = new Vector2();
				this.TextAlignment = new Vector2(-1, 0);
				this.Font = Fonts.VerySmallFont;
				this.TextShadow = true;
				this.Text = null;
				this.Value1 = 0.0f;
				this.Value2 = 0.0f;
				this.Transition = Transition.None;
				this.TransitionState = 1.0;
			}
		}
	}
}
