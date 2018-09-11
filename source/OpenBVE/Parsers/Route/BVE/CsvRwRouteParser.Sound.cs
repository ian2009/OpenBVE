using System;
using System.Linq;
using System.Xml;
using OpenBveApi.Math;

namespace OpenBve
{
	internal partial class CsvRwRouteParser
	{
		private struct Sound
		{
			internal double TrackPosition;
			internal Sounds.SoundBuffer SoundBuffer;
			internal SoundType Type;
			internal TrackManager.TriggerType TriggerType;
			internal Vector3 Position;
			internal double Speed;

			internal Sound(string xmlFile, double trackPosition, double speedConversionFactor) : this()
			{
				TrackPosition = trackPosition;
				TriggerType = TrackManager.TriggerType.PlayerTrain; //Set by default to trigger from the player train only
				string fn = String.Empty; //Never actually empty, but we need to initialise the variable
				double radius = 15.0, speed = 0.0, trailingSilence = 0.0; //Default values for a sound
				Vector3 position = new Vector3();
				bool looped = false;
				//The current XML file to load
				XmlDocument currentXML = new XmlDocument();
				//Load the object's XML file 
				currentXML.Load(xmlFile);
				string Path = System.IO.Path.GetDirectoryName(xmlFile);
				//Check for null
				if (currentXML.DocumentElement != null)
				{
					XmlNodeList DocumentNodes = currentXML.DocumentElement.SelectNodes("/openBVE/WorldSound");
					if (DocumentNodes != null)
					{
						foreach (XmlNode n in DocumentNodes)
						{
							if (n.ChildNodes.OfType<XmlElement>().Any())
							{
								foreach (XmlNode c in n.ChildNodes)
								{
									switch (c.Name.ToLowerInvariant())
									{
										case "filename":
											fn = OpenBveApi.Path.CombineFile(Path, c.InnerText);
											if (!System.IO.File.Exists(fn))
											{
												Interface.AddMessage(Interface.MessageType.Warning, false, "Sound " + c.InnerText + " does not exist in XML sound " + xmlFile);
												return;
											}

											break;
										case "radius":
											if (!NumberFormats.TryParseDoubleVb6(c.InnerText, out radius))
											{
												Interface.AddMessage(Interface.MessageType.Warning, false, "Sound radius was invalid in XML sound " + xmlFile);
											}

											break;
										case "position":
											string[] splitString = c.InnerText.Split(',');
											if (!NumberFormats.TryParseDoubleVb6(splitString[0], out position.X))
											{
												Interface.AddMessage(Interface.MessageType.Warning, false, "Sound Position X was invalid in XML sound " + xmlFile);
											}

											if (!NumberFormats.TryParseDoubleVb6(splitString[1], out position.Y))
											{
												Interface.AddMessage(Interface.MessageType.Warning, false, "Sound Position Y was invalid in XML sound " + xmlFile);
											}

											if (!NumberFormats.TryParseDoubleVb6(splitString[2], out position.Z))
											{
												Interface.AddMessage(Interface.MessageType.Warning, false, "Sound Position Z was invalid in XML sound " + xmlFile);
											}

											break;
										case "looped":
											if (c.InnerText.ToLowerInvariant() == "1" || c.InnerText.ToLowerInvariant() == "true")
											{
												looped = true;
											}
											else
											{
												looped = false;
											}

											break;
										case "trainspeed":
											if (!NumberFormats.TryParseDoubleVb6(c.InnerText, out speed))
											{
												Interface.AddMessage(Interface.MessageType.Warning, false, "Sound speed was invalid in XML sound " + xmlFile);
											}
											break;
										case "triggertype":
											switch (c.InnerText.ToLowerInvariant())
											{
												case "0":
												case "player":
													TriggerType = TrackManager.TriggerType.PlayerTrain;
													break;
												case "1":
												case "ai":
													TriggerType = TrackManager.TriggerType.AITrain;
													break;
												case "2":
												case "all":
													TriggerType = TrackManager.TriggerType.AllTrains;
													break;
												default:
													Interface.AddMessage(Interface.MessageType.Warning, false, "Sound trigger type was invalid in XML sound " + xmlFile);
													break;
											}
											break;
										case "repetitioninterval":
											if (!NumberFormats.TryParseDoubleVb6(c.InnerText, out trailingSilence))
											{
												Interface.AddMessage(Interface.MessageType.Warning, false, "Repetition interval was invalid in XML sound " + xmlFile);
											}
											break;
									}
								}
							}
						}
					}
				}

				if (trailingSilence != 0.0 && !looped)
				{
					Interface.AddMessage(Interface.MessageType.Warning, false, "A repetition interval was set, but the sound is not looped in XML sound " + xmlFile);
				}
				//Data has been collected so setup the actual sound
				SoundBuffer = Sounds.RegisterBuffer(fn, radius, trailingSilence);
				Position = position;
				if (looped)
				{
					Type = SoundType.World;
				}
				else
				{
					if (speed == 0.0)
					{
						Type = SoundType.TrainStatic;
					}
					else
					{
						Type = SoundType.TrainDynamic;
						Speed = speed * speedConversionFactor;
					}
				}
			}
		}
	}
}
