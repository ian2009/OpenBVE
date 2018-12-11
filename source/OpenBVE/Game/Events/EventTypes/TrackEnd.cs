﻿using OpenBveApi;
using TrackManager;

namespace OpenBve
{
	internal static partial class TrackManager
	{
		/// <summary>This event is placed at the end of the track</summary>
		internal class TrackEndEvent : GeneralEvent
		{
			internal TrackEndEvent(double TrackPositionDelta)
			{
				this.TrackPositionDelta = TrackPositionDelta;
				this.DontTriggerAnymore = false;
			}
			public override void Trigger(int Direction, EventTriggerType TriggerType, Train train, int CarIndex)
			{
				TrainManager.Train Train = (TrainManager.Train) train;
				if (TriggerType == EventTriggerType.RearCarRearAxle & Train != TrainManager.PlayerTrain)
				{
					Train.Dispose();
				}
				else if (Train == TrainManager.PlayerTrain)
				{
					Train.Derail(CarIndex, 0.0);
				}

				if (TriggerType == EventTriggerType.Camera)
				{
					World.CameraAtWorldEnd = !World.CameraAtWorldEnd;
				}
			}
		}
	}
}
