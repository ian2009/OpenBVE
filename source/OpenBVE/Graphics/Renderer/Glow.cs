﻿using OpenBveApi.Objects;

namespace OpenBve
{
	internal static partial class Renderer
	{
		/// <summary>Gets the current intensity glow intensity, using the glow attenuation factor</summary>
		/// <param name="Vertices">The verticies to which the glow is to be applied</param>
		/// <param name="Face">The face which these vertices make up</param>
		/// <param name="GlowAttenuationData">The current glow attenuation</param>
		/// <param name="CameraX">The X-position of the camera</param>
		/// <param name="CameraY">The Y-position of the camera</param>
		/// <param name="CameraZ">The Z-position of the camera</param>
		/// <returns></returns>
		public static double GetDistanceFactor(VertexTemplate[] Vertices, ref MeshFace Face, ushort GlowAttenuationData, double CameraX, double CameraY, double CameraZ)
		{
			if (Face.Vertices.Length == 0)
			{
				return 1.0;
			}
			Glow.AttenuationMode mode;
			double halfdistance;
			Glow.SplitAttenuationData(GlowAttenuationData, out mode, out halfdistance);
			int i = (int)Face.Vertices[0].Index;
			double dx = Vertices[i].Coordinates.X - CameraX;
			double dy = Vertices[i].Coordinates.Y - CameraY;
			double dz = Vertices[i].Coordinates.Z - CameraZ;
			switch (mode)
			{
				case Glow.AttenuationMode.DivisionExponent2:
					{
						double t = dx * dx + dy * dy + dz * dz;
						return t / (t + halfdistance * halfdistance);
					}
				case Glow.AttenuationMode.DivisionExponent4:
					{
						double t = dx * dx + dy * dy + dz * dz;
						t *= t;
						halfdistance *= halfdistance;
						return t / (t + halfdistance * halfdistance);
					}
				default:
					return 1.0;
			}
		}
	}
}
