﻿using System;
using OpenBveApi.Colors;
using OpenBveApi.Graphics;
using OpenBveApi.Runtime;
using OpenBveApi.Textures;
using OpenTK.Graphics.OpenGL;
using OpenBveShared;

namespace OpenBve
{
	internal static partial class Renderer
	{
		/* --------------------------------------------------------------
		 * This file contains the base drawing routines for screen overlays
		 * -------------------------------------------------------------- */
		
		/// <summary>Is called once by the main renderer loop, in order to render all overlays shown on the screen</summary>
		/// <param name="TimeElapsed">The time elapsed since the last call to this function</param>
		private static void RenderOverlays(double TimeElapsed)
		{
			//Initialize openGL
			GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
			GL.Enable(EnableCap.Blend); OpenBveShared.Renderer.BlendEnabled = true;
			GL.MatrixMode(MatrixMode.Projection);
			GL.PushMatrix();
			GL.LoadIdentity();
			GL.Ortho(0.0, (double)OpenBveShared.Renderer.Width, (double)OpenBveShared.Renderer.Height, 0.0, -1.0, 1.0);
			GL.MatrixMode(MatrixMode.Modelview);
			GL.PushMatrix();
			GL.LoadIdentity();
			//Check which overlays to show
			switch (CurrentOutputMode)
			{
				case OutputMode.Default:
					
						//Route info overlay (if selected)
						Game.routeInfoOverlay.Show();
						//HUD
						for (int i = 0; i < HUD.CurrentHudElements.Length; i++)
						{
							string Command = HUD.CurrentHudElements[i].Subject.ToLowerInvariant();
							switch (Command)
							{
								case "messages":
									{
										RenderGameMessages(HUD.CurrentHudElements[i], TimeElapsed);
									}
									break;
								case "scoremessages":
									{
										RenderScoreMessages(HUD.CurrentHudElements[i], TimeElapsed);
									}
									break;
								case "ats":
									{
										RenderATSLamps(HUD.CurrentHudElements[i], TimeElapsed);
									}
									break;
								default:
									{
										RenderHUDElement(HUD.CurrentHudElements[i], TimeElapsed);
									}
									break;
							}
						}
						//Marker textures
						if (Interface.CurrentOptions.GameMode != Interface.GameMode.Expert)
						{
							double y = 8.0;
							for (int i = 0; i < Game.MarkerTextures.Length; i++)
							{
								if (Textures.LoadTexture(Game.MarkerTextures[i], OpenGlTextureWrapMode.ClampClamp))
								{
									double w = (double)Game.MarkerTextures[i].Width;
									double h = (double)Game.MarkerTextures[i].Height;
									GL.Color4(1.0f, 1.0f, 1.0f, 1.0f);
									OpenBveShared.Renderer.RenderOverlayTexture(Game.MarkerTextures[i], (double)OpenBveShared.Renderer.Width - w - 8.0, y, (double)OpenBveShared.Renderer.Width - 8.0, y + h);
									y += h + 8.0;
								}
							}
						}
						//Timetable overlay
						//NOTE: Only affects auto-generated timetable, possibly change this inconsistant behaviour
						if (OpenBveShared.Timetable.CurrentTimetable == TimetableState.Default)
						{
							// default
							if (Textures.LoadTexture(Timetable.DefaultTimetableTexture, OpenGlTextureWrapMode.ClampClamp))
							{
								int w = Timetable.DefaultTimetableTexture.Width;
								int h = Timetable.DefaultTimetableTexture.Height;
								GL.Color4(1.0f, 1.0f, 1.0f, 1.0f);
								OpenBveShared.Renderer.RenderOverlayTexture(Timetable.DefaultTimetableTexture, (double)(OpenBveShared.Renderer.Width - w), Timetable.DefaultTimetablePosition, (double)OpenBveShared.Renderer.Width, (double)h + Timetable.DefaultTimetablePosition);
							}
						}
						else if (OpenBveShared.Timetable.CurrentTimetable == TimetableState.Custom & Timetable.CustomObjectsUsed == 0)
					{
						// custom
						if (Textures.LoadTexture(Timetable.CurrentCustomTimetableDaytimeTexture, OpenGlTextureWrapMode.ClampClamp))
						{
							int w = Timetable.CurrentCustomTimetableDaytimeTexture.Width;
							int h = Timetable.CurrentCustomTimetableDaytimeTexture.Height;
							GL.Color4(1.0f, 1.0f, 1.0f, 1.0f);
							OpenBveShared.Renderer.RenderOverlayTexture(Timetable.CurrentCustomTimetableDaytimeTexture, (double) (OpenBveShared.Renderer.Width - w), Timetable.CustomTimetablePosition, (double) OpenBveShared.Renderer.Width, (double) h + Timetable.CustomTimetablePosition);
						}

						if (Textures.LoadTexture(Timetable.CurrentCustomTimetableDaytimeTexture, OpenGlTextureWrapMode.ClampClamp))
						{
							int w = Timetable.CurrentCustomTimetableDaytimeTexture.Width;
							int h = Timetable.CurrentCustomTimetableDaytimeTexture.Height;
							float alpha;
							if (Timetable.CurrentCustomTimetableDaytimeTexture != null)
							{
								double t = (TrainManager.PlayerTrain.Cars[TrainManager.PlayerTrain.DriverCar].FrontAxle.Follower.TrackPosition - TrainManager.PlayerTrain.Cars[TrainManager.PlayerTrain.DriverCar].Brightness.PreviousTrackPosition) / (TrainManager.PlayerTrain.Cars[TrainManager.PlayerTrain.DriverCar].Brightness.NextTrackPosition - TrainManager.PlayerTrain.Cars[TrainManager.PlayerTrain.DriverCar].Brightness.PreviousTrackPosition);
								alpha = (float) ((1.0 - t) * TrainManager.PlayerTrain.Cars[TrainManager.PlayerTrain.DriverCar].Brightness.PreviousBrightness + t * TrainManager.PlayerTrain.Cars[TrainManager.PlayerTrain.DriverCar].Brightness.NextBrightness);
							}
							else
							{
								alpha = 1.0f;
							}

							GL.Color4(1.0f, 1.0f, 1.0f, alpha);
							OpenBveShared.Renderer.RenderOverlayTexture(Timetable.CurrentCustomTimetableDaytimeTexture, (double) (OpenBveShared.Renderer.Width - w), Timetable.CustomTimetablePosition, (double) OpenBveShared.Renderer.Width, (double) h + Timetable.CustomTimetablePosition);
						}
					}
					break;
				case OutputMode.Debug:
					RenderDebugOverlays();
					break;
				case OutputMode.DebugATS:
					RenderATSDebugOverlay();
					break;
			}
			// air brake debug output
			if (Interface.CurrentOptions.GameMode != Interface.GameMode.Expert & OptionBrakeSystems)
			{
				RenderBrakeSystemDebug();
			}
			//If paused, fade out the screen & write PAUSE
			if (Game.CurrentInterface == Game.InterfaceType.Pause)
			{
				// pause
				GL.Color4(0.0f, 0.0f, 0.0f, 0.5f);
				OpenBveShared.Renderer.RenderOverlaySolid(0.0, 0.0, (double)OpenBveShared.Renderer.Width, (double)OpenBveShared.Renderer.Height);
				GL.Color4(1.0f, 1.0f, 1.0f, 1.0f);
				OpenBveShared.Renderer.DrawString(Fonts.VeryLargeFont, "PAUSE", new System.Drawing.Point(OpenBveShared.Renderer.Width / 2, OpenBveShared.Renderer.Height / 2), TextAlignment.CenterMiddle, Color128.White, true);
			}
			else if (Game.CurrentInterface == Game.InterfaceType.Menu)
				Game.Menu.Draw();
			//Fade to black on change ends
			if (TrainManager.PlayerTrain.Station >= 0 && Game.Stations[TrainManager.PlayerTrain.Station].Type == StationType.ChangeEnds && TrainManager.PlayerTrain.StationState == TrainManager.TrainStopState.Boarding)
			{
				double time = TrainManager.PlayerTrain.StationDepartureTime - Game.SecondsSinceMidnight;
				if (time < 1.0)
				{
					FadeToBlackDueToChangeEnds = Math.Max(0.0, 1.0 - time);
				}
				else if (FadeToBlackDueToChangeEnds > 0.0)
				{
					FadeToBlackDueToChangeEnds -= TimeElapsed;
					if (FadeToBlackDueToChangeEnds < 0.0)
					{
						FadeToBlackDueToChangeEnds = 0.0;
					}
				}
			}
			else if (FadeToBlackDueToChangeEnds > 0.0)
			{
				FadeToBlackDueToChangeEnds -= TimeElapsed;
				if (FadeToBlackDueToChangeEnds < 0.0)
				{
					FadeToBlackDueToChangeEnds = 0.0;
				}
			}
			if (FadeToBlackDueToChangeEnds > 0.0 & (Camera.CameraView == CameraViewMode.Interior | Camera.CameraView == CameraViewMode.InteriorLookAhead))
			{
				GL.Color4(0.0, 0.0, 0.0, FadeToBlackDueToChangeEnds);
				OpenBveShared.Renderer.RenderOverlaySolid(0.0, 0.0, (double)OpenBveShared.Renderer.Width, (double)OpenBveShared.Renderer.Height);
			}
			// finalize
			GL.PopMatrix();
			GL.MatrixMode(MatrixMode.Projection);
			GL.PopMatrix();
			GL.MatrixMode(MatrixMode.Modelview);
			GL.Disable(EnableCap.Blend);
		}	
	}
}
