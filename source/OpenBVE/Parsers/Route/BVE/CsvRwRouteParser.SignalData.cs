using OpenBveApi.Textures;

namespace OpenBve
{
	internal partial class CsvRwRouteParser
	{
		/// <summary>An abstract signal - All signals must inherit from this class</summary>
		private abstract class SignalData
		{
		}

		private static void LoadCompatibilitySignalData(ref RouteData Data, System.Text.Encoding Encoding)
		{
			string SignalFolder = OpenBveApi.Path.CombineDirectory(CompatibilityFolder, "Signals");
			Data.Signals = new SignalData[7];
			Data.Signals[3] = new CompatibilitySignalData(new int[] {0, 2, 4}, new ObjectManager.StaticObject[]
					{
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_3_0.csv"), System.Text.Encoding.UTF8, false, false, false),
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_3_2.csv"), System.Text.Encoding.UTF8, false, false, false),
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_3_4.csv"), System.Text.Encoding.UTF8, false, false, false)
					});
					Data.Signals[4] = new CompatibilitySignalData(new int[] {0, 1, 2, 4}, new ObjectManager.StaticObject[]
					{
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_4_0.csv"), System.Text.Encoding.UTF8, false, false, false),
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_4a_1.csv"), System.Text.Encoding.UTF8, false, false, false),
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_4a_2.csv"), System.Text.Encoding.UTF8, false, false, false),
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_4a_4.csv"), System.Text.Encoding.UTF8, false, false, false)
					});
					Data.Signals[5] = new CompatibilitySignalData(new int[] {0, 1, 2, 3, 4}, new ObjectManager.StaticObject[]
					{
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_5_0.csv"), System.Text.Encoding.UTF8, false, false, false),
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_5a_1.csv"), System.Text.Encoding.UTF8, false, false, false),
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_5_2.csv"), System.Text.Encoding.UTF8, false, false, false),
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_5_3.csv"), System.Text.Encoding.UTF8, false, false, false),
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_5_4.csv"), System.Text.Encoding.UTF8, false, false, false)
					});
					Data.Signals[6] = new CompatibilitySignalData(new int[] {0, 3, 4}, new ObjectManager.StaticObject[]
					{
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "repeatingsignal_0.csv"),
							Encoding, false, false, false),
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "repeatingsignal_3.csv"),
							Encoding, false, false, false),
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "repeatingsignal_4.csv"),
							Encoding, false, false, false)
					});
					// compatibility signals
					Data.CompatibilitySignals = new CompatibilitySignalData[9];
					Data.CompatibilitySignals[0] = new CompatibilitySignalData(new int[] {0, 2},
						new ObjectManager.StaticObject[]
						{
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_2_0.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_2a_2.csv"), System.Text.Encoding.UTF8, false, false, false)
						});
					Data.CompatibilitySignals[1] = new CompatibilitySignalData(new int[] {0, 4},
						new ObjectManager.StaticObject[]
						{
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_2_0.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_2b_4.csv"), System.Text.Encoding.UTF8, false, false, false)
						});
					Data.CompatibilitySignals[2] = new CompatibilitySignalData(new int[] {0, 2, 4},
						new ObjectManager.StaticObject[]
						{
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_3_0.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_3_2.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_3_4.csv"), System.Text.Encoding.UTF8, false, false, false)
						});
					Data.CompatibilitySignals[3] = new CompatibilitySignalData(new int[] {0, 1, 2, 4},
						new ObjectManager.StaticObject[]
						{
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_4_0.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_4a_1.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_4a_2.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_4a_4.csv"), System.Text.Encoding.UTF8, false, false, false)
						});
					Data.CompatibilitySignals[4] = new CompatibilitySignalData(new int[] {0, 2, 3, 4},
						new ObjectManager.StaticObject[]
						{
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_4_0.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_4b_2.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_4b_3.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_4b_4.csv"), System.Text.Encoding.UTF8, false, false, false)
						});
					Data.CompatibilitySignals[5] = new CompatibilitySignalData(new int[] {0, 1, 2, 3, 4},
						new ObjectManager.StaticObject[]
						{
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_5_0.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_5a_1.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_5_2.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_5_3.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_5_4.csv"), System.Text.Encoding.UTF8, false, false, false)
						});
					Data.CompatibilitySignals[6] = new CompatibilitySignalData(new int[] {0, 2, 3, 4, 5},
						new ObjectManager.StaticObject[]
						{
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_5_0.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_5_2.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_5_3.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_5_4.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_5b_5.csv"), System.Text.Encoding.UTF8, false, false, false)
						});
					Data.CompatibilitySignals[7] = new CompatibilitySignalData(new int[] {0, 1, 2, 3, 4, 5},
						new ObjectManager.StaticObject[]
						{
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_6_0.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_6_1.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_6_2.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_6_3.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_6_4.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "signal_6_5.csv"), System.Text.Encoding.UTF8, false, false, false)
						});
					Data.CompatibilitySignals[8] = new CompatibilitySignalData(new int[] {0, 3, 4},
						new ObjectManager.StaticObject[]
						{
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "repeatingsignal_0.csv"),
								Encoding, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "repeatingsignal_3.csv"),
								Encoding, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "repeatingsignal_4.csv"),
								Encoding, false, false, false)
						});
			switch (Data.compatibilitySignalType)
			{
				case Interface.CompatibilitySignalType.Japanese:
					//Nothing to do
					break;
				case Interface.CompatibilitySignalType.BritishRail:
					/*
					 * 4 aspect sequence changed, repeater changed
					 */
					Data.Signals[4] = new CompatibilitySignalData(new int[] {0, 1, 2, 4}, new ObjectManager.StaticObject[]
					{
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "BritishRail\\signal_4_0.csv"), System.Text.Encoding.UTF8, false, false, false),
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "BritishRail\\signal_4_1.csv"), System.Text.Encoding.UTF8, false, false, false),
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "BritishRail\\signal_4_2.csv"), System.Text.Encoding.UTF8, false, false, false),
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "BritishRail\\signal_4_4.csv"), System.Text.Encoding.UTF8, false, false, false)
					});
					Data.Signals[6] = new CompatibilitySignalData(new int[] {0, 3, 4}, new ObjectManager.StaticObject[]
					{
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "BritishRail\\repeatingsignal_0.csv"),
							Encoding, false, false, false),
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "BritishRail\\repeatingsignal_1.csv"),
							Encoding, false, false, false),
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "BritishRail\\repeatingsignal_1.csv"),
							Encoding, false, false, false)
					});
					Data.CompatibilitySignals[3] = new CompatibilitySignalData(new int[] {0, 1, 2, 4},
						new ObjectManager.StaticObject[]
						{
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "BritishRail\\signal_4_0.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "BritishRail\\signal_4_1.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "BritishRail\\signal_4_2.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "BritishRail\\signal_4_4.csv"), System.Text.Encoding.UTF8, false, false, false)
						});
					Data.CompatibilitySignals[4] = new CompatibilitySignalData(new int[] {0, 2, 3, 4},
						new ObjectManager.StaticObject[]
						{
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "BritishRail\\signal_4_0.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "BritishRail\\signal_4_1.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "BritishRail\\signal_4_2.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "BritishRail\\signal_4_4.csv"), System.Text.Encoding.UTF8, false, false, false)
						});
					Data.CompatibilitySignals[8] = new CompatibilitySignalData(new int[] {0, 3, 4},
						new ObjectManager.StaticObject[]
						{
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "BritishRail\\repeatingsignal_0.csv"),
								Encoding, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "BritishRail\\repeatingsignal_1.csv"),
								Encoding, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "BritishRail\\repeatingsignal_1.csv"),
								Encoding, false, false, false)
						});
					break;
				case Interface.CompatibilitySignalType.DeutscheBundesbahn:
					/*
					 * Total signal change
					 */
					CompatibilityObjects.SignalPost = ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_post.b3d"), System.Text.Encoding.UTF8, false, false, false);
					Data.Signals[6] = new CompatibilitySignalData(new int[] {0, 3, 4}, new ObjectManager.StaticObject[]
					{
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\repeatingsignal_0.csv"),
							Encoding, false, false, false),
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\repeatingsignal_1.csv"),
							Encoding, false, false, false),
						ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\repeatingsignal_2.csv"),
							Encoding, false, false, false)
					});
					Data.CompatibilitySignals[0] = new CompatibilitySignalData(new int[] {0, 2},
						new ObjectManager.StaticObject[]
						{
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_0.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_1.csv"), System.Text.Encoding.UTF8, false, false, false)
						});
					Data.CompatibilitySignals[1] = new CompatibilitySignalData(new int[] {0, 4},
						new ObjectManager.StaticObject[]
						{
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_0.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_2.csv"), System.Text.Encoding.UTF8, false, false, false)
						});
					Data.CompatibilitySignals[2] = new CompatibilitySignalData(new int[] {0, 2, 4},
						new ObjectManager.StaticObject[]
						{
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_0.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_1.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_2.csv"), System.Text.Encoding.UTF8, false, false, false)
						});
					Data.CompatibilitySignals[3] = new CompatibilitySignalData(new int[] {0, 1, 2, 4},
						new ObjectManager.StaticObject[]
						{
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_0.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_1.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_1.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_2.csv"), System.Text.Encoding.UTF8, false, false, false)
						});
					Data.CompatibilitySignals[4] = new CompatibilitySignalData(new int[] {0, 2, 3, 4},
						new ObjectManager.StaticObject[]
						{
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_0.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_1.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_1.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_2.csv"), System.Text.Encoding.UTF8, false, false, false)
						});
					Data.CompatibilitySignals[5] = new CompatibilitySignalData(new int[] {0, 1, 2, 3, 4},
						new ObjectManager.StaticObject[]
						{
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_0.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_1.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_1.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_2.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_3.csv"), System.Text.Encoding.UTF8, false, false, false)
						});
					Data.CompatibilitySignals[6] = new CompatibilitySignalData(new int[] {0, 2, 3, 4, 5},
						new ObjectManager.StaticObject[]
						{
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_0.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_1.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_1.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_2.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_3.csv"), System.Text.Encoding.UTF8, false, false, false)
						});
					Data.CompatibilitySignals[7] = new CompatibilitySignalData(new int[] {0, 1, 2, 3, 4, 5},
						new ObjectManager.StaticObject[]
						{
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_0.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_1.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_1.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_2.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_3.csv"), System.Text.Encoding.UTF8, false, false, false),
							ObjectManager.LoadStaticObject(OpenBveApi.Path.CombineFile(SignalFolder, "DB\\signal_3.csv"), System.Text.Encoding.UTF8, false, false, false)
						});
					break;
			}
		}

		// ---SIGNAL TYPES---

		/// <summary>Defines a BVE 4 standard signal:
		/// A signal has a face based mesh and glow
		/// Textures are then substituted according to the aspect
		/// </summary>
		private class Bve4SignalData : SignalData
		{
			internal ObjectManager.StaticObject BaseObject;
			internal ObjectManager.StaticObject GlowObject;
			internal Texture[] SignalTextures;
			internal Texture[] GlowTextures;
		}
		/// <summary>Defines a default Japanese signal (See the documentation)</summary>
		private class CompatibilitySignalData : SignalData
		{
			internal readonly int[] Numbers;
			internal readonly ObjectManager.StaticObject[] Objects;
			internal CompatibilitySignalData(int[] Numbers, ObjectManager.StaticObject[] Objects)
			{
				this.Numbers = Numbers;
				this.Objects = Objects;
			}
		}
		/// <summary>Defines an animated signal object:
		/// The object is provided with the aspect number, and then should deal with the rest
		/// </summary>
		private class AnimatedObjectSignalData : SignalData
		{
			internal ObjectManager.AnimatedObjectCollection Objects;
		}
	}
}
