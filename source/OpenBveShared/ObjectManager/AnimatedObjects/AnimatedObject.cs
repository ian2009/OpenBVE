﻿using System;
using CSScriptLibrary;
using OpenBveApi;
using OpenBveApi.FunctionScripting;
using OpenBveApi.Interface;
using OpenBveApi.Math;
using OpenBveApi.Objects;
using OpenBveApi.World;

namespace OpenBveShared
{
	internal class AnimatedObject : AbstractAnimatedObject
		{			
			/// <summary>Clones this object</summary>
			/// <returns>The new object</returns>
			internal AnimatedObject Clone()
			{
				AnimatedObject Result = new AnimatedObject { States = new AnimatedObjectState[this.States.Length] };
				for (int i = 0; i < this.States.Length; i++)
				{
					Result.States[i].Position = this.States[i].Position;
					if (this.States[i].Object != null)
					{
						Result.States[i].Object = this.States[i].Object.Clone();
					}
				}
				Result.TrackFollowerFunction = this.TrackFollowerFunction == null ? null : this.TrackFollowerFunction.Clone();
				Result.FrontAxlePosition = this.FrontAxlePosition;
				Result.RearAxlePosition = this.RearAxlePosition;
				Result.TranslateXScriptFile = this.TranslateXScriptFile;
				Result.StateFunction = this.StateFunction == null ? null : this.StateFunction.Clone();
				Result.CurrentState = this.CurrentState;
				Result.TranslateZDirection = this.TranslateZDirection;
				Result.TranslateYDirection = this.TranslateYDirection;
				Result.TranslateXDirection = this.TranslateXDirection;
				Result.TranslateXFunction = this.TranslateXFunction == null ? null : this.TranslateXFunction.Clone();
				Result.TranslateYFunction = this.TranslateYFunction == null ? null : this.TranslateYFunction.Clone();
				Result.TranslateZFunction = this.TranslateZFunction == null ? null : this.TranslateZFunction.Clone();
				Result.RotateXDirection = this.RotateXDirection;
				Result.RotateYDirection = this.RotateYDirection;
				Result.RotateZDirection = this.RotateZDirection;
				Result.RotateXFunction = this.RotateXFunction == null ? null : this.RotateXFunction.Clone();
				Result.RotateXDamping = this.RotateXDamping == null ? null : this.RotateXDamping.Clone();
				Result.RotateYFunction = this.RotateYFunction == null ? null : this.RotateYFunction.Clone();
				Result.RotateYDamping = this.RotateYDamping == null ? null : this.RotateYDamping.Clone();
				Result.RotateZFunction = this.RotateZFunction == null ? null : this.RotateZFunction.Clone();
				Result.RotateZDamping = this.RotateZDamping == null ? null : this.RotateZDamping.Clone();
				Result.TextureShiftXDirection = this.TextureShiftXDirection;
				Result.TextureShiftYDirection = this.TextureShiftYDirection;
				Result.TextureShiftXFunction = this.TextureShiftXFunction == null ? null : this.TextureShiftXFunction.Clone();
				Result.TextureShiftYFunction = this.TextureShiftYFunction == null ? null : this.TextureShiftYFunction.Clone();
				Result.LEDClockwiseWinding = this.LEDClockwiseWinding;
				Result.LEDInitialAngle = this.LEDInitialAngle;
				Result.LEDLastAngle = this.LEDLastAngle;
				if (this.LEDVectors != null)
				{
					Result.LEDVectors = new Vector3[this.LEDVectors.Length];
					for (int i = 0; i < this.LEDVectors.Length; i++)
					{
						Result.LEDVectors[i] = this.LEDVectors[i];
					}
				}
				else
				{
					Result.LEDVectors = null;
				}
				Result.LEDFunction = this.LEDFunction == null ? null : this.LEDFunction.Clone();
				Result.RefreshRate = this.RefreshRate;
				Result.SecondsSinceLastUpdate = 0.0;
				Result.ObjectIndex = -1;
				return Result;
			}

			internal void Initialize(int StateIndex, bool Overlay, bool Show)
			{
				int i = ObjectIndex;
				OpenBveShared.Renderer.HideObject(i);
				int t = StateIndex;
				if (t >= 0 && States[t].Object != null)
				{
					int m = States[t].Object.Mesh.Vertices.Length;
					GameObjectManager.Objects[i].Mesh.Vertices = new VertexTemplate[m];
					for (int k = 0; k < m; k++)
					{
						if (States[t].Object.Mesh.Vertices[k] is ColoredVertex)
						{
							GameObjectManager.Objects[i].Mesh.Vertices[k] = new ColoredVertex((ColoredVertex)States[t].Object.Mesh.Vertices[k]);
						}
						else
						{
							GameObjectManager.Objects[i].Mesh.Vertices[k] = new Vertex((Vertex)States[t].Object.Mesh.Vertices[k]);
						}
						
					}
					m = States[t].Object.Mesh.Faces.Length;
					GameObjectManager.Objects[i].Mesh.Faces = new MeshFace[m];
					for (int k = 0; k < m; k++)
					{
						GameObjectManager.Objects[i].Mesh.Faces[k].Flags = States[t].Object.Mesh.Faces[k].Flags;
						GameObjectManager.Objects[i].Mesh.Faces[k].Material = States[t].Object.Mesh.Faces[k].Material;
						int o = States[t].Object.Mesh.Faces[k].Vertices.Length;
						GameObjectManager.Objects[i].Mesh.Faces[k].Vertices = new MeshFaceVertex[o];
						for (int h = 0; h < o; h++)
						{
							GameObjectManager.Objects[i].Mesh.Faces[k].Vertices[h] = States[t].Object.Mesh.Faces[k].Vertices[h];
						}
					}
					GameObjectManager.Objects[i].Mesh.Materials = States[t].Object.Mesh.Materials;
				}
				else
				{
					GameObjectManager.Objects[i] = null;
					GameObjectManager.Objects[i] = new StaticObject(this.CurrentHost)
					{
						Mesh =
						{
							Faces = new MeshFace[] {},
							Materials = new MeshMaterial[] {},
							Vertices = new VertexTemplate[] {}
						}
					};
				}
				CurrentState = StateIndex;
				if (Show)
				{
					if (Overlay)
					{
						Renderer.ShowObject(i, ObjectType.Overlay, Interface.CurrentOptions.TransparencyMode, World.CameraRestriction != Camera.RestrictionMode.NotAvailable);
					}
					else
					{
						Renderer.ShowObject(i, ObjectType.Dynamic, Interface.CurrentOptions.TransparencyMode, World.CameraRestriction != Camera.RestrictionMode.NotAvailable);
					}
				}
			}

			/// <summary> Updates the position and state of the animated object</summary>
			/// <param name="IsPartOfTrain">Whether this object forms part of a train</param>
			/// <param name="Train">The train, or a null reference otherwise</param>
			/// <param name="CarIndex">If this object forms part of a train, the car index it refers to</param>
			/// <param name="SectionIndex">If this object has been placed via Track.Sig, the index of the section it is attached to</param>
			/// <param name="TrackPosition"></param>
			/// <param name="Position"></param>
			/// <param name="Direction"></param>
			/// <param name="Up"></param>
			/// <param name="Side"></param>
			/// <param name="Overlay">Whether this object should be overlaid over the other objects on-screen (Forms part of the cab etc.)</param>
			/// <param name="UpdateFunctions">Whether the functions associated with this object should be re-evaluated</param>
			/// <param name="Show"></param>
			/// <param name="TimeElapsed">The time elapsed since this object was last updated</param>
			/// <param name="EnableDamping">Whether damping is to be applied for this call</param>
			internal void Update(bool IsPartOfTrain, Train Train, int CarIndex, int SectionIndex, double TrackPosition, Vector3 Position, Vector3 Direction, Vector3 Up, Vector3 Side, bool Overlay, bool UpdateFunctions, bool Show, double TimeElapsed, bool EnableDamping)
			{
				int s = CurrentState;
				int i = ObjectIndex;
				// state change
				if (StateFunction != null & UpdateFunctions)
				{
					double sd = StateFunction.Perform(Train, CarIndex, Position, TrackPosition, SectionIndex, IsPartOfTrain, TimeElapsed, CurrentState);
					int si = (int)Math.Round(sd);
					int sn = States.Length;
					if (si < 0 | si >= sn) si = -1;
					if (s != si)
					{
						Initialize(si, Overlay, Show);
						s = si;
					}
				}
				if (s == -1) return;
				// translation
				if (TranslateXFunction != null)
				{
					double x;
					if (UpdateFunctions)
					{
						x = TranslateXFunction.Perform(Train, CarIndex, Position, TrackPosition, SectionIndex, IsPartOfTrain, TimeElapsed, CurrentState);
					}
					else
					{
						x = TranslateXFunction.LastResult;
					}
					Vector3 translationVector = new Vector3(TranslateXDirection); //Must clone
					translationVector.Rotate(Direction, Up, Side);
					translationVector *= x;
					Position += translationVector;
				}
				else if (TranslateXScriptFile != null)
				{
					//Translate X Script
					if (TranslateXAnimationScript == null)
					{
						//Load the script if required
						try
						{
							CSScript.GlobalSettings.TargetFramework = "v4.0";
							TranslateXAnimationScript = CSScript.LoadCodeFrom(TranslateXScriptFile)
								.CreateObject("OpenBVEScript")
								.AlignToInterface<AnimationScript>(true);
						}
						catch
						{
							Interface.AddMessage(MessageType.Error, false,
								"An error occcured whilst parsing script " + TranslateXScriptFile);
							TranslateXScriptFile = null;
							return;
						}
					}
					double x = TranslateXAnimationScript.ExecuteScript(Train, Position, TrackPosition, SectionIndex,
						IsPartOfTrain, TimeElapsed);
					Vector3 translationVector = new Vector3(TranslateXDirection); //Must clone
					translationVector.Rotate(Direction, Up, Side);
					translationVector *= x;
					Position += translationVector;
				}


				if (TranslateYFunction != null)
				{
					double y;
					if (UpdateFunctions)
					{
						y = TranslateYFunction.Perform(Train, CarIndex, Position, TrackPosition, SectionIndex, IsPartOfTrain, TimeElapsed, CurrentState);
					}
					else
					{
						y = TranslateYFunction.LastResult;
					}
					Vector3 translationVector = new Vector3(TranslateYDirection); //Must clone
					translationVector.Rotate(Direction, Up, Side);
					translationVector *= y;
					Position += translationVector;
				}
				else if (TranslateYScriptFile != null)
				{
					//Translate X Script
					if (TranslateYAnimationScript == null)
					{
						//Load the script if required
						try
						{
							CSScript.GlobalSettings.TargetFramework = "v4.0";
							TranslateYAnimationScript = CSScript.LoadCodeFrom(TranslateYScriptFile)
								.CreateObject("OpenBVEScript")
								.AlignToInterface<AnimationScript>(true);
						}
						catch
						{
							Interface.AddMessage(MessageType.Error, false,
								"An error occcured whilst parsing script " + TranslateYScriptFile);
							TranslateYScriptFile = null;
							return;
						}
					}
					double y = TranslateYAnimationScript.ExecuteScript(Train, Position, TrackPosition, SectionIndex,
						IsPartOfTrain, TimeElapsed);
					Vector3 translationVector = new Vector3(TranslateYDirection); //Must clone
					translationVector.Rotate(Direction, Up, Side);
					translationVector *= y;
					Position += translationVector;
				}

				if (TranslateZFunction != null)
				{
					double z;
					if (UpdateFunctions)
					{
						z = TranslateZFunction.Perform(Train, CarIndex, Position, TrackPosition, SectionIndex, IsPartOfTrain, TimeElapsed, CurrentState);
					}
					else
					{
						z = TranslateZFunction.LastResult;
					}
					Vector3 translationVector = new Vector3(TranslateZDirection); //Must clone
					translationVector.Rotate(Direction, Up, Side);
					translationVector *= z;
					Position += translationVector;
				}
				else if (TranslateZScriptFile != null)
				{
					//Translate X Script
					if (TranslateZAnimationScript == null)
					{
						//Load the script if required
						try
						{
							CSScript.GlobalSettings.TargetFramework = "v4.0";
							TranslateZAnimationScript = CSScript.LoadCodeFrom(TranslateZScriptFile)
								.CreateObject("OpenBVEScript")
								.AlignToInterface<AnimationScript>(true);
						}
						catch
						{
							Interface.AddMessage(MessageType.Error, false,
								"An error occcured whilst parsing script " + TranslateZScriptFile);
							TranslateZScriptFile = null;
							return;
						}
					}
					double z = TranslateZAnimationScript.ExecuteScript(Train, Position, TrackPosition, SectionIndex,
						IsPartOfTrain, TimeElapsed);
					Vector3 translationVector = new Vector3(TranslateZDirection); //Must clone
					translationVector.Rotate(Direction, Up, Side);
					translationVector *= z;
					Position += translationVector;
				}
				// rotation
				bool rotateX = RotateXFunction != null;
				bool rotateY = RotateYFunction != null;
				bool rotateZ = RotateZFunction != null;
				double cosX, sinX;
				if (rotateX)
				{
					double a;
					if (UpdateFunctions)
					{
						a = RotateXFunction.Perform(Train, CarIndex, Position, TrackPosition, SectionIndex, IsPartOfTrain, TimeElapsed, CurrentState);
					}
					else
					{
						a = RotateXFunction.LastResult;
					}
					if (RotateXDamping != null)
					{
						RotateXDamping.Update(TimeElapsed, ref a, EnableDamping);
					}
					cosX = Math.Cos(a);
					sinX = Math.Sin(a);
				}
				else
				{
					cosX = 0.0; sinX = 0.0;
				}
				double cosY, sinY;
				if (rotateY)
				{
					double a;
					if (UpdateFunctions)
					{
						a = RotateYFunction.Perform(Train, CarIndex, Position, TrackPosition, SectionIndex, IsPartOfTrain, TimeElapsed, CurrentState);
					}
					else
					{
						a = RotateYFunction.LastResult;
					}
					if (RotateYDamping != null)
					{
						RotateYDamping.Update(TimeElapsed, ref a, EnableDamping);
					}
					cosY = Math.Cos(a);
					sinY = Math.Sin(a);
				}
				else
				{
					cosY = 0.0; sinY = 0.0;
				}
				double cosZ, sinZ;
				if (rotateZ)
				{
					double a;
					if (UpdateFunctions)
					{
						a = RotateZFunction.Perform(Train, CarIndex, Position, TrackPosition, SectionIndex, IsPartOfTrain, TimeElapsed, CurrentState);
					}
					else
					{
						a = RotateZFunction.LastResult;
					}
					if (RotateZDamping != null)
					{
						RotateZDamping.Update(TimeElapsed, ref a, EnableDamping);
					}
					cosZ = Math.Cos(a);
					sinZ = Math.Sin(a);
				}
				else
				{
					cosZ = 0.0; sinZ = 0.0;
				}
				// texture shift
				bool shiftx = TextureShiftXFunction != null;
				bool shifty = TextureShiftYFunction != null;
				if ((shiftx | shifty) & UpdateFunctions)
				{
					for (int k = 0; k < GameObjectManager.Objects[i].Mesh.Vertices.Length; k++)
					{
						GameObjectManager.Objects[i].Mesh.Vertices[k].TextureCoordinates = States[s].Object.Mesh.Vertices[k].TextureCoordinates;
					}
					if (shiftx)
					{
						double x = TextureShiftXFunction.Perform(Train, CarIndex, Position, TrackPosition, SectionIndex, IsPartOfTrain, TimeElapsed, CurrentState);
						x -= Math.Floor(x);
						for (int k = 0; k < GameObjectManager.Objects[i].Mesh.Vertices.Length; k++)
						{
							GameObjectManager.Objects[i].Mesh.Vertices[k].TextureCoordinates.X += (float)(x * TextureShiftXDirection.X);
							GameObjectManager.Objects[i].Mesh.Vertices[k].TextureCoordinates.Y += (float)(x * TextureShiftXDirection.Y);
						}
					}
					if (shifty)
					{
						double y = TextureShiftYFunction.Perform(Train, CarIndex, Position, TrackPosition, SectionIndex, IsPartOfTrain, TimeElapsed, CurrentState);
						y -= Math.Floor(y);
						for (int k = 0; k < GameObjectManager.Objects[i].Mesh.Vertices.Length; k++)
						{
							GameObjectManager.Objects[i].Mesh.Vertices[k].TextureCoordinates.X += (float)(y * TextureShiftYDirection.X);
							GameObjectManager.Objects[i].Mesh.Vertices[k].TextureCoordinates.Y += (float)(y * TextureShiftYDirection.Y);
						}
					}
				}
				// led
				bool led = LEDFunction != null;
				double ledangle;
				if (led)
				{
					if (UpdateFunctions)
					{
						ledangle = LEDFunction.Perform(Train, CarIndex, Position, TrackPosition, SectionIndex, IsPartOfTrain, TimeElapsed, CurrentState);
					}
					else
					{
						ledangle = LEDFunction.LastResult;
					}
				}
				else
				{
					ledangle = 0.0;
				}
				// null object
				if (States[s].Object == null)
				{
					return;
				}
				// initialize vertices
				for (int k = 0; k < States[s].Object.Mesh.Vertices.Length; k++)
				{
					GameObjectManager.Objects[i].Mesh.Vertices[k].Coordinates = States[s].Object.Mesh.Vertices[k].Coordinates;
				}
				// led
				if (led)
				{
					/*
					 * Edges:         Vertices:
					 * 0 - bottom     0 - bottom-left
					 * 1 - left       1 - top-left
					 * 2 - top        2 - top-right
					 * 3 - right      3 - bottom-right
					 *                4 - center
					 * */
					int v = 1;
					if (LEDClockwiseWinding)
					{
						/* winding is clockwise*/
						if (ledangle < LEDInitialAngle)
						{
							ledangle = LEDInitialAngle;
						}
						if (ledangle < LEDLastAngle)
						{
							double currentEdgeFloat = Math.Floor(0.636619772367582 * (ledangle + 0.785398163397449));
							int currentEdge = ((int)currentEdgeFloat % 4 + 4) % 4;
							double lastEdgeFloat = Math.Floor(0.636619772367582 * (LEDLastAngle + 0.785398163397449));
							int lastEdge = ((int)lastEdgeFloat % 4 + 4) % 4;
							if (lastEdge < currentEdge | lastEdge == currentEdge & Math.Abs(currentEdgeFloat - lastEdgeFloat) > 2.0)
							{
								lastEdge += 4;
							}
							if (currentEdge == lastEdge)
							{
								/* current angle to last angle */
								{
									double t = 0.5 + (0.636619772367582 * ledangle) - currentEdgeFloat;
									if (t < 0.0)
									{
										t = 0.0;
									}
									else if (t > 1.0)
									{
										t = 1.0;
									}
									t = 0.5 * (1.0 - Math.Tan(0.25 * (Math.PI - 2.0 * Math.PI * t)));
									double cx = (1.0 - t) * LEDVectors[(currentEdge + 3) % 4].X + t * LEDVectors[currentEdge].X;
									double cy = (1.0 - t) * LEDVectors[(currentEdge + 3) % 4].Y + t * LEDVectors[currentEdge].Y;
									double cz = (1.0 - t) * LEDVectors[(currentEdge + 3) % 4].Z + t * LEDVectors[currentEdge].Z;
									States[s].Object.Mesh.Vertices[v].Coordinates = new Vector3(cx, cy, cz);
									v++;
								}
								{
									double t = 0.5 + (0.636619772367582 * LEDLastAngle) - lastEdgeFloat;
									if (t < 0.0)
									{
										t = 0.0;
									}
									else if (t > 1.0)
									{
										t = 1.0;
									}
									t = 0.5 * (1.0 - Math.Tan(0.25 * (Math.PI - 2.0 * Math.PI * t)));
									double lx = (1.0 - t) * LEDVectors[(lastEdge + 3) % 4].X + t * LEDVectors[lastEdge].X;
									double ly = (1.0 - t) * LEDVectors[(lastEdge + 3) % 4].Y + t * LEDVectors[lastEdge].Y;
									double lz = (1.0 - t) * LEDVectors[(lastEdge + 3) % 4].Z + t * LEDVectors[lastEdge].Z;
									States[s].Object.Mesh.Vertices[v].Coordinates = new Vector3(lx, ly, lz);
									v++;
								}
							}
							else
							{
								{
									/* current angle to square vertex */
									double t = 0.5 + (0.636619772367582 * ledangle) - currentEdgeFloat;
									if (t < 0.0)
									{
										t = 0.0;
									}
									else if (t > 1.0)
									{
										t = 1.0;
									}
									t = 0.5 * (1.0 - Math.Tan(0.25 * (Math.PI - 2.0 * Math.PI * t)));
									double cx = (1.0 - t) * LEDVectors[(currentEdge + 3) % 4].X + t * LEDVectors[currentEdge].X;
									double cy = (1.0 - t) * LEDVectors[(currentEdge + 3) % 4].Y + t * LEDVectors[currentEdge].Y;
									double cz = (1.0 - t) * LEDVectors[(currentEdge + 3) % 4].Z + t * LEDVectors[currentEdge].Z;
									States[s].Object.Mesh.Vertices[v + 0].Coordinates = new Vector3(cx, cy, cz);
									States[s].Object.Mesh.Vertices[v + 1].Coordinates = LEDVectors[currentEdge];
									v += 2;
								}
								for (int j = currentEdge + 1; j < lastEdge; j++)
								{
									/* square-vertex to square-vertex */
									States[s].Object.Mesh.Vertices[v + 0].Coordinates = LEDVectors[(j + 3) % 4];
									States[s].Object.Mesh.Vertices[v + 1].Coordinates = LEDVectors[j % 4];
									v += 2;
								}
								{
									/* square vertex to last angle */
									double t = 0.5 + (0.636619772367582 * LEDLastAngle) - lastEdgeFloat;
									if (t < 0.0)
									{
										t = 0.0;
									}
									else if (t > 1.0)
									{
										t = 1.0;
									}
									t = 0.5 * (1.0 - Math.Tan(0.25 * (Math.PI - 2.0 * Math.PI * t)));
									double lx = (1.0 - t) * LEDVectors[(lastEdge + 3) % 4].X + t * LEDVectors[lastEdge % 4].X;
									double ly = (1.0 - t) * LEDVectors[(lastEdge + 3) % 4].Y + t * LEDVectors[lastEdge % 4].Y;
									double lz = (1.0 - t) * LEDVectors[(lastEdge + 3) % 4].Z + t * LEDVectors[lastEdge % 4].Z;
									States[s].Object.Mesh.Vertices[v + 0].Coordinates = LEDVectors[(lastEdge + 3) % 4];
									States[s].Object.Mesh.Vertices[v + 1].Coordinates = new Vector3(lx, ly, lz);
									v += 2;
								}
							}
						}
					}
					else
					{
						/* winding is counter-clockwise*/
						if (ledangle > LEDInitialAngle)
						{
							ledangle = LEDInitialAngle;
						}
						if (ledangle > LEDLastAngle)
						{
							double currentEdgeFloat = Math.Floor(0.636619772367582 * (ledangle + 0.785398163397449));
							int currentEdge = ((int)currentEdgeFloat % 4 + 4) % 4;
							double lastEdgeFloat = Math.Floor(0.636619772367582 * (LEDLastAngle + 0.785398163397449));
							int lastEdge = ((int)lastEdgeFloat % 4 + 4) % 4;
							if (currentEdge < lastEdge | lastEdge == currentEdge & Math.Abs(currentEdgeFloat - lastEdgeFloat) > 2.0)
							{
								currentEdge += 4;
							}
							if (currentEdge == lastEdge)
							{
								/* current angle to last angle */
								{
									double t = 0.5 + (0.636619772367582 * LEDLastAngle) - lastEdgeFloat;
									if (t < 0.0)
									{
										t = 0.0;
									}
									else if (t > 1.0)
									{
										t = 1.0;
									}
									t = 0.5 * (1.0 - Math.Tan(0.25 * (Math.PI - 2.0 * Math.PI * t)));
									double lx = (1.0 - t) * LEDVectors[(lastEdge + 3) % 4].X + t * LEDVectors[lastEdge].X;
									double ly = (1.0 - t) * LEDVectors[(lastEdge + 3) % 4].Y + t * LEDVectors[lastEdge].Y;
									double lz = (1.0 - t) * LEDVectors[(lastEdge + 3) % 4].Z + t * LEDVectors[lastEdge].Z;
									States[s].Object.Mesh.Vertices[v].Coordinates = new Vector3(lx, ly, lz);
									v++;
								}
								{
									double t = 0.5 + (0.636619772367582 * ledangle) - currentEdgeFloat;
									if (t < 0.0)
									{
										t = 0.0;
									}
									else if (t > 1.0)
									{
										t = 1.0;
									}
									t = t - Math.Floor(t);
									t = 0.5 * (1.0 - Math.Tan(0.25 * (Math.PI - 2.0 * Math.PI * t)));
									double cx = (1.0 - t) * LEDVectors[(currentEdge + 3) % 4].X + t * LEDVectors[currentEdge].X;
									double cy = (1.0 - t) * LEDVectors[(currentEdge + 3) % 4].Y + t * LEDVectors[currentEdge].Y;
									double cz = (1.0 - t) * LEDVectors[(currentEdge + 3) % 4].Z + t * LEDVectors[currentEdge].Z;
									States[s].Object.Mesh.Vertices[v].Coordinates = new Vector3(cx, cy, cz);
									v++;
								}
							}
							else
							{
								{
									/* current angle to square vertex */
									double t = 0.5 + (0.636619772367582 * ledangle) - currentEdgeFloat;
									if (t < 0.0)
									{
										t = 0.0;
									}
									else if (t > 1.0)
									{
										t = 1.0;
									}
									t = 0.5 * (1.0 - Math.Tan(0.25 * (Math.PI - 2.0 * Math.PI * t)));
									double cx = (1.0 - t) * LEDVectors[(currentEdge + 3) % 4].X + t * LEDVectors[currentEdge % 4].X;
									double cy = (1.0 - t) * LEDVectors[(currentEdge + 3) % 4].Y + t * LEDVectors[currentEdge % 4].Y;
									double cz = (1.0 - t) * LEDVectors[(currentEdge + 3) % 4].Z + t * LEDVectors[currentEdge % 4].Z;
									States[s].Object.Mesh.Vertices[v + 0].Coordinates = LEDVectors[(currentEdge + 3) % 4];
									States[s].Object.Mesh.Vertices[v + 1].Coordinates = new Vector3(cx, cy, cz);
									v += 2;
								}
								for (int j = currentEdge - 1; j > lastEdge; j--)
								{
									/* square-vertex to square-vertex */
									States[s].Object.Mesh.Vertices[v + 0].Coordinates = LEDVectors[(j + 3) % 4];
									States[s].Object.Mesh.Vertices[v + 1].Coordinates = LEDVectors[j % 4];
									v += 2;
								}
								{
									/* square vertex to last angle */
									double t = 0.5 + (0.636619772367582 * LEDLastAngle) - lastEdgeFloat;
									if (t < 0.0)
									{
										t = 0.0;
									}
									else if (t > 1.0)
									{
										t = 1.0;
									}
									t = 0.5 * (1.0 - Math.Tan(0.25 * (Math.PI - 2.0 * Math.PI * t)));
									double lx = (1.0 - t) * LEDVectors[(lastEdge + 3) % 4].X + t * LEDVectors[lastEdge].X;
									double ly = (1.0 - t) * LEDVectors[(lastEdge + 3) % 4].Y + t * LEDVectors[lastEdge].Y;
									double lz = (1.0 - t) * LEDVectors[(lastEdge + 3) % 4].Z + t * LEDVectors[lastEdge].Z;
									States[s].Object.Mesh.Vertices[v + 0].Coordinates = new Vector3(lx, ly, lz);
									States[s].Object.Mesh.Vertices[v + 1].Coordinates = LEDVectors[lastEdge % 4];
									v += 2;
								}
							}
						}
					}
					for (int j = v; v < 11; v++)
					{
						States[s].Object.Mesh.Vertices[j].Coordinates = LEDVectors[4];
					}
				}
				// update vertices
				for (int k = 0; k < States[s].Object.Mesh.Vertices.Length; k++)
				{
					// rotate
					if (rotateX)
					{
						GameObjectManager.Objects[i].Mesh.Vertices[k].Coordinates.Rotate(RotateXDirection, cosX, sinX);
					}
					if (rotateY)
					{
						GameObjectManager.Objects[i].Mesh.Vertices[k].Coordinates.Rotate(RotateYDirection, cosY, sinY);
					}
					if (rotateZ)
					{
						GameObjectManager.Objects[i].Mesh.Vertices[k].Coordinates.Rotate(RotateZDirection, cosZ, sinZ);
					}
					// translate
					if (Overlay & World.CameraRestriction != Camera.RestrictionMode.NotAvailable)
					{
						GameObjectManager.Objects[i].Mesh.Vertices[k].Coordinates.X += States[s].Position.X - Position.X;
						GameObjectManager.Objects[i].Mesh.Vertices[k].Coordinates.Y += States[s].Position.Y - Position.Y;
						GameObjectManager.Objects[i].Mesh.Vertices[k].Coordinates.Z += States[s].Position.Z - Position.Z;
						GameObjectManager.Objects[i].Mesh.Vertices[k].Coordinates.Rotate(World.AbsoluteCameraDirection, World.AbsoluteCameraUp, World.AbsoluteCameraSide);
						double dx = -Math.Tan(World.CameraCurrentAlignment.Yaw) - World.CameraCurrentAlignment.Position.X;
						double dy = -Math.Tan(World.CameraCurrentAlignment.Pitch) - World.CameraCurrentAlignment.Position.Y;
						double dz = -World.CameraCurrentAlignment.Position.Z;
						GameObjectManager.Objects[i].Mesh.Vertices[k].Coordinates.X += World.AbsoluteCameraPosition.X + dx * World.AbsoluteCameraSide.X + dy * World.AbsoluteCameraUp.X + dz * World.AbsoluteCameraDirection.X;
						GameObjectManager.Objects[i].Mesh.Vertices[k].Coordinates.Y += World.AbsoluteCameraPosition.Y + dx * World.AbsoluteCameraSide.Y + dy * World.AbsoluteCameraUp.Y + dz * World.AbsoluteCameraDirection.Y;
						GameObjectManager.Objects[i].Mesh.Vertices[k].Coordinates.Z += World.AbsoluteCameraPosition.Z + dx * World.AbsoluteCameraSide.Z + dy * World.AbsoluteCameraUp.Z + dz * World.AbsoluteCameraDirection.Z;
					}
					else
					{
						GameObjectManager.Objects[i].Mesh.Vertices[k].Coordinates.X += States[s].Position.X;
						GameObjectManager.Objects[i].Mesh.Vertices[k].Coordinates.Y += States[s].Position.Y;
						GameObjectManager.Objects[i].Mesh.Vertices[k].Coordinates.Z += States[s].Position.Z;
						GameObjectManager.Objects[i].Mesh.Vertices[k].Coordinates.Rotate(Direction, Up, Side);
						GameObjectManager.Objects[i].Mesh.Vertices[k].Coordinates.X += Position.X;
						GameObjectManager.Objects[i].Mesh.Vertices[k].Coordinates.Y += Position.Y;
						GameObjectManager.Objects[i].Mesh.Vertices[k].Coordinates.Z += Position.Z;
					}
				}
				// update normals
				for (int k = 0; k < States[s].Object.Mesh.Faces.Length; k++)
				{
					for (int h = 0; h < States[s].Object.Mesh.Faces[k].Vertices.Length; h++)
					{
						GameObjectManager.Objects[i].Mesh.Faces[k].Vertices[h].Normal = States[s].Object.Mesh.Faces[k].Vertices[h].Normal;
					}
					for (int h = 0; h < States[s].Object.Mesh.Faces[k].Vertices.Length; h++)
					{
						if (!Vector3.IsZero(States[s].Object.Mesh.Faces[k].Vertices[h].Normal))
						{
							if (rotateX)
							{
								GameObjectManager.Objects[i].Mesh.Faces[k].Vertices[h].Normal.Rotate(RotateXDirection, cosX, sinX);
							}
							if (rotateY)
							{
								GameObjectManager.Objects[i].Mesh.Faces[k].Vertices[h].Normal.Rotate(RotateYDirection, cosY, sinY);
							}
							if (rotateZ)
							{
								GameObjectManager.Objects[i].Mesh.Faces[k].Vertices[h].Normal.Rotate(RotateZDirection, cosZ, sinZ);
							}
							GameObjectManager.Objects[i].Mesh.Faces[k].Vertices[h].Normal.Rotate(Direction, Up, Side);
						}
					}
					// visibility changed
					if (Show)
					{
						if (Overlay)
						{
							OpenBveShared.Renderer.ShowObject(i, ObjectType.Overlay, Interface.CurrentOptions.TransparencyMode, World.CameraRestriction != Camera.RestrictionMode.NotAvailable);
						}
						else
						{
							OpenBveShared.Renderer.ShowObject(i, ObjectType.Dynamic, Interface.CurrentOptions.TransparencyMode, World.CameraRestriction != Camera.RestrictionMode.NotAvailable);
						}
					}
					else
					{
						OpenBveShared.Renderer.HideObject(i);
					}
				}
			}

			internal void CreateObject(Vector3 Position, Transformation BaseTransformation, Transformation AuxTransformation, int SectionIndex, double TrackPosition, double Brightness)
			{
				int a = GameObjectManager.AnimatedWorldObjectsUsed;
				if (a >= GameObjectManager.AnimatedWorldObjects.Length)
				{
					Array.Resize<WorldObject>(ref GameObjectManager.AnimatedWorldObjects, GameObjectManager.AnimatedWorldObjects.Length << 1);
				}
				Transformation FinalTransformation = new Transformation(AuxTransformation, BaseTransformation);
				
				//Place track followers if required
				if (TrackFollowerFunction != null)
				{
					var o = this.Clone();
					o.ObjectIndex = GameObjectManager.CreateDynamicObject(this.CurrentHost);
					TrackFollowingObject currentObject = new TrackFollowingObject
					{
						Position = Position,
						Direction = FinalTransformation.Z,
						Up = FinalTransformation.Y,
						Side = FinalTransformation.X,
						Object = o,
						SectionIndex = SectionIndex,
						TrackPosition = TrackPosition,
					};
					
					currentObject.FrontAxleFollower.TrackPosition = TrackPosition + FrontAxlePosition;
					currentObject.RearAxleFollower.TrackPosition = TrackPosition + RearAxlePosition;
					currentObject.FrontAxlePosition = FrontAxlePosition;
					currentObject.RearAxlePosition = RearAxlePosition;
					currentObject.FrontAxleFollower.UpdateWorldCoordinates(TrackManager.CurrentTrack, false);
					currentObject.RearAxleFollower.UpdateWorldCoordinates(TrackManager.CurrentTrack, false);
					for (int i = 0; i < currentObject.Object.States.Length; i++)
					{
						if (currentObject.Object.States[i].Object == null)
						{
							currentObject.Object.States[i].Object = new StaticObject(Program.CurrentHost)
							{
								Mesh =
								{
									Faces = new MeshFace[] {},
									Materials = new MeshMaterial[] {},
									Vertices = new VertexTemplate[] {}
								},
								RendererIndex = -1
							};
						}
					}
					double r = 0.0;
					for (int i = 0; i < currentObject.Object.States.Length; i++)
					{
						for (int j = 0; j < currentObject.Object.States[i].Object.Mesh.Materials.Length; j++)
						{
							currentObject.Object.States[i].Object.Mesh.Materials[j].Color.R = (byte)Math.Round((double)States[i].Object.Mesh.Materials[j].Color.R * Brightness);
							currentObject.Object.States[i].Object.Mesh.Materials[j].Color.G = (byte)Math.Round((double)States[i].Object.Mesh.Materials[j].Color.G * Brightness);
							currentObject.Object.States[i].Object.Mesh.Materials[j].Color.B = (byte)Math.Round((double)States[i].Object.Mesh.Materials[j].Color.B * Brightness);
						}
						for (int j = 0; j < currentObject.Object.States[i].Object.Mesh.Vertices.Length; j++)
						{
							double x = States[i].Object.Mesh.Vertices[j].Coordinates.X;
							double y = States[i].Object.Mesh.Vertices[j].Coordinates.Y;
							double z = States[i].Object.Mesh.Vertices[j].Coordinates.Z;
							double t = x * x + y * y + z * z;
							if (t > r) r = t;
						}
					}
					currentObject.Radius = Math.Sqrt(r);
					currentObject.Visible = false;
					currentObject.Object.Initialize(0, false, false);
					GameObjectManager.AnimatedWorldObjects[a] = currentObject;
				}
				else
				{
					var o = this.Clone();
					o.ObjectIndex = GameObjectManager.CreateDynamicObject(this.CurrentHost);
					AnimatedWorldObject currentObject = new AnimatedWorldObject
					{
						Position = Position,
						Direction = FinalTransformation.Z,
						Up = FinalTransformation.Y,
						Side = FinalTransformation.X,
						Object = o,
						SectionIndex = SectionIndex,
						TrackPosition = TrackPosition,
					};
					for (int i = 0; i < currentObject.Object.States.Length; i++)
					{
						if (currentObject.Object.States[i].Object == null)
						{
							currentObject.Object.States[i].Object = new StaticObject(this.CurrentHost)
							{
								Mesh =
								{
									Faces = new MeshFace[] {},
									Materials = new MeshMaterial[] {},
									Vertices = new VertexTemplate[] {}
								},
								RendererIndex = -1
							};
						}
					}
					double r = 0.0;
					for (int i = 0; i < currentObject.Object.States.Length; i++)
					{
						for (int j = 0; j < currentObject.Object.States[i].Object.Mesh.Materials.Length; j++)
						{
							currentObject.Object.States[i].Object.Mesh.Materials[j].Color.R = (byte)Math.Round((double)States[i].Object.Mesh.Materials[j].Color.R * Brightness);
							currentObject.Object.States[i].Object.Mesh.Materials[j].Color.G = (byte)Math.Round((double)States[i].Object.Mesh.Materials[j].Color.G * Brightness);
							currentObject.Object.States[i].Object.Mesh.Materials[j].Color.B = (byte)Math.Round((double)States[i].Object.Mesh.Materials[j].Color.B * Brightness);
						}
						for (int j = 0; j < currentObject.Object.States[i].Object.Mesh.Vertices.Length; j++)
						{
							double x = States[i].Object.Mesh.Vertices[j].Coordinates.X;
							double y = States[i].Object.Mesh.Vertices[j].Coordinates.Y;
							double z = States[i].Object.Mesh.Vertices[j].Coordinates.Z;
							double t = x * x + y * y + z * z;
							if (t > r) r = t;
						}
					}
					currentObject.Radius = Math.Sqrt(r);
					currentObject.Visible = false;
					currentObject.Object.Initialize(0, false, false);
					GameObjectManager.AnimatedWorldObjects[a] = currentObject;
				}

				GameObjectManager.AnimatedWorldObjectsUsed++;
			}
		}
}

