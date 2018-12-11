﻿using System;

namespace OpenBve
{
	internal static partial class Game
	{
		internal struct BogusPretrainInstruction
		{
			/// <summary>The track position at which this instruction is placed</summary>
			internal double TrackPosition;
			/// <summary>The time at which the .PreTrain command specifies the bogus train reaches this position</summary>
			internal double Time;
		}

		/// <summary>Holds all .PreTrain instructions for the current route (NOTE: Must be in distance and time ascending order)</summary>
		internal static BogusPretrainInstruction[] BogusPretrainInstructions = new BogusPretrainInstruction[] { };

		/// <summary>Represents the bogus (non-visible) AI train, placed via .PreTrain commands</summary>
		internal class BogusPretrainAI : GeneralAI
		{
			private double TimeLastProcessed;
			private double CurrentInterval;
			private readonly TrainManager.Train Train;

			internal BogusPretrainAI(TrainManager.Train train)
			{
				this.TimeLastProcessed = 0.0;
				this.CurrentInterval = 1.0;
				this.Train = train;
			}

			internal override void Trigger(double TimeElapsed)
			{
				if (SecondsSinceMidnight - TimeLastProcessed >= CurrentInterval)
				{
					TimeLastProcessed = SecondsSinceMidnight;
					CurrentInterval = 5.0;
					double ap = Double.MaxValue, at = Double.MaxValue;
					double bp = Double.MinValue, bt = Double.MinValue;
					for (int i = 0; i < BogusPretrainInstructions.Length; i++)
					{
						if (BogusPretrainInstructions[i].Time < SecondsSinceMidnight | at == Double.MaxValue)
						{
							at = BogusPretrainInstructions[i].Time;
							ap = BogusPretrainInstructions[i].TrackPosition;
						}
					}
					for (int i = BogusPretrainInstructions.Length - 1; i >= 0; i--)
					{
						if (BogusPretrainInstructions[i].Time > at | bt == Double.MinValue)
						{
							bt = BogusPretrainInstructions[i].Time;
							bp = BogusPretrainInstructions[i].TrackPosition;
						}
					}
					if (at != Double.MaxValue & bt != Double.MinValue & SecondsSinceMidnight <= BogusPretrainInstructions[BogusPretrainInstructions.Length - 1].Time)
					{
						double r = bt - at;
						if (r > 0.0)
						{
							r = (SecondsSinceMidnight - at) / r;
							if (r < 0.0) r = 0.0;
							if (r > 1.0) r = 1.0;
						}
						else
						{
							r = 0.0;
						}
						double p = ap + r * (bp - ap);
						double d = p - Train.Cars[0].FrontAxle.Follower.TrackPosition;
						for (int j = 0; j < Train.Cars.Length; j++)
						{
							Train.Cars[j].Move(d, 0.1);
						}
					}
					else
					{
						Train.Dispose();
					}
				}
			}
		}
	}
}
