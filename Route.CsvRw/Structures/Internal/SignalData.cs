using OpenBveApi.Objects;
using OpenBveApi.Textures;

namespace Plugin
{
	/// <summary>An abstract signal - All signals must inherit from this class</summary>
	internal abstract class SignalData
	{
	}


	// ---SIGNAL TYPES---

	/// <summary>Defines a BVE 4 standard signal:
	/// A signal has a face based mesh and glow
	/// Textures are then substituted according to the aspect
	/// </summary>
	internal class Bve4SignalData : SignalData
	{
		internal UnifiedObject BaseObject;
		internal UnifiedObject GlowObject;
		internal Texture[] SignalTextures;
		internal Texture[] GlowTextures;
	}
	/// <summary>Defines a default Japanese signal (See the documentation)</summary>
	internal class CompatibilitySignalData : SignalData
	{
		internal readonly int[] Numbers;
		internal readonly StaticObject[] Objects;
		internal CompatibilitySignalData(int[] Numbers, StaticObject[] Objects)
		{
			this.Numbers = Numbers;
			this.Objects = Objects;
		}
	}
	/// <summary>Defines an animated signal object:
	/// The object is provided with the aspect number, and then should deal with the rest
	/// </summary>
	internal class AnimatedObjectSignalData : SignalData
	{
		internal UnifiedObject Objects;
	}
}
